DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_inward_rpt` $$
CREATE PROCEDURE `sp_get_inward_rpt`(IN In_Condition text)
BEGIN
-- Created by Muralidharan 28/12/2020
if In_Condition='All' then
  set In_Condition = '';
end if;
	 set @v_query=concat( 'SELECT
						  Ifnull(DATE_FORMAT(inward_date, ''%d-%m-%Y''),'''') as ''Inward Date'',
						  Ifnull(lot_no,'''') as ''Lot No'',
                          Ifnull(a.branch_code,'''') as ''Branch Code'',
                          Ifnull(b.branch_name,'''') as ''Branch Name'',
                          Ifnull(a.pickup_location,'''') as ''Location Code'',
                          Ifnull(a.chq_count,0) as ''Cheque Count'',
                          Ifnull(a.batched_chq_count,0) as ''Batched Chq Count'',
                          Ifnull(a.inward_remark,'''') as ''Remarks'',
                          Ifnull(d.queue_desc,'''') as ''Status'',
						  a.inward_gid as ''Id''
						  FROM cms_trn_inward as a inner join cms_mst_branchmaster as b on a.branch_code=b.branch_code
                          inner join cms_mst_locationmaster as c on a.pickup_location=c.LOCATION_CODE
                          inner join cms_mst_queue as d
                          on a.inward_queue_code=d.queue_code
                          WHERE
                          d.queue_table=''Inward''' , In_Condition ,' order by inward_gid ');

    set @stmt_str =  @v_query;
    prepare stmt from @stmt_str;
    execute stmt;
    deallocate prepare stmt;
END $$

DELIMITER ;