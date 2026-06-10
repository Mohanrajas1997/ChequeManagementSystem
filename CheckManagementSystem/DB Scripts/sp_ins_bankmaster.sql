DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_bankmaster` $$
CREATE PROCEDURE `sp_ins_bankmaster`(
IN In_bank_code varchar(32),
IN In_bank_name varchar(128),
IN In_bank_micr_code varchar(3),
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

  if In_bank_code='' then
      set err_msg := concat(err_msg,'Bank Code is empty,');
      set err_flag := true;
  end if;

  if In_bank_name='' then
      set err_msg := concat(err_msg,'Bank Name is empty,');
      set err_flag := true;
  end if;

  if length(In_bank_micr_code) <> 3 then
    set err_msg := concat(err_msg,'Invalid Bank Micr Code,');
    set err_flag := true;
  elseif exists(select bank_gid from cms_mst_bankmaster where bank_micr_code=In_bank_micr_code ) then
    set err_msg := concat(err_msg,'Bank Micr Code alreay exists,');
    set err_flag := true;
  end if;

  if err_flag = true then
    set out_result = 0;
    set out_msg = err_msg;
    leave me;
  end if;

  if err_flag=false then
    start transaction;
    if not exists(select bank_gid from cms_mst_bankmaster where bank_code=In_bank_code ) then
       insert into cms_mst_bankmaster(bank_code,bank_name,bank_micr_code,insert_date,insert_by)
       values( In_bank_code,In_bank_name,In_bank_micr_code,now(),In_loginuser);
    else
      update cms_mst_bankmaster set
        bank_name = In_bank_name,
        bank_micr_code = In_bank_micr_code,
        update_date = now(),
        update_by = In_loginuser
      where bank_code = In_bank_code;
    end if;

     commit;

     set out_msg = 'Record Inserted Successfully !';
     set out_result = 1;
   else
     set out_result = 0;
	   set out_msg = err_msg ;
	   leave me;
   end if;
END $$

DELIMITER ;