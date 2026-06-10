using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public class MasterBusiness
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

        public string GetAccHolderName(string account_no)
        {
            string acc_holder_name = "";
            DataTable dt = new DataTable();

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_account_no", account_no);
                dt = con.RunProc("sp_get_accounts", values);

                if (dt.Rows.Count > 0) acc_holder_name = dt.Rows[0]["Account Name"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return acc_holder_name;
        }


        //public string[] serialNo { get; set; }
        public MasterEntities.RoleMasterEntities.MastersList GetMasters(MasterEntities.RoleMasterEntities mst)
        {
            MasterEntities.RoleMasterEntities.MastersList mast = new MasterEntities.RoleMasterEntities.MastersList();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(mst), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("GetAllMasters", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    MasterEntities.RoleMasterEntities.MastersList master = new MasterEntities.RoleMasterEntities.MastersList();
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    mast = (MasterEntities.RoleMasterEntities.MastersList)JsonConvert.DeserializeObject(post_data, mast.GetType());
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return mast;
        }
        public MasterEntities.RoleMasterEntities.MastersList GetMastersForTemplate(MasterEntities.RoleMasterEntities mst)
        {
            MasterEntities.RoleMasterEntities.MastersList mast = new MasterEntities.RoleMasterEntities.MastersList();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(mst), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("GetMastersForTemplate", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    MasterEntities.RoleMasterEntities.MastersList master = new MasterEntities.RoleMasterEntities.MastersList();
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    mast = (MasterEntities.RoleMasterEntities.MastersList)JsonConvert.DeserializeObject(post_data, mast.GetType());
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return mast;
        }
        public MasterEntities.FiledEntities.FileList GetMasterFields(MasterEntities.FiledEntities fild)
        {
            List<MasterEntities.FiledEntities> Fields = new List<MasterEntities.FiledEntities>();
            MasterEntities.FiledEntities.FileList filds = new MasterEntities.FiledEntities.FileList();
            DataTable tab = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_master_id", fild.master_id);
                tab = con.RunProc("pr_get_masterfield", values);
                if (tab.Rows.Count > 0)
                {
                    DataRow dr1 = tab.Rows[0];

                    foreach (DataRow dr2 in tab.Rows)
                    {
                        MasterEntities.FiledEntities fl = new MasterEntities.FiledEntities();
                        fl.field_id = Convert.ToInt32(dr2["field_id"].ToString());
                        fl.field_name = dr2["field_name"].ToString();
                        fl.master_id = Convert.ToInt32(dr2["master_id"].ToString());
                        fl.master_name = dr2["master_name"].ToString();
                        fl.fld_sl_no = Convert.ToInt32(dr2["sl_no"].ToString());
                        filds.result = 1;
                        filds.msg = "Success";
                        Fields.Add(fl);
                    }
                    filds.Fileds = Fields;
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
            return filds;
        }

        public MasterEntities.DownloadTemplateEntities UpdateTemplate(MasterEntities.DownloadTemplateEntities fild)
        {
            MasterEntities.DownloadTemplateEntities uploadtemplate = new MasterEntities.DownloadTemplateEntities();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(fild), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("DownloadTemplate", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    uploadtemplate = (MasterEntities.DownloadTemplateEntities)JsonConvert.DeserializeObject(post_data, uploadtemplate.GetType());
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return uploadtemplate;
        }

        public MasterEntities.BankMasterEntities UpdateBankMasters(MasterEntities.BankMasterEntities bank)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(bank), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("UploadBankMasters", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        bank = (MasterEntities.BankMasterEntities)JsonConvert.DeserializeObject(post_data, bank.GetType());
                    }
                    catch (Exception ex)
                    {
                        //LogHelper.WriteLog(ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bank;
        }

        public MasterEntities.UploadMasterEntities UploadMastersData(MasterEntities.UploadMasterEntities upload)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(upload), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("UploadMastersData", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = "";
                    post_data = reader.ReadToEnd();
                    var result = JsonConvert.DeserializeObject<MasterEntities.UploadMasterValues>(post_data);
                    upload.msg = result.msg;
                    upload.result = result.result;
                    upload.fieldstatus = result.fieldstatus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return upload;
        }
        public string[] UploadAccountMaster (string AccountName,string AccountNo,string LoginUser,int lineno)
        {
            string[] result={};
            DataTable dt = new DataTable();
            Dictionary<string, Object> values = new Dictionary<string, object>();

            DataConnection con = new DataConnection();
            values.Add("In_ACCOUNT_NAME", AccountName);
            values.Add("In_ACCOUNT_NO", AccountNo);
            values.Add("In_loginuser", LoginUser);
            values.Add("In_line_no", lineno);
            values.Add("out_msg", "out");
            values.Add("out_result", "out");
            result = con.RunDmlProc("sp_ins_accountmaster", values);
        
            return result;
        }
        public string[] UploadLocationMaster(string PickupLocation, string LocationCode, string LoginUser, int lineno)
        {
            string[] result = { };
            DataTable dt = new DataTable();
            Dictionary<string, Object> values = new Dictionary<string, object>();
            DataConnection con = new DataConnection();
            values.Add("In_PICKUP_LOCATION", PickupLocation);
            values.Add("In_LOCATION_CODE", LocationCode);
            values.Add("In_loginuser", LoginUser);
            values.Add("In_line_no", lineno);
            values.Add("out_msg", "out");
            values.Add("out_result", "out");
            result = con.RunDmlProc("sp_ins_locationmaster", values);
            return result;
        }

        public string[] UploadMicrMaster(string ChqType,string MicrCode, string BankCode, string BankName, string BranchName, string BranchCode, string LoginUser, long lineno)
        {
            string[] result = { };
            DataTable dt = new DataTable();
            Dictionary<string, Object> values = new Dictionary<string, object>();
            DataConnection con = new DataConnection();
            values.Add("In_chq_type", ChqType);
            values.Add("In_micr_code", MicrCode);
            values.Add("In_bank_code", BankCode);
            values.Add("In_branch_code", BranchCode);
            values.Add("In_bank_name", BankName);
            values.Add("In_branch_name", BranchName);
            values.Add("In_loginuser", LoginUser);
            values.Add("In_line_no", lineno);
            values.Add("out_msg", "out");
            values.Add("out_result", "out");
            result = con.RunDmlProc("sp_ins_micrmaster", values);
            return result;
        }

        public string [] UpdateBluckMicrCode(string MicrCode,int batchgid)
        {
            string[] result = { };
            DataTable dt = new DataTable();
            Dictionary<string, Object> values = new Dictionary<string, object>();
            DataConnection con = new DataConnection();
            values.Add("In_Bachgid", batchgid);
            values.Add("In_MicrCode", MicrCode);            
            values.Add("out_msg", "out");
            values.Add("out_result", "out");
            result = con.RunDmlProc("sp_set_bulk_micrentry", values);
            return result;
        }

        public string[] UploadAlterNateMicrCode(string ChqType,string MicrCode, string AlterNateMicrcode, string BranchCode, string LoginUser, string DeleteFlag, long lineno)
        {
            string[] result = { };
            DataTable dt = new DataTable();
            Dictionary<string, Object> values = new Dictionary<string, object>();
            DataConnection con = new DataConnection();
            values.Add("In_chq_type", ChqType);
            values.Add("In_micr_code", MicrCode);
            values.Add("In_alternate_micr", AlterNateMicrcode);
            values.Add("In_branch_code", BranchCode);
            values.Add("In_loginuser", LoginUser);
            values.Add("In_delete_flag", DeleteFlag);
            values.Add("In_line_no", lineno);
            values.Add("out_msg", "out");
            values.Add("out_result", "out");
            result = con.RunDmlProc("sp_ins_alternatemicr", values);
            return result;
        }


        public string[] UploadCustomerMaster(string CustomerCode, string CustomerName, string LoginUser, int lineno)
        {
            string[] result = { };
            DataTable dt = new DataTable();
            Dictionary<string, Object> values = new Dictionary<string, object>();
            DataConnection con = new DataConnection();
            values.Add("In_CUSTOMER_CODE", CustomerCode);
            values.Add("In_CUSTOMER_NAME", CustomerName);           
            values.Add("In_loginuser", LoginUser);
            values.Add("In_line_no", lineno);
            values.Add("out_msg", "out");
            values.Add("out_result", "out");
            result = con.RunDmlProc("sp_ins_customermaster", values);
            return result;
        }

        public string[] UploadBankMaster(string BankCode, string BankName, string BankMicrCode, string LoginUser, int lineno)
        {
            string[] result = { };
            DataTable dt = new DataTable();
            Dictionary<string, Object> values = new Dictionary<string, object>();
            DataConnection con = new DataConnection();
            values.Add("In_bank_code", BankCode);
            values.Add("In_bank_name", BankName);
            values.Add("In_bank_micr_code", BankMicrCode);
            values.Add("In_loginuser", LoginUser);
            values.Add("In_line_no", lineno);
            values.Add("out_msg", "out");
            values.Add("out_result", "out");
            result = con.RunDmlProc("sp_ins_bankmaster", values);
            return result;
        }

        public MasterEntities.CreateMasterFieldswithTableEntities CreateMasterfieldsWithTables(MasterEntities.CreateMasterFieldswithTableEntities create)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(create), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("CreateMasterFieldsWithTables", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        create = (MasterEntities.CreateMasterFieldswithTableEntities)JsonConvert.DeserializeObject(post_data, create.GetType());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return create;
        }

        public MasterEntities.AccountMaster.AccountName GetAccount(MasterEntities.AccountMaster acc)
        {
            MasterEntities.AccountMaster.AccountName accnts = new MasterEntities.AccountMaster.AccountName();
            MasterEntities.AccountMaster ac = new MasterEntities.AccountMaster();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(acc), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("GetAccountMasterName", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    accnts = (MasterEntities.AccountMaster.AccountName)JsonConvert.DeserializeObject(post_data, accnts.GetType());
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return accnts;
        }
        public MasterEntities.CustomerMaster.Customers GetCustomers()
        {
            MasterEntities.CustomerMaster.Customers customers = new MasterEntities.CustomerMaster.Customers();
            MasterEntities.CustomerMaster ac = new MasterEntities.CustomerMaster();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                    var response = client.GetAsync("GetCusotmers").Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    customers = (MasterEntities.CustomerMaster.Customers)JsonConvert.DeserializeObject(post_data, customers.GetType());
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return customers;
        }

        public string UpdateBankMasters(int master_id)
        {
            string responses = "";
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(master_id), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("ValidateMasterUpload", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        responses = (string)JsonConvert.DeserializeObject(post_data, responses.GetType());
                    }
                    catch (Exception ex)
                    {
                        //LogHelper.WriteLog(ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return responses;
        }
       
    }
}
