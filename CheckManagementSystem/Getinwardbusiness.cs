using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public class Getinwardbusiness
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

        public InwardEntites GetInwardDetails(InwardEntites GetInward)
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
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(GetInward), UTF8Encoding.UTF8, "application/json");
                        var response = client.PostAsync("GetInwardDetails", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        GetInward = (InwardEntites)JsonConvert.DeserializeObject(post_data, GetInward.GetType());
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
            return GetInward;
        }
    }
}
