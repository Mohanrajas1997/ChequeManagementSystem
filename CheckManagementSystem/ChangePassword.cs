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
    public partial class ChangePassword : Form
    {
        string UsrName = "";
        public ChangePassword(string Username)
        {
            InitializeComponent();
            UsrName = Username;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                string lsPwd = "";
                string lsNewPwd = "";
                int MaxSlno = 6;
                lsPwd = EnryptString(txtOldPwd.Text);
                lsPwd = lsPwd.Replace("'", "''");

                lsNewPwd = EnryptString(txtNewPwd.Text);
                lsNewPwd = lsNewPwd.Replace("'", "''");

                AdminMasterBusiness objSaveMaster = new AdminMasterBusiness();
                string[] result = objSaveMaster.SetPassword(UsrName, lsPwd, lsNewPwd, MaxSlno);
                if (result[1].ToString() == "1")
                {
                    MessageBox.Show(result[0].ToString());
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result[0].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return encrypted;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chgpassowrd_Load(object sender, EventArgs e)
        {

            txtUserCode.Text = UsrName;
        }

        private void ChnagePwd_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
