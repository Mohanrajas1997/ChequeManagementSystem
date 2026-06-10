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
    public class LoginBusiness
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();

        
        public DataTable GetLoginValidation(string UserCode, string Password, string SystemIP, int maxpwdattempt)
        {
            DataTable logindt = new DataTable();

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_user_code", UserCode);
                values.Add("in_pwd", Password);
                values.Add("in_ip_addr", SystemIP);
                values.Add("in_max_pwd_attempt", maxpwdattempt);
                logindt = con.RunProc("pr_get_loginvalidation", values);
                return logindt;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }


            return logindt;

        }

        public LoginEntities Getcreation(LoginEntities create)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(create), UTF8Encoding.UTF8, "application/json");
                    var response = client.GetAsync("creation").Result;
                    Stream data = response.Content.ReadAsStreamAsync().Result;
                    StreamReader reader = new StreamReader(data);
                    string post_data = reader.ReadToEnd();
                    create = (LoginEntities)JsonConvert.DeserializeObject(post_data, create.GetType());
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return create;

        }
    }
}
