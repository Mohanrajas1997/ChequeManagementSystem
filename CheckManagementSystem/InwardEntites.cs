using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManagementSystem
{

    public class InwardEntites
    {
        public int inward_gid { get; set; }
        public string inward_datetime { get; set; }
        public string inward_type { get; set; }
        public string lot_no { get; set; }
        public string branch_code_name { get; set; }
        public string pickup_location { get; set; }
        public string cheque_count { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
        public string created_by { get; set; }
        public string action { get; set; }
        public string msg { get; set; }
        public int result { get; set; }
    }

    public class UserMaster
    {
        public int user_gid { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string addr3 { get; set; }
        public string addr4 { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string contact_no { get; set; }
        public string sex { get; set; }
        public string dob { get; set; }
        public string doj { get; set; }
        public string desig_name { get; set; }
        public string dept_name { get; set; }
        public string user_status { get; set; }
        public int usergroup_gid { get; set; }
        public bool pwd_flag { get; set; }
        public string action { get; set; }
    }

    public class BatchEntities
    {
        public string inward_id { get; set; }
        public string batch_no { get; set; }
        public string branch_cheque_count { get; set; }
        public string batch_amount { get; set; }
        public string batch_dep_slip_no { get; set; }
        public string customer_code { get; set; }
        public string msg { get; set; }
        public int result { get; set; }
        //public string inward_id { get; set; }
        //public string batch_no { get; set; }
        //public string branch_cheque_count { get; set; }
        //public string batch_amount { get; set; }
        //public string batch_dep_slip_no { get; set; }
        //public string customer_code { get; set; }
        //public class BatchList
        //{
        //    public List<BatchEntities> batchEntities;
        //    public int result { get; set; }
        //    public string msg { get; set; }
        //}

    }
    public class BatchEntryEntities
    {
        public int BatchGid { get; set; }
        public string BatchNo { get; set; }
        public string ChqType { get; set; }
        public string CtsAccType { get; set; }
        public string CtsSingleAccNo { get; set; }
        public string CtsSingleAccHolderName { get; set; }
        public string DepositSlipNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int TotalChqCount { get; set; }
        public double TotalBatchAmount { get; set; }
        public string created_by { get; set; }
        public int InwardGid { get; set; }
        public string action { get; set; }
        public string msg { get; set; }
        public int result { get; set; }

    }
}

