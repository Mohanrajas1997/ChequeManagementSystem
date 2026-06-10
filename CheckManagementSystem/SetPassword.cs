using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;

namespace CheckManagementSystem
{
    public partial class SetPassword : Form
    {
        string UsrCode = "";
        public SetPassword(string UserCode)
        {
            InitializeComponent();
            UsrCode = UserCode;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string NewPwd = "";
                string UserCode = "";
                string UserStatus = "";
                string Selectflag = "";
                int lnUserId = 0;
                int lnPwdSno = 0;
                int lnPasswordId = 0;
                string action = "";
                NewPwd = EnryptString(txtNewPwd.Text);
                NewPwd = NewPwd.Replace("'", "''");
                UserCode = txtUserCode.Text.Trim();
                AdminMasterBusiness ObjMasterBusiness = new AdminMasterBusiness();
                DataTable dtuser = new DataTable();
                dtuser = ObjMasterBusiness.GetUsermaster(UserCode);
                lnUserId = Convert.ToInt32(dtuser.Rows[0]["user_gid"]);
                lnPwdSno = Convert.ToInt32(dtuser.Rows[0]["pwd_sno"]);
                UserStatus = dtuser.Rows[0]["user_status"].ToString();

                if (txtNewPwd.Text == txtRetypePwd.Text)
                {
                    if (UserStatus == "N")
                    {
                        MessageBox.Show("Password not changed ! Id was deactivated !", "Validation", MessageBoxButtons.OK);
                        return;
                    }
                    else if (UserStatus == "D")
                    {
                        MessageBox.Show("Password not changed ! Id was blocked !", "Validation", MessageBoxButtons.OK);
                        return;
                    }


                    DataTable dtPwdhis = new DataTable();
                    Selectflag = "P";
                    dtPwdhis = ObjMasterBusiness.GetPasswordDtls(lnUserId, NewPwd, lnPwdSno, Selectflag);
                   

                    if (dtPwdhis.Rows.Count > 0)
                    {
                        lnPasswordId = Convert.ToInt32(dtPwdhis.Rows[0]["password_gid"]);
                        MessageBox.Show("Your password not changed ! New password matched with previous !", "Validation", MessageBoxButtons.OK);
                        return;
                    }

                    if (lnPwdSno == 6)
                    {
                        lnPwdSno = 1;
                    }
                    else
                    {
                        lnPwdSno += 1;
                    }

                    DataTable dtPwdhist = new DataTable();
                    Selectflag = "H";
                    dtPwdhist = ObjMasterBusiness.GetPasswordDtls(lnUserId, NewPwd, lnPwdSno, Selectflag);
                    if (dtPwdhist.Rows.Count > 0)
                    {
                        action = "Update";
                        AdminMasterBusiness objSaveMaster = new AdminMasterBusiness();
                        string[] result = objSaveMaster.SavePasswordHistory(lnUserId, NewPwd, lnPwdSno, lnPasswordId, action);

                    }
                    else
                    {
                        action = "Insert";
                        AdminMasterBusiness objSaveMaster = new AdminMasterBusiness();
                        string[] result = objSaveMaster.SavePasswordHistory(lnUserId, NewPwd, lnPwdSno, lnPasswordId, action);

                    }

                    action = "Update";
                    AdminMasterBusiness ObjUptMaster = new AdminMasterBusiness();
                    string[] results = ObjUptMaster.UpdatePassword(lnUserId, NewPwd, lnPwdSno, action);

                    if (results[1].ToString() == "1")
                    {
                        MessageBox.Show("Password changed successfully !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(results[0].ToString());
                    }
                }
                else
                {
                     MessageBox.Show("Password mismatch !");
                     txtRetypePwd.Focus();
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
        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        private void SetPassword_Load(object sender, EventArgs e)
        {

            txtUserCode.Text = UsrCode;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
