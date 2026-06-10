DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_cheque` $$
CREATE PROCEDURE `sp_ins_cheque`(
  in in_batch_gid int,
  in in_chq_type varchar(9),
  in in_branch_code varchar(8),
  in in_chq_no varchar(16),
  in in_micr_code varchar(9),
  in in_tran_code varchar(2),
  in in_base_code varchar(16),
  in in_reader_txt text,
  out out_chq_gid int,
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag bool default false;
  declare v_micr_code varchar(9) default '';
  declare v_micr_disc_flag int default 0;
  declare v_chq_queue_code char(1) default 'E';

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if not exists(select batch_gid from cms_trn_batch
    where batch_gid = in_batch_gid
    and batch_queue_code = 'S') then
    set err_msg := concat(err_msg,'Batch is not available in scan queue,');
    set err_flag := true;
  end if;  

  if in_chq_type = 'CMS' then
    if not exists(select alternatemicr_gid from cms_mst_alternatemicr
      where micr_code = in_micr_code and branch_code = in_branch_code and chq_type = in_chq_type) then
	    if not exists(select micrcms_gid from  cms_mst_micrcms where micr_code=in_micr_code and branch_code = in_branch_code) then
        set v_micr_code = fn_get_localmicr(in_branch_code,substr(in_micr_code,4,3),in_branch_code);

        if v_micr_code = '' then
	        set v_micr_disc_flag=1;
          SET v_chq_queue_code='M';
        else
          set in_micr_code = v_micr_code;
        end if;
	    end if;
    else
      select alternate_micr into in_micr_code from cms_mst_alternatemicr
      where micr_code = in_micr_code and branch_code = in_branch_code
      and chq_type = in_chq_type limit 0,1;
    end if;
  end if;

  if in_chq_type = 'CTS' then
    if not exists(select alternatemicr_gid from cms_mst_alternatemicr
      where micr_code = in_micr_code and chq_type = in_chq_type) then
	    if not exists(select micrcts_gid from  cms_mst_micrcts where micr_code=in_micr_code) then
        set v_micr_disc_flag=1;
        SET v_chq_queue_code='M';
	    end if;
    else
      select alternate_micr into in_micr_code from cms_mst_alternatemicr
      where micr_code = in_micr_code
      and chq_type = in_chq_type limit 0,1;
    end if;
  end if;
  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  INSERT INTO cms_trn_cheque
  (
    batch_gid,
    chq_no,
    micr_code,
    tran_code,
    base_code,
    reader_txt,
    micr_disc_flag,
    chq_queue_code
  )
  VALUES
  (
    in_batch_gid,
    in_chq_no,
    in_micr_code,
    in_tran_code,
    in_base_code,
    in_reader_txt,
    v_micr_disc_flag,
    v_chq_queue_code
  );

  COMMIT;

  select max(chq_gid) into out_chq_gid from cms_trn_cheque where batch_gid = in_batch_gid;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;