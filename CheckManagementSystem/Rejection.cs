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

    public partial class Rejection : Form
    {
        int ChqGid = 0;
        int BatchGid = 0;
        public Rejection(int batchGid,int chqgid)
        {
            InitializeComponent();
            BatchGid = batchGid;
            ChqGid = chqgid;
            LoadRejection(ChqGid);
        }

        private void LoadRejection(int ChqGid)
        {
            try
            {
               
                PicFrontSide.Image = null;           
                Bitmap FrontImages = null;
              
                  
                InwardBusiness ObjInward = new InwardBusiness();
                DataTable dtscanimage = ObjInward.GetScanImageDtls(ChqGid);
                for (int i = 0; i < dtscanimage.Rows.Count; i++)
                {

                    if (dtscanimage.Rows[i]["image_side"].ToString() == "F")
                    {
                        FrontImages = ReturnImage((byte[])dtscanimage.Rows[i]["image_byte"]);
                    }
                   
                }
                PicFrontSide.Image = FrontImages;
              
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
                //Bitmap bmpFront = (Bitmap)Bitmap.FromStream(memoryStream);
                bm = new Bitmap(Image.FromStream(memoryStream));
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bm;
        }   
        private void Rejection_Load(object sender, EventArgs e)
        {
            try
            {
               
                TheamClass.SetTheam(this);
                InwardBusiness objinward = new InwardBusiness();
                DataTable dtReason = new DataTable();
                dtReason = objinward.GetDiscReason();

                DataRow rows = dtReason.NewRow();
                rows["disc_reason"] = "--Select--";
                dtReason.Rows.InsertAt(rows, 0);
                cmb_reason.DataSource = dtReason;
                cmb_reason.DisplayMember = "disc_reason";
                cmb_reason.ValueMember = "discreason_gid";

                CancelButton = btn_close;
                KeyPreview = true;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to save the record?", "Update", MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    if (cmb_reason.SelectedIndex == 0)
                    {
                        MessageBox.Show("Rejection Reason cannot be empty! Please Fill the rejection reason", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmb_reason.Focus();
                        return;
                    }
                    else
                    {

                        InwardBusiness objBusiness = new InwardBusiness();
                        int Descreasongid = Convert.ToInt32(cmb_reason.SelectedValue.ToString());
                        string EntryFlag = "Reject";
                        string[] result = objBusiness.SaveRejectionEntry(BatchGid, ChqGid, Descreasongid, EntryFlag);
                        MessageBox.Show(result[0].ToString());
                        if (result[1].ToString() == "1")
                        {

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

        private void btn_close_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close ?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Rejection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
