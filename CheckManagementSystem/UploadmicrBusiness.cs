using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public class UploadmicrBusiness
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

        public String saveuploadmicr(UploadMicrEntites uploadmicr)
        {
            string post_data = "";
            try
            {
                using (var client = new HttpClient())
                {
                    string[] res = new string[2];
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(uploadmicr), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("SaveUploadMicrData", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        post_data = reader.ReadToEnd();
                        post_data = JsonConvert.DeserializeObject(post_data).ToString(); //JsonConvert.DeserializeObject(post_data, post_data);
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
            return post_data;
        }
        public DataTable Getuploadmicr(int Getex_micr)
        {
            DataTable dt = new DataTable();
            try
            {
                GetUploadMicrEntites objent = new GetUploadMicrEntites();
                objent.GetEx_micr = Getex_micr;
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(objent), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("GetUploadMicrData",content).Result;
                        //"GetEx_micr":"152240302"
                        //var response = client.GetAsync(string.format("api/products/id={0}&type={1}", param.Id.Value, param.Id.Type));
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        dt = (DataTable)JsonConvert.DeserializeObject(post_data, (typeof(DataTable)));
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
            return dt;
        }
    }
}
