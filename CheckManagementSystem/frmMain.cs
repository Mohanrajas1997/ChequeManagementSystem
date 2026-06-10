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
    public partial class frmMain : Form
    {
        string user_name = "";
        int UserId = 0;
        int Usergroupid = 0;
        string Password = "";
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(int compid, string user_code)
        {
            InitializeComponent();
            UserId = compid;
            user_name = user_code;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                MenuStrip ms = new MenuStrip();
                Main();

                user_name = AdminMasterBusiness.Usercode;
                UserId = AdminMasterBusiness.UserId;
                Usergroupid = AdminMasterBusiness.Usergroupid;
                Password = AdminMasterBusiness.Password;
                if (user_name != "Admin")
                {
                    if (Usergroupid > 0)
                    {
                        ms = this.MenuStrip;
                        for (int i = 0; i < ms.Items.Count; i++)
                        {
                            Application.DoEvents();
                            LoadSubMenuItems(ms.Items[i]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubMenuItems(ToolStripItem toolStripItem)
        {
            try
            {
                ToolStripDropDownItem drp = (ToolStripDropDownItem)toolStripItem;
                int RightsCount = 0;
                string menuname = toolStripItem.Name;
                AdminMasterBusiness Obj_GetUserRights = new AdminMasterBusiness();
                DataTable dt = new DataTable();
                dt = Obj_GetUserRights.GetUserMenuAccess(menuname, UserId, Usergroupid, user_name, Password);
                if (dt.Rows.Count > 0)
                {
                    RightsCount = Convert.ToInt32(dt.Rows[0]["Rights_count"]);
                }
                if (RightsCount > 0)
                {
                    for (int i = 0; i < drp.DropDownItems.Count; i++)
                    {
                        if (drp.DropDownItems[i].Text != "")
                        {
                            Application.DoEvents();
                            LoadSubMenuItems(drp.DropDownItems[i]);
                        }
                    }
                }
                else
                {
                    toolStripItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Main()
        {
            try
            {
                frmLogin frmprintinv = new frmLogin();
                //frmprintinv.MdiParent = this;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmLogin)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuUserCreation_Click(object sender, EventArgs e)
        {
            try
            {

                frmUserMaster frmprintinv = new frmUserMaster(user_name);
                frmprintinv.MdiParent = this;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmUserMaster)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuSetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePassword frmprintinv = new ChangePassword(user_name);
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is ChangePassword)
                    {
                        f.Focus();
                        return;
                    }
                }
                // frmprintinv.StartPosition = FormStartPosition.CenterParent;
                frmprintinv.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUserGroup_Click(object sender, EventArgs e)
        {
            try
            {
                UserGroup frmprintinv = new UserGroup();
                foreach (Form f in Application.OpenForms)
                {
                    if (f is UserGroup)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.StartPosition = FormStartPosition.CenterParent;
                frmprintinv.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void mnuUserGrpRights_Click(object sender, EventArgs e)
        {
            try
            {
                frmRights frmprintinv = new frmRights(MenuStrip);
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmRights)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.StartPosition = FormStartPosition.CenterParent;
                frmprintinv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUserLog_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserManagementReport frmprintinv = new frmUserManagementReport();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmUserManagementReport)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuMasterImport_Click(object sender, EventArgs e)
        {
            try
            {
                MasterUploadTemplate frm = new MasterUploadTemplate(user_name);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuInward_Click(object sender, EventArgs e)
        {
            try
            {
                Inward frmprintinv = new Inward(user_name);
                frmprintinv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuBatching_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActiveMdiChild != null)
                {
                    if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                        return;
                    ActiveMdiChild.Close();
                }
                if (ActiveMdiChild != null)
                {
                    if (ActiveMdiChild.Text.Equals("ScannerRangers"))
                        return;
                    ActiveMdiChild.Close();
                }
                InwardQueue frmbatching = new InwardQueue();
                frmbatching.WindowState = FormWindowState.Maximized;
                frmbatching.MdiParent = this;
                frmbatching.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuScanning_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActiveMdiChild != null)
                {
                    if (ActiveMdiChild.Text.Equals("ScannerRangers"))
                        return;
                    ActiveMdiChild.Close();
                }
                if (ActiveMdiChild != null)
                {
                    if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                        return;
                    ActiveMdiChild.Close();
                }

                BatchQueue frmprintinv = new BatchQueue();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is BatchQueue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuMaker_Click(object sender, EventArgs e)
        {
            try
            {
                ScanQueue frmprintinv = new ScanQueue();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is ScanQueue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuChecker_Click(object sender, EventArgs e)
        {
            try
            {
                MakerQueue frmchecker = new MakerQueue();
                frmchecker.MdiParent = this;
                //frmchecker.Dock = DockStyle.Fill;
                frmchecker.FormClosed += new FormClosedEventHandler(this.fc_FormClosed);
                foreach (Form f in Application.OpenForms)
                {
                    if (f is MakerQueue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmchecker.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
        }

        private void mnuMicrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MicrUpdateQueue frmbatching = new MicrUpdateQueue();
                frmbatching.MdiParent = this;
                frmbatching.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is MicrUpdateQueue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmbatching.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUpload_Click(object sender, EventArgs e)
        {
            try
            {
                UploadQueue frmprintinv = new UploadQueue();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is UploadQueue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRejectionHandling_Click(object sender, EventArgs e)
        {
            try
            {
                RejectionQueue frmbatching = new RejectionQueue();
                frmbatching.MdiParent = this;
                //frmbatching.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is RejectionQueue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmbatching.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAccountMasterRpt_Click(object sender, EventArgs e)
        {
            try
            {
                AccountMst_Rpt frmprintinv = new AccountMst_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is AccountMst_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuLocationMasterRpt_Click(object sender, EventArgs e)
        {
            try
            {
                LocationMst_Rpt frmprintinv = new LocationMst_Rpt();
                frmprintinv.MdiParent = this;
                // frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is LocationMst_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuMicrMasterRpt_Click(object sender, EventArgs e)
        {
            try
            {
                MicrMaster_Rpt frmprintinv = new MicrMaster_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is MicrMaster_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCustomerMasterRpt_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerMaster_Rpt frmprintinv = new CustomerMaster_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is CustomerMaster_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAlternateMicrRpt_Click(object sender, EventArgs e)
        {
            try
            {
                AlternateMicr_Rpt frmprintinv = new AlternateMicr_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is AlternateMicr_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuInwardRpt_Click(object sender, EventArgs e)
        {
            try
            {
                Inward_Rpt frmprintinv = new Inward_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Inward_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuBatchRpt_Click(object sender, EventArgs e)
        {
            try
            {
                Batch_Rpt frmprintinv = new Batch_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Batch_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuChequeRpt_Click(object sender, EventArgs e)
        {
            try
            {
                Cheque_Rpt frmprintinv = new Cheque_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Cheque_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUploadRpt_Click(object sender, EventArgs e)
        {
            try
            {
                Upload_Rpt frmprintinv = new Upload_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Upload_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRejectionRpt_Click(object sender, EventArgs e)
        {
            try
            {
                Rejection_Rpt frmprintinv = new Rejection_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Rejection_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure to exit ?", "", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }

        private void menuImagepurge_Click(object sender, EventArgs e)
        {
            try
            {
                frmImagePurge frmprintinv = new frmImagePurge();
                frmprintinv.MdiParent = this;               
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmImagePurge)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuTran_Click(object sender, EventArgs e)
        {

        }



    }
}
