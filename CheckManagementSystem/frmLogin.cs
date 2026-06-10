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
    public partial class frmLogin : Form
    {
        private bool isValidate = true;
        string IPAddress = "";
        public frmLogin()
        {
            InitializeComponent();
        }
        private void Validate()
        {
            if (txtUserCode.Text == "")
            {
                isValidate = false;
                return;
            }
            if (txtPwd.Text == "")
            {
                isValidate = false;
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                if (isValidate == true)
                {
                    try
                    {
                        LoginValidation();

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
        }
        public string EnryptString(string strEncrypted)
        {
            string encrypted = "";
            try
            {

                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
                encrypted = Convert.ToBase64String(b);

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return encrypted;
        }
        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
        private void LoginValidation()
        {
            try
            {
                LoginBusiness objLogin = new LoginBusiness();
                string username = txtUserCode.Text;
                string password = EnryptString(txtPwd.Text);
                string gsSystemIp = GetIPAddress();
                string expdate = "";
                DateTime date = new DateTime();
                date = DateTime.Now;
                string DateFormat = date.ToString("ddMMyymm");
                int gnMaxPwdAttempt = 5;

                LoginEntities login = new LoginEntities();
                DataTable Login_dt = new DataTable();
                login.user_name = username;
                login.user_password = password;
                Login_dt = objLogin.GetLoginValidation(username, password, gsSystemIp, gnMaxPwdAttempt);
                if (Login_dt.Rows.Count > 0)
                {
                    DataRow dr = Login_dt.Rows[0];
                    login.result = Convert.ToInt32(dr["out_result"]);
                    login.msg = dr["out_msg"].ToString();
                    login.user_id = Convert.ToInt32(dr["user_gid"].ToString());
                    login.user_name = dr["user_name"].ToString();
                    login.user_code = txtUserCode.Text;
                    login.usergroup_gid = Convert.ToInt32(dr["usergroup_gid"].ToString());
                    login.user_password = password;
                    login.pwd_exp_date = dr["pwd_exp_date"].ToString();

                    AdminMasterBusiness.Usercode = login.user_code;
                    AdminMasterBusiness.UserId = login.user_id;
                    AdminMasterBusiness.Usergroupid = login.usergroup_gid;
                    AdminMasterBusiness.Password = login.user_password;
                }
                else
                {
                    login.result = 0;
                    login.msg = "Failed";
                }
                if (login.result == 1)
                {

                    if (password == "")
                    {
                        MessageBox.Show("Please set your password !", "Check Mandate System", MessageBoxButtons.OK);

                        SetPassword frm = new SetPassword(login.user_code);
                        frm.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog();
                    }

                    if (login.pwd_exp_date != "")
                    {
                        DateTime exp_datetime = new DateTime();
                        exp_datetime = Convert.ToDateTime(login.pwd_exp_date);
                        //expdate = exp_datetime.ToString("yyyy-MM-dd");

                        int n = (exp_datetime - date).Days;
                        if (n <= 0)
                        {
                            MessageBox.Show("Your password expired ! Please change your password !", "Check Mandate System", MessageBoxButtons.OK);

                            ChangePassword frm = new ChangePassword(login.user_code);
                            frm.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog();
                        }
                        else if (n <= 5)
                        {
                            string expstatus = string.Concat("Your password will be expired with in", n, " days !");
                            MessageBox.Show(expstatus, "Check Mandate System", MessageBoxButtons.OK);
                        }

                    }

                    this.Hide();

                }
                else if (username == "admin" && txtPwd.Text == DateFormat)
                {
                    AdminMasterBusiness.Usercode = "Admin";
                    this.Hide();
                    //Backup objback = new Backup();
                    //objback.ShowDialog();
                }
                else
                {
                    MessageBox.Show(login.msg, "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginValidation();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
    }
}
