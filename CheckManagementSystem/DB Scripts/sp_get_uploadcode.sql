DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_uploadcode` $$
CREATE PROCEDURE `sp_get_uploadcode`(IN In_uploadgid int)
BEGIN
    select
    In_uploadgid as Upload_gid,
    c.upload_code,
    c.upload_seq_id,
    a.batch_gid,
    a.batch_no,
    a.customer_code,
    a.customer_name,
    a.dep_slip_no,
    a.cts_acc_type,
    a.valid_batch_chq_count,
    a.valid_batch_amount,
    b.chq_gid,
	ifnull(b.chq_date,'') as chq_date,
    ifnull(b.chq_no,'') as chq_no,
    ROUND(b.chq_amount,2) as chq_amount,
    ifnull(b.acc_no,'') as acc_no,
    ifnull(b.acc_holder_name,'') as 'Drawee Name',
    ifnull(b.micr_code,'') as micr_code,
    ifnull(b.tran_code,'') as tran_code,
    ifnull(b.base_code,'') as base_code ,
    concat('FinnaxiaFile_Gnsa_',
	lpad ( convert(day(now()),CHAR),2,'0'),
	lpad(convert( month(now()),CHAR) , 2, '0'),
	year(now()),
	concat( '600',lpad(convert( hour(now()),CHAR) , 2, '0'),
	lpad(convert( minute(now()),CHAR) , 2, '0') ) )
	as 'Finnaxia',
    ifnull(d.bank_code,'') as 'BANK_CODE',
     FN_GET_FINACLENAME(In_uploadgid) AS 'Finacle'
    from cms_trn_batch as a
    inner join cms_trn_cheque as b on a.batch_gid=b.batch_gid
    and b.valid_flag=1
    and b.chq_queue_code='C'
    inner join cms_trn_upload as c on a.upload_gid=c.upload_gid
    left join cms_mst_micrcms as d on b.micr_code=d.micr_code and d.branch_code = c.branch_code
    where a.upload_gid=In_uploadgid order by b.chq_gid;
END $$

DELIMITER ;