using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class Rejection_Rpt : Form
    {
        string root = string.Empty;
         public string ConditionStatus = "";

         public Rejection_Rpt()
        {
            InitializeComponent();
        }
        #region Methods
     
        private void LoadRevokedetails(string ConditionStatus)
        {
            try
            {


                gvscanlist.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvscanlist.DataSource = null;
                InwardBusiness ObjInward = new InwardBusiness();
                dtscanning = ObjInward.GetRevokeDetails(ConditionStatus);
                gvscanlist.DataSource = dtscanning;
                if (gvscanlist.Columns["Batch Gid"] != null)
                {
                    gvscanlist.Columns["Batch Gid"].Visible = false;
                    gvscanlist.Columns["Chq Gid"].Visible = false;
                    gvscanlist.Columns["discreason_gid"].Visible = false;
                    gvscanlist.Columns["Chq No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvscanlist.Columns["Chq Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvscanlist.Columns["Acc No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dtscanning.Rows.Count == 0)
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
                this.WindowState = FormWindowState.Maximized;

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
                cmbbrcode.DisplayMember = "Branch Name";
                cmbbrcode.ValueMember = "Branch Code";

                DataRow dr = dtlocation.NewRow();
                dr["LOCATION_CODE"] = "--Select--";
                dtlocation.Rows.InsertAt(dr, 0);

                cmblocation.DataSource = dtlocation;
                cmblocation.DisplayMember = "LOCATION_CODE";
                cmblocation.ValueMember = "LOCATION_CODE";
                ConditionStatus = "All";
                LoadRevokedetails(ConditionStatus);

                CancelButton = btnClose;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConditionStatus = "All";
            LoadRevokedetails(ConditionStatus);
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

                if (Inward_Fromdate.Checked == true && Inward_Todate.Checked == true)
                {
                    InwardFromdate = Inward_Fromdate.Value.ToString("yyyy-MM-dd");
                    InwardTodate = Inward_Todate.Value.ToString("yyyy-MM-dd");

                }

                string BranchCode = "";
                string LocationCode = "";

                string lotno = LotNo_Txt.Text;
                string ChqNo = chqno_txt.Text;

                if (cmbbrcode.SelectedIndex > 0) BranchCode = cmbbrcode.SelectedValue.ToString();
                if (cmblocation.SelectedIndex > 0) LocationCode = cmblocation.SelectedValue.ToString();

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

                LoadRevokedetails(ConditionStatus);

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

      

        private void lstbtngen_click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;

            try
            {
                if (gvscanlist.Rows.Count == 0)
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
                worksheet.Name = "Rejection";


                // storing header part in Excel  
                for (int i = 1; i < gvscanlist.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = gvscanlist.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < gvscanlist.Rows.Count; i++)
                {
                    for (int j = 0; j < gvscanlist.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = gvscanlist.Rows[i].Cells[j].Value.ToString();
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
                workbook.SaveAs(root + "Rejection_Rpt" + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
