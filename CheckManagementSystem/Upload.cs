
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CheckManagementSystem
{
    public partial class Upload : Form
    {
        public int previousSelectedRow = -1;
        public int currectSelectedRow = -1;
        string[] status = new string[4];
        //public string Filenames[];
        public Upload()
        {
            InitializeComponent();
        }
        private Dictionary<string, string> DynamicCombo()
        {
            Dictionary<string, string> combo = new Dictionary<string, string>();
            try
            {
                ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("FilterHashKey");
                if (section != null)
                    foreach (FilterHashElement element in section.HashKeys)
                    {
                        combo.Add(element.Value, element.Value);
                    }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return combo;
        }
        private Dictionary<string, string> DynamicCombo1(string option)
        {
            Dictionary<string, string> combo = new Dictionary<string, string>();
            try
            {
                ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("FilterHashKey");
                if (section != null)
                    foreach (FilterHashElement element in section.HashKeys3)
                    {

                        combo.Add(element.Value, element.Value);
                    }
                if (option == "CMS")
                {
                    combo.Remove("Finacle");
                }
                else
                {
                    combo.Remove("Finnexia");
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return combo;

        }
        private void Upload_Load(object sender, EventArgs e)
        {
            try
            {
                cmbtype.DataSource = new BindingSource(DynamicCombo(), null);
                cmbtype.DisplayMember = "Value";
                cmbtype.ValueMember = "Key";
                InwardBusiness objinward = new InwardBusiness();
                DataTable dtbranch = objinward.GetBranches();
                DataRow dr = dtbranch.NewRow();

                dtbranch.Rows.InsertAt(dr, 0);
                foreach (DataRow row in dtbranch.Rows)
                {
                    cmbloc.DataSource = dtbranch;
                    cmbloc.DisplayMember = "Branch";
                    cmbloc.ValueMember = "Branch Code";
                }
                cmbloc.Text = "Chennai";
                cmbtype.Text = "CMS";
                if (rdoupload.Checked == true)
                {
                    lblstatus.Visible = true;
                    LoadUploadList("Upload Pending");
                    lblstatus.Visible = false;
                }
                if (gvuploadgrid.Rows.Count > 0)
                {
                    gvuploadgrid.Columns["Success"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    gvuploadgrid.Columns["Reject"].DefaultCellStyle.ForeColor = Color.Red;

                    gvuploadgrid.Columns["Success"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                    gvuploadgrid.Columns["Reject"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                    gvuploadgrid.Columns["Batch No"].ReadOnly = true;
                    gvuploadgrid.Columns["Success"].ReadOnly = true;
                    gvuploadgrid.Columns["Reject"].ReadOnly = true;
                    gvuploadgrid.Columns["Total Cheques"].ReadOnly = true;
                    gvuploadgrid.Columns["Batch Amount"].ReadOnly = true;
                    gvuploadgrid.Columns["Upload Code"].ReadOnly = true;
                }
                TheamClass.SetTheam(this);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //LoadGriddetails();
        }

        private bool CheckDublicateLinkNo(string[] uploadlink, string batch_no, string upload_code)
        {

            BatchUploadEntities upload = new BatchUploadEntities();
            ScannerBusiness sb = new ScannerBusiness();
            bool isupdate = false;
            try
            {
                int count = uploadlink.Distinct().Count();
                if (count == 1 || count == 0)
                {
                    if (uploadlink.Length == 1)
                    {
                        if (uploadlink[0] != "0")
                        {
                            int result = 0;
                            DataTable dt = (DataTable)gvuploadgrid.DataSource;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i][7].ToString() == uploadlink[0])
                                {
                                    result++;
                                }
                                else
                                {

                                }
                            }
                            if (result > 1)
                            {
                                MessageBox.Show("Link No Is Missing for this Batch", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isupdate = false;
                            }
                            else
                            {
                                isupdate = true;
                            }
                        }
                        else
                        {
                            isupdate = true;
                        }
                    }
                    else
                    {
                        isupdate = true;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Combination. Please Select the Matches Combination For Upload", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isupdate;
        }

        //private bool LatestCheckDublicateLinkNo(string[] uploadlink, string batch_no, string upload_code)
        //{

        //    BatchUploadEntities upload = new BatchUploadEntities();
        //    ScannerBusiness sb = new ScannerBusiness();
        //    bool isupdate = false;
        //    try
        //    {
        //        int count = uploadlink.Distinct().Count();
        //        if (count == 1 || count == 0)
        //        {
        //            if (uploadlink.Length == 1)
        //            {
        //                if (uploadlink[0] != "0")
        //                {
        //                    int result = 0;
        //                    DataTable dt = (DataTable)gvuploadgrid.DataSource;
        //                    for (int i = 0; i < dt.Rows.Count; i++)
        //                    {
        //                        if (dt.Rows[i][7].ToString() == uploadlink[0])
        //                        {
        //                            result++;
        //                        }
        //                        else
        //                        {

        //                        }
        //                    }
        //                    if (result > 1)
        //                    {
        //                        MessageBox.Show("Link No Is Missing for this Batch", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        isupdate = false;
        //                        PicLoad.Visible = false;
        //                    }
        //                    else
        //                    {
        //                        upload.batch_no = batch_no;
        //                        upload.upload_type = cmbtype.Text;
        //                        upload.batch_link_no = uploadlink[0];
        //                        upload.generate_type = cmbuptype.Text;
        //                        status = sb.UploadlinkOnBatch(upload);
        //                        isupdate = true;
        //                    }
        //                }
        //                else
        //                {
        //                    upload.batch_no = batch_no;
        //                    upload.upload_type = cmbtype.Text;
        //                    upload.batch_link_no = uploadlink[0];
        //                    upload.generate_type = cmbuptype.Text;
        //                    status = sb.UploadlinkOnBatch(upload);
        //                    isupdate = true;
        //                }
        //            }
        //            else
        //            {
        //                upload.batch_no = batch_no;
        //                upload.upload_type = cmbtype.Text;
        //                upload.batch_link_no = uploadlink[0];
        //                upload.generate_type = cmbuptype.Text;
        //                status = sb.UploadlinkOnBatch(upload);
        //                isupdate = true;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Incorrect Combination. Please Select the Matches Combination For Upload", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            PicLoad.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //LogHelper.WriteLog(ex.ToString());
        //        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return isupdate;
        //}

        private void btngen_Click(object sender, EventArgs e)
        {
            string[] uploadlink;
            string batch_no = "";
            string uploadcode = "";
            //btngen.Enabled = false;
            try
            {
                lblstatus.Visible = true;
                PicLoad.Visible = true;
                List<uploadgrid> list = new List<uploadgrid>();
                list.Clear();
                uploadlink = new string[gvuploadgrid.Rows.Count];
                for (int i = 0; i < gvuploadgrid.Rows.Count; i++)
                {
                    uploadgrid obj = new uploadgrid();
                    bool isSelected = Convert.ToBoolean(gvuploadgrid.Rows[i].Cells[0].Value);
                    if (isSelected)
                    {
                        obj.batch_no = gvuploadgrid.Rows[i].Cells[1].Value.ToString();
                        batch_no = batch_no + "," + gvuploadgrid.Rows[i].Cells[1].Value.ToString();
                        obj.cheque_count = gvuploadgrid.Rows[i].Cells[2].Value.ToString();
                        obj.batch_amount = gvuploadgrid.Rows[i].Cells[3].Value.ToString();
                        obj.depslip_no = gvuploadgrid.Rows[i].Cells[4].Value.ToString();
                        obj.cus_code = gvuploadgrid.Rows[i].Cells[5].Value.ToString();
                        uploadcode = uploadcode + "," + gvuploadgrid.Rows[i].Cells[7].Value.ToString();
                        uploadlink[i] = gvuploadgrid.Rows[i].Cells[8].Value.ToString();
                        //list[i].batch_no = gvuploadgrid.Rows[i].Cells[1].Value.ToString();
                        list.Add(obj);
                    }
                }
                bool isupdte = false;
                uploadlink = uploadlink.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                if (uploadlink.Length == 0)
                {
                    MessageBox.Show("Please Select Atleast one Record in Grid", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PicLoad.Visible = false;
                    return;
                }
                isupdte = CheckDublicateLinkNo(uploadlink, batch_no, uploadcode);
                gvuploadgrid.Refresh();
                if (isupdte == true)
                {

                    btngen.Enabled = false;
                    gvuploadgrid.Refresh();
                    if (list.Count > 0)
                    {
                        if (cmbuptype.Text == "Image")
                        {

                            LogHelper.WriteLog("Upload Image File..");
                            //ImageUpload(list);
                            ImageUploadByUploadCodeBased(list, status[0].Replace("/", "_"));

                        }
                        else if (cmbuptype.Text == "Finnexia")
                        {
                            LogHelper.WriteLog("Upload Finnexia File..");
                            string dd = DateTime.Now.Day.ToString("d2");
                            string mm = DateTime.Now.Month.ToString("d2");
                            string yy = DateTime.Now.Year.ToString();
                            string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                            if (!System.IO.Directory.Exists(PrgPath + "\\Upload\\"))
                            {
                                System.IO.Directory.CreateDirectory(PrgPath + "\\Upload\\");
                            }

                            //FinnaxiaUpload(list, PrgPath + "\\Upload\\FinnaxiaFile_Gnsa _" + dd + mm + yy);
                            //FinnaxiaUpload(list, PrgPath + "\\Upload\\FinnaxiaFile_Gnsa _" + dd + mm + yy);
                            FinnaxiaUpload(list, "FinnaxiaFile_Gnsa _" + dd + mm + yy);
                        }
                        else if (cmbuptype.Text == "Finacle")
                        {
                            LogHelper.WriteLog("Upload Finacle File..");
                            string dd = DateTime.Now.Day.ToString("d2");
                            string mm = DateTime.Now.Month.ToString("d2");
                            string yy = DateTime.Now.Year.ToString();
                            //string hh = DateTime.Now.Hour.ToString("d2");
                            //string min = DateTime.Now.Minute.ToString("d2");
                            //string sec = DateTime.Now.Second.ToString("d2");
                            string hh = DateTime.Now.Hour.ToString("00.##");
                            string min = DateTime.Now.Minute.ToString("00.##");
                            string ss = DateTime.Now.Second.ToString("00.##");



                            string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                            if (!System.IO.Directory.Exists(PrgPath + "\\Upload\\"))
                            {
                                System.IO.Directory.CreateDirectory(PrgPath + "\\Upload\\");
                            }

                            FinacleUpload(list, PrgPath + "\\Upload\\");
                        }
                        else
                        {

                        }

                    }
                    lblstatus.Visible = false;
                    PicLoad.Visible = false;
                    MessageBox.Show("Uploaded Successfully");
                    MasterEntities.UploadBatchEntities obj = new MasterEntities.UploadBatchEntities();
                    obj.Type = cmbtype.Text.ToString();
                    obj.Location = cmbloc.SelectedValue.ToString();
                    LoadGriddetails(obj);
                }
                else
                {
                    //lblstatus.Visible = false;
                    ////MessageBox.Show("Uploaded Successfully");
                    //MasterEntities.UploadBatchEntities obj = new MasterEntities.UploadBatchEntities();
                    //obj.Type = cmbtype.Text.ToString();
                    //obj.Location = cmbloc.SelectedValue.ToString();
                    //LoadGriddetails(obj);
                }
                btngen.Enabled = true;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnref_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            try
            {

                if (rdoupload.Checked == true)
                {
                    lblstatus.Visible = true;
                    LoadUploadList("Upload Pending");
                    if (gvuploadgrid.Rows.Count > 0)
                    {
                        gvuploadgrid.Columns["Success"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                        gvuploadgrid.Columns["Reject"].DefaultCellStyle.ForeColor = Color.Red;
                        //gvuploadgrid.Columns["Hold"].DefaultCellStyle.ForeColor = Color.DarkBlue;

                        gvuploadgrid.Columns["Success"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                        gvuploadgrid.Columns["Reject"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                        //gvuploadgrid.Columns["Hold"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                    }
                    lblstatus.Visible = false;
                }
                else
                {
                    lblstatus.Visible = true;
                    LoadUploadList("Upload Completed");
                    lblstatus.Visible = false;

                }
                PicLoad.Visible = false;
                // btnref.Enabled = false;
                //btngen.Enabled = true;
                //if (cmbtype.Text.ToString() != "")
                //{
                //    if (cmbloc.Text.ToString() != "")
                //    {
                //        MasterEntities.UploadBatchEntities obj = new MasterEntities.UploadBatchEntities();
                //        obj.Type = cmbtype.Text.ToString();
                //        obj.Location = cmbloc.SelectedValue.ToString();
                //        LoadGriddetails(obj);
                //    }
                //    //else
                //    //{
                //    //    MessageBox.Show("Please Select the Location ", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //    cmbtype.Focus();
                //    //    btnref.Enabled = true;
                //    //    return;
                //    //}
                //}
                //else
                //{
                //    MessageBox.Show("Please Select the Type", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbloc.Focus();
                //    return;
                //}
                if (gvuploadgrid.Rows.Count > 0)
                {
                    gvuploadgrid.Columns["Cheque Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvuploadgrid.Columns["Batch Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblstatus.Visible = false;
            }
            PicLoad.Visible = false;
        }
        private void btncls_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Upload Closed");
            this.Close();
        }
        // Grid loading info
        private void LoadGriddetails(MasterEntities.UploadBatchEntities obj)
        {
            try
            {
                previousSelectedRow = -1;
                //  EnableOrDisable(false);
                //txtdiff.Text = 
                gvuploadgrid.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvuploadgrid.DataSource = null;
                ScannerBusiness objscanning = new ScannerBusiness();
                dtscanning = objscanning.GetUploadDetails(obj);
                gvuploadgrid.DataSource = dtscanning;



                DataGridViewCheckBoxColumn check_Box = new DataGridViewCheckBoxColumn();
                check_Box.HeaderText = "";
                check_Box.Name = "Select";
                check_Box.FalseValue = "False";
                check_Box.TrueValue = "True";
                gvuploadgrid.Columns.Insert(0, check_Box);

                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Complete";
                col.Name = "Action";
                gvuploadgrid.Columns.Add(col);
                if (rdoall.Checked == true)
                {
                    gvuploadgrid.Columns["Action"].Visible = false;
                }
                if (gvuploadgrid.Rows.Count > 0)
                {
                    gvuploadgrid.Columns[8].Visible = false;
                    gvuploadgrid.Columns["Hold"].Visible = false;
                    gvuploadgrid.Columns["Action"].Visible = false;
                    gvuploadgrid.Columns["Upload Link"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String Values = cmbtype.Text.ToString();
                cmbuptype.DataSource = new BindingSource(DynamicCombo1(Values), null);
                cmbuptype.DisplayMember = "Value";
                cmbuptype.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvuploadgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FormCollection AllForms = Application.OpenForms;
                Boolean FormOpen = false;
                Form OpenedForm = new Form();
                foreach (Form form in AllForms)
                {
                    if (form.Name == "StatusWiseCheque")
                    {
                        OpenedForm = form;
                        FormOpen = true;
                    }
                }
                if (FormOpen == true)
                {
                    OpenedForm.Close();
                }
                if (e.RowIndex >= 0)
                {
                    if (Convert.ToBoolean(gvuploadgrid.Rows[e.RowIndex].Cells["select"].Value))
                    {
                        gvuploadgrid.Rows[e.RowIndex].Cells["select"].Value = false;
                    }
                    else
                    {
                        gvuploadgrid.Rows[e.RowIndex].Cells["select"].Value = true;
                    }
                    for (int i = 0; i < gvuploadgrid.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(gvuploadgrid.Rows[i].Cells["select"].Value))
                        {
                            // gvuploadgrid.ClearSelection();
                            gvuploadgrid.Rows[i].Selected = true;
                        }
                        else
                        {
                            //gvuploadgrid.ClearSelection();
                            gvuploadgrid.Rows[i].Selected = false;
                        }
                    }
                }
                if (gvuploadgrid.Columns[e.ColumnIndex].Name == "Action")
                {
                    int col = gvuploadgrid.CurrentCell.ColumnIndex;
                    int row = gvuploadgrid.CurrentCell.RowIndex;
                    string Batch_no = gvuploadgrid.Rows[row].Cells["Batch No"].Value.ToString();

                    ScannerBusiness objscanning = new ScannerBusiness();
                    string res = objscanning.SaveUpload(Batch_no);
                    MessageBox.Show("Status Update Successfully");
                }

                if (gvuploadgrid.Columns[e.ColumnIndex].Name == "Success")
                {
                    int col = gvuploadgrid.CurrentCell.ColumnIndex;
                    int row = gvuploadgrid.CurrentCell.RowIndex;
                    string Batch_no = gvuploadgrid.Rows[row].Cells["Batch No"].Value.ToString();

                    ScannerBusiness objscanning = new ScannerBusiness();
                    StatusWiseChequeList ent = new StatusWiseChequeList();
                    ent.in_Batch_No = Batch_no;
                    ent.in_Status = " in ('Checked Successfully')";
                    DataTable res = objscanning.GetStatusWiseCheque(ent);
                    StatusWiseCheque dis = new StatusWiseCheque(res);
                    dis.Show();
                }

                if (gvuploadgrid.Columns[e.ColumnIndex].Name == "Reject")
                {
                    int col = gvuploadgrid.CurrentCell.ColumnIndex;
                    int row = gvuploadgrid.CurrentCell.RowIndex;
                    string Batch_no = gvuploadgrid.Rows[row].Cells["Batch No"].Value.ToString();

                    ScannerBusiness objscanning = new ScannerBusiness();
                    StatusWiseChequeList ent = new StatusWiseChequeList();
                    ent.in_Batch_No = Batch_no;
                    //ent.in_Status = "'InValid PDC Cheque','Untraceable Cheques','Stale Cheque'";
                    ent.in_Status = "not in ('Checked Successfully','Valid PDC Cheque')";
                    DataTable res = objscanning.GetStatusWiseCheque(ent);
                    StatusWiseCheque dis = new StatusWiseCheque(res);
                    dis.Show();

                }

                if (gvuploadgrid.Columns[e.ColumnIndex].Name == "Hold")
                {
                    int col = gvuploadgrid.CurrentCell.ColumnIndex;
                    int row = gvuploadgrid.CurrentCell.RowIndex;
                    string Batch_no = gvuploadgrid.Rows[row].Cells["Batch No"].Value.ToString();

                    ScannerBusiness objscanning = new ScannerBusiness();
                    StatusWiseChequeList ent = new StatusWiseChequeList();
                    ent.in_Batch_No = Batch_no;
                    ent.in_Status = "in ('Valid PDC Cheque')";
                    DataTable res = objscanning.GetStatusWiseCheque(ent);
                    StatusWiseCheque dis = new StatusWiseCheque(res);
                    dis.Show();

                }
                if (gvuploadgrid.Columns[e.ColumnIndex].Name == "Total Cheques")
                {
                    int col = gvuploadgrid.CurrentCell.ColumnIndex;
                    int row = gvuploadgrid.CurrentCell.RowIndex;
                    string Batch_no = gvuploadgrid.Rows[row].Cells["Batch No"].Value.ToString();

                    ScannerBusiness objscanning = new ScannerBusiness();
                    StatusWiseChequeList ent = new StatusWiseChequeList();
                    ent.in_Batch_No = Batch_no;
                    ent.in_Status = "All";
                    DataTable res = objscanning.GetStatusWiseCheque(ent);
                    StatusWiseCheque dis = new StatusWiseCheque(res);
                    dis.Show();

                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        /*Image Upload*/
        #region Image Upload
        public void ImageUpload(List<uploadgrid> list)
        {
            try
            {

                List<CheckerEntities> obj;
                ScannerBusiness data = new ScannerBusiness();
                string dd = DateTime.Now.Day.ToString("d2");
                string mm = DateTime.Now.Month.ToString("d2");
                string yy = DateTime.Now.Year.ToString();
                //string hh = DateTime.Now.Hour.ToString("d2");
                //string min = DateTime.Now.Minute.ToString("d2");
                //string ss = DateTime.Now.Second.ToString("d2");
                string hh = DateTime.Now.Hour.ToString("00.##");
                string min = DateTime.Now.Minute.ToString("00.##");
                string ss = DateTime.Now.Second.ToString("00.##");


                string[] files;

                string[] xmlimagefiles;
                //string[] tifffiles;
                string batch_no = string.Empty;
                string PrgPath = string.Empty;
                string uploadpath = string.Empty;
                String xmlbatchwiseFileName = string.Empty;
                string url = string.Empty;

                for (int i = 0; i < list.Count; i++)
                {
                    DataTable dtscanningdtl = new DataTable();
                    ScannerBusiness objscanning = new ScannerBusiness();
                    xmlimagefiles = new string[5];
                    // string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    batch_no = list[i].batch_no.ToString();
                    DataTable dataobj = data.getxmlfile(batch_no);

                    dtscanningdtl = objscanning.GetUploadImage(batch_no);
                    if (dataobj.Rows.Count > 0)
                    {
                        if (dtscanningdtl.Rows.Count > 0)
                        {
                            // batch_no = batch_no.Replace('/', '-');
                            batch_no = "_" + batch_no.Split('/')[2];
                            PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                            uploadpath = PrgPath + "\\Upload\\" + batch_no;
                            if (!System.IO.Directory.Exists(PrgPath + "\\Upload\\"))
                            {
                                System.IO.Directory.CreateDirectory(PrgPath + "\\Upload\\");
                            }
                            if (!System.IO.Directory.Exists(uploadpath))
                            {
                                System.IO.Directory.CreateDirectory(uploadpath);
                            }
                            else
                            {
                                foreach (string file in Directory.GetFiles(uploadpath))
                                {
                                    File.Delete(file);
                                }
                                System.IO.Directory.Delete(uploadpath);
                                System.IO.Directory.CreateDirectory(uploadpath);
                            }
                            XmlDocument doc = new XmlDocument();
                            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                            doc.AppendChild(xmlDeclaration);

                            XmlElement element1 = CreateFileHeaderBatchwise(doc, batch_no);
                            doc.AppendChild(element1);
                            String imgFileName = string.Empty;
                            String imgFileName1 = string.Empty;
                            String imgFileName2 = string.Empty;
                            String imgFileName3 = string.Empty;
                            String xmlFileName = string.Empty;

                            for (int j = 0; j < dtscanningdtl.Rows.Count; j++)
                            {
                                //SaveImages(dtscanningdtl.Rows[j]["front_image"].ToString());
                                //SaveImages(dtscanningdtl.Rows[j]["back_image"].ToString());
                                //SaveImages(dtscanningdtl.Rows[j]["front_uv_image"].ToString());
                                //SaveImages(dtscanningdtl.Rows[j]["back_uv_image"].ToString());
                                //SaveImages(dtscanningdtl.Rows[j]["grey_front"].ToString());
                                //SaveImages(dtscanningdtl.Rows[j]["grey_back"].ToString());
                                int k = j + 1;
                                Bitmap front_image = ReturnImage(dtscanningdtl.Rows[j]["front_image"].ToString());
                                Bitmap back_image = ReturnImage(dtscanningdtl.Rows[j]["back_image"].ToString());
                                Bitmap front_uv_image = ReturnImage(dtscanningdtl.Rows[j]["front_uv_image"].ToString());
                                Bitmap back_uv_image = ReturnImage(dtscanningdtl.Rows[j]["back_uv_image"].ToString());
                                // Bitmap gray_front_image = ReturnImage();
                                Bitmap gray_back_image = ReturnImage(dtscanningdtl.Rows[j]["grey_back"].ToString());
                                imgFileName = "KIO_FG_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                                CreateGray(dtscanningdtl.Rows[j]["grey_front"].ToString(), uploadpath, imgFileName);
                                xmlimagefiles[0] = imgFileName + ".jpg";
                                imgFileName1 = "KIO_FB_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                                //CreateTiff(front_image, uploadpath, imgFileName1);
                                Tiff(dtscanningdtl.Rows[j]["front_image"].ToString(), uploadpath, imgFileName1);
                                xmlimagefiles[1] = imgFileName1 + ".tiff";

                                // Tiff Creation
                                imgFileName2 = " KIO_RB_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                                //CreateTiff(back_image, uploadpath, imgFileName2);
                                Tiff(dtscanningdtl.Rows[j]["back_image"].ToString(), uploadpath, imgFileName2);
                                xmlimagefiles[2] = imgFileName2 + ".tiff";

                                // UV Creation
                                imgFileName3 = "KIO_FU_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                                CreateGray(dtscanningdtl.Rows[j]["front_uv_image"].ToString(), uploadpath, imgFileName3);
                                xmlimagefiles[3] = imgFileName3 + ".jpg";
                                xmlFileName = "KXD_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                                CreateXmlFile(list, uploadpath, xmlFileName, xmlimagefiles, dataobj.Rows[j], batch_no, (j + 1));
                                xmlimagefiles[4] = xmlFileName + ".xml";
                                XmlElement element2 = CreateChildElementBatchwise(doc, xmlimagefiles, batch_no, (j + 1));
                                element1.AppendChild(element2);

                                imgFileName = string.Empty;
                                imgFileName1 = string.Empty;
                                imgFileName2 = string.Empty;
                                imgFileName3 = string.Empty;
                                xmlFileName = string.Empty;

                            }
                            int l = i + 1;
                            xmlbatchwiseFileName = "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41";
                            // CreatebatchwiseXmlFile(list, uploadpath, xmlbatchwiseFileName, xmlimagefiles);
                            url = uploadpath + "\\" + xmlbatchwiseFileName + ".xml";
                            //doc.Save(url);
                            using (var writer = new XmlTextWriter(url, new UTF8Encoding(false)))
                            {
                                doc.Save(writer);
                            }
                            string doneFilename = uploadpath + "\\" + "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41.XML.DONE";
                            CreateDoneFile(doneFilename);
                        }
                    }
                    batch_no = string.Empty;
                    PrgPath = string.Empty;
                    uploadpath = string.Empty;
                    xmlbatchwiseFileName = string.Empty;
                    url = string.Empty;

                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        /*Image Upload*/
        private void SaveImages(string base64String)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {

                    image = Image.FromStream(ms);

                }
                image.Save(@"E:\SavedImages1", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*Finnaxia Upload*/
        #region Finnaxia Upload
        public void FinnaxiaUpload(List<uploadgrid> list, string path)
        {
            getFinnaxia(list, path);
        }
        #endregion
        /*Finnaxia Upload*/
        /*Finacle Upload*/
        #region Finacle Upload
        public void FinacleUpload(List<uploadgrid> list, string path)
        {
            getFinacle(path, list);
        }
        #endregion
        /*Finacle Upload*/
        public static int Downscale(byte[] imgBits, string fileName, string path)
        {
            int pageCount = -1;
            {

                //string filenameext1 = path + "\\" + fileName + "_grey.jpg";
                string filenameext1 = path + "\\" + fileName + ".jpg";
                //string path = "D:\\Test\\Test.jpg";
                using (MemoryStream ms = new MemoryStream(imgBits))
                {
                    GrayGenerateThumbnails(0.1, ms, filenameext1);
                    //EnhanceGenerateThumbnails(15.5, ms, path2);
                }
            }

            return pageCount;
        }
        // Image resolution,height,width(setting)
        private static void GrayGenerateThumbnails(double scaleFactor, Stream sourcePath, string path)
        {
            try
            {
                using (var image1 = Image.FromStream(sourcePath))
                {
                    Bitmap bmp = new Bitmap(sourcePath);
                    // Grayscale creation
                    var image = MakeGrayscale(bmp);
                    var newWidth = 804;
                    var newHeight = 369;
                    var thumbnailImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbnailImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imageRectangle);
                    thumbnailImg.SetResolution(100, 100);
                    //imagecodeinfo creation
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
                    //Bitmap grayScaleBP = new System.Drawing.Bitmap(2, 2, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
                    EncoderParameters ep = new EncoderParameters(3);
                    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
                    ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
                    //thumbnailImg.Save(targetPath, image.RawFormat);
                    thumbnailImg.Save(path, jpgEncoder, myEncoderParameters);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original

            Bitmap newBitmap = new Bitmap(original, new Size(787, 364));
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(original,
               new Rectangle(0, 0, 787, 364),
               0, 0, original.Width, original.Height,
               GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();

            return newBitmap;
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public void CreateGray(string base64String, string path, string Filename)
        {
            // Bitmap getinput = input;

            //Bitmap grayScaleBP = new System.Drawing.Bitmap(2, 2, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);

            string getpath = path;
            string getfilename = Filename;
            try
            {
                //creating byte array
                byte[] imageBytes = Convert.FromBase64String(base64String);

                string fillpath = path + "\\" + getfilename + ".jpg";
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {

                    Downscale(imageBytes, Filename, path);
                    //using (Bitmap bm2 = new Bitmap(ms))
                    //{
                    //    bm2.Save(ms, ImageFormat.Jpeg);

                    //var newWidth = 200;
                    //                //var newHeight = 50;
                    //                //var thumbnailImg = new Bitmap(newWidth, newHeight);
                    //                //var thumbGraph = Graphics.FromImage(thumbnailImg);
                    //                //thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    //                //thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    //                //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //                //thumbnailImg.SetResolution(30, 30);

                    //                bm2.Save(ms,ImageFormat.Jpeg);

                    //               // bm2.SetResolution(30, 30);
                    //}
                }

            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #region  implemented by mohan

        public void Tiff(string base64String, string path, string Filename)
        {
            if (base64String != "UV Image Not Available")
            {
                //using (MemoryStream ms = new MemoryStream(imgBits))
                {
                    byte[] imgBits = Convert.FromBase64String(base64String);
                    string getfilename = Filename;
                    string fillpath = path + "\\" + getfilename + ".tiff";
                    //string filenameext1 = Filename + ".tif";
                    using (MemoryStream ms1 = new MemoryStream(imgBits))
                    {
                        GenerateThumbnails(0.1, ms1, fillpath);
                    }
                }
            }
        }

        #endregion
        public void CreateTiff(Bitmap newBitMAp, string path, string Filename)
        {
            //string getinput = input;
            //string getpath = path;
            //string getfilename = Filename;
            //// Bitmap greyscale = new Bitmap(input.Width, input.Height);
            //string url = path + "\\" + Filename + ".tiff";
            //Image img1 = default(Image);
            //img1 = Image.FromFile(getinput);
            //string fillpath = path + "\\" + getfilename + ".tiff";
            //img1.Save(fillpath, System.Drawing.Imaging.ImageFormat.Tiff);
            string getfilename = Filename;
            string fillpath = path + "\\" + getfilename + ".tiff";

            //TIFF(imageBytes, Filename, fillpath);
            //try
            //{
            //    string getfilename = Filename;
            //    string fillpath = path + "\\" + getfilename + ".tiff";
            //    //string url = path + "\\" + Filename + ".tiff";
            //    //Bitmap newBitMAp = new Bitmap(input);
            //    //input = null;   
            //    //newBitMAp.Height=200;
            //    newBitMAp.SetResolution(30, 30);
            //    newBitMAp.Save(fillpath, ImageFormat.Tiff);
            //    //newBitMAp.Save(@"E:\A1.tiff", ImageFormat.Tiff);
            //    newBitMAp.Dispose();

            //}
            //catch (Exception Ex)
            //{
            //    LogHelper.WriteLog(Ex.ToString());
            //}
        }
        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = Image.FromStream(sourcePath))
            {
                //image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                var newWidth = 1616;
                var newHeight = 737;
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.SetResolution(200, 200);
                EncoderParameters parms = new EncoderParameters(1);
                ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(decoder => decoder.FormatID == ImageFormat.Tiff.Guid);
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Tiff);
                parms.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
                Bitmap finalImage = new Bitmap(ResizeImage(image, 1000, 600));
                thumbnailImg.Save(targetPath, jpgEncoder, parms);
            }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public void CreateXmlFile(List<uploadgrid> list, string path, string Filename, string[] imagefilename, DataRow Dtrow, string batch_no, int cc)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmlDeclaration);
                XmlElement element1 = CreateFileHeader(doc, Dtrow, batch_no);
                doc.AppendChild(element1);
                XmlElement element2 = CreateChildElement(doc, imagefilename, Dtrow, batch_no, cc);
                element1.AppendChild(element2);
                string url = path + "\\" + Filename + ".xml";
                //doc.Save(url);
                using (var writer = new XmlTextWriter(url, new UTF8Encoding(false)))
                {
                    doc.Save(writer);
                }
            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private XmlElement CreateFileHeader(XmlDocument doc, DataRow Dtrow, string batch_no)
        {
            string dd = DateTime.Now.Day.ToString("d2");
            string mm = DateTime.Now.Month.ToString("d2");
            string yy = DateTime.Now.Year.ToString();
            //string hh = DateTime.Now.Hour.ToString();
            //string min = DateTime.Now.Minute.ToString();
            //string ss = DateTime.Now.Second.ToString();
            string hh = DateTime.Now.Hour.ToString("00.##");
            string min = DateTime.Now.Minute.ToString("00.##");
            string ss = DateTime.Now.Second.ToString("00.##");



            XmlElement element = doc.CreateElement("FileHeader");
            element.SetAttribute("DLLVersion", "01.03.11.15");
            element.SetAttribute("SolId", "0001");
            element.SetAttribute("Encrypt", "No");
            element.SetAttribute("UVAvailable", "Yes");
            element.SetAttribute("BatchID", batch_no);                 // Need pass the Batch through Parameter           
            element.SetAttribute("PresentmentDate", dd + mm + yy);    // Get the Date 
            element.SetAttribute("CreationTime", hh + min + ss);         // Get the Time and assign
            //element.SetAttribute("KioskName", "FTL0000060012001");  // Need to pass tskName -- Commented By Sheeba For Location Code Applied
            //element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "12001");
            if (cmbloc.Text == "Chennai")
            {
                element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "12001");
            }
            else
            {
                element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "11001");
            }

            element.SetAttribute("xmlns", "FTL:OUTCL:CXD:FileStructure:010001");
            return element;
        }
        public static string DoFormat(double myNumber)
        {
            return string.Format("{0:0.00}", myNumber).Replace(".00", "");
        }
        private XmlElement CreateChildElement(XmlDocument doc, string[] imagefilename, DataRow Dtrow, string upload_code, int cc)
        {
            string amt = Dtrow["Amount"].ToString();
            Regex reg = new Regex("^[0-9]*(\\.[0-9]{1,2})?$");
            if (!reg.IsMatch(amt))
            {
                double a = Convert.ToDouble(amt);
                amt = DoFormat(a);
            }
            else
            {
                double a = Convert.ToDouble(amt);
                amt = string.Format("{0:N2}", Convert.ToDecimal(a));
            }
            amt = amt.Replace(",", "");
            amt = amt.Replace(".", "");


            DateTime chqdate = Convert.ToDateTime(Dtrow["Che_Date"]);
            string dd = chqdate.Day.ToString("00.##");
            string mm = chqdate.Month.ToString("00.##");
            //string hh = DateTime.Now.Hour.ToString("00.##");
            //string mm = DateTime.Now.Minute.ToString("00.##");
            string ss = DateTime.Now.Second.ToString("00.##");


            string yy = chqdate.Year.ToString();
            XmlElement element = doc.CreateElement("", "ItemDetail", "");
            try
            {
                element.SetAttribute("GovtStatus", "0");
                element.SetAttribute("MailID", "emial@email.com");
                element.SetAttribute("MobileNo", "9845098450");
                element.SetAttribute("CTSstatus", "2");
                element.SetAttribute("UVstatus", "2");
                element.SetAttribute("Skew", "2");
                element.SetAttribute("DocSizeInTenths", "2");
                element.SetAttribute("PctBlackBits", "2");
                element.SetAttribute("IQAIgnoreInd", "2");
                element.SetAttribute("ImageUsability", "2");
                element.SetAttribute("ImageQuality", "2");
                element.SetAttribute("ExceedsMaximumImageSize", "2");
                element.SetAttribute("BelowMinimumImageSize", "2");
                element.SetAttribute("LightOrDark", "2");
                element.SetAttribute("PartialImage", "2");
                element.SetAttribute("BentRightTopPix", "2");
                element.SetAttribute("BentRightBottomPix", "2");
                element.SetAttribute("BentLeftBottomPix", "2");
                element.SetAttribute("BentLeftTopPix", "2");
                element.SetAttribute("ChDate", dd + mm + yy); //TODO
                element.SetAttribute("DocType", "B");
                element.SetAttribute("Status", "PENDING");
                element.SetAttribute("DraweeDetail", "DRAWEE NAME");
                if (cmbtype.Text == "CMS")
                {
                    string customer = Dtrow["customer_code"].ToString();
                    customer = customer.Split('/')[1];
                    element.SetAttribute("DepositorName", customer);
                }
                if (cmbtype.Text == "CTS")
                {
                    element.SetAttribute("DepositorName", Dtrow["Drawee_Name"].ToString());
                }
                element.SetAttribute("DepositorAcct", "826LIABICMSCLINR");
                element.SetAttribute("MiCRAmount", amt);
                element.SetAttribute("MICRTransCode", Dtrow["Tran_Code"].ToString());
                element.SetAttribute("MICRAccountNo", Dtrow["Base_Code"].ToString());
                string sort = Dtrow["Sort_Code"].ToString();
                sort = cmbloc.SelectedValue + sort.Substring(3);
                element.SetAttribute("MICRPayorBankRoutNo", sort);
                element.SetAttribute("MICRSerialNo", Dtrow["Cheq_no"].ToString());
                //element.SetAttribute("FGFileName", imagefilename[0].ToString());
                //element.SetAttribute("FBFileName", imagefilename[1].ToString());
                //element.SetAttribute("FUFileName", imagefilename[3].ToString());
                //element.SetAttribute("RBFileName", imagefilename[2].ToString());
                element.SetAttribute("FGFileName", imagefilename[3].ToString());
                element.SetAttribute("FBFileName", imagefilename[0].ToString());
                element.SetAttribute("FUFileName", imagefilename[2].ToString());
                element.SetAttribute("RBFileName", imagefilename[1].ToString());
                if (cmbloc.Text == "Chennai")
                {
                    element.SetAttribute("KioskTranId", "080320160416");
                }
                else
                {
                    element.SetAttribute("KioskTranId", "00466003" + upload_code + cc.ToString("000"));
                }
                //element.SetAttribute("ItemSeqNo", "00466003505001");
                //element.SetAttribute("ItemSeqNo", "00466003" + upload_code.Substring(1, 3) + cc.ToString("000"));
                element.SetAttribute("ItemSeqNo", "00466003" + upload_code + cc.ToString("000"));


            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
        }
        public void CreatebatchwiseXmlFile(List<uploadgrid> list, string path, string Filename, string[] imagefilename)
        {
            //XmlDocument doc = new XmlDocument();
            ////XmlElement element1 = CreateFileHeaderBatchwise(doc);
            //doc.AppendChild(element1);
            //XmlElement element2 = CreateChildElementBatchwise(doc, imagefilename);
            //element1.AppendChild(element2);
            //string url = path + "\\" + Filename + ".xml";
            //doc.Save(url);
        }
        private XmlElement CreateFileHeaderBatchwise(XmlDocument doc, string batch_no)
        {
            XmlElement element = doc.CreateElement("FileHeader");
            try
            {
                string dd = DateTime.Now.Day.ToString("d2");
                string mm = DateTime.Now.Month.ToString("d2");
                string yy = DateTime.Now.Year.ToString();
                string hh = DateTime.Now.Hour.ToString();
                string min = DateTime.Now.Minute.ToString();
                string ss = DateTime.Now.Second.ToString();

                //element.SetAttribute("KioskName", "FTL0000060012001");
                //element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "12001");
                if (cmbloc.Text == "Chennai")
                {
                    element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "12001");
                }
                else
                {
                    element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "11001");
                }
                element.SetAttribute("CreationTime", hh + min + ss);
                element.SetAttribute("PresentmentDate", dd + mm + yy);
                element.SetAttribute("BatchID", batch_no.Remove(0, 1));                 // Need pass the Batch through Parameter           
                element.SetAttribute("UVAvailable", "Yes");    // Get the Date 
                element.SetAttribute("Encrypt", "No");         // Get the Time and assign
                element.SetAttribute("SolId", "0001");  // Need to pass the KioskName
                element.SetAttribute("DLLVersion", "01.03.11.15");    // Get the Date   
                element.SetAttribute("xmlns", "FTL:OUTCL:CXD:FileStructure:010001");
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
        }
        private XmlElement CreateChildElementBatchwise(XmlDocument doc, string[] imagefilename, string upload_code, int cc)
        {
            XmlElement element = doc.CreateElement("", "Item", "");
            try
            {
                //element.SetAttribute("FGFileName", imagefilename[2].ToString());
                //element.SetAttribute("FBFileName", imagefilename[1].ToString());
                //element.SetAttribute("FUFileName", imagefilename[3].ToString());
                //element.SetAttribute("RBFileName", imagefilename[0].ToString());
                element.SetAttribute("FGFileName", imagefilename[3].ToString());
                element.SetAttribute("FBFileName", imagefilename[0].ToString());
                element.SetAttribute("FUFileName", imagefilename[2].ToString());
                element.SetAttribute("RBFileName", imagefilename[1].ToString());
                element.SetAttribute("CXDDataFile", imagefilename[4].ToString());
                element.SetAttribute("ItemSeqNo", "00466003" + upload_code + cc.ToString("000"));
                if (cmbloc.Text == "Chennai")
                {
                    element.SetAttribute("KioskTranId", "080320160416");
                }
                else
                {
                    element.SetAttribute("KioskTranId", "00466003" + upload_code + cc.ToString("000"));
                }
                //element.SetAttribute("KioskTranId", "080320160416");
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
        }
        public void getFinnaxia(List<uploadgrid> list, string fileName)
        {
            try
            {
                if (list.Count > 0)
                {
                    DataTable obj = new DataTable();
                    ScannerBusiness data = new ScannerBusiness();
                    string cmbBatNo = "";
                    string batch_no = "";
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (list[k].batch_no.ToString() != null)
                        {
                            batch_no = list[k].batch_no.ToString();
                            cmbBatNo = cmbBatNo + "'" + batch_no + "',";
                        }
                        batch_no = "";
                    }
                    cmbBatNo = cmbBatNo.Remove(cmbBatNo.Length - 1, 1);
                    obj = data.getxmlfile(cmbBatNo);
                    string batch_no_data = obj.Rows[0]["Batch_No"].ToString();
                    string batch_cde = batch_no_data.Split('/')[2].ToString();

                    //string basefileName = fileName + "_" + batch_cde + ".txt";
                    // string basefileName = fileName + "_" + "7 Digits" + ".txt";

                    String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                    string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    string uploadpath = PrgPath + "\\" + Todaysdate + "\\Finnaxia\\";
                    //string uploadpath = fileName + "Finacle";
                    if (!System.IO.Directory.Exists(uploadpath))
                    {
                        System.IO.Directory.CreateDirectory(uploadpath);
                    }

                    string basefileName = uploadpath + fileName + "_" + "7 Digits" + ".txt";

                    try
                    {
                        // Check if file already exists. If yes, delete it.     
                        //if (File.Exists(basefileName))
                        //{
                        //    File.Delete(basefileName);
                        //}
                        // Create a new file     
                        using (StreamWriter fs = File.CreateText(basefileName))
                        {
                            string dd = DateTime.Now.Day.ToString("d2");
                            string mm = DateTime.Now.Month.ToString("d2");
                            string yy = DateTime.Now.Year.ToString();
                            decimal Totalamt = 0;
                            string vdd = string.Empty;
                            string vmm = string.Empty;
                            string vyy = string.Empty;
                            string amount = string.Empty;
                            decimal val = 0;
                            fs.WriteLine("HDR~0811" + yy + mm + dd + batch_cde + "~0811~");
                            for (int i = 0; i < obj.Rows.Count; i++)
                            {
                                int j = i + 1;
                                DateTime value = Convert.ToDateTime(obj.Rows[i]["Che_Date"].ToString());
                                vdd = value.Day.ToString("d2");
                                vmm = value.Month.ToString("d2");
                                vyy = value.Year.ToString();
                                //decimal amnt = Convert.ToDecimal(obj.Rows[i]["Amount"].ToString().Replace(",", ""));
                                //string amount = amnt.ToString("0.00");
                                amount = obj.Rows[i]["Amount"].ToString().Replace(",", "");
                                //fs.WriteLine("I~" + j + "~" + obj.Rows[i]["Cheq_no"] + "~" + obj.Rows[i]["Amount"] + "~" + dd + mm + yy + "~" + vdd + vmm + vyy + "~DBSAMMAN~" + dd + mm + yy + "~CHEN~N~M~IOB~" + obj.Rows[i]["Sort_Code"] + obj.Rows[i]["Drawee_Name"] + dd + mm + yy + "~~~~~");
                                //fs.WriteLine("I~" + j + "~" + obj.Rows[i]["Cheq_no"] + "~" + obj.Rows[i]["Amount"] + "~" + dd + mm + yy + "~" + vdd + vmm + vyy + "~" + obj.Rows[i]["customer_code"] + "~" + dd + mm + yy + "~CHEN~N~M~" + obj.Rows[i]["BANK_CODE"] + "~" + obj.Rows[i]["Sort_Code"] + "~~" + obj.Rows[i]["Drawee_Name"] + "~~CHQ~" + dd + mm + yy + "~~~~~");
                                fs.WriteLine("I~" + j + "~" + obj.Rows[i]["Cheq_no"] + "~" + amount + "~" + dd + mm + yy + "~" + vdd + vmm + vyy + "~" + obj.Rows[i]["customer_code"] + "~" + dd + mm + yy + "~CHEN~N~M~" + obj.Rows[i]["BANK_CODE"] + "~" + obj.Rows[i]["Sort_Code"] + "~~" + obj.Rows[i]["Drawee_Name"] + "~~CHQ~" + obj.Rows[i]["Deposit Slip No"] + "~~~~~");
                                val = Convert.ToDecimal(obj.Rows[i]["Amount"].ToString());
                                Totalamt += val;

                                vdd = string.Empty;
                                vmm = string.Empty;
                                vyy = string.Empty;
                                amount = string.Empty;
                                val = 0;
                            }
                            int line = Convert.ToInt32(obj.Rows.Count) + 2;
                            fs.WriteLine("TRL~" + line + "~" + Totalamt + "~");
                        }

                        // Open the stream and read it back.    
                        //using (StreamReader sr = File.OpenText(fileName))
                        //{
                        //    string s = "";
                        //    while ((s = sr.ReadLine()) != null)
                        //    {

                        //    }
                        //}

                    }
                    catch (Exception Ex)
                    {
                        //LogHelper.WriteLog(Ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {

            DataView dv = new DataView(i_dSourceTable);

            //getting distinct values for group column
            DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn });

            //adding column for the row count
            dtGroup.Columns.Add("SumOfAmount", typeof(int));

            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["SumOfAmount"] = i_dSourceTable.Compute("sum(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
            }

            //returning grouped/counted result
            return dtGroup;
        }
        public void getFinacle(string fileName, List<uploadgrid> list)
        {
            string dd = DateTime.Now.Day.ToString("d2");
            string mm = DateTime.Now.Month.ToString("d2");
            string yy = DateTime.Now.Year.ToString();
            string hh = DateTime.Now.Hour.ToString("d2");
            string min = DateTime.Now.Minute.ToString("d2");
            string sec = DateTime.Now.Second.ToString("d2");
            if (list.Count > 0)
            {
                try
                {
                    DataTable obj = new DataTable();
                    ScannerBusiness data = new ScannerBusiness();
                    string batch_cde;
                    string cmbBatNo = "";
                    string batch_no = "";
                    for (int k = 0; k < list.Count; k++)
                    {
                        batch_no = list[k].batch_no.ToString();
                        cmbBatNo = cmbBatNo + "'" + batch_no + "',";
                        // Check if file already exists. If yes, delete it.    
                        batch_cde = batch_no.Split('/')[2].ToString();
                        batch_no = "";
                    }
                    cmbBatNo = cmbBatNo.Remove(cmbBatNo.Length - 1, 1);
                    obj = data.getxmlfile(cmbBatNo);

                    //DataTable dt = obj;
                    DataTable groupDT = GroupBy("Account_No", "Amount", obj);

                    //   var newDt = obj.AsEnumerable()
                    //.GroupBy(r => new
                    //    {
                    //        BatchNo = r.Field<string>(0).Trim(),
                    //        CheqNo = r.Field<string>(1).Trim(),
                    //        SortCode = r.Field<string>(2).Trim(),
                    //        BaseCode = r.Field<string>(3).Trim(),
                    //        TranCode = r.Field<string>(4).Trim(),
                    //        CheDate = r.Field<string>(5).Trim(),
                    //        Amount = r.Field<string>(6).Trim(),
                    //        AccountNo = r.Field<string>(7).Trim(),
                    //        DraweeName = r.Field<string>(8).Trim(),
                    //        Status = r.Field<string>(9).Trim(),
                    //        CustomerCode = r.Field<string>(10).Trim(),
                    //        CheckedBy = r.Field<string>(11).Trim(),
                    //        LocationCode = r.Field<string>(12).Trim(),
                    //        BankCode = r.Field<string>(13).Trim(),
                    //        BatchAmount = r.Field<string>(14).Trim(),
                    //        DeposoitSlipNo = r.Field<string>(15).Trim(),
                    //        BatchCode = r.Field<int>(16),
                    //    })
                    //.Select(g =>
                    //{
                    //    var row = obj.NewRow();
                    //    row[0] = g.Key.BatchNo;
                    //    row[1] = g.Sum(r => Convert.ToDecimal(r.Field<string>(1)));
                    //    return row;
                    //}).CopyToDataTable();

                    string batch_no_data = obj.Rows[0]["batch_code"].ToString();
                    String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                    string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    string uploadpath = PrgPath + "\\" + Todaysdate + "\\Finacle\\";
                    //string uploadpath = fileName + "Finacle";
                    if (!System.IO.Directory.Exists(uploadpath))
                    {
                        System.IO.Directory.CreateDirectory(uploadpath);
                    }
                    //string uploadpath1 = fileName + "Finacle\\" + batch_no_data;
                    //if (!System.IO.Directory.Exists(uploadpath1))
                    //{
                    //    System.IO.Directory.CreateDirectory(uploadpath1);
                    //}
                    string file = uploadpath + "\\FinacleFile_Gnsa _South_CLUPLD_" + yy + mm + dd + "_" + hh + min + sec + ".txt";
                    string basefileName = file;
                    if (File.Exists(basefileName))
                    {
                        File.Delete(basefileName);
                    }
                    // Create a new file     
                    using (StreamWriter fs = File.CreateText(basefileName))
                    {
                        string tempAccNo = "";
                        string line1 = string.Empty;
                        string line2 = string.Empty;
                        decimal flt = 0;
                        string ba = string.Empty;
                        string line3 = string.Empty;
                        string line4 = string.Empty;
                        decimal amnt = 0;
                        string amt = string.Empty;
                        string line5 = string.Empty;
                        string line6 = string.Empty;
                        string line7 = string.Empty;

                        for (int i = 0; i < obj.Rows.Count; i++)
                        {
                            //string line1 = obj.Rows[i]["Account_No"].ToString();
                            //line1 = line1.Length == 12 ? line1 : line1.PadRight(10, ' ');
                            //string line2 = "INR";
                            //string ba = obj.Rows[i]["batch_amount"].ToString().Replace(",", "");
                            //string line3 = ba + "Y.";
                            //string line4 = obj.Rows[i]["Cheq_no"].ToString();
                            //string amt = obj.Rows[i]["Amount"].ToString().Replace(",", "");
                            //string line5 = amt + obj.Rows[i]["Tran_Code"].ToString();
                            //string line6 = obj.Rows[i]["Sort_Code"].ToString();
                            //string line7 = "YY";
                            ////fs.WriteLine(obj.Rows[i]["Account_No"] + "\t INR \t\t" + obj.Rows[i]["batch_amount"] + "Y.[/{0}][/{0}][/{0}][/{0}][/{0}]" + obj.Rows[i]["Cheq_no"] + "[/{0}][/{0}]" + obj.Rows[i]["Amount"] + "" + obj.Rows[i]["Tran_Code"] + " " + obj.Rows[i]["Sort_Code"] + "[/{0}][/{0}]NY");                              
                            //fs.WriteLine("{0}\t{1}\r{2}\r{3}\r{4}\r{5}\r{6}", line1.PadRight(3, ' '), line2.PadRight(8, ' '), line3.PadLeft(14, ' '), line4.PadLeft(45, ' '), line5.PadLeft(19, ' '), line6.PadLeft(10, ' '), line7.PadLeft(14, ' '));

                            line1 = obj.Rows[i]["Account_No"].ToString();
                            var result = groupDT.AsEnumerable().Where(dr => dr.Field<string>("Account_No").Trim() == line1);
                            DataRow[] dr1 = groupDT.Select(string.Format("Account_No ='{0}' ", line1));
                            line1 = line1.Length == 12 ? line1 : line1.PadRight(10, ' ');
                            tempAccNo = (i < obj.Rows.Count - 1) ? obj.Rows[i + 1]["Account_No"].ToString() : tempAccNo = obj.Rows[i - 1]["Account_No"].ToString();
                            line2 = "INR";
                            flt = Convert.ToDecimal(dr1[0].ItemArray[1].ToString());
                            ba = flt.ToString("0.00");
                            //string ba = dr1[0].ItemArray[1].ToString();
                            //ba = ba.Contains(".") ? ba : ba + ".00";
                            line3 = ba + "Y.";
                            line4 = obj.Rows[i]["Cheq_no"].ToString();
                            //string amt = obj.Rows[i]["Amount"].ToString().Replace(",", "");
                            //amt = amt.Contains(".") ? amt : amt + ".00";
                            amnt = Convert.ToDecimal(obj.Rows[i]["Amount"].ToString().Replace(",", ""));
                            amt = amnt.ToString("0.00");
                            line5 = amt + obj.Rows[i]["Tran_Code"].ToString();
                            line6 = obj.Rows[i]["Sort_Code"].ToString();
                            line7 = "";// "YY";
                            line7 = (tempAccNo.Equals(line1)) ? "NY" : "YY";
                            if (i == obj.Rows.Count - 1)
                            {
                                line7 = "YY";
                            }
                            //fs.WriteLine(obj.Rows[i]["Account_No"] + "\t INR \t\t" + obj.Rows[i]["batch_amount"] + "Y.[/{0}][/{0}][/{0}][/{0}][/{0}]" + obj.Rows[i]["Cheq_no"] + "[/{0}][/{0}]" + obj.Rows[i]["Amount"] + "" + obj.Rows[i]["Tran_Code"] + " " + obj.Rows[i]["Sort_Code"] + "[/{0}][/{0}]NY");                              
                            fs.WriteLine("{0}\t{1}\r{2}\r{3}\r{4}\r{5}\r{6}", line1.PadRight(3, ' '), line2.PadRight(8, ' '), line3.PadLeft(14, ' '), line4.PadLeft(45, ' '), line5.PadLeft(19, ' '), line6.PadLeft(10, ' '), line7.PadLeft(14, ' '));

                            line1 = string.Empty;
                            line2 = string.Empty;
                            flt = 0;
                            ba = string.Empty;
                            line3 = string.Empty;
                            line4 = string.Empty;
                            amnt = 0;
                            amt = string.Empty;
                            line5 = string.Empty;
                            line6 = string.Empty;
                            line7 = string.Empty;
                        }
                    }
                    // Open the stream and read it back.    
                    using (StreamReader sr = File.OpenText(basefileName))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {

                        }
                    }
                }
                catch (Exception Ex)
                {
                    //LogHelper.WriteLog(Ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void CreateDoneFile(string fileName)
        {
            try
            {

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                // Create a new file     
                using (StreamWriter fs = File.CreateText(fileName))
                {
                }
                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
                {

                }
            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Bitmap ReturnImage(string base64)
        {
            Bitmap bm = null;
            byte[] byteBuffer = null;
            try
            {
                byteBuffer = Convert.FromBase64String(base64);
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                //Bitmap bmpFront = (Bitmap)Bitmap.FromStream(memoryStream);
                bm = new Bitmap(Image.FromStream(memoryStream));
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bm;
        }
        private void gvuploadgrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = gvuploadgrid.CurrentCell.ColumnIndex;
                    int iRow = gvuploadgrid.CurrentCell.RowIndex;
                    if (iColumn == gvuploadgrid.Columns.Count - 1)
                        gvuploadgrid.CurrentCell = gvuploadgrid[0, iRow + 1];
                    else
                        gvuploadgrid.CurrentCell = gvuploadgrid[iColumn + 1, iRow];
                }

                switch (e.KeyData & Keys.KeyCode)
                {
                    case Keys.Up:
                    case Keys.Right:
                    case Keys.Down:
                    case Keys.Left:
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Upload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        /*Upload Image in the Same PAth*/
        /*Write By SheebaSebasthian*/
        private void ImageUploadByUploadCodeBased(List<uploadgrid> list, string BatchName)
        {
            try
            {
                List<CheckerEntities> obj;
                ScannerBusiness data = new ScannerBusiness();
                string dd = DateTime.Now.Day.ToString("d2");
                string mm = DateTime.Now.Month.ToString("d2");
                string yy = DateTime.Now.Year.ToString();
                string hh = DateTime.Now.Hour.ToString("d2");
                string min = DateTime.Now.Minute.ToString("d2");
                string ss = DateTime.Now.Second.ToString("d2");


                string[] files;
                string[] xmlimagefiles;
                string batch_no = "";
                //string[] tifffiles;
                string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                BatchName = BatchName.Replace("-", "");
                String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                string uploadpath = PrgPath + "\\" + Todaysdate + "\\Upload\\" + BatchName;
                string uploadpathOld = PrgPath + "\\" + Todaysdate + "\\Upload\\" + batch_no;
                string currentdate = PrgPath + "\\" + Todaysdate + " \\";
                if (!System.IO.Directory.Exists(currentdate))
                {
                    System.IO.Directory.CreateDirectory(currentdate);
                }

                if (!System.IO.Directory.Exists(currentdate + "\\Upload\\"))
                {
                    System.IO.Directory.CreateDirectory(currentdate + "\\Upload\\");
                }
                if (!System.IO.Directory.Exists(uploadpath))
                {
                    System.IO.Directory.CreateDirectory(uploadpath);
                }
                else
                {
                    foreach (string file in Directory.GetFiles(uploadpath))
                    {
                        File.Delete(file);
                    }
                    System.IO.Directory.Delete(uploadpath);
                    System.IO.Directory.CreateDirectory(uploadpath);
                }
                DataTable dataobj = new DataTable();
                DataTable dtscanningdtl = new DataTable();



                xmlimagefiles = new string[5 * list.Count];
                string cmbBatNo = "";
                for (int i = 0; i < list.Count; i++)
                {
                    batch_no = list[i].batch_no.ToString();
                    cmbBatNo = cmbBatNo + "'" + batch_no + "',";

                }
                cmbBatNo = cmbBatNo.Remove(cmbBatNo.Length - 1, 1);

                ScannerBusiness objscanning = new ScannerBusiness();
                batch_no = list[0].batch_no.ToString();
                dataobj = data.getxmlfile(cmbBatNo);
                dtscanningdtl = objscanning.GetUploadImage(cmbBatNo);
                string b_code = dataobj.Rows[0]["batch_code"].ToString();
                batch_no = "_" + b_code.Split('/')[2];
                if (dataobj.Rows.Count > 0)
                {
                    if (dtscanningdtl.Rows.Count > 0)
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                        doc.AppendChild(xmlDeclaration);

                        XmlElement element1 = CreateFileHeaderBatchwise(doc, batch_no);

                        doc.AppendChild(element1);

                        Bitmap front_image = null;
                        Bitmap back_image = null;
                        Bitmap front_uv_image = null;
                        Bitmap back_uv_image = null;
                        Bitmap gray_back_image = null;
                        String imgFileName = string.Empty;
                        String imgFileName1 = string.Empty;
                        string FI = string.Empty;
                        String imgFileName2 = string.Empty;
                        string BI = string.Empty;
                        String imgFileName3 = string.Empty;
                        String xmlFileName = string.Empty;

                        for (int j = 0; j < dtscanningdtl.Rows.Count; j++)
                        {
                          
                            LogHelper.WriteLog("Upload Image File Creation Started..");
                            int k = j + 1;
                            front_image = ReturnImage(dtscanningdtl.Rows[j]["front_image"].ToString());
                            back_image = ReturnImage(dtscanningdtl.Rows[j]["back_image"].ToString());
                            front_uv_image = ReturnImage(dtscanningdtl.Rows[j]["front_uv_image"].ToString());
                            back_uv_image = ReturnImage(dtscanningdtl.Rows[j]["back_uv_image"].ToString());
                            // Bitmap gray_front_image = ReturnImage();
                            gray_back_image = ReturnImage(dtscanningdtl.Rows[j]["grey_back"].ToString());
                            imgFileName = "KIO_FG_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                            CreateGray(dtscanningdtl.Rows[j]["grey_front"].ToString(), uploadpath, imgFileName);
                            xmlimagefiles[0] = imgFileName + ".jpg";
                            imgFileName1 = "KIO_FB_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                            FI = dtscanningdtl.Rows[j]["front_image"].ToString();
                            Tiff(FI, uploadpath, imgFileName1);
                            xmlimagefiles[1] = imgFileName1 + ".tiff";
                            // Tiff Creation
                             imgFileName2 = " KIO_RB_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                            //CreateTiff(back_image, uploadpath, imgFileName2);
                             BI = dtscanningdtl.Rows[j]["back_image"].ToString();
                            Tiff(BI, uploadpath, imgFileName2);
                            xmlimagefiles[2] = imgFileName2 + ".tiff";

                            // UV Creation
                             imgFileName3 = "KIO_FU_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                            CreateGray(dtscanningdtl.Rows[j]["front_uv_image"].ToString(), uploadpath, imgFileName3);
                            xmlimagefiles[3] = imgFileName3 + ".jpg";
                             xmlFileName = "KXD_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
                            CreateXmlFile(list, uploadpath, xmlFileName, xmlimagefiles, dataobj.Rows[j], batch_no, (j + 1));
                            xmlimagefiles[4] = xmlFileName + ".xml";
                            XmlElement element2 = CreateChildElementBatchwise(doc, xmlimagefiles, batch_no, (j + 1));
                            element1.AppendChild(element2);

                             front_image = null;
                             back_image = null;
                             front_uv_image = null;
                             back_uv_image = null;
                             gray_back_image = null;
                             imgFileName = string.Empty;
                             imgFileName1 = string.Empty;
                             FI = string.Empty;
                             imgFileName2 = string.Empty;
                             BI = string.Empty;
                             imgFileName3 = string.Empty;
                             xmlFileName = string.Empty;

                        }

                        String xmlbatchwiseFileName = "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41";
                        // CreatebatchwiseXmlFile(list, uploadpath, xmlbatchwiseFileName, xmlimagefiles);
                        string url = uploadpath + "\\" + xmlbatchwiseFileName + ".xml";
                        // doc.Save(url);
                        using (var writer = new XmlTextWriter(url, new UTF8Encoding(false)))
                        {
                            doc.Save(writer);
                        }
                        string doneFilename = uploadpath + "\\" + "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41.XML.DONE";
                        CreateDoneFile(doneFilename);
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog("Upload Image File Failed..");
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
            //    List<CheckerEntities> obj;
            //    ScannerBusiness data = new ScannerBusiness();
            //    string dd = DateTime.Now.Day.ToString("d2");
            //    string mm = DateTime.Now.Month.ToString("d2");
            //    string yy = DateTime.Now.Year.ToString();
            //    string hh = DateTime.Now.Hour.ToString("d2");
            //    string min = DateTime.Now.Minute.ToString("d2");
            //    string ss = DateTime.Now.Second.ToString("d2");

            //    string[] files;

            //    string[] xmlimagefiles;
            //    //string[] tifffiles;
            //    string batch_no = "";
            //    string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //    string uploadpath = PrgPath + "\\Upload\\" + BatchName;
            //    if (!System.IO.Directory.Exists(PrgPath + "\\Upload\\"))
            //    {
            //        System.IO.Directory.CreateDirectory(PrgPath + "\\Upload\\");
            //    }
            //    if (!System.IO.Directory.Exists(uploadpath))
            //    {
            //        System.IO.Directory.CreateDirectory(uploadpath);
            //    }
            //    else
            //    {
            //        foreach (string file in Directory.GetFiles(uploadpath))
            //        {
            //            File.Delete(file);
            //        }
            //        System.IO.Directory.Delete(uploadpath);
            //        System.IO.Directory.CreateDirectory(uploadpath);
            //    }
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        DataTable dtscanningdtl = new DataTable();
            //        ScannerBusiness objscanning = new ScannerBusiness();
            //        xmlimagefiles = new string[5];
            //        // string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //        batch_no = list[i].batch_no.ToString();
            //        DataTable dataobj = data.getxmlfile(batch_no);
            //        dtscanningdtl = objscanning.GetUploadImage(batch_no);
            //        if (dataobj.Rows.Count > 0)
            //        {
            //            if (dtscanningdtl.Rows.Count > 0)
            //            {
            //                // batch_no = batch_no.Replace('/', '-');

            //                XmlDocument doc = new XmlDocument();
            //                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            //                doc.AppendChild(xmlDeclaration);

            //                XmlElement element1 = CreateFileHeaderBatchwise(doc, batch_no);

            //                doc.AppendChild(element1);

            //                for (int j = 0; j < dtscanningdtl.Rows.Count; j++)
            //                {
            //                    int k = j + 1;
            //                    Bitmap front_image = ReturnImage(dtscanningdtl.Rows[j]["front_image"].ToString());
            //                    Bitmap back_image = ReturnImage(dtscanningdtl.Rows[j]["back_image"].ToString());
            //                    Bitmap front_uv_image = ReturnImage(dtscanningdtl.Rows[j]["front_uv_image"].ToString());
            //                    Bitmap back_uv_image = ReturnImage(dtscanningdtl.Rows[j]["back_uv_image"].ToString());
            //                    // Bitmap gray_front_image = ReturnImage();
            //                    Bitmap gray_back_image = ReturnImage(dtscanningdtl.Rows[j]["grey_back"].ToString());
            //                    String imgFileName = "KIO_FG_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
            //                    CreateGray(dtscanningdtl.Rows[j]["grey_front"].ToString(), uploadpath, imgFileName);
            //                    xmlimagefiles[0] = imgFileName + ".jpg";
            //                    String imgFileName1 = "KIO_FB_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
            //                    CreateTiff(front_image, uploadpath, imgFileName1);
            //                    xmlimagefiles[1] = imgFileName1 + ".tiff";
            //                    // Tiff Creation
            //                    String imgFileName2 = " KIO_RB_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
            //                    CreateTiff(back_image, uploadpath, imgFileName2);
            //                    xmlimagefiles[2] = imgFileName2 + ".tiff";

            //                    // UV Creation
            //                    String imgFileName3 = "KIO_FU_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
            //                    CreateGray(dtscanningdtl.Rows[j]["front_uv_image"].ToString(), uploadpath, imgFileName3);
            //                    xmlimagefiles[3] = imgFileName3 + ".jpg";
            //                    String xmlFileName = "KXD_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_00" + k;
            //                    CreateXmlFile(list, uploadpath, xmlFileName, xmlimagefiles, dataobj.Rows[j], batch_no);
            //                    xmlimagefiles[4] = xmlFileName + ".xml";
            //                    XmlElement element2 = CreateChildElementBatchwise(doc, xmlimagefiles);
            //                    element1.AppendChild(element2);
            //                }
            //                int l = i + 1;
            //                String xmlbatchwiseFileName = "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41";
            //                // CreatebatchwiseXmlFile(list, uploadpath, xmlbatchwiseFileName, xmlimagefiles);
            //                string url = uploadpath + "\\" + xmlbatchwiseFileName + ".xml";
            //                doc.Save(url);
            //                string doneFilename = uploadpath + "\\" + "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41.XML.DONE";
            //                CreateDoneFile(doneFilename);
            //            }
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(ex.ToString());
            //}
        }
        private void cmbuptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            btngen.Enabled = true;
        }
        private void cmbloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnref.Enabled = true;
        }
        private void cmbuptype_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btngen.Enabled = true;
        }
        private void cmbloc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnref.Enabled = true;
        }
        #region Implemented By Mohan For New Upload
        private void lstbtngen_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            string batch_no = "";
            try
            {
                List<DataGridViewRow> rows3 = new List<DataGridViewRow>(from DataGridViewRow r in gvuploadgrid.Rows
                                                                        where Convert.ToBoolean(r.Cells[0].Value) == true
                                                                        select r);
                if (rows3.Count == 0)
                {
                    MessageBox.Show("Please Select Atleast OneRecord In Grid");
                    PicLoad.Visible = false;
                    rows3 = null;
                    return;
                }
                if (cmbloc.Text.ToString() == "")
                {
                    MessageBox.Show("Please Select the Location ", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbtype.Focus();
                    PicLoad.Visible = false;
                    btnref.Enabled = true;
                    return;
                }

                var list = new List<DataGridViewRow>(rows3);

                var groupvalue = list.GroupBy(V => V.Cells[8].Value).Where(x => x.Count() >= 1).ToList();

                DataTable updt = (DataTable)gvuploadgrid.DataSource;

                if (rows3.Count > 0)
                {
                    if (groupvalue.Count > 1)
                    {
                        MessageBox.Show("Link No Is Missing for this Batch", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PicLoad.Visible = false;
                        return;
                    }
                    else
                    {
                        string[] uploadlink = new string[updt.Rows.Count];
                        string linkno = "";
                        string uplodcode = "";
                        int checkuecount = 0;
                        for (int j = 0; j < rows3.Count; j++)
                        {
                            uploadlink[j] = rows3[j].Cells["Upload Link No"].Value.ToString(); ;
                            batch_no = batch_no + "," + rows3[j].Cells["Batch No"].Value.ToString();
                            linkno = rows3[j].Cells["Upload Link No"].Value.ToString();
                            uplodcode = rows3[j].Cells["Upload Code"].Value.ToString();
                            checkuecount = checkuecount + Convert.ToInt16(rows3[j].Cells["Success"].Value.ToString());
                        }
                        uploadlink = uploadlink.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        bool isvalid = CheckDublicateLinkNo(uploadlink, batch_no, uplodcode);

                        if (isvalid)
                        {
                            /* -- Commented By Sheeba
                            batch_no = batch_no.Substring(1);
                            NewUploaEntites lstobj = new NewUploaEntites();
                            lstobj.batch_no = batch_no;
                            lstobj.upload_linkno = linkno;
                            lstobj.generate_type = cmbuptype.Text;
                            lstobj.upload_code = uplodcode;
                            lstobj.location_name = cmbloc.Text;
                            ScannerBusiness obj = new ScannerBusiness();

                            DataTable dtresultRecord = obj.NewUpload(lstobj); */

                            batch_no = batch_no.Substring(1);
                            NewUploaEntites lstobj = new NewUploaEntites();
                            lstobj.batch_no = batch_no;
                            lstobj.upload_linkno = linkno;
                            lstobj.generate_type = cmbuptype.Text;
                            lstobj.upload_code = uplodcode;
                            lstobj.location_name = cmbloc.Text;
                            ScannerBusiness obj = new ScannerBusiness();
                            DataTable dtresultRecord = new DataTable();
                            for (int i = 0; i < checkuecount; i++)
                            {
                                lstobj.from_index = (i + 1);
                                lstobj.to_index = (i + 10);
                                DataTable dt = obj.NewUpload(lstobj);
                                if (i == 0)
                                {
                                    dtresultRecord = dt.Clone();
                                }
                                foreach (DataRow drtableOld in dt.Rows)
                                {
                                    dtresultRecord.ImportRow(drtableOld);
                                }
                                i = i + 9;
                            }

                            LogHelper.WriteLog("Checque Count :" + checkuecount);
                            LogHelper.WriteLog("Data Result Count :" + dtresultRecord.Rows.Count);

                            if (cmbuptype.Text == "Image" && dtresultRecord.Rows.Count > 0)
                            {
                                LogHelper.WriteLog("Upload Image File.." + dtresultRecord.Rows.Count);
                                //var batchCodeVsUpLoadCode = (uplodcode.ToString()).Replace("/", "_");
                                var batchCodeVsUpLoadCode = (dtresultRecord.Rows[0]["batch_code"].ToString()).Replace("/", "_");
                                string uploadPath = CreateFolderForImageUpload(batchCodeVsUpLoadCode);

                                if (uploadPath != "")
                                {
                                    ImageAndXMLFileCration(uploadPath, dtresultRecord);
                                    //ImageAndXMLFileCrationFromPhysicalPath(uploadPath, dtresultRecord);
                                    MessageBox.Show("uploaded succesfully");
                                    PicLoad.Visible = false;
                                    MasterEntities.UploadBatchEntities obj1 = new MasterEntities.UploadBatchEntities();
                                    obj1.Type = cmbtype.Text.ToString();
                                    obj1.Location = cmbloc.SelectedValue.ToString();
                                    rdoall.Checked = true;
                                    LoadGriddetails(obj1);
                                    PicLoad.Visible = false;
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("There is some issue in folder creation");
                                    PicLoad.Visible = false;
                                    return;
                                }
                            }
                            else if (cmbuptype.Text == "Finnexia")
                            {
                                LogHelper.WriteLog("Upload Finnexia File..");
                                string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                                if (!System.IO.Directory.Exists(PrgPath + "\\Upload\\"))
                                {
                                    System.IO.Directory.CreateDirectory(PrgPath + "\\Upload\\");
                                }
                                GetFinnaxiaFile(dtresultRecord);

                                MessageBox.Show("Finnaxia File Uploaded Successfully");
                                PicLoad.Visible = false;

                                return;
                            }
                            else if (cmbuptype.Text == "Finacle")
                            {
                                LogHelper.WriteLog("Upload Finacle File..");
                                string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                                if (!System.IO.Directory.Exists(PrgPath + "\\Upload\\"))
                                {
                                    System.IO.Directory.CreateDirectory(PrgPath + "\\Upload\\");
                                }

                                GetFinacleFile(dtresultRecord);
                                MessageBox.Show("Finacle File Uploaded Successfully");
                                PicLoad.Visible = false;

                                return;

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Atleast OneRecord In Grid");
                    PicLoad.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PicLoad.Visible = false;
                return;
            }
            PicLoad.Visible = false;
        }
        static DataTable ConvertListToDataTable(List<DataGridViewRow> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (DataGridViewRow row in list)
            {
                //table.Columns.Add(row.Cells)
                table.Rows.Add(row);
            }

            //// Add columns.
            //for (int i = 0; i < columns; i++)
            //{
            //    table.Columns.Add();
            //}

            //// Add rows.
            //foreach (var array in list)
            //{
            //    table.Rows.Add(array);
            //}

            return table;
        }
        private string CreateFolderForImageUpload(string Upd_Code)
        {
            string returnVal = "";
            try
            {

                string[] files;
                string[] xmlimagefiles;
                string batch_no = "";
                //string[] tifffiles;
                string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                Upd_Code = Upd_Code.Replace("-", "");
                String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                string uploadpath = PrgPath + "\\" + Todaysdate + "\\Upload\\" + Upd_Code;
                string uploadpathOld = PrgPath + "\\" + Todaysdate + "\\Upload\\" + batch_no;
                string currentdate = PrgPath + "\\" + Todaysdate + " \\";
                if (!System.IO.Directory.Exists(currentdate))
                {
                    System.IO.Directory.CreateDirectory(currentdate);
                }

                if (!System.IO.Directory.Exists(currentdate + "\\Upload\\"))
                {
                    System.IO.Directory.CreateDirectory(currentdate + "\\Upload\\");
                }
                if (!System.IO.Directory.Exists(uploadpath))
                {
                    System.IO.Directory.CreateDirectory(uploadpath);
                }
                else
                {
                    foreach (string file in Directory.GetFiles(uploadpath))
                    {
                        File.Delete(file);
                    }
                    System.IO.Directory.Delete(uploadpath);
                    System.IO.Directory.CreateDirectory(uploadpath);
                }
                returnVal = uploadpath;
                //return returnVal;
            }
            catch (Exception e)
            {
                returnVal = "";

            }
            finally
            {

            }
            return returnVal;
            //if (dt.Rows.Count > 0)
            //{
            //    for (int j = 0; j < dt.Rows.Count; j++)
            //    {
            //        String imgFileName = dt.Rows[j]["FrontGrayImageName"].ToString();
            //        CreateGray(dt.Rows[j]["front_image"].ToString(), uploadpath, imgFileName);



            //    }
            //}
        }
        private void ImageAndXMLFileCration(string uploadPath, DataTable dtreturnRecord)
        {
            try
            {
                string dd = DateTime.Now.Day.ToString("d2");
                string mm = DateTime.Now.Month.ToString("d2");
                string yy = DateTime.Now.Year.ToString();
                //string hh = DateTime.Now.Hour.ToString("d2");
                //string min = DateTime.Now.Minute.ToString("d2");
                //string ss = DateTime.Now.Second.ToString("d2");
                string hh = DateTime.Now.Hour.ToString("00.##");
                string min = DateTime.Now.Minute.ToString("00.##");
                string ss = DateTime.Now.Second.ToString("00.##");

                if (dtreturnRecord.Rows.Count > 0)
                {
                    int cc = 0;
                    string[] xmlimgfile;
                    xmlimgfile = new string[5 * dtreturnRecord.Rows.Count];
                    string batchCodeVsUpLoadCode = (dtreturnRecord.Rows[0]["batch_code"].ToString()).Replace("/", "_");
                    string batch_no = batchCodeVsUpLoadCode.Split('_')[2];

                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                    doc.AppendChild(xmlDeclaration);
                    XmlElement element1 = CreateFileHeaderBatch(doc, batch_no);
                    doc.AppendChild(element1);
                    foreach (DataRow dtRow in dtreturnRecord.Rows)
                    {
                        cc++;

                        //String FrontImgName = dtRow[22].ToString();
                        //Tiff(dtRow[9].ToString(), uploadPath, FrontImgName);
                        //xmlimgfile[0] = FrontImgName + ".jpg";

                        //String BackImgName = dtRow[23].ToString();
                        //Tiff(dtRow[10].ToString(), uploadPath, BackImgName);
                        //xmlimgfile[1] = BackImgName + ".tif";

                        //String FUImgName = dtRow[25].ToString(); // TODO dtRow[24].ToString();
                        //CreateGray(dtRow[11].ToString(), uploadPath, FUImgName);
                        //xmlimgfile[2] = FUImgName + ".jpg";

                        //String RBImgName = dtRow[24].ToString(); // TODO
                        //CreateGray(dtRow[9].ToString(), uploadPath, RBImgName);
                        //xmlimgfile[3] = RBImgName + ".tif";  // TODO

                        string FBImgName = dtRow[23].ToString();
                        Tiff(dtRow[9].ToString(), uploadPath, FBImgName);
                        xmlimgfile[0] = FBImgName + ".tiff";

                        string RBImgName = dtRow[24].ToString();
                        Tiff(dtRow[10].ToString(), uploadPath, RBImgName);
                        xmlimgfile[1] = RBImgName + ".tiff";

                        string FUImgName = dtRow[25].ToString(); // TODO dtRow[24].ToString();
                        CreateGray(dtRow[11].ToString(), uploadPath, FUImgName);
                        xmlimgfile[2] = FUImgName + ".jpg";

                        string FGImgName = dtRow[22].ToString(); // TODO
                        CreateGray(dtRow[9].ToString(), uploadPath, FGImgName);
                        xmlimgfile[3] = FGImgName + ".jpg";  // TODO

                        string xmlFileName = dtRow[26].ToString();
                        CreateXmlImg(uploadPath, xmlFileName, xmlimgfile, dtRow, batch_no, cc);
                        xmlimgfile[4] = xmlFileName + ".xml";
                        XmlElement element2 = CreateChildElementBatchwise(doc, xmlimgfile, batch_no, cc);
                        element1.AppendChild(element2);
                    }

                    //string xmlbatchwiseFileName = "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41";
                    string xmlbatchwiseFileName = dtreturnRecord.Rows[0]["OverallXMLFile"].ToString();
                    string doneFilename = uploadPath + "\\" + dtreturnRecord.Rows[0]["DoneFile"].ToString();
                    //if (cmbloc.Text == "Chennai")
                    //{
                    //    xmlbatchwiseFileName = "KIO_FTL00000" + cmbloc.SelectedValue + "12001_01_" + dd + mm + yy + "_" + cmbloc.SelectedValue + "641002_" + hh + min + ss + "_" + batch_no + "_41";
                    //    doneFilename = uploadPath + "\\" + "KIO_FTL00000" + cmbloc.SelectedValue + "12001_01_" + dd + mm + yy + "_" + cmbloc.SelectedValue + "641002_" + hh + min + ss + "_" + batch_no + "_41.XML.DONE";
                    //}
                    //else if (cmbloc.Text == "Delhi")
                    //{
                    //    xmlbatchwiseFileName = "KIO_FTL00000" + cmbloc.SelectedValue + "11001_01_" + dd + mm + yy + "_" + cmbloc.SelectedValue + "641002_" + hh + min + ss + "_" + batch_no + "_41";
                    //    doneFilename = uploadPath + "\\" + "KIO_FTL00000" + cmbloc.SelectedValue + "11001_01_" + dd + mm + yy + "_" + cmbloc.SelectedValue + "641002_" + hh + min + ss + "_" + batch_no + "_41.XML.DONE";
                    //}
                    string url = uploadPath + "\\" + xmlbatchwiseFileName + ".xml";
                    // doc.Save(url);
                    using (var writer = new XmlTextWriter(url, new UTF8Encoding(false)))
                    {
                        doc.Save(writer);
                    }
                    //string doneFilename = uploadPath + "\\" + "KIO_FTL0000060012001_01_" + dd + mm + yy + "_600641002_" + hh + min + ss + batch_no + "_41.XML.DONE";
                    CreateDoneFile(doneFilename);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

        private void ImageAndXMLFileCrationFromPhysicalPath(string uploadPath, DataTable dtreturnRecord)
        {
            string dd = DateTime.Now.Day.ToString("d2");
            string mm = DateTime.Now.Month.ToString("d2");
            string yy = DateTime.Now.Year.ToString();
            string hh = DateTime.Now.Hour.ToString("00.##");
            string min = DateTime.Now.Minute.ToString("00.##");
            string ss = DateTime.Now.Second.ToString("00.##");

            if (dtreturnRecord.Rows.Count > 0)
            {
                int cc = 0;
                string[] xmlimgfile;
                xmlimgfile = new string[5 * dtreturnRecord.Rows.Count];
                string batchCodeVsUpLoadCode = (dtreturnRecord.Rows[0]["batch_code"].ToString()).Replace("/", "_");
                string batch_no = batchCodeVsUpLoadCode.Split('_')[2];

                batchCodeVsUpLoadCode = batchCodeVsUpLoadCode.Replace("UPLOAD", "BATCH");
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmlDeclaration);
                XmlElement element1 = CreateFileHeaderBatch(doc, batch_no);
                doc.AppendChild(element1);
                foreach (DataRow dtRow in dtreturnRecord.Rows)
                {
                    cc++;

                    string physicalpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    physicalpath = physicalpath + "\\Scanimage\\" + batchCodeVsUpLoadCode;

                    string FBImgName = "\\ScanimageFront" + cc + mm + dd;
                    File.Move(FBImgName, FBImgName + ".tiff");


                    //string FBImgName = dtRow[23].ToString();
                    //Tiff(dtRow[9].ToString(), uploadPath, FBImgName);
                    //xmlimgfile[0] = FBImgName + ".tiff";

                    //string RBImgName = dtRow[24].ToString();
                    //Tiff(dtRow[10].ToString(), uploadPath, RBImgName);
                    //xmlimgfile[1] = RBImgName + ".tiff";

                    //string FUImgName = dtRow[25].ToString(); // TODO dtRow[24].ToString();
                    //CreateGray(dtRow[11].ToString(), uploadPath, FUImgName);
                    //xmlimgfile[2] = FUImgName + ".jpg";

                    //string FGImgName = dtRow[22].ToString(); // TODO
                    //CreateGray(dtRow[9].ToString(), uploadPath, FGImgName);
                    //xmlimgfile[3] = FGImgName + ".jpg";  // TODO

                    string xmlFileName = dtRow[26].ToString();
                    CreateXmlImg(uploadPath, xmlFileName, xmlimgfile, dtRow, batch_no, cc);
                    xmlimgfile[4] = xmlFileName + ".xml";
                    XmlElement element2 = CreateChildElementBatchwise(doc, xmlimgfile, batch_no, cc);
                    element1.AppendChild(element2);
                }
                string xmlbatchwiseFileName = dtreturnRecord.Rows[0]["OverallXMLFile"].ToString();
                string doneFilename = uploadPath + "\\" + dtreturnRecord.Rows[0]["DoneFile"].ToString();
                string url = uploadPath + "\\" + xmlbatchwiseFileName + ".xml";
                using (var writer = new XmlTextWriter(url, new UTF8Encoding(false)))
                {
                    doc.Save(writer);
                }
                CreateDoneFile(doneFilename);
            }
            return;
        }

        public void CreateXmlImg(string path, string Filename, string[] imagefilename, DataRow Dtrow, string batch_no, int cc)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmlDeclaration);
                XmlElement element1 = CreateFileHeader(doc, Dtrow, batch_no);
                doc.AppendChild(element1);
                XmlElement element2 = CreateChildElementForNewXML(doc, imagefilename, Dtrow, batch_no, cc);
                element1.AppendChild(element2);
                string url = path + "\\" + Filename + ".xml";
                // doc.Save(url);
                using (var writer = new XmlTextWriter(url, new UTF8Encoding(false)))
                {
                    doc.Save(writer);
                }
            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private XmlElement CreateChildElementForNewXML(XmlDocument doc, string[] imagefilename, DataRow Dtrow, string upload_code, int cc)
        {
            string amt = Dtrow[2].ToString();
            Regex reg = new Regex("^[0-9]*(\\.[0-9]{1,2})?$");
            if (!reg.IsMatch(amt))
            {
                double a = Convert.ToDouble(amt);
                amt = DoFormat(a);
            }
            else
            {
                double a = Convert.ToDouble(amt);
                amt = string.Format("{0:N2}", Convert.ToDecimal(a));
            }
            amt = amt.Replace(",", "");
            amt = amt.Replace(".", "");

            string CheckAmt = Dtrow[14].ToString();
            CheckAmt = CheckAmt.Replace(",", "");
            CheckAmt = CheckAmt.Replace(".", "");

            DateTime chqdate = Convert.ToDateTime(Dtrow[16]);
            string dd = chqdate.Day.ToString("00.##");
            string mm = chqdate.Month.ToString("00.##");
            //string hh = DateTime.Now.Hour.ToString("00.##");
            // string mm = DateTime.Now.Minute.ToString("00.##");
            string ss = DateTime.Now.Second.ToString("00.##");

            string yy = chqdate.Year.ToString();
            XmlElement element = doc.CreateElement("", "ItemDetail", "");
            try
            {
                element.SetAttribute("GovtStatus", "0");
                element.SetAttribute("MailID", "emial@email.com");
                element.SetAttribute("MobileNo", "9845098450");
                element.SetAttribute("CTSstatus", "2");
                element.SetAttribute("UVstatus", "2");
                element.SetAttribute("Skew", "2");
                element.SetAttribute("DocSizeInTenths", "2");
                element.SetAttribute("PctBlackBits", "2");
                //element.SetAttribute("IQAIgnoreInd", "2");
                element.SetAttribute("IQAIgnoreInd", "0");
                element.SetAttribute("ImageUsability", "2");
                element.SetAttribute("ImageQuality", "2");
                element.SetAttribute("ExceedsMaximumImageSize", "2");
                element.SetAttribute("BelowMinimumImageSize", "2");
                element.SetAttribute("LightOrDark", "2");
                element.SetAttribute("PartialImage", "2");
                element.SetAttribute("BentRightTopPix", "2");
                element.SetAttribute("BentRightBottomPix", "2");
                element.SetAttribute("BentLeftBottomPix", "2");
                element.SetAttribute("BentLeftTopPix", "2");
                element.SetAttribute("ChDate", dd + mm + yy); // TODO
                element.SetAttribute("DocType", "B");
                element.SetAttribute("Status", "PENDING");
                element.SetAttribute("DraweeDetail", "DRAWEE NAME");
                if (cmbtype.Text == "CMS")
                {
                    string customer = Dtrow["customer_code"].ToString();
                    customer = customer.Split('/')[1];
                    if (customer.Length > 25)
                    {
                        element.SetAttribute("DepositorName", customer.Substring(0, 25));
                    }
                    else
                    {
                        element.SetAttribute("DepositorName", customer);
                    }
                }
                if (cmbtype.Text == "CTS")
                {
                    element.SetAttribute("DepositorName", Dtrow[15].ToString());
                }
                element.SetAttribute("DepositorAcct", "826LIABICMSCLINR");
                element.SetAttribute("MiCRAmount", CheckAmt);
                element.SetAttribute("MICRTransCode", Dtrow["Tran_Code"].ToString());
                element.SetAttribute("MICRAccountNo", Dtrow["Base_Code"].ToString());
                string sort = Dtrow["Sort_Code"].ToString();
                sort = cmbloc.SelectedValue + sort.Substring(3);
                element.SetAttribute("MICRPayorBankRoutNo", sort);
                element.SetAttribute("MICRSerialNo", Dtrow["Cheq_no"].ToString());
                //element.SetAttribute("FGFileName", imagefilename[0].ToString());
                //element.SetAttribute("FBFileName", imagefilename[1].ToString()); // TODO
                //element.SetAttribute("FUFileName", imagefilename[2].ToString());  // TODO
                //element.SetAttribute("RBFileName", imagefilename[3].ToString());
                element.SetAttribute("FGFileName", imagefilename[3].ToString());
                element.SetAttribute("FBFileName", imagefilename[0].ToString()); // TODO
                element.SetAttribute("FUFileName", imagefilename[2].ToString());  // TODO
                element.SetAttribute("RBFileName", imagefilename[1].ToString());

                //element.SetAttribute("KioskTranId", "080320160416");
                if (cmbloc.Text == "Chennai")
                {
                    element.SetAttribute("KioskTranId", "080320160416");
                }
                else
                {
                    element.SetAttribute("KioskTranId", "00466003" + upload_code + cc.ToString("000"));
                }
                //element.SetAttribute("ItemSeqNo", "00466003505001");
                //element.SetAttribute("ItemSeqNo", "00466003" + upload_code.Substring(1, 3) + cc.ToString("000"));
                element.SetAttribute("ItemSeqNo", "00466003" + upload_code + cc.ToString("000"));

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
        }
        private XmlElement CreateFileHeaderBatch(XmlDocument doc, string batch_no)
        {
            XmlElement element = doc.CreateElement("FileHeader");
            try
            {
                string dd = DateTime.Now.Day.ToString("d2");
                string mm = DateTime.Now.Month.ToString("d2");
                string yy = DateTime.Now.Year.ToString();
                string hh = DateTime.Now.Hour.ToString();
                string min = DateTime.Now.Minute.ToString();
                string ss = DateTime.Now.Second.ToString();
                //element.SetAttribute("KioskName", "FTL0000060012001");
                if (cmbloc.Text == "Chennai")
                {
                    element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "12001");
                }
                else
                {
                    element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "11001");
                }
                element.SetAttribute("CreationTime", hh + min + ss);
                element.SetAttribute("PresentmentDate", dd + mm + yy);
                //element.SetAttribute("BatchID", batch_no.Remove(0, 1));                 // Need pass the Batch through Parameter           
                element.SetAttribute("BatchID", batch_no);
                element.SetAttribute("UVAvailable", "Yes");    // Get the Date 
                element.SetAttribute("Encrypt", "No");         // Get the Time and assign
                element.SetAttribute("SolId", "0001");  // Need to pass the KioskName
                element.SetAttribute("DLLVersion", "01.03.11.15");    // Get the Date   
                element.SetAttribute("xmlns", "FTL:OUTCL:CXD:FileStructure:010001");
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
        }
        public void GetFinnaxiaFile(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    LogHelper.WriteLog("Retrive Count is :" + dt.Rows.Count);
                    ScannerBusiness data = new ScannerBusiness();
                    string batch_no_data = dt.Rows[0]["batch_code"].ToString();
                    LogHelper.WriteLog("Upload Code:" + batch_no_data);
                    string batch_cde = batch_no_data.Split('/')[2].ToString();
                    String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                    LogHelper.WriteLog("Get Finnaxia file Location");
                    string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    LogHelper.WriteLog("Location :" + PrgPath);
                    string uploadpath = PrgPath + "\\" + Todaysdate + "\\Finnaxia\\";
                    if (!System.IO.Directory.Exists(uploadpath))
                    {
                        System.IO.Directory.CreateDirectory(uploadpath);
                    }
                    string basefileName = uploadpath + dt.Rows[0]["Finnaxia"].ToString() + ".txt";
                    LogHelper.WriteLog("Upload Finnaxia File :" + basefileName);
                    try
                    {
                        using (StreamWriter fs = File.CreateText(basefileName))
                        {
                            LogHelper.WriteLog("Start to write Finnaxia File");
                            string dd = DateTime.Now.Day.ToString("d2");
                            string mm = DateTime.Now.Month.ToString("d2");
                            string yy = DateTime.Now.Year.ToString();
                            decimal Totalamt = 0;
                            fs.WriteLine("HDR~0811" + yy + mm + dd + batch_cde + "~0811~");
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                int j = i + 1;
                                DateTime value = Convert.ToDateTime(dt.Rows[i]["Cheque Date"].ToString());
                                LogHelper.WriteLog("Check date :" + value);
                                string vdd = value.Day.ToString("d2");
                                string vmm = value.Month.ToString("d2");
                                string vyy = value.Year.ToString();
                                //string amount = dt.Rows[i]["Cheque Amount"].ToString().Replace(",", "");
                                //decimal amt = Convert.ToDecimal(amount);
                                decimal amount = Convert.ToDecimal(dt.Rows[i]["Cheque Amount"].ToString().Replace(",", ""));
                                LogHelper.WriteLog("Check date :" + amount.ToString());
                                string sortCode = dt.Rows[i]["Sort_Code"].ToString();
                                LogHelper.WriteLog("Sort Code:" + sortCode.ToString());
                                string chequeamount = amount.ToString("N0");
                                LogHelper.WriteLog("Check Amount :" + chequeamount.ToString());
                                //if (cmbloc.Text == "Chennai")
                                //{
                                //    sortCode = "600" + sortCode.Substring(3);
                                //}
                                LogHelper.WriteLog("Check Amount :" + cmbloc.SelectedValue);
                                //sortCode = cmbloc.SelectedValue + sortCode.Substring(3); /// Commented by Murali 03/12/2020

                                string customerCode = dt.Rows[i]["customer_code"].ToString();
                                if (customerCode != "")
                                {
                                    //if (customerCode != "Image Upload")
                                    //{
                                    customerCode = customerCode.Substring(0, customerCode.IndexOf('/'));
                                    //}
                                    LogHelper.WriteLog("Check Amount :" + cmbloc.SelectedValue);
                                }
                                LogHelper.WriteLog("Customer Code :" + customerCode.ToString());
                                //string txt = "I~" + j + "~" + dt.Rows[i]["Cheq_no"] + "~" + chequeamount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~CHEN~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["batch_dep_slip_no"] + "~~~~~";
                                //fs.WriteLine("I~" + j + "~" + dt.Rows[i]["Cheq_no"] + "~" + amount + "~" + dd + mm + yy + "~" + vdd + vmm + vyy + "~" + dt.Rows[i]["customer_code"] + "~" + dd + mm + yy + "~CHEN~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + dt.Rows[i]["Sort_Code"] + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["batch_dep_slip_no"] + "~~~~~");
                                //fs.WriteLine("I~" + j + "~" + dt.Rows[i]["Cheq_no"] + "~" + amount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~CHEN~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["batch_dep_slip_no"] + "~~~~~");
                                if (cmbloc.Text == "Chennai")
                                {
                                    // sortCode = sortCode.Substring(0, 6) + "002"; /// Commented by Murali 03/12/2020
                                    fs.WriteLine("I~" + j + "~" + dt.Rows[i]["Cheq_no"] + "~" + amount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~CHEN~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["batch_dep_slip_no"] + "~~~~~");
                                }
                                else if (cmbloc.Text == "Bangalore")
                                {
                                    fs.WriteLine("I~" + j + "~" + dt.Rows[i]["Cheq_no"] + "~" + amount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~BAN~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["batch_dep_slip_no"] + "~~~~~");
                                }
                                else if (cmbloc.Text == "Delhi")
                                {
                                    fs.WriteLine("I~" + j + "~" + dt.Rows[i]["Cheq_no"] + "~" + amount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~DEL~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["batch_dep_slip_no"] + "~~~~~");
                                }
                                decimal val = Convert.ToDecimal(dt.Rows[i]["Cheque Amount"].ToString());
                                Totalamt += val;
                                LogHelper.WriteLog("End Of Write Finnaxia");
                            }
                            int line = Convert.ToInt32(dt.Rows.Count) + 2;
                            fs.WriteLine("TRL~" + line + "~" + Totalamt + "~");
                        }

                    }
                    catch (Exception Ex)
                    {
                        //LogHelper.WriteLog(Ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PicLoad.Visible = false;

                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); PicLoad.Visible = false;

                return;
            }
        }
        public void GetFinacleFile(DataTable dt)
        {
            string dd = DateTime.Now.Day.ToString("d2");
            string mm = DateTime.Now.Month.ToString("d2");
            string yy = DateTime.Now.Year.ToString();
            string hh = DateTime.Now.Hour.ToString("d2");
            string min = DateTime.Now.Minute.ToString("d2");
            string sec = DateTime.Now.Second.ToString("d2");
            if (dt.Rows.Count > 0)
            {
                try
                {
                    DataTable obj = new DataTable();
                    ScannerBusiness data = new ScannerBusiness();
                    string batch_cde;
                    string cmbBatNo = "";
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        string batch_no = dt.Rows[k]["batch_no"].ToString();
                        cmbBatNo = cmbBatNo + "'" + batch_no + "',";
                        batch_cde = batch_no.Split('/')[2].ToString();
                    }
                    cmbBatNo = cmbBatNo.Remove(cmbBatNo.Length - 1, 1);
                    obj = data.getxmlfile(cmbBatNo);
                    DataTable groupDT = GroupBy("Account_No", "Amount", obj);
                    string batch_no_data = obj.Rows[0]["batch_code"].ToString();
                    String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                    string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    string uploadpath = PrgPath + "\\" + Todaysdate + "\\Finacle\\";
                    if (!System.IO.Directory.Exists(uploadpath))
                    {
                        System.IO.Directory.CreateDirectory(uploadpath);
                    }
                    string file = uploadpath + dt.Rows[0]["Finacle"].ToString() + ".txt";
                    string basefileName = file;
                    if (File.Exists(basefileName))
                    {
                        File.Delete(basefileName);
                    }
                    using (StreamWriter fs = File.CreateText(basefileName))
                    {
                        string tempAccNo = "";
                        for (int i = 0; i < obj.Rows.Count; i++)
                        {
                            string line1 = obj.Rows[i]["Account_No"].ToString();
                            var result = groupDT.AsEnumerable().Where(dr => dr.Field<string>("Account_No").Trim() == line1);
                            DataRow[] dr1 = groupDT.Select(string.Format("Account_No ='{0}' ", line1));
                            line1 = line1.Length == 12 ? line1 : line1.PadRight(10, ' ');
                            tempAccNo = (i < obj.Rows.Count - 1) ? obj.Rows[i + 1]["Account_No"].ToString() : tempAccNo = obj.Rows[i]["Account_No"].ToString();
                            string line2 = "INR";
                            decimal flt = Convert.ToDecimal(dr1[0].ItemArray[1].ToString());
                            string ba = flt.ToString("0.00");
                            string line3 = ba + "Y.";
                            string line4 = obj.Rows[i]["Cheq_no"].ToString();
                            decimal amnt = Convert.ToDecimal(obj.Rows[i]["Amount"].ToString().Replace(",", ""));
                            string amt = amnt.ToString("0.00");
                            string line5 = amt + obj.Rows[i]["Tran_Code"].ToString();
                            string line6 = obj.Rows[i]["Sort_Code"].ToString();
                            string line7 = "";// "YY";
                            line7 = (tempAccNo.Equals(line1)) ? "NY" : "YY";
                            if (i == obj.Rows.Count - 1)
                            {
                                line7 = "YY";
                            }
                            //string newLine = line1.PadRight(3, ' ')+""+ line2.PadRight(8, ' ') +""+line3.PadLeft(14, ' ')+""+line4.PadLeft(45, ' ')+""+line5.PadLeft(19, ' ')+""+line6.PadLeft(10, ' ')+""+line7.PadLeft(14, ' ');
                            string newLine = String.Format("{0}    {1}{2}{3}{4}{5}{6}", line1.PadRight(3, ' '), line2.PadRight(8, ' '), line3.PadLeft(14, ' '), line4.PadLeft(45, ' '), line5.PadLeft(19, ' '), line6.PadLeft(10, ' '), line7.PadLeft(14, ' '));
                            // fs.WriteLine("{0}\t{1}\r{2}\r{3}\r{4}\r{5}\r{6}", line1.PadRight(3, ' '), line2.PadRight(8, ' '), line3.PadLeft(14, ' '), line4.PadLeft(45, ' '), line5.PadLeft(19, ' '), line6.PadLeft(10, ' '), line7.PadLeft(14, ' '));
                            fs.WriteLine("{0}", newLine);
                        }
                    }
                    using (StreamReader sr = File.OpenText(basefileName))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {

                        }
                    }
                }
                catch (Exception Ex)
                {
                    //LogHelper.WriteLog(Ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); PicLoad.Visible = false;
                    return;
                }
            }

        }
        #endregion
        private void rdoupload_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoupload.Checked == true)
            {
                lblstatus.Visible = true;
                LoadUploadList("Upload Pending");
                if (gvuploadgrid.RowCount > 0)
                {
                    gvuploadgrid.Columns["Success"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    gvuploadgrid.Columns["Reject"].DefaultCellStyle.ForeColor = Color.Red;

                    gvuploadgrid.Columns["Success"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                    gvuploadgrid.Columns["Reject"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);

                    gvuploadgrid.Columns["Batch No"].ReadOnly = true;
                    gvuploadgrid.Columns["Success"].ReadOnly = true;
                    gvuploadgrid.Columns["Reject"].ReadOnly = true;
                    gvuploadgrid.Columns["Total Cheques"].ReadOnly = true;
                    gvuploadgrid.Columns["Batch Amount"].ReadOnly = true;
                    gvuploadgrid.Columns["Upload Code"].ReadOnly = true;
                }
                lblstatus.Visible = false;



            }
        }
        private void LoadUploadList(string status)
        {
            try
            {

                // btnref.Enabled = false;
                if (cmbtype.SelectedIndex > 0)
                {
                    if (cmbloc.Text != "")
                    {
                        MasterEntities.UploadBatchEntities obj = new MasterEntities.UploadBatchEntities();
                        obj.Type = cmbtype.Text.ToString();
                        obj.Location = cmbloc.Text.ToString();
                        obj.upload_Status = status;
                        LoadGriddetails(obj);
                        btnref.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show("Please Select the Location ", "CMSCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbloc.Focus();
                        btnref.Enabled = true;
                        return;

                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Upload Type", "CMSCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbtype.Focus();
                    return;

                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rdoall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoall.Checked == true)
                {
                    lblstatus.Visible = true;
                    LoadUploadList("Upload Completed");
                    if (gvuploadgrid.Rows.Count > 0)
                    {
                        gvuploadgrid.Columns["Success"].DefaultCellStyle.ForeColor = Color.DarkGreen;
                        gvuploadgrid.Columns["Reject"].DefaultCellStyle.ForeColor = Color.Red;
                        gvuploadgrid.Columns["Success"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                        gvuploadgrid.Columns["Reject"].DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                        gvuploadgrid.Columns["Batch No"].ReadOnly = true;
                        gvuploadgrid.Columns["Success"].ReadOnly = true;
                        gvuploadgrid.Columns["Reject"].ReadOnly = true;
                        gvuploadgrid.Columns["Total Cheques"].ReadOnly = true;
                        gvuploadgrid.Columns["Success Amount"].ReadOnly = true;
                        gvuploadgrid.Columns["Batch Amount"].ReadOnly = true;
                        gvuploadgrid.Columns["Upload Code"].ReadOnly = true;
                        gvuploadgrid.Columns["Upload Link"].ReadOnly = true;
                    }

                    lblstatus.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
