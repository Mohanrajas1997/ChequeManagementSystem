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
    public partial class UploadMICR : Form
    {
        public UploadMICR()
        {
            InitializeComponent();
        }
      
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtexmicr.Text != "")
                {
                    if (cmbloc.Text != "")
                    {
                        if (txtupdmicr.Text != "")
                        {
                            UploadMicrEntites updmicr = new UploadMicrEntites();
                            string updmic = "";
                            updmicr.Ex_micr = Convert.ToInt32(txtexmicr.Text);
                            updmicr.Location = cmbloc.Text;
                            updmicr.Update_micr = Convert.ToInt32(txtupdmicr.Text);
                            UploadmicrBusiness objbus = new UploadmicrBusiness();
                            updmic = objbus.saveuploadmicr(updmicr);
                            if (updmic == "")
                            {
                                MessageBox.Show("Updated failed because invalid Exmicr.!");
                            }
                            else
                            {
                                MessageBox.Show(updmic);
                            }
                            txtexmicr.Clear();
                            txtupdmicr.Clear();
                            cmbloc.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Update MICR Cannot Be Empty");
                            txtupdmicr.Focus();
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Location Cannot Be Empty");
                        cmbloc.Focus();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Ex MICR Cannot Be Empty");
                    txtexmicr.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtexmicr_Leave(object sender, EventArgs e)
        {
            //if (txtexmicr.Text != "")
            //{
            //if (txtexmicr.TextLength < 9)
            //{
            //    MessageBox.Show("Please Enter The Valid MICR");
            //    txtexmicr.Clear();
            //    txtexmicr.Focus();
            //    return;
            //}
            //}
            //else
            //{
            //    MessageBox.Show("Ex MICR Cannot Be Empty");
            //    txtexmicr.Focus();
            //    return;
            //}
            if(txtexmicr.Text != "")
            {
                int Getex_micr = Convert.ToInt32(txtexmicr.Text);
                DataTable dt = new DataTable();
                UploadmicrBusiness objupdmicr = new UploadmicrBusiness();
                dt = objupdmicr.Getuploadmicr(Getex_micr);
                GrdUpdMicr.DataSource = dt;
            }
           
            
        }

        private void cmbloc_Leave(object sender, EventArgs e)
        {
            if (cmbloc.Text == "")
            {
                MessageBox.Show("Location Cannot Be Empty");
                cmbloc.Focus();
                return;
            }
        }

        private void txtupdmicr_Leave(object sender, EventArgs e)
        {
            if (txtupdmicr.Text != "")
            {
                if (txtupdmicr.TextLength < 9)
                {
                    MessageBox.Show("Please Enter The Valid MICR");
                    txtupdmicr.Clear();
                    txtupdmicr.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Update MICR Cannot Be Empty");
                txtexmicr.Focus();
                return;
            }
        }

        private void UploadMICR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtexmicr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtupdmicr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int exmicr =Convert.to txtexmicr.Text;
            for (int i = 0; i < GrdUpdMicr.Rows.Count;i++ )
            {
                string Loc = GrdUpdMicr.Rows[i].Cells["Location"].Value.ToString();
                string GetLoc = cmbloc.Text;
                if (Loc == GetLoc)
                {
                    MessageBox.Show(GetLoc + " Location is already Exists in Below Grid");
                    cmbloc.Focus();
                }
               
            }

                
        }

        private void txtexmicr_Click(object sender, EventArgs e)
        {
            if (txtexmicr.Text != "")
            {
                if (txtexmicr.TextLength < 9)
                {
                    MessageBox.Show("Please Enter The Valid MICR");
                    txtexmicr.Clear();
                    txtexmicr.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ex MICR Cannot Be Empty");
                txtexmicr.Focus();
                return;
            }
        }

        private void cmbloc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
