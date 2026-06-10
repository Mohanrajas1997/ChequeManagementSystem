DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_ctschq` $$
CREATE PROCEDURE `sp_ins_ctschq`(
  in in_batch_gid int,
  in in_chq_gid int,
  in in_cts_chq_no varchar(16),
  in in_cts_chq_amount double(15,2),
  in in_cts_acc_no varchar(32),
  in in_cts_acc_name varchar(128),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag bool default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_result = 0;
    set out_msg = @full_error;
  END;

  if not exists(select batch_gid from cms_trn_batch
    where batch_gid = in_batch_gid
    and batch_queue_code in ('S','B','E')) then
    set err_msg := concat(err_msg,'Batch is not available in batch/scan/checker queue,');
    set err_flag := true;
  end if;

  if in_cts_chq_no = '' then
    set err_msg := concat(err_msg,'Blank cheque no,');
    set err_flag := true;
  end if;

  if in_cts_chq_amount <= 0 then
    set err_msg := concat(err_msg,'Invalid cheque amount,');
    set err_flag := true;
  end if;

  if not exists(select gid from cms_mst_accountmaster
    where ACCOUNT_NO = in_cts_acc_no) then
    set err_msg := concat(err_msg,'Invalid a/c no,');
    set err_flag := true;
  end if;

  if in_chq_gid > 0 then
    if not exists(select chq_gid from cms_trn_cheque
      where chq_gid = in_chq_gid
      and chq_queue_code in ('B','S','E')) then
      set err_msg := concat(err_msg,'Cheque is not available in the batch/scan/checker queue,');
      set err_flag := true;
    end if;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  START TRANSACTION;

  if in_chq_gid = 0 then
    INSERT INTO cms_trn_cheque
    (
      batch_gid,
      cts_chq_no,
      cts_chq_amount,
      cts_acc_no,
      cts_acc_name,
      chq_queue_code
    )
    VALUES
    (
      in_batch_gid,
      in_cts_chq_no,
      in_cts_chq_amount,
      in_cts_acc_no,
      in_cts_acc_name,
      'B'
    );
  else
    update cms_trn_cheque set
      cts_chq_no = in_cts_chq_no,
      cts_chq_amount = in_cts_chq_amount,
      cts_acc_no = in_cts_acc_no,
      cts_acc_name = in_cts_acc_name
    where chq_gid = in_chq_gid
    and chq_queue_code in ('B','S','E');
  end if;

  COMMIT;

  set out_result = 1;
  set out_msg = 'Record updated successfully !';
 END $$

DELIMITER ;