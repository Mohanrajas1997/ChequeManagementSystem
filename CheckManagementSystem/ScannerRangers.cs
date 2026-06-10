


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class ScannerRangers : Form
    {
        string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();
        string scanner_type = ConfigurationManager.AppSettings["ScannerType"].ToString();

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

        #region Constructors
        public ScannerRangers()
        {
            InitializeComponent();
        }
        public ScannerRangers(string _batch_no, string _check_count, string _batch_amount, string _dep_slip_no, string _cust_code)
        {
            batch_num = _batch_no;
            check_Count = _check_count;
            batch_amt = _batch_amount;
            dep_slip_no = _dep_slip_no;
            cust_name = _cust_code;
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void LoadScanningData()
        {
            try
            {
                GrVwBatching.Rows.Add();
                GrVwBatching.Rows[0].Cells[0].Value = batch_num;
                GrVwBatching.Rows[0].Cells[1].Value = check_Count;
                GrVwBatching.Rows[0].Cells[2].Value = batch_amt;
                GrVwBatching.Rows[0].Cells[3].Value = dep_slip_no;
                GrVwBatching.Rows[0].Cells[4].Value = cust_name;
                GrVwBatching.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                GrVwBatching.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                GrVwBatching.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn c in GrVwBatching.Columns)
                {
                    c.HeaderCell.Style.ForeColor = Color.White;
                    c.DefaultCellStyle.Font = new Font("Calibri", 14, GraphicsUnit.Pixel);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private void DisplayRangerState()
        {
            //Display the current ranger state to the screen
            string rangerstate = axRanger1.GetTransportStateString();
        }
        private string[] GetMicrMaster(string txt)
        {
            string[] result = new string[4];
            try
            {
                string chequeNo = "";
                string micrCode = "";
                string baseCode = "";
                string tranCode = "";
                string[] list = txt.Split(' ');
                list = list.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                if (list.Length > 4)
                {
                    chequeNo = Regex.Replace(list[0], "[^.0-9]", "");
                    micrCode = Regex.Replace(list[1], "[^.0-9]", "");
                    baseCode = Regex.Replace(list[2], "[^.0-9]", "");
                    tranCode = Regex.Replace(list[3], "[^.0-9]", "");
                }
                else
                {
                    chequeNo = Regex.Replace(list[0], "[^.0-9]", "");
                    micrCode = Regex.Replace(list[1], "[^.0-9]", "");
                    baseCode = "000000";
                    tranCode = Regex.Replace(list[2], "[^.0-9]", "");
                }
                //result[0] = chequeNo == "" ? "" : chequeNo.Trim();
                //result[1] = micrCode == "" ? "" : micrCode.Trim();
                //result[2] = tranCode == "" ? "" : tranCode.Trim().Substring(0, 2);
                //result[3] = baseCode == "" ? "" : baseCode.Trim();
                result[0] = chequeNo.Trim();
                result[1] = micrCode.Trim();
                result[2] = tranCode.Trim().Substring(0, 2);
                result[3] = baseCode.Trim();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return result;
        }
        public string ImageToBase64(string path)
        {
            try
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
                LogHelper.WriteLog("This is the Path...." + path);
                return base64String = "";
            }
        }
        private Bitmap ReturnImage(string base64)
        {
            Bitmap bm = null;
            try
            {
                byte[] byteBuffer = Convert.FromBase64String(base64);
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                //Bitmap bmpFront = (Bitmap)Bitmap.FromStream(memoryStream);
                bm = new Bitmap(Image.FromStream(memoryStream));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return bm;
        }
        private void ContinueScan()
        {
            try
            {
                int FeedSourceMainHopper = 0,
                        FeedContinuously = 0;
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private void AdjustScanSettings()
        {
            AdjustScanCountEntities ad = new AdjustScanCountEntities();
            ad.batch_no = batch_num;
            ad.cheque_count = grdScanning.Rows.Count;
            string status = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(apiurl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(ad), UTF8Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("AdjustScanCount", content).Result;
                        Stream data = response.Content.ReadAsStreamAsync().Result;
                        StreamReader reader = new StreamReader(data);
                        string post_data = reader.ReadToEnd();
                        status = (string)JsonConvert.DeserializeObject(post_data, (typeof(string)));
                    }
                    catch (Exception ex)
                    {
                        //LogHelper.WriteLog(ex.ToString());
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region RangerEvents
        private void axRanger1_TransportChangeOptionsState(object sender, AxRANGERLib._DRangerEvents_TransportChangeOptionsStateEvent e)
        {
            if (scanner_type == "Canon")
            {
                if (e.previousState == (int)XportStates.TransportStartingUp)
                {
                    axRanger1.SetGenericOption("OptionalDevices", "NeedImaging", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage1", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage1", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage2", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage2", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage3", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage3", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage4", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage4", "True");
                    axRanger1.EnableOptions();
                }
            }
            else
            {
                if (e.previousState == (int)XportStates.TransportStartingUp)
                {
                    axRanger1.SetGenericOption("OptionalDevices", "NeedImaging", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage1", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage1", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage2", "False");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage2", "False");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage3", "False");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage3", "False");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage4", "True");
                    axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage4", "False");
                    axRanger1.EnableOptions();
                }
            }
        }
        private void axRanger1_TransportNewState(object sender, AxRANGERLib._DRangerEvents_TransportNewStateEvent e)
        {
            try
            {
                DisplayRangerState();
                if (e.currentState == (int)XportStates.TransportChangeOptions)
                {
                    string txt = "";
                }
                else if (e.currentState == (int)XportStates.TransportReadyToFeed)
                {
                    //Commented By MohanDhanush
                    //btnImgScan.Enabled = true;
                    //PicLoad.Visible = false;
                    if (Convert.ToInt32(GrVwBatching.Rows[0].Cells[6].Value) == 0 && (Convert.ToInt32(GrVwBatching.Rows[0].Cells[5].Value) != 0))
                    {
                        btnImgScan.Enabled = false;
                    }
                    else
                    {
                        PicLoad.Visible = false;
                        btnImgScan.Enabled = true;
                    }
                }
                else if (e.currentState == (int)XportStates.TransportShutDown)
                {
                    btnImgScan.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void axRanger1_TransportFeedingStopped(object sender, AxRANGERLib._DRangerEvents_TransportFeedingStoppedEvent e)
        {
            try
            {
                if (e.reason == (int)FeedingStoppedReasons.MainHopperEmpty)
                {
                    if (grdScanning.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(check_Count) == grdScanning.Rows.Count)
                        {
                            btnContinue.Enabled = false;
                            vtnexit.Enabled = true;
                        }
                        else
                        {
                            DialogResult dg1 = MessageBox.Show("Scan Count Mismatched! Rescan?", "Check Mandate System", MessageBoxButtons.YesNo);
                            if (dg1 == DialogResult.Yes)
                            {
                                ContinueScan();
                            }
                            else
                            {
                                AdjustScanSettings();
                                GrVwBatching.Rows[0].Cells[6].Value = 0;
                                GrVwBatching.Rows[0].Cells[1].Value = grdScanning.Rows.Count;
                                vtnexit.Enabled = true;
                                MessageBox.Show("Scan Count Adjusted");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Feeder is Empty");
                    }
                }
                else if (e.reason == (int)FeedingStoppedReasons.ExceptionDetected)
                {
                    DialogResult dg1 = MessageBox.Show("Packet is Filled ! Do You Want  Rescan?", "Check Mandate System", MessageBoxButtons.YesNo);
                    if (dg1 == DialogResult.Yes)
                    {
                        ContinueScan();
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void axRanger1_TransportSetItemOutput(object sender, AxRANGERLib._DRangerEvents_TransportSetItemOutputEvent e)
        {
            string cheq_no = string.Empty;
            string micr_code = string.Empty;
            string base_code = string.Empty;
            string tran_code = string.Empty;
            string micr = '"' + axRanger1.GetMicrText(1) + '"';
            string[] result = GetMicrMaster(micr);
            cheq_no = result[0];
            micr_code = result[1];
            tran_code = result[2];
            base_code = result[3];
            i++;
            grdScanning.Rows.Add(i, cheq_no, micr_code, base_code, tran_code);
            GrVwBatching.Rows[0].Cells[5].Value = i.ToString();
            GrVwBatching.Rows[0].Cells[6].Value = (Convert.ToInt32(check_Count) - i).ToString();
            if (Convert.ToInt32(GrVwBatching.Rows[0].Cells[6].Value) == 0)
            {
                btnImgScan.Enabled = false;
            }
            axRanger1.SetTargetLogicalPocket(1);
        }
        private void axRanger1_TransportItemInPocket(object sender, AxRANGERLib._DRangerEvents_TransportItemInPocketEvent e)
        {
            try
            {
                #region CommentedBysheeba
                ////if (scan_type == "Image Scan")
                ////{
                ////    //e.ItemId identifies which item this event refers to.
                ////Comment By Shee
                //// txtInPocket.Text = e.itemId.ToString();

                ////At this point the item is either in the pocket or it was removed from
                ////the document stream for some reason.


                ////You also have access to all data read and output requests during this event.
                ////Could call:
                ////  AxRanger1.GetEncodeText()
                ////  AxRanger1.GetEndorseText(TransportRear, 1)
                ////  AxRanger1.GetEndorseText(TransportRear, 2)
                ////  etc.

                ////*****************************************
                ////Copy the image from unmanaged memory to managed memory
                ////that C# can access.

                /////* 
                ////Note: The following section illustrates the process of retrieving the front and rear bitonal images.
                ////Both the 'GetImageByteCount' and 'GetImageAddress' methods refer to images that were requested in
                ////the event handler AxRanger1_TransportChangeOptionsState via 'NeedFrontImage1' and 'NeedRearImage1'.
                ////If grayscale images are to be requested,  NeedFrontImage2/NeedRearImage2 should be set to 'true'
                ////and 'ImageColorTypeGrayscale' should be passed to both the GetImageByteCount and GetImageAddress methods.
                ////*/

                ////get the size
                //count++;
                //int sizeFront;
                //sizeFront = axRanger1.GetImageByteCount((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal);
                //byte[] mybytesFront = new byte[sizeFront];
                ////create the pointer and assign the Ranger image address to it
                //IntPtr ptrFront = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal));
                ////Copy the bytes from nmanaged memory to managed memory
                //Marshal.Copy(ptrFront, mybytesFront, 0, sizeFront);
                ////Create an image stream and a bitmap object to hold the image 
                //System.IO.MemoryStream streamBitmapFront = new MemoryStream(mybytesFront);
                //Bitmap bitImageFront = new Bitmap(Image.FromStream(streamBitmapFront));
                ////assign that bitmap object to the picture box
                //PicbxScannedFront.Image = bitImageFront;
                //bitImageFront.Save(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //string txt = ImageToBase64(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                //grdScanning.Rows[(i - 1)].Cells["front_image"].Value = txt;

                ////bool notmalFront = axRanger1.SaveImageToFile(0, 0, root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////string txt = ImageToBase64(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////grdScanning.Rows[(i - 1)].Cells["front_image"].Value = txt;
                ////PicbxScannedFront.Image = new Bitmap(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////get the size

                //count++;
                //int sizeRear;
                //sizeRear = axRanger1.GetImageByteCount((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal);
                //byte[] mybytesRear = new byte[sizeRear];
                ////create the pointer and assign the Ranger image address to it
                //IntPtr ptrRear = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal));
                ////Copy the bytes from nmanaged memory to managed memory
                //Marshal.Copy(ptrRear, mybytesRear, 0, sizeRear);
                ////Create an image stream and a bitmap object to hold the image 
                //System.IO.MemoryStream streamBitmapRear = new MemoryStream(mybytesRear);
                //Bitmap bitImageRear = new Bitmap(Image.FromStream(streamBitmapRear));
                ////assign that bitmap object to the picture box
                //pictureScannedImageBack.Image = bitImageRear;
                //bitImageRear.Save(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //string btxt = ImageToBase64(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                //grdScanning.Rows[(i - 1)].Cells["back_image"].Value = btxt;
                ////bool notmalback = axRanger1.SaveImageToFile(1, 0, root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////string btxt = ImageToBase64(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////grdScanning.Rows[(i - 1)].Cells["back_image"].Value = btxt;
                ////pictureScannedImageBack.Image = new Bitmap(root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");

                //string greyfront = axRanger1.GetImageBase64(0, 1);
                //string greyback = axRanger1.GetImageBase64(1, 1);
                //grdScanning.Rows[(i - 1)].Cells["front_grey"].Value = greyfront;
                //grdScanning.Rows[(i - 1)].Cells["back_grey"].Value = greyback;

                //string ctxt = "";
                //bool isSave = axRanger1.SaveImageToFile(0, 3, root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                //if (File.Exists(root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg"))
                //{
                //    ctxt = ImageToBase64(root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                //    grdScanning.Rows[(i - 1)].Cells["front_uv_image"].Value = ctxt;
                //}
                //else
                //{
                //    ctxt = "UV Image Not Available";
                //    grdScanning.Rows[(i - 1)].Cells["front_uv_image"].Value = ctxt;
                //}

                ////bool greyfront = axRanger1.SaveImageToFile(0, 1, root + "\\ScanimageGreyFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////string ctxt = ImageToBase64(root + "\\ScanimageGreyFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////
                ////pictureScannedImageBack.Image = new Bitmap(root + "\\ScanimageGreyFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");

                ////bool greyback = axRanger1.SaveImageToFile(1, 1, root + "\\ScanimageGreyBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////string dtxt = ImageToBase64(root + "\\ScanimageGreyBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////grdScanning.Rows[(i - 1)].Cells["back_grey"].Value = dtxt;
                ////pictureScannedImageBack.Image = new Bitmap(root + "\\ScanimageGreyBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////}
                ////else if (scan_type == "UV Scan")
                ////{
                ////    count++;
                ////    //txtInPocket.Text = e.itemId.ToString();
                ////    bool isSave = axRanger1.SaveImageToFile(0, 3, root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////    string ctxt = ImageToBase64(root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                ////    grdScanning.Rows[(i)].Cells["front_uv_image"].Value = ctxt;
                ////    i++;
                ////    //MessageBox.Show(isSave.ToString());
                ////}
                ////*****************************************
                ////if (Convert.ToInt32(check_Count) == grdScanning.Rows.Count)
                ////{
                ////    btnContinue.Enabled = false;
                ////    vtnexit.Enabled = true;
                ////}
                ////else
                ////{
                ////    DialogResult dg1 = MessageBox.Show("Scann Count Mismatched! Rescan?", "Check Mandate System", MessageBoxButtons.YesNo);
                ////    if (dg1 == DialogResult.Yes)
                ////    {
                ////        ContinueScan();
                ////    }
                ////    else
                ////    {
                ////        AdjustScanSettings();
                ////        GrVwBatching.Rows[0].Cells[6].Value = 0;
                ////        vtnexit.Enabled = true;
                ////        MessageBox.Show("Scan Count Adjusted");
                ////    }
                ////}
                #endregion

                if (scanner_type == "Canon")
                {
                    #region ReducedSizeForCanon
                    LogHelper.WriteLog("Image Captured Count : " + i.ToString());
                    count++;
                    bool nf = axRanger1.SaveImageToFile(0, 0, root + "\\ScanimageFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    string nfr = ImageToBase64(root + "\\ScanimageFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    grdScanning.Rows[(i - 1)].Cells["front_image"].Value = nfr;
                    PicbxScannedFront.Image = new Bitmap(root + "\\ScanimageFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");

                    bool nb = axRanger1.SaveImageToFile(1, 0, root + "\\ScanimageBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    string na = ImageToBase64(root + "\\ScanimageBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    grdScanning.Rows[(i - 1)].Cells["back_image"].Value = na;
                    pictureScannedImageBack.Image = new Bitmap(root + "\\ScanimageBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");

                    bool gf = axRanger1.SaveImageToFile(0, 1, root + "\\ScanimageGreyFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    string gftxt = ImageToBase64(root + "\\ScanimageGreyFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    grdScanning.Rows[(i - 1)].Cells["front_grey"].Value = gftxt;

                    bool gb = axRanger1.SaveImageToFile(1, 1, root + "\\ScanimageGreyBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    string gbk = ImageToBase64(root + "\\ScanimageGreyBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    grdScanning.Rows[(i - 1)].Cells["back_grey"].Value = gbk;

                    string uv = "";
                    bool isSave = axRanger1.SaveImageToFile(0, 3, root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    //uv = ImageToBase64(root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    if (File.Exists(root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg"))
                    {
                        uv = ImageToBase64(root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                        grdScanning.Rows[(i - 1)].Cells["front_uv_image"].Value = uv;
                    }
                    else
                    {
                        uv = "UV Image Not Available";
                        grdScanning.Rows[(i - 1)].Cells["front_uv_image"].Value = uv;
                    }
                    #endregion
                }
                else
                {
                    #region ReducedSizeForBorroughsScanner
                    LogHelper.WriteLog("Image Captured Count : " + i.ToString());
                    count++;
                    string filename = "\\ScanimageFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg";
                    //bool nf = axRanger1.SaveImageToFile(0, 0, root + "\\ScanimageFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    bool nf = axRanger1.SaveImageToFile(0, 0, root + filename);
                    //string nfr = ImageToBase64(root + "\\ScanimageFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    string nfr = ImageToBase64(root + filename);
                    grdScanning.Rows[(i - 1)].Cells["front_image_fileName"].Value = root + filename;
                    grdScanning.Rows[(i - 1)].Cells["front_image"].Value = nfr;
                    //PicbxScannedFront.Image = new Bitmap(root + "\\ScanimageFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    PicbxScannedFront.Image = new Bitmap(root + filename);

                    filename = "";
                    filename = "\\ScanimageBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg";
                    bool nb = axRanger1.SaveImageToFile(1, 0, root + filename);
                    string na = ImageToBase64(root + filename);
                    grdScanning.Rows[(i - 1)].Cells["back_image_fileName"].Value = root + filename;
                    grdScanning.Rows[(i - 1)].Cells["back_image"].Value = na;
                    pictureScannedImageBack.Image = new Bitmap(root + filename);

                    byte[] imageBytesFront = Convert.FromBase64String(nfr);
                    string gftxt = Downscale(imageBytesFront, root + "\\ScanimageGreyFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    grdScanning.Rows[(i - 1)].Cells["front_grey"].Value = gftxt;
                    grdScanning.Rows[(i - 1)].Cells["front_gray_image_filename"].Value = root + "\\ScanimageGreyFront" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg";

                    byte[] imageBytesback = Convert.FromBase64String(nfr);
                    string gbk = Downscale(imageBytesback, root + "\\ScanimageGreyBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                    grdScanning.Rows[(i - 1)].Cells["back_grey"].Value = gftxt;
                    grdScanning.Rows[(i - 1)].Cells["back_grey_image_filename"].Value = root + "\\ScanimageGreyBack" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg";


                    string uv = "";
                    filename = "";
                    filename = "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg";
                    bool isSave = axRanger1.SaveImageToFile(0, 3, root + filename);
                    if (File.Exists(root + "\\UVImage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg"))
                    {
                        uv = ImageToBase64(root + filename);
                        grdScanning.Rows[(i - 1)].Cells["front_uv_image"].Value = uv;
                    }
                    else
                    {
                        uv = "UV Image Not Available";
                        grdScanning.Rows[(i - 1)].Cells["front_uv_image"].Value = uv;
                    }
                    grdScanning.Rows[(i - 1)].Cells["front_uv_image_fileName"].Value = root + filename;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message);
            }
        }
        #endregion

        #region Events
        private void btnImgScan_Click(object sender, EventArgs e)
        {
            btnImgScan.Enabled = false;
            LogHelper.WriteLog("Start to Scan Images");
            i = 0;
            btnToggle.Enabled = true;
            PicLoad.Visible = true;
            btnImgScan.Enabled = false;
            grdScanning.Rows.Clear();
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
                PicLoad.Visible = false;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ScannerRangers_Resize(object sender, EventArgs e)
        {
            panel2.Left = 0;
            panel2.Width = this.Width;
            grdScanning.Left = 0;
            grdScanning.Width = Math.Abs(this.Width - panel3.Width);
            panel3.Left = grdScanning.Left + grdScanning.Width;
        }

        private void ScannerRangers_Load(object sender, EventArgs e)
        {
            try
            {
                LoadScanningData();
                exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string batch_no = batch_num;
                batch_no = batch_no.Replace('/', '-');
                root = exePath + "\\Scanimage\\" + batch_no;
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                else
                {
                    string[] files = Directory.GetFiles(root);
                    for (int k = 0; k < files.Length; k++)
                    {
                        File.Delete(files[k]);
                    }
                    Directory.Delete(root);
                    Directory.CreateDirectory(root);
                }
                grdScanning.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                grdScanning.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grdScanning.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn c in grdScanning.Columns)
                {
                    c.HeaderCell.Style.ForeColor = Color.White;
                    c.DefaultCellStyle.Font = new Font("Calibri", 14, GraphicsUnit.Pixel);
                }
                btnrange.Focus();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TheamClass.SetTheam(this);
        }
        private void vtnexit_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            LogHelper.WriteLog("Going to Save Scanned List....");
            int success = 0;
            int failed = 0;
            ScannerBusiness objscanner = new ScannerBusiness();
            bool isvalidscan = true;
            try
            {
                int scanned = grdScanning.Rows.Count;
                //if (Convert.ToInt32(check_Count) == scanned)
                //{
                if (scanned > 0)
                {
                    DataTable dt = new DataTable();
                    foreach (DataGridViewColumn col in grdScanning.Columns)
                    {
                        dt.Columns.Add(col.Name);
                    }
                    foreach (DataGridViewRow row in grdScanning.Rows)
                    {
                        DataRow dRow = dt.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dRow[cell.ColumnIndex] = cell.Value;
                        }
                        dt.Rows.Add(dRow);
                    }
                    bool contains = dt.AsEnumerable().Any(row => row["front_image"] == DBNull.Value || row["front_image"] == "");
                    DataTable newDt = new DataTable();
                    if (contains == true)
                    {
                        newDt = dt.AsEnumerable().Where(r => r["front_image"] == DBNull.Value || r["front_image"] == "").CopyToDataTable();
                    }

                    LogHelper.WriteLog("Front Image Empty Count : " + newDt.Rows.Count.ToString());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ScannerEntities scan = new ScannerEntities();
                        scan.batch_no = batch_num;
                        scan.cheq_no = dt.Rows[i]["check_no"].ToString() == "" ? "" : dt.Rows[i]["check_no"].ToString();
                        scan.sort_code = dt.Rows[i]["sort_codes"].ToString() == "" ? "" : dt.Rows[i]["sort_codes"].ToString();
                        scan.base_code = dt.Rows[i]["base_codes"].ToString() == "" ? "" : dt.Rows[i]["base_codes"].ToString();
                        scan.tran_code = dt.Rows[i]["tran_codes"].ToString() == "" ? "" : dt.Rows[i]["tran_codes"].ToString();
                        LogHelper.WriteLog("Front Image File Name :" + root + "\\ScanimageFront" + (i + 1) + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg");
                        scan.front_image = dt.Rows[i]["front_image"].ToString() == "" || dt.Rows[i]["front_image"] == null ? ImageToBase64(root + "\\ScanimageFront" + (i + 1) + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg") : dt.Rows[i]["front_image"].ToString();
                        scan.back_image = dt.Rows[i]["back_image"].ToString() == "" || dt.Rows[i]["back_image"] == null ? ImageToBase64(root + "\\ScanimageBack" + (i + 1) + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg") : dt.Rows[i]["back_image"].ToString();
                        scan.front_uv_image = dt.Rows[i]["front_uv_image"].ToString() == "" || dt.Rows[i]["front_uv_image"] == null ? ImageToBase64(root + "\\UVImage" + (i + 1) + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg") : dt.Rows[i]["front_uv_image"].ToString();
                        scan.greyfront_image = dt.Rows[i]["front_grey"].ToString() == "" || dt.Rows[i]["front_grey"] == null ? ImageToBase64(root + "\\ScanimageGreyFront" + (i + 1) + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg") : dt.Rows[i]["front_grey"].ToString();
                        scan.greyback_image = dt.Rows[i]["back_grey"].ToString() == "" || dt.Rows[i]["back_grey"] == null ? ImageToBase64(root + "\\ScanimageGreyBack" + (i + 1) + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".jpg") : dt.Rows[i]["back_grey"].ToString();
                        scan.status = "";
                        scan.scan_id = 0;
                        if (scan.front_image.Length == 0)
                        {
                            LogHelper.WriteLog("scan image checking  :" + i);
                            LogHelper.WriteLog("scan image checking  :" + scan.front_image.Length);
                        }
                        //scan.front_uv_image = dt.Rows[i]["front_uv_image"].ToString() == "" ? "" : dt.Rows[i]["front_uv_image"].ToString();
                        //scan.back_uv_image = dt.Rows[i]["back_uv_image"].ToString() == "" ? "" : dt.Rows[i]["back_uv_image"].ToString();
                        string[] result = objscanner.SaveScanedDetails(scan);
                        if (result[1] == "1")
                        {
                            LogHelper.WriteLog("Succeeed :" + i);
                            success++;
                        }
                        else
                        {
                            LogHelper.WriteLog("Failed :" + i);
                            failed++;
                        }
                    }
                    MessageBox.Show("Data Uploaded : " + success + "; Failed : " + failed, "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PicbxScannedFront.Image = null;
                    pictureScannedImageBack.Image = null;
                    axRanger1.ShutDown();
                    this.Close();
                    if (!Directory.Exists(root))
                    {
                        string[] files = Directory.GetFiles(root);
                        for (int k = 0; k < files.Length; k++)
                        {
                            File.Delete(files[k]);
                        }
                        Directory.Delete(root);
                    }

                }
                else
                {
                    //MessageBox.Show("Shoult Not Exit Untill the Scan Completed");
                    DialogResult dg1 = MessageBox.Show("Scanner Pending..Rescan?", "Check Mandate System", MessageBoxButtons.YesNo);
                    if (dg1 == DialogResult.Yes)
                    {
                        if (grdScanning.Rows.Count > 0)
                        {
                            btnContinue.Enabled = true;
                            btnContinue.Focus();
                        }
                        else
                        {
                            btnrange.Focus();
                        }
                    }
                    else
                    {
                        axRanger1.ShutDown();
                        Thread.Sleep(1000);
                        this.Close();
                    }
                    //DialogResult dg1 = MessageBox.Show("Should Not Exit Untill the Scan is Completed... Do you want to Continue the Scan.....", "Check Mandate System", MessageBoxButtons.YesNo);
                    //if (dg1 == DialogResult.Yes)
                    //{
                    //    if (grdScanning.Rows.Count > 0)
                    //    {
                    //        //ContinueScan();
                    //    }
                    //    else
                    //    {
                    //        //ScanningProcess();
                    //    }
                    //}
                    //else
                    //{

                    //    this.Close();
                    //    Scanner sc = new Scanner();
                    //    sc.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PicLoad.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            LogHelper.WriteLog("Ranger Started....");
            try
            {
                axRanger1.StartUp();
                //btnImgScan.Enabled = true;
                btnrange.Enabled = false;
                //if (grdScanning.Rows.Count > 0)
                //{
                //    axRanger1.ShutDown();
                //    scan_type = "UV Scan";
                //    axRanger1.StartUp();
                //    Thread.Sleep(20000);
                //}
                //else
                //{
                //    scan_type = "Image Scan";
                //    axRanger1.StartUp();
                //}
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                //if (scan_type == "Image Scan")
                //{
                int checkCount = Convert.ToInt32(check_Count);
                int scanCount = grdScanning.Rows.Count;
                if (checkCount != scanCount)
                {
                    int FeedSourceMainHopper = 0,
                        FeedContinuously = 0;
                    axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
                }
                else
                {
                    btnrange.Enabled = true;
                    //btnuvscan.Enabled = true;
                    btnContinue.Enabled = false;
                }
                //}
                //else if (scan_type == "UV Scan")
                //{
                //    int checkCount = Convert.ToInt32(check_Count);
                //    if (checkCount != uvCount)
                //    {
                //        int FeedSourceMainHopper = 0,
                //            FeedContinuously = 0;
                //        axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
                //    }
                //    else
                //    {
                //        vtnexit.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grdScanning_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int rowindex = grdScanning.CurrentCell.RowIndex;
                //int rowindex = grdScanning.CurrentCell.RowIndex;
                string Fbase = grdScanning.Rows[rowindex].Cells["front_image"].Value.ToString();
                string Bbase = grdScanning.Rows[rowindex].Cells["back_image"].Value.ToString();
                PicbxScannedFront.Image = ReturnImage(Fbase);
                pictureScannedImageBack.Image = ReturnImage(Bbase);
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Shut Down and Start the Ranger...");
            axRanger1.ShutDown();
            this.Close();
        }
        private void btnuvscan_Click(object sender, EventArgs e)
        {
            scan_type = "UV Scan";
            uvCount = 0;
            i = 0;
            count = 0;
            btnuvscan.Enabled = false;
            //btnContinue.Enabled = true;
            //scan_type = "UV Scan";
            GrVwBatching.Rows[0].Cells[5].Value = 0;
            GrVwBatching.Rows[0].Cells[6].Value = 0;
            try
            {
                int FeedSourceMainHopper = 0,
                    FeedContinuously = 0;
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
                PicLoad.Visible = false;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            try
            {
                if (PicbxScannedFront.Visible == true)
                {
                    PicbxScannedFront.Visible = false;
                    pictureScannedImageBack.Visible = true;
                }
                else if (pictureScannedImageBack.Visible == true)
                {
                    PicbxScannedFront.Visible = true;
                    pictureScannedImageBack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void ScannerRangers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        //private void button1_Click(object sender, EventArgs e)
        //{

        //    vtnexit.Enabled = true;
        //}
        #endregion

        #region ConvertToGreyConverts
        public string Downscale(byte[] imgBits, string fileName)
        {
            string basestrg = "";
            try
            {
                int pageCount = -1;
                {

                    string filenameext1 = fileName + "_grey.jpg";
                    string path = filenameext1;
                    using (MemoryStream ms = new MemoryStream(imgBits))
                    {
                        basestrg = GrayGenerateThumbnails(0.1, ms, fileName);
                        //EnhanceGenerateThumbnails(15.5, ms, path2);
                    }
                }
                return basestrg;
            }
            catch (Exception ex)
            {
                return basestrg = "";
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GrayGenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            string base64 = "";
            try
            {
                using (var image1 = Image.FromStream(sourcePath))
                {
                    Bitmap bmp = new Bitmap(sourcePath);
                    var image = MakeGrayscale(bmp);
                    //var newWidth = (int)(image.Width * scaleFactor);
                    //var newHeight = (int)(image.Height * scaleFactor);
                    //image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    var newWidth = 798;
                    var newHeight = 369;
                    var thumbnailImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbnailImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imageRectangle);
                    thumbnailImg.SetResolution(100, 100);

                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);

                    EncoderParameters ep = new EncoderParameters(3);
                    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
                    ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
                    thumbnailImg.Save(targetPath, image.RawFormat);

                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    thumbnailImg.Save(targetPath, jpgEncoder, myEncoderParameters);
                    thumbnailImg.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] imageBytes = stream.ToArray();
                    base64 = Convert.ToBase64String(imageBytes);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return base64;
        }
        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original

            Bitmap newBitmap = new Bitmap(original, new Size(787, 364));
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(original,
               new Rectangle(0, 0, 787, 364),
               0, 0, original.Width, original.Height,
               GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();

            return newBitmap;
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        #endregion

        //private void btCorrection_Click(object sender, EventArgs e)
        //{
        //        try
        //        {
        //            for (int i = 0; i < grdScanning.Rows.Count; i++)
        //            {
        //                //    string tempFilename = "";
        //                //    tempFilename = grdScanning.Rows[i].Cells["front_image_fileName"].Value.ToString(); ;
        //                //    string nfr = ImageToBase64(tempFilename);
        //                //    grdScanning.Rows[i].Cells["front_image"].Value = nfr;
        //                //    tempFilename = grdScanning.Rows[i].Cells["back_image_fileName"].Value.ToString();
        //                //    string nfr1 = ImageToBase64(tempFilename);
        //                //    grdScanning.Rows[i].Cells["back_image"].Value = nfr1;
        //                //    tempFilename = grdScanning.Rows[i].Cells["front_uv_image_fileName"].Value.ToString(); ;
        //                //    string nfr2 = ImageToBase64(tempFilename);
        //                //    grdScanning.Rows[i].Cells["front_uv_image"].Value = nfr2;
        //                //    tempFilename = grdScanning.Rows[i].Cells["front_gray_image_filename"].Value.ToString(); ;
        //                //    string nfr3 = ImageToBase64(tempFilename);
        //                //    grdScanning.Rows[i].Cells["front_grey"].Value = nfr3;
        //                //    tempFilename = grdScanning.Rows[i].Cells["back_grey_image_filename"].Value.ToString(); ;
        //                //    string nfr4 = ImageToBase64(tempFilename);
        //                //    grdScanning.Rows[i].Cells["back_grey"].Value = nfr4;

        //                if (grdScanning.Rows[i].Cells["front_image"].Value == null || grdScanning.Rows[i].Cells["front_image"].Value == "")
        //                {
        //                    string tempFilename = grdScanning.Rows[i].Cells["front_image_fileName"].Value.ToString();
        //                    string nfr = ImageToBase64(tempFilename);
        //                    grdScanning.Rows[i].Cells["front_image"].Value = nfr;
        //                }
        //                if (grdScanning.Rows[i].Cells["back_image"].Value == null || grdScanning.Rows[i].Cells["back_image"].Value == "")
        //                {
        //                    string tempFilename = grdScanning.Rows[i].Cells["back_image_fileName"].Value.ToString();
        //                    string nfr = ImageToBase64(tempFilename);
        //                    grdScanning.Rows[i].Cells["back_image"].Value = nfr;
        //                }
        //                if (grdScanning.Rows[i].Cells["front_uv_image"].Value == null || grdScanning.Rows[i].Cells["front_uv_image"].Value == "")
        //                {
        //                    string tempFilename = grdScanning.Rows[i].Cells["front_uv_image_fileName"].Value.ToString();
        //                    string nfr = ImageToBase64(tempFilename);
        //                    grdScanning.Rows[i].Cells["front_uv_image"].Value = nfr;
        //                }
        //                if (grdScanning.Rows[i].Cells["front_grey"].Value == null || grdScanning.Rows[i].Cells["front_grey"].Value == "")
        //                {
        //                    string tempFilename = grdScanning.Rows[i].Cells["front_gray_image_filename"].Value.ToString();
        //                    string nfr = ImageToBase64(tempFilename);
        //                    grdScanning.Rows[i].Cells["front_grey"].Value = nfr;
        //                }
        //                if (grdScanning.Rows[i].Cells["back_grey"].Value == null || grdScanning.Rows[i].Cells["back_grey"].Value == "")
        //                {
        //                    string tempFilename = grdScanning.Rows[i].Cells["back_grey_image_filename"].Value.ToString();
        //                    string nfr = ImageToBase64(tempFilename);
        //                    grdScanning.Rows[i].Cells["back_grey"].Value = nfr;
        //                }
        //            }
        //            grdScanning.Update();
        //            grdScanning.Refresh();
        //            vtnexit.Enabled = true;
        //            MessageBox.Show("Correction Completed");
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.WriteLog(ex.ToString());
        //        }
        //    }
        //}

        //private void btCorrection_Click(object sender, EventArgs e)
        //{
        //    #region OldCode
        //    //string fileName = "";
        //    //int rowIndex = -1;
        //    //for (int i = 0; i < grdScanning.Rows.Count; i++)
        //    //{
        //    //    if (grdScanning.Rows[i].Cells["front_image"].Value.ToString() != "")
        //    //    {
        //    //        if (grdScanning.Rows[i].Cells["front_image"].Value.ToString() != "")
        //    //        {
        //    //            fileName = grdScanning.Rows[i].Cells["front_image_fileName"].Value.ToString();
        //    //            rowIndex = i + 1;
        //    //            break;
        //    //        }
        //    //    }
        //    //    else if (grdScanning.Rows[i].Cells["back_image"].Value.ToString() != "")
        //    //    {
        //    //        if (grdScanning.Rows[i].Cells["back_image"].Value.ToString() != "")
        //    //        {
        //    //            fileName = grdScanning.Rows[i].Cells["back_image_fileName"].Value.ToString();
        //    //            rowIndex = i + 1;
        //    //            break;
        //    //        }
        //    //    }
        //    //}

        //    //for (int i = 0; i < grdScanning.Rows.Count; i++)
        //    //{
        //    //    if (grdScanning.Rows[i].Cells["front_image"].Value.ToString() == "")
        //    //    {
        //    //        string tempFilename = fileName;
        //    //        // "ScanimageFront"
        //    //        //   ScanimageBack
        //    //        if (tempFilename.Contains("ScanimageFront" + rowIndex))
        //    //        {
        //    //            tempFilename = tempFilename.Replace("ScanimageFront" + rowIndex, "ScanimageFront" + i);
        //    //        }
        //    //        else if (tempFilename.Contains("ScanimageBack" + rowIndex))
        //    //        {
        //    //            tempFilename = tempFilename.Replace("ScanimageBack" + rowIndex, "ScanimageFront" + i);
        //    //        }
        //    //        string nfr = ImageToBase64(tempFilename);
        //    //        // grdScanning.Rows[(i - 1)].Cells["front_image_fileName"].Value = root + filename;
        //    //        //  grdScanning.Rows[(i - 1)].Cells["front_image"].Value = nfr;
        //    //        grdScanning.Rows[i].Cells["front_image"].Value = nfr;
        //    //        grdScanning.Update();
        //    //        grdScanning.Refresh();
        //    //    }
        //    //    if (grdScanning.Rows[i].Cells["back_image"].Value.ToString() == "")
        //    //    {
        //    //        string tempFilename = fileName;
        //    //        // "ScanimageFront"
        //    //        //   ScanimageBack
        //    //        if (tempFilename.Contains("ScanimageFront" + rowIndex))
        //    //        {
        //    //            tempFilename = tempFilename.Replace("ScanimageFront" + rowIndex, "ScanimageBack" + i);
        //    //        }
        //    //        else if (tempFilename.Contains("ScanimageBack" + rowIndex))
        //    //        {
        //    //            tempFilename = tempFilename.Replace("ScanimageBack" + rowIndex, "ScanimageBack" + i);
        //    //        }
        //    //        string nfr = ImageToBase64(tempFilename);
        //    //        // grdScanning.Rows[(i - 1)].Cells["front_image_fileName"].Value = root + filename;
        //    //        //  grdScanning.Rows[(i - 1)].Cells["front_image"].Value = nfr;
        //    //        grdScanning.Rows[i].Cells["back_image"].Value = nfr;
        //    //        grdScanning.Update();
        //    //        grdScanning.Refresh();
        //    //    }
        //    //}
        //    #endregion
        //    try
        //    {
        //        for (int i = 0; i < grdScanning.Rows.Count; i++)
        //        {
        //            //    string tempFilename = "";
        //            //    tempFilename = grdScanning.Rows[i].Cells["front_image_fileName"].Value.ToString(); ;
        //            //    string nfr = ImageToBase64(tempFilename);
        //            //    grdScanning.Rows[i].Cells["front_image"].Value = nfr;
        //            //    tempFilename = grdScanning.Rows[i].Cells["back_image_fileName"].Value.ToString();
        //            //    string nfr1 = ImageToBase64(tempFilename);
        //            //    grdScanning.Rows[i].Cells["back_image"].Value = nfr1;
        //            //    tempFilename = grdScanning.Rows[i].Cells["front_uv_image_fileName"].Value.ToString(); ;
        //            //    string nfr2 = ImageToBase64(tempFilename);
        //            //    grdScanning.Rows[i].Cells["front_uv_image"].Value = nfr2;
        //            //    tempFilename = grdScanning.Rows[i].Cells["front_gray_image_filename"].Value.ToString(); ;
        //            //    string nfr3 = ImageToBase64(tempFilename);
        //            //    grdScanning.Rows[i].Cells["front_grey"].Value = nfr3;
        //            //    tempFilename = grdScanning.Rows[i].Cells["back_grey_image_filename"].Value.ToString(); ;
        //            //    string nfr4 = ImageToBase64(tempFilename);
        //            //    grdScanning.Rows[i].Cells["back_grey"].Value = nfr4;

        //            if (grdScanning.Rows[i].Cells["front_image"].Value == null || grdScanning.Rows[i].Cells["front_image"].Value == "")
        //            {
        //                string tempFilename = grdScanning.Rows[i].Cells["front_image_fileName"].Value.ToString();
        //                string nfr = ImageToBase64(tempFilename);
        //                grdScanning.Rows[i].Cells["front_image"].Value = nfr;
        //            }
        //            if (grdScanning.Rows[i].Cells["back_image"].Value == null || grdScanning.Rows[i].Cells["back_image"].Value == "")
        //            {
        //                string tempFilename = grdScanning.Rows[i].Cells["back_image_fileName"].Value.ToString();
        //                string nfr = ImageToBase64(tempFilename);
        //                grdScanning.Rows[i].Cells["back_image"].Value = nfr;
        //            }
        //            if (grdScanning.Rows[i].Cells["front_uv_image"].Value == null || grdScanning.Rows[i].Cells["front_uv_image"].Value == "")
        //            {
        //                string tempFilename = grdScanning.Rows[i].Cells["front_uv_image_fileName"].Value.ToString();
        //                string nfr = ImageToBase64(tempFilename);
        //                grdScanning.Rows[i].Cells["front_uv_image"].Value = nfr;
        //            }
        //            if (grdScanning.Rows[i].Cells["front_grey"].Value == null || grdScanning.Rows[i].Cells["front_grey"].Value == "")
        //            {
        //                string tempFilename = grdScanning.Rows[i].Cells["front_gray_image_filename"].Value.ToString();
        //                string nfr = ImageToBase64(tempFilename);
        //                grdScanning.Rows[i].Cells["front_grey"].Value = nfr;
        //            }
        //            if (grdScanning.Rows[i].Cells["back_grey"].Value == null || grdScanning.Rows[i].Cells["back_grey"].Value == "")
        //            {
        //                string tempFilename = grdScanning.Rows[i].Cells["back_grey_image_filename"].Value.ToString();
        //                string nfr = ImageToBase64(tempFilename);
        //                grdScanning.Rows[i].Cells["back_grey"].Value = nfr;
        //            }
        //        }
        //        grdScanning.Update();
        //        grdScanning.Refresh();
        //        vtnexit.Enabled = true;
        //        MessageBox.Show("Correction Completed");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}

    }
}