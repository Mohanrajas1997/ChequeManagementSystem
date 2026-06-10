DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_del_upload` $$
CREATE PROCEDURE `sp_del_upload`(
  in in_upload_gid int,
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

  if err_flag = true then
	  set out_result = 0;
    set out_msg = err_msg;
	  leave me;
  else
    START TRANSACTION;

    UPDATE cms_trn_upload set
      upload_queue_code = 'D'
    WHERE upload_gid = in_upload_gid
    and upload_queue_code = 'C';

    UPDATE cms_trn_batch as b
    inner join cms_trn_cheque as c on b.batch_gid = c.batch_gid and c.chq_queue_code = 'C'
    set
      b.upload_gid = 0,
      b.batch_queue_code = 'U',
      c.chq_queue_code = 'U'
    WHERE b.upload_gid = in_upload_gid
    and b.batch_queue_code = 'C';

    COMMIT;

    set out_result=1;
    set out_msg="Upload deleted successfully !";
  end if;
END $$

DELIMITER ;