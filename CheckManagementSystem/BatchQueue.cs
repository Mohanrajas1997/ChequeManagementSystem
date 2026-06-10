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
    public partial class BatchQueue : Form
    {
       public string ConditionStatus = "";

        public BatchQueue()
        {
            InitializeComponent();
        }
      
        private void LoadBatchdetails(string ConditionStatus)
        {
            try
            {


                gvscanlist.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvscanlist.DataSource = null;
                InwardBusiness ObjInward = new InwardBusiness();
                dtscanning = ObjInward.GetBatchDetails(ConditionStatus);
                gvscanlist.DataSource = dtscanning;               

                if (gvscanlist.Columns["Batch Gid"] != null)
                {
                    gvscanlist.Columns["Batch No"].Width = 150;
                    gvscanlist.Columns["Batch Gid"].Visible = false;
                    gvscanlist.Columns["branch_code"].Visible = false;
                    gvscanlist.Columns["inward_gid"].Visible = false;
                    gvscanlist.Columns["Cheque Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;                  

                }
                if (dtscanning.Rows.Count > 0)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.HeaderText = "Scan";
                    col.Text = "Scan";
                    col.Name = "Scan";
                    gvscanlist.Columns.Add(col);

                    col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.HeaderText = "CTS Entry";
                    col.Text = "CTS Entry";
                    col.Name = "CTS Entry";
                    gvscanlist.Columns.Add(col);

                    col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.HeaderText = "Delete";
                    col.Text = "Delete";
                    col.Name = "Delete";
                    gvscanlist.Columns.Add(col);
                 

                }
                else
                {
                    MessageBox.Show("No Batch List Available for Scanning Validation", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                gvscanlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void BatchQueue_Load(object sender, EventArgs e)
        {
            try
            {
                CancelButton = btnClose;
                DropDownLoading();

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

                if (InwardFromdate != "")
                {
                    ConditionStatus = " and a.batch_date >=" + "'" + InwardFromdate + "'";

                }

                if (InwardTodate != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.batch_date<=" + "'" + InwardTodate + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.batch_date<=" + "'" + InwardTodate + "'";
                    }
                }
                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }
               
                LoadBatchdetails(ConditionStatus);
                this.WindowState = FormWindowState.Maximized;
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
                if (dslist.Tables[1].Rows.Count > 0)
                {
                    dtlocation = dslist.Tables[1];
                }

                DataRow rows = dtbranch.NewRow();
                rows["Branch Name"] = "--Select--";
                dtbranch.Rows.InsertAt(rows, 0);

                DataRow dr = dtlocation.NewRow();
                dr["LOCATION_CODE"] = "--Select--";
                dtlocation.Rows.InsertAt(dr, 0);
                cmbbrcode.DataSource = dtbranch;
                cmbbrcode.DisplayMember = "Branch Name";
                cmbbrcode.ValueMember = "Branch Code";

                cmblocation.DataSource = dtlocation;
                cmblocation.DisplayMember = "LOCATION_CODE";
                cmblocation.ValueMember = "LOCATION_CODE";
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
                if (e.RowIndex < 0) return;

                PicLoad.Visible = true;
                int col = gvscanlist.CurrentCell.ColumnIndex;
                int row = gvscanlist.CurrentCell.RowIndex;
                int Batchgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Batch Gid"].Value);
                string ChequeType = gvscanlist.Rows[row].Cells["Cheque Type"].Value.ToString();
                string CtsAccType = gvscanlist.Rows[row].Cells["CTS A/C Type"].Value.ToString();
                string CtsAccNo = gvscanlist.Rows[row].Cells["CTS A/C No"].Value.ToString();

                if (gvscanlist.Columns[e.ColumnIndex].Name == "Scan")
                {

                    string branch_code = gvscanlist.Rows[row].Cells["branch_code"].Value.ToString();
                    string BatchDate = gvscanlist.Rows[row].Cells["Batch Date"].Value.ToString();
                    string BatchNo = gvscanlist.Rows[row].Cells["Batch No"].Value.ToString();
                    string CtsAccHolder = gvscanlist.Rows[row].Cells["CTS A/C Holder"].Value.ToString();
                    string DepositSlipNo = gvscanlist.Rows[row].Cells["Deposit Slip No"].Value.ToString();
                    string Pickuplocation = gvscanlist.Rows[row].Cells["Pickup Location"].Value.ToString();
                    int ChequeCount = Convert.ToInt32(gvscanlist.Rows[row].Cells["Cheque Count"].Value);
                    string CustomerName = gvscanlist.Rows[row].Cells["Customer Name"].Value.ToString();
                    double batchamount = Convert.ToDouble(gvscanlist.Rows[row].Cells["Batch Amount"].Value.ToString());

                    if (ChequeType == "CMS")
                    {
                        ScanChq objcheck = new ScanChq(Batchgid, branch_code, BatchDate, BatchNo, ChequeType, DepositSlipNo, Pickuplocation, ChequeCount, CustomerName, batchamount);
                        objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                        objcheck.StartPosition = FormStartPosition.CenterParent;
                        objcheck.ShowDialog();
                    }
                    else
                    {
                        ScanCtsChq objcheck = new ScanCtsChq(Batchgid, branch_code, BatchDate, BatchNo, ChequeType, CtsAccType, DepositSlipNo, CtsAccNo,CtsAccHolder, Pickuplocation, ChequeCount, batchamount);
                        objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                        objcheck.StartPosition = FormStartPosition.CenterParent;
                        objcheck.ShowDialog();
                    }
                }
                if (e.RowIndex < 0) return;
                if (gvscanlist.Columns[e.ColumnIndex].Name == "CTS Entry" && ChequeType == "CTS")
                {
                    if (CtsAccType == "S")
                    {
                        CtsSingleChqEntryNew obj = new CtsSingleChqEntryNew(Batchgid);
                        obj.ShowDialog();
                    }
                    else if (CtsAccType == "M")
                    {
                        CtsMultipleChqEntryNew obj = new CtsMultipleChqEntryNew(Batchgid);
                        obj.ShowDialog();
                    }
                }
                if (e.RowIndex < 0) return;
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the record?", "", MessageBoxButtons.YesNo))
                    {
                        int Inwardgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["inward_gid"].Value);
                        BatchEntryEntities ObjBatchEntity = new BatchEntryEntities();
                        ObjBatchEntity.BatchGid = Batchgid;
                        ObjBatchEntity.BatchNo = "";
                        ObjBatchEntity.ChqType = ChequeType;
                        ObjBatchEntity.CtsAccType = CtsAccType;
                        ObjBatchEntity.CtsSingleAccNo = CtsAccNo;
                        ObjBatchEntity.CustomerCode = "";
                        ObjBatchEntity.DepositSlipNo = "";
                        ObjBatchEntity.TotalChqCount = 0;
                        ObjBatchEntity.TotalBatchAmount = 0;
                        ObjBatchEntity.InwardGid = Inwardgid;
                        ObjBatchEntity.created_by = "";
                        ObjBatchEntity.action = "Delete";

                        BatchEntryBusiness objBusiness = new BatchEntryBusiness();
                        string[] result = objBusiness.SaveBatchEntry(ObjBatchEntity);
                        ObjBatchEntity.msg = result[0].ToString();

                        MessageBox.Show(ObjBatchEntity.msg);
                        if (result[1].ToString() == "1")
                        {
                            btnref.PerformClick();
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
            BatchQueue_Load(sender,e);
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

        private void label1_Click(object sender, EventArgs e)
        {

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
                if(Inward_Todate.Checked == true)
                {
                    InwardTodate = Inward_Todate.Value.ToString("yyyy-MM-dd");
                }

                string BranchCode = cmbbrcode.SelectedValue.ToString();
                string LocationCode = cmblocation.SelectedValue.ToString();
                string lotno = LotNo_Txt.Text;

                if (!(cmbbrcode.SelectedIndex > 0)) BranchCode = "";
                if (!(cmblocation.SelectedIndex > 0)) LocationCode = "";

                if (InwardFromdate != "")
                {
                    ConditionStatus = " and a.batch_date >=" + "'" + InwardFromdate + "'";

                }

                if (InwardTodate !="")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.batch_date<=" + "'" + InwardTodate + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.batch_date<=" + "'" + InwardTodate + "'";
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
                if (LocationCode != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and b.pickup_location =" + "'" + LocationCode + "'";
                    }
                    else
                    {
                        ConditionStatus = "and b.pickup_location =" + "'" + LocationCode + "'";
                    }
                }
                if (lotno != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.batch_no =" + "'" + lotno + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.batch_no =" + "'" + lotno + "'";
                    }
                }

                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }

                LoadBatchdetails(ConditionStatus);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LotNo_Txt.Text = "";
            cmbbrcode.Text = "";
            cmblocation.Text = "";
            DropDownLoading();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvscanlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
