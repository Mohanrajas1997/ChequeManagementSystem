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
    public partial class frmImagePurge : Form
    {
        public frmImagePurge()
        {
            InitializeComponent();
        }

        private void frmImagePurge_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Visible = true;

                string BatchFromdate = "";
                string BatchTodate = "";
                
                if (Batch_Fromdate.Checked == true && Batch_to_Date.Checked == true)
                {
                    BatchFromdate = Batch_Fromdate.Value.ToString("yyyy-MM-dd");
                    BatchTodate = Batch_to_Date.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    MessageBox.Show("Please Select Fromdate and Todate!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Visible = false;
                    return;
                }

                DateTime date = new DateTime();
                date = DateTime.Now;

                DateTime to_datetime = new DateTime();
                to_datetime = Convert.ToDateTime(Batch_to_Date.Value);
                int n = (date - to_datetime).Days;
                
                if (n>30)
                {
                    AdminMasterBusiness Obj_SetImagepurge = new AdminMasterBusiness();
                    string[] result = Obj_SetImagepurge.SetScanImagePurge(BatchFromdate, BatchTodate);
                    if(result[1].ToString() == "1")
                    {
                        MessageBox.Show("Image Purge Completed!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result[0].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Less then 30 days in to date", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Visible = false;
                    Batch_to_Date.Focus();
                    return;
                }

                lblStatus.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
