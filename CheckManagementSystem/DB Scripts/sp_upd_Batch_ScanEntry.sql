DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_upd_Batch_ScanEntry` $$
CREATE PROCEDURE `sp_upd_Batch_ScanEntry`(
  in in_batch_gid int,
  out out_msg text,
  out out_result int
)
me:BEGIN
-- Create by Muralidharan 17-12-2020

  declare err_msg text default '';

  declare err_flag varchar(10) default false;
  declare v_batch_chq_count int default 0;
  declare v_micr_disc_count int default 0;
  declare v_queue_code char(1) default '';

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
     set err_msg := concat(err_msg,'Batch is not available in the scan queue,');
	   set err_flag := true;
  end if;

  select
    count(*)
  into
    v_batch_chq_count
  from cms_trn_cheque
  where batch_gid = in_batch_gid
  and chq_queue_code = 'B';

  set v_batch_chq_count = ifnull(v_batch_chq_count,0);

  if v_batch_chq_count > 0 then
    set err_msg := concat(err_msg,'Few cheque(s) in the batch queue,');
    set err_flag := true;
  end if;

  if err_flag = true then
	  set out_result = 0;
    set out_msg = err_msg;
	  leave me;
  else
    select
	    count(*)
    into
	    v_micr_disc_count
    from cms_trn_cheque
    where batch_gid = in_batch_gid
    and micr_disc_flag = 1;

    select
      count(*)
    into
      v_batch_chq_count
    from cms_trn_cheque
    where batch_gid = in_batch_gid;

    if v_micr_disc_count > 0 then
      set v_queue_code = 'M';
    else
      set v_queue_code = 'E';
    end if;

    START TRANSACTION;

    UPDATE cms_trn_batch set
      batch_queue_code = v_queue_code,
	    tot_chq_count = v_batch_chq_count
	 WHERE batch_gid = in_batch_gid;

    COMMIT;

    set out_result=1;
    set out_msg="Record Updated Sucessfully!";
  end if;
END $$

DELIMITER ;