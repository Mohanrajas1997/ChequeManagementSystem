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
    public partial class CheckerValidation : Form
    {
        public static DataTable Dtpersist = new DataTable();
        //DataTable Dtpersist = new DataTable();
        bool Isstatus;
        #region Initialization
        int count = 0;
        string prvvalue = "";
        private string batch_num = string.Empty;
        private string check_Count = string.Empty;
        private string batch_amt = string.Empty;
        private string dep_slip_no = string.Empty;
        private string cust_name = string.Empty;
        private string inward_type = string.Empty;
        public int previousSelectedRow = -1;
        public int currectSelectedRow = -1;
        string[] files;
        string[] filePaths;
        int i = 0;
        #endregion

        #region Constructor
        public CheckerValidation()
        {
            InitializeComponent();

        }
        public CheckerValidation(string _batch_no, string _check_count, string _batch_amount, string _dep_slip_no, string _cust_code, string _inward_type)
        {
            batch_num = _batch_no;
            check_Count = _check_count;
            batch_amt = _batch_amount;
            dep_slip_no = _dep_slip_no;
            cust_name = _cust_code;
            inward_type = _inward_type;
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void LoadCheckerValidatelist()
        {
            try
            {
                gvscanlist.Rows.Add();
                gvscanlist.Rows[0].Cells[0].Value = batch_num;
                gvscanlist.Rows[0].Cells[1].Value = check_Count;
                gvscanlist.Rows[0].Cells[2].Value = batch_amt;

                gvscanlist.Rows[0].Cells[3].Value = dep_slip_no;
                gvscanlist.Rows[0].Cells[4].Value = cust_name;
                gvscanlist.Rows[0].Cells[5].Value = check_Count;
                gvscanlist.Rows[0].Cells[6].Value = "0";
                gvscanlist.Rows[0].Cells[7].Value = batch_amt;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCheckerValidateDetails()
        {
            try
            {
                GrdScannedList.Columns.Clear();
                //int count = gvchqdetails.Columns.Count;
                DataTable dtscanningdtl = new DataTable();
                ////gvchqdetails.DataSource = null;
                ScannerBusiness objscanning = new ScannerBusiness();
                dtscanningdtl = objscanning.GetScanning(batch_num);

                //DataColumn dc = new DataColumn();
                //dc.ColumnName = "cheque Date";
                //dtscanningdtl.Columns.Add(dc);

                //DataColumn dc1 = new DataColumn();
                //dc1.ColumnName = "Amount";
                //dtscanningdtl.Columns.Add(dc1);


                //DataColumn dc2 = new DataColumn();
                //dc2.ColumnName = "A/c No";
                //dtscanningdtl.Columns.Add(dc2);

                //DataColumn dc3 = new DataColumn();
                //dc3.ColumnName = "Drawee Name";
                //dtscanningdtl.Columns.Add(dc3);

                //DataColumn dc4 = new DataColumn();
                //dc4.ColumnName = "Image Files";
                //dtscanningdtl.Columns.Add(dc4);

                GrdScannedList.DataSource = dtscanningdtl;

                //if (inward_type == "CMS")
                //{
                //    GrdScannedList.Columns["Drawee Name"].Visible = false;
                //}

                GrdScannedList.Columns["Status"].Visible = false;
                GrdScannedList.Columns["Scan ID"].Visible = false;
                GrdScannedList.Columns["Front Image"].Visible = false;
                GrdScannedList.Columns["Back Image"].Visible = false;
                GrdScannedList.Columns[0].ReadOnly = true;
                GrdScannedList.Columns["Cheque No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdScannedList.Columns["Sort Code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdScannedList.Columns["Base Code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdScannedList.Columns["Tran Code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdScannedList.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                GrdScannedList.Columns["A/c No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //GrdScannedList.Columns["Image Files"].Visible = false;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCheker(int previousSelectedRow, DateTime chqdatepic, string txchktamt, string txtaccn, string txtnm)
        {
            int row = GrdScannedList.CurrentCell.RowIndex;
            //previousSelectedRow = previousSelectedRow + 1;
            previousSelectedRow = row;
            try
            {
                // GrdScannedList.Rows[previousSelectedRow].Cells[6].Value = chqdatepic.ToString();
                GrdScannedList.Rows[previousSelectedRow].Cells["cheque Date"].Value = chqdatepic.ToString("dd-MM-yyyy");
                GrdScannedList.Rows[previousSelectedRow].Cells["Amount"].Value = txchktamt.ToString().Replace(",", "");
                GrdScannedList.Rows[previousSelectedRow].Cells["A/c No"].Value = txtaccn.ToString();
                GrdScannedList.Rows[previousSelectedRow].Cells["Drawee Name"].Value = txtnm.ToString();
                decimal totalAmt = 0;
                for (int i = 0; i < GrdScannedList.RowCount; i++)
                {
                    //totalAmt = totalAmt + Convert.ToInt32((GrdScannedList.Rows[i].Cells[7].Value.ToString() != "" ? GrdScannedList.Rows[i].Cells[7].Value : "0"));
                    totalAmt = totalAmt + Convert.ToDecimal((GrdScannedList.Rows[i].Cells["Amount"].Value.ToString() != "" ? GrdScannedList.Rows[i].Cells["Amount"].Value : "0"));
                }
                gvscanlist.Rows[0].Cells[6].Value = totalAmt.ToString();
                gvscanlist.Rows[0].Cells[7].Value = (Convert.ToDecimal(batch_amt) - Convert.ToDecimal(totalAmt)).ToString();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            chqdtpicker.Text = "";
            txtchqamt.Text = "";
            txtaccno.Text = "";
            cmbodraweename.Text = "";
            txtaccname.Text = "";
        }

        private string LoadDraweeName(string account_no)
        {
            string acc_name = string.Empty;
            try
            {
                MasterEntities.AccountMaster.AccountName acc = new MasterEntities.AccountMaster.AccountName();
                MasterBusiness obj = new MasterBusiness();
                MasterEntities.AccountMaster accs = new MasterEntities.AccountMaster();
                accs.account_no = account_no;
                acc = obj.GetAccount(accs);
                acc_name = acc.Accounts[0].account_name;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return acc_name;
        }

        private void LoadImage()
        {
            try
            {
                string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string batch_no = batch_num;
                batch_no = batch_no.Replace('/', '-');
                string root = exePath + "\\Scanimage\\" + batch_no;
                files = System.IO.Directory.GetFiles(root);
                filePaths = Directory.GetFiles(root);
                var sort = from fn in filePaths orderby new FileInfo(fn).CreationTime ascending select fn;
                int m = 0;
                foreach (string n in sort)
                {
                    filePaths[m] = n;
                    m++;
                }
                int t = 0;
                for (int k = 0; k < filePaths.Length; k++)
                {
                    k++;
                    GrdScannedList.Rows[t].Cells[10].Value = (k + "," + (k - 1));
                    t++;
                }
                int rowindex = GrdScannedList.CurrentCell.RowIndex;
                string fileindex = GrdScannedList.Rows[rowindex].Cells[10].Value.ToString();
                string[] flindx = fileindex.Split(',');

                //PicFrontSide.Image = new Bitmap(filePaths[0]);
                //PicFrontSide.SizeMode = PictureBoxSizeMode.StretchImage;
                //PicBackSide.Image = new Bitmap(filePaths[1]);
                //PicBackSide.SizeMode = PictureBoxSizeMode.StretchImage;


                PicFrontSide.Image = new Bitmap(filePaths[Convert.ToInt32(flindx[1])]);
                PicFrontSide.SizeMode = PictureBoxSizeMode.StretchImage;
                PicBackSide.Image = new Bitmap(filePaths[Convert.ToInt32(flindx[0])]);
                PicBackSide.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateChecker()
        {
            bool isvalid = true;
            try
            {
                for (int i = 0; i < GrdScannedList.RowCount; i++)
                {
                    //if (GrdScannedList.Rows[i].Cells[6].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[6].Value.ToString() == null)
                    //{
                    //    MessageBox.Show("Empty Record Not Allowed");
                    //    GrdScannedList.Focus();
                    //    GrdScannedList.CurrentCell = GrdScannedList.Rows[i].Cells[6];
                    //    isvalid = false;
                    //    break;
                    //}

                    //if (GrdScannedList.Rows[i].Cells[7].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[6].Value.ToString() == null)
                    //{
                    //    MessageBox.Show("Empty Record Not Allowed");
                    //    GrdScannedList.Focus();
                    //    GrdScannedList.CurrentCell = GrdScannedList.Rows[i].Cells[7];
                    //    isvalid = false;
                    //    break;
                    //}
                    //if (GrdScannedList.Rows[i].Cells[8].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[6].Value.ToString() == null)
                    //{
                    //    MessageBox.Show("Empty Record Not Allowed");
                    //    GrdScannedList.Focus();
                    //    GrdScannedList.CurrentCell = GrdScannedList.Rows[i].Cells[8];
                    //    isvalid = false;
                    //    break;
                    //}
                    if (GrdScannedList.Rows[i].Cells["cheque Date"].Value.ToString() == "" || GrdScannedList.Rows[i].Cells["cheque Date"].Value.ToString() == null)
                    {
                        MessageBox.Show("Cheque Date Cannot be Empty");
                        GrdScannedList.Focus();
                        GrdScannedList.CurrentCell = GrdScannedList.Rows[i].Cells["cheque Date"];
                        chqdtpicker.Focus();
                        isvalid = false;
                        break;
                    }
                    if (GrdScannedList.Rows[i].Cells["Amount"].Value.ToString() == "" || GrdScannedList.Rows[i].Cells["Amount"].Value.ToString() == null)
                    {
                        MessageBox.Show("Cheque Amount Cannot be Empty");
                        GrdScannedList.Focus();
                        GrdScannedList.CurrentCell = GrdScannedList.Rows[i].Cells["Amount"];
                        txtchqamt.Focus();
                        isvalid = false;
                        break;
                    }

                    //if (GrdScannedList.Rows[i].Cells["A/c No"].Value.ToString() == "" || GrdScannedList.Rows[i].Cells["A/c No"].Value.ToString() == null)
                    //{
                    //    MessageBox.Show("Account No Cannot be Empty");
                    //    GrdScannedList.Focus();
                    //    GrdScannedList.CurrentCell = GrdScannedList.Rows[i].Cells["Amount"];
                    //    txtchqamt.Focus();
                    //    isvalid = false;
                    //    break;
                    //}

                    //for (int j = 0; j < GrdScannedList.ColumnCount; j++)
                    //{
                    //    if (GrdScannedList.Rows[i].Cells[j].Value == null)
                    //    {
                    //        MessageBox.Show("Please Fill Record");
                    //        GrdScannedList.Focus();
                    //        GrdScannedList.CurrentCell = GrdScannedList.Rows[i].Cells[j];
                    //        isvalid = false;
                    //        break;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isvalid;
        }
        private Bitmap ReturnImage(string base64)
        {

            Bitmap bm = null;
            try
            {
                //LogHelper.WriteLog("Checker Base64  Data" + base64);

                byte[] byteBuffer = Convert.FromBase64String(base64);

                //LogHelper.WriteLog("Checker Byte Buffer" + byteBuffer);
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                //Bitmap bmpFront = (Bitmap)Bitmap.FromStream(memoryStream);
                //LogHelper.WriteLog("checker bm variable before value " + bm);
                bm = new Bitmap(Image.FromStream(memoryStream));
                //LogHelper.WriteLog("Checker bm variable after value " + bm);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bm;
        }
        #endregion

        #region Events

        #region ChequeDate
        private void chqdtpicker_Leave(object sender, EventArgs e)
        {
            try
            {
                prvvalue = chqdtpicker.Text;
                string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
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
                        LoadCheker(previousSelectedRow, dateTime, txchktamt, txtaccn, txtnm);
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
        public static bool IsValidDate(string value, string[] dateFormats)
        {
            DateTime tempDate;
            bool validDate = DateTime.TryParseExact(value, "dd-MM-YYYY", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);
            if (validDate)
                return true;
            else
                return false;
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
                                    txtchqamt.Focus();
                                    prvvalue = "";
                                    currentvalue = "";
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Please Enter the Valid Date ");
                                    chqdtpicker.Text = "";
                                    chqdtpicker.Focus();
                                }

                                //count = 0;
                                //txtchqamt.Focus();
                                //prvvalue = "";
                                //currentvalue = "";
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
        #endregion

        #region Amount
        private void txtchqamt_Leave(object sender, EventArgs e)
        {
            try
            {

                string amount = txtchqamt.Text;
                if (Convert.ToInt32(txtchqamt.Text.ToString()) > 0)
                {
                    //string dt = chqdtpicker.Text;
                    //DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(chqdtpicker.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    ////DateTime dt3 = Convert.ToDateTime(dt);
                    ////dt = string.Format("dd/MM/yyyy", dt3);

                    //DateTime dt1 = Convert.ToDateTime(DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    //DateTime dt2 = DateTime.ParseExact( "04-22-2019", "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
                    //dtgvbatching.Rows[dtgvbatching.CurrentRow.Index].Cells[2].Value = string.Format("{0:N2}", Convert.ToDecimal(a));

                    //decimal txchktamt = Convert.ToDecimal(string.Format("{0:N2}", txtchqamt.Text != "" ? txtchqamt.Text : "0"));
                    string tx = string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                    //txchktamt = string.Format("{0:N2}",
                    string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
                    //string txtnm = Convert.ToString(cmbodraweename.Text) == "" ? "" : Convert.ToString(cmbodraweename.Text);
                    string txtnm = txtaccname.Text == "" ? "" : txtaccname.Text;

                    prvvalue = chqdtpicker.Text;
                    string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);
                    DateTime dateTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));

                    string datetime = dateTime.ToString("dd/MM/yyyy");
                    LoadCheker(previousSelectedRow, dateTime, tx, txtaccn, txtnm);
                }
                else
                {
                    MessageBox.Show("please Fill The Valid Check Amount ", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtchqamt.Focus();
                    return;
                }


            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtchqamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
                else
                {
                    string currentvalue = "";
                    // only allow one decimal point 

                    if (e.KeyChar == 13)
                    {
                        if (txtchqamt.Text != "")
                        {
                            count += 1;
                            if (count == 1)
                            {
                                prvvalue = txtchqamt.Text;
                                txtchqamt.Clear();
                            }
                            else if (count == 2)
                            {
                                currentvalue = txtchqamt.Text;
                                if (prvvalue.Equals(currentvalue))
                                {
                                    count = 0;
                                    txtaccno.Focus();
                                    prvvalue = "";
                                    currentvalue = "";
                                }
                                else
                                {
                                    count = 0;
                                    txtchqamt.Clear();
                                    MessageBox.Show("Reenter The Amount", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                count = 0;
                                txtchqamt.Clear();
                                MessageBox.Show("Reenter The Amount", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Amount Cannot Be Empty", "Checke Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtchqamt.Focus();
                        }
                    }
                }
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region AccountNo
        private void txtaccno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (inward_type == "CMS")
                {
                    //decimal txchktamt = Convert.ToDecimal(txtchqamt.Text != "" ? txtchqamt.Text : "0");
                    string tx = string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                    string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);

                    string txtnm = Convert.ToString(txtaccname.Text) == "" ? "" : Convert.ToString(txtaccname.Text);
                    prvvalue = chqdtpicker.Text;
                    string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);

                    DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    LoadCheker(previousSelectedRow, datTime, tx, txtaccn, txtnm);
                }
                if (inward_type == "CTS")
                {
                    //if (txtaccno.Text != "")
                    //{
                    if (Convert.ToInt64(txtaccno.Text.ToString()) > 0)
                    {
                        string Accno = txtaccno.Text.ToString();
                        string acc_name = LoadDraweeName(Accno);
                        //decimal txchktamt = Convert.ToDecimal(txtchqamt.Text != "" ? txtchqamt.Text : "0");
                        string tx = string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                        string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
                        //string txtnm = Convert.ToString(cmbodraweename.Text) == "" ? "" : Convert.ToString(cmbodraweename.Text);
                        string txtnm = txtaccname.Text == "" ? "" : txtaccname.Text;
                        prvvalue = chqdtpicker.Text;
                        string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);

                        DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        LoadCheker(previousSelectedRow, datTime, tx, txtaccn, acc_name);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter The Valid Account No", "Cheque Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtaccno.Focus();
                        return;
                    }
                    // }
                    //else
                    //{
                    //    MessageBox.Show("Please Enter The Account No", "Cheque Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txtaccno.Focus();
                    //    return;
                    //}

                }
                //else
                //{
                //    MessageBox.Show("Account No Cannot Be Empty", "Cheque Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtaccno.Focus();
                //}
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtaccno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (inward_type == "CTS")
                {
                    if (txtchqamt.Text == "")
                    {
                        e.Handled = true;
                        MessageBox.Show("Please Enter Amount", "Cheque Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtaccno.Text = "";
                        txtchqamt.Focus();
                        return;
                    }
                }
                if ((sender as TextBox).Text.Count(Char.IsDigit) >= 16)
                    e.Handled = true;
                if (inward_type == "CTS")
                {
                    string currentvalue = "";
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    if (e.KeyChar == 13)
                    {
                        count += 1;
                        currentvalue = txtaccno.Text;
                        GrdScannedList.Focus();
                        GrdScannedList.CurrentCell = GrdScannedList.Rows[GrdScannedList.SelectedRows[0].Index].Cells[0];
                    }
                }
                else
                {
                    string currentvalue = "";
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    if (e.KeyChar == 13)
                    {
                        count += 1;
                        currentvalue = txtaccno.Text;
                        txtaccname.Focus();
                    }
                }
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region AccountName
        private void txtaccname_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (!char.IsLetter(e.KeyChar))
                //  {
                //      e.Handled = true;
                //  }
                if (inward_type == "CTS")
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

                if (inward_type == "CMS")
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

                if (inward_type == "CTS")
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
                        GrdScannedList.Focus();
                        GrdScannedList.CurrentCell = GrdScannedList.Rows[GrdScannedList.SelectedRows[0].Index].Cells[0];
                    }
                    //if (Convert.ToInt32(check_Count) == GrdScannedList.Rows.Count)
                    //{
                    //    MessageBox.Show("Data Entry Completed..!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    btnSave.Focus();
                    //}
                }
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtaccname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (inward_type == "CTS")
                {
                    if (txtaccno.Text != "")
                    {
                        //decimal txchktamt = Convert.ToDecimal(txtchqamt.Text != "" ? txtchqamt.Text : "0");
                        string tx = txtchqamt.Text == "" ? "" : string.Format("{0:N2}", Convert.ToDecimal(txtchqamt.Text));
                        string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
                        string txtnm = Convert.ToString(txtaccname.Text) == "" ? "" : Convert.ToString(txtaccname.Text);
                        prvvalue = chqdtpicker.Text;
                        string result = prvvalue.Substring(0, 2) + "/" + prvvalue.Substring(2, 2) + "/" + "20" + prvvalue.Substring(4, 2);

                        DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        LoadCheker(previousSelectedRow, datTime, tx, txtaccn, txtnm);
                        GrdScannedList.Focus();
                    }
                    else
                    {
                        txtaccno.Focus();
                    }
                }
                if (inward_type == "CMS")
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

                            DateTime datTime = Convert.ToDateTime(DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                            LoadCheker(previousSelectedRow, datTime, tx, txtaccn, txtnm);
                            GrdScannedList.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Drawee Name!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtaccname.Focus();
                            return;
                        }
                    }
                    else
                    {
                        txtaccname.Text = "";
                    }
                    //else
                    //{
                    //    MessageBox.Show("Please Enter Drawee Name!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txtaccname.Focus();
                    //    return;
                    //}


                    //if (Convert.ToInt32(check_Count) == GrdScannedList.Rows.Count)
                    //{
                    //    MessageBox.Show("Data Entry Completed..!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    btnSave.Focus();
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void CheckerValidation_Load(object sender, EventArgs e)
        {
            try
            {
                chqdtpicker.Focus();
                LoadCheckerValidatelist();
                //if (Dtpersist.Rows.Count <= 0)
                //{
                LoadCheckerValidateDetails();

                string Fbase = GrdScannedList.Rows[0].Cells["Front Image"].Value.ToString();
                string Bbase = GrdScannedList.Rows[0].Cells["Back Image"].Value.ToString();
                PicFrontSide.Image = ReturnImage(Fbase);
                PicBackSide.Image = ReturnImage(Bbase);
                // }
                if (inward_type == "CTS")
                {
                    btnSave.Enabled = false;
                    //txtaccname.Visible = false;
                    //cmbodraweename.Visible = true;
                    lblaccno.Text = "Account No";
                    lbldrwname.Text = "Account Holder";
                    btnReview.Visible = true;
                    //txtaccname.ReadOnly = true;
                    // LoadDraweeName();
                }
                else
                {
                    btnSave.Enabled = true;
                    btnReview.Visible = false;
                    //txtaccname.Visible = true;
                    //cmbodraweename.Visible = false;
                }
                chqdtpicker.Focus();
                //   TheamClass.SetTheam(this);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Checker Closed");
            try
            {
                string Amount = gvscanlist.Rows[0].Cells["differecne"].Value.ToString();
                if (Amount == "0" || Amount == "0.0" || Amount == "0.00")
                {
                    this.Close();
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Amount Mismatched.. Please Validate the Checks Amount. Close Checker?", "Check Management System", MessageBoxButtons.YesNo);
                    if (dg == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool checkDrawname()
        {
            bool validate = false;
            for (int i = 0; i < GrdScannedList.Rows.Count; i++)
            {
                string accountname = GrdScannedList.Rows[i].Cells[12].Value.ToString();

                if (GrdScannedList.Rows[i].Cells[12].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[12].Value.ToString() == null)
                {
                    validate = true;
                }
            }
            return validate;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            if (inward_type.ToString() == "CTS")
            {
                if (inward_type.ToString() == "CTS")
                {
                    btn_Refersh.Visible = true;
                }
            }
            if (inward_type.ToString() == "CMS")
            {
                if (checkaccountname())
                {
                    MessageBox.Show("One or More Fields empty. Please enter required fields");
                    PicLoad.Visible = false;
                    if (inward_type.ToString() == "CMS")
                    {
                        btn_Refersh.Visible = true;
                        return;
                    }

                }
            }
            LogHelper.WriteLog("Going to Save Checker Detils");
            try
            {
                bool isvalid = ValidateChecker();
                if (isvalid == true)
                {
                    LogHelper.WriteLog("Level 1 : Validation Completed..");
                    //Decimal Amount = Convert.ToDecimal(gvscanlist.Rows[0].Cells["differecne"].Value.ToString());
                    //if (Amount == 0 )
                    //{
                    string Amount = gvscanlist.Rows[0].Cells["differecne"].Value.ToString();
                    if (Convert.ToDecimal(Amount) != 0)
                    {
                        DialogResult dg1 = MessageBox.Show("Do You Want  Update Cheque Amount?", "Check Mandate System", MessageBoxButtons.YesNo);
                        if (dg1 == DialogResult.Yes)
                        {
                            txtchequeamt.Visible = true;
                            btnUpdate.Visible = true;
                            txtchequeamt.Focus();
                        }
                    }
                    else
                    {

                        if (Amount == "0" || Amount == "0.0" || Amount == "0.00")
                        {
                            LogHelper.WriteLog("Level 2 : Amount is 0 Completed..");
                            try
                            {
                                DataTable dtable = new DataTable();
                                foreach (DataGridViewColumn col in GrdScannedList.Columns)
                                {
                                    dtable.Columns.Add(col.Name);
                                }
                                dtable.Columns["A/C No"].ColumnName = "Account_No";
                                foreach (DataGridViewRow row in GrdScannedList.Rows)
                                {
                                    DataRow dRow = dtable.NewRow();
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        dRow[cell.ColumnIndex] = cell.Value;
                                    }
                                    dtable.Rows.Add(dRow);
                                }
                                LogHelper.WriteLog("Level 3 : Data is Captured to Datatable..");
                                DataColumn dcol = new DataColumn();
                                dcol.ColumnName = "Batch No";
                                dcol.DefaultValue = batch_num;
                                dtable.Columns.Add(dcol);
                                ScannerBusiness scan = new ScannerBusiness();
                                LogHelper.WriteLog("Level 4 : Data Going to Save..");
                                dtable.Columns.Remove("Front Image");
                                dtable.Columns.Remove("Back Image");
                                string response = scan.SaveCheckerDetails(dtable);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                //LogHelper.WriteLog(ex.ToString());
                                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Amount Mismatched.. Please Validate the Checks Amount.");
                        }
                    }
                }
                else
                {
                    LogHelper.WriteLog("Level 1 : Failed. Because of Fields Is MIssing from Data Entry.");
                    MessageBox.Show("Field Cannot be Empty Please Fill the Records", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }
        private void btntogg_Click(object sender, EventArgs e)
        {
            try
            {
                if (PicFrontSide.Visible == true)
                {
                    PicBackSide.Visible = true;
                    PicFrontSide.Visible = false;
                }
                else if (PicBackSide.Visible == true)
                {
                    PicBackSide.Visible = false;
                    PicFrontSide.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GrdScannedList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string chqdt = "";
                int rowindex = GrdScannedList.CurrentCell.RowIndex;
                //Clear();
                //
                string Fbase = GrdScannedList.Rows[rowindex].Cells["Front Image"].Value.ToString();
                string Bbase = GrdScannedList.Rows[rowindex].Cells["Back Image"].Value.ToString();
                string date = GrdScannedList.Rows[rowindex].Cells["Cheque Date"].Value.ToString();
                if (date != "")
                {
                    string[] dte = date.Split('-');
                    chqdt = dte[0] + dte[1] + dte[2].Substring(2, 2);
                }
                else
                {
                    chqdt = "";
                }
                chqdtpicker.Text = chqdt;
                txtchqamt.Text = GrdScannedList.Rows[rowindex].Cells["Amount"].Value.ToString() == "" ? "" : GrdScannedList.Rows[rowindex].Cells["Amount"].Value.ToString();
                txtaccno.Text = GrdScannedList.Rows[rowindex].Cells["A/c No"].Value.ToString() == "" ? "" : GrdScannedList.Rows[rowindex].Cells["A/c No"].Value.ToString();
                txtaccname.Text = GrdScannedList.Rows[rowindex].Cells["Drawee Name"].Value.ToString() == "" ? "" : GrdScannedList.Rows[rowindex].Cells["Drawee Name"].Value.ToString();
                PicFrontSide.Image = ReturnImage(Fbase);
                PicBackSide.Image = ReturnImage(Bbase);
                //chqdtpicker.Focus();
                count = 0;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            //Regex reg = new Regex(@"^(\d{1,2})/(\d{1,2})/(\d{4})$");
            //Match m = reg.Match(chqdtpicker.Text);
            //if (m.Success)
            //{
            //    int dd = int.Parse(m.Groups[1].Value);
            //    int mm = int.Parse(m.Groups[2].Value);
            //    int yyyy = int.Parse(m.Groups[3].Value);
            //    e.Cancel = dd < 1 || dd > 31 || mm < 1 || mm > 12 || yyyy > DateTime.Now.Year;
            //}
            //else e.Cancel = true;
            //if (e.Cancel)
            //{
            //    chqdtpicker.Focus();
            //    if (MessageBox.Show("Wrong date format. The correct format is dd-mm-yyyy\n+ dd should be between 1 and 31.\n+ mm should be between 1 and 12.\n+ yyyy should be before 2013", "Invalid date", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
            //        e.Cancel = false;
            //}
        }
        private void GrdScannedList_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //int numRows = GrdScannedList.Rows.Count;
                if (e.KeyChar == 13)
                {
                    Clear();
                    //int select = GrdScannedList.SelectedRows.Count;
                    //int selectedrow = Convert.ToInt32(GrdScannedList.Rows[GrdScannedList.Rows.Count - 1].Cells[0].Value);

                    //if (selectedrow == numRows)
                    //{
                    //}
                    //int check_count = check_Count;
                    //if (GrdScannedList.Rows[check_Count - 1]Cells[0].Selected)

                    //if (GrdScannedList.Rows[GrdScannedList.Rows.Count - 1].Cells[0].Selected)
                    //{
                    if (GrdScannedList.Rows[GrdScannedList.Rows.Count - 1].Cells["Amount"].Value.ToString() != "")
                    {
                        MessageBox.Show("Data Entry Completed..!", "CheckManagementSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //btnSave.Focus();
                        btnReview.Focus();
                    }
                    //}
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtchequeamt.Text != "")
            {
                DialogResult dg1 = MessageBox.Show("Do You Want  Update Cheque Amount?", "Check Mandate System", MessageBoxButtons.YesNo);
                if (dg1 == DialogResult.Yes)
                {
                    string Status = "";
                    ScannerBusiness scan = new ScannerBusiness();
                    BatchAMTUpdateEntities ent = new BatchAMTUpdateEntities();
                    ent.batch_no = gvscanlist.Rows[0].Cells["batch_no"].Value.ToString();
                    ent.Amount = txtchequeamt.Text.ToString();
                    Status = scan.UpdateBatchAmount(ent);
                    if (Status == "Success")
                    {
                        gvscanlist.Rows[0].Cells[2].Value = txtchequeamt.Text.ToString();
                        gvscanlist.Rows[0].Cells[7].Value = (Convert.ToDecimal(gvscanlist.Rows[0].Cells[2].Value.ToString()) - Convert.ToDecimal(gvscanlist.Rows[0].Cells[6].Value.ToString())).ToString();
                        txtchequeamt.Visible = false;
                        btnUpdate.Visible = false;
                    }
                }
            }
        }
        public bool checkaccountname()
        {
            bool validate = false;
            try
            {
                for (int i = 0; i < GrdScannedList.Rows.Count; i++)
                {
                    string ChequeDate = GrdScannedList.Rows[i].Cells[9].Value.ToString();
                    LogHelper.WriteLog(ChequeDate);
                    string Amount = GrdScannedList.Rows[i].Cells[10].Value.ToString();
                    LogHelper.WriteLog(Amount);
                    string AccountNo = GrdScannedList.Rows[i].Cells[11].Value.ToString();
                    LogHelper.WriteLog(AccountNo);
                    string accountname = GrdScannedList.Rows[i].Cells[12].Value.ToString();
                    LogHelper.WriteLog(accountname);

                    //string ChequeDate = GrdScannedList.Rows[i].Cells["cheque Date"].Value.ToString();
                    //LogHelper.WriteLog(ChequeDate);
                    //string Amount = GrdScannedList.Rows[i].Cells["Amount"].Value.ToString();
                    //LogHelper.WriteLog(Amount);
                    //string AccountNo = GrdScannedList.Rows[i].Cells["A/c No"].Value.ToString();
                    //LogHelper.WriteLog(AccountNo);
                    //string accountname = GrdScannedList.Rows[i].Cells["Drawee Name"].Value.ToString();
                    //LogHelper.WriteLog(accountname);

                    if (GrdScannedList.Rows[i].Cells[9].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[9].Value.ToString() == null)
                    {
                        validate = true;
                    }
                    if (GrdScannedList.Rows[i].Cells[10].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[10].Value.ToString() == null)
                    {
                        validate = true;
                    }
                    if (GrdScannedList.Rows[i].Cells[12].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[12].Value.ToString() == null)
                    {
                        validate = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return validate;
        }
        private void btn_Refersh_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            string accountname = string.Empty;
            string accountno = string.Empty;
            string acc_name = string.Empty;
            for (int i = 0; i < GrdScannedList.Rows.Count; i++)
            {
                 accountname = GrdScannedList.Rows[i].Cells[12].Value.ToString();

                if (GrdScannedList.Rows[i].Cells[12].Value.ToString() == "" || GrdScannedList.Rows[i].Cells[12].Value.ToString() == null)
                {
                    if (GrdScannedList.Rows[i].Cells[11].Value.ToString() != "" || GrdScannedList.Rows[i].Cells[11].Value.ToString() != null)
                    {
                         accountno = GrdScannedList.Rows[i].Cells[11].Value.ToString();
                         acc_name = LoadDraweeName(accountno);
                        GrdScannedList.Rows[i].Cells[12].Value = acc_name;
                    }
                }
                 accountname = string.Empty;
                 accountno = string.Empty;
                 acc_name = string.Empty;
            }
            btn_Refersh.Visible = false;
            PicLoad.Visible = false;
        }
        public DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {
            DataTable dtGroup = new DataTable();
            try
            {
                DataView dv = new DataView(i_dSourceTable);
                //getting distinct values for group column
                dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn });
                //adding column for the row count
                dtGroup.Columns.Add("SumOfAmount", typeof(int));
                //looping thru distinct values for the group, counting
                foreach (DataRow dr in dtGroup.Rows)
                {
                    dr["SumOfAmount"] = i_dSourceTable.Compute("sum(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //returning grouped/counted result
            return dtGroup;
        }
        private void btnReview_Click(object sender, EventArgs e)
        {
            try
            {
                string Amount = gvscanlist.Rows[0].Cells["differecne"].Value.ToString();
                if (Convert.ToDecimal(Amount) != 0)
                {
                    DialogResult dg1 = MessageBox.Show("Do You Want  Update Cheque Amount?", "Check Mandate System", MessageBoxButtons.YesNo);
                    if (dg1 == DialogResult.Yes)
                    {
                        txtchequeamt.Visible = true;
                        btnUpdate.Visible = true;
                        txtchequeamt.Focus();
                    }
                }
                else
                {
                    try
                    {
                        DataTable dt = (DataTable)GrdScannedList.DataSource;
                        DataTable Acdt = new DataTable();
                        //dt.Columns["A/C No"].ColumnName = "A/C No";
                        var newDt = dt.AsEnumerable()
                          .GroupBy(r => r.Field<string>(11).Trim())
                          .Select(g =>
                          {
                              var row = dt.NewRow();
                              row[11] = g.Key;
                              row[10] = g.Sum(r => Convert.ToDecimal(r.Field<string>(10)));
                              return row;
                          }).CopyToDataTable();
                        DataView dv = new DataView(newDt);

                        newDt = dv.ToTable(true, "A/C No", "Amount");
                        //Acdt = dv.ToTable(true, "A/C No");
                        DataColumn dc2 = new DataColumn();
                        dc2.ColumnName = "A/C No";
                        // dc1.ColumnName = "A/C No";
                        Acdt.Columns.Add(dc2);

                        DataColumn dc1 = new DataColumn();
                        dc1.ColumnName = "Amount";
                        // dc1.ColumnName = "A/C No";
                        Acdt.Columns.Add(dc1);

                        //   DataTable groupDT = GroupBy("Account_No", "Amount", dt);

                        ReviewCheckAmount objcheck = new ReviewCheckAmount(newDt, Amount, Acdt);
                        objcheck.FormClosed += new FormClosedEventHandler(sc_formclosd);
                        //objcheck.MdiParent = Checker.ActiveForm;
                        //objcheck.Dock = DockStyle.Fill;
                        //foreach (Form f in Application.OpenForms)
                        //{
                        //    if (f is ReviewCheckAmount)
                        //    {
                        //        f.Close();
                        //        return;
                        //    }
                        //}
                        objcheck.ShowDialog();
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
        private void sc_formclosd(object sender, EventArgs e)
        {
            //btnReview.Enabled = false;
            if (ReviewCheckAmount.status == "Success")
            {
                btnSave.Enabled = true;
                btnSave.Focus();
            }
        }
        #endregion

        private void PicBackSide_Click(object sender, EventArgs e)
        {

        }

        private void btn_persist_Click(object sender, EventArgs e)
        {
            PicLoad.Enabled = true;
            string chequedate = string.Empty ;
            string amount = string.Empty;
            string draweename = string.Empty;
            string accountno = string.Empty;
            try
            {
                DataTable dtable = new DataTable();
                foreach (DataGridViewColumn col in GrdScannedList.Columns)
                {
                    dtable.Columns.Add(col.Name);
                }

                dtable.Columns["A/C No"].ColumnName = "Account_No";
                foreach (DataGridViewRow row in GrdScannedList.Rows)
                {
                    if (inward_type.ToString() == "CMS")
                    {
                         chequedate = row.Cells["cheque Date"].Value == null ? "" : row.Cells["cheque Date"].Value.ToString();
                         amount = row.Cells["Amount"].Value == null ? "" : row.Cells["Amount"].Value.ToString();
                         draweename = row.Cells["Drawee Name"].Value == null ? "" : row.Cells["Drawee Name"].Value.ToString();
                        if (chequedate != "" && amount != "" && draweename != "")
                        {
                            DataRow dRow = dtable.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dtable.Rows.Add(dRow);
                        }
                    }
                    else
                    {
                         chequedate = row.Cells["cheque Date"].Value == null ? "" : row.Cells["cheque Date"].Value.ToString();
                         amount = row.Cells["Amount"].Value == null ? "" : row.Cells["Amount"].Value.ToString();
                         accountno = row.Cells["A/C No"].Value == null ? "" : row.Cells["A/C No"].Value.ToString();
                         draweename = row.Cells["A/C No"].Value == null ? "" : row.Cells["A/C No"].Value.ToString();
                        if (chequedate != "" && amount != "" && accountno != "" && draweename != "")
                        {
                            DataRow dRow = dtable.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dtable.Rows.Add(dRow);
                        }
                    }
                    chequedate = string.Empty;
                    amount = string.Empty;
                    draweename = string.Empty;
                    accountno = string.Empty;
                }
                DataColumn dcol = new DataColumn();
                dcol.ColumnName = "Batch No";
                dcol.DefaultValue = batch_num;
                dtable.Columns.Add(dcol);
                ScannerBusiness scan = new ScannerBusiness();
                dtable.Columns.Remove("Front Image");
                dtable.Columns.Remove("Back Image");
                string response = scan.PersistCheckerDetails(dtable);
                MessageBox.Show("Data Persisted.", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PicLoad.Enabled = false;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void txtchequeamt_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if ((sender as TextBox).Text.Count(Char.IsDigit) >= 16)
        //            e.Handled = true;
        //        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        //        {
        //            e.Handled = true;
        //        }
        //        if (Regex.IsMatch(txtchqamt.Text, @"\.\d\d") && e.KeyChar != 13 && e.KeyChar != 8)
        //        {
        //            e.Handled = true;
        //        }
        //        else
        //        {

        //            if (e.KeyChar == 13)
        //            {
        //                btnUpdate.Focus();
        //            }
        //        }
        //        if (Char.IsControl(e.KeyChar))
        //        {
        //            e.Handled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}

        //private void btn_persist_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        btn_persist.Enabled = false;
        //        Dtpersist.Columns.Add("sl no");
        //        Dtpersist.Columns.Add("Cheque No");
        //        Dtpersist.Columns.Add("Sort Code");
        //        Dtpersist.Columns.Add("Base Code");
        //        Dtpersist.Columns.Add("Tran Code");
        //        Dtpersist.Columns.Add("Cheque Date");
        //        Dtpersist.Columns.Add("Amount");
        //        Dtpersist.Columns.Add("A/C No");
        //        Dtpersist.Columns.Add("Drawee Name");

        //        DataRow Drpersist = null;
        //        foreach (DataGridViewRow dr in GrdScannedList.Rows)
        //        {
        //            Drpersist = Dtpersist.NewRow();
        //            Drpersist["sl no"] = dr.Cells["sl no"].Value;
        //            Drpersist["Cheque No"] = dr.Cells["Cheque No"].Value;
        //            Drpersist["Sort Code"] = dr.Cells["Sort Code"].Value;
        //            Drpersist["Base Code"] = dr.Cells["Base Code"].Value;
        //            Drpersist["Tran Code"] = dr.Cells["Tran Code"].Value;
        //            Drpersist["Cheque Date"] = dr.Cells["Cheque Date"].Value;
        //            Drpersist["Amount"] = dr.Cells["Amount"].Value;
        //            Drpersist["A/C No"] = dr.Cells["A/C No"].Value;
        //            Drpersist["Drawee Name"] = dr.Cells["Drawee Name"].Value;
        //            Dtpersist.Rows.Add(Drpersist);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }

        //}

        #region HideCode
        //private void txtaccname_TextChanged(object sender, EventArgs e)
        //{
        //    txtaccname.Text = txtaccname.Text.ToUpper();
        //}

        //private void gvscanlist_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            e.SuppressKeyPress = true;
        //            int iColumn = gvscanlist.CurrentCell.ColumnIndex;
        //            int iRow = gvscanlist.CurrentCell.RowIndex;
        //            if (iColumn == gvscanlist.Columns.Count - 1)
        //                gvscanlist.CurrentCell = gvscanlist[0, iRow + 1];
        //            else
        //                gvscanlist.CurrentCell = gvscanlist[iColumn + 1, iRow];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void chqdtpicker_KeyPress_1(object sender, KeyPressEventArgs e)
        //{
        //    string currentvalue = "";
        //    if (e.KeyChar == 13)
        //    {
        //        count += 1;

        //        if (count == 1)
        //        {
        //            prvvalue = chqdtpicker.Text;
        //            chqdtpicker.Clear();
        //            chqdtpicker.Focus();
        //        }
        //        else if (count == 2)
        //        {
        //            currentvalue = chqdtpicker.Text;
        //            prvvalue = chqdtpicker.Text;
        //            if (chqdtpicker.Text.Length < 6)
        //            {
        //                MessageBox.Show("Please Enter the Valid Date ");
        //                chqdtpicker.Text = "";
        //                chqdtpicker.Focus();
        //            }
        //            else
        //            {
        //                if (prvvalue.Equals(currentvalue))
        //                {
        //                    count = 0;
        //                    txtchqamt.Focus();
        //                    prvvalue = "";
        //                    currentvalue = "";
        //                }
        //                else
        //                {
        //                    count = 0;
        //                    chqdtpicker.Clear();
        //                    chqdtpicker.Focus();
        //                    MessageBox.Show("Enter Valid Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }

        //            }
        //        }
        //        else
        //        {
        //            count = 0;
        //            // chqdtpicker.Text = DateTime.Now.ToString();
        //            chqdtpicker.Focus();
        //            MessageBox.Show("Enter Valid Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //    }
        //}

        //private void pnlinfo_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void txtaccno_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string currentvalue = "";
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }

        //    if (e.KeyChar == 13)
        //    {

        //        count += 1;

        //        if (count == 1)
        //        {
        //            prvvalue = txtaccno.Text;
        //            txtaccno.Clear();
        //        }
        //        else if (count == 2)
        //        {
        //            currentvalue = txtaccno.Text;
        //            if (prvvalue.Equals(currentvalue))
        //            {
        //                count = 0;
        //                //cmbodraweename.Focus();
        //                GrdScannedList.Focus();
        //                //  GrdScannedList.CurrentCell = GrdScannedList.Rows[GrdScannedList.SelectedRows[0].Index].Cells[0];
        //                prvvalue = "";
        //                currentvalue = "";
        //            }
        //            else
        //            {
        //                count = 0;
        //                txtaccno.Clear();
        //                MessageBox.Show("Reenter The Account No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }

        //        }
        //        else
        //        {
        //            count = 0;
        //            txtaccno.Clear();
        //            MessageBox.Show("Reenter The Account No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //private void cmbodraweename_Leave(object sender, EventArgs e)
        //{
        //    int txchktamt = Convert.ToInt32(txtchqamt.Text != "" ? txtchqamt.Text : "0");
        //    string txtaccn = Convert.ToString(txtaccno.Text) == "" ? "" : Convert.ToString(txtaccno.Text);
        //    string txtnm = Convert.ToString(cmbodraweename.Text) == "" ? "" : Convert.ToString(cmbodraweename.Text);
        //    LoadCheker(previousSelectedRow, Convert.ToDateTime(chqdtpicker.Text), txchktamt, txtaccn, txtnm);
        //}
        //private void txtchequeamt_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string senderText = (sender as TextBox).Text;
        //    string senderName = (sender as TextBox).Name;
        //    string[] splitByDecimal = senderText.Split('.');
        //    int cursorPosition = (sender as TextBox).SelectionStart;

        //    if (!char.IsControl(e.KeyChar)
        //        && !char.IsDigit(e.KeyChar)
        //        && (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }


        //    if (e.KeyChar == '.'
        //        && senderText.IndexOf('.') > -1)
        //    {
        //        e.Handled = true;
        //    }


        //    if (!char.IsControl(e.KeyChar)
        //        && senderText.IndexOf('.') < cursorPosition
        //        && splitByDecimal.Length > 1
        //        && splitByDecimal[1].Length == 2)
        //    {
        //        e.Handled = true;
        //    }
        //}

        #endregion

        //private void GrdScannedList_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        switch (e.KeyData & Keys.KeyCode)
        //        {
        //            //case Keys.Up:
        //            case Keys.Right:
        //            //case Keys.Down:
        //            case Keys.Left:
        //                e.Handled = false;
        //                e.SuppressKeyPress = false;
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
    }
}




