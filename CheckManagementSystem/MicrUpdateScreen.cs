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
    public partial class MicrUpdateScreen : Form
    {
        public int BatchGid = 0;
        public MicrUpdateScreen()
        {
            InitializeComponent();
        }
        public MicrUpdateScreen(int Batchgid, string BatchDate, string BatchNo, string ChequeType, string DepositSlipNo, string Pickuplocation, int ChequeCount, string CustomerName, double batchamount)
        {

            InitializeComponent();

            BatchGid = Batchgid;
            BatchNo_Txt.Text = BatchNo;
            chqtype_txt.Text = ChequeType;
            Depslipno_txt.Text = DepositSlipNo;
            CustomerName_txt.Text = CustomerName;
            ChqCount_txt.Text = Convert.ToString(ChequeCount);
            BatchAmount_txt.Text = Convert.ToString(batchamount);
            ScanCount_txt.Text = Convert.ToString(ChequeCount);


        }
        private void LoadValidMicrDtl(int BatchGid)
        {
            try
            {
                gvmicrentry.Columns.Clear();
                DataTable dtscanning = new DataTable();
                gvmicrentry.DataSource = null;
                InwardBusiness ObjInward = new InwardBusiness();
                dtscanning = ObjInward.GetValidMicrDtls(BatchGid);
                gvmicrentry.DataSource = dtscanning;

                if (gvmicrentry.Columns["Cheque Gid"] != null)
                {
                    gvmicrentry.Columns["Cheque Gid"].Visible = false;
                    gvmicrentry.Columns["Batch Gid"].Visible = false;
                    gvmicrentry.Columns["Cheque Date"].Visible = false;
                    gvmicrentry.Columns["Cheque amount"].Visible = false;

                }
                if (dtscanning.Rows.Count > 0)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.Text = "Select";
                    col.Name = "Action";
                    gvmicrentry.Columns.Add(col);
                }
                else
                {
                    MessageBox.Show("No Micr List Available for Maker Validation", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                gvmicrentry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakerScreen_Load(object sender, EventArgs e)
        {
            LoadValidMicrDtl(BatchGid);
        }

        private void MakerScreen_Activated(object sender, EventArgs e)
        {
            //if (gvmicrentry.Rows.Count > 0)
            //{
            //    showchq(0);
            //}
        }
        
        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            //LoadMicrDtl(BatchGid);
        }

        private void showchq(int row)
        {
            Bitmap FrontImages = null;

            int Chqgid = Convert.ToInt32(gvmicrentry.Rows[row].Cells["Cheque Gid"].Value);
            string ChqNo = gvmicrentry.Rows[row].Cells["Cheque No"].Value.ToString();
            string MicrCode = gvmicrentry.Rows[row].Cells["Micr Code"].Value.ToString();
            string ChqType = chqtype_txt.Text.Trim();

            InwardBusiness ObjInward = new InwardBusiness();
            DataTable dtscanimage = ObjInward.GetScanImageDtls(Chqgid);
            for (int i = 0; i < dtscanimage.Rows.Count; i++)
            {

                if (dtscanimage.Rows[i]["image_side"].ToString() == "F")
                {
                    FrontImages = ReturnImage((byte[])dtscanimage.Rows[i]["image_byte"]);
                }
                //if (dtscanimage.Rows[i]["image_side"].ToString() == "R")
                //{
                //    RImage = dtscanimage.Rows[i]["image_byte"].ToString();
                //}

            }
            FrontImage.Image = FrontImages;
            //PicBackSide.Image = ReturnImage(RImage);

            MicrUpdate objcheck = new MicrUpdate(BatchGid, Chqgid, MicrCode, ChqNo, ChqType);
            objcheck.Top = pnlGrid.Top + 36;
            objcheck.Left = this.Left + ((this.Width - objcheck.Width) / 2);
            DialogResult result =  objcheck.ShowDialog();

            if (result != System.Windows.Forms.DialogResult.Cancel)
            {
                int current_row = (int)gvmicrentry.CurrentCell.RowIndex;
                LoadValidMicrDtl(BatchGid);

                if (current_row < gvmicrentry.Rows.Count-1)
                {
                    current_row++;
                    gvmicrentry.FirstDisplayedScrollingRowIndex = current_row;
                    gvmicrentry.CurrentCell = gvmicrentry.Rows[current_row].Cells[0];
                    showchq(current_row);
                }
            }
        }

        private void gvmicrentry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == gvmicrentry.ColumnCount - 1)
                {
                    showchq(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Bitmap ReturnImage(byte[] byteBuffer)
        {

            Bitmap bm = null;
            try
            {


                //byte[] byteBuffer = Convert.FromBase64String(base64);
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                bm = new Bitmap(Image.FromStream(memoryStream));

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bm;
        }

        private void gvmicrentry_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Bitmap FrontImages = null;
                int col = gvmicrentry.CurrentCell.ColumnIndex;
                int row = gvmicrentry.CurrentCell.RowIndex;
                int Chqgid = Convert.ToInt32(gvmicrentry.Rows[row].Cells["Cheque Gid"].Value);
                InwardBusiness ObjInward = new InwardBusiness();
                DataTable dtscanimage = ObjInward.GetScanImageDtls(Chqgid);
                for (int i = 0; i < dtscanimage.Rows.Count; i++)
                {

                    if (dtscanimage.Rows[i]["image_side"].ToString() == "F")
                    {
                        FrontImages = ReturnImage((byte[])dtscanimage.Rows[i]["image_byte"]);
                    }

                }
                FrontImage.Image = FrontImages;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvmicrentry_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                showchq(e.RowIndex);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvmicrentry_KeyDownClick(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.F2)
                {
                    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F2) e.SuppressKeyPress = true;

                    if (gvmicrentry.CurrentCell.RowIndex >= 0)
                    {
                        showchq(gvmicrentry.CurrentCell.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvmicrentry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
