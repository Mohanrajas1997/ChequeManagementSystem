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
    public partial class UploadQueue : Form
    {
        public string ConditionStatus = "";
        string chq_type = "";

        public UploadQueue()
        {
            InitializeComponent();
        }
        #region Methods
        private void LoadBatchdetails(string ConditionStatus)
        {
            try
            {


                gvscanlist.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvscanlist.DataSource = null;
                InwardBusiness ObjInward = new InwardBusiness();
                dtscanning = ObjInward.GetUploadQueueDtls(ConditionStatus);
                gvscanlist.DataSource = dtscanning;

                if (gvscanlist.Columns["Batch Gid"] != null)
                {
                    gvscanlist.Columns["Batch Gid"].Visible = false;
                    gvscanlist.Columns["Upload Code"].Visible = false;
                    gvscanlist.Columns["UploadGid"].Visible = false;

                }

                for (int i = 0; i < gvscanlist.Columns.Count - 1; i++)
                {
                    gvscanlist.Columns[i].ReadOnly = true;
                }

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Back to Checker";
                btn.Text = "Back to Checker";
                btn.Name = "Checker";
                btn.UseColumnTextForButtonValue = true;
                gvscanlist.Columns.Insert(0, btn);

                DataGridViewCheckBoxColumn check_Box = new DataGridViewCheckBoxColumn();
                check_Box.HeaderText = "Select";
                check_Box.Name = "Select";
                check_Box.FalseValue = "False";
                check_Box.TrueValue = "True";
                gvscanlist.Columns.Insert(0, check_Box);

                gvscanlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReuploadDetails(string ConditionStatus)
        {
            try
            {


                gvscanlist.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvscanlist.DataSource = null;
                InwardBusiness ObjInward = new InwardBusiness();
                dtscanning = ObjInward.GetReUploadQueue(ConditionStatus);
                gvscanlist.DataSource = dtscanning;
                gvscanlist.Columns["Sl No"].Visible = false;
                gvscanlist.Columns["UploadGid"].Visible = false;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.Text = "Delete";
                btn.UseColumnTextForButtonValue = true;
                gvscanlist.Columns.Add(btn);

                DataGridViewCheckBoxColumn check_Box = new DataGridViewCheckBoxColumn();
                check_Box.HeaderText = "Select";
                check_Box.Name = "Select";
                check_Box.FalseValue = "False";
                check_Box.TrueValue = "True";
                gvscanlist.Columns.Insert(0, check_Box);

                for (int i = 1; i < gvscanlist.Columns.Count - 1; i++)
                {
                    gvscanlist.Columns[i].ReadOnly = true;
                }

                gvscanlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        #endregion

        private void BatchQueue_Load(object sender, EventArgs e)
        {
            try
            {

                DropDownLoading();
                this.WindowState = FormWindowState.Maximized;
                CancelButton = btnClose;
                btnref_Click(sender, e);

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DropDownLoading()
        {
            try
            {

                InwardBusiness objinward = new InwardBusiness();
                DataSet dslist = new DataSet();
                DataTable dtbranch = new DataTable();
                DataTable dtlocation = new DataTable();
                dslist = objinward.GetBranchLocation();

                if (dslist.Tables[0].Rows.Count > 0)
                {
                    dtbranch = dslist.Tables[0];
                }


                DataRow rows = dtbranch.NewRow();
                dtbranch.Rows.InsertAt(rows, 0);
                cmblocation.DataSource = dtbranch;
                cmblocation.DisplayMember = "Branch Name";
                cmblocation.ValueMember = "Branch Code";

                cmbtype.Items.Clear();
                cmbtype.Items.Add("CMS");
                cmbtype.Items.Add("CTS");

                cmblocation.Text = "600_Chennai";
                cmbtype.Text = "CMS";


            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gvscanlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PicLoad.Visible = true;
                if (e.RowIndex >= 0)
                {
                    if (RdoPending.Checked)
                    {
                        if (gvscanlist.Columns[e.ColumnIndex].Name == "Checker")
                        {
                            if (MessageBox.Show("Are you sure to move back to checker ?", "Move to checker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                InwardBusiness obj = new InwardBusiness();
                                string[] result = obj.MoveBatchFromUploadToMaker(Convert.ToInt32(gvscanlist.Rows[e.RowIndex].Cells["Batch Gid"].Value.ToString()));

                                if (result[1] == "1")
                                {
                                    btnref.PerformClick();
                                    MessageBox.Show(result[0], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(result[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (gvscanlist.Columns[e.ColumnIndex].Name == "Delete")
                        {
                            if (MessageBox.Show("Are you sure to delete upload ?", "Delete Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                InwardBusiness obj = new InwardBusiness();
                                string[] result = obj.DeleteUpload(Convert.ToInt32(gvscanlist.Rows[e.RowIndex].Cells["UploadGid"].Value.ToString()));

                                if (result[1] == "1")
                                {
                                    btnref.PerformClick();
                                    MessageBox.Show(result[0], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(result[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            BatchQueue_Load(sender, e);
        }

        private void gvscanlist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = gvscanlist.CurrentCell.ColumnIndex;
                    int iRow = gvscanlist.CurrentCell.RowIndex;
                    if (iColumn == gvscanlist.Columns.Count - 1)
                        gvscanlist.CurrentCell = gvscanlist[0, iRow + 1];
                    else
                        gvscanlist.CurrentCell = gvscanlist[iColumn + 1, iRow];
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnref_Click(object sender, EventArgs e)
        {
            try
            {
                string InwardFromdate = "";
                string InwardTodate = "";
                ConditionStatus = "";

                if (Inward_Fromdate.Checked == true)
                {
                    InwardFromdate = Inward_Fromdate.Value.ToString("yyyy-MM-dd");
                }
                if (Inward_Todate.Checked == true)
                {
                    InwardTodate = Inward_Todate.Value.ToString("yyyy-MM-dd");
                }

                if (cmblocation.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Please Select the Location ", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmblocation.Focus();
                    PicLoad.Visible = false;
                    btnref.Enabled = true;
                    return;
                }

                if (cmbtype.Text.ToString() == "")
                {
                    MessageBox.Show("Please select the cheque type !", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbtype.Focus();
                    PicLoad.Visible = false;
                    btnref.Enabled = true;
                    return;
                }

                string BranchCode = cmblocation.SelectedValue.ToString();
                string ChqType = cmbtype.Text.ToString();
                chq_type = ChqType;

                if (RdoPending.Checked == true)
                {
                    if (InwardFromdate != "")
                    {
                        ConditionStatus = " and a.batch_date >=" + "'" + InwardFromdate + "'";

                    }
                    if (InwardTodate != "")
                    {
                        if (ConditionStatus != "")
                        {
                            ConditionStatus += "and a.batch_date <=" + "'" + InwardTodate + "'";
                        }
                        else
                        {
                            ConditionStatus = "and a.batch_date <=" + "'" + InwardTodate + "'";
                        }
                    }
                    if (BranchCode != "")
                    {
                        if (ConditionStatus != "")
                        {
                            ConditionStatus += "and b.branch_code =" + "'" + BranchCode + "'";
                        }
                        else
                        {
                            ConditionStatus = "and b.branch_code =" + "'" + BranchCode + "'";
                        }

                    }
                    if (ChqType != "")
                    {
                        if (ConditionStatus != "")
                        {
                            ConditionStatus += "and a.chq_type =" + "'" + ChqType + "'";
                        }
                        else
                        {
                            ConditionStatus = "and a.chq_type =" + "'" + ChqType + "'";
                        }
                    }

                    if (ConditionStatus == "")
                    {
                        ConditionStatus = "All";
                    }
                    LoadBatchdetails(ConditionStatus);
                }
                else
                {
                    ConditionStatus = "";
                    if (InwardFromdate != "")
                    {
                        ConditionStatus = " and d.upload_date >=" + "'" + InwardFromdate + "'";

                    }

                    if (InwardTodate != "")
                    {
                        if (ConditionStatus != "")
                        {
                            ConditionStatus += "and d.upload_date <=" + "'" + InwardTodate + "'";
                        }
                        else
                        {
                            ConditionStatus = "and d.upload_date <=" + "'" + InwardTodate + "'";
                        }
                    }

                    if (BranchCode != "")
                    {
                        if (ConditionStatus != "")
                        {
                            ConditionStatus += "and d.branch_code =" + "'" + BranchCode + "'";
                        }
                        else
                        {
                            ConditionStatus = "and d.branch_code =" + "'" + BranchCode + "'";
                        }

                    }
                    if (ChqType != "")
                    {
                        if (ConditionStatus != "")
                        {
                            ConditionStatus += "and d.chq_type =" + "'" + ChqType + "'";
                        }
                        else
                        {
                            ConditionStatus = "and d.chq_type =" + "'" + ChqType + "'";
                        }
                    }

                    if (ConditionStatus == "")
                    {
                        ConditionStatus = "All";
                    }

                    LoadReuploadDetails(ConditionStatus);
                }


            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmbtype.Text = "";
            cmblocation.Text = "";
            gvscanlist.Columns.Clear();

        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            string batchid = "";
            string batchno = "";
            PicLoad.Visible = true;
            int UploadGid = 0;
            try
            {

                if (gvscanlist.Rows.Count == 0)
                {
                    MessageBox.Show("No Records to found!");
                    return;
                }

                List<DataGridViewRow> rows3 = new List<DataGridViewRow>(from DataGridViewRow r in gvscanlist.Rows
                                                                        where Convert.ToBoolean(r.Cells[0].Value) == true
                                                                        select r);
                if (rows3.Count == 0)
                {
                    MessageBox.Show("Please Select Atleast OneRecord In Grid");
                    PicLoad.Visible = false;
                    rows3 = null;
                    return;
                }
                if (cmbtype.Text.ToString() == "")
                {
                    MessageBox.Show("Please Select the Cheque Type ", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbtype.Focus();
                    PicLoad.Visible = false;
                    btnref.Enabled = true;
                    return;
                }
                if (cmblocation.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Please Select the Location ", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmblocation.Focus();
                    PicLoad.Visible = false;
                    btnref.Enabled = true;
                    return;
                }

                if (chq_type != cmbtype.Text.ToString())
                {
                    MessageBox.Show("Selected cheque type differs from loaded list !", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbtype.Focus();
                    PicLoad.Visible = false;
                    btnref.Enabled = true;
                    return;
                }

                var list = new List<DataGridViewRow>(rows3);

                if (RdoPending.Checked == true)
                {
                    if (rows3.Count > 0)
                    {
                        for (int j = 0; j < rows3.Count; j++)
                        {
                            if (batchid == "")
                            {
                                batchid = rows3[j].Cells["Batch Gid"].Value.ToString();
                                batchno = rows3[j].Cells["Batch No"].Value.ToString();
                            }
                            else
                            {
                                batchid = batchid + "," + rows3[j].Cells["Batch Gid"].Value.ToString();
                                batchno = batchno + "," + rows3[j].Cells["Batch No"].Value.ToString();
                            }

                        }

                    }

                    if (batchid != "")
                    {
                        string location = cmblocation.SelectedValue.ToString();
                        string chqtype = cmbtype.Text.ToString();
                        InwardBusiness objBusiness = new InwardBusiness();
                        string[] result = objBusiness.SaveUpload(batchid, location, chqtype);
                        UploadGid = Convert.ToInt32(result[1].ToString());
                    }
                }
                else
                {
                    UploadGid = Convert.ToInt32(rows3[0].Cells["UploadGid"].Value.ToString());

                }
                if (UploadGid > 0)
                {
                    UploadBusiness ObjUpload = new UploadBusiness();
                    DataTable dtChqdtls = new DataTable();
                    dtChqdtls = ObjUpload.GetSingleUploadDetails(UploadGid);

                    if (cmbtype.Text.ToString() == "CMS")
                    {
                        var batchCodeVsUpLoadCode = dtChqdtls.Rows[0]["upload_code"].ToString();
                        string upload_seq_id = dtChqdtls.Rows[0]["upload_seq_id"].ToString();
                        string uploadPath = CreateFolderForImageUpload(upload_seq_id);

                        if (uploadPath != "")
                        {
                            ImageAndXMLFileCration(upload_seq_id, uploadPath, dtChqdtls);

                        }
                        else
                        {
                            MessageBox.Show("There is some issue in folder creation");
                            PicLoad.Visible = false;
                            return;
                        }

                        string uploadpath_fx = CreateFolderForUpload(upload_seq_id) + "\\Finnaxia\\";

                        if (!System.IO.Directory.Exists(uploadpath_fx))
                        {
                            System.IO.Directory.CreateDirectory(uploadpath_fx);
                        }

                        GetFinnaxiaFile(uploadpath_fx, dtChqdtls);

                        MessageBox.Show("uploaded succesfully");
                        PicLoad.Visible = false;
                        RdoReUpload.Checked = true;
                        btnref_Click(sender, e);
                        System.Diagnostics.Process.Start("explorer.exe", uploadpath_fx);
                        return;
                    }
                    else
                    {
                        var batchCodeVsUpLoadCode = dtChqdtls.Rows[0]["upload_code"].ToString();
                        string upload_seq_id = dtChqdtls.Rows[0]["upload_seq_id"].ToString();
                        string uploadPath = CreateFolderForImageUpload(batchCodeVsUpLoadCode);

                        if (uploadPath != "")
                        {
                            ImageAndXMLFileCration(upload_seq_id, uploadPath, dtChqdtls);

                        }
                        else
                        {
                            MessageBox.Show("There is some issue in folder creation");
                            PicLoad.Visible = false;
                            return;
                        }

                        string uploadpath_fx = CreateFolderForUpload(upload_seq_id) + "\\Finacle\\";
                        if (!System.IO.Directory.Exists(uploadpath_fx))
                        {
                            System.IO.Directory.CreateDirectory(uploadpath_fx);
                        }

                        GetFinacleFile(uploadpath_fx, dtChqdtls);
                        GetFinacleFileNew(uploadpath_fx, dtChqdtls);

                        MessageBox.Show("Finacle File Uploaded Successfully");
                        PicLoad.Visible = false;
                        System.Diagnostics.Process.Start("explorer.exe", uploadpath_fx);

                        return;

                    }
                }

            }
            catch (Exception ex)
            {

                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {

            DataView dv = new DataView(i_dSourceTable);

            //getting distinct values for group column
            DataTable dtGroup = dv.ToTable(true, new string[] { "batch_gid", i_sGroupByColumn });

            //adding column for the row count
            dtGroup.Columns.Add("SumOfAmount", typeof(decimal));

            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["SumOfAmount"] = i_dSourceTable.Compute("sum(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "' and batch_gid = " + dr["batch_gid"]);
            }

            //returning grouped/counted result
            return dtGroup;
        }
        public void GetFinacleFile(string uploadpath, DataTable dt)
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

                    //ScannerBusiness data = new ScannerBusiness();
                    string batch_cde;
                    string cmbBatNo = "";

                    //for (int k = 0; k < dt.Rows.Count; k++)
                    //{
                    //    string batch_no = dt.Rows[k]["batch_no"].ToString();
                    //    cmbBatNo = cmbBatNo + "'" + batch_no + "',";
                    //    batch_cde = batch_no.Split('/')[2].ToString();
                    //}

                    //cmbBatNo = cmbBatNo.Remove(cmbBatNo.Length - 1, 1);

                    DataTable groupDT = GroupBy("acc_no", "chq_amount", dt);
                    string batch_no_data = dt.Rows[0]["upload_code"].ToString();

                    string basefileName = uploadpath + dt.Rows[0]["Finacle"].ToString();
                    //string basefileName = file;
                    //if (File.Exists(basefileName))
                    //{
                    //    File.Delete(basefileName);
                    //}
                    using (StreamWriter fs = File.CreateText(basefileName))
                    {
                        string tempAccNo = "";
                        string tempbatchgid = "";
                        string batchgid = "";

                        decimal flt;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string line1 = dt.Rows[i]["acc_no"].ToString();
                            long batch_gid = Convert.ToInt32(dt.Rows[i]["batch_gid"].ToString());
                            batchgid = dt.Rows[i]["batch_gid"].ToString();
                            tempbatchgid = (i < dt.Rows.Count - 1) ? dt.Rows[i + 1]["batch_gid"].ToString() : tempbatchgid = dt.Rows[i]["batch_gid"].ToString();

                            line1 = line1.Length == 12 ? line1 : line1.PadRight(10, ' ');
                            tempAccNo = (i < dt.Rows.Count - 1) ? dt.Rows[i + 1]["acc_no"].ToString() : tempAccNo = dt.Rows[i]["acc_no"].ToString();
                            string line2 = "INR";

                            if (dt.Rows[i]["cts_acc_type"].ToString() == "S")
                            {
                                DataRow[] dr1 = groupDT.Select(string.Format("acc_no ='{0}' and batch_gid = {1} ", line1, batch_gid));
                                flt = Convert.ToDecimal(dr1[0].ItemArray[2].ToString());
                            }
                            else
                            {
                                flt = Convert.ToDecimal(dt.Rows[i]["chq_amount"].ToString().Replace(",", ""));
                            }

                            string ba = flt.ToString("0.00");
                            string line3 = ba + "Y.";
                            string line4 = dt.Rows[i]["chq_no"].ToString();
                            decimal amnt = Convert.ToDecimal(dt.Rows[i]["chq_amount"].ToString().Replace(",", ""));
                            string amt = amnt.ToString("0.00");
                            string line5 = amt + dt.Rows[i]["tran_code"].ToString();
                            string line6 = dt.Rows[i]["micr_code"].ToString();
                            string line7 = "";// "YY";

                            if (dt.Rows[i]["cts_acc_type"].ToString() == "S")
                            {
                                line7 = (tempbatchgid.Equals(batchgid)) ? "NY" : "YY";
                                if (i == dt.Rows.Count - 1)
                                {
                                    line7 = "YY";
                                }
                            }
                            else
                            {
                                line7 = "YY";
                            }

                            //string newLine = line1.PadRight(3, ' ')+""+ line2.PadRight(8, ' ') +""+line3.PadLeft(14, ' ')+""+line4.PadLeft(45, ' ')+""+line5.PadLeft(19, ' ')+""+line6.PadLeft(10, ' ')+""+line7.PadLeft(14, ' ');
                            string newLine = String.Format("{0}    {1}{2}{3}{4}{5}{6}", line1.PadRight(3, ' '), line2.PadRight(8, ' '), line3.PadLeft(14, ' '), line4.PadLeft(45, ' '), line5.PadLeft(19, ' '), line6.PadLeft(10, ' '), line7.PadLeft(14, ' '));
                            // fs.WriteLine("{0}\t{1}\r{2}\r{3}\r{4}\r{5}\r{6}", line1.PadRight(3, ' '), line2.PadRight(8, ' '), line3.PadLeft(14, ' '), line4.PadLeft(45, ' '), line5.PadLeft(19, ' '), line6.PadLeft(10, ' '), line7.PadLeft(14, ' '));
                            fs.WriteLine("{0}", newLine);
                        }

                        fs.Close();
                    }

                    /*
                    using (StreamReader sr = File.OpenText(basefileName))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {

                        }
                    }*/
                }
                catch (Exception Ex)
                {
                    //LogHelper.WriteLog(Ex.ToString());
                    MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PicLoad.Visible = false;
                    return;
                }
            }

        }
        public void GetFinacleFileNew(string uploadpath, DataTable dt)
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

                    //ScannerBusiness data = new ScannerBusiness();
                    string batch_cde;
                    string cmbBatNo = "";
                    int totamount = 0;
                    //for (int k = 0; k < dt.Rows.Count; k++)
                    //{
                    //    string batch_no = dt.Rows[k]["batch_no"].ToString();
                    //    cmbBatNo = cmbBatNo + "'" + batch_no + "',";
                    //    batch_cde = batch_no.Split('/')[2].ToString();
                    //}

                    //cmbBatNo = cmbBatNo.Remove(cmbBatNo.Length - 1, 1);

                    DataTable groupDT = GroupBy("acc_no", "chq_amount", dt);
                    string batch_no_data = dt.Rows[0]["upload_code"].ToString();

                    string basefileName = uploadpath + dt.Rows[0]["Finaclenew"].ToString();
                    //string basefileName = file;
                    //if (File.Exists(basefileName))
                    //{
                    //    File.Delete(basefileName);
                    //}
                    using (StreamWriter fs = File.CreateText(basefileName))
                    {
                        string tempAccNo = "";
                        string tempbatchgid = "";
                        string batchgid = "";

                        decimal flt;
                        string line01 = "1" + dt.Rows[0]["Finaclenew"].ToString();
                        string line02 = "2";
                        fs.WriteLine("{0}", line01);
                        fs.WriteLine("{0}", line02);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string line1 = "4";//dt.Rows[i]["acc_no"].ToString();
                            long batch_gid = Convert.ToInt32(dt.Rows[i]["batch_gid"].ToString());
                            batchgid = dt.Rows[i]["batch_gid"].ToString();
                            tempbatchgid = (i < dt.Rows.Count - 1) ? dt.Rows[i + 1]["batch_gid"].ToString() : tempbatchgid = dt.Rows[i]["batch_gid"].ToString();

                            //line1 = line1.Length == 12 ? line1 : line1.PadRight(10, ' ');
                            tempAccNo = (i < dt.Rows.Count - 1) ? dt.Rows[i + 1]["acc_no"].ToString() : tempAccNo = dt.Rows[i]["acc_no"].ToString();
                            //string line2 = "INR";
                            string line2 = tempAccNo = dt.Rows[i]["acc_no"].ToString();
                            if (dt.Rows[i]["cts_acc_type"].ToString() == "S")
                            {
                                DataRow[] dr1 = groupDT.Select(string.Format("acc_no ='{0}' and batch_gid = {1} ", line1, batch_gid));
                                flt = Convert.ToDecimal(dr1[0].ItemArray[2].ToString());
                            }
                            else
                            {
                                flt = Convert.ToDecimal(dt.Rows[i]["chq_amount"].ToString().Replace(",", ""));
                            }

                            string ba = flt.ToString("0.00");
                            string line3 = "INR";
                            string line4 = "";
                            string line5 = "";
                            string line6 = dt.Rows[i]["chq_no"].ToString();//1000000000002200
                            //string line4 = dt.Rows[i]["chq_no"].ToString();
                            decimal amnt = Convert.ToDecimal(dt.Rows[i]["chq_amount"].ToString().Replace(",", ""));
                            string amt = amnt.ToString("0.00");
                            //string line5 = amt + dt.Rows[i]["tran_code"].ToString();
                            //string line7 = dt.Rows[i]["micr_code"].ToString();
                            string line7 = amt;
                            totamount = Convert.ToInt32(dt.Rows[i]["chq_amount"]) + totamount;
                            string line8 = "";
                            string line9 = dt.Rows[i]["micr_code"].ToString();
                            string line10 = "";
                            string line11 = dt.Rows[i]["uploaddate"].ToString() + "1106410000100000000006525";
                            string line12 = "";
                            string line13 = dt.Rows[i]["upload_date"].ToString();
                            string line14 = "OWCLG";
                            string line15 = "";
                            string line16 = "SOUTH1";
                            //----
                            string line17 = "";
                            string line18 = "CHQ";
                            string line19 = "";

                            //string line7 = "";// "YY";

                            //if (dt.Rows[i]["cts_acc_type"].ToString() == "S")
                            //{
                            //    line7 = (tempbatchgid.Equals(batchgid)) ? "NY" : "YY";
                            //    if (i == dt.Rows.Count - 1)
                            //    {
                            //        line7 = "YY";
                            //    }
                            //}
                            //else
                            //{
                            //    line7 = "YY";
                            //}

                            //string newLine = line1.PadRight(3, ' ')+""+ line2.PadRight(8, ' ') +""+line3.PadLeft(14, ' ')+""+line4.PadLeft(45, ' ')+""+line5.PadLeft(19, ' ')+""+line6.PadLeft(10, ' ')+""+line7.PadLeft(14, ' ');
                            string newLine = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}",
                                line1, line2.PadRight(35, ' '), line3.PadLeft(3, ' '), line4.PadLeft(18, ' '), line5.PadRight(30, ' '),
                                line6.PadLeft(16, '0'), line7.PadLeft(17, ' '), line8.PadLeft(5, ' '), line9.PadLeft(9, ' '),
                                line10.PadLeft(179, ' '), line11.PadLeft(33, ' '), line12.PadRight(426, ' '), line13.PadLeft(8, ' '),
                                line14.PadLeft(5, ' '), line15.PadLeft(3, ' '), line16.PadLeft(6, ' '), line17.PadLeft(2, ' '), line18.PadRight(5, ' '),
                                line19.PadLeft(5, ' '));
                            // fs.WriteLine("{0}\t{1}\r{2}\r{3}\r{4}\r{5}\r{6}", line1.PadRight(3, ' '), line2.PadRight(8, ' '), line3.PadLeft(14, ' '), line4.PadLeft(45, ' '), line5.PadLeft(19, ' '), line6.PadLeft(10, ' '), line7.PadLeft(14, ' '));
                            fs.WriteLine("{0}", newLine);
                        }
                        fs.WriteLine("{0}", "8" + dt.Rows.Count.ToString().PadLeft(7, '0'));
                        fs.WriteLine("{0}", "900000000" + totamount);
                        fs.Close();
                    }

                    /*
                    using (StreamReader sr = File.OpenText(basefileName))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {

                        }
                    }*/
                }
                catch (Exception Ex)
                {
                    //LogHelper.WriteLog(Ex.ToString());
                    MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PicLoad.Visible = false;
                    return;
                }
            }

        }
        public void GetFinnaxiaFile(string uploadpath, DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {

                    //ScannerBusiness data = new ScannerBusiness();
                    string batch_no_data = dt.Rows[0]["upload_seq_id"].ToString();
                    string batch_cde = batch_no_data;
                    string basefileName = uploadpath + dt.Rows[0]["Finnaxia"].ToString() + ".txt";

                    try
                    {
                        using (StreamWriter fs = File.CreateText(basefileName))
                        {

                            string dd = DateTime.Now.Day.ToString("d2");
                            string mm = DateTime.Now.Month.ToString("d2");
                            string yy = DateTime.Now.Year.ToString();
                            decimal Totalamt = 0;
                            fs.WriteLine("HDR~0811" + yy + mm + dd + batch_cde + "~0811~");
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                int j = i + 1;
                                DateTime value = Convert.ToDateTime(dt.Rows[i]["chq_date"].ToString());

                                string vdd = value.Day.ToString("d2");
                                string vmm = value.Month.ToString("d2");
                                string vyy = value.Year.ToString();
                                decimal amount = Convert.ToDecimal(dt.Rows[i]["chq_amount"].ToString().Replace(",", ""));
                                string sortCode = dt.Rows[i]["micr_code"].ToString();
                                string chequeamount = amount.ToString("N0");
                                string customerCode = dt.Rows[i]["customer_code"].ToString();
                                //if (customerCode != "") //Comment by Murali 23/12/2020
                                //{
                                //    customerCode = customerCode.Substring(0, customerCode.IndexOf('/'));

                                //}

                                if (cmblocation.SelectedValue.ToString() == "600")
                                {
                                    // sortCode = sortCode.Substring(0, 6) + "002"; /// Commented by Murali 03/12/2020
                                    fs.WriteLine("I~" + j + "~" + dt.Rows[i]["chq_no"] + "~" + amount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~CHEN~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["dep_slip_no"] + "~~~~~");
                                }
                                else if (cmblocation.SelectedValue.ToString() == "560")
                                {
                                    fs.WriteLine("I~" + j + "~" + dt.Rows[i]["chq_no"] + "~" + amount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~BAN~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["dep_slip_no"] + "~~~~~");
                                }
                                else if (cmblocation.SelectedValue.ToString() == "110")
                                {
                                    fs.WriteLine("I~" + j + "~" + dt.Rows[i]["chq_no"] + "~" + amount + "~" + vdd + vmm + vyy + "~" + dd + mm + yy + "~" + customerCode + "~" + dd + mm + yy + "~DEL~N~M~" + dt.Rows[i]["BANK_CODE"] + "~" + sortCode + "~~" + dt.Rows[i]["Drawee Name"] + "~~CHQ~" + dt.Rows[i]["dep_slip_no"] + "~~~~~");
                                }
                                decimal val = Convert.ToDecimal(dt.Rows[i]["chq_amount"].ToString());
                                Totalamt += val;
                            }
                            int line = Convert.ToInt32(dt.Rows.Count) + 2;
                            fs.WriteLine("TRL~" + line + "~" + Totalamt + "~");
                        }

                    }
                    catch (Exception Ex)
                    {
                        //LogHelper.WriteLog(Ex.ToString());
                        MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PicLoad.Visible = false;

                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); PicLoad.Visible = false;

                return;
            }
        }

        private string CreateFolderForImageUpload(string Upd_Code)
        {
            string returnVal = "";
            try
            {
                string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                Upd_Code = Upd_Code.Replace("-", "");
                String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                string uploadpath = "";

                PrgPath = PrgPath + "\\" + Todaysdate;

                if (!System.IO.Directory.Exists(PrgPath))
                {
                    System.IO.Directory.CreateDirectory(PrgPath);
                }

                PrgPath = PrgPath + "\\Upload";

                if (!System.IO.Directory.Exists(PrgPath))
                {
                    System.IO.Directory.CreateDirectory(PrgPath);
                }

                PrgPath = PrgPath + "\\" + Upd_Code;

                if (!System.IO.Directory.Exists(PrgPath))
                {
                    System.IO.Directory.CreateDirectory(PrgPath);
                }

                PrgPath = PrgPath + "\\Images";

                if (!System.IO.Directory.Exists(PrgPath))
                {
                    System.IO.Directory.CreateDirectory(PrgPath);
                }

                uploadpath = PrgPath;

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
                    System.IO.Directory.Delete(uploadpath, true);
                    System.IO.Directory.CreateDirectory(uploadpath);
                }
                returnVal = uploadpath;

            }
            catch (Exception ex)
            {
                returnVal = "";
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
            return returnVal;
        }

        private string CreateFolderForUpload(string Upd_Code)
        {
            string returnVal = "";
            try
            {
                string PrgPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                Upd_Code = Upd_Code.Replace("-", "");
                String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
                string uploadpath = "";

                PrgPath = PrgPath + "\\" + Todaysdate;

                if (!System.IO.Directory.Exists(PrgPath))
                {
                    System.IO.Directory.CreateDirectory(PrgPath);
                }

                PrgPath = PrgPath + "\\Upload";

                if (!System.IO.Directory.Exists(PrgPath))
                {
                    System.IO.Directory.CreateDirectory(PrgPath);
                }

                PrgPath = PrgPath + "\\" + Upd_Code;

                if (!System.IO.Directory.Exists(PrgPath))
                {
                    System.IO.Directory.CreateDirectory(PrgPath);
                }

                uploadpath = PrgPath;

                returnVal = uploadpath;
            }
            catch (Exception ex)
            {
                returnVal = "";
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
            return returnVal;
        }

        private void ImageAndXMLFileCration(string batch_no, string uploadPath, DataTable dtreturnRecord)
        {
            try
            {
                DataTable dtScanImageDtl = new DataTable();
                if (dtreturnRecord.Rows.Count > 0)
                {
                    int cc = 0;
                    string[] xmlimgfile;
                    xmlimgfile = new string[5 * dtreturnRecord.Rows.Count];

                    XmlDocument doc = new XmlDocument();

                    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                    doc.AppendChild(xmlDeclaration);

                    XmlElement element1 = CreateFileHeaderBatch(doc, batch_no);
                    doc.AppendChild(element1);
                    foreach (DataRow dtRow in dtreturnRecord.Rows)
                    {
                        cc++;

                        UploadBusiness ObjUpload = new UploadBusiness();
                        int Upload_gid = Convert.ToInt32(dtRow["Upload_gid"].ToString());
                        int Chq_gid = Convert.ToInt32(dtRow["chq_gid"].ToString());
                        dtScanImageDtl = ObjUpload.GetSinlgeScanImage(Upload_gid, Chq_gid);

                        for (int i = 0; i < dtScanImageDtl.Rows.Count; i++)
                        {
                            if (dtScanImageDtl.Rows[i]["image_side"].ToString() == "F" && dtScanImageDtl.Rows[i]["image_type"].ToString() == "B")
                            {
                                string FBImgName = dtScanImageDtl.Rows[i]["ImageName"].ToString();
                                Tiff((byte[])dtScanImageDtl.Rows[i]["image_byte"], uploadPath, FBImgName);
                                xmlimgfile[0] = FBImgName;
                            }
                            if (dtScanImageDtl.Rows[i]["image_side"].ToString() == "R" && dtScanImageDtl.Rows[i]["image_type"].ToString() == "B")
                            {
                                string RBImgName = dtScanImageDtl.Rows[i]["ImageName"].ToString();
                                Tiff((byte[])dtScanImageDtl.Rows[i]["image_byte"], uploadPath, RBImgName);
                                xmlimgfile[1] = RBImgName;
                            }
                            if (dtScanImageDtl.Rows[i]["image_side"].ToString() == "F" && dtScanImageDtl.Rows[i]["image_type"].ToString() == "U")
                            {
                                string FUImgName = dtScanImageDtl.Rows[i]["ImageName"].ToString();
                                CreateGray((byte[])dtScanImageDtl.Rows[i]["image_byte"], uploadPath, FUImgName);
                                xmlimgfile[2] = FUImgName;
                            }
                            if (dtScanImageDtl.Rows[i]["image_side"].ToString() == "F" && dtScanImageDtl.Rows[i]["image_type"].ToString() == "G")
                            {
                                string FGImgName = dtScanImageDtl.Rows[i]["ImageName"].ToString();
                                CreateGray((byte[])dtScanImageDtl.Rows[i]["image_byte"], uploadPath, FGImgName);
                                xmlimgfile[3] = FGImgName;  // TODO
                            }


                        }
                        string xmlFileName = dtScanImageDtl.Rows[0]["SingleXMLImage"].ToString();
                        CreateXmlImg(uploadPath, xmlFileName, xmlimgfile, dtRow, batch_no, cc);
                        xmlimgfile[4] = xmlFileName;
                        XmlElement element2 = CreateChildElementBatchwise(doc, xmlimgfile, batch_no, cc);
                        element1.AppendChild(element2);
                    }
                    string xmlbatchwiseFileName = dtScanImageDtl.Rows[0]["OverallXMLFile"].ToString();
                    string doneFilename = uploadPath + "\\" + dtScanImageDtl.Rows[0]["DoneFile"].ToString();
                    string url = uploadPath + "\\" + xmlbatchwiseFileName;
                    using (var writer = new XmlTextWriter(url, new UTF8Encoding(false)))
                    {
                        doc.Save(writer);
                    }
                    CreateDoneFile(doneFilename);

                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private XmlElement CreateChildElementBatchwise(XmlDocument doc, string[] imagefilename, string upload_code, int cc)
        {
            XmlElement element = doc.CreateElement("", "Item", "");
            try
            {
                element.SetAttribute("ItemSeqNo", "00466003" + upload_code + cc.ToString("000"));

                if (cmblocation.SelectedValue.ToString() == "600")
                {
                    element.SetAttribute("KioskTranId", "080320160416");
                }
                else
                {
                    element.SetAttribute("KioskTranId", "00466003" + upload_code + cc.ToString("000"));
                }

                element.SetAttribute("CXDDataFile", imagefilename[4].ToString());
                element.SetAttribute("RBFileName", imagefilename[1].ToString());
                element.SetAttribute("FUFileName", imagefilename[2].ToString());
                element.SetAttribute("FBFileName", imagefilename[0].ToString());
                element.SetAttribute("FGFileName", imagefilename[3].ToString());
                //element.SetAttribute("KioskTranId", "080320160416");
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
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
                string url = path + "\\" + Filename;
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
            string amt = Dtrow["valid_batch_amount"].ToString();
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

            string CheckAmt = string.Format("{0:0.00}", Dtrow["chq_amount"]);
            CheckAmt = CheckAmt.Replace(",", "");
            CheckAmt = CheckAmt.Replace(".", "");

            DateTime chqdate = Convert.ToDateTime(Dtrow["chq_date"]);
            string dd = chqdate.Day.ToString("00.##");
            string mm = chqdate.Month.ToString("00.##");

            string ss = DateTime.Now.Second.ToString("00.##");

            string yy = chqdate.Year.ToString();
            XmlElement element = doc.CreateElement("", "ItemDetail", "");
            try
            {
                element.SetAttribute("ItemSeqNo", "00466003" + upload_code + cc.ToString("000"));

                //element.SetAttribute("KioskTranId", "080320160416");
                if (cmblocation.SelectedValue.ToString() == "600")
                {
                    element.SetAttribute("KioskTranId", "080320160416");
                }
                else
                {
                    element.SetAttribute("KioskTranId", "00466003" + upload_code + cc.ToString("000"));
                }

                element.SetAttribute("RBFileName", imagefilename[1].ToString());
                element.SetAttribute("FUFileName", imagefilename[2].ToString());  // TODO
                element.SetAttribute("FBFileName", imagefilename[0].ToString()); // TODO
                element.SetAttribute("FGFileName", imagefilename[3].ToString());

                element.SetAttribute("MICRSerialNo", Dtrow["chq_no"].ToString());
                string sort = Dtrow["micr_code"].ToString();
                sort = cmblocation.SelectedValue + sort.Substring(3);
                element.SetAttribute("MICRPayorBankRoutNo", sort);
                element.SetAttribute("MICRAccountNo", Dtrow["base_code"].ToString());
                element.SetAttribute("MICRTransCode", Dtrow["tran_code"].ToString());
                element.SetAttribute("MiCRAmount", CheckAmt);
                element.SetAttribute("DepositorAcct", "826LIABICMSCLINR");

                if (cmbtype.Text == "CMS")
                {
                    string customer = Regex.Replace(Dtrow["customer_name"].ToString(), "&", "AND");
                    //customer = customer.Split('/')[1];
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
                    // string depositorname= Dtrow["Drawee Name"].ToString().Replace("&","AND");
                    string depositorname = Regex.Replace(Dtrow["Drawee Name"].ToString(), "&", "AND");
                    element.SetAttribute("DepositorName", depositorname);
                }

                element.SetAttribute("DraweeDetail", "DRAWEE NAME");
                element.SetAttribute("Status", "PENDING");
                element.SetAttribute("DocType", "B");
                element.SetAttribute("ChDate", dd + mm + yy); // TODO
                element.SetAttribute("BentLeftTopPix", "2");
                element.SetAttribute("BentLeftBottomPix", "2");
                element.SetAttribute("BentRightBottomPix", "2");
                element.SetAttribute("BentRightTopPix", "2");
                element.SetAttribute("PartialImage", "2");
                element.SetAttribute("LightOrDark", "2");
                element.SetAttribute("BelowMinimumImageSize", "2");
                element.SetAttribute("ExceedsMaximumImageSize", "2");
                element.SetAttribute("ImageQuality", "2");
                element.SetAttribute("ImageUsability", "2");
                element.SetAttribute("IQAIgnoreInd", "0");
                element.SetAttribute("PctBlackBits", "2");
                element.SetAttribute("DocSizeInTenths", "2");
                element.SetAttribute("Skew", "2");
                element.SetAttribute("UVstatus", "2");
                element.SetAttribute("CTSstatus", "2");
                element.SetAttribute("MobileNo", "9845098450");
                element.SetAttribute("MailID", "emial@email.com");
                element.SetAttribute("GovtStatus", "0");
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
        }
        public static string DoFormat(double myNumber)
        {
            return string.Format("{0:0.00}", myNumber).Replace(".00", "");
        }
        private XmlElement CreateFileHeader(XmlDocument doc, DataRow Dtrow, string batch_no)
        {
            string dd = DateTime.Now.Day.ToString("d2");
            string mm = DateTime.Now.Month.ToString("d2");
            string yy = DateTime.Now.Year.ToString();

            string hh = DateTime.Now.Hour.ToString("00.##");
            string min = DateTime.Now.Minute.ToString("00.##");
            string ss = DateTime.Now.Second.ToString("00.##");
            XmlElement element = doc.CreateElement("FileHeader");
            element.SetAttribute("xmlns", "FTL:OUTCL:CXD:FileStructure:010001");

            if (cmblocation.SelectedValue.ToString() == "600")
            {
                element.SetAttribute("KioskName", "FTL00000" + cmblocation.SelectedValue + "12001");
            }
            else
            {
                element.SetAttribute("KioskName", "FTL00000" + cmblocation.SelectedValue + "11001");
            }

            element.SetAttribute("CreationTime", hh + min + ss);         // Get the Time and assign
            element.SetAttribute("PresentmentDate", dd + mm + yy);    // Get the Date 
            element.SetAttribute("BatchID", batch_no);                 // Need pass the Batch through Parameter           
            element.SetAttribute("UVAvailable", "Yes");
            element.SetAttribute("Encrypt", "No");
            element.SetAttribute("SolId", "0001");
            element.SetAttribute("DLLVersion", "01.03.11.15");
            //element.SetAttribute("KioskName", "FTL0000060012001");  // Need to pass tskName -- Commented By Sheeba For Location Code Applied
            //element.SetAttribute("KioskName", "FTL00000" + cmbloc.SelectedValue + "12001");

            return element;
        }
        public void CreateGray(byte[] imageBytes, string path, string Filename)
        {

            string getpath = path;
            string getfilename = Filename;
            try
            {
                //creating byte array
                //byte[] imageBytes = Convert.FromBase64String(base64String);

                string fillpath = path + "\\" + getfilename;
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {

                    Downscale(imageBytes, Filename, path);
                }

            }
            catch (Exception Ex)
            {
                //LogHelper.WriteLog(Ex.ToString());
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static int Downscale(byte[] imgBits, string fileName, string path)
        {
            int pageCount = -1;
            {

                //string filenameext1 = path + "\\" + fileName + "_grey.jpg";
                string filenameext1 = path + "\\" + fileName;
                //string path = "D:\\Test\\Test.jpg";
                using (MemoryStream ms = new MemoryStream(imgBits))
                {
                    GrayGenerateThumbnails(0.1, ms, filenameext1);
                    //EnhanceGenerateThumbnails(15.5, ms, path2);
                }
            }

            return pageCount;
        }
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
        public void Tiff(byte[] imgBits, string path, string Filename)
        {
            if (imgBits != null)
            {
                //using (MemoryStream ms = new MemoryStream(imgBits))
                {
                    //byte[] imgBits = Convert.FromBase64String(base64String);
                    string getfilename = Filename;
                    string fillpath = path + "\\" + getfilename;
                    //string filenameext1 = Filename + ".tif";
                    using (MemoryStream ms1 = new MemoryStream(imgBits))
                    {
                        GenerateThumbnails(0.1, ms1, fillpath);
                    }
                }
            }
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
        private XmlElement CreateFileHeaderBatch(XmlDocument doc, string batch_no)
        {
            XmlElement element = doc.CreateElement("FileHeader");
            try
            {
                string dd = DateTime.Now.Day.ToString("d2");
                string mm = DateTime.Now.Month.ToString("d2");
                string yy = DateTime.Now.Year.ToString();

                string hh = DateTime.Now.Hour.ToString("00.##");
                string min = DateTime.Now.Minute.ToString("00.##");
                string ss = DateTime.Now.Second.ToString("00.##");

                //element.SetAttribute("KioskName", "FTL0000060012001");
                element.SetAttribute("xmlns", "FTL:OUTCL:CXD:FileStructure:010001");
                if (cmblocation.SelectedValue.ToString() == "600")
                {
                    element.SetAttribute("KioskName", "FTL00000" + cmblocation.SelectedValue + "12001");
                }
                else
                {
                    element.SetAttribute("KioskName", "FTL00000" + cmblocation.SelectedValue + "11001");
                }
                element.SetAttribute("CreationTime", hh + min + ss);
                element.SetAttribute("PresentmentDate", dd + mm + yy);
                //element.SetAttribute("BatchID", batch_no.Remove(0, 1));                 // Need pass the Batch through Parameter           
                element.SetAttribute("BatchID", batch_no);
                element.SetAttribute("UVAvailable", "Yes");    // Get the Date 
                element.SetAttribute("Encrypt", "No");         // Get the Time and assign
                element.SetAttribute("SolId", "0001");  // Need to pass the KioskName
                element.SetAttribute("DLLVersion", "01.03.11.15");    // Get the Date   
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return element;
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

        private void RdoPending_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnref_Click(sender, e);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdoReUpload_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnref_Click(sender, e);

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
