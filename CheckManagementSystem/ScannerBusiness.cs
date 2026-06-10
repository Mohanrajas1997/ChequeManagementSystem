using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public class ScannerBusiness
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

        public DataTable GetBatchingDetails()
        {
            DataTable dtBatches = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("GetBatchingDetails").Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtBatches = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
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
            return dtBatches;
        }
        public DataTable GetBatchingList(string scan_type)
        {
            DataTable dtBatches = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(scan_type), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetBatchingList", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtBatches = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
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
            return dtBatches;
        }
        public string SaveScanedItems(DataTable dt)
        {
            string status = "";
            ScannerEntities scan = new ScannerEntities();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(dt), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("SaveScanning", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
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
            return status;
        }
        public string[] SaveScanedDetails(ScannerEntities scan)
        {
            int success = 0;
            int failure = 0;
            string[] status = new string[2];
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(scan), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("SaveScanningDetails", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string[])JsonConvert.DeserializeObject(post_data, status.GetType());
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
            return status;
        }
        public DataTable GetScanning(string batch_no)
        {
            DataTable dtscanningdtl = new DataTable();
            try
            {
                ScannerEntities scan = new ScannerEntities();
                scan.batch_no = batch_no;
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(scan), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetScanningDetails", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtscanningdtl = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
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
            return dtscanningdtl;
        }
        public DataTable GetScanningDetails()
        {
            string status = "Scanning Completed";
            DataTable dtscanningdtl = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(status), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetAllCheckerBatchList", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtscanningdtl = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
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
            return dtscanningdtl;
        }
        public DataTable GetMakerDetails()
        {
            string status = "Maker Validation Completed";
            DataTable dtscanningdtl = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(status), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetAllCheckerBatchList", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtscanningdtl = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
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
            return dtscanningdtl;
        }
        public DataTable GetUploadDetails(MasterEntities.UploadBatchEntities obj)
        {
            DataTable dtscanningdtl = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetAllUploadBatchList", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtscanningdtl = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
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
            return dtscanningdtl;
        }
        public string SaveCheckerDetails(DataTable dt)
        {
            string status = "";
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        LogHelper.WriteLog("Level 5 : Calling API..");
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(dt), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("SaveChecker", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                        LogHelper.WriteLog("Level 6 : Got API Reposonse..");
                        LogHelper.WriteLog("Level 6A :Reposonse.. " + status);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return status;
        }

        public string PersistCheckerDetails(DataTable dt)
        {
            string status = "";
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        LogHelper.WriteLog("Level 5 : Calling API..");
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(dt), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("PersistChecker", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                        LogHelper.WriteLog("Level 6 : Got API Reposonse..");
                        LogHelper.WriteLog("Level 6A :Reposonse.. " + status);

                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog("Level 7 : Error While Calling API..");
                        //LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return status;
        }

        public string SaveRejectionData(DataTable dt)
        {
            string status = "Reject";
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(dt), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("SaveRejectionDetails", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return status;
        }
        public bool ValidateMICR(string micr_code)
        {
            bool isvalid = false;
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(micr_code), UTF8Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("ValidateMICR", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    isvalid = (bool)JsonConvert.DeserializeObject(post_data, (typeof(bool)));
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
            return isvalid;
        }
        public DataTable GetMicrList()
        {
            DataTable dtMicrList = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("GetMicrList").Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtMicrList = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtMicrList;
        }

        public DataTable GetTranCodeList()
        {
            DataTable dtTranCodeList = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("GetTranCodeList").Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtTranCodeList = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtTranCodeList;
        }

        public DataTable getxmlfile(string batch_code)
        {
            bool isvalid = false;
            DataTable list = new DataTable();

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(batch_code), UTF8Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("GetXMLFileCreate", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();

                    list = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
            return list;
        }
        public DataTable GetUploadImage(string batch_no)
        {
            DataTable dtscanningdtl = new DataTable();
            try
            {
                UploadImageEntities scan = new UploadImageEntities();
                scan.in_batch_no = batch_no;
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(scan), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetUploadImage", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtscanningdtl = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtscanningdtl;
        }
        //public DataTable GetRejectionLists(string cheque_no, string cheque_amount)
        //{
        //    DataTable dtrejection = new DataTable();
        //    try
        //    {
        //        RejectionEntites rejection = new RejectionEntites();
        //        rejection.in_cheque_no = cheque_no;
        //        rejection.in_cheque_amount = cheque_amount;
        //        using (var client = new HttpClient())
        //        {
        //            try
        //            {
        //                client.BaseAddress = new Uri(apiurl);
        //                client.DefaultRequestHeaders.Accept.Clear();
        //                HttpContent content = new StringContent(JsonConvert.SerializeObject(rejection), UTF8Encoding.UTF8, "application/json");
        //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                var response = client.PostAsync("GetRejectionLists", content).Result;
        //                Stream data = response.Content.ReadAsStreamAsync().Result;
        //                StreamReader reader = new StreamReader(data);
        //                string post_data = reader.ReadToEnd();
        //                dtrejection = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
        //            }
        //            catch (Exception ex)
        //            {
        //                LogHelper.WriteLog(ex.ToString());
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return dtrejection;
        //}
        public DataTable GetRejectionLists(RejectEntities rej)
        {
            DataTable dtrejection = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(rej), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetRejectionLists", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtrejection = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtrejection;
        }
        public DataTable GetRejectionReasonLists()
        {
            DataTable dtReason = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(""), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("GetRejectReasonDetails").Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtReason = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtReason;
        }
        public string SaveUpload(string batch_code)
        {
            bool isvalid = false;
            string res = "";
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(batch_code), UTF8Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("SaveUpload", content).Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    res = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
            return res;
        }
        public string[] UploadlinkOnBatch(BatchUploadEntities upload)
        {
            string[] status = new string[4];
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(upload), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("UploadBatch", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string[])JsonConvert.DeserializeObject(post_data, (typeof(string[])));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return status;
        }
        public string UpdateBatchAmount(BatchAMTUpdateEntities values)
        {
            string status = "";
            BatchAMTUpdateEntities scan = new BatchAMTUpdateEntities();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(values), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("UpdateBatchAmount", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
        public string[] GenerateBatchLinkNo(string[] batchlist)
        {
            string[] res = new string[2];
            CTSScanEntities objcts = new CTSScanEntities();
            objcts.batchlist = batchlist;
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(objcts), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("GenerateBatchLinkNo", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        res = (string[])JsonConvert.DeserializeObject(post_data, (typeof(string[])));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return res;
        }
        public DataTable NewUpload(NewUploaEntites batch)
        {
            DataTable dt = new DataTable();
            string Batch_no = batch.batch_no;
            string upload_linkno= batch.upload_linkno;
            string generate_type= batch.generate_type;
            string upload_code= batch.upload_code;
            string location_name= batch.location_name;
            int from_index=batch.from_index;
            int to_index = batch.to_index;
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("inbatch_no", Batch_no);
                values.Add("inupload_link_no", upload_linkno);
                values.Add("ingenerate_type", generate_type);
                values.Add("inupload_code", upload_code);
                values.Add("inlocation_name", location_name);
                values.Add("from_index", from_index);
                values.Add("to_index", to_index);
                dt = con.RunProc("sp_latest_uploadgeneration", values);               
                return dt;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }

            return dt;    
            
        }
        public string GetRHEVData(RhevEntities batch)
        {
            DataTable dt = new DataTable();
            string dt1 = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.Timeout = TimeSpan.FromMilliseconds(300000);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(batch), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("Getrhevdata", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dt1 = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }

            return dt1;
        }
        public string GetRestoreData(RhevEntities batch)
        {
            DataTable dt = new DataTable();
            string dt2 = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.Timeout = TimeSpan.FromMilliseconds(300000);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(batch), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("Getrhevrestore", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dt2 = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }

            return dt2;
        }
        public DataTable GetStatusWiseCheque(StatusWiseChequeList list)
        {

            DataTable dtReason = new DataTable();
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(list), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetStatusWiseCheque", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dtReason = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtReason;
        }
        public DataTable updmicrdata(string batch_no,string ex_micr)
        {
            DataTable dt = new DataTable();
            try
            {
                UpdateMicrEntites objent = new UpdateMicrEntites();
                objent.batch_no = batch_no;
                objent.ex_micr = ex_micr;
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(objent), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("Updmicrdata", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dt = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public string SaveScanner(SaveScanner scan)
        {
            int success = 0;
            int failure = 0;
            string status = "";
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(scan), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("SaveScanner", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string)JsonConvert.DeserializeObject(post_data, status.GetType());
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }

}
