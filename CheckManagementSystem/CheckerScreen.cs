using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class CheckerScreen : Form
    {
        public int BatchGid = 0;
        int count = 0;
        string prvvalue = "";
        string ChqDate = "";
        int Selected_ChqGid = 0;
        double tot_chqentry = 0;
        double tot_batchamt = 0;
        double entered_chq_amt = 0;
        string chq_type = "";
        string cts_acc_type = "";

        public CheckerScreen()
        {
            InitializeComponent();
        }
        public CheckerScreen(int Batchgid, string BatchDate, string BatchNo, string ChequeType,string _cts_acc_type, string DepositSlipNo, string Pickuplocation, int ChequeCount, string CustomerName, double batchamount)
        {

            InitializeComponent();

            BatchGid = Batchgid;
            BatchNo_Txt.Text = BatchNo;
            chqtype_txt.Text = ChequeType;
            chq_type = ChequeType;
            if (_cts_acc_type != "")
            {
                chqtype_txt.Text += "-" + _cts_acc_type;
                cts_acc_type = _cts_acc_type;
            }

            Depslipno_txt.Text = DepositSlipNo;
            CustomerName_txt.Text = CustomerName;
            ChqCount_txt.Text = Convert.ToString(ChequeCount);
            BatchAmount_txt.Text = string.Format("{0:0.00}",batchamount);
            tot_batchamt = batchamount;
            txtBatchAmt.Text = BatchAmount_txt.Text;
            ScanCount_txt.Text = Convert.ToString(ChequeCount);

            if (ChequeType == "CTS")
            {
                txtaccno.ReadOnly = true;
                txtaccname.ReadOnly = true;
            }
            else
            {
                txtaccno.ReadOnly = false;
                txtaccname.ReadOnly = false;
            }

            //if (ChequeType == "CMS")
            //{
            //    txtaccno.ReadOnly = true;
            //    txtaccname.ReadOnly = false;
            //}
            //else
            //{
            //    txtaccno.ReadOnly = false;
            //    txtaccname.ReadOnly = true;
            //}


        }
        private void LoadChqDtl(int BatchGid)
        {
            try
            {
                gvmChkrEntry.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvmChkrEntry.DataSource = null;
                
                InwardBusiness ObjInward = new InwardBusiness();
                BatchEntryBusiness ObjBatch = new BatchEntryBusiness();

                tot_chqentry = ObjInward.GetValidChqTotal(BatchGid);
                txtEnteredAmt.Text = string.Format("{0:0.00}", tot_chqentry);
                txtDiffAmt.Text = string.Format("{0:0.00}", tot_batchamt-tot_chqentry);
                
                string batch_queue_code = ObjBatch.GetBatchQueueCode(BatchGid);
                string chq_queue_code = "";

                if (rdoPending.Checked)
                    chq_queue_code = "E";
                else
                    chq_queue_code = "U";

                dtscanning = ObjInward.GetCheckerDtls(BatchGid,chq_queue_code);
                gvmChkrEntry.DataSource = dtscanning;

                if (gvmChkrEntry.Columns["Cheque Gid"] != null && batch_queue_code == "E")
                {
                    gvmChkrEntry.Columns["Cheque Gid"].Visible = false;
                    gvmChkrEntry.Columns["Batch Gid"].Visible = false;
                    gvmChkrEntry.Columns["Base Code"].Visible = false;
                    gvmChkrEntry.Columns["cts_acc_no"].Visible = false;
                    gvmChkrEntry.Columns["cts_acc_name"].Visible = false;
                    gvmChkrEntry.Columns["cts_chq_amount"].Visible = false;

                }
                else
                {
                    if (batch_queue_code == "U")
                        MessageBox.Show("Checker entry completed moved to upload queue !", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Not Available for Checker Validation", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                gvmChkrEntry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (rdoPending.Checked)
                {
                    lblPending.Text = "Pending : " + dtscanning.Rows.Count.ToString();
                    lblCompleted.Text = "Completed : " + (Convert.ToInt32(ScanCount_txt.Text) - dtscanning.Rows.Count).ToString();
                }
                else
                {
                    lblPending.Text = "Pending : " + (Convert.ToInt32(ScanCount_txt.Text) - dtscanning.Rows.Count).ToString();
                    lblCompleted.Text = "Completed : " + dtscanning.Rows.Count.ToString(); 
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckerScreen_Load(object sender, EventArgs e)
        {
            LoadChqDtl(BatchGid);
            chqdtpicker.Focus();
        }
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {

            LoadChqDtl(BatchGid);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chqdtpicker.Text.ToString() == "")
                {
                    MessageBox.Show("Chq Date Can't Empty ");
                    chqdtpicker.Focus();
                    return;
                }

                if (txtchqamt.Text.ToString() == "" || txtchqamt.Text.ToString() == "0")
                {
                    MessageBox.Show("Chq Amount Can't Empty ");
                    txtchqamt.Focus();
                    return;
                }

                if (chq_type == "CTS")
                {
                    if (txtaccno.Text == "")
                    {
                        MessageBox.Show("Drawee A/C No Can't Empty ");
                        txtaccno.Focus();
                        return;
                    }

                    if (Math.Round(Convert.ToDouble(txtchqamt.Text) - Convert.ToDouble(txtCtsChqAmt.Text), 2) != 0)
                    {
                        MessageBox.Show("CTS Cheque amount not matched with entered cheque amount !","CTS Cheque Amount Mismatch",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtchqamt.Focus();
                        return;
                    }
                }

                if (txtaccname.Text.ToString() == "")
                {
                    MessageBox.Show("Drawee Name Can't Empty ");
                    txtaccname.Focus();
                    return;
                }

                if (rdoPending.Checked && gvmChkrEntry.Rows.Count == 1)
                {
                    double input_diff_amt = 0;
                    double chq_amt = 0;

                    if (txtchqamt.Text == "")
                        chq_amt = 0;
                    else
                        chq_amt = Math.Round(Convert.ToDouble(txtchqamt.Text), 2);

                    if (txtInputDiffAmt.Text == "")
                        txtInputDiffAmt.Text = "0";
                    else
                        input_diff_amt = Convert.ToDouble(txtInputDiffAmt.Text);

                    input_diff_amt = Math.Round(input_diff_amt, 2);

                    if (Math.Round(tot_batchamt - (tot_chqentry +chq_amt + input_diff_amt), 2) != 0)
                    {
                        MessageBox.Show("Entered total cheque amount not talled with batch amount ! Please enter the difference amount !", "Batch Not Tallied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtInputDiffAmt.Enabled = true;
                        txtInputDiffAmt.Focus();
                        return;
                    }
                }

                if (MessageBox.Show("Are you sure to save ?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                InwardBusiness objBusiness = new InwardBusiness();
                string EntryChqDate = ChqDate;
                string chqamt = txtchqamt.Text.Trim();
                string accno = txtaccno.Text.Trim();
                string accname = txtaccname.Text.Trim();
                string[] result = objBusiness.SaveCheckerDtl(BatchGid, Selected_ChqGid, EntryChqDate, chqamt, accno, accname);
                if(result[1].ToString() == "1")
                {
                    chqdtpicker.Text = "";
                    txtchqamt.Text = "";
                    txtaccno.Text = "";
                    txtaccname.Text = "";

                    LoadChqDtl(BatchGid);
                    
                    chqdtpicker.Focus();

                    txtInputDiffAmt.Text = "";
                    txtInputDiffAmt.Enabled = false;
                }
                else
                    MessageBox.Show(result[0].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvmicrentry_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {

                    if (gvmChkrEntry.Rows[gvmChkrEntry.Rows.Count - 1].Cells["Amount"].Value.ToString() != "")
                    {
                        MessageBox.Show("Data Entry Completed..!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    else
                    {
                        chqdtpicker.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvmicrentry_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                             
               Bitmap FrontImage=null ;
               Bitmap BackImage = null;
                int rowindex = gvmChkrEntry.CurrentCell.RowIndex;
                
                Selected_ChqGid = Convert.ToInt32(gvmChkrEntry.Rows[rowindex].Cells["Cheque Gid"].Value.ToString());

                txtaccno.Text = gvmChkrEntry.Rows[rowindex].Cells["cts_acc_no"].Value.ToString();
                txtaccname.Text = gvmChkrEntry.Rows[rowindex].Cells["cts_acc_name"].Value.ToString();
                txtCtsChqAmt.Text = gvmChkrEntry.Rows[rowindex].Cells["cts_chq_amount"].Value.ToString();
                entered_chq_amt = Math.Round( Convert.ToDouble( gvmChkrEntry.Rows[rowindex].Cells["Cheque Amount"].Value.ToString()),2);

                InwardBusiness ObjInward = new InwardBusiness();
                DataTable dtscanimage = ObjInward.GetScanImageDtls(Selected_ChqGid);
                for (int i = 0; i < dtscanimage.Rows.Count; i++)
                {

                    if (dtscanimage.Rows[i]["image_side"].ToString() == "F")
                    {
                        FrontImage = ReturnImage((byte[])dtscanimage.Rows[i]["image_byte"]);
                    }
                    if (dtscanimage.Rows[i]["image_side"].ToString() == "R")
                    {
                        BackImage = ReturnImage((byte[])dtscanimage.Rows[i]["image_byte"]);
                    }

                }
                PicFrontSide.Image = FrontImage;
                PicBackSide.Image = BackImage;

                count = 0;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Bitmap ReturnImage(byte[] byteBuffer)
        {

            Bitmap bm = null;
            try
            {
               

                //byte[] byteBuffer = Convert.FromBase64String(base64);                
                MemoryStream memoryStream = new MemoryStream(byteBuffer);               
                bm = new Bitmap(Image.FromStream(memoryStream));
                
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bm;
        }

        private void txtchqamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{tab}");
                    return;
                }

                if (chqdtpicker.Text == "")
                {
                    e.Handled = true;
                    MessageBox.Show("Please Enter Cheque Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtchqamt.Text = "";
                    chqdtpicker.Focus();
                    return;
                }
                if ((sender as TextBox).Text.Count(Char.IsDigit) >= 16)
                    e.Handled = true;
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                if (Regex.IsMatch(txtchqamt.Text, @"\.\d\d") && e.KeyChar != 13 && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
                //if (Char.IsControl(e.KeyChar))
                //{
                //    e.Handled = false;
                //}
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtchqamt_Leave(object sender, EventArgs e)
        {
            try
            {
                //string amount = txtchqamt.Text;

                if (txtchqamt.Text.ToString() != "")
                {
                    string currentvalue = "";
                    // only allow one decimal point 
                    if (Convert.ToDouble( txtchqamt.Text) > 0)
                    {
                        count += 1;
                        if (count == 1)
                        {
                            prvvalue = txtchqamt.Text;
                            txtchqamt.Clear();
                            txtchqamt.Focus();                            
                        }
                        else if (count == 2)
                        {
                            currentvalue = txtchqamt.Text;
                            if (prvvalue.Equals(currentvalue))
                            {
                                txtDiffAmt.Text = string.Format("{0:0.00}", tot_batchamt - (tot_chqentry - entered_chq_amt + Convert.ToDouble( currentvalue)));

                                count = 0;
                                prvvalue = "";
                                currentvalue = "";
                                if (chq_type == "CTS")
                                {
                                    //btnSave.Focus();
                                }
                                else
                                    txtaccno.Focus();
                            }
                            else
                            {
                                count = 0;
                                txtchqamt.Clear();
                                txtchqamt.Focus();
                                MessageBox.Show("Amount mismatch ! Reenter the amount", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            count = 0;
                            txtchqamt.Clear();
                            txtchqamt.Focus();                            
                            MessageBox.Show("Reenter The Amount", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Amount Cannot Be Empty", "Checke Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtchqamt.Focus();                            
                    }

                }
                else
                {
                    MessageBox.Show("Invalid cheque amount !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chqdtpicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    string currentvalue = "";
                    if (e.KeyChar == 13)
                    {
                        count += 1;
                        currentvalue = chqdtpicker.Text;
                        prvvalue = chqdtpicker.Text;
                        if (chqdtpicker.Text.Length < 6)
                        {
                            MessageBox.Show("Please Enter the Valid Date ");
                            chqdtpicker.Text = "";
                            chqdtpicker.Focus();
                        }
                        else
                        {
                            if (prvvalue.Equals(currentvalue))
                            {
                                try
                                {
                                    int year = Convert.ToInt32("20" + prvvalue.Substring(4, 2));
                                    int month = Convert.ToInt32(prvvalue.Substring(2, 2));
                                    int date = Convert.ToInt32(prvvalue.Substring(0, 2));
                                    DateTime tempDate = new DateTime(year, month, date);
                                    count = 0;
                                    //txtchqamt.Focus();
                                    prvvalue = "";
                                    currentvalue = "";
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Please Enter the Valid Date ");
                                    chqdtpicker.Text = "";
                                    chqdtpicker.Focus();
                                }

                                count = 0;
                                txtchqamt.Focus();
                                prvvalue = "";
                                currentvalue = "";
                            }
                            else
                            {
                                count = 0;
                                chqdtpicker.Clear();
                                chqdtpicker.Focus();
                                MessageBox.Show("Enter Valid Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void chqdtpicker_Leave(object sender, EventArgs e)
        {
            try
            {
                if (chqdtpicker.Text.Length != 6) return;

                prvvalue = chqdtpicker.Text;
                string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
                ChqDate =  "20" + prvvalue.Substring(4, 2)+ "-" + prvvalue.Substring(2, 2) +"-"+ prvvalue.Substring(0, 2);
                DateTime dateTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                if ((dateTime - DateTime.Now).TotalDays < -90)
                {
                    MessageBox.Show("Cheque's Stale Cheque.", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chqdtpicker.Text = "";
                    chqdtpicker.Focus();
                    return;
                }
                else if ((dateTime - DateTime.Now).TotalDays > 1)
                {
                    MessageBox.Show("PDC Cheque.", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chqdtpicker.Text = "";
                    chqdtpicker.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        string txchktamt = txtchqamt.Text == "" ? "" : string.Format("", Convert.ToDecimal(txtchqamt.Text));
                        string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
                        //string txtnm = Convert.ToString(cmbodraweename.Text) == "" ? "" : Convert.ToString(cmbodraweename.Text);
                        string txtnm = txtaccname.Text == "" ? "" : txtaccname.Text;
                        //string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
                        //DateTime dateTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        string datetime = dateTime.ToString("dd/MM/yyyy");
                        //LoadCheker(previousSelectedRow, dateTime, txchktamt, txtaccn, txtnm);
                    }
                    catch (Exception ex)
                    {
                        //LogHelper.WriteLog(ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtaccno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (chqtype_txt.Text == "CMS")
                {
                    //decimal txchktamt = Convert.ToDecimal(txtchqamt.Text != "" ? txtchqamt.Text : "0");
                    string tx = string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                    string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);

                    string txtnm = Convert.ToString(txtaccname.Text) == "" ? "" : Convert.ToString(txtaccname.Text);
                    prvvalue = chqdtpicker.Text;
                    string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
                    ChqDate = "20" + prvvalue.Substring(4, 2) + "-" + prvvalue.Substring(2, 2) + "-" + prvvalue.Substring(0, 2);
                    DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    //LoadCheker(previousSelectedRow, datTime, tx, txtaccn, txtnm);
                    txtaccname.Focus();
                }

                if (chq_type == "CTS")
                {
                    btnSave.Focus();
                    /*
                    if (Convert.ToInt64(txtaccno.Text.ToString()) > 0)
                    {
                        string Accno = txtaccno.Text.ToString();
                        MasterBusiness ObjMaster = new MasterBusiness();
                        string acc_name = ObjMaster.GetAccHolderName(Accno);

                        txtaccname.Text = acc_name;

                        if (acc_name == "")
                        {
                            MessageBox.Show("Account no not available in the master ! Please verify/maintain the account no !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtaccno.Focus();
                            return;
                        }
                        
                        //decimal txchktamt = Convert.ToDecimal(txtchqamt.Text != "" ? txtchqamt.Text : "0");
                        string tx = string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                        string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
                        //string txtnm = Convert.ToString(cmbodraweename.Text) == "" ? "" : Convert.ToString(cmbodraweename.Text);
                        string txtnm = txtaccname.Text == "" ? "" : txtaccname.Text;
                        prvvalue = chqdtpicker.Text;
                        string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
                        ChqDate = "20" + prvvalue.Substring(4, 2) + "-" + prvvalue.Substring(2, 2) + "-" + prvvalue.Substring(0, 2);
                        DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        //LoadCheker(previousSelectedRow, datTime, tx, txtaccn, acc_name);
                        //btnSave_Click(sender, e);
                        //gvmicrentry.Focus();
                        //chqdtpicker.Focus();
                        btnSave.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter The Valid Account No", "Cheque Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtaccno.Focus();
                        return;
                    }
                    */
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /*
    private void txtaccname_KeyPress(object sender, KeyPressEventArgs e)
    {
    try
    {
        if (chqtype_txt.Text == "CTS")
        {
            if (txtaccno.Text == "")
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Account No!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtaccname.Text = "";
                txtaccno.Focus();
                return;
            }
        }

        if (chqtype_txt.Text == "CMS")
        {
            if (chqdtpicker.Text != "")
            {
                if (txtchqamt.Text == "")
                {
                    e.Handled = true;
                    MessageBox.Show("Please Enter Amount!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtaccname.Text = "";
                    txtchqamt.Focus();
                    return;
                }
            }
            else
            {
                var vl = txtaccname.Text;
                e.Handled = true;
                MessageBox.Show("Please Enter Cheque Date!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chqdtpicker.Focus();
                return;
            }

        }
        if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
        {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        if (chqtype_txt.Text == "CTS")
        {
            string currentvalue = "";
            if (e.KeyChar == 13)
            {
                count += 1;
                currentvalue = txtaccname.Text;
            }
        }
        else
        {
            string currentvalue = "";
            if (e.KeyChar == 13)
            {
                count += 1;
                currentvalue = txtaccname.Text;
                //gvmicrentry.Focus();
                //gvmicrentry.CurrentCell = gvmicrentry.Rows[gvmicrentry.SelectedRows[0].Index].Cells[0];
            }

        }
        if (Char.IsControl(e.KeyChar))
        {
            e.Handled = false;
        }
    }
    catch (Exception ex)
    {
        LogHelper.WriteLog(ex.ToString());
    }
    }*/


        private void txtaccname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (chq_type == "CTS")
                {
                    if (txtaccno.Text != "")
                    {
                        //decimal txchktamt = Convert.ToDecimal(txtchqamt.Text != "" ? txtchqamt.Text : "0");
                        string tx = txtchqamt.Text == "" ? "" : string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                        string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
                        string txtnm = Convert.ToString(txtaccname.Text) == "" ? "" : Convert.ToString(txtaccname.Text);
                        prvvalue = chqdtpicker.Text;
                        string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
                        ChqDate = "20" + prvvalue.Substring(4, 2) + "-" + prvvalue.Substring(2, 2) + "-" + prvvalue.Substring(0, 2);
                        DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        //LoadCheker(previousSelectedRow, datTime, tx, txtaccn, txtnm);
                        //btnSave_Click(sender, e);
                        //gvmicrentry.Focus();
                        //chqdtpicker.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Acc No!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtaccno.Focus();

                    }
                }
                if (chqtype_txt.Text == "CMS")
                {
                    if (chqdtpicker.Text != "" && txtchqamt.Text != "")
                    {
                        if (txtaccname.Text != "")
                        {
                            //decimal txchktamt = Convert.ToDecimal(txtchqamt.Text != "" ? txtchqamt.Text : "0");
                            string tx = txtchqamt.Text == "" ? "" : string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                            string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
                            string txtnm = Convert.ToString(txtaccname.Text) == "" ? "" : Convert.ToString(txtaccname.Text);
                            prvvalue = chqdtpicker.Text;
                            string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
                            ChqDate = "20" + prvvalue.Substring(4, 2) + "-" + prvvalue.Substring(2, 2) + "-" + prvvalue.Substring(0, 2);
                            DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                            //LoadCheker(previousSelectedRow, datTime, tx, txtaccn, txtnm);
                            //btnSave_Click(sender, e);
                            //gvmicrentry.Focus();
                            //chqdtpicker.Focus();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtchqamt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaccno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaccname_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckerScreen_Resize(object sender, EventArgs e)
        {
            pnlBatch.Width = this.Width - pnlBatch.Left * 2 - 8;

            pnlChq.Top = this.Height - (pnlBatch.Top + pnlBatch.Height + pnlChq.Height) + 48;
            pnlChq.Left = pnlBatch.Left;
            pnlChq.Width = this.Width - pnlChq.Left * 2;

            pnlEntry.Width = 264;

            PicFrontSide.Top = pnlBatch.Top + pnlBatch.Height + 8;
            PicFrontSide.Left = pnlBatch.Left;
            PicFrontSide.Width = this.Width - pnlEntry.Width - 48;
            PicFrontSide.Height = pnlChq.Top - (pnlBatch.Top + pnlBatch.Height+16);

            pnlEntry.Top = PicFrontSide.Top;
            pnlEntry.Left = PicFrontSide.Left + PicFrontSide.Width + 8;

            pnlAmt.Top = pnlEntry.Top + pnlEntry.Height + 8;
            pnlAmt.Left = pnlEntry.Left;
        }

        private void chqdtpicker_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaccname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void lblPending_Click(object sender, EventArgs e)
        {

        }

        private void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            LoadChqDtl(BatchGid);
        }

        private void rdoCompleted_CheckedChanged(object sender, EventArgs e)
        {
            LoadChqDtl(BatchGid);
        }

        private void gvmChkrEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtaccno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtaccno_Enter(object sender, EventArgs e)
        {
            if (chq_type == "CTS") btnSave.Focus();
        }

        private void txtInputDiffAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSave.Focus();
        }

        private void txtBatchAmt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
