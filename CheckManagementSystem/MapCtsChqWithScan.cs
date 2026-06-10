using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;

namespace CheckManagementSystem
{
    public partial class MapCtsChqWithScan : Form
    {    
        byte[] scan_image;
        string chq_no;
        int batch_gid;

        public int chq_gid { get; set; }
        public string cts_acc_no { get; set; }
        public string cts_acc_name { get; set; }

        public MapCtsChqWithScan(int _batch_gid,string _chq_no,byte[] _scan_image)
        {
            InitializeComponent();

            scan_image = _scan_image;
            chq_no = _chq_no;
            batch_gid = _batch_gid;
        }

        private void load_data()
        {
            try
            {
                InwardBusiness obj = new InwardBusiness();
                DataTable dt = obj.GetCtsCheque(batch_gid, chq_no);

                dgvCtsChqEntry.Columns.Clear();
                dgvCtsChqEntry.DataSource = dt;

                dgvCtsChqEntry.Columns["chq_gid"].Visible = false;
                dgvCtsChqEntry.Columns["batch_gid"].Visible = false;

                // add edit button
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.UseColumnTextForButtonValue = true;
                btn.Name = "Select";
                btn.Text = "Select";
                btn.HeaderText = "Select";
                dgvCtsChqEntry.Columns.Insert(0, btn);

                MemoryStream streamBmpImg = new MemoryStream(scan_image);
                Bitmap bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                picChq.Image = bitImg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.chq_gid = 0;
            this.Close();
        }

        private void MapCtsChqWithScan_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dgvCtsChqEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvCtsChqEntry.Columns[e.ColumnIndex].Name == "Select")
                    {
                        txtChqNo.Text = dgvCtsChqEntry.Rows[e.RowIndex].Cells["Cheque No"].Value.ToString();
                        txtChqAmt.Text = string.Format("{0:0.00}", dgvCtsChqEntry.Rows[e.RowIndex].Cells["Cheque Amount"].Value);
                        txtCtsAccNo.Text = dgvCtsChqEntry.Rows[e.RowIndex].Cells["A/C No"].Value.ToString();
                        txtCtsAccName.Text = dgvCtsChqEntry.Rows[e.RowIndex].Cells["A/C Name"].Value.ToString();
                        txtChqId.Text = dgvCtsChqEntry.Rows[e.RowIndex].Cells["chq_gid"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            this.chq_gid = Convert.ToInt32(txtChqId.Text);
            this.cts_acc_no = txtCtsAccNo.Text;
            this.cts_acc_name = txtCtsAccName.Text;
            this.Close();
        }
    }
}
