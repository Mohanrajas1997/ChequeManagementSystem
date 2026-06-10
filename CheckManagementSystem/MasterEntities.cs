using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManagementSystem
{
    public class MasterEntities
    {
        public class RoleMasterEntities
        {
            public int comp_id { get; set; }
            public int master_id { get; set; }
            public string master_name { get; set; }
            public class MastersList
            {
                public List<RoleMasterEntities> Masters;
                public int result { get; set; }
                public string msg { get; set; }
            }
        }
        public class FiledEntities
        {
            public int field_id { get; set; }
            public int master_id { get; set; }
            public string field_name { get; set; }
            public int fld_sl_no { get; set; }
            public string master_name { get; set; }
            public class FileList
            {
                public List<FiledEntities> Fileds;
                public int result { get; set; }
                public string msg { get; set; }
            }
        }
        public class DownloadTemplateEntities
        {
            public string[] query { get; set; }
            public string result { get; set; }
        }
        public class BankMasterEntities
        {
            public int result { get; set; }
            public string msg { get; set; }
            public DataTable dtBankMaster { get; set; }
        }
        public class UploadMasterEntities
        {
            public string fieldstatus { get; set; }
            public string result { get; set; }
            public string msg { get; set; }
            public string master_name { get; set; }
            public string master_id { get; set; }
            public DataTable dtUploadData { get; set; }

            //public string[] query { get; set; }
        }
        //public class CreateMasterFields
        //{
        //    public string master_name { get; set; }
        //    public DataTable dttable { get; set; }
        //    public int master_id { get; set; }
        //    public int company_id { get; set; }
        //    public int result { get; set; }
        //    public string msg { get; set; }
        //}
        public class CreateMasterFieldswithTableEntities
        {
            public string result { get; set; }
            public string msg { get; set; }
            public string master_name { get; set; }
            public DataTable dttable { get; set; }
            public string company_id { get; set; }
            public string master_id { get; set; }

        }
        public class UploadMasterValues
        {
            public string fieldstatus { get; set; }
            public string result { get; set; }
            public string msg { get; set; }
            public string master_name { get; set; }
            public string master_id { get; set; }
        }
        public class AccountMaster
        {
            public string account_name { get; set; }
            public string account_no { get; set; }
            public class AccountName
            {
                public List<AccountMaster> Accounts;
                public int result { get; set; }
                public string msg { get; set; }
            }
        }
        public class CustomerMaster
        {
            public string account_name { get; set; }
            public string account_no { get; set; }
            public class Customers
            {
                public List<CustomerMaster> Accounts;
                public int result { get; set; }
                public string msg { get; set; }
            }
        }
        public class UploadBatchEntities
        {
            public string Type { get; set; }
            public string Location { get; set; }
            public string Batch_No { get; set; }
            public string Chq_Count { get; set; }
            public string Batch_Amount { get; set; }
            public string Dep_SlipNo { get; set; }
            public string Cust_Code { get; set; }
            public string upload_Status { get; set; }
            public string Current_Date { get; set; }
            public class UploadBatchList
            {
                public List<UploadBatchEntities> uploadbatch;
                public int result { get; set; }
                public string msg { get; set; }
            }
        }

    }
}
