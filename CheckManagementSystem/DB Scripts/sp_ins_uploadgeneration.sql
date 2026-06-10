DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_uploadgeneration` $$
CREATE PROCEDURE `sp_ins_uploadgeneration`(
IN In_batchgid varchar(225),
IN In_branch_code varchar(16),
IN In_chqtype varchar(8),
  out out_msg text,
  out out_result int(10))
me:BEGIN
  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_upload_count int default 0;
  declare v_uploadslno int default 0;
  declare v_uploadcode varchar(32);
  declare v_upload_seqid char(3);
  declare v_lastinsert_id int default 0;
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;
  
  set v_upload_count=(select count(*) from cms_trn_upload );
  set v_uploadslno=(select v_upload_count+1);

  if v_uploadslno mod 1000 = 0 then
    set v_uploadslno=(select v_upload_count+1);
  end if;

  set v_uploadcode =(select LPAD(v_uploadslno,4,0));
  set v_upload_seqid = (select LPAD(v_uploadslno mod 1000,3,0));

  START TRANSACTION;

	  insert into cms_trn_upload(upload_date,upload_code,upload_slno,upload_seq_id,branch_code,chq_type,upload_queue_code,insert_date)
	  values(current_date(),v_uploadcode,v_uploadslno,v_upload_seqid,In_branch_code,In_chqtype,'C',now());
  
	  set v_lastinsert_id=last_insert_id();
  
	 set @v_query=concat('update cms_trn_batch set upload_gid=',v_lastinsert_id,' ,batch_queue_code=''C'' 
							where batch_gid in (',In_batchgid,') and batch_queue_code=''U''  ');
	 set @stmt_str =  @v_query;
     prepare stmt from @stmt_str;
     execute stmt;
     deallocate prepare stmt; 
   COMMIT;
   
   START TRANSACTION;  
  
	 SET @rownr=0;
     set @v_sql = concat('update cms_trn_cheque set chq_queue_code=''C'',
							chq_upload_order=( SELECT @rownr := @rownr + 1 ) 
                            where batch_gid in (',In_batchgid,') 
                            and valid_flag=1 
							and chq_queue_code=''U'' 
                            order by chq_gid asc  ');
                  
	 set @stmt_str =  @v_sql;
     prepare stmt from @stmt_str;
     execute stmt;
     deallocate prepare stmt; 
     
   COMMIT;
    set out_result = v_lastinsert_id;
    set out_msg = 'Record Insert Sucessfully' ;
		      
END $$

DELIMITER ;