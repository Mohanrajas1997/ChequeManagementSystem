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
    public partial class Checker : Form
    {
        public int previousSelectedRow = -1;
        public int currectSelectedRow = -1;
        //Text disable info
        //public void Disable()
        //{
        //    txtbthno.Enabled = false;
        //    txtchqcnt.Enabled = false;
        //    txtbthamt.Enabled = false;
        //    txtslpno.Enabled = false;
        //    txtcusname.Enabled = false;
        //    txtchqno.Enabled = false;
        //    txtsrtcd.Enabled = false;
        //    txtbscd.Enabled = false;
        //    txttrncd.Enabled = false;
        //    txtscncnt.Enabled = false;
        //    txtdiff.Enabled = false;
        //}
        //Validation Info
        //public bool ScanValidation()
        //{
        //    //bool ff=true;
        //    if (txtamtent.Text == "")
        //    {
        //        MessageBox.Show("Please fill the Amount Entered field");
        //        return false;
        //    }

        //    return true;
        //}
        public Checker()
        {
            InitializeComponent();
        }
        // Scanning details loading info
        private void Loadscanningdetails()
        {
            previousSelectedRow = -1;
            EnableOrDisable(false);
            //txtdiff.Text = 
            gvscanlist.Columns.Clear();
            DataTable dtscanning = new DataTable();
            gvscanlist.DataSource = null;
            ScannerBusiness objscanning = new ScannerBusiness();
            dtscanning = objscanning.GetMakerDetails();
            gvscanlist.DataSource = dtscanning;
            if (dtscanning.Rows.Count > 0)
            {
                //gvscanlist.Columns["Cheque Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //gvscanlist.Columns["Batch Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //  gvscanlist.Columns["Batch Deposit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // gvscanlist.Columns["Customer Code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Check";
                col.Name = "Action";
                gvscanlist.Columns.Add(col);
            }
            else
            {
                MessageBox.Show("No Scanned List Available for Checker Validation", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void EnableOrDisable(bool inputboolean)
        {
            //txtchqamt.Text = "";
            //txtaccno.Text = "";
            //txtname.Text = "";
            //chqdtpicker.Enabled = inputboolean;
            //txtchqamt.Enabled = inputboolean;
            //txtaccno.Enabled = inputboolean;
            //txtname.Enabled = inputboolean;
        }
        //private void Loadscanningdtl()
        //{

        //    gvchqdetails.Columns.Clear();
        //    DataTable dtscanningdtl = new DataTable();
        //    gvchqdetails.DataSource = null;
        //    ScannerBusiness objscanning = new ScannerBusiness();
        //    dtscanningdtl = objscanning.GetScanning(txtbthno.Text.ToString());
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "cheque Date";
        //    dtscanningdtl.Columns.Add(dc);
        //    DataColumn dc1 = new DataColumn();
        //    dc1.ColumnName = "Amount";
        //    dtscanningdtl.Columns.Add(dc1);
        //    DataColumn dc2 = new DataColumn();
        //    dc2.ColumnName = "A/c No";
        //    dtscanningdtl.Columns.Add(dc2);
        //    DataColumn dc3 = new DataColumn();
        //    dc3.ColumnName = "Drawee Name";
        //    dtscanningdtl.Columns.Add(dc3);
        //    gvchqdetails.DataSource = dtscanningdtl;
        //    //DataGridViewButtonColumn col = new DataGridViewButtonColumn();
        //    //col.UseColumnTextForButtonValue = true;
        //    //col.Text = "view";
        //    //col.Name = "Action";
        //    //gvchqdetails.Columns.Add(col);

        //}
        // cheker screen loading info
        private void Checker_Load(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Load the Checker Details.....");
            try
            {
                Loadscanningdetails();
            }
            catch (Exception ex)
            {

            }
            TheamClass.SetTheam(this);
        }
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Loadscanningdetails();
        }
        //Save activity
        //private void btn_save_Click(object sender, EventArgs e)
        //{
        //    if (txtdiff.Text == "0")
        //    {
        //        try
        //        {

        //            DataTable dtable = new DataTable();
        //            foreach (DataGridViewColumn col in gvchqdetails.Columns)
        //            {
        //                dtable.Columns.Add(col.Name);
        //            }

        //            foreach (DataGridViewRow row in gvchqdetails.Rows)
        //            {
        //                DataRow dRow = dtable.NewRow();
        //                foreach (DataGridViewCell cell in row.Cells)
        //                {
        //                    dRow[cell.ColumnIndex] = cell.Value;
        //                }
        //                dtable.Rows.Add(dRow);
        //            }
        //            dtable = dtable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field =>
        //                    field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

        //            //for (int i = 0; i < dtable.Rows.Count; i++)
        //            //{

        //            ScannerBusiness scan = new ScannerBusiness();
        //            string response = scan.SaveCheckerDetails(dtable);
        //            if (response == "Success")
        //            {
        //                MessageBox.Show("Checker Validation Completed..");
        //            }
        //            //}
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.WriteLog(ex.ToString());
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Amount is Not Matched for this Batch!");
        //    }

        //}
        //private void gvchqdetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        int row = gvchqdetails.Rows.Count;
        //        int curentcount = Convert.ToInt32(gvchqdetails.Rows[e.RowIndex].Cells[1].Value);
        //        gvchqdetails.Rows.Add();
        //        gvchqdetails.Rows[row].Cells[1].Value = chq_no.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        ////datepicker disable info
        //private void chqdtpicker_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = true; // To Supress the event
        //}
        ////Allow only numeric values in text box
        //private void txtamtent_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
        //private void txtchqamt_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
        //private void txtaccno_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
        //Scanning grid to text box fetching info
        private void gvscanlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col;
                int row;
                string batch_number = string.Empty;
                string check_cont = string.Empty;
                string batch_Amt = string.Empty;
                string dep_slip_no = string.Empty;
                string customer_code = string.Empty;
                string inward_type = string.Empty;
                if (gvscanlist.Columns[e.ColumnIndex].Name == "Action")
                {
                    PicLoad.Visible = true;
                    LogHelper.WriteLog("Open Checker Validation Screen");
                     col = gvscanlist.CurrentCell.ColumnIndex;
                     row = gvscanlist.CurrentCell.RowIndex;
                    //txtbthno.Text = gvscanlist.Rows[row].Cells["Batch No"].Value.ToString();
                    //txtchqcnt.Text = gvscanlist.Rows[row].Cells["Cheque Count"].Value.ToString();
                    //txtbthamt.Text = gvscanlist.Rows[row].Cells["Batch Amount"].Value.ToString();
                    //txtslpno.Text = gvscanlist.Rows[row].Cells["Batch Deposit Slip No"].Value.ToString();
                    //txtcusname.Text = gvscanlist.Rows[row].Cells["Customer Code"].Value.ToString();
                    //txtscncnt.Text = gvscanlist.Rows[row].Cells["Cheque Count"].Value.ToString();
                     batch_number = gvscanlist.Rows[row].Cells["Batch No"].Value.ToString();
                     check_cont = gvscanlist.Rows[row].Cells["Cheque Count"].Value.ToString();
                     batch_Amt = gvscanlist.Rows[row].Cells["Batch Amount"].Value.ToString();
                     dep_slip_no = gvscanlist.Rows[row].Cells["Batch Deposit Slip No"].Value.ToString();
                     customer_code = gvscanlist.Rows[row].Cells["Customer Code"].Value.ToString();
                     inward_type = gvscanlist.Rows[row].Cells["Inward Type"].Value.ToString();

                    CheckerValidation objcheck = new CheckerValidation(batch_number, check_cont, batch_Amt, dep_slip_no, customer_code, inward_type);
                    objcheck.MdiParent = Checker.ActiveForm;
                    objcheck.Dock = DockStyle.Fill;
                    objcheck.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is CheckerValidation)
                        {
                            f.Close();
                            return;
                        }
                    }
                    PicLoad.Visible = false;
                    objcheck.Show();

                    //CheckerValidation objcheck = new CheckerValidation(batch_number, check_cont, batch_Amt, dep_slip_no, customer_code, inward_type);

                    //objcheck.MdiParent = Checker.ActiveForm;
                    //objcheck.Dock = DockStyle.Fill;
                    //objcheck.ShowDialog();
                    //CheckerValidation objcheck = new CheckerValidation(batch_number, check_cont, batch_Amt, dep_slip_no, customer_code, inward_type);
                    //objcheck.Show();
                    //txtdiff.Text = txtbthamt.Text;
                    //txtamtent.Text = "0";
                }
                //   Loadscanningdtl();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private void btnrefresh_Click(object sender, EventArgs e)
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
                LogHelper.WriteLog(ex.ToString());
            }
        }
        //private void gvchqdetails_DoubleClick(object sender, EventArgs e)
        //{

        //    this.gvchqdetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    this.gvchqdetails.MultiSelect = false;
        //    int col = gvchqdetails.CurrentCell.ColumnIndex;
        //    currectSelectedRow = gvchqdetails.CurrentCell.RowIndex;
        //    int row = currectSelectedRow;
        //    previousSelectedRow = currectSelectedRow;
        //    txtchqno.Text = gvchqdetails.Rows[row].Cells["Cheque No"].Value.ToString();
        //    txtsrtcd.Text = gvchqdetails.Rows[row].Cells["Sort Code"].Value.ToString();
        //    txtbscd.Text = gvchqdetails.Rows[row].Cells["Base Code"].Value.ToString();
        //    txttrncd.Text = gvchqdetails.Rows[row].Cells["Tran Code"].Value.ToString();
        //    EnableOrDisable(true);
        //}

        ////upon clicking cheeck button txt box to grid binding info
        //private void LoadCheker(int previousSelectedRow, DateTime chqdatepic, int txchktamt, string txtaccn, string txtnm)
        //{
        //    try
        //    {
        //        gvchqdetails.Rows[previousSelectedRow].Cells[6].Value = chqdatepic.ToString();
        //        gvchqdetails.Rows[previousSelectedRow].Cells[7].Value = txchktamt.ToString();
        //        gvchqdetails.Rows[previousSelectedRow].Cells[8].Value = txtaccn.ToString();
        //        gvchqdetails.Rows[previousSelectedRow].Cells[9].Value = txtnm.ToString();
        //        int totalAmt = 0;
        //        for (int i = 0; i < gvchqdetails.RowCount - 1; i++)
        //        {
        //            totalAmt = totalAmt + Convert.ToInt32((gvchqdetails.Rows[i].Cells[7].Value.ToString() != "" ? gvchqdetails.Rows[i].Cells[7].Value : "0"));
        //        }
        //        txtamtent.Text = totalAmt.ToString();
        //        txtdiff.Text = (Convert.ToInt32(txtbthamt.Text) - totalAmt).ToString();
        //        //txtdiff.Text = (Convert.ToInt32(txtdiff.Text != "" ? txtdiff.Text : "0") - txchktamt).ToString();

        //        //gvchqdetails.Columns[previousSelectedRow].Visible = false;
        //        //gvchqdetails.Columns[previousSelectedRow].ReadOnly = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void txtchqamt_Leave(object sender, EventArgs e)
        //{
        //    DateTime chqdatepic = chqdtpicker.Value;
        //    int txchktamt = Convert.ToInt32(txtchqamt.Text != "" ? txtchqamt.Text : "0");
        //    //txtamtent.Text = (Convert.ToInt32(txtamtent.Text != "" ? txtamtent.Text : "0") + txchktamt).ToString();
        //    //txtdiff.Text = (Convert.ToInt32(txtdiff.Text != "" ? txtdiff.Text : "0") - txchktamt).ToString();
        //    string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
        //    string txtnm = Convert.ToString(txtname.Text) == "" ? "" : Convert.ToString(txtname.Text);
        //    LoadCheker(previousSelectedRow, chqdatepic, txchktamt, txtaccn, txtnm);
        //}

        //private void txtaccno_Leave(object sender, EventArgs e)
        //{
        //    DateTime chqdatepic = chqdtpicker.Value;
        //    int txchktamt = Convert.ToInt32(txtchqamt.Text != "" ? txtchqamt.Text : "0");
        //    string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
        //    string txtnm = Convert.ToString(txtname.Text) == "" ? "" : Convert.ToString(txtname.Text);
        //    LoadCheker(previousSelectedRow, chqdatepic, txchktamt, txtaccn, txtnm);
        //}

        //private void txtname_Leave(object sender, EventArgs e)
        //{
        //    DateTime chqdatepic = chqdtpicker.Value;
        //    int txchktamt = Convert.ToInt32(txtchqamt.Text != "" ? txtchqamt.Text : "0");
        //    string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
        //    string txtnm = Convert.ToString(txtname.Text) == "" ? "" : Convert.ToString(txtname.Text);
        //    LoadCheker(previousSelectedRow, chqdatepic, txchktamt, txtaccn, txtnm);
        //}


    }
}
