DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_reuploadlist` $$
CREATE PROCEDURE `sp_get_reuploadlist`(IN In_Condition longtext)
BEGIN
-- Created by Muralidharan on 21-12-2020
if In_Condition='All' then
  set In_Condition = '';
end if;
    set @v_query=concat('SELECT
		d.upload_slno as ''Sl No'',
		d.upload_code as ''Upload Code'',
		d.upload_gid as ''UploadGid'',
		DATE_FORMAT(d.upload_date, ''%d-%m-%Y'') AS ''Upload Date'',
    concat(d.branch_code,''-'',c.branch_name) as ''Branch'',
		d.chq_type AS ''Cheque Type''
	FROM
		cms_trn_upload AS d INNER JOIN
		cms_mst_branchmaster AS c ON d.branch_code = c.branch_code
	WHERE
		 d.upload_queue_code = ''C''' , In_Condition ,' order by d.upload_gid desc ' );

	 set @stmt_str =  @v_query;
     prepare stmt from @stmt_str;
     execute stmt;
     deallocate prepare stmt;
END $$

DELIMITER ;