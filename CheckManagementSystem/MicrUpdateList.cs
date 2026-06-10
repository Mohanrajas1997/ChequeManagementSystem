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
    public partial class MicrUpdateList : Form
    {
        public string ConditionStatus = "";

        public MicrUpdateList()
        {
            InitializeComponent();
        }
        #region Methods

        private void LoadMicrList(string ConditionStatus)
        {
            try
            {


                gvscanlist.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvscanlist.DataSource = null;
                InwardBusiness ObjInward = new InwardBusiness();
                dtscanning = ObjInward.GetRejectionDetails(ConditionStatus);
                gvscanlist.DataSource = dtscanning;
                if (gvscanlist.Columns["Batch Gid"] != null)
                {
                    gvscanlist.Columns["Batch Gid"].Visible = false;
                    gvscanlist.Columns["Chq Gid"].Visible = false;
                    gvscanlist.Columns["Chq No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvscanlist.Columns["Chq Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvscanlist.Columns["Acc No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dtscanning.Rows.Count > 0)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.Text = "Rejection";
                    col.Name = "Action";
                    gvscanlist.Columns.Add(col);



                }
                else
                {
                    MessageBox.Show("No Cheque List Available", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BatchQueue_Load(object sender, EventArgs e)
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
                cmbbrcode.DataSource = dtbranch;
                cmbbrcode.DisplayMember = "LOCATION_CODE";
                cmbbrcode.ValueMember = "LOCATION_CODE";

                DataRow dr = dtlocation.NewRow();
                dr["LOCATION_CODE"] = "--Select--";
                dtlocation.Rows.InsertAt(dr, 0);

                cmblocation.DataSource = dtlocation;
                cmblocation.DisplayMember = "LOCATION_CODE";
                cmblocation.ValueMember = "LOCATION_CODE";
                ConditionStatus = "All";
                //LoadMicrList(ConditionStatus);
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
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Action")
                {

                    int col = gvscanlist.CurrentCell.ColumnIndex;
                    int row = gvscanlist.CurrentCell.RowIndex;
                    int Batchgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Batch Gid"].Value);
                    int ChqGid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Chq Gid"].Value);

                    Rejection objcheck = new Rejection(Batchgid, ChqGid);
                    //objcheck.MdiParent = ScanChq.ActiveForm;
                    //objcheck.Dock = DockStyle.Fill;
                    objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is Rejection)
                        {
                            f.Close();
                            return;
                        }
                    }
                    objcheck.StartPosition = FormStartPosition.CenterParent;
                    objcheck.ShowDialog();
                }
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Revoke")
                {
                    int col = gvscanlist.CurrentCell.ColumnIndex;
                    int row = gvscanlist.CurrentCell.RowIndex;
                    int Batchgid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Batch Gid"].Value);
                    int ChqGid = Convert.ToInt32(gvscanlist.Rows[row].Cells["Chq Gid"].Value);
                    int discreasongid = Convert.ToInt32(gvscanlist.Rows[row].Cells["discreason_gid"].Value);
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to revoke the record?", "", MessageBoxButtons.YesNo))
                    {
                        InwardBusiness objBusiness = new InwardBusiness();
                        
                        string EntryFlag = "Revoke";
                        string[] result = objBusiness.SaveRejectionEntry(Batchgid, ChqGid, discreasongid, EntryFlag);
                        MessageBox.Show(result[0].ToString());                       

                            btnref_Click(sender, e);

                        
                    }
                    else
                    {
                        btnref_Click(sender, e);
                    }

                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnref_Click(sender,e);
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

                if (Batch_Fromdate.Checked == true && Batch_Todate.Checked == true)
                {
                    InwardFromdate = Batch_Fromdate.Value.ToString("yyyy-MM-dd");
                    InwardTodate = Batch_Todate.Value.ToString("yyyy-MM-dd");

                }

                string BranchCode = "";
                string LocationCode = "";

                string lotno = LotNo_Txt.Text;
                string ChqNo = chqno_txt.Text;

                if (cmbbrcode.SelectedIndex != -1) BranchCode = cmbbrcode.SelectedValue.ToString();
                if (cmblocation.SelectedIndex != -1) LocationCode = cmblocation.SelectedValue.ToString();

                if (InwardFromdate != "" && InwardTodate != "")
                {
                    ConditionStatus = " and a.insert_date >=" + "'" + InwardFromdate + "' and a.insert_date <=" + "'" + InwardTodate + "'";

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
                if (LocationCode != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and d.pickup_location =" + "'" + LocationCode + "'";
                    }
                    else
                    {
                        ConditionStatus = "and d.pickup_location =" + "'" + LocationCode + "'";
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
                if (ChqNo != "")
                {
                    if (ConditionStatus != "")
                    {
                        ConditionStatus += "and b.chq_no =" + "'" + ChqNo + "'";
                    }
                    else
                    {
                        ConditionStatus = "and b.chq_no =" + "'" + ChqNo + "'";
                    }
                }

                if (ConditionStatus == "")
                {
                    ConditionStatus = "All";
                }

                //LoadBatchdetails(ConditionStatus);
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
            chqno_txt.Text = "";
        }

        private void rdoRejection_CheckedChanged(object sender, EventArgs e)
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

        private void rdoRevoke_CheckedChanged(object sender, EventArgs e)
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

        private void btncls_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
