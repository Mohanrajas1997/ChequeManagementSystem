DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_checkerdtls` $$
CREATE PROCEDURE `sp_ins_checkerdtls`(
IN In_batchid int,
IN In_chqid int,
IN In_chqdate varchar(12),
IN In_chqamt double(15,2),
IN In_accno varchar(16),
IN In_accholderName varchar(125),
out out_msg text,
out out_result int
)
me:BEGIN
-- Create by Muralidharan 17-12-2020

  declare err_msg text default '';

  declare err_flag varchar(10) default false;
  declare v_batch_chq_count int default 0;
  declare v_checker_chq_count int default 0;
  declare v_total_chq_amount double(15,2) default 0;
  declare v_count int default 0;
  declare v_chq_amt double(15,2) default 0;
  declare v_chq_queue_code char(1) default '';
  
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;
  
  if In_chqid=0 then
     set err_msg := concat(err_msg,'Cheque Id not valid,');
	 set err_flag := true;
  end if;
  if In_batchid=0 then
     set err_msg := concat(err_msg,'Batch Id not valid,');
	 set err_flag := true;
  end if;

  if not exists(select chq_gid from cms_trn_cheque
    where chq_gid = In_chqid
    and chq_queue_code in ('E','U')) then
    set err_msg := concat(err_msg,'Cheque is not available in the checker/upload queue,');
    set err_flag := true;
  end if;

  if err_flag=false then
    select chq_amount,chq_queue_code into v_chq_amt,v_chq_queue_code from cms_trn_cheque
    where chq_gid = in_chqid;

    START TRANSACTION;
      Update cms_trn_cheque
      set chq_queue_code='U',
      chq_date=In_chqdate,
      chq_amount=In_chqamt,
      acc_no=In_accno,
      acc_holder_name=In_accholderName,
      valid_flag=1
      Where chq_gid=In_chqid;

      if v_chq_queue_code = 'E' then
        update cms_trn_batch
        set valid_batch_chq_count=valid_batch_chq_count+1,
        valid_batch_amount=valid_batch_amount + In_chqamt
        where batch_gid = In_batchid;
      elseif v_chq_queue_code = 'U' then
        update cms_trn_batch
        set valid_batch_amount=valid_batch_amount -v_chq_amt + In_chqamt
        where batch_gid = In_batchid;
      end if;

      select count(*) into v_count from cms_trn_cheque
      where batch_gid = In_batchid
      and chq_queue_code = 'E';

      if v_count = 0 then
        UPDATE cms_trn_batch
        SET
          batch_queue_code = 'U'
        WHERE batch_gid = In_batchid
        AND batch_queue_code = 'E';
      end if;
    COMMIT;
   set out_result=1;
   set out_msg="Record Updated Sucessfully!";

  else

   set out_result = 0;
   set out_msg = err_msg ;
   leave me;
   
  end if;
END $$

DELIMITER ;