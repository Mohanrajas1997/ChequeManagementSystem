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
    public partial class InwardQueue : Form
    {
        public string ConditionStatus = "";

        public InwardQueue()
        {
            InitializeComponent();
        }
        #region Methods
        private void LoadInwarddetails(string ConditionStatus)
        {
            try
            {


                gvscanlist.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvscanlist.DataSource = null;
                InwardBusiness ObjInward = new InwardBusiness();
                dtscanning = ObjInward.GetInwardDetails(ConditionStatus);
                gvscanlist.DataSource = dtscanning;
                if (gvscanlist.Columns["Inward ID"] != null)
                {
                    gvscanlist.Columns["Inward ID"].Visible = false;
                    gvscanlist.Columns["Inward Remarks"].Visible = false;
                    gvscanlist.Columns["Cheque Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvscanlist.Columns["Batched Cheque Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                if (dtscanning.Rows.Count > 0)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.Text = "Batch";
                    col.Name = "Batch";
                    gvscanlist.Columns.Add(col);

                    DataGridViewButtonColumn col1 = new DataGridViewButtonColumn();
                    col1.UseColumnTextForButtonValue = true;
                    col1.Text = "Edit";
                    col1.Name = "Edit";
                    gvscanlist.Columns.Add(col1);

                    DataGridViewButtonColumn col2 = new DataGridViewButtonColumn();
                    col2.UseColumnTextForButtonValue = true;
                    col2.Text = "Delete";
                    col2.Name = "Delete";
                    gvscanlist.Columns.Add(col2);

                }
                else
                {
                    MessageBox.Show("No Inward List Available for Batching Validation", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                gvscanlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void InwardQueue_Load(object sender, EventArgs e)
        {
            try
            {
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
                    ConditionStatus = " and a.inward_date >=" + "'" + InwardFromdate + "'";
                }

                if (InwardTodate != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.inward_date <=" + "'" + InwardTodate + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.inward_date <=" + "'" + InwardTodate + "'";
                    }
                }

                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }                
                LoadInwarddetails(ConditionStatus);
                this.WindowState = FormWindowState.Maximized;
                CancelButton = btnClose;
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
                if (gvscanlist.Rows.Count == 0) return;

                PicLoad.Visible = true;
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Batch")
                {

                    int col = gvscanlist.CurrentCell.ColumnIndex;
                    int row = gvscanlist.CurrentCell.RowIndex;
                    int inwardgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Inward Id"].Value);
                    string InwardDate = gvscanlist.Rows[row].Cells["Inward Date"].Value.ToString();
                    string BranchName = gvscanlist.Rows[row].Cells["Branch code /Name"].Value.ToString();
                    string PickupLocation = gvscanlist.Rows[row].Cells["Pickup Location"].Value.ToString();
                    int ChqCount = Convert.ToInt32(gvscanlist.Rows[row].Cells["Cheque Count"].Value);
                    string Remarks = gvscanlist.Rows[row].Cells["Inward Remarks"].Value.ToString();
                    int BatchedChq = Convert.ToInt32(gvscanlist.Rows[row].Cells["Batched Cheque Count"].Value);

                    BatchEntry objcheck = new BatchEntry(inwardgid, InwardDate, BranchName, PickupLocation, ChqCount, BatchedChq, Remarks);
                    // objcheck.MdiParent = InwardQueue.ActiveForm;
                    //objcheck.Dock = DockStyle.Fill;
                    objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is BatchEntry)
                        {
                            f.Close();
                            return;
                        }
                    }
                    objcheck.StartPosition = FormStartPosition.CenterParent;
                    objcheck.ShowDialog();
                }
                if (gvscanlist.Rows.Count == 0) return;
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int col = gvscanlist.CurrentCell.ColumnIndex;
                    int row = gvscanlist.CurrentCell.RowIndex;

                    int inwardgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Inward Id"].Value);

                    Inward objcheck = new Inward(inwardgid);
                    // objcheck.MdiParent = InwardQueue.ActiveForm;
                    //objcheck.Dock = DockStyle.Fill;
                    objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is Inward)
                        {
                            f.Close();
                            return;
                        }
                    }
                    objcheck.StartPosition = FormStartPosition.CenterParent;
                    objcheck.ShowDialog();
                }
                if (gvscanlist.Rows.Count == 0) return;
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the record?", "", MessageBoxButtons.YesNo))
                    {

                        int col = gvscanlist.CurrentCell.ColumnIndex;
                        int row = gvscanlist.CurrentCell.RowIndex;

                        InwardEntites objInward = new InwardEntites();
                        objInward.inward_gid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Inward Id"].Value);
                        objInward.lot_no = gvscanlist.Rows[row].Cells["Lot No"].Value.ToString();
                        objInward.cheque_count = gvscanlist.Rows[row].Cells["Cheque Count"].Value.ToString();
                        objInward.created_by = "";
                        objInward.action = "Delete";

                        InwardBusiness objBusiness = new InwardBusiness();
                        string[] result = objBusiness.SaveInward(objInward);
                        objInward.msg = result[0].ToString();
                        MessageBox.Show(result[0].ToString());
                        InwardQueue_Load(sender, e);
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
            InwardQueue_Load(sender, e);
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

                if (Inward_Todate.Checked == true)
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
                    ConditionStatus = " and a.inward_date >=" + "'" + InwardFromdate + "'";
                }

                if (InwardTodate != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.inward_date <=" + "'" + InwardTodate + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.inward_date <=" + "'" + InwardTodate + "'";
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
                        ConditionStatus += "and a.pickup_location =" + "'" + LocationCode + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.pickup_location =" + "'" + LocationCode + "'";
                    }
                }
                if (lotno != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.lot_no =" + "'" + lotno + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.lot_no =" + "'" + lotno + "'";
                    }
                }

                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }

                LoadInwarddetails(ConditionStatus);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LotNo_Txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
