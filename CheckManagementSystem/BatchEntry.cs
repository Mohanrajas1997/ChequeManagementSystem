using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;

namespace CheckManagementSystem
{
    public partial class BatchEntry : Form
    {
        public string cmbbrcodename;
        DataTable dtbranch1;
        string user_name = string.Empty;
        public string ModeFlag;

        public int InwardId = 0;
        int Tot_BatchedChq = 0;
        int Total_Balance_Chq = 0;
        int BatchGid = 0;
        int InwardChqCount = 0;

        Getinwardbusiness objfetch = new Getinwardbusiness();

        public BatchEntry()
        {
            InitializeComponent();
        }

        public BatchEntry(string _user_name)
        {
            InitializeComponent();
            user_name = _user_name;

        }

        public BatchEntry(int inwardgid, string InwardDate, string BranchName, string PickupLocation, int ChqCount, int BatchedChq, string Remarks)
        {
            try
            {


                ModeFlag = "New";
                InitializeComponent();
                InwardId = Convert.ToInt32(inwardgid);
                dateTimePicker1.Text = InwardDate.ToString();
                BranchName_Txt.Text = BranchName.ToString();
                Location_Txt.Text = PickupLocation.ToString();
                chqcnt.Text = Convert.ToString(ChqCount.ToString());
                InwardChqCount = ChqCount;
                Remark_Txt.Text = Remarks.ToString();
                Tot_BatchedChq = BatchedChq;


                LoadBatchEntry(inwardgid);
            }
            catch(Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           

        }

        private void LoadBatchEntry(int inwardgid)
        {
            try
            {
                int Totbatch_chq_count = 0;
                string inward_queue_code = "";

                gvbatchlist.Columns.Clear();
                BatchEntryBusiness ObjBatchEntry = new BatchEntryBusiness();
                inward_queue_code = ObjBatchEntry.GetInwardQueueCode(InwardId);
                DataTable dtSingleBatch = new DataTable();
                dtSingleBatch = ObjBatchEntry.GetBatchEntry(inwardgid);
                gvbatchlist.DataSource = dtSingleBatch;
                gvbatchlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gvbatchlist.Columns["Batch Id"].Visible = false;

                if (dtSingleBatch.Rows.Count > 0)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.Text = "Edit";
                    col.Name = "Action";
                    gvbatchlist.Columns.Add(col);

                    col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.HeaderText = "CTS Entry";
                    col.Text = "CTS Entry";
                    col.Name = "CTS Entry";
                    gvbatchlist.Columns.Add(col);
                }

                for (int i = 0; i < dtSingleBatch.Rows.Count; i++)
                {
                   int Totchq_count = Convert.ToInt32(dtSingleBatch.Rows[i]["Chq Count"]);
                   Totbatch_chq_count = Totbatch_chq_count + Totchq_count;
                }

                Total_Balance_Chq = InwardChqCount - Totbatch_chq_count;

                TotalChq_Txt.Text = Convert.ToString(Total_Balance_Chq.ToString());

                if (inward_queue_code == "C")
                {
                    MessageBox.Show("Cheque Count Completed..", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                Cmb_ChqType.Focus();
            }
            catch(Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Clear()
        {
            Deposit_Txt.Text = "";            
            BatchAmt_Txt.Text = "";

            cmbCtsAccType.Text = "";
            cmbCtsAccType.Tag = "";
            txtAccNo.Text = "";
            txtRetypeAccNo.Text = "";
            txtAccName.Text = "";

        }
        private void BatchEntry_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Enabled = false;
            try
            {
                if (ModeFlag == "New")
                {
                    pnlUpdateSubmit.Visible = false;
                    Clear();
                    LoadCustomerDetails();                   
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadCustomerDetails()
        {
            try
            {
                BatchEntryBusiness ObjBatch = new BatchEntryBusiness();
                DataTable dtcustomer = new DataTable();
                dtcustomer = ObjBatch.GetCustomerDetails();

                DataRow rows = dtcustomer.NewRow();
                rows["Customer Name"] = "--Select--";
                dtcustomer.Rows.InsertAt(rows, 0);
                Cmb_CustomerName.DataSource = dtcustomer;
                Cmb_CustomerName.DisplayMember = "Customer Name";
                Cmb_CustomerName.ValueMember = "Customer Code";
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // To Supress the event 
        }

      
        private void Inward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        
        //public bool BatchEntryValidation()
        //{
        //    string chqCount = TotalChq_Txt.Text;
        
        //    if (Cmb_ChqType.SelectedIndex < 0)
        //    {
        //        MessageBox.Show("Cheque Type Cannot be Empty! Please Fill the Cheque Type", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        Cmb_ChqType.Focus();
        //        return false;
        //    }
        //    if (Cmb_CustomerName.SelectedIndex == 0 && Cmb_ChqType.Text == "CMS")
        //    {
        //        MessageBox.Show("Customer Name Cannot be Empty! Please Fill the Customer Name", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        Cmb_CustomerName.Focus();
        //        return false;
        //    }
        //    if (chqCount == "" || chqCount == null || chqCount == "0")
        //    {
        //        MessageBox.Show("Check Count Cannot be Empty! Please Fill the Check Count", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        TotalChq_Txt.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(BatchAmt_Txt.Text)) BatchAmt_Txt.Text = "0";

        //    return true;
        //}     

       

        private void gvbatchlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                BatchGid = Convert.ToInt32(gvbatchlist.Rows[e.RowIndex].Cells["Batch Id"].Value);
                string cms_acc_type = gvbatchlist.Rows[e.RowIndex].Cells["CTS A/C Type"].Value.ToString();
                if (cms_acc_type != "") cms_acc_type = cms_acc_type.Substring(0, 1);

                if (gvbatchlist.Columns[e.ColumnIndex].Name == "Action")
                {
                    int col = gvbatchlist.CurrentCell.ColumnIndex;
                    int row = gvbatchlist.CurrentCell.RowIndex;
                    ModeFlag = "Edit";
                    pnlUpdateSubmit.Visible = true;
                    pnlAddSubmit.Visible = false;
                    
                    LoadCustomerDetails();

                     string Batch_No = gvbatchlist.Rows[row].Cells["Batch No"].Value.ToString();
                     Cmb_ChqType.Text = gvbatchlist.Rows[row].Cells["Cheque Type"].Value.ToString();
                     cmbCtsAccType.Text = gvbatchlist.Rows[row].Cells["CTS A/C Type"].Value.ToString();
                     txtAccNo.Text = gvbatchlist.Rows[row].Cells["CTS A/C No"].Value.ToString();
                     txtRetypeAccNo.Text = txtAccNo.Text;
                     txtAccName.Text = gvbatchlist.Rows[row].Cells["CTS A/C Name"].Value.ToString();
                     Deposit_Txt.Text = gvbatchlist.Rows[row].Cells["Deposit Slip No"].Value.ToString();
                     Cmb_CustomerName.SelectedValue = gvbatchlist.Rows[row].Cells["Customer Code"].Value.ToString();
                     TotalChq_Txt.Text = gvbatchlist.Rows[row].Cells["Chq Count"].Value.ToString();
                     BatchAmt_Txt.Text = gvbatchlist.Rows[row].Cells["Batch Amount"].Value.ToString();
                }

                if (gvbatchlist.Columns[e.ColumnIndex].Name == "CTS Entry" && gvbatchlist.Rows[e.RowIndex].Cells["Cheque Type"].Value.ToString() == "CTS")
                {
                    if (cms_acc_type == "S")
                    {
                        CtsSingleChqEntryNew obj = new CtsSingleChqEntryNew(BatchGid);
                        obj.ShowDialog();
                    }
                    else if (cms_acc_type == "M")
                    {
                        CtsMultipleChqEntryNew obj = new CtsMultipleChqEntryNew(BatchGid);
                        obj.ShowDialog();
                    }
                }

            }
            catch(Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to save the record?", "", MessageBoxButtons.YesNo))
                {
                    if (TotalChq_Txt.Text == "")
                    {

                        MessageBox.Show("cheque count Can't Empty ");

                    }
                    else
                    {
                        if (Convert.ToInt32(TotalChq_Txt.Text.ToString()) > 0)
                        {
                            if (BatchEntryValidation())
                            {
                                BatchEntryEntities ObjBatchEntity = new BatchEntryEntities();
                                ObjBatchEntity.BatchGid = 0;
                                ObjBatchEntity.BatchNo = "";
                                ObjBatchEntity.ChqType = Cmb_ChqType.Text;
                                ObjBatchEntity.CtsAccType = cmbCtsAccType.Tag.ToString();
                                ObjBatchEntity.CtsSingleAccNo = txtAccNo.Text;
                                ObjBatchEntity.CtsSingleAccHolderName = txtAccName.Text;
                                ObjBatchEntity.CustomerCode = Cmb_CustomerName.SelectedValue.ToString();
                                ObjBatchEntity.DepositSlipNo = Deposit_Txt.Text.Trim();
                                ObjBatchEntity.TotalChqCount = Convert.ToInt32(TotalChq_Txt.Text.Trim());
                                ObjBatchEntity.TotalBatchAmount = Convert.ToDouble(BatchAmt_Txt.Text.Trim());
                                ObjBatchEntity.InwardGid = InwardId;
                                ObjBatchEntity.created_by = "";
                                ObjBatchEntity.action = "Insert";

                                BatchEntryBusiness objBusiness = new BatchEntryBusiness();
                                string[] result = objBusiness.SaveBatchEntry(ObjBatchEntity);
                                ObjBatchEntity.msg = result[0].ToString();

                                MessageBox.Show(result[0].ToString());
                                if (result[1].ToString() == "1")
                                {
                                    Clear();
                                    LoadCustomerDetails();
                                    LoadBatchEntry(InwardId);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(user_name + "-" + ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancel_Click_2(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the record?", "", MessageBoxButtons.YesNo))
                {

                    BatchEntryEntities ObjBatchEntity = new BatchEntryEntities();
                    ObjBatchEntity.BatchGid = BatchGid;
                    ObjBatchEntity.BatchNo = "";
                    ObjBatchEntity.ChqType = Cmb_ChqType.Text;
                    if (cmbCtsAccType.Text != "") ObjBatchEntity.CtsAccType = cmbCtsAccType.Text.Substring(0,1);
                    ObjBatchEntity.CtsSingleAccNo = txtAccNo.Text;
                    ObjBatchEntity.CustomerCode = "";
                    ObjBatchEntity.DepositSlipNo = "";
                    ObjBatchEntity.TotalChqCount = Convert.ToInt32(TotalChq_Txt.Text.Trim());
                    ObjBatchEntity.TotalBatchAmount = Convert.ToDouble(BatchAmt_Txt.Text.Trim());
                    ObjBatchEntity.InwardGid = InwardId;
                    ObjBatchEntity.created_by = "";
                    ObjBatchEntity.action = "Delete";

                    BatchEntryBusiness objBusiness = new BatchEntryBusiness();
                    string[] result = objBusiness.SaveBatchEntry(ObjBatchEntity);
                    ObjBatchEntity.msg = result[0].ToString();

                    MessageBox.Show(result[0].ToString());
                    if (result[1].ToString() == "1")
                    {
                        Clear();
                        
                        LoadCustomerDetails();
                        LoadBatchEntry(InwardId);

                        pnlAddSubmit.Visible = true;
                        pnlUpdateSubmit.Visible = false;
                    }
                }
            }
            catch(Exception ex)
            {
                //LogHelper.WriteLog(user_name + "-" + ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool BatchEntryValidation()
        {
            try
            {
                cmbCtsAccType.Tag = "";

                if (BatchAmt_Txt.Text == "") BatchAmt_Txt.Text = "0";

                if (Cmb_ChqType.Text != "CMS" && Cmb_ChqType.Text != "CTS")
                {
                    MessageBox.Show("Invalid cheque type !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cmb_ChqType.Focus();
                    return false;
                }

                if (Cmb_ChqType.Text == "CMS")
                {
                    if (Cmb_CustomerName.SelectedIndex <= 0)
                    {
                        MessageBox.Show("Please select customer name !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cmb_CustomerName.Focus();
                        return false;
                    }
                }

                if (TotalChq_Txt.Text == "")
                {
                    MessageBox.Show("Cheque count cannot be empty !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TotalChq_Txt.Focus();
                    return false;
                }

                if (Convert.ToInt32(TotalChq_Txt.Text) <= 0)
                {
                    MessageBox.Show("Invalid cheque count !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TotalChq_Txt.Focus();
                    return false;
                }

                if (Cmb_ChqType.Text == "CTS")
                {
                    if (cmbCtsAccType.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select cts account type !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCtsAccType.Focus();
                        return false;
                    }

                    if (cmbCtsAccType.Text == "SINGLE")
                    {
                        if (txtAccNo.Text == "")
                        {
                            MessageBox.Show("Account no cannot be empty !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAccNo.Focus();
                            return false;
                        }

                        if (txtAccNo.Text != txtRetypeAccNo.Text)
                        {
                            MessageBox.Show("Account no not matched with retyped one !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtRetypeAccNo.Focus(); 
                            return false;
                        }

                        if (txtAccName.Text == "")
                        {
                            MessageBox.Show("Invalid account no !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAccNo.Focus();
                            return false;
                        }

                        cmbCtsAccType.Tag = "S";
                    }

                    if (cmbCtsAccType.Text == "MULTIPLE")
                    {
                        cmbCtsAccType.Tag = "M";
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to update the record?", "", MessageBoxButtons.YesNo))
                {
                    if (TotalChq_Txt.Text == "")
                    {
                        MessageBox.Show("cheque count Can't Empty ");
                    }
                    else
                    {
                        if (Convert.ToInt32(TotalChq_Txt.Text.ToString()) > 0)
                        {
                            if (BatchEntryValidation())
                            {
                                BatchEntryEntities ObjBatchEntity = new BatchEntryEntities();
                                ObjBatchEntity.BatchGid = BatchGid;
                                ObjBatchEntity.BatchNo = "";
                                ObjBatchEntity.ChqType = Cmb_ChqType.Text;
                                ObjBatchEntity.CtsAccType = cmbCtsAccType.Tag.ToString();
                                ObjBatchEntity.CtsSingleAccNo = txtAccNo.Text;
                                ObjBatchEntity.CtsSingleAccHolderName = txtAccName.Text;
                                ObjBatchEntity.CustomerCode = Cmb_CustomerName.SelectedValue.ToString();
                                ObjBatchEntity.DepositSlipNo = Deposit_Txt.Text.Trim();
                                ObjBatchEntity.TotalChqCount = Convert.ToInt32(TotalChq_Txt.Text.Trim());
                                ObjBatchEntity.TotalBatchAmount = Convert.ToDouble(BatchAmt_Txt.Text.Trim());
                                ObjBatchEntity.InwardGid = InwardId;
                                ObjBatchEntity.created_by = "";
                                ObjBatchEntity.action = "Update";

                                BatchEntryBusiness objBusiness = new BatchEntryBusiness();
                                string[] result = objBusiness.SaveBatchEntry(ObjBatchEntity);
                                ObjBatchEntity.msg = result[0].ToString();

                                MessageBox.Show(result[0].ToString());
                                if (result[1].ToString() == "1")
                                {
                                    Clear();
                                    LoadCustomerDetails();
                                    LoadBatchEntry(InwardId);

                                    pnlAddSubmit.Visible = true;
                                    pnlUpdateSubmit.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(user_name + "-" + ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cmb_ChqType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cmb_ChqType_Leave(object sender, EventArgs e)
        {
            txtAccNo.Enabled = false;
            txtRetypeAccNo.Enabled = false;

            if (Cmb_ChqType.Text == "CMS")
            {
                Cmb_CustomerName.Enabled = true;
                cmbCtsAccType.Enabled = false;
                Deposit_Txt.Enabled = true;
                Cmb_CustomerName.Focus();
            }
            else
            {
                Cmb_CustomerName.Enabled = false;
                Deposit_Txt.Enabled = false;
                cmbCtsAccType.Enabled = true;
                cmbCtsAccType.Focus();
            }
        }

        private void cmbCtsAccType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCtsAccType_Leave(object sender, EventArgs e)
        {
            if (cmbCtsAccType.Text == "SINGLE")
            {
                txtAccNo.Enabled = true;
                txtRetypeAccNo.Enabled = true;
            }
            else
            {
                txtAccNo.Enabled = false;
                txtRetypeAccNo.Enabled = false;
            }
        }

        private void txtAccNo_Enter(object sender, EventArgs e)
        {
            txtAccNo.PasswordChar = '\0';
            txtRetypeAccNo.PasswordChar = '*';
        }

        private void txtAccNo_Leave(object sender, EventArgs e)
        {
            txtAccNo.PasswordChar = '*';
            txtRetypeAccNo.PasswordChar = '\0';
        }

        private void txtRetypeAccNo_Leave(object sender, EventArgs e)
        {
            if (txtAccNo.Text != txtRetypeAccNo.Text && txtRetypeAccNo.Text != "")
            {
                MessageBox.Show("Retyped account no not matched !", "Account no mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRetypeAccNo.Focus();
                return;
            }

            MasterBusiness ObjMaster = new MasterBusiness();
            string acc_name = ObjMaster.GetAccHolderName(txtAccNo.Text);

            txtAccName.Text = acc_name;

            if (acc_name == "")
            {
                MessageBox.Show("Account no not available in the master ! Please verify/maintain the account no !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccNo.Focus();
                return;
            }

            txtRetypeAccNo.PasswordChar = '*';
            txtAccNo.PasswordChar = '\0';
        }

        private void txtRetypeAccNo_Enter(object sender, EventArgs e)
        {
            txtRetypeAccNo.PasswordChar = '\0';
            txtAccNo.PasswordChar = '*';
        }

        private void txtAccNo_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
