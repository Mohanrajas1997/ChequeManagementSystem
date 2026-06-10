/* Prepared By  : SheebaSebasthian
 * Prepared On  :  27-May-2019*/
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
    public partial class ReviewCheckAmount : Form
    {
        public static string status = "";
        string verified = "";
        int count = 0;
        string prvvalue = "";

        #region Intilization
        string batch_no = "";
        DataTable dt = new DataTable();
        DataTable Amtdt = new DataTable();
        //ScannerBusiness sb = new ScannerBusiness();
        string amountdiff = "";
        #endregion

        #region Methods
        private void LoadReviewCheckBatchAmount()
        {
            try
            {
                //for (int i = 0; i < Amtdt.Rows.Count; i++)
                //{
                dt.Rows.Add("");
                //}
                dtgvReviewAmount.DataSource = dt;

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events

        public ReviewCheckAmount()
        {
            InitializeComponent();
        }
        public ReviewCheckAmount(DataTable _dt, string _amountdiff, DataTable _amrdt)
        {
            dt = _amrdt;
            amountdiff = _amountdiff;
            Amtdt = _dt;
            InitializeComponent();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            //if (verified == "Success")
            //{
            this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Cannot Close untill Account No With Amount Verified.", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btnverify.Focus();
            //}
        }
        #endregion

        private void ReviewCheckAmount_Load(object sender, EventArgs e)
        {
            LoadReviewCheckBatchAmount();
            TheamClass.SetTheam(this);

        }
        private void btnverify_Click(object sender, EventArgs e)
        {

            //test

            //test end
            bool verify = false;
            bool isbreak = true;
            try
            {
                DataTable dtreview = (DataTable)dtgvReviewAmount.DataSource;
                for (int i = 0; i < Amtdt.Rows.Count; i++)
                {
                    if (isbreak)
                    {
                        string account_no = dtreview.Rows[i]["A/C No"].ToString();
                        DataTable resultTable = new DataTable();
                        resultTable.Columns.Add("ACC_No");
                        var result = from c in dtreview.AsEnumerable()
                                     group c by new
                                     {
                                         ACC_No = c.Field<string>("A/C No")
                                     } into g
                                     where g.Count() > 1
                                     select new { g.Key.ACC_No };

                        int duplicates = result.ToList().Count;
                        if (duplicates > 0)
                        {
                            MessageBox.Show("Account No iS Duplication");
                            return;
                        }
                        else
                        {


                            //for (int k = 0; k < result.ToList().Count; k++)
                            //{
                            //    var item = result.ToList()[k];
                            //    resultTable.Rows.Add(item.ACC_No);
                            //}
                            // var duplicates = dtreview.AsEnumerable().Select(dr => dr.Field<string>("A/C No")).GroupBy(x => x).ToList();

                            if (account_no != "")
                            {
                                bool isaccno = Amtdt.AsEnumerable().Any(row => account_no == row.Field<string>("A/C no"));
                                if (isaccno)
                                {
                                    for (int j = 0; j < dtreview.Rows.Count; j++)
                                    {
                                        if (account_no == dtreview.Rows[j]["A/C No"].ToString())
                                        {
                                            //string orgamt = Amtdt.Rows[i]["Amount"].ToString();
                                            string orgamt = (Amtdt.AsEnumerable().Where(p => p["A/C No"].ToString() == account_no).Select(p => p["Amount"].ToString())).FirstOrDefault();
                                            // orgamt = orgamt.Contains(".") ? orgamt : orgamt + ".00";
                                            if (dtreview.Rows[i]["Amount"].ToString() != "")
                                            {
                                                string ea = (dtreview.AsEnumerable().Where(p => p["A/C No"].ToString() == account_no).Select(p => p["Amount"].ToString())).FirstOrDefault();
                                                decimal d = Convert.ToDecimal(ea);
                                                string revamt = String.Format("{0:0.00}", d);
                                                if (orgamt == revamt)
                                                {
                                                    verify = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Amount No Incorrect. Your Expected Amount for this Account No is  : " + orgamt, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    dtgvReviewAmount.Focus();
                                                    dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[i].Cells[1];
                                                    isbreak = false;
                                                    break;
                                                }
                                            }
                                            //string revamt = string.Format(dtreview.Rows[i]["Amount"].ToString(),  @"\.\d\d");

                                           // string revamt = String.Format("{0:0.00}");
                                            else
                                            {
                                                MessageBox.Show("Amount No Incorrect. Your Expected Amount for this Account No is  : " + orgamt, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                dtgvReviewAmount.Focus();
                                                dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[i].Cells[1];
                                                isbreak = false;
                                                break;

                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    isbreak = false;
                                    MessageBox.Show("Please Enter Valid Account No. Your Expected Account No is  : " + account_no, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                            else
                            {
                                isbreak = false;
                                MessageBox.Show("Please Enter Account No. Your Expected Account No Count is  : " + Amtdt.Rows.Count, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                }
                if (isbreak)
                {
                    MessageBox.Show("Verification Completed", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    status = "Success";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            //if (dtgvReviewAmount.Rows.Count > 1)
            //{
            //    bool verify = true;
            //    try
            //    {


            //        for (int i = 0; i < dtgvReviewAmount.Rows.Count - 1; i++)
            //        {
            //            dtgvReviewAmount[1, i].Style.BackColor = Color.White;

            //        }
            //        if (amountdiff == "0" || amountdiff == "0.0" || amountdiff == "0.00")
            //        {
            //            for (int d = 0; d < dtgvReviewAmount.Rows.Count; d++)
            //            {
            //                for (int f = 0; f < dtgvReviewAmount.Columns.Count; f++)
            //                {
            //                    dtgvReviewAmount[f, d].Style.BackColor = Color.White;
            //                }
            //            }

            //            DataTable dt = (DataTable)dtgvReviewAmount.DataSource;
            //            DataTable Acdt = new DataTable();
            //            // dt.Columns["A/C No"].ColumnName = "A/C No";
            //            var newDt1 = dt.AsEnumerable()
            //              .GroupBy(r => r.Field<string>(0).Trim())
            //              .Select(g =>
            //              {
            //                  var row = dt.NewRow();
            //                  row[0] = g.Key;
            //                  row[1] = g.Sum(r => Convert.ToDecimal(r.Field<string>(1)));
            //                  return row;
            //              }).CopyToDataTable();
            //            DataView dv = new DataView(newDt1);
            //            newDt1 = dv.ToTable(true, "A/C No", "Amount");
            //            DataTable ReviewDt = new DataTable();
            //            DataColumn dc2 = new DataColumn();
            //            dc2.ColumnName = "A/C No";
            //            // dc1.ColumnName = "A/C No";
            //            ReviewDt.Columns.Add(dc2);

            //            DataColumn dc1 = new DataColumn();
            //            dc1.ColumnName = "Amount";
            //            // dc1.ColumnName = "A/C No";
            //            ReviewDt.Columns.Add(dc1);
            //            if (newDt1.Rows.Count > 0)
            //            {
            //                for (int d = 0; d < Amtdt.Rows.Count; d++)
            //                {
            //                    for (int f = 0; f < newDt1.Rows.Count; f++)
            //                    {
            //                        if (Amtdt.Rows[d]["A/C No"].ToString() == newDt1.Rows[f]["A/C No"].ToString())
            //                        {
            //                            if (Convert.ToDecimal(Amtdt.Rows[d]["Amount"].ToString()) != Convert.ToDecimal(newDt1.Rows[f]["Amount"].ToString()))
            //                            {
            //                                DataRow dr = ReviewDt.NewRow();
            //                                dr[0] = newDt1.Rows[f]["A/C No"].ToString();
            //                                dr[1] = newDt1.Rows[f]["Amount"].ToString();
            //                                ReviewDt.Rows.Add(dr);
            //                            }
            //                        }

            //                    }
            //                }
            //            }
            //            for (int i = 0; i < dtgvReviewAmount.Rows.Count - 1; i++)
            //            {

            //                for (int j = 0; j < ReviewDt.Rows.Count; j++)
            //                {
            //                    if (dtgvReviewAmount.Rows[i].Cells["A/C No"].Value.ToString() == ReviewDt.Rows[j]["A/C No"].ToString())
            //                    {

            //                        dtgvReviewAmount[1, i].Style.BackColor = Color.Yellow;
            //                        verify = false;
            //                    }
            //                }
            //            }
            //            if (Amtdt.AsEnumerable().Where(ra => newDt1.AsEnumerable().Any(rb => rb.Field<string>("A/C No") != ra.Field<string>("A/C No"))).CopyToDataTable().Rows.Count > 0)
            //            {
            //                DataTable ValidateAcc = newDt1.AsEnumerable().Where(ra => !Amtdt.AsEnumerable().Any(rb => rb.Field<string>("A/C No") == ra.Field<string>("A/C No"))).CopyToDataTable();

            //                for (int i = 0; i < dtgvReviewAmount.Rows.Count - 1; i++)
            //                {
            //                    for (int j = 0; j < ValidateAcc.Rows.Count; j++)
            //                    {
            //                        if (dtgvReviewAmount.Rows[i].Cells["A/C No"].Value.ToString() == ValidateAcc.Rows[j]["A/C No"].ToString())
            //                        {

            //                            dtgvReviewAmount[0, i].Style.BackColor = Color.Yellow;
            //                        }
            //                    }
            //                }
            //            }
            //            for (int x = 0; x < dtgvReviewAmount.Rows.Count; x++)
            //            {
            //                for (int y = 0; y < dtgvReviewAmount.Columns.Count; y++)
            //                {
            //                    if (dtgvReviewAmount[y, x].Style.BackColor == Color.Yellow)
            //                    {
            //                        verify = false;
            //                    }
            //                }
            //            }
            //            DataTable NodataValidate = Amtdt.AsEnumerable().Where(ra => !newDt1.AsEnumerable().Any(rb => rb.Field<string>("A/C No") == ra.Field<string>("A/C No"))).CopyToDataTable();
            //            string data = "";
            //            if (NodataValidate.Rows.Count > 0)
            //            {
            //                for (int v = 0; v < NodataValidate.Rows.Count; v++)
            //                {
            //                    data = data + NodataValidate.Rows[v]["A/C No"].ToString();
            //                    dtgvReviewAmount[0, v].Style.BackColor = Color.Yellow;
            //                }
            //                MessageBox.Show(data, "");
            //                return;
            //            }
            //            if (verify)
            //            {
            //                MessageBox.Show("Verification Completed", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                this.Close();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Amount Mismatched Please Check the Amount", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        if (verify)
            //        {
            //            MessageBox.Show("Verification Completed", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            status = "Success";
            //            this.Close();
            //        }
            //        LogHelper.WriteLog(ex.ToString());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Grid Cannot Be Empty", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        private void dtgvReviewAmount_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgvReviewAmount.Columns[e.ColumnIndex].Name == "A/C No")
                {
                    dtgvReviewAmount.Focus();
                    dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                }
                if (dtgvReviewAmount.Columns[e.ColumnIndex].Name == "Amount")
                {
                    int curentcount = dtgvReviewAmount.Rows.Count;
                    int total = Amtdt.Rows.Count;
                    if (curentcount < total)
                    {
                        DataTable dt1 = (DataTable)dtgvReviewAmount.DataSource;
                        dt1.Rows.Add("");
                        dtgvReviewAmount.DataSource = dt1;
                        dtgvReviewAmount.Focus();
                        dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[e.RowIndex + 1].Cells[e.ColumnIndex - 1];
                    }
                    else
                    {
                        btnverify.Focus();
                    }
                }
                //if (dtgvReviewAmount.Columns[e.ColumnIndex].Name == "A/C No")
                //{
                //    if (e.ColumnIndex == dtgvReviewAmount.Columns.Count - 1)
                //    {
                //        dtgvReviewAmount.Focus();
                //        dtgvReviewAmount.CurrentCell = dtgvReviewAmount[0, e.RowIndex + 1];
                //    }
                //    else
                //    {
                //        dtgvReviewAmount.Focus();
                //        dtgvReviewAmount.CurrentCell = dtgvReviewAmount[e.ColumnIndex + 1, e.RowIndex];
                //    }
                //}
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        //private void dtgvReviewAmount_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            e.SuppressKeyPress = true;
        //            int iColumn = dtgvReviewAmount.CurrentCell.ColumnIndex;
        //            int iRow = dtgvReviewAmount.CurrentCell.RowIndex;
        //            if (iColumn == dtgvReviewAmount.Columns.Count - 1)
        //                dtgvReviewAmount.CurrentCell = dtgvReviewAmount[0, iRow + 1];
        //            else
        //                dtgvReviewAmount.CurrentCell = dtgvReviewAmount[iColumn + 1, iRow];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //    switch (e.KeyData & Keys.KeyCode)
        //    {
        //        case Keys.Up:
        //        case Keys.Right:
        //        case Keys.Down:
        //        case Keys.Left:
        //            e.Handled = true;
        //            e.SuppressKeyPress = true;
        //            break;
        //    }
        //}
        private void dtgvReviewAmount_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtgvReviewAmount.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Col_KeyPress);
                }
            }
            if (dtgvReviewAmount.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Col_KeyPress);
                }
            }
        }
        private void Col_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ri = dtgvReviewAmount.CurrentCell.RowIndex;
            int ci = dtgvReviewAmount.CurrentCell.ColumnIndex;
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 48 && ascii <= 57) || (ascii == 8) || ascii == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        //private void dtgvReviewAmount_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (e.KeyCode == Keys.Enter)
        //    //    {
        //    //        e.SuppressKeyPress = true;
        //    //        int iColumn = dtgvReviewAmount.CurrentCell.ColumnIndex;
        //    //        int iRow = dtgvReviewAmount.CurrentCell.RowIndex;
        //    //        if (iColumn == dtgvReviewAmount.Columns.Count - 1)
        //    //            dtgvReviewAmount.CurrentCell = dtgvReviewAmount[0, iRow + 1];
        //    //        else
        //    //            dtgvReviewAmount.CurrentCell = dtgvReviewAmount[iColumn + 1, iRow];
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    LogHelper.WriteLog(ex.ToString());
        //    //}

        //    //int iColumn = dtgvReviewAmount.CurrentCell.ColumnIndex;
        //    //int iRow = dtgvReviewAmount.CurrentCell.RowIndex;
        //    //if (e.KeyCode == Keys.Enter)
        //    //{
        //    //    SendKeys.Send("{TAB}");
        //    //    //if (dtgvReviewAmount.Columns[iColumn].Name == "A/C No")
        //    //    //{
        //    //    //    e.SuppressKeyPress = true;
        //    //    //    if (iColumn == dtgvReviewAmount.Columns.Count - 1)
        //    //    //        dtgvReviewAmount.CurrentCell = dtgvReviewAmount[0, iRow + 1];
        //    //    //    else
        //    //    //        dtgvReviewAmount.CurrentCell = dtgvReviewAmount[iColumn + 1, iRow];
        //    //    //}
        //    //}
        //}

        //private void dtgvReviewAmount_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (dtgvReviewAmount.Columns[e.ColumnIndex].Name == "A/C No")
        //    //    {
        //    //        if (e.ColumnIndex != dtgvReviewAmount.Columns.Count - 1)
        //    //        {
        //    //            dtgvReviewAmount.Focus();
        //    //            dtgvReviewAmount.CurrentCell = dtgvReviewAmount[0, e.RowIndex + 1];
        //    //        }
        //    //        else
        //    //        {
        //    //            dtgvReviewAmount.Focus();
        //    //            dtgvReviewAmount.CurrentCell = dtgvReviewAmount[e.ColumnIndex + 1, e.RowIndex];
        //    //        }
        //    //        //dtgvReviewAmount.Focus();
        //    //        //dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];

        //    //        //dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex + 1];
        //    //    }
        //    //    if (dtgvReviewAmount.Columns[e.ColumnIndex].Name == "Amount")
        //    //    {
        //    //        //if (e.ColumnIndex == dtgvReviewAmount.Columns.Count - 1)
        //    //        //{
        //    //        //    dtgvReviewAmount.Focus();
        //    //        //    dtgvReviewAmount.CurrentCell = dtgvReviewAmount[0, e.RowIndex + 1];
        //    //        //}
        //    //        //else
        //    //        //{
        //    //        //    dtgvReviewAmount.Focus();
        //    //        //    dtgvReviewAmount.CurrentCell = dtgvReviewAmount[e.ColumnIndex + 1, e.RowIndex];
        //    //        //}
        //    //        //dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[e.RowIndex + 1].Cells[e.ColumnIndex];
        //    //        //dtgvReviewAmount.Focus();
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    LogHelper.WriteLog(ex.ToString());
        //    //}

        //}

        //private void dtgvReviewAmount_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyChar == 13)
        //        {
        //            //e.SuppressKeyPress = true;
        //            int iColumn = dtgvReviewAmount.CurrentCell.ColumnIndex;
        //            int iRow = dtgvReviewAmount.CurrentCell.RowIndex;
        //            if (iColumn == dtgvReviewAmount.Columns.Count - 1)
        //                dtgvReviewAmount.CurrentCell = dtgvReviewAmount[0, iRow + 1];
        //            else
        //                dtgvReviewAmount.CurrentCell = dtgvReviewAmount[iColumn + 1, iRow];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}

        //private void dtgvReviewAmount_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (dtgvReviewAmount.Columns[e.ColumnIndex].Name == "A/C No")
        //        {
        //            dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
        //            dtgvReviewAmount.Focus();
        //            //dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex + 1];
        //        }
        //        if (dtgvReviewAmount.Columns[e.ColumnIndex].Name == "Amount")
        //        {
        //            dtgvReviewAmount.CurrentCell = dtgvReviewAmount.Rows[e.RowIndex + 1].Cells[e.ColumnIndex];
        //            dtgvReviewAmount.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}

    }
}
