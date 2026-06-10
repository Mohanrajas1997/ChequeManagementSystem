DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_batch_rpt` $$
CREATE PROCEDURE `sp_get_batch_rpt`(IN In_Condition text)
BEGIN
-- Created by Muralidharan 28/12/2020
if In_Condition='All' then
  set In_Condition = '';
end if;
           set @v_query=concat( 'SELECT
						  Ifnull(DATE_FORMAT(a.insert_date, ''%d-%m-%Y''),'''') as ''Batch Date'',
						  Ifnull(a.batch_no,'''') as ''Batch No'',
                          Ifnull(a.chq_type,'''') as ''Cheque Type'',
                          Ifnull(a.dep_slip_no,'''') as ''Deposit Slip No'',
                          Ifnull(a.customer_code,'''') as ''Customer Code'',
                          Ifnull(a.customer_name,'''') as ''Customer Name'',
                          Ifnull(a.tot_chq_count,0) as ''Batch Cheque Count'',
                          Ifnull(a.tot_batch_amount,0) as ''Batch Amount'',
                          Ifnull(a.valid_batch_chq_count,0) as ''Valid Chq Count'',
                          Ifnull(a.valid_batch_amount,0) as ''Valid Amount'',
						  Ifnull(a.disc_chq_count,0) as ''Disc Chq Count'',
                          Ifnull(a.disc_batch_amount,0) as ''Disc Amount'',
                          Ifnull(a.discmicr_count,0) as ''Disc Micr Count'',
                          Ifnull(d.queue_desc,'''') as ''Status'',
                          Ifnull(a.batch_gid,0) as ''Batch Id'',
                          Ifnull(a.inward_gid,0) as ''Inward Id'',
                          Ifnull(a.upload_gid,0) as ''Upload Id''
 						  FROM cms_trn_batch as a
                          inner join cms_mst_customermaster as b on a.customer_code=b.CUSTOMER_CODE
                          inner join cms_mst_queue as d on a.batch_queue_code=d.queue_code
                          and d.queue_table=''Batch''' , In_Condition ,' order by a.batch_gid ');

    set @stmt_str =  @v_query;
    prepare stmt from @stmt_str;
    execute stmt;
    deallocate prepare stmt;
END $$

DELIMITER ;