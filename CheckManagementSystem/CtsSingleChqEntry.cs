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
    public partial class CtsSingleChqEntry : Form
    {
        double batch_amt = 0;
        double chq_amt = 0;
        double sub_chq_amt = 0;
        double chq_tot_amt = 0;
        double diff_amt = 0;

        int batch_chq_count = 0;
        int entered_chq_count = 0;
        int pend_chq_count = 0;
        int batch_gid = 0;
        int chq_gid = 0;
        int sub_chq_count = 0;

        public CtsSingleChqEntry(int _batch_gid)
        {
            InitializeComponent();
            batch_gid = _batch_gid;
        }

        private void CtsSingleChqEntry_Load(object sender, EventArgs e)
        {
            load_batch(batch_gid);
            KeyPreview = true;
        }
        private void load_batch(int batch_gid)
        {
            try
            {
                BatchEntryBusiness obj = new BatchEntryBusiness();
                DataTable dt;
                dt = obj.GetBatch(batch_gid);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["cts_acc_type"].ToString() != "S")
                    {
                        MessageBox.Show("Batch not in CTS Single !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }

                    txtBatchDate.Text = ((DateTime)dt.Rows[0]["batch_date"]).ToString("dd-MM-yyyy");
                    txtBatchNo.Text = dt.Rows[0]["batch_no"].ToString();
                    txtDepSlipNo.Text = dt.Rows[0]["dep_slip_no"].ToString();
                    txtChqType.Text = dt.Rows[0]["chq_type"].ToString();
                    txtCtsAccType.Text = "SINGLE";
                    txtBatchChqCount.Text = dt.Rows[0]["tot_chq_count"].ToString();
                    txtBatchAmt.Text = string.Format("{0:0.00}", dt.Rows[0]["tot_batch_amount"]);
                    txtCtsAccNo.Text = dt.Rows[0]["cts_acc_no"].ToString();
                    txtCtsAccHolderName.Text = dt.Rows[0]["cts_acc_holder"].ToString();

                    batch_amt = Math.Round((double)dt.Rows[0]["tot_batch_amount"], 2);
                    batch_chq_count = (int)dt.Rows[0]["tot_chq_count"];

                    load_chq(batch_gid);
                }
                else
                {
                    MessageBox.Show("Invalid batch !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CtsSingleChqEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtChqNo_Enter(object sender, EventArgs e)
        {
            txtChqNo.PasswordChar = '\0';
            txtRetypeChqNo.PasswordChar = '*';
        }

        private void txtChqNo_Leave(object sender, EventArgs e)
        {
            txtChqNo.PasswordChar = '*';
            txtRetypeChqNo.PasswordChar = '\0';
        }

        private void txtRetypeChqNo_Leave(object sender, EventArgs e)
        {
            if (txtChqNo.Text != txtRetypeChqNo.Text && txtRetypeChqNo.Text != "")
            {
                MessageBox.Show("Retyped cheque no not matched !", "Cheque Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetypeChqNo.Focus();
                return;
            }
            
            txtRetypeChqNo.PasswordChar = '*';
            txtChqNo.PasswordChar = '\0';
        }

        private void txtRetypeChqNo_Enter(object sender, EventArgs e)
        {
            txtRetypeChqNo.PasswordChar = '\0';
            txtChqNo.PasswordChar = '*';
        }

        private void txtChqAmt_Leave(object sender, EventArgs e)
        {
            txtChqAmt.PasswordChar = '*';
            txtRetypeChqAmt.PasswordChar = '\0';
        }

        private void txtChqAmt_Enter(object sender, EventArgs e)
        {
            txtChqAmt.PasswordChar = '\0';
            txtRetypeChqAmt.PasswordChar = '*';
        }

        private void txtRetypeChqAmt_Leave(object sender, EventArgs e)
        {
            txtRetypeChqAmt.PasswordChar = '*';
            txtChqAmt.PasswordChar = '\0';
        }

        private void txtRetypeChqAmt_Enter(object sender, EventArgs e)
        {
            txtRetypeChqAmt.PasswordChar = '\0';
            txtChqAmt.PasswordChar = '*';
        }

        private bool validation()
        {

            if (txtChqNo.Text == "")
            {
                MessageBox.Show("Cheque no cannot be empty !", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChqNo.Focus();
                return false;
            }

            if (txtChqNo.Text != txtRetypeChqNo.Text)
            {
                MessageBox.Show("Retyped cheque no not matched !", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetypeChqNo.Focus();
                return false;
            }

            if (txtChqAmt.Text == "")
            {
                MessageBox.Show("Cheque amount cannot be empty/zero !", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChqAmt.Focus();
                return false;
            }

            if (txtChqAmt.Text != txtRetypeChqAmt.Text)
            {
                MessageBox.Show("Retyped cheque amount not matched !", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetypeChqAmt.Focus();
                return false;
            }

            chq_amt = Math.Round(Convert.ToDouble(txtChqAmt.Text), 2);

            if (batch_amt == chq_tot_amt + chq_amt - sub_chq_amt)
            {
                if (batch_chq_count != entered_chq_count + 1 - sub_chq_count)
                {
                    if (MessageBox.Show("Batch tallied ! But cheque count not tallied ! Are you sure to save ?", "Tallied ! Cheque Count Mismatch",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        txtBatchAmt.Focus();
                        return false;
                    }
                }
            }
            else
            {
                if (batch_chq_count == entered_chq_count + 1 - sub_chq_count)
                {
                    if (MessageBox.Show("Batch cheque count tallied ! But amount not tallied ! Are you sure to save ?", "Tallied ! Cheque Count Mismatch",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        txtBatchAmt.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                InwardBusiness obj = new InwardBusiness();
                string[] result = obj.SaveCtsCheque(batch_gid,chq_gid, txtChqNo.Text, (double)Math.Round(Convert.ToDecimal(txtChqAmt.Text), 2), txtCtsAccNo.Text, txtCtsAccHolderName.Text);

                if (result[1] == "1")
                {
                    MessageBox.Show(result[0], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_chq(batch_gid);
                }
                else
                {
                    MessageBox.Show(result[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtChqNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtRetypeChqNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChqAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRetypeChqAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void clear_chq()
        { 
            txtSlNo.Text = (dgvCtsChqEntry.Rows.Count + 1).ToString();
            txtChqId.Text = "";
            txtChqNo.Text = "";
            txtRetypeChqNo.Text = "";
            txtChqAmt.Text = "";
            txtRetypeChqAmt.Text = "";
            
            chq_gid = 0;
            sub_chq_count = 0;
            sub_chq_amt = 0;
            
            txtChqNo.Focus();
        }

        private void load_chq(int batch_gid)
        {
            try
            {
                DataTable dt;
                DataGridViewButtonColumn btn;
                InwardBusiness obj = new InwardBusiness();
                dt = obj.GetCtsCheque(batch_gid,"");

                dgvCtsChqEntry.Columns.Clear();
                dgvCtsChqEntry.DataSource = dt;

                // add edit button
                btn = new DataGridViewButtonColumn();
                btn.UseColumnTextForButtonValue = true;
                btn.Name = "Edit";
                btn.Text = "Edit";
                btn.HeaderText = "Edit";
                dgvCtsChqEntry.Columns.Add(btn);

                // add delete button
                btn = new DataGridViewButtonColumn();
                btn.UseColumnTextForButtonValue = true;
                btn.Name = "Delete";
                btn.Text = "Delete";
                btn.HeaderText = "Delete";
                dgvCtsChqEntry.Columns.Add(btn);

                dgvCtsChqEntry.Columns["batch_gid"].Visible = false;
                dgvCtsChqEntry.Columns["chq_gid"].Visible = false;
                dgvCtsChqEntry.Columns["A/C No"].Visible = false;
                dgvCtsChqEntry.Columns["A/C Name"].Visible = false;
                dgvCtsChqEntry.Columns["mapped_flag"].Visible = false;

                entered_chq_count = dt.Rows.Count;
                pend_chq_count = batch_chq_count - entered_chq_count;

                lblChqCount.Text = "Entered Cheque : " + dt.Rows.Count.ToString();
                lblPendChqCount.Text = "Pending Cheque : " + (batch_chq_count - dt.Rows.Count).ToString();

                if (dt.Rows.Count > 0)
                    chq_tot_amt = Math.Round((double)dt.Compute("SUM(`Cheque Amount`)", ""), 2);
                else
                    chq_tot_amt = 0;

                diff_amt = batch_amt - chq_tot_amt;

                lblEnteredTotAmt.Text = "Entered Amount : " + string.Format("{0:0.00}", chq_tot_amt);
                lblDiffAmt.Text = "Difference Amount : " + string.Format("{0:0.00}", diff_amt);

                clear_chq();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear_chq();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCtsChqEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                chq_gid = Convert.ToInt32(dgvCtsChqEntry.Rows[e.RowIndex].Cells["chq_gid"].Value.ToString());

                if (dgvCtsChqEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Edit")
                {
                    if (MessageBox.Show("Are you sure to edit ?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        txtSlNo.Text = dgvCtsChqEntry.Rows[e.RowIndex].Cells["Serial No"].Value.ToString();
                        txtChqId.Text = dgvCtsChqEntry.Rows[e.RowIndex].Cells["chq_gid"].Value.ToString();

                        sub_chq_count = 1;
                        sub_chq_amt = (double)dgvCtsChqEntry.Rows[e.RowIndex].Cells["Cheque Amount"].Value;

                        txtChqNo.Text = "";
                        txtRetypeChqNo.Text = "";
                        txtChqAmt.Text = "";
                        txtRetypeChqAmt.Text = "";

                        txtChqNo.Focus();
                    }
                }

                if (dgvCtsChqEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                {
                    if (MessageBox.Show("Are you sure to delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        InwardBusiness obj = new InwardBusiness();
                        string[] result = obj.DeleteCtsCheque(chq_gid);

                        if (result[1] == "1")
                        {
                            MessageBox.Show(result[0], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load_chq(batch_gid);
                        }
                        else
                        {
                            MessageBox.Show(result[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
    }
}
