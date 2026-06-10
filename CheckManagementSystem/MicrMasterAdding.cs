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
    public partial class MicrMasterAdding : Form
    {
        public int Chqid = 0;
        public int Batchid = 0;
        public string Chq_Type = "";
        public MicrMasterAdding()
        {
            InitializeComponent();
            BankName_Txt.Focus();
        }


        public MicrMasterAdding(string MicrCode, int BatchGid, string ChqType)
        {
            InitializeComponent();
            Batchid = BatchGid;
            //Chqid = ChqGid;
            MicrNo_Txt.Text = MicrCode;
            Chq_Type = ChqType;
            //this.Text = this.Text + " (Cheque No : " + ChqNo + ")";
            BankName_Txt.Focus();


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
                    MasterBusiness master = new MasterBusiness();

                    if (BankName_Txt.Text.ToString() == "")
                    {
                        MessageBox.Show("Bank Name Can't be Empty ");
                        BankName_Txt.Focus();
                    }
                    else
                    {
                        
                        InwardBusiness objBusiness = new InwardBusiness();
                        string NewMicrCode = MicrNo_Txt.Text.Trim();
                        string Bank_Name = BankName_Txt.Text.Trim();
                        string Bank_Code = "";
                        string Branch_Name = BranchName_Txt.Text.Trim();
                        string ChqType = Chq_Type;
                        string Loginuser = AdminMasterBusiness.Usercode;
                        int i = 1;
                        string[] result = master.UploadMicrMaster(ChqType, NewMicrCode, Bank_Code, Bank_Name, Branch_Name, "", Loginuser, Convert.ToInt32(i));
                       // string[] result = objBusiness.SaveMicrCode(Batchid,Chqid, NewMicrCode);
                        MessageBox.Show(result[0].ToString());
                        if (result[1].ToString() == "1")
                        {
                            string[] results = master.UpdateBluckMicrCode(NewMicrCode, Batchid);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
                        }
                    }

                }
            }
            catch(Exception ex)
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
                

        private void MicrEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

     
    }
}
