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
    public partial class MicrEntry : Form
    {
        public int Chqid = 0;
        public int Batchid = 0;
        public string ChqType = "";

        public MicrEntry()
        {
            InitializeComponent();
            NewMicrNo_Txt.Focus();
        }


        public MicrEntry(int BatchGid, int ChqGid, string MicrCode, string ChqNo, string Chq_Type)
        {
            InitializeComponent();
            Batchid = BatchGid;
            Chqid = ChqGid;
            ChqType = Chq_Type;
            OldMicrNo_Txt.Text = MicrCode;
            this.Text = this.Text + " (Cheque No : " + ChqNo + ")";
            NewMicrNo_Txt.Focus();

        }


        private void MicrEntry_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CancelButton = btnClose;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to save the record?", "", MessageBoxButtons.YesNo))
                {
                    if (NewMicrNo_Txt.Text.ToString() == "")
                    {
                        MessageBox.Show("Micr Code Can't Empty ");
                        NewMicrNo_Txt.Focus();
                    }
                    else
                    {

                        InwardBusiness objBusiness = new InwardBusiness();
                        string NewMicrCode = NewMicrNo_Txt.Text.Trim();
                        string[] result = objBusiness.SaveMicrCode(Batchid, Chqid, NewMicrCode);
                        MessageBox.Show(result[0].ToString());
                        if (result[1].ToString() == "1")
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void NewMicrNo_Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt32(e.KeyChar);
            if ((ascii >= 48 && ascii <= 57) || (ascii == 8) || ascii == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void MicrEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void PicPlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChqType == "CTS")
                {
                    MicrMasterAdding objcheck = new MicrMasterAdding(OldMicrNo_Txt.Text, Batchid, ChqType);
                    objcheck.Top = this.Top + panel1.Top + panel1.Height - objcheck.Height;
                    objcheck.Left = this.Left + ((this.Width - objcheck.Width) / 2);
                    DialogResult result = objcheck.ShowDialog();
                    if (result != System.Windows.Forms.DialogResult.Cancel)
                    {
                        //NewMicrNo_Txt.Text = OldMicrNo_Txt.Text.Trim();
                        //btnSave_Click(sender,e);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Micr Adding only CTS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
