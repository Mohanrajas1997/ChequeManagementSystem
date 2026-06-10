DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_inward` $$
CREATE PROCEDURE `sp_ins_inward`(
  in in_inward_gid int,
  in in_inward_datetime varchar(50),
  in in_lot_no varchar(50),
  in in_branch_code_name varchar(50),
  in in_pickup_location varchar(50),
  in in_cheque_count varchar(50),
  in in_inward_remark varchar(255),
  in in_created_by varchar(50),
  in in_action varchar(16),
  out out_msg text,
  out out_result int(10))
me:BEGIN

  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare inwardcount int default 0;
  declare lot_no varchar(100) default '';
  declare v_inward_slno int default 0;
 
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;
  
  if not exists(select '*' from cms_mst_branchmaster where branch_code=in_branch_code_name) then
    set err_msg= Concat('Please select valid branch name!,');
    set err_flag=true;
  end if;
  
  if not exists (select '*' from cms_mst_locationmaster where LOCATION_CODE=in_pickup_location) then
    set err_msg= Concat(err_msg,'Please select valid location name!,');
    set err_flag=true;    
  end if;
  
  if lot_no = '' then
	set v_inward_slno=  (select ifnull(max(inward_slno),0) from cms_trn_inward where inward_date = curdate());
	set v_inward_slno = v_inward_slno + 1;

	set lot_no = CONCAT("LOT",DATE_FORMAT(current_date,'%d%m%y'),'/',lpad(v_inward_slno,4,'0'));
	
 end if;
if in_action='Insert' then 
	 if err_flag = true then
		 set out_result = 0;
		 set out_msg = err_msg;    
		 leave me;
	 end if;
 
	if err_flag= false then
	   START TRANSACTION;

		  INSERT INTO cms_trn_inward (inward_date,inward_slno,lot_no,branch_code,pickup_location,chq_count,inward_queue_code,
									inward_remark,insert_date,insert_by)
		  VALUES(in_inward_datetime,v_inward_slno,lot_no,in_branch_code_name,in_pickup_location,in_cheque_count,'B',
									in_inward_remark,now(),in_created_by);
	  
	   COMMIT;
		  set out_result = 1;
		  set out_msg = 'Record Saved successfully!';  
    else
          set out_result = 0;
		  set out_msg = err_msg ;
		  leave me;          
   end if;   
end if;

if in_action='Update' then
   START TRANSACTION;
      Update cms_trn_inward
      set branch_code=in_branch_code_name,
      pickup_location=in_pickup_location,
      chq_count=in_cheque_count,
      inward_remark=in_inward_remark,
      update_date=now(),
      update_by=in_created_by
      where inward_gid=in_inward_gid
      and inward_queue_code='B'
      and chq_count>batched_chq_count;      
   COMMIT;
      set out_msg = "Record Updated Successfully";
      set out_result=1;
end if;

if in_action='Delete' then
   START TRANSACTION;
      update cms_trn_inward
      set inward_queue_code='D',
      update_date=now(),
      update_by=in_created_by
      where inward_gid=in_inward_gid
      and inward_queue_code='B'
      and batched_chq_count=0;
   COMMIT;
      set out_msg = "Record deleted successfully";
      set out_result=1;
end if;   

END $$

DELIMITER ;