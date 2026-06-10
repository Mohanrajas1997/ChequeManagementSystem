DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_cheque_rpt` $$
CREATE PROCEDURE `sp_get_cheque_rpt`(IN In_Condition longtext
)
BEGIN
-- Created by Muralidharan on 30-12-2020
if In_Condition='All' then
  set In_Condition = '';
end if;

	set @v_query=concat( 'SELECT
		Ifnull(DATE_FORMAT(a.insert_date, ''%d-%m-%Y''),'''') AS ''Batch Date'',
		Ifnull(a.batch_no,'''') AS ''Batch No'',
		Ifnull(a.chq_type,'''') AS ''Cheque Type'',
		Ifnull(a.dep_slip_no,'''') AS ''Deposit Slip No'',
        Ifnull(a.customer_code,'''') as ''Customer Code'',
		Ifnull(a.customer_name,'''') AS ''Customer Name'',
       Ifnull(DATE_FORMAT( b.chq_date, ''%d-%m-%Y''),'''') as ''Cheque Date'',
       Ifnull(b.chq_no,'''') as ''Cheque No'',
       Ifnull(b.chq_amount,0.00) as ''Cheque Amount'',
       Ifnull(b.acc_no,'''') as ''Account No'',
       Ifnull(b.acc_holder_name,'''') as ''Account Holder Name'',
       Ifnull(b.micr_code,'''') as ''Micr Code'',
       Ifnull(b.tran_code,'''') as ''Tran Code'',
       Ifnull(b.base_code,'''') as ''Base Code'',
       CASE When b.valid_flag=0 then ''False'' else ''True'' end as ''Chq valid flag'',
       Ifnull(b.disc_reason,'''') as ''Disc Reason'',
       case when b.micr_disc_flag =0 then ''False'' else ''True'' end as ''Micr valid flag'',
        d.queue_desc as ''Chq Status'',
	   Ifnull(a.batch_gid,0) AS ''Batch Gid'',
       Ifnull(b.chq_gid,0) as ''Cheque Gid''
	FROM
		cms_trn_batch AS a
		INNER JOIN
		cms_trn_cheque as b on a.batch_gid=b.batch_gid
        inner join cms_mst_queue as d on b.chq_queue_code=d.queue_code
         where d.queue_table=''Cheque''' , In_Condition ,' order by b.chq_gid ');

    set @stmt_str =  @v_query;
    prepare stmt from @stmt_str;
    execute stmt;
    deallocate prepare stmt;
END $$

DELIMITER ;