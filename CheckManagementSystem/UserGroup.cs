using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class UserGroup : Form
    {
        public UserGroup()
        {
            InitializeComponent();
        }

        private void UserGroup_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int groupid = 0;
                string groupname = txtName.Text.Trim();
                if(txtName.Text=="")
                {
                    MessageBox.Show("Group Name cannot be empty!", "Validation", MessageBoxButtons.OK);
                    txtName.Focus();
                    return;
                }
                else
                {
                    AdminMasterBusiness objSaveMaster = new AdminMasterBusiness();

                    string[] result = objSaveMaster.SaveUserGroup(groupid, groupname);
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
            }
            catch(Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

    }
}
