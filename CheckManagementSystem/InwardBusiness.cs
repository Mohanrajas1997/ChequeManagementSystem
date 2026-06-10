using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CheckManagementSystem;
using System.Configuration;
using System.Windows.Forms;

namespace CheckManagementSystem
{

    public class InwardBusiness
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

        public DataTable GetUserDetails(string UserEmpCode)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_emp_code", UserEmpCode);
                dt = con.RunProc("sp_get_user", values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetUserGroup()
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                dt = con.RunProc("pr_get_usergroup", values);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        public string[] SaveUserMaster(UserMaster ObjUsermaster)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_user_gid", ObjUsermaster.user_gid);
                values.Add("in_user_code", ObjUsermaster.user_code);
                values.Add("in_user_name", ObjUsermaster.user_name);
                values.Add("in_addr1", ObjUsermaster.addr1);
                values.Add("in_addr2", ObjUsermaster.addr2);
                values.Add("in_addr3", ObjUsermaster.addr3);
                values.Add("in_addr4", ObjUsermaster.addr4);
                values.Add("in_city", ObjUsermaster.city);
                values.Add("in_pincode", ObjUsermaster.pincode);
                values.Add("in_contact_no", ObjUsermaster.contact_no);
                values.Add("in_sex", ObjUsermaster.sex);
                values.Add("in_dob", ObjUsermaster.dob);
                values.Add("in_doj", ObjUsermaster.doj);
                values.Add("in_desig_name", ObjUsermaster.desig_name);
                values.Add("in_dept_name", ObjUsermaster.dept_name);
                values.Add("in_user_status", ObjUsermaster.user_status);
                values.Add("in_pwd_flag", ObjUsermaster.pwd_flag);
                values.Add("in_usergroup_gid", ObjUsermaster.usergroup_gid);
                values.Add("in_action", ObjUsermaster.action);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("pr_ins_user", values);
                return result;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        public string[] SaveUpload(string BatchGid,string BranchCode,string ChqType)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_batchgid", BatchGid);
                values.Add("In_branch_code", BranchCode);
                values.Add("In_chqtype", ChqType);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_ins_uploadgeneration", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string[] MoveBatchFromUploadToMaker(long BatchId)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_batch_gid", BatchId);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_set_batch_maker", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string[] DeleteUpload(long UploadId)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_upload_gid", UploadId);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_del_upload", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string[] SaveCtsCheque(int batch_gid,int chq_gid,string cts_chq_no,double cts_chq_amount,string cts_acc_no,string cts_acc_name)
        {
            string[] result = { };

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_batch_gid", batch_gid);
                values.Add("in_chq_gid", chq_gid);
                values.Add("in_cts_chq_no", cts_chq_no);
                values.Add("in_cts_chq_amount", cts_chq_amount);
                values.Add("in_cts_acc_no", cts_acc_no);
                values.Add("in_cts_acc_name", cts_acc_name);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_ins_ctschq", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string[] DeleteCtsCheque(int chq_gid)
        {
            string[] result = { };

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_chq_gid", chq_gid);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_del_ctschq", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public List<string> TranCodeList()
        {
            List<string> trancode = new List<string>();
            DataTable dt;

            try 
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                dt = con.RunProc("sp_get_trancodelist", values);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    trancode.Add(dt.Rows[i]["tran_code"].ToString());
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return trancode;
        }

        public double GetValidChqTotal(int batch_gid)
        {
            double total = 0;
            DataTable dt;
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_batch_gid", batch_gid);
                dt = con.RunProc("sp_get_validchqtotal", values);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "")
                        total = 0;
                    else
                        total = Math.Round(Convert.ToDouble(dt.Rows[0][0].ToString()), 2);
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return total;
        }

        public string[] SaveInward(InwardEntites Inward)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_inward_gid", Inward.inward_gid);
                values.Add("in_inward_datetime", Inward.inward_datetime);
                values.Add("in_lot_no", Inward.lot_no);
                values.Add("in_branch_code_name", Inward.branch_code_name);
                values.Add("in_pickup_location", Inward.pickup_location);
                values.Add("in_cheque_count", Inward.cheque_count);
                values.Add("in_inward_remark", Inward.remarks);
                values.Add("in_created_by", Inward.created_by);
                values.Add("in_action", Inward.action);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_ins_inward", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string[] SaveMicrCode(int Batchid, int ChqGid, string MicrCode)
        {
            string[] result = { };

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Bachgid", Batchid);
                values.Add("In_Chqgid", ChqGid);
                values.Add("In_MicrCode", MicrCode);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_ins_Maker_MicrEntry", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string[] UpdateMicrCode(int ChqGid, string MicrCode)
        {
            string[] result = { };

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Chqgid", ChqGid);
                values.Add("In_MicrCode", MicrCode);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_upd_micr", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string[] SaveRejectionEntry(int Batchid, int ChqGid, int  descreasongid,string entryflag)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_batch_gid", Batchid);
                values.Add("In_chq_gid", ChqGid);
                values.Add("In_discreason_gid", descreasongid);
                values.Add("In_entryflag", entryflag);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_upd_chq_descreason", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public string[] SaveCheckerDtl(int BatchGid, int Selected_ChqGid, string ChqDate, string chqamt, string accno, string accname)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_batchid", BatchGid);
                values.Add("In_chqid", Selected_ChqGid);
                values.Add("In_chqdate", ChqDate);
                values.Add("In_chqamt", chqamt);
                values.Add("In_accno", accno);
                values.Add("In_accholderName", accname);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_ins_checkerdtls", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public DataTable GetSingleInwardDetails(int InwardGid)
        {
            DataTable dtInward = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Inward_gid", InwardGid);
                dtInward = con.RunProc("sp_get_single_inwarddetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtInward;
        }
        public DataTable GetScanImageDtls(int ChqGid)
        {
            DataTable dtScanImage = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("IN_ChqGid", ChqGid);
                dtScanImage = con.RunProc("sp_get_scanimage_checker", values);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScanImage;
        }
        public DataTable GetInwardDetails(string ConditionStatus)
        {
            DataTable dtInward = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtInward = con.RunProc("sp_get_inwarddetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtInward;
        }
        public DataTable GetBatchDetails(string ConditionStatus)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtScandtl = con.RunProc("sp_get_batchdetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }

        public DataTable GetRejectionDetails(string ConditionStatus)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtScandtl = con.RunProc("sp_get_rejection_queue", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }

        public DataTable GetMicrListDetails(string ConditionStatus)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dt = con.RunProc("sp_get_validmicr_list", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetRevokeDetails(string ConditionStatus)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtScandtl = con.RunProc("sp_get_rejection_revoke", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }

        public DataTable GetScanDetails(string ConditionStatus)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtScandtl = con.RunProc("sp_get_scandetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }

        public DataTable GetMicrUpdateBatch(string ConditionStatus)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dt = con.RunProc("sp_get_micrupdatebatch", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }


        public DataTable GetMakerDetails(string ConditionStatus)
        {
            DataTable dtScandtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtScandtl = con.RunProc("sp_get_makerdetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtScandtl;
        }

        public DataTable GetMicrDetails(int BranchGid)
        {
            DataTable dtMicrDtl = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Batchgid", BranchGid);
                dtMicrDtl = con.RunProc("sp_get_InvalidMicrDtl", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtMicrDtl;
        }

        public DataTable GetCtsCheque(int batch_gid, string chq_no)
        {
            DataTable dt = new DataTable();

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_batch_gid", batch_gid);
                values.Add("in_cts_chq_no", chq_no);
                dt = con.RunProc("sp_get_ctschq", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetCheckerDtls(int BranchGid,string chq_queue_code)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Batchgid", BranchGid);
                values.Add("in_chq_queue_code", chq_queue_code);
                dt = con.RunProc("sp_get_checkerdetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetValidMicrDtls(int BranchGid)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Batchgid", BranchGid);
                dt = con.RunProc("sp_get_validmicrdetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetUploadQueueDtls(string ConditionStatus)
        {
            DataTable dtUploadQ = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtUploadQ = con.RunProc("sp_get_uploadqueuelist", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtUploadQ;
        }
        public DataTable GetReUploadQueue(string ConditionStatus)
        {
            DataTable dtUploadQ = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Condition", ConditionStatus);
                dtUploadQ = con.RunProc("sp_get_reuploadlist", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtUploadQ;
        }

        public DataSet GetBranchLocation()
        {
            DataSet ds = new DataSet();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                ds = con.RunProc_ds("pr_get_branch_location", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        public DataTable GetDiscReason()
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                dt = con.RunProc("pr_get_disc_reason", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public DataTable GetBranches()
        {
            DataTable dtbranch = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                dtbranch = con.RunProc("pr_get_branches", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtbranch;
        }
        public DataTable GetLocation()
        {
            DataTable dtlocation = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                dtlocation = con.RunProc("pr_get_locations", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtlocation;
        }

    }
}

public class BatchBusiness
{
    string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

    public DataTable SaveBatching(List<BatchEntities> batchEntities)
    {
        DataTable dt = new DataTable();
        BatchEntities bat = new BatchEntities();
        List<BatchEntities> optionList = new List<BatchEntities>();
        try
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.Timeout = TimeSpan.FromMilliseconds(500000);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(batchEntities), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync("SaveBatching", content).Result;
                    // var response = client.PostAsync("SaveBatching", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    dt = (DataTable)JsonConvert.DeserializeObject(post_data, dt.GetType());
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
            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return dt;
    }
}

public class Getinwardbusiness
{
    string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();
    public InwardEntites GetInwardDetails()
    {
        try
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("GetInwardDetails").Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();

                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    //var response = client.PostAsync("GetInwardDetails", content).Result;
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
        return new InwardEntites();
    }

}
