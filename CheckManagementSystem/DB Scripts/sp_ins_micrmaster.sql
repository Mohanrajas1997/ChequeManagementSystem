DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_micrmaster` $$
CREATE PROCEDURE `sp_ins_micrmaster`(
IN In_chq_type varchar(8),
IN In_micr_code varchar(9),
IN In_bank_code varchar(64),
in In_branch_code varchar(8),
IN In_bank_name varchar(128),
IN In_branch_name text,
IN In_loginuser varchar(128),
IN In_line_no int,
  out out_msg text,
  out out_result int
)
me:BEGIN
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
  
  if In_micr_code='' then
      set err_msg := concat(err_msg,'Micr Code is empty,');
      set err_flag := true;
  end if;

  if in_chq_type = 'CMS' then
    if not exists(select bank_gid from cms_mst_bankmaster
      where bank_code = In_bank_code) then
        set err_msg := concat(err_msg,'Invalid bank code,');
        set err_flag := true;
    end if;
  end if;

  if in_chq_type = 'CMS' then
    if not exists(select branch_gid from cms_mst_branchmaster
      where branch_code = In_branch_code) then
      set err_msg := concat(err_msg,'Invalid branch code,');
      set err_flag := true;
    end if;
  end if;

  if err_flag = true then
	  set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

   if in_chq_type = 'CMS' then
    if not exists(select micrcms_gid from cms_mst_micrcms where micr_code=In_micr_code and branch_code = In_branch_code) then
	     start transaction;
       insert into cms_mst_micrcms(
         micr_code,branch_code,
         micr_loc_code,
         micr_bank_code,
         micr_branch_code,
         bank_code,bank_name,branch_name,
         insert_date,insert_by)
       values(
         In_micr_code,In_branch_code,
         mid(In_micr_code,1,3),
         mid(In_micr_code,4,3),
         mid(In_micr_code,7,3),
         In_bank_code,In_bank_name,In_branch_name,
         now(),In_loginuser);
       commit;
    else
	     start transaction;
       update cms_mst_micrcms set 
         bank_code = In_bank_code,
         bank_name = In_bank_name,
         branch_name = In_branch_name,
         update_date = now(),
         update_by = In_loginuser
       where micr_code=In_micr_code and branch_code = In_branch_code;
       commit;
    end if;
   end if;

   if in_chq_type = 'CTS' then
     if not exists(select micrcts_gid from cms_mst_micrcts where micr_code=In_micr_code) then
	     start transaction;
       insert into cms_mst_micrcts(
         micr_code,
         bank_code,bank_name,branch_name,
         insert_date,insert_by)
       values(
         In_micr_code,
         In_bank_code,In_bank_name,In_branch_name,
         now(),In_loginuser);
       commit;
     else
	     start transaction;
       update cms_mst_micrcts set
         bank_code = In_bank_code,
         bank_name = In_bank_name,
         branch_name = In_branch_name,
         update_date = now(),
         update_by = In_loginuser
         where micr_code=In_micr_code;
       commit;
     end if;

   end if;

   set out_msg = 'Record Inserted Successfully !';
   set out_result = 1;
END $$

DELIMITER ;