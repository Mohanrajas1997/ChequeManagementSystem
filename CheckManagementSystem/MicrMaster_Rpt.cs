using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CheckManagementSystem
{
    public partial class MicrMaster_Rpt : Form
    {
        public int previousSelectedRow = -1;
        public int currectSelectedRow = -1;
        string[] status = new string[4];
        string root = string.Empty;
        //public string Filenames[];
        public MicrMaster_Rpt()
        {
            InitializeComponent();
        }
     
      
        private void Upload_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //LoadGriddetails();
        }
        
       
       
        private void btnref_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            lblstatus.Visible = true;
            try
            {
                string MicrCode = MicrCode_Txt.Text.Trim();
                string BankName = BankName_Txt.Text.Trim();
                string BranchName = BranchName_Txt.Text.Trim();
                string ConditionStatus = "";

                if (MicrCode != "")
                {
                    ConditionStatus = " where micr_code =" + "'" + MicrCode + "'";
                    
                }
                if (BankName != "")
                {
                    if (ConditionStatus !="")
                    {
                        ConditionStatus += "and bank_name =" + "'" + BankName + "'";
                    }
                    else
                    {
                        ConditionStatus = " where bank_name=" + "'" + BankName + "'";
                    }
                }
                if (BranchName != "")
                {
                     if (ConditionStatus !="")
                    {
                        ConditionStatus += "and branch_name =" + "'" + BranchName + "'";
                    }
                    else
                    {
                        ConditionStatus = " where branch_name=" + "'" + BranchName + "'";
                    }
                }

                if (ConditionStatus=="")
                {
                    ConditionStatus = "All";
                }
                gvuploadgrid.Columns.Clear();
                gvuploadgrid.DataSource = null;
                MasterRpt_Business Obj = new MasterRpt_Business();
                DataTable dt = new DataTable();
                dt = Obj.MicrMasterRpt(ConditionStatus,Cmb_ChqType.Text);
                gvuploadgrid.DataSource = dt;

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblstatus.Visible = false;
            }
            PicLoad.Visible = false;
            lblstatus.Visible = false;
        }
        private void btncls_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lstbtngen_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            
            try
            {
                if (gvuploadgrid.Rows.Count == 0)
                {
                    MessageBox.Show("No Records to found.");
                    return;
                }
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Micr Master";
                // storing header part in Excel  
                for (int i = 1; i < gvuploadgrid.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = gvuploadgrid.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i <  gvuploadgrid.Rows.Count; i++)
                {
                    for (int j = 0; j < gvuploadgrid.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = gvuploadgrid.Rows[i].Cells[j].Value.ToString();
                    }
                }
                string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                root = exePath + "\\Reports\\";
                //string root = DestinationFile;
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                // save the application  
                workbook.SaveAs(root + "MicrMaster_Rpt" + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
                MessageBox.Show("Export Excel Completed.");
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PicLoad.Visible = false;
                return;
            }
            PicLoad.Visible = false;
        }

        private void gvuploadgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                          
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void gvuploadgrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Upload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
