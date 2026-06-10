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
    public partial class MakerQueue : Form
    {
        public string ConditionStatus = "";

        public MakerQueue()
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
                dtscanning = ObjInward.GetMakerDetails(ConditionStatus);
                gvscanlist.DataSource = dtscanning;
                if (gvscanlist.Columns["Batch Gid"] != null)
                {
                    gvscanlist.Columns["Batch Gid"].Visible = false;
                    gvscanlist.Columns["Customer Name"].Visible = false;
                    gvscanlist.Columns["Batch Amount"].Visible = false;
                    gvscanlist.Columns["Cheque Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                if (dtscanning.Rows.Count > 0)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.Text = "Checker";
                    col.Name = "Action";
                    gvscanlist.Columns.Add(col);

                    col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.HeaderText = "CTS Entry";
                    col.Text = "CTS Entry";
                    col.Name = "CTS Entry";
                    gvscanlist.Columns.Add(col);
                }
                else
                {
                    MessageBox.Show("No Maker List Available for Checker Validation", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void MakerQueue_Load(object sender, EventArgs e)
        {
            try
            {

                string InwardFromdate = "";
                string InwardTodate = "";
                ConditionStatus = "";

                DropDownLoading();

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
                        ConditionStatus += "and a.batch_date <=" + "'" + InwardTodate + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.batch_date <=" + "'" + InwardTodate + "'";
                    }
                }

                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }

                LoadBatchdetails(ConditionStatus);

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

                if (dslist.Tables[1].Rows.Count > 0)
                {
                    dtlocation = dslist.Tables[1];
                }

                DataRow dr = dtlocation.NewRow();
                dr["LOCATION_CODE"] = "--Select--";
                dtlocation.Rows.InsertAt(dr, 0);


                cmblocation.DataSource = dtlocation;
                cmblocation.DisplayMember = "LOCATION_CODE";
                cmblocation.ValueMember = "LOCATION_CODE";

                cmb_chq_type.Items.Clear();
                cmb_chq_type.Items.Add("CMS");
                cmb_chq_type.Items.Add("CTS");
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

                if (e.RowIndex < 0) return;

                int col = gvscanlist.CurrentCell.ColumnIndex;
                int row = gvscanlist.CurrentCell.RowIndex;

                int Batchgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Batch Gid"].Value);
                string BatchDate = gvscanlist.Rows[row].Cells["Batch Date"].Value.ToString();
                string BatchNo = gvscanlist.Rows[row].Cells["Batch No"].Value.ToString();
                string ChequeType = gvscanlist.Rows[row].Cells["Cheque Type"].Value.ToString();
                string CtsAccType = gvscanlist.Rows[row].Cells["CTS A/C Type"].Value.ToString();
                string DepositSlipNo = gvscanlist.Rows[row].Cells["Deposit Slip No"].Value.ToString();
                string Pickuplocation = gvscanlist.Rows[row].Cells["Pickup Location"].Value.ToString();
                int ChequeCount = Convert.ToInt32(gvscanlist.Rows[row].Cells["Cheque Count"].Value);
                string CustomerName = gvscanlist.Rows[row].Cells["Customer Name"].Value.ToString();
                double batchamount = Convert.ToDouble(gvscanlist.Rows[row].Cells["Batch Amount"].Value.ToString());

                if (gvscanlist.Columns[e.ColumnIndex].Name == "Action")
                {
                    CheckerScreen objcheck = new CheckerScreen(Batchgid, BatchDate, BatchNo, ChequeType, CtsAccType, DepositSlipNo, Pickuplocation, ChequeCount, CustomerName, batchamount);
                    //objcheck.MdiParent = CheckerScreen.ActiveForm;
                    //objcheck.Dock = DockStyle.Fill;
                    objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is CheckerScreen)
                        {
                            f.Close();
                            return;
                        }
                    }
                    objcheck.StartPosition = FormStartPosition.CenterParent;
                    objcheck.ShowDialog();
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
            MakerQueue_Load(sender, e);
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

                string chqType = cmb_chq_type.Text;
                string LocationCode = cmblocation.SelectedValue.ToString();
                string BatchNo = LotNo_Txt.Text;

                if (!(cmblocation.SelectedIndex > 0)) LocationCode = "";

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
                if (chqType != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.chq_type =" + "'" + chqType + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.chq_type =" + "'" + chqType + "'";
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
                if (BatchNo != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and a.batch_no =" + "'" + BatchNo + "'";
                    }
                    else
                    {
                        ConditionStatus = "and a.batch_no =" + "'" + BatchNo + "'";
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
            cmb_chq_type.Text = "";
            cmblocation.Text = "";
        }

        private void gvscanlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
