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
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace CheckManagementSystem
{
    public partial class ScanCtsChq : Form
    {
        #region variables
        MySqlConnection con;

        DataTable dtScan = new DataTable();
        DataTable dtCtsChq;
        DataRow drScan;
        DataGridViewButtonColumn dgvBtnCol;

        string chq_type;
        string cts_chq_type;
        string branch_code;
        int scan_slno = 0;
        string reader_txt;
        string[] reader_split;
        string micr_code;
        string chq_no;
        string base_code;
        string tran_code;
        List<string> tran_code_list;
        int batchid = 0;

        int sizeImg;
        byte[] mybytesImg;
        IntPtr ptrImg;
        Bitmap bitImg;
        System.IO.MemoryStream streamBmpImg;

        #endregion

        #region Initialization
        private string batch_num = string.Empty;
        private string check_Count = string.Empty;
        private string batch_amt = string.Empty;
        private string dep_slip_no = string.Empty;
        private string cust_name = string.Empty;
        private string scan_type = string.Empty;
        int uvCount = 0;
        private enum XportStates
        {
            TransportShutDown = 0,
            TransportStartingUp = 1,
            TransportChangeOptions = 2,
            TransportEnablingOptions = 3,
            TransportReadyToFeed = 4,
            TransportFeeding = 5,
            TransportExceptionInProgress = 6,
            TransportShuttingDown = 7
        };
        private enum FeedingStoppedReasons
        {
            FeedRequestFinished = 0,
            MainHopperEmpty = 1,
            MergeHopperEmpty = 2,
            ManualDropEmpty = 3,
            FeedStopRequested = 4,
            ClearTrackRequested = 5,
            BlackBandItemDetected = 6,
            EndOfLogicalMicrofilmRoll = 7,
            ExceptionDetected = 8
        };
        private enum IQATestIDs
        {
            IQATest_UndersizeImage = 1,
            IQATest_OversizeImage = 2,
            IQATest_BelowMinCompressedSize = 3,
            IQATest_AboveMaxCompressedSize = 4,
            IQATest_FrontRearDimensionMismatch = 5,
            IQATest_HorizontalStreaks = 6,
            IQATest_ImageTooLight = 7,
            IQATest_ImageTooDark = 8,
            IQATest_CarbonStrip = 9,
            IQATest_FramingError = 10,
            IQATest_ExcessiveSkew = 11,
            IQATest_TornEdges = 12,
            IQATest_TornCorners = 13,
            IQATest_SpotNoise = 14
        };
        private enum IQATestStatus
        {
            IQATestStatus_NotTested = 0,
            IQATestStatus_DefectPresent = 1,
            IQATestStatus_DefectNotPresent = 2
        };
        private enum IQAResults
        {
            IQAResult_TestResult = 1
        };
        private enum IQAResults_UndersizeImage : int
        {
            UndersizeImage_ImageWidth = 2,
            UndersizeImage_ImageHeight = 3
        };
        private enum IQAResults_OversizeImage
        {
            OversizeImage_ImageWidth = 2,
            OversizeImage_ImageHeight = 3
        };
        private enum IQAResults_BelowMinCompressedSize
        {
            BelowMinCompressedSize_CompressedImageSize = 2,
            BelowMinCompressedSize_ImageResolution = 3
        };
        private enum IQAResults_AboveMaxCompressedSize
        {
            AboveMaxCompressedSize_CompressedImageSize = 2,
            AboveMaxCompressedSize_ImageResolution = 3
        };
        private enum IQAResults_FrontRearDimensionMismatch
        {
            FrontRearDimensionMismatch_WidthDifference = 2,
            FrontRearDimensionMismatch_HeightDifference = 3
        };
        private enum IQAResults_HorizontalStreaks
        {
            HorizontalStreaks_StreakCount = 2,
            HorizontalStreaks_ThickestStreak = 3,
            HorizontalStreaks_ThickestStreakLocation = 4
        };
        private enum IQAResults_ImageTooLight
        {
            ImageTooLight_BitonalBlackPixelPercent = 2
        };
        private enum IQAResults_ImageTooDark
        {
            ImageTooDark_BitonalBlackPixelPercent = 2
        };
        private enum IQAResults_FramingError
        {
            FramingError_TopEdge = 2,
            FramingError_LeftEdge = 3,
            FramingError_BottomEdge = 4,
            FramingError_RightEdge = 5
        };
        private enum IQAResults_ExcessiveSkew
        {
            ExcessiveSkew_Angle = 2
        };
        private enum IQAResults_TornEdges
        {
            TornEdges_LeftTearWidth = 2,
            TornEdges_LeftTearHeight = 3,
            TornEdges_BottomTearWidth = 4,
            TornEdges_BottomTearHeight = 5,
            TornEdges_RightTearWidth = 6,
            TornEdges_RightTearHeight = 7,
            TornEdges_TopTearWidth = 8,
            TornEdges_TopTearHeight = 9
        };
        private enum IQAResults_TornCorners
        {
            TornCorners_TopLeftTearWidth = 2,
            TornCorners_TopLeftTearHeight = 3,
            TornCorners_BottomLeftTearWidth = 4,
            TornCorners_BottomLeftTearHeight = 5,
            TornCorners_TopRightTearWidth = 6,
            TornCorners_TopRightTearHeight = 7,
            TornCorners_BottomRightTearWidth = 8,
            TornCorners_BottomRightTearHeight = 9
        };
        private enum IQAResults_SpotNoise
        {
            SpotNoise_AverageSpotNoiseCount = 2
        };
        private enum Sides
        {
            TransportFront = 0,
            TransportRear = 1,
        };
        private enum ImageColorTypes
        {
            ImageColorTypeUnknown = -1,
            ImageColorTypeBitonal = 0,
            ImageColorTypeGrayscale = 1,
            ImageColorTypeColor = 2
        };
        string exePath = string.Empty;
        string root = string.Empty;
        int count = 0;
        int i = 0;
        static string base64String = "";
        #endregion

        public ScanCtsChq()
        {
            InitializeComponent();
            con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            con.Open();
        }

        public ScanCtsChq(int Batchgid, string _branch_code, string BatchDate, string BatchNo, string ChequeType, string _cts_chq_type,string DepositSlipNo,string _cts_acc_no,string _cts_acc_name, string Pickuplocation, int ChequeCount, double batchamount)
        {
            InitializeComponent();
            batchid = Batchgid;
            branch_code = _branch_code;
            Inward_Fromdate.Text = BatchDate;
            txtBatchNo.Text = BatchNo;
            txtChqType.Text = ChequeType + "-" + _cts_chq_type;
            chq_type = ChequeType;
            cts_chq_type = _cts_chq_type;

            txtCtsAccNo.Text = _cts_acc_no;
            lblCtsAccHolder.Text = _cts_acc_name;

            txtDepSlipNo.Text = DepositSlipNo;
            txtChqCount.Text = Convert.ToString(ChequeCount);
            txtBatchAmt.Text = Convert.ToString(batchamount);

            con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            con.Open();
        }


        #region RangerEvents
        private void axRanger1_TransportChangeOptionsState(object sender, AxRANGERLib._DRangerEvents_TransportChangeOptionsStateEvent e)
        {
            if (e.previousState == (int)XportStates.TransportStartingUp)
            {
                axRanger1.SetGenericOption("OptionalDevices", "NeedImaging", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage1", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage1", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage2", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage2", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage4", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage4", "True");
                axRanger1.EnableOptions();
            }
        }

        private void axRanger1_TransportNewState(object sender, AxRANGERLib._DRangerEvents_TransportNewStateEvent e)
        {
            try
            {
                if (e.currentState == (int)XportStates.TransportChangeOptions)
                {
                    string txt = "";
                }
                else if (e.currentState == (int)XportStates.TransportReadyToFeed)
                {
                    btnScan.Enabled = true;
                    btnShutdown.Enabled = true;
                }
                else if (e.currentState == (int)XportStates.TransportShutDown)
                {
                    btnScan.Enabled = false;
                    btnShutdown.Enabled = false;
                    btnStartRanger.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void axRanger1_TransportFeedingStopped(object sender, AxRANGERLib._DRangerEvents_TransportFeedingStoppedEvent e)
        {
            try
            {
                if (e.reason == (int)FeedingStoppedReasons.MainHopperEmpty)
                {
                    MessageBox.Show("Feeder is Empty");
                }
                else if (e.reason == (int)FeedingStoppedReasons.ExceptionDetected)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void axRanger1_TransportNewItem(object sender, System.EventArgs e)
        {
            try
            {
                int ItemID = axRanger1.GetItemID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void axRanger1_TransportSetItemOutput(object sender, AxRANGERLib._DRangerEvents_TransportSetItemOutputEvent e)
        {
            axRanger1.SetTargetLogicalPocket(1);
        }

        private void axRanger1_TransportItemInPocket(object sender, AxRANGERLib._DRangerEvents_TransportItemInPocketEvent e)
        {
            try
            {
                string txt1 = "",txt2 = "",txt3 = "";

                reader_txt = axRanger1.GetMicrText(1);

                scan_slno += 1;

                drScan = dtScan.NewRow();

                drScan["S No"] = scan_slno;
                drScan["reader_txt"] = reader_txt;

                try 
                {
                    reader_txt = reader_txt.Replace("c", "");
                    reader_txt = reader_txt.Replace("d", "");
                    reader_txt = reader_txt.Replace("!", "");
                    reader_txt = reader_txt.Replace("-", "");
                    reader_txt = reader_txt.Replace("  ", " ");
                    reader_txt = reader_txt.Trim();

                    reader_split = reader_txt.Split(new String[] { " " }, StringSplitOptions.None);

                    drScan["Chq No"] = "";
                    drScan["Micr Code"] = "";
                    drScan["Tran Code"] = "";
                    drScan["Base Code"] = "";

                    if (reader_split.Length == 3)
                    {
                        drScan["Chq No"] = reader_split[0];
                        drScan["Micr Code"] = reader_split[1];
                        drScan["Tran Code"] = reader_split[2];
                    }
                    else if (reader_split.Length == 4)
                    {
                        drScan["Chq No"] = reader_split[0];
                        drScan["Micr Code"] = reader_split[1];
                        drScan["Tran Code"] = reader_split[3];
                        drScan["Base Code"] = reader_split[2];
                    }
                    else if (reader_split.Length > 4)
                    {
                        drScan["Chq No"] = reader_split[0];
                        drScan["Micr Code"] = reader_split[1];

                        for (int i = 2; i < reader_split.Length; i++)
                        {
                            if (reader_split[i].Length == 6) drScan["Base Code"] = reader_split[i];
                            if (reader_split[i].Length == 2) drScan["Tran Code"] = reader_split[i];
                        }
                    }

                    if (drScan["Chq No"].ToString().Length == 15)
                    {
                        txt1 = drScan["Chq No"].ToString();
                        txt2 = drScan["Micr Code"].ToString();
                        txt3 = drScan["Base Code"].ToString();

                        drScan["Chq No"] = txt1.Substring(0, 6);
                        drScan["Micr Code"] = txt1.Substring(6, 9);

                        if (txt2.Length == 8)
                        {
                            drScan["Base Code"] = txt2.Substring(0, 6);
                            drScan["Tran Code"] = txt2.Substring(6, 2);
                        }

                        if (txt2.Length == 6)
                        {
                            drScan["Base Code"] = txt2;
                        }

                        if (txt3.Length == 2)
                        {
                            drScan["Tran Code"] = txt3;
                        }
                    }

                    if (drScan["Micr Code"].ToString().Length == 15)
                    {
                        txt2 = drScan["Micr Code"].ToString();
                        txt3 = drScan["Base Code"].ToString();

                        drScan["Micr Code"] = txt1.Substring(0, 9);
                        drScan["Base Code"] = txt2.Substring(9, 6);

                        if (txt3.Length == 2)
                        {
                            drScan["Tran Code"] = txt3;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // bw front
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal));
                //Copy the bytes from nmanaged memory to managed memory
                Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                picChq.Image = bitImg;

                drScan["bw_front_image"] = mybytesImg;

                // bw rear
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal));
                //Copy the bytes from nmanaged memory to managed memory
                Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                picChq.Image = bitImg;

                drScan["bw_rear_image"] = mybytesImg;

                // gray front
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeGrayscale);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeGrayscale));
                //Copy the bytes from nmanaged memory to managed memory
                Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box
                picChq.Image = bitImg;

                drScan["gray_front_image"] = mybytesImg;

                // uv front
                sizeImg = axRanger1.GetImageByteCount((int)Sides.TransportFront, 4);
                mybytesImg = new byte[sizeImg];
                //create the pointer and assign the Ranger image address to it
                ptrImg = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, 4));
                //Copy the bytes from nmanaged memory to managed memory
                Marshal.Copy(ptrImg, mybytesImg, 0, sizeImg);
                //Create an image stream and a bitmap object to hold the image 
                streamBmpImg = new MemoryStream(mybytesImg);
                bitImg = new Bitmap(Image.FromStream(streamBmpImg));
                //assign that bitmap object to the picture box

                drScan["uv_front_image"] = mybytesImg;

                dtScan.Rows.Add(drScan);

                dgvScan.DataSource = dtScan;
                dgvScan.FirstDisplayedScrollingRowIndex = dgvScan.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void disp_image()
        {
            string fld_image = "";

            if (lblScanSerialNo.Tag.ToString() == "") return;

            if (rdoBW.Checked)
            {
                if (rdoFront.Checked)
                {
                    fld_image = "bw_front_image";
                }
                else
                {
                    fld_image = "bw_rear_image";
                }
            }
            else if (rdoGray.Checked)
            {
                fld_image = "gray_front_image";
            }
            else
            {
                fld_image = "uv_front_image";
            }

            streamBmpImg = new MemoryStream((byte[])dtScan.Rows[Convert.ToInt32(lblScanSerialNo.Tag.ToString()) - 1][fld_image]);
            bitImg = new Bitmap(Image.FromStream(streamBmpImg));
            //assign that bitmap object to the picture box
            picChq.Image = bitImg;

        }

        private void load_chq(int batch_gid)
        {
            try
            {
                InwardBusiness obj = new InwardBusiness();
                dtCtsChq = obj.GetCtsCheque(batch_gid,"");

                dgvCtsChq.DataSource = dtCtsChq;

                dgvCtsChq.Columns["Serial No"].Width = 50;
                dgvCtsChq.Columns["batch_gid"].Visible = false;
                dgvCtsChq.Columns["chq_gid"].Visible = false;

                if (cts_chq_type == "S")
                {
                    dgvCtsChq.Columns["A/C No"].Visible = false;
                    dgvCtsChq.Columns["A/C Name"].Visible = false;
                }

                for (int i = 0; i < dtScan.Rows.Count; i++)
                {
                    dtScan.Rows[i]["chq_gid"] = 0;
                    dgvScan.Rows[i].DefaultCellStyle.BackColor = txtBatchAmt.BackColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScanChq_Load(object sender, EventArgs e)
        {
            try
            {
                InwardBusiness obj = new InwardBusiness();
                tran_code_list = obj.TranCodeList();

                // data table column structuring
                DataColumn dc;

                dc = new DataColumn();

                dc.ColumnName = "S No";
                dc.DataType = System.Type.GetType("System.Int16");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Chq No";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Micr Code";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Tran Code";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Base Code";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "reader_txt";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "A/C No";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "A/C Name";
                dc.DataType = System.Type.GetType("System.String");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "bw_front_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "bw_rear_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "gray_front_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "uv_front_image";
                dc.DataType = System.Type.GetType("System.Byte[]");
                dtScan.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "chq_gid";
                dc.DataType = System.Type.GetType("System.Int32");
                dtScan.Columns.Add(dc);

                load_chq(batchid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScanChq_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                pnlBatch.Width = pnlButton.Width;

                dgvScan.Top = pnlBatch.Top;
                dgvScan.Left = pnlBatch.Left + pnlBatch.Width + 8;
                dgvScan.Height = pnlBatch.Height + pnlButton.Height + 8;
                dgvScan.Width = (this.Width - (pnlBatch.Left + pnlBatch.Width + 36));

                btnMapCtsChq.Left = dgvScan.Left + dgvScan.Width - btnMapCtsChq.Width;

                dgvCtsChq.Left = dgvScan.Left;
                dgvCtsChq.Width = dgvScan.Width;
                dgvCtsChq.Height = dgvScan.Height;

                picChq.Top = (pnlButton.Top + pnlButton.Height) + 8;
                picChq.Left = 8;
                picChq.Height = this.Height - (pnlButton.Top + pnlButton.Height) - 48;
                picChq.Width = this.Width - 32;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartRanger_Click(object sender, EventArgs e)
        {
            try
            {
                axRanger1.StartUp();
                dgvScan.Rows.Clear();
                dgvScan.Columns.Clear();

                btnStartRanger.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            axRanger1.ShutDown();

            btnShutdown.Enabled = false;
            btnStartRanger.Enabled = true;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                int FeedSourceMainHopper = 0,
                    FeedContinuously = 0;
                //Request that the transport feed continuously from the main hopper.
                //Other possible feed sources are:
                //   + FeedSourceMergeHopper
                //   + FeedSourceManualDrop

                //axRanger1.StartFeeding() can be used to feed a single item or continously.

                //Ranger will transition to the "TransportFeeding" state before StartFeeding() returns.
                //Document cycle events will be fired after an item has been fed.
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
                //axRanger1.ShutDown();
                //enable stop feeding button
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClrScan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to clear scan ?", "Clear Scan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtScan.Rows.Clear();
                scan_slno = 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblScanSerialNo.Tag.ToString() == "")
            {
                MessageBox.Show("Please select the cheque !", "Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToInt32(lblScanSerialNo.Tag.ToString()) > dgvScan.Rows.Count)
            {
                MessageBox.Show("Invalid cheque !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblScanSerialNo.Text = "";
                lblScanSerialNo.Tag = "";
                txtChqNo.Text = "";
                txtMicrCode.Text = "";
                txtTranCode.Text = "";

                return;
            }

            if (txtChqNo.Text == "")
            {
                MessageBox.Show("Cheque no cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChqNo.Focus();
                return;
            }
            else if (!(new Regex(@"^\d{6}$").IsMatch(txtChqNo.Text)))
            {
                MessageBox.Show("Invalid cheque no !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChqNo.Focus();
                return;
            }

            if (txtMicrCode.Text == "")
            {
                MessageBox.Show("Micr code cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMicrCode.Focus();
                return;
            }
            else if (!(new Regex(@"^\d{9}$").IsMatch(txtMicrCode.Text)))
            {
                MessageBox.Show("Invalid micr code !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMicrCode.Focus();
                return;
            }

            if (txtTranCode.Text == "")
            {
                MessageBox.Show("Tran code cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTranCode.Focus();
                return;
            }
            else if (!(new Regex(@"^\d{2}$").IsMatch(txtTranCode.Text)))
            {
                MessageBox.Show("Invalid tran code !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTranCode.Focus();
                return;
            }

            if (txtBaseCode.Text != "")
            {
                if (txtBaseCode.Text.All(char.IsDigit) == false)
                {
                    MessageBox.Show("Base code cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBaseCode.Focus();
                    return;
                }
            }

            if (MessageBox.Show("Are you sure to update cheque details ?", "Update Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int i = Convert.ToInt32(lblScanSerialNo.Tag.ToString()) - 1;

                dtScan.Rows[i]["Micr Code"] = txtMicrCode.Text;
                dtScan.Rows[i]["Chq No"] = txtChqNo.Text;
                dtScan.Rows[i]["Tran Code"] = txtTranCode.Text;
                dtScan.Rows[i]["Base Code"] = txtBaseCode.Text;

                dgvScan.Refresh();

                clear_cheque();

                MessageBox.Show("Updated successfully !", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvScan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 /*&& e.ColumnIndex == 0*/)
            {
                lblScanSerialNo.Tag = dgvScan.Rows[e.RowIndex].Cells["S No"].Value.ToString();
                lblScanSerialNo.Text = "Scan Serial No : " + dgvScan.Rows[e.RowIndex].Cells["S No"].Value.ToString();
                txtChqNo.Text = dgvScan.Rows[e.RowIndex].Cells["Chq No"].Value.ToString();
                txtMicrCode.Text = dgvScan.Rows[e.RowIndex].Cells["Micr Code"].Value.ToString();
                txtTranCode.Text = dgvScan.Rows[e.RowIndex].Cells["Tran Code"].Value.ToString();
                txtBaseCode.Text = dgvScan.Rows[e.RowIndex].Cells["Base Code"].Value.ToString();

                disp_image();

                btnUpdate.Enabled = true;
                btnClear.Enabled = true;
            }
        }

        private void clear_cheque()
        {
            lblScanSerialNo.Text = "";
            lblScanSerialNo.Tag = "";
            txtChqNo.Text = "";
            txtMicrCode.Text = "";
            txtTranCode.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lblScanSerialNo.Tag.ToString() != "")
            {
                if (MessageBox.Show("Are you sure to clear cheque details ?", "Clear Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    clear_cheque();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid_flag;
            string txt;
            int i;
            int chq_gid;
            int scan_gid;
            int result;
            string msg;

            bool disc_flag = false;
            string disc_txt = "";

            MySqlCommand cmd;

            for (i = 0; i < dtCtsChq.Rows.Count ; i++)
            {
                if (dtCtsChq.Rows[i]["mapped_flag"].ToString() != "Y")
                {
                    dgvCtsChq.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                    disc_flag = true;
                    txt = "Rows No : " + (i + 1).ToString() + ",Scan cheque not mapped with CTS Cheque entry,";
                    disc_txt += txt + "\n";
                }
            }

            for (i = 0; i < dtScan.Rows.Count; i++)
            {
                txt = "Rows No : " + (i + 1).ToString() + ",";

                valid_flag = true;

                if (dtScan.Rows[i]["chq_gid"].ToString() == "" || dtScan.Rows[i]["chq_gid"].ToString() == "0")
                {
                    valid_flag = false;
                    txt += "Chq Not Mapped With CTS Cheque Entry,";
                }

                if (dtScan.Rows[i]["Chq No"].ToString() == "" || 
                    dtScan.Rows[i]["Chq No"].ToString().Length != 6 ||
                    dtScan.Rows[i]["Chq No"].ToString() == "000000")
                {
                    valid_flag = false;

                    if (dtScan.Rows[i]["Chq No"].ToString() == "")
                    {
                        txt += "Blank Chq No,";
                    }
                    else
                    {
                        txt += "Invalid Chq No:" + dtScan.Rows[i]["Chq No"].ToString() + ",";
                    }
                }

                if (dtScan.Rows[i]["Micr Code"].ToString() == "" || 
                    dtScan.Rows[i]["Micr Code"].ToString().Length != 9 ||
                    dtScan.Rows[i]["Micr Code"].ToString() == "000000000")
                {
                    valid_flag = false;

                    if (dtScan.Rows[i]["Micr Code"].ToString() == "")
                    {
                        txt += "Blank Micr Code,";
                    }
                    else
                    {
                        txt += "Invalid Micr Code:" + dtScan.Rows[i]["Micr Code"].ToString() + ",";
                    }
                }

                bool tran_result = tran_code_list.Any(s => s == dtScan.Rows[i]["Tran Code"].ToString());

                if (dtScan.Rows[i]["Tran Code"].ToString() == "" || tran_result == false)
                {
                    valid_flag = false;

                    if (dtScan.Rows[i]["Tran Code"].ToString() == "")
                    {
                        txt += "Blank Tran Code,";
                    }
                    else
                    {
                        txt += "Invalid Tran Code:" + dtScan.Rows[i]["Tran Code"].ToString() + ",";
                    }
                }

                if (dtScan.Rows[i]["Base Code"].ToString() != "")
                {
                    if (!dtScan.Rows[i]["Base Code"].ToString().All(char.IsDigit) ||
                        dtScan.Rows[i]["Base Code"].ToString() == "000000")
                    {
                        txt += "Invalid Base Code:" + dtScan.Rows[i]["Base Code"].ToString() + ",";
                    }
                }

                if (valid_flag)
                    dgvScan.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                else
                {
                    dgvScan.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                    disc_flag = true;
                    disc_txt += txt + "\n";
                }
            }

            if (disc_flag)
            {
                MessageBox.Show(disc_txt, "Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(disc_txt);
                return;
            }

            if (MessageBox.Show("Are you sure to complete the scan batch ?", "Scan Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (dtScan.Rows.Count == 0)
            {
                MessageBox.Show("Scan cheque not available !", "Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (Convert.ToInt32(txtChqCount.Text) != dtScan.Rows.Count)
            {
                if (MessageBox.Show("Scanned cheque count not tallied with batch cheque count ! Are you sure to close the batch ?", "Scan Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            axRanger1.ShutDown();
            btnSave.Enabled = false;

            for (i = 0; i < dtScan.Rows.Count; i++)
            {
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_upd_cheque";
                cmd.CommandTimeout = 0;
                chq_gid = (int)dtScan.Rows[i]["chq_gid"];
                cmd.Parameters.Add("in_chq_gid", MySqlDbType.Int32).Value = chq_gid;
                cmd.Parameters.Add("in_batch_gid", MySqlDbType.Int32).Value = batchid;
                cmd.Parameters.Add("in_chq_type", MySqlDbType.VarChar).Value = chq_type;
                cmd.Parameters.Add("in_branch_code", MySqlDbType.VarChar).Value = branch_code;
                cmd.Parameters.Add("in_chq_no", MySqlDbType.VarChar).Value = dtScan.Rows[i]["Chq No"].ToString();
                cmd.Parameters.Add("in_micr_code", MySqlDbType.VarChar).Value = dtScan.Rows[i]["Micr Code"].ToString();
                cmd.Parameters.Add("in_tran_code", MySqlDbType.VarChar).Value = dtScan.Rows[i]["Tran Code"].ToString();
                cmd.Parameters.Add("in_base_code", MySqlDbType.VarChar).Value = dtScan.Rows[i]["Base Code"].ToString();
                cmd.Parameters.Add("in_reader_txt", MySqlDbType.VarChar).Value = dtScan.Rows[i]["reader_txt"].ToString();
                cmd.Parameters.Add("in_acc_no", MySqlDbType.VarChar).Value = dtScan.Rows[i]["A/C No"].ToString();
                cmd.Parameters.Add("in_acc_holder_name", MySqlDbType.VarChar).Value = dtScan.Rows[i]["A/C Name"].ToString();
                cmd.Parameters.Add("out_msg", MySqlDbType.VarChar);
                cmd.Parameters.Add("out_result", MySqlDbType.Int32);

                cmd.Parameters["out_msg"].Direction = ParameterDirection.Output;
                cmd.Parameters["out_result"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = (int)cmd.Parameters["out_result"].Value;
                msg = cmd.Parameters["out_msg"].Value.ToString();

                if (result == 1)
                {
                    // front bw
                    cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ins_scan";
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add("in_chq_gid", MySqlDbType.Int32).Value = chq_gid;
                    cmd.Parameters.Add("in_image_side", MySqlDbType.VarChar).Value = "F";
                    cmd.Parameters.Add("in_image_type", MySqlDbType.VarChar).Value = "B";
                    cmd.Parameters.Add("in_image_byte", MySqlDbType.LongBlob).Value = dtScan.Rows[i]["bw_front_image"];
                    cmd.Parameters.Add("out_scan_gid", MySqlDbType.Int32);
                    cmd.Parameters.Add("out_msg", MySqlDbType.VarChar);
                    cmd.Parameters.Add("out_result", MySqlDbType.Int32);

                    cmd.Parameters["out_scan_gid"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_msg"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_result"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    result = (int)cmd.Parameters["out_result"].Value;
                    msg = cmd.Parameters["out_msg"].Value.ToString();
                    scan_gid = (int)cmd.Parameters["out_scan_gid"].Value;

                    // rear bw
                    cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ins_scan";
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add("in_chq_gid", MySqlDbType.Int32).Value = chq_gid;
                    cmd.Parameters.Add("in_image_side", MySqlDbType.VarChar).Value = "R";
                    cmd.Parameters.Add("in_image_type", MySqlDbType.VarChar).Value = "B";
                    cmd.Parameters.Add("in_image_byte", MySqlDbType.LongBlob).Value = dtScan.Rows[i]["bw_rear_image"];

                    cmd.Parameters.Add("out_scan_gid", MySqlDbType.Int32);
                    cmd.Parameters.Add("out_msg", MySqlDbType.VarChar);
                    cmd.Parameters.Add("out_result", MySqlDbType.Int32);

                    cmd.Parameters["out_scan_gid"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_msg"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_result"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    result = (int)cmd.Parameters["out_result"].Value;
                    msg = cmd.Parameters["out_msg"].Value.ToString();
                    scan_gid = (int)cmd.Parameters["out_scan_gid"].Value;

                    // front gray
                    cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ins_scan";
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add("in_chq_gid", MySqlDbType.Int32).Value = chq_gid;
                    cmd.Parameters.Add("in_image_side", MySqlDbType.VarChar).Value = "F";
                    cmd.Parameters.Add("in_image_type", MySqlDbType.VarChar).Value = "G";
                    cmd.Parameters.Add("in_image_byte", MySqlDbType.LongBlob).Value = dtScan.Rows[i]["gray_front_image"];
                    cmd.Parameters.Add("out_scan_gid", MySqlDbType.Int32);
                    cmd.Parameters.Add("out_msg", MySqlDbType.VarChar);
                    cmd.Parameters.Add("out_result", MySqlDbType.Int32);

                    cmd.Parameters["out_scan_gid"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_msg"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_result"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    result = (int)cmd.Parameters["out_result"].Value;
                    msg = cmd.Parameters["out_msg"].Value.ToString();
                    scan_gid = (int)cmd.Parameters["out_scan_gid"].Value;

                    // uv gray
                    cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ins_scan";
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add("in_chq_gid", MySqlDbType.Int32).Value = chq_gid;
                    cmd.Parameters.Add("in_image_side", MySqlDbType.VarChar).Value = "F";
                    cmd.Parameters.Add("in_image_type", MySqlDbType.VarChar).Value = "U";
                    cmd.Parameters.Add("in_image_byte", MySqlDbType.LongBlob).Value = dtScan.Rows[i]["uv_front_image"];

                    cmd.Parameters.Add("out_scan_gid", MySqlDbType.Int32);
                    cmd.Parameters.Add("out_msg", MySqlDbType.VarChar);
                    cmd.Parameters.Add("out_result", MySqlDbType.Int32);

                    cmd.Parameters["out_scan_gid"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_msg"].Direction = ParameterDirection.Output;
                    cmd.Parameters["out_result"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    result = (int)cmd.Parameters["out_result"].Value;
                    msg = cmd.Parameters["out_msg"].Value.ToString();
                    scan_gid = (int)cmd.Parameters["out_scan_gid"].Value;
                }
            }

            // update batch entry
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_upd_Batch_ScanEntry";
            cmd.CommandTimeout = 0;

            cmd.Parameters.Add("in_batch_gid", MySqlDbType.Int32).Value = batchid;
            cmd.Parameters.Add("out_msg", MySqlDbType.VarChar);
            cmd.Parameters.Add("out_result", MySqlDbType.Int32);

            cmd.Parameters["out_msg"].Direction = ParameterDirection.Output;
            cmd.Parameters["out_result"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            result = (int)cmd.Parameters["out_result"].Value;
            msg = cmd.Parameters["out_msg"].Value.ToString();

            if (result > 0)
            {
                axRanger1.Dispose();
                dtScan.Dispose();
                dtCtsChq.Dispose();

                MessageBox.Show("Scan completed !", "Scan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnShutdown.Enabled = false;
            btnStartRanger.Enabled = true;
            btnSave.Enabled = true;
            btnScan.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close ?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                axRanger1.ShutDown();

                axRanger1.Dispose();
                dtScan.Dispose();
                dtCtsChq.Dispose();

                this.Close();
            }
        }

        private void rdoFront_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoRear_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoBW_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoGray_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void rdoUV_CheckedChanged(object sender, EventArgs e)
        {
            disp_image();
        }

        private void btnCtsChqEntry_Click(object sender, EventArgs e)
        {
            if (cts_chq_type == "S")
            {
                CtsSingleChqEntryNew obj = new CtsSingleChqEntryNew(batchid);
                obj.ShowDialog();

                load_chq(batchid);
            }
            else if (cts_chq_type == "M")
            {
                CtsMultipleChqEntryNew obj = new CtsMultipleChqEntryNew(batchid);
                obj.ShowDialog();

                load_chq(batchid);
            }
        }

        private void dgvScan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                int row = dgvScan.CurrentCell.RowIndex;

                if (row >= 0)
                {
                    string chq_no = dgvScan.Rows[row].Cells["Chq No"].Value.ToString();
                    byte[] img_byte = (byte[]) dgvScan.Rows[row].Cells["bw_front_image"].Value;

                    MapCtsChqWithScan frm = new MapCtsChqWithScan(batchid, chq_no, img_byte);
                    frm.ShowDialog();

                    if (frm.chq_gid > 0)
                    {
                        DataRow[] rows = dtCtsChq.Select("chq_gid = " + frm.chq_gid.ToString() + " and mapped_flag <> 'Y'");

                        if (rows.Length > 0)
                        {
                            if (rows[0]["mapped_flag"].ToString() != "Y")
                            {
                                dtScan.Rows[row]["chq_gid"] = frm.chq_gid;
                                dtScan.Rows[row]["A/C No"] = frm.cts_acc_no;
                                dtScan.Rows[row]["A/C Name"] = frm.cts_acc_name;

                                rows[0]["mapped_flag"] = "Y";
                                dgvScan.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
        }

        private void btnMapCtsChq_Click(object sender, EventArgs e)
        {
            try
            {
                for (i = 0; i < dtScan.Rows.Count; i++)
                {
                    if (dtScan.Rows[i]["chq_gid"].ToString() == "" || dtScan.Rows[i]["chq_gid"].ToString() == "0")
                    {
                        dgvScan.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;

                        if (!(dtScan.Rows[i]["Chq No"].ToString() == "" || dtScan.Rows[i]["Chq No"].ToString().Length != 6))
                        {
                            DataRow[] rows = dtCtsChq.Select("`Cheque No`='" + dtScan.Rows[i]["Chq No"].ToString() + "' and mapped_flag <> 'Y'");

                            if (rows.Length > 0)
                            {
                                if (rows.Length == 1)
                                {
                                    dtScan.Rows[i]["A/C No"] = rows[0]["A/C No"];
                                    dtScan.Rows[i]["A/C Name"] = rows[0]["A/C Name"];
                                    dtScan.Rows[i]["chq_gid"] = rows[0]["chq_gid"];
                                    rows[0]["mapped_flag"] = "Y";
                                    dgvScan.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                                }
                                else
                                    dgvScan.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }
                    }
                }


                for (i = 0; i < dgvCtsChq.Rows.Count; i++)
                {
                    if (dgvCtsChq.Rows[i].Cells["mapped_flag"].Value.ToString() == "Y")
                    {
                        dgvCtsChq.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = dtScan.NewRow();

            row[0] = 1;
            row[1] = "537849";
            row[2] = "152010002";
            row[3] = "12";
            row[6] = "826200143257";
            row[7] = "12";

            dtScan.Rows.Add(row);

            row = dtScan.NewRow();

            row[0] = 2;
            row[1] = "782048";
            row[2] = "152010002";
            row[3] = "12";
            row[6] = "826200143257";
            row[7] = "12";

            dtScan.Rows.Add(row);

            row = dtScan.NewRow();

            row[0] = 3;
            row[1] = "836275";
            row[2] = "152010002";
            row[3] = "12";
            row[6] = "826200143257";
            row[7] = "12";

            dtScan.Rows.Add(row);

            dgvScan.DataSource = dtScan;    
        }

        private void rdoScanChq_CheckedChanged(object sender, EventArgs e)
        {
            dgvScan.Visible = true;
            dgvCtsChq.Visible = false;
        }

        private void rdoCtsChq_CheckedChanged(object sender, EventArgs e)
        {
            dgvCtsChq.Visible = true;
            dgvScan.Visible = false;
        }

        private void txtChqNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtMicrCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtTranCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtBaseCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void ScanCtsChq_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                axRanger1.ShutDown();

                axRanger1.Dispose();
                dtScan.Dispose();
                dtCtsChq.Dispose();

                this.Close();
            }
            catch (Exception ex)
            { 
            }
        }
    }
}
