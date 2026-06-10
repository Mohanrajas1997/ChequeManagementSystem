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
    public partial class CMSMaker : Form
    {
        #region Constructor
        public CMSMaker()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        private void Loadscanningdetails()
        {
            gvscanlist.Columns.Clear();
            DataTable dtscanning = new DataTable();
            gvscanlist.DataSource = null;
            ScannerBusiness objscanning = new ScannerBusiness();
            dtscanning = objscanning.GetScanningDetails();
            gvscanlist.DataSource = dtscanning;
            if (dtscanning.Rows.Count > 0)
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Maker";
                col.Name = "Maker";
                gvscanlist.Columns.Add(col);
                gvscanlist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gvscanlist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            else
            {
                MessageBox.Show("No Scanned List Available for Maker Validation","Check Management System", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        #endregion
        private void CMSMaker_Load(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Load Maker List....");
            try
            {
                Loadscanningdetails();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TheamClass.SetTheam(this);
        }
        private void gvscanlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Maker")
                {
                    PicLoad.Visible = true;
                    int col = gvscanlist.CurrentCell.ColumnIndex;
                    int row = gvscanlist.CurrentCell.RowIndex;
                    string batch_number = gvscanlist.Rows[row].Cells["Batch No"].Value.ToString();
                    string check_cont = gvscanlist.Rows[row].Cells["Cheque Count"].Value.ToString();
                    string batch_Amt = gvscanlist.Rows[row].Cells["Batch Amount"].Value.ToString();
                    string dep_slip_no = gvscanlist.Rows[row].Cells["Batch Deposit Slip No"].Value.ToString();
                    string customer_code = gvscanlist.Rows[row].Cells["Customer Code"].Value.ToString();
                    string inward_type = gvscanlist.Rows[row].Cells["Inward Type"].Value.ToString();
                    MakerValidation objcheck = new MakerValidation(batch_number, check_cont, batch_Amt, dep_slip_no, customer_code, inward_type);
                    objcheck.MdiParent = CMSMaker.ActiveForm;
                    objcheck.Dock = DockStyle.Fill;
                    objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is MakerValidation)
                        {
                            f.Close();
                            return;
                        }
                    }
                    PicLoad.Visible = false;
                    objcheck.Show();
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
            Loadscanningdetails();
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

    }
}
