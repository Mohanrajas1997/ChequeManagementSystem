using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VintaSoft.Twain;
using VintaSoft.Tiff;
using System.IO;
//using Tesseract;
namespace CheckManagementSystem
{
    public partial class Scanner : Form
    {
        #region Initialization
        //string[] frontImageList;
        //string[] backImageList;
        //string[] files;
        //int i = 0;
        //int j = 0;
        //VintaSoft.Twain.VSTwain objVSTwain = new VintaSoft.Twain.VSTwain();
        //VintaSoft.Tiff.VSTiff objVStiff;
        //string msPaperSize;
        //bool mbDuplexFlag;
        //int mnPageCount;
        //int ScanCount = 0;
        #endregion

        #region Constructor
        public Scanner()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods
        //public void Scanning()
        //{
        //    try
        //    {
        //        int check_count = Convert.ToInt32(txtCheckCount.Text);
        //        string sbatchno = txtbatchNo.Text;
        //        sbatchno = sbatchno.Replace("/", "-");
        //        string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        //        string DestinationFile = System.Configuration.ConfigurationManager.AppSettings["DestinationFolder"].ToString();
        //        string batch_no = txtbatchNo.Text;
        //        batch_no = batch_no.Replace('/', '-');
        //        string root = exePath + "\\Scanimage\\" + batch_no;
        //        //string root = DestinationFile;
        //        if (!Directory.Exists(root))
        //        {
        //            Directory.CreateDirectory(root);
        //        }
        //        else
        //        {
        //            string[] files = Directory.GetFiles(root);

        //            for (int k = 0; k < files.Length; k++)
        //            {
        //                File.Delete(files[k]);
        //            }
        //            Directory.Delete(root);
        //            Directory.CreateDirectory(root);
        //        }

        //        int i;
        //        string VSUserName;
        //        string VSUserMail;
        //        string VSRegCode;
        //        string msg = "";
        //        string lsScanFileName = "";
        //        bool flag = false;
        //        VSUserName = "Sundar Sharma";
        //        VSUserMail = "rama@vcidex.com";
        //        VSRegCode = "TcImTlXpAerMTuW+8Lk9vvPEj1KgZcHZQrP8DV5CnYDaa89eqxit5BgXgviV3LKFub33h5gsIEjq/eF4WuM2Hm7EESBIR8a3qr2mu" + "lByY1QmoKQcySAvCNQRSYK7CkA1hHCS4gz2317sNjvkBymOTJlFReydFSgJIxIzq5CSvrYk";
        //        objVSTwain.Register(VSUserName, VSUserMail, VSRegCode);
        //        objVSTwain.StartDevice();
        //        for (i = 0; (i <= (objVSTwain.sourcesCount - 1)); i++)
        //        {
        //            if ((objVSTwain.GetSourceProductName(i) == "Canon DR-7580 TWAIN 1.88 (32-32)"))
        //            {
        //                objVSTwain.sourceIndex = i;
        //                objVSTwain.SelectSource();
        //                break;
        //            }
        //        }
        //        objVSTwain.showUI = true;
        //        objVSTwain.disableAfterAcquire = true;
        //        objVSTwain.autoCleanBuffer = true;
        //        objVSTwain.OpenDataSource();
        //        // objVSTwain.unitOfMeasure = UnitOfMeasure.Inches
        //        objVSTwain.tiffMultiPage = true;
        //        objVSTwain.fileFormat = FileFormat.Tiff;
        //        objVSTwain.tiffCompression = VintaSoft.Twain.TiffCompression.CCITGroup4;
        //        objVSTwain.duplexEnabled = true;
        //        switch (msPaperSize)
        //        {
        //            case "A3":
        //                objVSTwain.pageSize = PageSize.A3;
        //                break;
        //            case "A4":
        //                objVSTwain.pageSize = PageSize.A4;
        //                break;
        //            case "A5":
        //                objVSTwain.pageSize = PageSize.A5;
        //                break;
        //            case "LETTER":
        //                objVSTwain.pageSize = PageSize.USLETTER;
        //                break;
        //            default:
        //                objVSTwain.pageSize = PageSize.USLEGAL;
        //                break;
        //        }
        //        if (objVSTwain.feederPresent)
        //        {
        //            objVSTwain.feederEnabled = true;
        //            objVSTwain.autoFeed = true;
        //            objVSTwain.xferCount = 32767;
        //            int count = 0;
        //            if (objVSTwain.feederLoaded)
        //            {
        //                while (objVSTwain.AcquireModal())
        //                {
        //                    try
        //                    {
        //                        count++;
        //                        if (count % 2 == 0)
        //                        {
        //                            //lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
        //                            lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
        //                            if (!objVSTwain.SaveImage(0, lsScanFileName))
        //                            {
        //                                return;
        //                            }
        //                            objVStiff = new VSTiff(lsScanFileName);
        //                        }
        //                        else
        //                        {

        //                            //lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
        //                            lsScanFileName = (root + "\\Scanimage" + count + "-" + DateTime.Now.Month + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Millisecond + ".jpg");
        //                            if (!objVSTwain.SaveImage(0, lsScanFileName))
        //                            {
        //                                return;
        //                            }
        //                            objVStiff = new VSTiff(lsScanFileName);
        //                        }
        //                        // gnNumber = objVStiff.numImages;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MessageBox.Show("" + ex.Message);
        //                    }

        //                }

        //            }

        //        }

        //        objVSTwain.CloseDataSource();
        //        objVSTwain.StopDevice();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        private void LoadBatching()
        {
            try
            {
                //lblStatus.Visible = false;
                ScannerBusiness scanbuss = new ScannerBusiness();
                DataTable dtbatch = scanbuss.GetBatchingDetails();
                //grdvwBactchlist.Rows.Clear();
                grdvwBactchlist.Columns.Clear();
                grdvwBactchlist.DataSource = null;

                //grdvwBactchlist.Rows.Clear();
                if (dtbatch.Rows.Count > 0)
                {
                    grdvwBactchlist.DataSource = dtbatch;
                    grdvwBactchlist.Columns["Inward Id"].Visible = false;
                    grdvwBactchlist.Columns["Batch Id"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No Bathcing for Scanners..");
                }

                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Scan";
                col.Name = "Scan";
                //col.indexer = 0;
                grdvwBactchlist.Columns.Add(col);
                //  grdvwBactchlist.Columns.Count
                grdvwBactchlist.Columns["cheque Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdvwBactchlist.Columns["Batch Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //lblStatus.Visible = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        //public void ScanningProcess()
        //{
        //    try
        //    {
        //        //Scanning();
        //        string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        //        string batch_no = txtbatchNo.Text;
        //        batch_no = batch_no.Replace('/', '-');
        //        string root = exePath + "\\Scanimage\\" + batch_no;

        //        files = System.IO.Directory.GetFiles(root);
        //        string[] filePaths = Directory.GetFiles(root);
        //        var sort = from fn in filePaths orderby new FileInfo(fn).CreationTime ascending select fn;

        //        int m = 0;
        //        foreach (string n in sort)
        //        {
        //            filePaths[m] = n;
        //            m++;
        //        }

        //        picScannedImageFront.Image = new Bitmap(filePaths[i]);
        //        var img = new Bitmap(filePaths[i]);
        //        string[] s = { "\\bin" };
        //        string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\tessdata";
        //        var ocr = new TesseractEngine(path, "mcr+oab", EngineMode.TesseractOnly);
        //        var page = ocr.Process(img);
        //        string ocrtxt = page.GetText();
        //        //string Che_Mic_Bas_Tra = GetCheMicBasTra(page.GetText().Trim());
        //        string[] result = GetCheMicBasTra(page.GetText().Trim());
        //        string cheq_no = result[0];
        //        string sort_code = result[1];
        //        string base_code = result[2];
        //        string tran_code = result[3];
        //        ScannerEntities scan = new ScannerEntities();
        //        j++;
        //        txtScancount.Text = j.ToString();
        //        txtDifference.Text = (Convert.ToInt32(txtCheckCount.Text) - j).ToString();
        //        grdScanning.Rows.Add(j, cheq_no, sort_code, base_code, tran_code);
        //        if (grdScanning.Rows[(j - 1)].Cells["check_no"].Value.ToString() == "")
        //        {
        //            grdScanning[1, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //        if (grdScanning.Rows[(j - 1)].Cells["sort_codes"].Value.ToString() == "")
        //        {
        //            grdScanning[2, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //        if (grdScanning.Rows[(j - 1)].Cells["base_codes"].Value.ToString() == "")
        //        {
        //            grdScanning[3, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //        if (grdScanning.Rows[(j - 1)].Cells["tran_Codes"].Value.ToString() == "")
        //        {
        //            grdScanning[4, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //        i++;
        //        pictureScannedImageBack.Image = new Bitmap(filePaths[i]);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void HighlightOCR(string filepath)
        //{
        //    try
        //    {
        //        var img = new Bitmap(filepath);
        //        string[] s = { "\\bin" };
        //        string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\tessdata";
        //        var ocr = new TesseractEngine(path, "mcr+oab", EngineMode.TesseractOnly);
        //        var page = ocr.Process(img);
        //        string ocrtxt = page.GetText();
        //        //string Che_Mic_Bas_Tra = GetCheMicBasTra(page.GetText().Trim());
        //        string[] result = GetCheMicBasTra(page.GetText().Trim());
        //        i++;
        //        pictureScannedImageBack.Image = new Bitmap(filepath);
        //        string cheq_no = result[0];
        //        string sort_code = result[1];
        //        string base_code = result[2];
        //        string tran_code = result[3];
        //        //File.Delete(filePaths[0]);
        //        ScannerEntities scan = new ScannerEntities();
        //        j++;
        //        txtScancount.Text = j.ToString();
        //        txtDifference.Text = (Convert.ToInt32(txtCheckCount.Text) - j).ToString();
        //        //grdScanning.Rows.Add();
        //        grdScanning.Rows.Add(j, cheq_no, sort_code, base_code, tran_code);
        //        if (grdScanning.Rows[(j - 1)].Cells["check_no"].Value.ToString() == "")
        //        {
        //            grdScanning[1, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //        if (grdScanning.Rows[(j - 1)].Cells["sort_codes"].Value.ToString() == "")
        //        {
        //            grdScanning[2, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //        if (grdScanning.Rows[(j - 1)].Cells["base_codes"].Value.ToString() == "")
        //        {
        //            grdScanning[3, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //        if (grdScanning.Rows[(j - 1)].Cells["tran_Codes"].Value.ToString() == "")
        //        {
        //            grdScanning[4, (j - 1)].Style.BackColor = Color.Yellow;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private string[] GetCheMicBasTra(string inputStr)
        //{
        //    string[] result = new string[4];
        //    try
        //    {
        //        string tranCode = inputStr.Substring(inputStr.LastIndexOf(' ')).Trim();
        //        string tempStr = inputStr.Substring(inputStr.LastIndexOf('[')).Substring(1); //.Substring(0, baseCode.IndexOf("@"));
        //        string baseCode = tempStr.Substring(0, tempStr.IndexOf('@')).Trim();
        //        tempStr = inputStr.Substring(inputStr.LastIndexOf('-') + 4).Trim();
        //        string chequeNo = tempStr.Substring(0, tempStr.IndexOf('@'));
        //        string micrCode = tempStr.Substring(tempStr.IndexOf(' '), 10).Trim();

        //        result[0] = chequeNo;
        //        result[1] = micrCode;
        //        result[2] = baseCode;
        //        result[3] = tranCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        result[0] = "";
        //        result[1] = "";
        //        result[2] = "";
        //        result[3] = "";
        //    }
        //    //return chequeNo + "/" + micrCode + "/" + baseCode + "/" + tranCode;
        //    return result;
        //}
        //private void StartScan(int checkcount)
        //{
        //    ScannerEntities scan = new ScannerEntities();
        //    for (int i = 0; i < checkcount; i++)
        //    {
        //        txtScancount.Text = (i + 1).ToString();
        //        txtDifference.Text = (checkcount - (i + 1)).ToString();
        //        scan.serial_no = i + 1;
        //        scan.check_no = "Check01";
        //        scan.sort_code = "5656";
        //        scan.base_code = "000001";
        //        scan.tran_code = "101021";
        //        grdScanning.Rows.Add(scan.serial_no, scan.check_no, scan.sort_code, scan.base_code, scan.tran_code);
        //    }
        //}
        //private void Clear()
        //{
        //    grdScanning.Rows.Clear();
        //    txtbatchNo.Text = "";
        //    txtBatchAmount.Text = "";
        //    txtCheckCount.Text = "";
        //    txtCustomercode.Text = "";
        //    txtdepositSlipNo.Text = "";
        //    txtDifference.Text = "";
        //    txtScancount.Text = "";
        //}
        //private void TriedMethods()
        //{
        //    //[col.Index, row.Index].Style.BackColor = Color.Green;
        //    //grdScan.Rows.Add();

        //    //IEnumerable<string> filefront = Directory.EnumerateFiles(root, "Front*.*"); // lazy file system lookup
        //    //filefront = Directory.GetFiles(root).Where(f => f.Contains("Front"));
        //    //IEnumerable<string> fileback = Directory.EnumerateFiles(root, "Back*.*"); // lazy file system lookup
        //    //backImageList = Directory.GetFiles(root, "Back*.*"); // not lazy



        //    //string DestinationFile = System.Configuration.ConfigurationManager.AppSettings["DestinationFolder"].ToString();

        //    //if (!System.IO.Directory.Exists(DestinationFile))
        //    //{
        //    //    System.IO.Directory.CreateDirectory(DestinationFile);
        //    //}
        //    //System.IO.File.Copy(root, destFile, true);
        //    //int fCount = Directory.GetFiles(root, "*", SearchOption.TopDirectoryOnly).Length;
        //    //int check_count = Convert.ToInt32(txtCheckCount.Text);
        //    ////System.IO.File.Move(root, DestinationFile);
        //    //
        //    //string fileName = "";
        //    //// Copy the files and overwrite destination files if they already exist.
        //    //DestinationFile = System.IO.Path.Combine(DestinationFile, fileName);
        //    //foreach (string s in files)
        //    //{
        //    //    // Use static Path methods to extract only the file name from the path.
        //    //    fileName = System.IO.Path.GetFileName(s);
        //    //    System.IO.File.Copy(s, DestinationFile, true);

        //    //string root = exePath + "\\Scanimage";
        //}
        //public void New(string _PageSize, bool _DuplexFlag, int _PageCount)
        //{
        //    //  This call is required by the designer.
        //    InitializeComponent();
        //    //  Add any initialization after the InitializeComponent() call.
        //    msPaperSize = _PageSize;
        //    mbDuplexFlag = _DuplexFlag;
        //    mnPageCount = _PageCount;
        //}
        #endregion

        #region Events
        private void Scanner_Load(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Load Scanned List");
            //btnsave.Enabled = false;
            LoadBatching();
            TheamClass.SetTheam(this);
        }
        private void grdvwBactchlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdvwBactchlist.Columns[e.ColumnIndex].Name == "Scan")
                {
                    int rindex = e.RowIndex;
                    int cindex = e.ColumnIndex;

                    //int col_count = grdvwBactchlist.Columns.Count;
                    //string col1 = grdvwBactchlist.Columns[0].ToString();
                    //grdvwBactchlist.Rows[rindex].Cells.
                    string batch_number = grdvwBactchlist.Rows[rindex].Cells["Batch No"].Value.ToString();
                    string check_cont = grdvwBactchlist.Rows[rindex].Cells["Cheque Count"].Value.ToString();
                    string batch_Amt = grdvwBactchlist.Rows[rindex].Cells["Batch Amount"].Value.ToString();
                    string dep_slip_no = grdvwBactchlist.Rows[rindex].Cells["Batch Deposit Slip No"].Value.ToString();
                    string customer_code = grdvwBactchlist.Rows[rindex].Cells["Customer Code"].Value.ToString();

                    //if (ActiveMdiChild != null)
                    //{
                    //    if (ActiveMdiChild.Text.Equals("StartScanning"))
                    //        return;
                    //    ActiveMdiChild.Close();
                    //}

                    //StartScanning frmscan = new StartScanning(batch_number, check_cont, batch_Amt, dep_slip_no, customer_code);
                    //frmscan.MdiParent = Scanner.ActiveForm;
                    //frmscan.FormClosed += new FormClosedEventHandler(this.sc_FormClosed);
                    //foreach (Form f in Application.OpenForms)
                    //{
                    //    if (f is StartScanning)
                    //    {
                    //        f.Focus();
                    //        return;
                    //    }
                    //}
                    //frmscan.Show();

                    ScannerRangers frmscan = new ScannerRangers(batch_number, check_cont, batch_Amt, dep_slip_no, customer_code);
                    frmscan.MdiParent = Scanner.ActiveForm;
                    frmscan.Dock = DockStyle.Fill;
                    frmscan.FormClosed += new FormClosedEventHandler(this.sr_FormClosed);
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is ScannerRangers)
                        {
                            f.Focus();
                            return;
                        }
                    }
                    frmscan.Show();


                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadBatching();
        }

        public void sc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBatching();
        }
        public void sr_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadBatching();
        }

        private void grdvwBactchlist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = grdvwBactchlist.CurrentCell.ColumnIndex;
                    int iRow = grdvwBactchlist.CurrentCell.RowIndex;
                    if (iColumn == grdvwBactchlist.Columns.Count - 1)
                        grdvwBactchlist.CurrentCell = grdvwBactchlist[0, iRow + 1];
                    else
                        grdvwBactchlist.CurrentCell = grdvwBactchlist[iColumn + 1, iRow];
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        //private void btnImageScan_Click(object sender, EventArgs e)
        //{
        //    if (txtCheckCount.Text != "")
        //    {
        //        lblStatus.Visible = true;
        //        lblStatus.ForeColor = Color.Green;
        //        lblStatus.Text = "Scanner Running....";
        //        try
        //        {
        //            ScanningProcess();
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.WriteLog(ex.ToString());
        //        }
        //        lblStatus.ForeColor = Color.Green;
        //        lblStatus.Text = "Scanner Completed";
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Select Batch For Scaning...");
        //    }
        //}
        //private void btnsave_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();
        //    foreach (DataGridViewColumn col in grdScanning.Columns)
        //    {
        //        dt.Columns.Add(col.Name);
        //    }
        //    foreach (DataGridViewRow row in grdScanning.Rows)
        //    {
        //        DataRow dRow = dt.NewRow();
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            dRow[cell.ColumnIndex] = cell.Value;
        //        }
        //        dt.Rows.Add(dRow);
        //    }
        //    ScannerBusiness objscanner = new ScannerBusiness();
        //    System.Data.DataColumn newColumn = new System.Data.DataColumn("batch_no", typeof(System.String));
        //    newColumn.DefaultValue = txtbatchNo.Text;
        //    dt.Columns.Add(newColumn);

        //    System.Data.DataColumn frontimage = new System.Data.DataColumn("front_image", typeof(System.String));
        //    newColumn.DefaultValue = "";
        //    dt.Columns.Add(frontimage);

        //    System.Data.DataColumn back_image = new System.Data.DataColumn("back_image", typeof(System.String));
        //    newColumn.DefaultValue = "";
        //    dt.Columns.Add(back_image);

        //    System.Data.DataColumn front_uvimage = new System.Data.DataColumn("front_uv_image", typeof(System.String));
        //    newColumn.DefaultValue = "";
        //    dt.Columns.Add(front_uvimage);

        //    System.Data.DataColumn bac_uvimage = new System.Data.DataColumn("back_uv_image", typeof(System.String));
        //    newColumn.DefaultValue = "";
        //    dt.Columns.Add(bac_uvimage);

        //    string response = objscanner.SaveScanedItems(dt);
        //    if (response == "Success")
        //    {
        //        MessageBox.Show("Scanned Details Successfully Uploaded....");
        //        LoadBatching();
        //        Clear();
        //    }
        //}
        //private void Toggle_Click(object sender, EventArgs e)
        //{
        //    //if (picScannedImageFront.Visible == true)
        //    //{
        //    //    pictureScannedImageBack.Visible = true;
        //    //    picScannedImageFront.Visible = false;
        //    //}
        //    //else if (pictureScannedImageBack.Visible == true)
        //    //{
        //    //    pictureScannedImageBack.Visible = false;
        //    //    picScannedImageFront.Visible = true;
        //    //}
        //}
        //private void btnContnu_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Convert.ToInt32(txtDifference.Text) != 0)
        //        {
        //            string exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        //            string batch_no = txtbatchNo.Text;
        //            batch_no = batch_no.Replace('/', '-');
        //            string root = exePath + "\\Scanimage\\" + batch_no;
        //            i++;
        //            string[] filePath = Directory.GetFiles(root);
        //            var sort = from fn in filePath orderby new FileInfo(fn).CreationTime ascending select fn;
        //            int m = 0;
        //            foreach (string n in sort)
        //            {
        //                filePath[m] = n;
        //                m++;
        //            }


        //            picScannedImageFront.Image = new Bitmap(filePath[i]);
        //            var img = new Bitmap(filePath[i]);
        //            string[] s = { "\\bin" };
        //            string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\tessdata";
        //            var ocr = new TesseractEngine(path, "mcr+oab", EngineMode.TesseractOnly);
        //            var page = ocr.Process(img);
        //            string ocrtxt = page.GetText();
        //            string[] result = GetCheMicBasTra(page.GetText().Trim());
        //            string cheq_no = result[0];
        //            string sort_code = result[1];
        //            string base_code = result[2];
        //            string tran_code = result[3];
        //            ScannerEntities scan = new ScannerEntities();
        //            j++;
        //            grdScanning.Rows.Add(j, cheq_no, sort_code, base_code, tran_code);
        //            if (grdScanning.Rows[(j - 1)].Cells["check_no"].Value.ToString() == "")
        //            {
        //                grdScanning[1, (j - 1)].Style.BackColor = Color.Yellow;
        //            }
        //            if (grdScanning.Rows[(j - 1)].Cells["sort_codes"].Value.ToString() == "")
        //            {
        //                grdScanning[2, (j - 1)].Style.BackColor = Color.Yellow;
        //            }
        //            if (grdScanning.Rows[(j - 1)].Cells["base_codes"].Value.ToString() == "")
        //            {
        //                grdScanning[3, (j - 1)].Style.BackColor = Color.Yellow;
        //            }
        //            if (grdScanning.Rows[(j - 1)].Cells["tran_Codes"].Value.ToString() == "")
        //            {
        //                grdScanning[4, (j - 1)].Style.BackColor = Color.Yellow;
        //            }
        //            i++;
        //            pictureScannedImageBack.Image = new Bitmap(filePath[i]);
        //            txtScancount.Text = j.ToString();
        //            txtDifference.Text = (Convert.ToInt32(txtCheckCount.Text) - j).ToString();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Scanning Completed for Current Batch List");
        //            btnsave.Enabled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Check Mandate Missing From Scanners");
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void btncontinue_Click(object sender, EventArgs e)
        //{

        //}
        //private void Cancel_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Do you want Cancel thi Batch?", "Confirmation", MessageBoxButtons.YesNoCancel);
        //    if (result == DialogResult.Yes)
        //    {
        //        Clear();
        //    }
        //    else if (result == DialogResult.No)
        //    {
        //        //...
        //    }
        //}
        #endregion

    }
}
