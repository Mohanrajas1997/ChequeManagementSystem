DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_upload_rpt` $$
CREATE PROCEDURE `sp_get_upload_rpt`(
IN In_Condition longtext
)
BEGIN
-- Created by Muralidharan on 30-12-2020
if In_Condition='All' then
  set In_Condition = '';
end if;

	set @v_query=concat('  SELECT Ifnull(DATE_FORMAT(a.upload_date, ''%d-%m-%Y''),'''') AS ''Upload Date'',
							a.upload_code as ''Upload Code'',
							a.upload_slno as ''Upload Slno'',
							a.upload_seq_id as ''Upload Seq Id'',
							a.branch_code as ''Branch Code'',
							b.branch_name as ''Branch Name'',
							a.chq_type as ''Chy Type'',
							d.batch_no as ''Batch No'',
							d.dep_slip_no as ''Deposit Slip No'',
							d.customer_code as ''Customer Code'',
							d.customer_name as ''Customer Name'',
							d.tot_chq_count as ''Total Chq Count'',
							d.tot_batch_amount as ''Total Batch Amount'',
							d.valid_batch_chq_count as ''Valid Chq Count'',
							d.valid_batch_amount as ''Valid Batch Amount'',
							d.disc_chq_count as ''Disc Chq Count'',
							d.disc_batch_amount as ''Disc Batch Amount'',
							d.discmicr_count as ''Disc Micr Count'',
							d.inward_gid as ''Inward Gid'',
							d.upload_gid as ''Upload Gid'',
							c.queue_desc as ''Status''
							from cms_trn_upload as a inner join cms_mst_branchmaster as b
							on a.branch_code=b.branch_code inner join cms_mst_queue as c on a.upload_queue_code=c.queue_code
							inner join cms_trn_batch as d on a.upload_gid=d.upload_gid
							where c.queue_table=''Upload'''  , In_Condition ,' order by a.upload_gid desc');

    set @stmt_str =  @v_query;
    prepare stmt from @stmt_str;
    execute stmt;
    deallocate prepare stmt;
END $$

DELIMITER ;