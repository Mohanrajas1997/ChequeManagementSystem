DELIMITER $$

DROP FUNCTION IF EXISTS `fn_get_chqxmlname` $$
CREATE FUNCTION `fn_get_chqxmlname`(in_chq_gid int) RETURNS text CHARSET latin1
BEGIN
  declare v_batch_gid int default 0;
  declare v_branch_micr_code varchar(16) default '';
  declare v_kishok_code varchar(32) default '';
  declare v_upload_date datetime default null;
  declare v_upload_seq_id varchar(8) default '';
  declare v_chq_upload_order varchar(8) default '';
  declare v_txt text default '';
  declare v_file_name text default '';

  select
    m.branch_micr_code,
    m.kishok_code,
    u.insert_date,
    u.upload_seq_id,
    lpad(cast(c.chq_upload_order as nchar),3,'0')
  into
    v_branch_micr_code,
    v_kishok_code,
    v_upload_date,
    v_upload_seq_id,
    v_chq_upload_order
  from cms_trn_cheque as c
  inner join cms_trn_batch as b on c.batch_gid = b.batch_gid
  inner join cms_trn_inward as i on b.inward_gid = i.inward_gid
  inner join cms_trn_upload as u on b.upload_gid = u.upload_gid
  inner join cms_mst_branchmaster as m on i.branch_code = m.branch_code
  where c.chq_gid = in_chq_gid;

  set v_file_name = concat(v_file_name,'KXD_');
  set v_file_name = concat(v_file_name,v_kishok_code,'_01_');
  set v_file_name = concat(v_file_name,date_format(v_upload_date,'%d%m%Y'),'_',v_branch_micr_code,'_');
  set v_file_name = concat(v_file_name,date_format(v_upload_date,'%H%i%s'),'_',v_upload_seq_id,'_');
  set v_file_name = concat(v_file_name,v_chq_upload_order,'.xml');

  RETURN v_file_name;
END $$

DELIMITER ;