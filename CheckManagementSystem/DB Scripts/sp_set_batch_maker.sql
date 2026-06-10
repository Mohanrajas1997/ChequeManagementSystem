DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_set_batch_maker` $$
CREATE PROCEDURE `sp_set_batch_maker`(
  in in_batch_gid int,
  out out_msg text,
  out out_result int
)
me:BEGIN
-- Create by Vijayavel 19-01-2021

  declare err_msg text default '';
  declare err_flag varchar(10) default false;

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
	  and batch_queue_code = 'U') then
     set err_msg := concat(err_msg,'Batch is not available in upload queue,');
	   set err_flag := true;
  end if;

  if err_flag = true then
	  set out_result = 0;
    set out_msg = err_msg;
	  leave me;
  else
    START TRANSACTION;

    UPDATE cms_trn_batch set
      batch_queue_code = 'E' 
    WHERE batch_gid = in_batch_gid
    and batch_queue_code = 'U';

    COMMIT;

    set out_result=1;
    set out_msg="Batch moved back to checker queue !";
  end if;
END $$

DELIMITER ;