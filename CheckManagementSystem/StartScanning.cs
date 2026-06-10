using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using VintaSoft.Tiff;
using VintaSoft.Twain;

namespace CheckManagementSystem
{
    public partial class StartScanning : Form
    {
        #region Initialization
        private string batch_num = string.Empty;
        private string check_Count = string.Empty;
        private string batch_amt = string.Empty;
        private string dep_slip_no = string.Empty;
        private string cust_name = string.Empty;
        string[] frontImageList;
        string[] backImageList;
        string[] files;
        int i = 0;
        int j = 0;
        VintaSoft.Twain.VSTwain objVSTwain = new VintaSoft.Twain.VSTwain();
        VintaSoft.Tiff.VSTiff objVStiff;
        string msPaperSize;
        bool mbDuplexFlag;
        int mnPageCount;
        int scanCount = 0;
        string root = string.Empty;
        DataTable dtMicrList;
        #endregion

        #region Constructor
        public StartScanning()
        {
            InitializeComponent();
            GrVwBatching.Columns["Chq Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrVwBatching.Columns["Batch Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        public StartScanning(string _batch_no, string _check_count, string _batch_amount, string _dep_slip_no, string _cust_code)
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
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        public void ScanningProcess()
        {
            try
            {
                PicLoad.Visible = true;
                pictureScannedImageBack.Image = null;
                PicbxScannedFront.Image = null;
                Scanning();
                //ImplementOCR();
                PicLoad.Visible = false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        public void Scanning()
        {
            try
            {
                int check_count = Convert.ToInt32(check_Count);
                string sbatchno = batch_num;
                sbatchno = sbatchno.Replace("/", "-");
                string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //string DestinationFile = System.Configuration.ConfigurationManager.AppSettings["DestinationFolder"].ToString();
                string batch_no = batch_num;
                batch_no = batch_no.Replace('/', '-');
                root = exePath + "\\Scanimage\\" + batch_no;
                //string root = DestinationFile;
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

                int i;
                string VSUserName;
                string VSUserMail;
                string VSRegCode;
                string msg = "";
                string lsScanFileName = "";
                bool flag = false;
                VSUserName = "Sundar Sharma";
                VSUserMail = "rama@vcidex.com";
                VSRegCode = "TcImTlXpAerMTuW+8Lk9vvPEj1KgZcHZQrP8DV5CnYDaa89eqxit5BgXgviV3LKFub33h5gsIEjq/eF4WuM2Hm7EESBIR8a3qr2mu" + "lByY1QmoKQcySAvCNQRSYK7CkA1hHCS4gz2317sNjvkBymOTJlFReydFSgJIxIzq5CSvrYk";
                objVSTwain.Register(VSUserName, VSUserMail, VSRegCode);
                objVSTwain.StartDevice();
                for (i = 0; (i <= (objVSTwain.sourcesCount - 1)); i++)
                {
                    if ((objVSTwain.GetSourceProductName(i) == "Canon DR-7580 TWAIN 1.88 (32-32)"))
                    {
                        objVSTwain.sourceIndex = i;
                        objVSTwain.SelectSource();
                        break;
                    }
                }
                objVSTwain.showUI = true;
                objVSTwain.disableAfterAcquire = true;
                objVSTwain.autoCleanBuffer = true;
                objVSTwain.OpenDataSource();
                // objVSTwain.unitOfMeasure = UnitOfMeasure.Inches
                objVSTwain.tiffMultiPage = true;
                objVSTwain.fileFormat = FileFormat.Tiff;
                objVSTwain.tiffCompression = VintaSoft.Twain.TiffCompression.CCITGroup4;
                objVSTwain.duplexEnabled = true;
                switch (msPaperSize)
                {
                    case "A3":
                        objVSTwain.pageSize = PageSize.A3;
                        break;
                    case "A4":
                        objVSTwain.pageSize = PageSize.A4;
                        break;
                    case "A5":
                        objVSTwain.pageSize = PageSize.A5;
                        break;
                    case "LETTER":
                        objVSTwain.pageSize = PageSize.USLETTER;
                        break;
                    default:
                        objVSTwain.pageSize = PageSize.USLEGAL;
                        break;
                }
                if (objVSTwain.feederPresent)
                {
                    objVSTwain.feederEnabled = true;
                    objVSTwain.autoFeed = true;
                    objVSTwain.xferCount = 32767;
                    int count = 0;

                    if (objVSTwain.feederLoaded)
                    {
                        while (objVSTwain.AcquireModal())
                        {
                            try
                            {
                                count++;
                                if (count % 2 == 0)
                                {
                                    //lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    if (!objVSTwain.SaveImage(0, lsScanFileName))
                                    {
                                        return;
                                    }
                                    objVStiff = new VSTiff(lsScanFileName);
                                }
                                else
                                {
                                    //lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    if (!objVSTwain.SaveImage(0, lsScanFileName))
                                    {
                                        return;
                                    }
                                    objVStiff = new VSTiff(lsScanFileName);
                                    scanCount++;
                                    HighlightOCR(lsScanFileName, count);
                                }
                                // gnNumber = objVStiff.numImages;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("" + ex.Message);
                            }
                        }
                    }
                }
                objVSTwain.CloseDataSource();
                objVSTwain.StopDevice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ImplementOCR()
        {
            try
            {
                string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string batch_no = batch_num;
                batch_no = batch_no.Replace('/', '-');
                string root = exePath + "\\Scanimage\\" + batch_no;
                files = System.IO.Directory.GetFiles(root);
                string[] filePaths = Directory.GetFiles(root);
                var sort = from fn in filePaths orderby new FileInfo(fn).CreationTime ascending select fn;
                int m = 0;
                foreach (string n in sort)
                {
                    filePaths[m] = n;
                    m++;
                }
                int filescount = 0;
                if (grdScanning.Rows.Count == 0)
                {
                    PicbxScannedFront.Image = new Bitmap(filePaths[i]);
                    PicbxScannedFront.SizeMode = PictureBoxSizeMode.StretchImage;
                    i++;
                    pictureScannedImageBack.Image = new Bitmap(filePaths[i]);
                    pictureScannedImageBack.SizeMode = PictureBoxSizeMode.StretchImage;
                    filescount = Convert.ToInt32(filePaths.Length) / 2;
                }
                else
                {
                    int rowindex = (grdScanning.Rows.Count - 1);
                    string fileindex = grdScanning.Rows[rowindex].Cells[5].Value.ToString();
                    string[] flindx = fileindex.Split(',');
                    i = Convert.ToInt32(flindx[0]);
                    filescount = Convert.ToInt32(filePaths.Length) / 2;

                }
                int a = 0;

                if (grdScanning.Rows.Count == 0)
                {
                    a = 0;

                }
                else
                {
                    a = grdScanning.Rows.Count;
                }
                for (int j = a; a < filescount; a++)
                {
                    var img = new Bitmap(filePaths[i]);
                    string[] s = { "\\bin" };
                    string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\tessdata";
                    var ocr = new TesseractEngine(path, "mcr+oab", EngineMode.TesseractOnly);
                    var page = ocr.Process(img);
                    string ocrtxt = page.GetText();
                    //string Che_Mic_Bas_Tra = GetCheMicBasTra(page.GetText().Trim());
                    string[] result = GetCheMicBasTra(page.GetText().Trim());
                    string cheq_no = result[0];
                    string sort_code = result[1];
                    string tran_code = result[2];
                    string base_code = result[3];
                    grdScanning.Rows.Add((a + 1), cheq_no, sort_code, base_code, tran_code, (i + "," + (i - 1)));

                    //string fileindex = grdScanning.Rows[grdScanning.Rows.Count-1].Cells[5].Value.ToString();
                    //string[] flindx = fileindex.Split(',');

                    //PicbxScannedFront.Image = new Bitmap(filePaths[Convert.ToInt32(flindx[1])]);
                    //PicbxScannedFront.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (grdScanning.Rows[(a)].Cells["check_no"].Value.ToString() == "")
                    {
                        grdScanning[1, (a)].Style.BackColor = Color.Yellow;
                    }
                    if (grdScanning.Rows[(a)].Cells["sort_codes"].Value.ToString() == "")
                    {
                        grdScanning[2, (a)].Style.BackColor = Color.Yellow;
                    }
                    if (grdScanning.Rows[(a)].Cells["base_codes"].Value.ToString() == "")
                    {
                        grdScanning[3, (a)].Style.BackColor = Color.Yellow;
                    }
                    if (grdScanning.Rows[(a)].Cells["tran_Codes"].Value.ToString() == "")
                    {
                        grdScanning[4, (a)].Style.BackColor = Color.Yellow;
                    }
                    i = i + 2;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private void HighlightOCR(string filepath, int count)
        {
            try
            {
                PicbxScannedFront.Refresh();
                grdScanning.Refresh();
                var img = new Bitmap(filepath);
                string[] s = { "\\bin" };
                string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\tessdata";
                //string path = "D:\\tessdata";
                var ocr = new TesseractEngine(path, "mcr+oab", EngineMode.TesseractOnly);
                var page = ocr.Process(img);
                string ocrtxt = page.GetText();
                //string Che_Mic_Bas_Tra = GetCheMicBasTra(page.GetText().Trim());
                string[] result = GetCheMicBasTra(page.GetText().Trim());
                i = count;
                pictureScannedImageBack.Image = new Bitmap(filepath);
                string cheq_no = result[0] == "" ? "000000" : result[0];
                string sort_code = result[1] == "" ? "000000000" : result[1];
                string tran_code = result[2] == "" ? "00" : result[2];
                string base_code = result[3] == "" ? "000000" : result[3];
                //File.Delete(filePaths[0]);
                ScannerEntities scan = new ScannerEntities();
                j++;
                //txtScancount.Text = j.ToString();
                //txtDifference.Text = (Convert.ToInt32(txtCheckCount.Text) - j).ToString();
                //grdScanning.Rows.Add();
                //grdScanning.Rows.Add((a + 1), cheq_no, sort_code, base_code, tran_code, (i + "," + (i - 1)));
                grdScanning.Columns["serial_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdScanning.Columns["check_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdScanning.Columns["sort_codes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdScanning.Columns["base_codes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdScanning.Columns["tran_Codes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //grdScanning.Rows.Add(j, cheq_no, sort_code, base_code, tran_code, "LLL");
                grdScanning.Rows.Add(j, cheq_no, sort_code, base_code, tran_code, (i + "," + (i - 1)));
                grdScanning.Rows[grdScanning.Rows.Count - 1].Selected = true;
                string fileindex = grdScanning.Rows[grdScanning.Rows.Count - 1].Cells[5].Value.ToString();
                string[] flindx = fileindex.Split(',');

                PicbxScannedFront.Image = new Bitmap(filepath); //(filepath[Convert.ToInt32(flindx[1])]);
                PicbxScannedFront.SizeMode = PictureBoxSizeMode.StretchImage;
                //  pictureScannedImageBack.Image = new Bitmap(filePaths[Convert.ToInt32(flindx[0])]);
                //pictureScannedImageBack.SizeMode = PictureBoxSizeMode.StretchImage;
                string tempcheque = grdScanning.Rows[(j - 1)].Cells["check_no"].Value.ToString();
                string tempSortCode = grdScanning.Rows[(j - 1)].Cells["sort_codes"].Value.ToString();
                string tempBaseCode = grdScanning.Rows[(j - 1)].Cells["base_codes"].Value.ToString();
                //  ScannerBusiness sb = new ScannerBusiness();
                //  DataTable dtMicrList = sb.GetMicrList();
                //string Micr_Code = /dtScanned.Rows[i]["sort_codes"].ToString();
                bool contains = dtMicrList.AsEnumerable().Any(row => tempSortCode == row.Field<String>("MICR_CODE"));
                string tempTranCode = grdScanning.Rows[(j - 1)].Cells["tran_Codes"].Value.ToString();
                if (tempcheque.Length != 6 || tempcheque == "000000")
                {
                    grdScanning[1, (j - 1)].Style.BackColor = Color.Yellow;
                }
                if (tempSortCode.Length != 9 || !contains || tempSortCode == "000000000")  // Need to validate with branch master micr_Code
                {
                    grdScanning[2, (j - 1)].Style.BackColor = Color.Yellow;
                }
                if (tempBaseCode.Length != 6 )
                {
                    grdScanning[3, (j - 1)].Style.BackColor = Color.Yellow;
                }
                if (tempTranCode.Length != 2 || tempTranCode == "00")
                {
                    grdScanning[4, (j - 1)].Style.BackColor = Color.Yellow;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private string[] GetCheMicBasTra(string inputStr)
        {
            string[] result = new string[4];
            try
            {
                //V1
                //string tranCode = inputStr.Substring(inputStr.LastIndexOf(' ')).Trim();
                //string tempStr = inputStr.Substring(inputStr.LastIndexOf('[')).Substring(1); //.Substring(0, baseCode.IndexOf("@"));
                //string baseCode = tempStr.Substring(0, tempStr.IndexOf('@')).Trim();
                //tempStr = inputStr.Substring(inputStr.LastIndexOf('-') + 4).Trim();
                //string chequeNo = tempStr.Substring(0, tempStr.IndexOf('@'));
                //string micrCode = tempStr.Substring(tempStr.IndexOf(' '), 10).Trim();
                //string tranCode = inputStr.Substring(inputStr.LastIndexOf(' ')).Trim();


                //v2

                //string tempStr = inputStr.Substring(inputStr.LastIndexOf('[')).Substring(1); //.Substring(0, baseCode.IndexOf("@"));
                ////string baseCode = tempStr.Substring(0, tempStr.IndexOf('@')).Trim();
                //tempStr = inputStr.Substring(inputStr.LastIndexOf('-') + 4).Trim();
                ////  tempStr =   tempStr.Substring(tempStr.IndexOf('@'));
                //// string chequeNo = tempStr.Substring(0, tempStr.IndexOf('@'));
                //// string micrCode = tempStr.Substring(tempStr.IndexOf(' '), 10).Trim();

                //string[] Data = tempStr.Split('@');
                //string chequeNo = Data[1];
                //string micrCode = Data[2].Split('[')[0];
                //string tranCode = Data[2].Split('[')[1];
                //string baseCode = Data[3];
                //textBox1.Text = chequeNo + "/" + micrCode + "/" + baseCode + "/" + tranCode;
                //return chequeNo + "/" + micrCode + "/" + baseCode + "/" + tranCode;


                //V3
                ////string chequeNo = "";
                ////string micrCode = "";
                ////string baseCode = "";
                ////string tranCode = "";
                ////string tempStr = Regex.Replace(inputStr, @"\n", "");
                ////tempStr = tempStr.Replace('[', '@').Replace('-', ' ');// Regex.Replace(tempStr, @"[", "@");
                ////string[] CheMicBasTrn = tempStr.Split('@');
                ////chequeNo = CheMicBasTrn[CheMicBasTrn.Length - 4];
                ////micrCode = CheMicBasTrn[CheMicBasTrn.Length - 3];
                ////baseCode = CheMicBasTrn[CheMicBasTrn.Length - 2];
                ////tranCode = CheMicBasTrn[CheMicBasTrn.Length - 1].Trim().Substring(0, 2);
                //////textBox1.Text = chequeNo.Trim() + "/" + micrCode.Trim() + "/" + baseCode.Trim() + "/" + tranCode.Trim();
                //////return textBox1.Text;
                ////result[0] = chequeNo;
                ////result[1] = micrCode;
                ////result[2] = tranCode;
                ////result[3] = baseCode;

                //V4

                string chequeNo = "";
                string micrCode = "";
                string baseCode = "";
                string tranCode = "";
                string tempStr = Regex.Replace(inputStr, @"\n| ", "").Trim();
                // To find the Base code is present or not
                int lIndex = tempStr.Contains('[') ? tempStr.LastIndexOf('[') : 0;
                int len1 = tempStr.Substring(lIndex).Length;
                tempStr = len1 == 3 ? tempStr.Replace("[", "@@") : tempStr.Replace('[', '@');
                string[] CheMicBasTrn = tempStr.Split('@');
                chequeNo = CheMicBasTrn[CheMicBasTrn.Length - 4];
                micrCode = CheMicBasTrn[CheMicBasTrn.Length - 3];
                //int a = CheMicBasTrn[CheMicBasTrn.Length - 2].Length;
                baseCode = CheMicBasTrn[CheMicBasTrn.Length - 2].Length == 0 ? "000000" : CheMicBasTrn[CheMicBasTrn.Length - 2].Replace("-", "");
                tranCode = CheMicBasTrn[CheMicBasTrn.Length - 1];
                //textBox1.Text = chequeNo.Trim() + "/" + micrCode.Trim() + "/" + baseCode.Trim() + "/" + tranCode.Trim();
                //return textBox1.Text;

                chequeNo = Regex.Replace(chequeNo, "[^.0-9]", "");
                micrCode = Regex.Replace(micrCode, "[^.0-9]", "");
                tranCode = Regex.Replace(tranCode, "[^.0-9]", "");
                baseCode = Regex.Replace(baseCode, "[^.0-9]", "");

                result[0] = chequeNo.Trim();
                result[1] = micrCode.Trim();
                result[2] = tranCode.Trim().Substring(0, 2);
                result[3] = baseCode.Trim();

            }
            catch (Exception ex)
            {
                result[0] = "";
                result[1] = "";
                result[2] = "";
                result[3] = "";
            }
            //return chequeNo + "/" + micrCode + "/" + baseCode + "/" + tranCode;
            return result;
        }
        private string[] ValidateMICR(DataTable dt)
        {
            string[] result = new string[3];
            bool isvalid = false;
            try
            {
                ScannerBusiness sb = new ScannerBusiness();
                for (int l = 0; l < dt.Rows.Count; l++)
                {
                    string micr_code = dt.Rows[l]["sort_codes"].ToString();
                    isvalid = sb.ValidateMICR(micr_code);
                    result[0] = isvalid.ToString();
                    result[1] = micr_code;
                    result[2] = l.ToString();
                    if (result[0] == "False")
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return result;
        }
        private void ContinueScan()
        {
            try
            {
                int i;
                string VSUserName;
                string VSUserMail;
                string VSRegCode;
                string msg = "";
                string lsScanFileName = "";
                bool flag = false;
                VSUserName = "Sundar Sharma";
                VSUserMail = "rama@vcidex.com";
                VSRegCode = "TcImTlXpAerMTuW+8Lk9vvPEj1KgZcHZQrP8DV5CnYDaa89eqxit5BgXgviV3LKFub33h5gsIEjq/eF4WuM2Hm7EESBIR8a3qr2mu" + "lByY1QmoKQcySAvCNQRSYK7CkA1hHCS4gz2317sNjvkBymOTJlFReydFSgJIxIzq5CSvrYk";
                objVSTwain.Register(VSUserName, VSUserMail, VSRegCode);
                objVSTwain.StartDevice();
                for (i = 0; (i <= (objVSTwain.sourcesCount - 1)); i++)
                {
                    if ((objVSTwain.GetSourceProductName(i) == "Canon DR-7580 TWAIN 1.88 (32-32)"))
                    {
                        objVSTwain.sourceIndex = i;
                        objVSTwain.SelectSource();
                        break;
                    }
                }
                objVSTwain.showUI = true;
                objVSTwain.disableAfterAcquire = true;
                objVSTwain.autoCleanBuffer = true;
                objVSTwain.OpenDataSource();
                // objVSTwain.unitOfMeasure = UnitOfMeasure.Inches
                objVSTwain.tiffMultiPage = true;
                objVSTwain.fileFormat = FileFormat.Tiff;
                objVSTwain.tiffCompression = VintaSoft.Twain.TiffCompression.CCITGroup4;
                objVSTwain.duplexEnabled = true;
                switch (msPaperSize)
                {
                    case "A3":
                        objVSTwain.pageSize = PageSize.A3;
                        break;
                    case "A4":
                        objVSTwain.pageSize = PageSize.A4;
                        break;
                    case "A5":
                        objVSTwain.pageSize = PageSize.A5;
                        break;
                    case "LETTER":
                        objVSTwain.pageSize = PageSize.USLETTER;
                        break;
                    default:
                        objVSTwain.pageSize = PageSize.USLEGAL;
                        break;
                }
                if (objVSTwain.feederPresent)
                {
                    objVSTwain.feederEnabled = true;
                    objVSTwain.autoFeed = true;
                    objVSTwain.xferCount = 32767;
                    int rowindex = (grdScanning.Rows.Count - 1);
                    string fileindex = grdScanning.Rows[rowindex].Cells[5].Value.ToString();
                    string[] flindx = fileindex.Split(',');
                    int count = Convert.ToInt32(flindx[0]);
                    count = count + 1;
                    if (objVSTwain.feederLoaded)
                    {
                        while (objVSTwain.AcquireModal())
                        {
                            try
                            {
                                count++;
                                if (count % 2 == 0)
                                {
                                    //lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    if (!objVSTwain.SaveImage(0, lsScanFileName))
                                    {
                                        return;
                                    }
                                    objVStiff = new VSTiff(lsScanFileName);
                                }
                                else
                                {
                                    //lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
                                    if (!objVSTwain.SaveImage(0, lsScanFileName))
                                    {
                                        return;
                                    }
                                    objVStiff = new VSTiff(lsScanFileName);
                                    HighlightOCR(lsScanFileName, count);
                                    scanCount++;

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("" + ex.Message);
                            }
                        }
                    }
                }
                objVSTwain.CloseDataSource();
                objVSTwain.StopDevice();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        #endregion

        #region Events
        private void StartScanning_Load(object sender, EventArgs e)
        {
            //CheckManagementSystem.ActiveForm.Enabled = false;
            //load.ShowDialog();
            LoadScanningData();
            //GrVwBatching.Columns["Chq Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //GrVwBatching.Columns["Batch Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrVwBatching.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrVwBatching.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrVwBatching.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrVwBatching.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //ScanningProcess();
            ////scanCount = scanCount / 2;
            //GrVwBatching.Rows[0].Cells[5].Value = scanCount.ToString();
            ////GrVwBatching.Rows[0].Cells[7].Value = (Convert.ToInt32(check_Count) - scanCount);
            ////load.Close();
            TheamClass.SetTheam(this);
        }
        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (PicbxScannedFront.Visible == true)
            {
                pictureScannedImageBack.Visible = true;
                PicbxScannedFront.Visible = false;
            }
            else if (pictureScannedImageBack.Visible == true)
            {
                pictureScannedImageBack.Visible = false;
                PicbxScannedFront.Visible = true;
            }
        }

        private void btnImgScan_Click(object sender, EventArgs e)
        {
            ScannerBusiness sb = new ScannerBusiness();
            dtMicrList = sb.GetMicrList();

            lblstatus.Visible = true;
            pictureScannedImageBack.Image = null;
            PicbxScannedFront.Image = null;
            ScanningProcess();
            int scanned = scanCount;
            GrVwBatching.Rows[0].Cells[5].Value = scanned.ToString();
            int difference = (Convert.ToInt32(check_Count) - scanned);
            GrVwBatching.Rows[0].Cells[6].Value = difference.ToString();
            //if (Convert.ToInt32(check_Count) == scanned)
            //{
            //    lblstatus.Text = "Scanning Completed..";
            //}
            //else
            //{
            //    DialogResult dg = MessageBox.Show("Checks are missed from Scanners! Do you want to Continue...", "Confirmation", MessageBoxButtons.YesNoCancel);
            //    if (dg == DialogResult.Yes)
            //    {
            //        DialogResult dgs = MessageBox.Show("Please Conform Scanner Tray has Checks..", "Confirmation", MessageBoxButtons.YesNoCancel);
            //        if (dgs == DialogResult.Yes)
            //        {
            //            ContinueScan();
            //            ImplementOCR();
            //            int count = grdScanning.Rows.Count;
            //            scanned =  scanned + grdScanning.Rows.Count;
            //            GrVwBatching.Rows[0].Cells[5].Value = scanned.ToString();
            //            int diff = (Convert.ToInt32(check_Count) - scanned);
            //            GrVwBatching.Rows[0].Cells[6].Value = difference.ToString();
            //        }
            //    }
            //}
            if (Convert.ToInt32(check_Count) != scanned)
            {
                do
                {
                    DialogResult dg = MessageBox.Show("Cheque Count Mismatched, Do you want to Rescan?", "Confirmation", MessageBoxButtons.YesNoCancel);

                    if (dg == DialogResult.Yes)
                    {
                        ContinueScan();
                        ImplementOCR();
                        int count = grdScanning.Rows.Count;
                        scanned = count;
                        GrVwBatching.Rows[0].Cells[5].Value = scanned.ToString();
                        int diff = (Convert.ToInt32(check_Count) - scanned);
                        GrVwBatching.Rows[0].Cells[6].Value = diff.ToString();
                    }
                    if (dg == DialogResult.No)
                    {
                        break;
                        this.Close();
                    }

                }
                while (Convert.ToInt32(check_Count) != scanned);
            }
            lblstatus.Visible = false;
            //btnvalidate.Enabled = true;
            //load.Close();
        }
        private void grdScanning_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdScanning.Rows.Count == Convert.ToInt32(check_Count))
                {
                    string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    string batch_no = batch_num;
                    batch_no = batch_no.Replace('/', '-');
                    string root = exePath + "\\Scanimage\\" + batch_no;
                    files = System.IO.Directory.GetFiles(root);
                    string[] filePaths = Directory.GetFiles(root);
                    var sort = from fn in filePaths orderby new FileInfo(fn).CreationTime ascending select fn;
                    int m = 0;
                    foreach (string n in sort)
                    {
                        filePaths[m] = n;
                        m++;
                    }

                    int rowindex = grdScanning.CurrentCell.RowIndex;
                    string fileindex = grdScanning.Rows[rowindex].Cells[5].Value.ToString();
                    string[] flindx = fileindex.Split(',');

                    PicbxScannedFront.Image = new Bitmap(filePaths[Convert.ToInt32(flindx[1])]);
                    PicbxScannedFront.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureScannedImageBack.Image = new Bitmap(filePaths[Convert.ToInt32(flindx[0])]);
                    pictureScannedImageBack.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                pictureScannedImageBack.Image = null;
                PicbxScannedFront.Image = null;
                ScanningProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void vtnexit_Click(object sender, EventArgs e)
        {
            PicbxScannedFront.Image = null;
            pictureScannedImageBack.Image = null;
            try
            {
                int scanned = scanCount;
                if (Convert.ToInt32(check_Count) == scanned)
                {
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
                        ScannerBusiness objscanner = new ScannerBusiness();
                        System.Data.DataColumn newColumn = new System.Data.DataColumn("batch_no", typeof(System.String));
                        newColumn.DefaultValue = batch_num;
                        dt.Columns.Add(newColumn);

                        System.Data.DataColumn frontimage = new System.Data.DataColumn("front_image", typeof(System.String));
                        newColumn.DefaultValue = "";
                        dt.Columns.Add(frontimage);

                        System.Data.DataColumn back_image = new System.Data.DataColumn("back_image", typeof(System.String));
                        newColumn.DefaultValue = "";
                        dt.Columns.Add(back_image);

                        System.Data.DataColumn front_uvimage = new System.Data.DataColumn("front_uv_image", typeof(System.String));
                        newColumn.DefaultValue = "";
                        dt.Columns.Add(front_uvimage);

                        System.Data.DataColumn bac_uvimage = new System.Data.DataColumn("back_uv_image", typeof(System.String));
                        newColumn.DefaultValue = "";
                        dt.Columns.Add(bac_uvimage);
                        //string[] result = ValidateMICR(dt);
                        //if (result[0] == "True")
                        //{
                        string response = objscanner.SaveScanedItems(dt);
                        if (response == "Success")
                        {
                            MessageBox.Show("Scanned Details Successfully Uploaded....");
                            this.Close();
                            //Scanner sc = new Scanner();
                            //sc.Refresh();

                            //Scanner frmscan = new Scanner();
                            //frmscan.MdiParent = StartScanning.ActiveForm;
                            //foreach (Form f in Application.OpenForms)
                            //{
                            //    if (f is Scanner)
                            //    {
                            //        f.Focus();
                            //        return;
                            //    }
                            //}
                            //Scanner sc = new Scanner();
                            //sc.Show();
                            //sc.Refresh();

                        }
                        ////}
                        //else
                        //{
                        //    MessageBox.Show("Please Check the MICR Code");
                        //    grdScanning[2, Convert.ToInt32(result[2])].Style.BackColor = Color.Red;
                        //}
                    }
                }
                else
                {
                    DialogResult dg1 = MessageBox.Show("Should Not Exit Untill the Scan is Completed... Do you want to Continue the Scan.....", "Check Mandate System", MessageBoxButtons.YesNo);
                    if (dg1 == DialogResult.Yes)
                    {
                        if (grdScanning.Rows.Count > 0)
                        {
                            ContinueScan();
                        }
                        else
                        {
                            ScanningProcess();
                        }
                    }
                    else
                    {

                        this.Close();
                        Scanner sc = new Scanner();
                        //sc.IsAccessible
                        sc.Close();
                        //Scanner sc = new Scanner();
                        //sc.Refresh();


                        //Scanner frmscan = new Scanner();
                        //frmscan.MdiParent = StartScanning.ActiveForm;
                        //foreach (Form f in Application.OpenForms)
                        //{
                        //    if (f is Scanner)
                        //    {
                        //        f.Focus();
                        //        return;
                        //    }
                        //}

                        //Scanner sc = new Scanner();
                        //sc.Show();
                        //sc.Refresh();

                        //Scanner scan = new Scanner();
                        ////scan.MdiParent = this;
                        //scan.Show();

                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private void btnvalidate_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            try
            {
                ScannerBusiness sb = new ScannerBusiness();
                DataTable dtMicrList = sb.GetMicrList();

                DataTable dtScanned = new DataTable();
                foreach (DataGridViewColumn col in grdScanning.Columns)
                {
                    dtScanned.Columns.Add(col.Name);
                }
                foreach (DataGridViewRow row in grdScanning.Rows)
                {
                    DataRow dRow = dtScanned.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dtScanned.Rows.Add(dRow);
                }

                for (int i = 0; i < dtScanned.Rows.Count; i++)
                {
                    string Micr_Code = dtScanned.Rows[i]["sort_codes"].ToString();
                    bool contains = dtMicrList.AsEnumerable().Any(row => Micr_Code == row.Field<String>("MICR_CODE"));
                    if (contains == true)
                    {

                    }
                    else
                    {
                        grdScanning[2, i].Style.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            PicLoad.Visible = false;
        }
        private void lblstatus_Click(object sender, EventArgs e)
        {

        }
        private void btnImgScan1_Click(object sender, EventArgs e)
        {

        }
        private void btnuvscan_Click(object sender, EventArgs e)
        {

        }
        private void grdScanning_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cellch = grdScanning.Rows[e.RowIndex].Cells["check_no"].Value == null ? "000000" : grdScanning.Rows[e.RowIndex].Cells["check_no"].Value.ToString();
                string cellchq = cellch.ToString();
                Color chColor = ((cellchq.Length != 6) || (cellchq == "000000") ? Color.Yellow : Color.White);
                grdScanning[1, e.RowIndex].Style.BackColor = chColor;
                grdScanning[1, e.RowIndex].Value = cellch;

                var cellso = grdScanning.Rows[e.RowIndex].Cells["sort_codes"].Value == null ? "000000000" : grdScanning.Rows[e.RowIndex].Cells["sort_codes"].Value.ToString();
                string cellsortcode = cellso.ToString();
                bool contains = dtMicrList.AsEnumerable().Any(row => cellsortcode == row.Field<String>("MICR_CODE"));
                Color chColor1 = (cellsortcode.Length != 9 || !contains || (cellchq == "000000000")) ? Color.Yellow : Color.White;
                grdScanning[2, e.RowIndex].Style.BackColor = chColor1;
                grdScanning[2, e.RowIndex].Value = cellsortcode;

                var cellbs = grdScanning.Rows[e.RowIndex].Cells["base_codes"].Value == null ? "000000" : grdScanning.Rows[e.RowIndex].Cells["base_codes"].Value.ToString();
                string cellbasecode = cellbs.ToString();
                //string cellbasecode = grdScanning.Rows[e.RowIndex].Cells["base_codes"].Value.ToString();
                Color chColor2 = ((cellbasecode.Length != 6)  ? Color.Yellow : Color.White);
                grdScanning[3, e.RowIndex].Style.BackColor = chColor2;
                grdScanning[3, e.RowIndex].Value = cellbasecode;

                var celltc = grdScanning.Rows[e.RowIndex].Cells["tran_Codes"].Value == null ? "00" : grdScanning.Rows[e.RowIndex].Cells["tran_Codes"].Value.ToString();
                string celltrancode = celltc.ToString();
                //string celltrancode = grdScanning.Rows[e.RowIndex].Cells["tran_Codes"].Value.ToString();
                Color chColor3 = celltrancode.Length != 2 || (celltrancode == "00") ? Color.Yellow : Color.White;
                grdScanning[4, e.RowIndex].Style.BackColor = chColor3;
                grdScanning[4, e.RowIndex].Value = celltrancode;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }

            //if (cellsortcode.Length != 9)
            //{
            //    grdScanning[2, e.RowIndex].Style.BackColor = Color.Yellow;
            //}
            //else
            //{
            //    grdScanning[2, e.RowIndex].Style.BackColor = Color.White;
            //}
            //string cellbasecode = grdScanning.Rows[e.RowIndex].Cells["base_codes"].Value.ToString();
            //if (cellbasecode.Length != 6)
            //{
            //    grdScanning[3, e.RowIndex].Style.BackColor = Color.Yellow;
            //}
            // string celltrancode = grdScanning.Rows[e.RowIndex].Cells["tran_Codes"].Value.ToString();
            //if (celltrancode.Length != 2)
            //{
            //    grdScanning[4, e.RowIndex].Style.BackColor = Color.Yellow;
            //}
        }


        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void grdScanning_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
            }
        }
        #endregion

        private void btnRefersh_Click(object sender, EventArgs e)
        {
            try
            {
                ScannerBusiness sb = new ScannerBusiness();
                DataTable dtMicrList = sb.GetMicrList();
                for (int i = 0; i < grdScanning.Rows.Count; i++)
                {
                    var cellch = grdScanning.Rows[i].Cells["check_no"].Value == null ? "000000" : grdScanning.Rows[i].Cells["check_no"].Value.ToString();
                    string cellchq = cellch.ToString();
                    Color chColor = ((cellchq.Length != 6) || (cellchq == "000000") ? Color.Yellow : Color.White);
                    grdScanning[1, i].Style.BackColor = chColor;
                    grdScanning[1, i].Value = cellch;

                    var cellso = grdScanning.Rows[i].Cells["sort_codes"].Value == null ? "000000000" : grdScanning.Rows[i].Cells["sort_codes"].Value.ToString();
                    string cellsortcode = cellso.ToString();
                    bool contains = dtMicrList.AsEnumerable().Any(row => cellsortcode == row.Field<String>("MICR_CODE"));
                    Color chColor1 = (cellsortcode.Length != 9 || !contains || (cellchq == "000000000")) ? Color.Yellow : Color.White;
                    grdScanning[2, i].Style.BackColor = chColor1;
                    grdScanning[2, i].Value = cellsortcode;

                    var cellbs = grdScanning.Rows[i].Cells["base_codes"].Value == null ? "000000" : grdScanning.Rows[i].Cells["base_codes"].Value.ToString();
                    string cellbasecode = cellbs.ToString();
                    //string cellbasecode = grdScanning.Rows[e.RowIndex].Cells["base_codes"].Value.ToString();
                    Color chColor2 = ((cellbasecode.Length != 6) || (cellbasecode == "000000") ? Color.Yellow : Color.White);
                    grdScanning[3, i].Style.BackColor = chColor2;
                    grdScanning[3, i].Value = cellbasecode;

                    var celltc = grdScanning.Rows[i].Cells["tran_Codes"].Value == null ? "00" : grdScanning.Rows[i].Cells["tran_Codes"].Value.ToString();
                    string celltrancode = celltc.ToString();
                    //string celltrancode = grdScanning.Rows[e.RowIndex].Cells["tran_Codes"].Value.ToString();
                    Color chColor3 = celltrancode.Length != 2 || (celltrancode == "00") ? Color.Yellow : Color.White;
                    grdScanning[4, i].Style.BackColor = chColor3;
                    grdScanning[4, i].Value = celltrancode;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void grdScanning_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Left:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

    }
}
