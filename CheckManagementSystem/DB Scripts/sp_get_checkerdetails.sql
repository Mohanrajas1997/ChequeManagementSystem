DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_get_checkerdetails` $$
CREATE PROCEDURE `sp_get_checkerdetails`(
IN In_Batchgid int,
in in_chq_queue_code char(1)
)
BEGIN
-- Created By Vijayavel 06-01-2021
SET @rownr=0;
SELECT
    @rownr:=@rownr+1 AS 'Serial No',
    chq_gid AS 'Cheque Gid',
    batch_gid AS 'Batch Gid',
    DATE_FORMAT(chq_date, '%d-%m-%Y') AS 'Cheque Date',
    chq_no AS 'Cheque No',
    chq_amount AS 'Cheque Amount',
    micr_code AS 'Micr Code',
    tran_code AS 'Tran Code',
    base_code AS 'Base Code',
    cts_acc_no,
    cts_acc_name,
    cts_chq_amount
FROM
    cms_trn_cheque
WHERE
    micr_disc_flag = 0
    AND chq_queue_code = in_chq_queue_code 
	AND batch_gid = In_Batchgid
ORDER BY  chq_gid asc;
END $$

DELIMITER ;