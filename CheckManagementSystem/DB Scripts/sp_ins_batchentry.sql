DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_ins_batchentry` $$
CREATE PROCEDURE `sp_ins_batchentry`(
IN In_batch_gid int,
IN In_batch_no varchar(32),
IN In_chq_type varchar(8),
IN In_cts_acc_type char(1),
IN In_cts_acc_no varchar(32),
IN In_cts_acc_name varchar(128),
IN In_dep_slip_no varchar(45),
IN In_customer_code varchar(32),
IN In_tot_chq_count int,
IN In_tot_batch_amount double(15,2),
IN In_inward_gid int,
IN In_User varchar(45),
IN In_action varchar(16),
  out out_msg text,
  out out_result int(10)
)
me:BEGIN
-- Created by Muralidharan 14-12-2020

  declare err_msg text default '';
  declare err_flag varchar(10) default false;
  declare v_customer_name varchar(128);
  declare batchcount int default 0;
  declare v_batch_no varchar(100) default '';
  declare v_Total_chq_count int default 0;
  declare v_prv_chq_count int default 0;
  declare v_inward_blnc_count int default 0;
  declare v_sum_prvinward_chq_count int default 0;
  declare v_batch_slno int default 0;
  
 DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
    @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;

    SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);

    ROLLBACK;

    set out_msg = @full_error;
    set out_result = 0;
  END;

  if In_chq_type='CMS' then
    set In_cts_acc_type = '';
    set In_cts_acc_no = '';
    set In_cts_acc_name = '';

    if not exists(select '*' from cms_mst_customermaster where CUSTOMER_CODE=In_customer_code) then
		  set err_msg= Concat(err_msg,'Please select valid Customer name!,');
		  set err_flag=true;
    else
		  set v_customer_name=(select CUSTOMER_NAME from cms_mst_customermaster where CUSTOMER_CODE=In_customer_code limit 0,1);
	  end if;
  elseif In_chq_type='CTS' then
    if In_cts_acc_type = 'S' then
      if exists(select gid from cms_mst_accountmaster where ACCOUNT_NO = In_cts_acc_no) then
        select ACCOUNT_NAME into In_cts_acc_name from cms_mst_accountmaster where ACCOUNT_NO = In_cts_acc_no limit 0,1;
      else
		    set err_msg= Concat(err_msg,'Invalid cts a/c no !,');
		    set err_flag=true;
      end if;
    elseif In_cts_acc_type = 'M' then
      set In_cts_acc_no = '';
      set In_cts_acc_name = '';
    else
		  set err_msg= Concat(err_msg,'Invalid cts a/c type !,');
		  set err_flag=true;
    end if;
  else
		  set err_msg= Concat(err_msg,'Invalid cheque type !,');
		  set err_flag=true;
  end if;

	if err_flag = true then
		 set out_result = 0;
		 set out_msg = err_msg;
		 leave me;
	end if;

  if In_action='Insert' then
    set v_inward_blnc_count=(select IFNULL((chq_count-batched_chq_count),0) from cms_trn_inward where  inward_gid= In_inward_gid
                              and inward_queue_code='B');

    if In_tot_chq_count <= v_inward_blnc_count then
      set v_batch_slno=  ifnull((select max(batch_slno) from cms_trn_batch where batch_date = curdate() and chq_type = In_chq_type),0)+1;
      set v_batch_no =  CONCAT(In_chq_type,date_format(curdate(),'%d%m%y'),'-',LPAD(v_batch_slno, 4, '0'));
      -- set batch_no =  CONCAT("BATCH","/",DATE_FORMAT(current_date,'%d'),'-',DATE_FORMAT(current_date,'%m'),'-',DATE_FORMAT(current_date,'%Y'),'/',LPAD( batchcount, 5, '0'));

      START TRANSACTION;
         Insert into cms_trn_batch(batch_date,batch_slno,batch_no,chq_type,cts_acc_type,cts_acc_no,cts_acc_holder,
                 dep_slip_no,customer_code,customer_name,tot_chq_count,tot_batch_amount,
                 batch_queue_code,insert_date,insert_by,inward_gid)
         values(curdate(),v_batch_slno,v_batch_no,In_chq_type,In_cts_acc_type,In_cts_acc_no,In_cts_acc_name,
         In_dep_slip_no,In_customer_code,v_customer_name,In_tot_chq_count,In_tot_batch_amount,
				'B',current_date(),In_User,In_inward_gid);

         update cms_trn_inward
         set batched_chq_count=batched_chq_count + In_tot_chq_count,
         update_date=now(),
         update_by=In_User
         where inward_gid=In_inward_gid;

         update cms_trn_inward set inward_queue_code='C',
         update_date=now(),
         update_by=In_User
         where inward_gid=In_inward_gid
         and chq_count=batched_chq_count;

         update cms_trn_batch as a inner join cms_trn_inward as b on a.inward_gid=b.inward_gid
         set a.batch_queue_code='S' where a.inward_gid=In_inward_gid and b.inward_queue_code='C';

      COMMIT;
      set out_result = 1;
		  set out_msg = 'Record Saved Successfully!';
    else
       set out_result = 0;
	     set out_msg = "Cheque Count greater than balance cheque count!";
	     leave me;
    end if;
  end if;

  if In_action='Update' then
    if not exists(select batch_gid from cms_trn_batch
      where batch_gid = In_batch_gid
      and batch_queue_code = 'B') then
		  set out_result = 0;
      set out_msg = 'Access denied !';
      leave me;
    end if;

    set v_inward_blnc_count=(select IFNULL((chq_count-batched_chq_count),0) from cms_trn_inward where  inward_gid= In_inward_gid
                              and inward_queue_code='B');
    set v_prv_chq_count  = (select ifnull(tot_chq_count,0) from  cms_trn_batch where batch_gid=In_batch_gid and batch_queue_code = 'B' ) ;
    set v_sum_prvinward_chq_count=(select ifnull(sum(v_inward_blnc_count+v_prv_chq_count),0));

    if v_sum_prvinward_chq_count>=In_tot_chq_count then
      if err_flag=false then
        START TRANSACTION;

			update cms_trn_batch set
			  chq_type=In_chq_type,
        cts_acc_type=In_cts_acc_type,
        cts_acc_no=In_cts_acc_no,
        cts_acc_holder=In_cts_acc_name,
			  dep_slip_no=In_dep_slip_no,
			  customer_code=In_customer_code,
			  customer_name=v_customer_name,
			  tot_chq_count=In_tot_chq_count,
			  tot_batch_amount=In_tot_batch_amount,
			  update_date=now(),
			  update_by=In_User
			where batch_gid=In_batch_gid;

			set v_Total_chq_count=(select ifnull(sum(tot_chq_count),0) from cms_trn_batch where inward_gid=In_inward_gid and batch_queue_code <> 'D' ) ;

			 update cms_trn_inward
			 set batched_chq_count=batched_chq_count-v_prv_chq_count+In_tot_chq_count,
			 update_date=now(),
			 update_by=In_User
			 where inward_gid=In_inward_gid;

			 update cms_trn_inward set inward_queue_code='C',
			 update_date=now(),
			 update_by=In_User
			 where inward_gid=In_inward_gid
			 and chq_count=batched_chq_count;

			 update cms_trn_batch as a inner join cms_trn_inward as b on a.inward_gid=b.inward_gid
			 set a.batch_queue_code='S' where a.inward_gid=In_inward_gid and b.inward_queue_code='C';

       COMMIT;
       set out_result = 1;
		    set out_msg = 'Record Updated Successfully!';
      end if;
    else
       set out_result = 0;
	     set out_msg = "Cheque Count greater than balance cheque count!";
	     leave me;
    end if;
 end if;


  if In_action='Delete' then
    if exists(select batch_gid from cms_trn_batch
      where batch_gid = In_batch_gid
      and batch_queue_code in ('B','S')) then
      select tot_chq_count into v_prv_chq_count from cms_trn_batch
      where batch_gid = In_batch_gid
      and batch_queue_code in ('B','S');
    else
      set err_msg= Concat('Access denied !');
      set err_flag=true;
      leave me;
    end if;

    START TRANSACTION;

      update cms_trn_batch
      set batch_queue_code='D',
	      update_date=now(),
		  update_by=In_User
      where batch_gid=In_batch_gid;

      update cms_trn_inward
      set batched_chq_count=batched_chq_count-v_prv_chq_count,
      inward_queue_code='B',
      update_date=now(),
      update_by=In_User
      where inward_gid=In_inward_gid;

    COMMIT;

    set out_result = 1;
    set out_msg = 'Record Deleted Successfully!';
  end if;



END $$

DELIMITER ;