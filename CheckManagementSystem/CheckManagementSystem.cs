using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class CheckManagementSystem : Form
    {
        int comp_id = 0;
        string user_name = string.Empty;
        public CheckManagementSystem()
        {
            InitializeComponent();
        }
        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }
        public CheckManagementSystem(int _comp_id, string _user_name)
        {
            InitializeComponent();
            comp_id = _comp_id;
            user_name = _user_name;
        }

        //private void mastersToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    //pnlScreens.Visible = true;
        //    //    pnlHelp.Visible = true;
        //    //    //CheckMandateMasters frmprintinv = new CheckMandateMasters(comp_id);
        //    //    MasterFormateTemplate frmprintinv = new MasterFormateTemplate(comp_id);
        //    //    frmprintinv.MdiParent = this;
        //    //    //frmprintinv.Dock = DockStyle.Fill;
        //    //    foreach (Form f in Application.OpenForms)
        //    //    {
        //    //        if (f is MasterFormateTemplate)
        //    //        {
        //    //            f.Focus();
        //    //            return;
        //    //        }
        //    //    }
        //    //    frmprintinv.Show();
        //    //}
        //    //catch(Exception ex)
        //    //{
        //    //    LogHelper.WriteLog(ex.ToString());
        //    //}

        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("StartScanning"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    MasterFormateTemplate MstForTemp = new MasterFormateTemplate(comp_id, user_name);
        //    MstForTemp.MdiParent = this;
        //    MstForTemp.Dock = DockStyle.Fill;
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f is MasterFormateTemplate)
        //        {
        //            f.Close();
        //            return;
        //        }
        //    }
        //    MstForTemp.Show();
        //}

        private void CheckManagementSystem_Load(object sender, EventArgs e)
        {
            UpdateTextPosition();
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("StartScanning"))
                    return;
                ActiveMdiChild.Close();
            }
            //pnlScreens.Visible = false;
            pnlHelp.Visible = false;
            TheamClass.SetTheam(this);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - MASTER UPLOAD TEMPLATE";
        //    //try
        //    //{

        //    //    MasterUploadTemplate frmprintinv = new MasterUploadTemplate(comp_id);
        //    //    frmprintinv.MdiParent = this;
        //    //    foreach (Form f in Application.OpenForms)
        //    //    {
        //    //        if (f is MasterFormateTemplate)
        //    //        {
        //    //            f.Focus();
        //    //            return;
        //    //        }
        //    //    }
        //    //    frmprintinv.Show();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    LogHelper.WriteLog(ex.ToString());
        //    //}

        //    LogHelper.WriteLog(user_name + "-Going to Upload  Menu");

        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("StartScanning"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }

        //    MasterUploadTemplate MstUplTemp = new MasterUploadTemplate(comp_id);
        //    MstUplTemp.MdiParent = this;
        //    MstUplTemp.Dock = DockStyle.Fill;
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f is MasterUploadTemplate)
        //        {
        //            f.Close();
        //            return;
        //        }
        //    }
        //    MstUplTemp.Show();
        //}

        //private void batchingToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - BATCHING";
        //    PicLoad.Visible = true;
        //    LogHelper.WriteLog(user_name + "-Going to Batching  Menu");
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }

        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("ScannerRangers"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }

        //    try
        //    {

        //        Batching frmbatching = new Batching();
        //        frmbatching.MdiParent = this;
        //        frmbatching.Dock = DockStyle.Fill;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is Batching)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmbatching.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    PicLoad.Visible = false;
        //}

        private void inwardToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - INWARD";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
            try
            {

                Inward frmprintinv = new Inward(user_name);
                frmprintinv.MdiParent = this;
                frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Inward)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        //private void scanningToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - SCANNING";
        //    PicLoad.Visible = true;
        //    LogHelper.WriteLog(user_name + "-Going to Scaning  Menu");
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("ScannerRangers"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    try
        //    {

        //        Scanner frmprintinv = new Scanner();
        //        frmprintinv.MdiParent = this;
        //        frmprintinv.Dock = DockStyle.Fill;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is Scanner)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmprintinv.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    PicLoad.Visible = false;
        //}

        //private void checkerToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - CHECKER";
        //    PicLoad.Visible = true;
        //    LogHelper.WriteLog(user_name + "-Going to Checker  Menu");
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }

        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("ScannerRangers"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    try
        //    {
        //        Checker frmchecker = new Checker();
        //        frmchecker.MdiParent = this;
        //        frmchecker.Dock = DockStyle.Fill;
        //        frmchecker.FormClosed += new FormClosedEventHandler(this.fc_FormClosed);
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is Checker)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmchecker.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    PicLoad.Visible = false;
        //}

        public void fc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
        }

        //private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - IMAGE UPLOAD";
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("ScannerRangers"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }

        //    try
        //    {
        //        Upload frmprintinv = new Upload();
        //        frmprintinv.MdiParent = this;
        //        frmprintinv.Dock = DockStyle.Fill;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is Upload)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmprintinv.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}

        private void CheckManagementSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var res = MessageBox.Show(this, "Are You Sure You Want To Exit?", "Confirmation",
            // MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //  if (res != DialogResult.Yes)
            //  {
            //      e.Cancel = true;
            //      return;
            //  }
            //  else
            //  {
            //      Application.Exit();
            //      System.Diagnostics.Process.GetCurrentProcess().Kill();
            //  }

            try
            {
                //bool ispersist = false;

                //FormCollection fc = Application.OpenForms;
                //foreach (Form frm in fc)
                //{
                //    if (frm.Name == "CheckerValidation")
                //    {
                //        ispersist = true;
                //        break;
                //    }
                //}
                //if (ispersist == true)
                //{
                //    var pers = MessageBox.Show("Note: If you Want Persist the Data PLease Click the Persist Button In Checker Screen", "Check Mandate System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //    if (pers == DialogResult.Yes)
                //    {
                //        e.Cancel = true;
                //        return;
                //    }
                //    else
                //    {
                //        var res = MessageBox.Show(this, "Are You Sure You Want To Exit?", "Confirmation",
                //       MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                //        if (res != DialogResult.Yes)
                //        {
                //            e.Cancel = true;
                //            return;
                //        }
                //        else
                //        {
                //            Application.Exit();
                //            System.Diagnostics.Process.GetCurrentProcess().Kill();
                //        }
                //    }
                //}
                //else
                //{
                var res = MessageBox.Show(this, "Are You Sure You Want To Exit?", "Confirmation",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Application.Exit();
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                //}
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void makerToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - MAKER";
        //    PicLoad.Visible = true;
        //    LogHelper.WriteLog(user_name + "-Going to Maker  Menu");
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("ScannerRangers"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    try
        //    {
        //        CMSMaker frmprintinv = new CMSMaker();
        //        frmprintinv.MdiParent = this;
        //        frmprintinv.Dock = DockStyle.Fill;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is CMSMaker)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmprintinv.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    PicLoad.Visible = false;
        //}

        //private void uploadToolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    PicLoad.Visible = true;
        //    LogHelper.WriteLog(user_name + "-Going to Upload  Menu");
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("ScannerRangers"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }

        //    try
        //    {
        //        Upload frmprintinv = new Upload();
        //        frmprintinv.Dock = DockStyle.Fill;
        //        frmprintinv.MdiParent = this;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is Upload)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmprintinv.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    PicLoad.Visible = false;
        //}

        private void rejectionHandlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - REJECTION";
            PicLoad.Visible = true;
            try
            {
                MicrUpdateList frmbatching = new MicrUpdateList();
                frmbatching.MdiParent = this;
                frmbatching.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is MicrUpdateList)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmbatching.Show();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        //private void imageUploadToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - EXTERNAL IMAGE UPLOAD";
        //    PicLoad.Visible = true;
        //    try
        //    {
        //        LogHelper.WriteLog(user_name + "-Going to image upload  Menu");
        //        ImageUpload frmbatching = new ImageUpload();
        //        frmbatching.Dock = DockStyle.Fill;
        //        frmbatching.MdiParent = this;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is ImageUpload)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmbatching.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    PicLoad.Visible = false;
        //}

        //private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - RESTORE & BACKUP";
        //    // PicLoad.Visible = true;
        //    try
        //    {
        //        LogHelper.WriteLog(user_name + "-Going to image upload  Menu");
        //        RHEVBackup frmbatching = new RHEVBackup();
        //        frmbatching.MdiParent = this;
        //        frmbatching.Dock = DockStyle.Fill;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is RHEVBackup)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmbatching.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    // PicLoad.Visible = false;
        //}

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    //pnlScreens.Visible = true;
        //    //    pnlHelp.Visible = true;
        //    //    //CheckMandateMasters frmprintinv = new CheckMandateMasters(comp_id);
        //    //    MasterFormateTemplate frmprintinv = new MasterFormateTemplate(comp_id);
        //    //    frmprintinv.MdiParent = this;
        //    //    //frmprintinv.Dock = DockStyle.Fill;
        //    //    foreach (Form f in Application.OpenForms)
        //    //    {
        //    //        if (f is MasterFormateTemplate)
        //    //        {
        //    //            f.Focus();
        //    //            return;
        //    //        }
        //    //    }
        //    //    frmprintinv.Show();
        //    //}
        //    //catch(Exception ex)
        //    //{
        //    //    LogHelper.WriteLog(ex.ToString());
        //    //}
        //    txtmenu.Text = "CMS&CTS - MASTER FORMATE TEMPLATE";

        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("CheckerValidation"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    if (ActiveMdiChild != null)
        //    {
        //        if (ActiveMdiChild.Text.Equals("StartScanning"))
        //            return;
        //        ActiveMdiChild.Close();
        //    }
        //    MasterFormateTemplate MstForTemp = new MasterFormateTemplate(comp_id, user_name);
        //    MstForTemp.MdiParent = this;
        //    MstForTemp.Dock = DockStyle.Fill;
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f is MasterFormateTemplate)
        //        {
        //            f.Close();
        //            return;
        //        }
        //    }
        //    MstForTemp.Show();
        //}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - MASTER UPLOAD TEMPLATE";
            LogHelper.WriteLog(user_name + "-Going to Upload  Menu");

            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("StartScanning"))
                    return;
                ActiveMdiChild.Close();
            }

            MasterUploadTemplate MstUplTemp = new MasterUploadTemplate(comp_id);
            MstUplTemp.MdiParent = this;
            MstUplTemp.Dock = DockStyle.Fill;
            foreach (Form f in Application.OpenForms)
            {
                if (f is MasterUploadTemplate)
                {
                    f.Close();
                    return;
                }
            }
            MstUplTemp.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - BATCHING";

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
            try
            {
                InwardQueue frmbatching = new InwardQueue();
                frmbatching.MdiParent = this;
                //frmbatching.Dock = DockStyle.Fill;
                //frmbatching.Left = 0;
                //frmbatching.Top = 0;
                //Rectangle recNew = new Rectangle();
                //recNew = this.ClientRectangle;
                //recNew.Height -= 4;
                //recNew.Width -= 22;
                //frmbatching.Size = recNew.Size;
                //foreach (Form f in Application.OpenForms)
                //{
                //    if (f is Batching)
                //    {
                //        f.Focus();
                //        return;
                //    }
                //}
                frmbatching.Show();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - INWARD";
            PicLoad.Visible = true;

            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
            try
            {

                Inward frmprintinv = new Inward(user_name);
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                //frmprintinv.Show();
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Inward)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - SCANNING";
            PicLoad.Visible = true;

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
            try
            {

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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - MAKER";
            PicLoad.Visible = true;

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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - CHECKER";
            PicLoad.Visible = true;

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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - REJECTION";
            PicLoad.Visible = true;
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
            PicLoad.Visible = false;
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - UPLOAD";
            PicLoad.Visible = true;
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        //private void toolStripButton10_Click(object sender, EventArgs e)
        //{
        //    txtmenu.Text = "CMS&CTS - EXTERNAL IMAGE UPLOAD";
        //    PicLoad.Visible = true;
        //    try
        //    {
        //        LogHelper.WriteLog(user_name + "-Going to image upload  Menu");
        //        ImageUpload frmbatching = new ImageUpload();
        //        frmbatching.MdiParent = this;
        //        frmbatching.Dock = DockStyle.Fill;
        //        foreach (Form f in Application.OpenForms)
        //        {
        //            if (f is ImageUpload)
        //            {
        //                f.Focus();
        //                return;
        //            }
        //        }
        //        frmbatching.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    PicLoad.Visible = false;
        //}

        private void tool_dashboard_Click(object sender, EventArgs e)
        {
            if (toolStripDashboard.Visible == true)
            {
                toolStripDashboard.Visible = false;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripDashboard.Visible == true)
                {
                    toolStripDashboard.Visible = false;
                }
                else
                {
                    toolStripDashboard.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void tool_Masters_Click(object sender, EventArgs e)
        {
            if (toolStripMaster.Visible == true)
            {
                toolStripMaster.Visible = false;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripMaster.Visible == true)
                {
                    toolStripMaster.Visible = false;
                }
                else
                {
                    toolStripMaster.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }

        private void tool_masterupload_Click(object sender, EventArgs e)
        {
            if (toolStripMasUpload.Visible == true)
            {
                toolStripMasUpload.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {

            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }
            if (toolStripMasUpload.Visible == true)
            {
                toolStripMasUpload.Visible = false;
            }
            else
            {
                toolStripMasUpload.Visible = true;
            }
        }

        private void tool_Inward_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - INWARD";
            if (toolStripInward.Visible == true)
            {
                toolStripInward.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripInward.Visible == true)
                {
                    toolStripInward.Visible = false;
                }
                else
                {
                    toolStripInward.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void tool_batching_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - BATCHING";
            if (toolStripBatch.Visible == true)
            {
                toolStripBatch.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripBatch.Visible == true)
                {
                    toolStripBatch.Visible = false;
                }
                else
                {
                    toolStripBatch.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void tool_Scanning_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - SCANNING";
            if (toolStripScan.Visible == true)
            {
                toolStripScan.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripScan.Visible == true)
                {
                    toolStripScan.Visible = false;
                }
                else
                {
                    toolStripScan.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void makerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - MAKER";
            if (toolStripMaker.Visible == true)
            {
                toolStripMaker.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripMaker.Visible == true)
                {
                    toolStripMaker.Visible = false;
                }
                else
                {
                    toolStripMaker.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void checkerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //txtmenu.Text = "CMS&CTS - CHECKER";
            if (toolStripChcker.Visible == true)
            {
                toolStripChcker.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripChcker.Visible == true)
                {
                    toolStripChcker.Visible = false;
                }
                else
                {
                    toolStripChcker.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void rejectionHandlingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - REJECTION";
            if (toolStripRejection.Visible == true)
            {
                toolStripRejection.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripRejection.Visible == true)
                {
                    toolStripRejection.Visible = false;
                }
                else
                {
                    toolStripRejection.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void uploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - UPLOAD";
            if (toolStripUpload.Visible == true)
            {
                toolStripUpload.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripUpload.Visible == true)
                {
                    toolStripUpload.Visible = false;
                }
                else
                {
                    toolStripUpload.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }

        }
        private void imageUploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - IMAGE UPLOAD";
            if (toolStripExternal.Visible == true)
            {
                toolStripExternal.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripExternal.Visible == true)
                {
                    toolStripExternal.Visible = false;
                }
                else
                {
                    toolStripExternal.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }
        }
        private void toolStripBackup_Click(object sender, EventArgs e)
        {
            try
            {
                txtmenu.Text = "CMS&CTS - Micr Update";
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backupAndRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripBackup.Visible == true)
            {
                toolStripBackup.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripBackup.Visible == true)
                {
                    toolStripBackup.Visible = false;
                }
                else
                {
                    toolStripBackup.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }
        }

        private void updateMICRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (toolStripUpdateMicr.Visible == true)
            {
                toolStripUpdateMicr.Visible = false;
                return;
            }
            int count = 0;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Visible == true)
                {
                    count++;
                }
            }
            if (count <= 9)
            {
                if (toolStripUpdateMicr.Visible == true)
                {
                    toolStripUpdateMicr.Visible = false;
                }
                else
                {
                    toolStripUpdateMicr.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Remove One Menu Item");
            }
        }

        private void toolStripUpdateMicr_Click(object sender, EventArgs e)
        {
            try
            {
                txtmenu.Text = "CMS&CTS - Upload MICR";
                UploadMICR frmbatching = new UploadMICR();
                frmbatching.MdiParent = this;
                frmbatching.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is UploadMICR)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmbatching.Show();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void toolStripAccountMst_Rpt_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Account Master Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }


        private void locationMaster_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Location Master Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void MicrMasterMenu_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Micr Master Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void CustomerMst_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Customer Master Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                
            }
            PicLoad.Visible = false;
        }

        private void inwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Inward Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void batchReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Batch Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void makerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Maker Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
            try
            {
                Maker_Rpt frmprintinv = new Maker_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Maker_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void checkerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Checker Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
            try
            {
                Checker_Rpt frmprintinv = new Checker_Rpt();
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Checker_Rpt)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void uploadReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Upload Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void rejectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Rejection Report";
            PicLoad.Visible = true;
            if (ActiveMdiChild != null)
            {
                if (ActiveMdiChild.Text.Equals("CheckerValidation"))
                    return;
                ActiveMdiChild.Close();
            }
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void toolStripMasUpload_Click(object sender, EventArgs e)
        {
            txtmenu.Text = "CMS&CTS - Master Upload";
            PicLoad.Visible = true;
            try
            {

                MasterUploadTemplate frm = new MasterUploadTemplate();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }

        private void toolStripMaster_Click(object sender, EventArgs e)
        {

        }

    }
}
