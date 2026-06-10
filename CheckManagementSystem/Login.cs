using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;

namespace CheckManagementSystem
{
    public partial class Login : Form
    {
        static string myIP = "";
        private bool isValidate = true;
        public Login()
        {
            InitializeComponent();
        }
        private void Validate()
        {
            if (txt_user.Text == "")
            {
                isValidate = false;
                return;
            }
            if (txt_pswd.Text == "")
            {
                isValidate = false;
                return;
            }
        }
        private void GetIP()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            // Get the IP  
            myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                string add = addr[i].ToString();
            }
            Console.ReadLine();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            //GetIP();
            try
            {
                if (isValidate == true)
                {
                    try
                    {
                        LoginBusiness objLogin = new LoginBusiness();
                        string username = txt_user.Text;
                        string password = txt_pswd.Text;
                        LoginEntities login = new LoginEntities();
                        DataTable Login_dt = new DataTable();
                        login.user_name = username;
                        login.user_password = password;
                        //Login_dt = objLogin.GetLoginValidation(login);
                        if (Login_dt.Rows.Count > 0)
                        {
                            DataRow dr = Login_dt.Rows[0];
                            login.user_id = Convert.ToInt32(dr["user_id"].ToString());
                            login.comp_name = dr["comp_name"].ToString();
                            login.comp_code = dr["comp_code"].ToString();
                            login.user_name = dr["user_name"].ToString();
                            login.user_password = dr["password"].ToString();
                            login.user_role = dr["role"].ToString();
                            login.user_status = dr["status"].ToString();
                            login.comp_id = Convert.ToInt32(dr["comp_id"].ToString());
                            login.result = 1;
                            login.msg = "Success";
                        }
                        else
                        {
                            login.result = 0;
                            login.msg = "Failed";
                        }
                        if (login.result == 1)
                        {
                            if (username == "admin")
                            {
                                this.Hide();
                                Backup objback = new Backup();
                                objback.ShowDialog();
                            }
                            else
                            {
                                this.Hide();
                                CheckManagementSystem objcheck = new CheckManagementSystem(login.comp_id, login.user_name);
                                objcheck.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Login With Valid Credentials..", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        //LogHelper.WriteLog(txt_user.Text + "- " + ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btncrt_Click(object sender, EventArgs e)
        {
            //string constring = "server=169.38.82.134;user=root;pwd=gnsa;database=cmscts_test;";
            //using (MySqlConnection conn = new MySqlConnection(constring))
            //{
            //    conn.Open();

            //    using (MySqlTransaction trans = conn.BeginTransaction())
            //    {
            //        using (MySqlCommand command = conn.CreateCommand())
            //        {
            //            command.CommandText = query;

            //            command.ExecuteNonQuery();
            //        }

            //        trans.Commit();
            //    }
            //}


            LoginBusiness objcreate = new LoginBusiness();
            LoginEntities Create = new LoginEntities();
            Create = objcreate.Getcreation(Create);

        }


        //private void txt_pswd_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        btn_login_Click(this, new EventArgs());
        //    }
        //}
    }
}
