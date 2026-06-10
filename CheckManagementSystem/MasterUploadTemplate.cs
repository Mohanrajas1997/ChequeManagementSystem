using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Web;

namespace CheckManagementSystem
{
    public partial class MasterUploadTemplate : Form
    {

        DataTable dtMicrList = new DataTable();
        int comp_id = 0;
        string root = string.Empty;
        string UserName = "";
        
        public MasterUploadTemplate()
        {
            InitializeComponent();
        }

        public MasterUploadTemplate(string user_name)
        {
            InitializeComponent();
            UserName = user_name;
        }

        public MasterUploadTemplate(int _comp_id)
        {
            InitializeComponent();
            comp_id = _comp_id;
        }

        MasterBusiness objmaster = new MasterBusiness();
        private void LoadMastersForTemplate()
        {
            try
            {
                cmb_master.Items.Clear();
                cmb_master.Items.Add("Account Master");
                cmb_master.Items.Add("Alternate Micr Master");
                cmb_master.Items.Add("Bank Master");
                cmb_master.Items.Add("CMS Micr Master");
                cmb_master.Items.Add("CTS Micr Master");
                cmb_master.Items.Add("Customer Master");
                cmb_master.Items.Add("Location Master");
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MasterUploadTemplate_Load(object sender, EventArgs e)
        {
            try
            {

             
                //cmb_master.SelectedIndex = 1;
                lblStatus.Visible = true;
                LoadMastersForTemplate();
                lblStatus.Visible = false;
                //TheamClass.SetTheam(this);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DownloadTemplate()
        {
            string status = "";
            try
            {
                if (cmb_master.Text != "")
                {
                    try
                    {
                        //string[] field = tabMasters.SelectedTab.Name.Split('/');
                        string sss = cmb_master.SelectedIndex.ToString();
                        //string[] field = cmb_master.SelectedValue.ToString();
                        int master_id = Convert.ToInt32(GetMaster_Id(cmb_master.Text));
                        MasterEntities.FiledEntities fild = new MasterEntities.FiledEntities();
                        fild.master_id = master_id;
                        MasterEntities.FiledEntities.FileList fields = new MasterEntities.FiledEntities.FileList();
                        fields = objmaster.GetMasterFields(fild);
                        string ExcelWritePath = ConfigurationManager.AppSettings["ExcelWritePath"].ToString();
                        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                        if (xlApp == null)
                        {
                            status = "failed";
                            return status;
                        }
                        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;

                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        for (int i = 1; i <= fields.Fileds.Count; i++)
                        {
                            xlWorkSheet.Cells[1, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            xlWorkSheet.Cells[1, i].Font.Bold = true;

                            Microsoft.Office.Interop.Excel.Range formatRange;
                            formatRange = xlWorkSheet.get_Range("a1", "o1");
                            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightPink);
                            xlWorkSheet.Cells[1, i] = "LightPink";
                            xlWorkSheet.Columns[i].ColumnWidth = 18;
                        }

                        for (int i = 0; i < fields.Fileds.Count; i++)
                        {
                            xlWorkSheet.Cells[1, (i + 1)] = fields.Fileds[i].field_name.ToString();
                        }
                        string uploadcode = fields.Fileds[0].master_name.ToString();
                        //xlWorkBook.SaveAs(ExcelWritePath + uploadcode + ".xlsx",
                        xlWorkBook.SaveAs(root + uploadcode + ".xls",
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                        xlWorkBook.Close(true, Missing.Value, Missing.Value);
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlWorkSheet);
                        Marshal.ReleaseComObject(xlWorkBook);
                        Marshal.ReleaseComObject(xlApp);
                        status = "Success";

                        System.Diagnostics.Process.Start(root + uploadcode + ".xls");
                    }
                    catch (Exception ex)
                    {
                        //LogHelper.WriteLog(ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Master For Download the Template");
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }


        private void btndownloadtemplate_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                root = exePath + "\\Dowloaded Templates\\";
                //string root = DestinationFile;
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                lblStatus.Visible = true;
                string respone = DownloadTemplate();
                if (respone == "Success")
                {
                    MessageBox.Show("Template Downloaded Successfully....", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBrowse.Enabled = true;
                }
                else
                {
                    //LogHelper.WriteLog(respone);
                    MessageBox.Show(respone, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lblStatus.Visible = false;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string DynamicUpload()
        {
            string status = "";
            if (cmb_master.Text != "")
            {
                MasterEntities.UploadMasterEntities uploaddt = new MasterEntities.UploadMasterEntities();
                string[] query;
                string[] ExcelFields;
                string[] DBFields;
                string selectedfields = "";
                string master_name = "";
                string rowvalues = "";
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                string file = txtfilepath.Text;
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
                Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet
                Microsoft.Office.Interop.Excel.Range range = xlWorksheet.UsedRange;
                try
                {
                    //string[] field = tabMasters.SelectedTab.Name.Split('/');
                    //int master_id = Convert.ToInt32(field[1].ToString());
                    int master_id = Convert.ToInt32(GetMaster_Id(cmb_master.Text));
                    MasterEntities.FiledEntities fild = new MasterEntities.FiledEntities();
                    fild.master_id = master_id;
                    MasterEntities.FiledEntities.FileList fields = new MasterEntities.FiledEntities.FileList();
                    fields = objmaster.GetMasterFields(fild);
                    master_name = fields.Fileds[0].master_name.ToString();
                    DBFields = new string[fields.Fileds.Count];
                    for (int i = 0; i <= (fields.Fileds.Count - 1); i++)
                    {
                        DBFields[(i)] = fields.Fileds[i].field_name.ToString();
                    }



                    if (xlApp == null)
                    {
                        status = "failed";
                        return status;
                    }
                    //string file = @"C:\Users\emp10135\Desktop\Bank Master.xlsx";

                    ExcelFields = new string[range.Columns.Count];
                    for (int i = 1; i <= range.Columns.Count; i++)
                    {
                        if (((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Value2 != null)
                        {
                            ExcelFields[(i - 1)] = ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Value2;
                            if (i == 1)
                            {
                                selectedfields = ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Value2;
                            }
                            else
                            {
                                selectedfields = selectedfields + "," + ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Value2; ;
                            }
                        }
                    }
                    List<string> y = ExcelFields.ToList<string>();
                    y.RemoveAll(p => string.IsNullOrEmpty(p));
                    ExcelFields = y.ToArray();
                    bool areEqual = DBFields.SequenceEqual(ExcelFields);
                    query = new string[(range.Rows.Count - 1)];
                    if (areEqual == true)
                    {
                        if (range.Rows.Count > 0)
                        {
                            //string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + file + "';Extended Properties='Excel 8.0 Xml;IMEX=1'";
                            //string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
                            string excelConnectionString = "";

                            if (file.Split('.')[file.Split('.').Length - 1].ToLower() == "xlsx")
                                excelConnectionString = excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
                            else
                                excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + file + ";" + "Extended Properties=Excel 8.0;";
        


                            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                            excelConnection.Open();
                            string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                            OleDbCommand cmd = new OleDbCommand("Select " + selectedfields + " from [" + tableName + "]", excelConnection);
                            DataSet ds = new DataSet();
                            OleDbDataAdapter da = new OleDbDataAdapter("Select " + selectedfields + " from [" + tableName + "]", excelConnection);
                            da.Fill(ds);
                            DataTable dt = ds.Tables[0];                          
                            int k = 0;
                            MasterBusiness master = new MasterBusiness();
                            if (master_name.ToUpper() == "ACCOUNT MASTER")
                            {
                                for (long i = 0; i < dt.Rows.Count; i++)
                                {

                                    string AccountName = dt.Rows[Convert.ToInt32(i)]["ACCOUNT_NAME"].ToString();
                                    string AccountNo = dt.Rows[Convert.ToInt32(i)]["ACCOUNT_NO"].ToString();
                                    string Loginuser = UserName;
                                    string[] result = master.UploadAccountMaster(AccountName, AccountNo, Loginuser, Convert.ToInt32(i));
                                    if (result[1] == "1")
                                    {
                                        k++;
                                    }
                                }
                            }
                            else if (master_name.ToUpper() == "LOCATION MASTER")
                            {
                                for (long i = 0; i < dt.Rows.Count; i++)
                                {

                                    string PickupLocation = dt.Rows[Convert.ToInt32(i)]["PICKUP_LOCATION"].ToString();
                                    string LocationCode = dt.Rows[Convert.ToInt32(i)]["LOCATION_CODE"].ToString();
                                    string Loginuser = UserName;
                                    string[] result = master.UploadLocationMaster(PickupLocation, LocationCode, Loginuser, Convert.ToInt32(i));
                                    if (result[1] == "1")
                                    {
                                        k++;
                                    }
                                }
                            }
                            else if (master_name.ToUpper() == "CMS MICR MASTER")
                            {
                                for (long i = 0; i < dt.Rows.Count; i++)
                                {

                                    string Micr_code = dt.Rows[Convert.ToInt32(i)]["MICR_CODE"].ToString();
                                    string Bank_Code = dt.Rows[Convert.ToInt32(i)]["BANK_CODE"].ToString();
                                    string Bank_Name = dt.Rows[Convert.ToInt32(i)]["BANK_NAME"].ToString();
                                    string Branch_Name = dt.Rows[Convert.ToInt32(i)]["BRANCH_NAME"].ToString();
                                    string Branch_Code = dt.Rows[Convert.ToInt32(i)]["BRANCH_CODE"].ToString();
                                    string Chq_Type = dt.Rows[Convert.ToInt32(i)]["CHQ_TYPE"].ToString();
                                    string Loginuser = UserName;
                                    if (Micr_code.Length == 9)
                                    {
                                        string[] result = master.UploadMicrMaster(Chq_Type, Micr_code,Bank_Code, Bank_Name, Branch_Name, Branch_Code, Loginuser, Convert.ToInt32(i));
                                        if (result[1] == "1")
                                        {
                                            k++;
                                        }
                                    }
                                }
                            }
                            else if (master_name.ToUpper() == "CTS MICR MASTER")
                            {
                                for (long i = 0; i < dt.Rows.Count; i++)
                                {

                                    string Micr_code = dt.Rows[Convert.ToInt32(i)]["MICR_CODE"].ToString();
                                    string Bank_Code = dt.Rows[Convert.ToInt32(i)]["BANK_CODE"].ToString();
                                    string Bank_Name = dt.Rows[Convert.ToInt32(i)]["BANK_NAME"].ToString();
                                    string Branch_Name = dt.Rows[Convert.ToInt32(i)]["BRANCH_NAME"].ToString();
                                    string Chq_Type = dt.Rows[Convert.ToInt32(i)]["CHQ_TYPE"].ToString();
                                    string Loginuser = UserName;
                                    if (Micr_code.Length == 9)
                                    {
                                        string[] result = master.UploadMicrMaster(Chq_Type, Micr_code, Bank_Code, Bank_Name, Branch_Name, "", Loginuser, Convert.ToInt32(i));
                                        Application.DoEvents();
                                        lblStatus.Text = "Out of " + dt.Rows.Count.ToString() + " reading " + i.ToString() + " record ...";
 
                                        if (result[1] == "1")
                                        {
                                            k++;
                                        }
                                    }
                                }
                            }
                            else if (master_name.ToUpper() == "CUSTOMER MASTER")
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {

                                    string Customer_code = dt.Rows[i]["CUSTOMER_CODE"].ToString();
                                    string Customer_Name = dt.Rows[i]["CUSTOMER_NAME"].ToString();                                   
                                    string Loginuser = "";
                                    string[] result = master.UploadCustomerMaster(Customer_code, Customer_Name, Loginuser, i);
                                    if (result[1] == "1")
                                    {
                                        k++;
                                    }

                                }
                            }
                            else if (master_name.ToUpper() == "BANK MASTER")
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {

                                    string bank_code = dt.Rows[i]["BANK_CODE"].ToString();
                                    string bank_name = dt.Rows[i]["BANK_NAME"].ToString();
                                    string bank_micr_code = dt.Rows[i]["BANK_MICR_CODE"].ToString();
                                    string Loginuser = "";
                                    string[] result = master.UploadBankMaster(bank_code, bank_name,bank_micr_code, Loginuser, i);
                                    if (result[1] == "1")
                                    {
                                        k++;
                                    }

                                }
                            }
                            else if (master_name.ToUpper() == "ALTERNATE MICR MASTER")
                            {
                                for (long i = 0; i < dt.Rows.Count; i++)
                                {
                                    string MicrCode = dt.Rows[Convert.ToInt32(i)]["MICR_CODE"].ToString().Trim();
                                    string AlternateMicrCode = dt.Rows[Convert.ToInt32(i)]["ALTERNATE_MICR_CODE"].ToString().Trim();
                                    string BranchCode = dt.Rows[Convert.ToInt32(i)]["BRANCH_CODE"].ToString().Trim();
                                    string ChqType = dt.Rows[Convert.ToInt32(i)]["CHQ_TYPE"].ToString().Trim();
                                    string DeleteFlag = dt.Rows[Convert.ToInt32(i)]["DELETE_FLAG"].ToString().Trim();
                                    string LoginUser = UserName;
                                    string[] result = master.UploadAlterNateMicrCode(ChqType,MicrCode, AlternateMicrCode, BranchCode, LoginUser, DeleteFlag, Convert.ToInt32(i));
                                    if (result[1] == "1")
                                    {
                                        k++;
                                    }

                                }
                            }

                            status = String.Concat("Out of ", dt.Rows.Count, " record(s) ", k, " record(s) imported successfully ! ");
                            excelConnection.Close();
                            MessageBox.Show(status);
                            status = "success";                          
                        }
                        else
                        {

                            MessageBox.Show("There is no Records in Excel Sheet. Please Update Valid Excel..", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            status = "failed";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Excel! Please Check it...", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        status = "failed";
                    }
                    xlWorkbook.Close(true, Missing.Value, Missing.Value);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook);
                    Marshal.ReleaseComObject(xlApp);
                }
                catch (Exception ex)
                {
                    xlWorkbook.Close(true, Missing.Value, Missing.Value);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook);
                    Marshal.ReleaseComObject(xlApp);
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = "failed";
                }
            }
            else
            {
                MessageBox.Show("Please Select the Master for Upload the Data");
            }
            return status;
        }
        private string tablename(string master_name)
        {
            try
            {
                switch (master_name)
                {
                    case "Bank Master":
                        master_name = "cms_mst_bankmaster";
                        break;
                    case "Location Master":
                        master_name = "cms_mst_locationmaster";
                        break;
                    case "Branch Master":
                        master_name = "cms_mst_branchmaster";
                        break;
                    case "Customer Master":
                        master_name = "cms_mst_customermaster";
                        break;
                    case "Account Master":
                        master_name = "cms_mst_accountmaster";
                        break;
                    case "Customer Wise Source Dump":
                        master_name = "cms_mst_customerwisesourcedumpmaster";
                        break;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return master_name;
        }
        private string GetMaster_Id(string master_name)
        {
            string master_id = "0";
            try
            {
                switch (master_name)
                {
                    //case "Bank Master":
                    //    master_name = "1";
                    //    break;
                    case "Location Master":
                        master_name = "2";
                        break;
                    //case "Branch Master":
                    //    master_name = "3";
                    //    break;
                    case "Customer Master":
                        master_name = "4";
                        break;
                    case "Account Master":
                        master_name = "5";
                        break;
                    //case "Customer Wise Source Dump":
                    //    master_name = "6";
                    //    break;
                    case "CMS Micr Master":
                        master_name = "10";
                        break;
                    case "Alternate Micr Master":
                        master_name = "11";
                        break;
                    case "CTS Micr Master":
                        master_name = "12";
                        break;
                    case "Bank Master":
                        master_name = "13";
                        break;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return master_name;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Visible = true;
                if (txtfilepath.Text == "")
                {
                    MessageBox.Show("Kindly Select The File");
                    return;
                }
                MasterBusiness master = new MasterBusiness();
              

                string response = DynamicUpload();
                if (response == "success")
                {
                    MessageBox.Show("Data Uploaded Successfully...", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Uploaded Failed...", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lblStatus.Visible = false;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            int master_id = Convert.ToInt32(GetMaster_Id(cmb_master.Text));
            OpenFileDialog fg = new OpenFileDialog();
            DialogResult result = fg.ShowDialog();
            txtfilepath.Text = fg.FileName;
            btnUpload.Enabled = true;
            if (master_id == 3)
            {
                btnUpload.Enabled = true;
            }
        }

        //private void cmb_master_Leave(object sender, EventArgs e)
        //{
        //    txtfilepath.Text = "";
        //}

        //private void cmb_master_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    txtfilepath.Text = "";
        //}

        private void cmb_master_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfilepath.Text = "";
            int master_id = Convert.ToInt32(GetMaster_Id(cmb_master.Text));
          
            //if (!Directory.Exists(@"D:/" + "CheckMandateTemplates" + "Account Master"))
            // {
            //     btndownloadtemplate.Enabled = false;
            // }


        }

        private void btn_valid_Click(object sender, EventArgs e)
        {
            try
            {

                ScannerBusiness sb = new ScannerBusiness();
                dtMicrList = sb.GetMicrList();
                dtMicrList = dtMicrList.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field =>
                          field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
                string file = txtfilepath.Text;
                string excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + file + ";" + "Extended Properties=Excel 8.0;";

                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                excelConnection.Open();
                string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                OleDbCommand cmd = new OleDbCommand("Select MICR_CODE from [" + tableName + "]", excelConnection);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter("Select MICR_CODE  from [" + tableName + "]", excelConnection);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                bool validate = false;
                string temp = " ";
                //compare columns.
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Exceldata = dt.Rows[i]["MICR_CODE"].ToString().ToUpper();

                    for (int j = 0; j < dtMicrList.Rows.Count; j++)
                    {
                        string Dbdata = dtMicrList.Rows[j]["MICR_CODE"].ToString().ToUpper();
                        if (Exceldata == Dbdata)
                        {
                            temp = temp + "," + Exceldata;
                            validate = true;
                            break;
                        }
                    }
                }

                if (validate)
                {
                    MessageBox.Show(temp + " MICR Code is already Exist");
                    btnUpload.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Validation Completed");
                    btnUpload.Enabled = true;
                    btnUpload.Focus();
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btn_valid_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        ScannerBusiness sb = new ScannerBusiness();
        //        dtMicrList = sb.GetMicrList();
        //        dtMicrList = dtMicrList.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field =>
        //                  field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();
        //        string file = txtfilepath.Text;
        //        string excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + file + ";" + "Extended Properties=Excel 8.0;";

        //        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
        //        excelConnection.Open();
        //        string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
        //        OleDbCommand cmd = new OleDbCommand("Select MICR_CODE from [" + tableName + "]", excelConnection);
        //        DataSet ds = new DataSet();
        //        OleDbDataAdapter da = new OleDbDataAdapter("Select MICR_CODE  from [" + tableName + "]", excelConnection);
        //        da.Fill(ds);
        //        DataTable dt = ds.Tables[0];

        //        bool validate = false;
        //        string temp = " ";
        //        //compare columns.
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string Exceldata = dt.Rows[i]["MICR_CODE"].ToString().ToUpper();

        //            for (int j = 0; j < dtMicrList.Rows.Count; j++)
        //            {
        //                string Dbdata = dtMicrList.Rows[j]["MICR_CODE"].ToString().ToUpper();
        //                if (Exceldata == Dbdata)
        //                {
        //                    temp = temp + "," + Exceldata;
        //                    validate = true;
        //                    break;
        //                }
        //            }
        //        }

        //        if (validate)
        //        {
        //            MessageBox.Show(temp + " MICR Code is already Exist");
        //            btnUpload.Enabled = false;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Validation Completed");
        //            btnUpload.Enabled = true;
        //            btnUpload.Focus();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}

    }
}
