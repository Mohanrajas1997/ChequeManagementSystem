using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class MakerValidation : Form
    {
        DataTable dtscanningdtl;
        DataTable modifiedRecod;
        #region Initialization
        private string batch_num = string.Empty;
        private string check_Count = string.Empty;
        private string batch_amt = string.Empty;
        private string dep_slip_no = string.Empty;
        private string cust_name = string.Empty;
        private string inward_type = string.Empty;
        DataTable dtMicrList = new DataTable();
        DataTable dtTranCodeList = new DataTable();
        int sortcount = 0;
        int basecount = 0;
        int trancount = 0;
        int chequecount = 0;
        #endregion


        #region Constructor
        public MakerValidation()
        {
            InitializeComponent();
        }
        public MakerValidation(string _batch_no, string _check_count, string _batch_amount, string _dep_slip_no, string _cust_code, string _inward_type)
        {
            batch_num = _batch_no;
            check_Count = _check_count;
            batch_amt = _batch_amount;
            dep_slip_no = _dep_slip_no;
            cust_name = _cust_code;
            inward_type = _inward_type;
            InitializeComponent();
        }
        #endregion

        private void ReduceImageSize(double scaleFactor, Stream sourcePath, string targetPath)
        {
            try
            {
                using (var image = System.Drawing.Image.FromStream(sourcePath))
                {
                    var newWidth = (int)(image.Width * scaleFactor);
                    var newHeight = (int)(image.Height * scaleFactor);
                    var thumbnailImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbnailImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imageRectangle);
                    thumbnailImg.Save(targetPath, image.RawFormat);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Methods
        private void LoadMakerBatchDetails()
        {
            try
            {
                gvscanlist.Rows.Add();
                gvscanlist.Rows[0].Cells[0].Value = batch_num;
                gvscanlist.Rows[0].Cells[1].Value = check_Count;
                gvscanlist.Rows[0].Cells[2].Value = batch_amt;

                gvscanlist.Rows[0].Cells[3].Value = dep_slip_no;
                gvscanlist.Rows[0].Cells[4].Value = cust_name;
                gvscanlist.Rows[0].Cells[5].Value = check_Count;
                gvscanlist.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gvscanlist.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gvscanlist.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void LoadMakerScannedDetails()
        //{
        //    try
        //    {
        //        //if (rbt_all.Checked == true)
        //        //{

        //            DataTable dtscanningdtl = new DataTable();
        //            ScannerBusiness objscanning = new ScannerBusiness();
        //            dtscanningdtl = objscanning.GetScanning(batch_num);
        //            //GrdMaker.DataSource = dtscanningdtl;

        //            DataTable Temp = new DataTable();
        //            DataTable allRecord = new DataTable();
        //           // Temp.Clear();

        //            //Temp.Columns.Add("sl no");
        //            //Temp.Columns.Add("Cheque No");
        //            //Temp.Columns.Add("Sort Code");
        //            //Temp.Columns.Add("Base Code");
        //            //Temp.Columns.Add("Tran Code");
        //            //Temp.Columns.Add("Front Image");
        //            //Temp.Columns.Add("Back Image");
        //            //Temp.Columns.Add("Status");
        //            //Temp.Columns.Add("Scan ID");
        //            Temp.Clear();
        //            Temp.Columns.Add("serial_no");
        //            Temp.Columns.Add("check_no");
        //            Temp.Columns.Add("sort_codes");
        //            Temp.Columns.Add("base_codes");
        //            Temp.Columns.Add("tran_codes");
        //            Temp.Columns.Add("front_image");
        //            Temp.Columns.Add("back_image");
        //            Temp.Columns.Add("status");
        //            Temp.Columns.Add("scan_id");


        //            for (int i = 0; i < dtscanningdtl.Rows.Count; i++)
        //            {
        //                byte[] byteArray = Encoding.ASCII.GetBytes(dtscanningdtl.Rows[i]["Front Image"].ToString());
        //                System.IO.Stream stream = new MemoryStream(byteArray);
        //                //ReduceImageSize(00.5, stream, "");
        //                string serial_no = dtscanningdtl.Rows[i]["sl no"].ToString();
        //                string cheq_no = dtscanningdtl.Rows[i]["Cheque No"].ToString();
        //                string sort_code = dtscanningdtl.Rows[i]["Sort Code"].ToString();
        //                string base_code = dtscanningdtl.Rows[i]["Base Code"].ToString();
        //                string tran_code = dtscanningdtl.Rows[i]["Tran Code"].ToString();
        //                string front_image = dtscanningdtl.Rows[i]["Front Image"].ToString();
        //                string back_image = dtscanningdtl.Rows[i]["Back Image"].ToString();
        //                string status = dtscanningdtl.Rows[i]["Status"].ToString();
        //                string scn_id = dtscanningdtl.Rows[i]["Scan ID"].ToString();

        //                GrdMaker.Rows.Add(serial_no, cheq_no, sort_code, base_code, tran_code, front_image, back_image, status, scn_id);
        //                var cellch = GrdMaker.Rows[i].Cells["check_no"].Value == "" ? "000000" : GrdMaker.Rows[i].Cells["check_no"].Value.ToString();
        //                string cellchq = cellch.ToString();
        //                Color chColor = ((cellchq.Length != 6) ? Color.Yellow : Color.White);
        //                GrdMaker[1, i].Style.BackColor = chColor;
        //                GrdMaker[1, i].Value = cellch;

        //                var cellso = GrdMaker.Rows[i].Cells["sort_codes"].Value == "" ? "000000000" : GrdMaker.Rows[i].Cells["sort_codes"].Value.ToString();
        //                string cellsortcode = cellso.ToString();
        //                bool contains = dtMicrList.AsEnumerable().Any(row => cellsortcode == row.Field<String>("MICR_CODE"));

        //                Color chColor1 = (cellsortcode.Length != 9 || !contains || (cellsortcode == "000000000")) ? Color.Yellow : Color.White;
        //                GrdMaker[2, i].Style.BackColor = chColor1;
        //                GrdMaker[2, i].Value = cellsortcode;

        //                var cellbs = GrdMaker.Rows[i].Cells["base_codes"].Value == "" ? "000000" : GrdMaker.Rows[i].Cells["base_codes"].Value.ToString();
        //                string cellbasecode = cellbs.ToString();
        //                Color chColor2 = ((cellbasecode.Length != 6) || (cellbasecode == "") ? Color.Yellow : Color.White);
        //                GrdMaker[3, i].Style.BackColor = chColor2;
        //                GrdMaker[3, i].Value = cellbasecode;

        //                var celltc = GrdMaker.Rows[i].Cells["tran_codes"].Value == "" ? "00" : GrdMaker.Rows[i].Cells["tran_codes"].Value.ToString();
        //                string celltrancode = celltc.ToString();
        //                Color chColor3 = celltrancode.Length != 2 ? Color.Yellow : Color.White;
        //                GrdMaker[4, i].Style.BackColor = chColor3;
        //                GrdMaker[4, i].Value = celltrancode;
        //                if (rbt_hghlgt.Checked == true)
        //                {
        //                    if (contains == false || chColor.Name == "Yellow" || chColor2.Name == "Yellow" || chColor3.Name == "Yellow")
        //                    {
        //                        var row = Temp.NewRow();

        //                        //row["sl no"] = GrdMaker.Rows[i].Cells[0].Value;
        //                        //row["Cheque No"] = GrdMaker.Rows[i].Cells[1].Value;
        //                        //row["Sort Code"] = GrdMaker.Rows[i].Cells[2].Value;
        //                        //row["Base Code"] = GrdMaker.Rows[i].Cells[3].Value;
        //                        //row["Tran Code"] = GrdMaker.Rows[i].Cells[4].Value;
        //                        //row["Front Image"] = GrdMaker.Rows[i].Cells[5].Value;
        //                        //row["Back Image"] = GrdMaker.Rows[i].Cells[6].Value;
        //                        //row["Status"] = GrdMaker.Rows[i].Cells[7].Value;
        //                        //row["Scan ID"] = GrdMaker.Rows[i].Cells[8].Value;
        //                        //Temp.Rows.Add(row);

        //                        row["serial_no"] = GrdMaker.Rows[i].Cells[0].Value;
        //                        row["check_no"] = GrdMaker.Rows[i].Cells[1].Value;
        //                        row["sort_codes"] = GrdMaker.Rows[i].Cells[2].Value;
        //                        row["base_codes"] = GrdMaker.Rows[i].Cells[3].Value;
        //                        row["tran_codes"] = GrdMaker.Rows[i].Cells[4].Value;
        //                        row["front_image"] = GrdMaker.Rows[i].Cells[5].Value;
        //                        row["back_image"] = GrdMaker.Rows[i].Cells[6].Value;
        //                        row["status"] = GrdMaker.Rows[i].Cells[7].Value;
        //                        row["scan_id"] = GrdMaker.Rows[i].Cells[8].Value;
        //                        Temp.Rows.Add(row);

        //                    }
        //                }
        //            }
        //            GrdMaker.Columns["front_image"].Visible = false;
        //            GrdMaker.Columns["back_image"].Visible = false;
        //            //ValidateScannerData();
        //            if (Temp.Rows.Count > 0)
        //            {
        //                GrdMaker.Columns.Clear();
        //                GrdMaker.Rows.Clear();
        //                GrdMaker.DataSource = Temp;
        //                HiglightRows();
        //                //GrdMaker.Columns["Sort Code"].DefaultCellStyle.BackColor = Color.Yellow;

        //            }
        //            else
        //            {

        //            }
        //        }

        //   // }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}

        private void LoadDatafromDB()
        {
            modifiedRecod = new DataTable();
            modifiedRecod.Rows.Clear();
            modifiedRecod.Columns.Add("serial_no");
            modifiedRecod.Columns.Add("check_no");
            modifiedRecod.Columns.Add("sort_codes");
            modifiedRecod.Columns.Add("base_codes");
            modifiedRecod.Columns.Add("tran_codes");
            //modifiedRecod.Columns.Add("front_image");
            //modifiedRecod.Columns.Add("back_image");
            //modifiedRecod.Columns.Add("status");
            //modifiedRecod.Columns.Add("scan_id");

            dtscanningdtl = new DataTable();
            ScannerBusiness objscanning = new ScannerBusiness();
            dtscanningdtl = objscanning.GetScanning(batch_num);
        }

        private void LoadMakerScannedDetails()
        {
            try
            {
                //if (rbt_all.Checked == true)
                //{
                //dtscanningdtl = new DataTable();
                //ScannerBusiness objscanning = new ScannerBusiness();
                //dtscanningdtl = objscanning.GetScanning(batch_num);

                //GrdMaker.DataSource = dtscanningdtl;

                DataTable Temp = new DataTable();
                //        DataTable allRecord = new DataTable();
                // Temp.Clear();

                //Temp.Columns.Add("sl no");
                //Temp.Columns.Add("`");
                //Temp.Columns.Add("Sort Code");
                //Temp.Columns.Add("Base Code");
                //Temp.Columns.Add("Tran Code");
                //Temp.Columns.Add("Front Image");
                //Temp.Columns.Add("Back Image");
                //Temp.Columns.Add("Status");
                //Temp.Columns.Add("Scan ID");
                Temp.Clear();
                Temp.Rows.Clear();
                Temp.Columns.Add("serial_no");
                Temp.Columns.Add("check_no");
                Temp.Columns.Add("sort_codes");
                Temp.Columns.Add("base_codes");
                Temp.Columns.Add("tran_codes");
                Temp.Columns.Add("front_image");
                Temp.Columns.Add("back_image");
                Temp.Columns.Add("status");
                Temp.Columns.Add("scan_id");




                //  DataTable allRecords = Temp;
                DataTable hilighedRecords = new DataTable();
                hilighedRecords.Rows.Clear();
                hilighedRecords.Columns.Add("serial_no");
                hilighedRecords.Columns.Add("check_no");
                hilighedRecords.Columns.Add("sort_codes");
                hilighedRecords.Columns.Add("base_codes");
                hilighedRecords.Columns.Add("tran_codes");
                hilighedRecords.Columns.Add("front_image");
                hilighedRecords.Columns.Add("back_image");
                hilighedRecords.Columns.Add("status");
                hilighedRecords.Columns.Add("scan_id");



                string a = "";
                for (int i = 0; i < dtscanningdtl.Rows.Count; i++)
                {

                    //string serial_no = dtscanningdtl.Rows[i]["sl no"].ToString();
                    //string cheq_no = dtscanningdtl.Rows[i]["Cheque No"].ToString();
                    //string sort_code = dtscanningdtl.Rows[i]["Sort Code"].ToString();
                    //string base_code = dtscanningdtl.Rows[i]["Base Code"].ToString();
                    //string tran_code = dtscanningdtl.Rows[i]["Tran Code"].ToString();
                    //string front_image = dtscanningdtl.Rows[i]["Front Image"].ToString();
                    //string back_image = dtscanningdtl.Rows[i]["Back Image"].ToString();
                    //string status = dtscanningdtl.Rows[i]["Status"].ToString();
                    //string scn_id = dtscanningdtl.Rows[i]["Scan ID"].ToString();

                    //  string serial_no = modifiedRecod.Rows[i]["serial_no"].ToString();
                    //string m_serial_no = string.Empty;
                    string m_sordCode = string.Empty;
                    string serino = string.Empty;
                    string cheqNo = string.Empty;
                    bool isCheHig = false;
                    string sortCode = string.Empty;
                    bool contains = false;
                    bool isSCHig = false;
                    string baseCode = string.Empty;
                    bool isBCHig = false;
                    string tc = string.Empty;
                    bool contain = false;
                    bool isTCHig = false;

                    var tpRow = Temp.NewRow();

                    //DataRow tpRow = new DataRow();
                     serino = dtscanningdtl.Rows[i]["sl no"].ToString();
                     cheqNo = dtscanningdtl.Rows[i]["Cheque No"].ToString() == "" ? "000000" : dtscanningdtl.Rows[i]["Cheque No"].ToString();
                     isCheHig = ((cheqNo.Length != 6) ? true : false);
                     sortCode = dtscanningdtl.Rows[i]["Sort Code"].ToString() == "" ? "000000000" : dtscanningdtl.Rows[i]["Sort Code"].ToString();
                     contains = dtMicrList.AsEnumerable().Any(row => sortCode == row.Field<string>("MICR_CODE"));
                     isSCHig = (sortCode.Length != 9 || !contains || (sortCode == "000000000")) ? true : false;
                    baseCode = dtscanningdtl.Rows[i]["Base Code"].ToString() == "" ? "000000" : dtscanningdtl.Rows[i]["Base Code"].ToString(); //dtscanningdtl.Rows[i]["Base Code"].ToString();
                    isBCHig = ((baseCode.Length != 6) || (baseCode == "") ? true : false);
                    tc = dtscanningdtl.Rows[i]["Tran Code"].ToString() == "" ? "00" : dtscanningdtl.Rows[i]["Tran Code"].ToString();
                     contain = dtTranCodeList.AsEnumerable().Any(row => tc == row.Field<string>("tran_code").ToString());
                     isTCHig = (tc.Length != 2 || !contain) ? true : false;
                    //bool isTCHig = tc.Length != 2 ? true : false;


                    //string sLNofrmDB = dtscanningdtl.Rows[i]["sl no"].ToString(); ;
                    //serial_no = modifiedRecod.Rows[0]["serial_no"].ToString();

                    if (modifiedRecod.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        dt.Columns.Add("serial_no");
                        dt.Columns.Add("check_no");
                        dt.Columns.Add("sort_codes");
                        dt.Columns.Add("base_codes");
                        dt.Columns.Add("tran_codes");

                        //var results = from myRow in modifiedRecod.Rows.Cast<DataRow>()
                        //                 where myRow.Field<int>("serial_no") == Convert.ToInt16(serino)
                        //                 select myRow;

                        //var results = from myRow in modifiedRecod.AsEnumerable()
                        //              where myRow.Field<string>("serial_no") == serino
                        //              select myRow;


                        var query = from p in modifiedRecod.AsEnumerable()
                                    where p.Field<string>("serial_no") == serino
                                    select new
                                    {
                                        sort_codes = p.Field<string>("sort_codes")
                                        //age = p.Field<int>("age")
                                    };

                        if (query.Count() != 0)
                        {
                            a = query.FirstOrDefault().sort_codes.ToString();
                        }

                        if (query != null)
                            dt.Rows.Add(query);

                        if (dt.Rows.Count > 0)
                        {
                            m_sordCode = dt.Rows[0]["sort_codes"].ToString();
                        }
                        //query = null;
                        //select myRow.Field<string>("sort_codes");

                        //if( results != null)
                        //{
                        //    m_sordCode = row["sort_codes"].ToString();
                        //}
                        //foreach (DataRow row in results)
                        //{
                        //    m_sordCode = row["sort_codes"].ToString();
                        //   // var contact = row["CONTACT"].ToString();
                        //}


                        //  sordCodeTemp = modifiedRecod.Rows[0]["sort_codes"].ToString();
                    }

                    //if(modifiedRecod.Rows.Count <=0)
                    //{
                    tpRow["serial_no"] = serino;  // GrdMaker.Rows[i].Cells[0].Value; 
                    //tpRow["serial_no"] = serial_no.Equals(string.Empty) ? serino : serial_no; // GrdMaker.Rows[i].Cells[0].Value;

                    tpRow["check_no"] = cheqNo;
                    tpRow["sort_codes"] = sortCode;
                    tpRow["base_codes"] = baseCode;
                    tpRow["tran_codes"] = tc;
                    tpRow["front_image"] = dtscanningdtl.Rows[i]["Front Image"].ToString();
                    tpRow["back_image"] = dtscanningdtl.Rows[i]["Back Image"].ToString();
                    tpRow["status"] = dtscanningdtl.Rows[i]["Status"].ToString();
                    tpRow["scan_id"] = dtscanningdtl.Rows[i]["Scan ID"].ToString();
                    //}

                    //tpRow["serial_no"] = serino;  // GrdMaker.Rows[i].Cells[0].Value; 
                    ////tpRow["serial_no"] = serial_no.Equals(string.Empty) ? serino : serial_no; // GrdMaker.Rows[i].Cells[0].Value;

                    //tpRow["check_no"] = cheqNo;
                    //tpRow["sort_codes"] = a.Equals(string.Empty) ? sortCode : a;
                    //tpRow["base_codes"] = baseCode;
                    //tpRow["tran_codes"] = tc;
                    //tpRow["front_image"] = dtscanningdtl.Rows[i]["Front Image"].ToString();
                    //tpRow["back_image"] = dtscanningdtl.Rows[i]["Back Image"].ToString();
                    //tpRow["status"] = dtscanningdtl.Rows[i]["Status"].ToString();
                    //tpRow["scan_id"] = dtscanningdtl.Rows[i]["Scan ID"].ToString();
                    //hlRow = tpRow;
                    if (isCheHig || isSCHig || isBCHig || isTCHig)
                    {
                        var hlRow = hilighedRecords.NewRow();
                        hlRow["serial_no"] = dtscanningdtl.Rows[i]["sl no"].ToString(); // GrdMaker.Rows[i].Cells[0].Value;                    
                        hlRow["check_no"] = cheqNo;
                        hlRow["sort_codes"] = sortCode;
                        hlRow["base_codes"] = baseCode;
                        hlRow["tran_codes"] = tc;
                        hlRow["front_image"] = dtscanningdtl.Rows[i]["Front Image"].ToString();
                        hlRow["back_image"] = dtscanningdtl.Rows[i]["Back Image"].ToString();
                        hlRow["status"] = dtscanningdtl.Rows[i]["Status"].ToString();
                        hlRow["scan_id"] = dtscanningdtl.Rows[i]["Scan ID"].ToString();
                        hilighedRecords.Rows.Add(hlRow);
                    }
                    a = "";
                    Temp.Rows.Add(tpRow);

                    //foreach (DataRow dtNewRow in Temp.Rows)
                    //{
                    //    foreach (DataRow dtNewRowModi in modifiedRecod.Rows)
                    //    {
                    //        if (dtNewRowModi["serial_no"].ToString() == dtNewRow["serial_no"].ToString())
                    //        {
                    //            //tpRow["serial_no"] = serino;  // GrdMaker.Rows[i].Cells[0].Value; 
                    //            ////tpRow["serial_no"] = serial_no.Equals(string.Empty) ? serino : serial_no; // GrdMaker.Rows[i].Cells[0].Value;

                    //            //tpRow["check_no"] = cheqNo;
                    //            tpRow["sort_codes"] = dtNewRowModi["sort_codes"].ToString();
                    //            //tpRow["base_codes"] = baseCode;
                    //            //tpRow["tran_codes"] = tc;
                    //            //tpRow["front_image"] = dtscanningdtl.Rows[i]["Front Image"].ToString();
                    //            //tpRow["back_image"] = dtscanningdtl.Rows[i]["Back Image"].ToString();
                    //            //tpRow["status"] = dtscanningdtl.Rows[i]["Status"].ToString();
                    //            //tpRow["scan_id"] = dtscanningdtl.Rows[i]["Scan ID"].ToString();
                    //        }

                    //    }
                    //}



                    // byte[] byteArray = Encoding.ASCII.GetBytes(dtscanningdtl.Rows[i]["Front Image"].ToString());
                    //System.IO.Stream stream = new MemoryStream(byteArray);
                    //ReduceImageSize(00.5, stream, "");
                    //string serial_no = dtscanningdtl.Rows[i]["sl no"].ToString();
                    //string cheq_no = dtscanningdtl.Rows[i]["Cheque No"].ToString();
                    //string sort_code = dtscanningdtl.Rows[i]["Sort Code"].ToString();
                    //string base_code = dtscanningdtl.Rows[i]["Base Code"].ToString();
                    //string tran_code = dtscanningdtl.Rows[i]["Tran Code"].ToString();
                    //string front_image = dtscanningdtl.Rows[i]["Front Image"].ToString();
                    //string back_image = dtscanningdtl.Rows[i]["Back Image"].ToString();
                    //string status = dtscanningdtl.Rows[i]["Status"].ToString();
                    //string scn_id = dtscanningdtl.Rows[i]["Scan ID"].ToString();

                    //GrdMaker.Rows.Add(serial_no, cheq_no, sort_code, base_code, tran_code, front_image, back_image, status, scn_id);
                    //var cellch = GrdMaker.Rows[i].Cells["check_no"].Value == "" ? "000000" : GrdMaker.Rows[i].Cells["check_no"].Value.ToString();
                    //string cellchq = cellch.ToString();
                    //Color chColor = ((cellchq.Length != 6) ? Color.Yellow : Color.White);
                    //GrdMaker[1, i].Style.BackColor = chColor;
                    //GrdMaker[1, i].Value = cellch;

                    //var cellso = GrdMaker.Rows[i].Cells["sort_codes"].Value == "" ? "000000000" : GrdMaker.Rows[i].Cells["sort_codes"].Value.ToString();
                    //string cellsortcode = cellso.ToString();
                    //bool contains = dtMicrList.AsEnumerable().Any(row => cellsortcode == row.Field<String>("MICR_CODE"));

                    //Color chColor1 = (cellsortcode.Length != 9 || !contains || (cellsortcode == "000000000")) ? Color.Yellow : Color.White;
                    //GrdMaker[2, i].Style.BackColor = chColor1;
                    //GrdMaker[2, i].Value = cellsortcode;

                    //var cellbs = GrdMaker.Rows[i].Cells["base_codes"].Value == "" ? "000000" : GrdMaker.Rows[i].Cells["base_codes"].Value.ToString();
                    //string cellbasecode = cellbs.ToString();
                    //Color chColor2 = ((cellbasecode.Length != 6) || (cellbasecode == "") ? Color.Yellow : Color.White);
                    //GrdMaker[3, i].Style.BackColor = chColor2;
                    //GrdMaker[3, i].Value = cellbasecode;

                    //var celltc = GrdMaker.Rows[i].Cells["tran_codes"].Value == "" ? "00" : GrdMaker.Rows[i].Cells["tran_codes"].Value.ToString();
                    //string celltrancode = celltc.ToString();
                    //Color chColor3 = celltrancode.Length != 2 ? Color.Yellow : Color.White;
                    //GrdMaker[4, i].Style.BackColor = chColor3;
                    //GrdMaker[4, i].Value = celltrancode;
                    //if (rbt_hghlgt.Checked == true)
                    //{
                    //    if (contains == false || chColor.Name == "Yellow" || chColor2.Name == "Yellow" || chColor3.Name == "Yellow")
                    //    {
                    //        var row = Temp.NewRow();

                    //        //row["sl no"] = GrdMaker.Rows[i].Cells[0].Value;
                    //        //row["Cheque No"] = GrdMaker.Rows[i].Cells[1].Value;
                    //        //row["Sort Code"] = GrdMaker.Rows[i].Cells[2].Value;
                    //        //row["Base Code"] = GrdMaker.Rows[i].Cells[3].Value;
                    //        //row["Tran Code"] = GrdMaker.Rows[i].Cells[4].Value;
                    //        //row["Front Image"] = GrdMaker.Rows[i].Cells[5].Value;
                    //        //row["Back Image"] = GrdMaker.Rows[i].Cells[6].Value;
                    //        //row["Status"] = GrdMaker.Rows[i].Cells[7].Value;
                    //        //row["Scan ID"] = GrdMaker.Rows[i].Cells[8].Value;
                    //        //Temp.Rows.Add(row);

                    //        row["serial_no"] = GrdMaker.Rows[i].Cells[0].Value;
                    //        row["check_no"] = GrdMaker.Rows[i].Cells[1].Value;
                    //        row["sort_codes"] = GrdMaker.Rows[i].Cells[2].Value;
                    //        row["base_codes"] = GrdMaker.Rows[i].Cells[3].Value;
                    //        row["tran_codes"] = GrdMaker.Rows[i].Cells[4].Value;
                    //        row["front_image"] = GrdMaker.Rows[i].Cells[5].Value;
                    //        row["back_image"] = GrdMaker.Rows[i].Cells[6].Value;
                    //        row["status"] = GrdMaker.Rows[i].Cells[7].Value;
                    //        row["scan_id"] = GrdMaker.Rows[i].Cells[8].Value;
                    //        Temp.Rows.Add(row);

                    //    }
                    //}
                }
                foreach (DataRow dtNewRow in Temp.Rows)
                {
                    foreach (DataRow dtNewRowModi in modifiedRecod.Rows)
                    {
                        if (dtNewRowModi["serial_no"].ToString() == dtNewRow["serial_no"].ToString())
                        {
                            //tpRow["serial_no"] = serino;  // GrdMaker.Rows[i].Cells[0].Value; 
                            ////tpRow["serial_no"] = serial_no.Equals(string.Empty) ? serino : serial_no; // GrdMaker.Rows[i].Cells[0].Value;

                            dtNewRow["check_no"] = dtNewRowModi["check_no"].ToString();//cheqNo;
                            dtNewRow["sort_codes"] = dtNewRowModi["sort_codes"].ToString();
                            dtNewRow["base_codes"] = dtNewRowModi["base_codes"].ToString();//baseCode;
                            dtNewRow["tran_codes"] = dtNewRowModi["tran_codes"].ToString();//tc;
                            //tpRow["front_image"] = dtscanningdtl.Rows[i]["Front Image"].ToString();
                            //tpRow["back_image"] = dtscanningdtl.Rows[i]["Back Image"].ToString();
                            //tpRow["status"] = dtscanningdtl.Rows[i]["Status"].ToString();
                            //tpRow["scan_id"] = dtscanningdtl.Rows[i]["Scan ID"].ToString();
                        }

                    }
                }
                //modifiedRecod.Rows.Clear();
                //  allRecords = Temp;
                //
                //  GrdMaker.Columns["front_image"].Visible = false;
                //  GrdMaker.Columns["back_image"].Visible = false;
                //   GrdMaker.Columns.Clear();
                //  GrdMaker.Rows.Clear();

                //ValidateScannerData();
                if (rbt_hghlgt.Checked)
                {
                    GrdMaker.Columns.Clear();
                    //  GrdMaker.Rows.Clear();
                    int i = 0;
                    int[] j = new int[hilighedRecords.Rows.Count];
                    DataTable hilighttem = hilighedRecords.Clone();
                    // hilighttem = hilighedRecords;
                    bool isMofified = false;

                    foreach (DataRow dtNewRow in hilighedRecords.Rows)
                    {
                        isMofified = false;
                        foreach (DataRow dtNewRowModi in modifiedRecod.Rows)
                        {

                            if (dtNewRowModi["serial_no"].ToString() == dtNewRow["serial_no"].ToString())
                            {

                                isMofified = true;
                            }
                            else
                            {
                                //var hlTem = hilighttem.NewRow();

                                ////  //tpRow["serial_no"] = serino;  // GrdMaker.Rows[i].Cells[0].Value; 
                                ////  ////tpRow["serial_no"] = serial_no.Equals(string.Empty) ? serino : serial_no; // GrdMaker.Rows[i].Cells[0].Value;
                                //hlTem["check_no"] = dtNewRowModi["check_no"].ToString();//cheqNo;
                                //hlTem["sort_codes"] = dtNewRowModi["sort_codes"].ToString();
                                //hlTem["base_codes"] = dtNewRowModi["base_codes"].ToString();//baseCode;
                                //hlTem["tran_codes"] = dtNewRowModi["tran_codes"].ToString();//tc;
                                //hlTem["serial_no"] = dtNewRow["serial_no"].ToString();
                                ////hlTem["front_image"] = dtNewRow["front_image"].ToString();
                                ////hlTem["back_image"] = dtNewRow["Back Image"].ToString();
                                ////hlTem["Status"] = dtNewRow["Status"].ToString();
                                ////hlTem[" scan_id"] = dtNewRow["scan_id"].ToString();
                                ////  //tpRow["front_image"] = dtscanningdtl.Rows[i]["Front Image"].ToString();
                                ////  //tpRow["back_image"] = dtscanningdtl.Rows[i]["Back Image"].ToString();
                                ////  //tpRow["status"] = dtscanningdtl.Rows[i]["Status"].ToString();
                                ////  //tpRow["scan_id"] = dtscanningdtl.Rows[i]["Scan ID"].ToString();  
                                //hilighttem.Rows.Add(hlTem);
                            }
                            // i++;
                        }

                        if (!isMofified)
                        {
                            var hlTem = hilighttem.NewRow();

                            hlTem["check_no"] = dtNewRow["check_no"].ToString();//cheqNo;
                            hlTem["sort_codes"] = dtNewRow["sort_codes"].ToString();
                            hlTem["base_codes"] = dtNewRow["base_codes"].ToString();//baseCode;
                            hlTem["tran_codes"] = dtNewRow["tran_codes"].ToString();//tc;
                            hlTem["serial_no"] = dtNewRow["serial_no"].ToString();
                            hlTem["front_image"] = dtNewRow["front_image"].ToString();
                            hlTem["back_image"] = dtNewRow["back_image"].ToString();
                            hlTem["Status"] = dtNewRow["Status"].ToString();
                            hlTem["scan_id"] = dtNewRow["scan_id"].ToString();
                            hilighttem.Rows.Add(hlTem);
                        }


                    }
                    //if (modifiedRecod.Rows.Count == 0)
                    //{
                    //    hilighttem = hilighedRecords;
                    //}
                    //else
                    //{
                    //    hilighedRecords.Rows.Clear();
                    //}
                    //for (int k = 0; k < j.Length;k++ )
                    //{
                    //    if(j[k]>0)
                    //    {
                    //       hilighedRecords.Rows[j[k]-1].Delete();
                    //        //hilighedRecords.Rows.
                    //    }
                    //}                

                    //if (hilighttem.Rows.Count > 0)
                    //{
                    hilighedRecords = hilighttem;
                    //}
                    //else if (hilighedRecords.Rows.Count == modifiedRecod.Rows.Count)
                    //{

                    //}

                    //GrdMaker.Columns["sort_codes"].MaxInputLength = 6;
                    GrdMaker.DataSource = hilighedRecords;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["sort_codes"]).MaxInputLength = 9;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["base_codes"]).MaxInputLength = 6;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["check_no"]).MaxInputLength = 6;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["tran_codes"]).MaxInputLength = 2;

                    GrdMaker.Columns["front_image"].Visible = false;
                    GrdMaker.Columns["back_image"].Visible = false;
                    GrdMaker.Columns["status"].Visible = false;
                    GrdMaker.Columns["scan_id"].Visible = false;
                    //modifiedRecod.Rows.Clear();
                    HiglightRows(false);
                    //GrdMaker.Columns["Sort Code"].DefaultCellStyle.BackColor = Color.Yellow;
                    DataTable NewHiglight = new DataTable();

                }
                else
                {
                    GrdMaker.Columns.Clear();
                    //foreach (DataRow dtNewRow in Temp.Rows)
                    //{
                    //    foreach (DataRow dtNewRowModi in modifiedRecod.Rows)
                    //    {
                    //        if (dtNewRowModi["serial_no"].ToString() == dtNewRow["serial_no"].ToString())
                    //        {
                    //            Temp.Rows.Remove(dtNewRow);
                    //            var data = Temp.NewRow();

                    //            data["check_no"] = dtNewRowModi["check_no"].ToString();//cheqNo;
                    //            data["sort_codes"] = dtNewRowModi["sort_codes"].ToString();
                    //            data["base_codes"] = dtNewRowModi["base_codes"].ToString();//baseCode;
                    //            data["tran_codes"] = dtNewRowModi["tran_codes"].ToString();//tc;
                    //            Temp.Rows.Add(data);
                    //        }
                    //    }

                    //}

                    for (int i = 0; i < Temp.Rows.Count; i++)
                    {
                        for (int j = 0; j < modifiedRecod.Rows.Count; j++)
                        {
                            if (Temp.Rows[i]["serial_no"].ToString() == modifiedRecod.Rows[j]["serial_no"].ToString())
                            {
                                var data = Temp.NewRow();
                                //Temp.Rows[i].Delete();
                                Temp.Rows[i]["check_no"] = modifiedRecod.Rows[j]["check_no"].ToString();//cheqNo;
                                Temp.Rows[i]["sort_codes"] = modifiedRecod.Rows[j]["sort_codes"].ToString();
                                Temp.Rows[i]["base_codes"] = modifiedRecod.Rows[j]["base_codes"].ToString();//baseCode;
                                Temp.Rows[i]["tran_codes"] = modifiedRecod.Rows[j]["tran_codes"].ToString();//tc;
                                //Temp.Rows.Add(data);
                            }

                        }
                    }

                    // GrdMaker.Rows.Clear();
                    GrdMaker.DataSource = Temp;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["sort_codes"]).MaxInputLength = 9;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["base_codes"]).MaxInputLength = 6;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["check_no"]).MaxInputLength = 6;
                    ((DataGridViewTextBoxColumn)GrdMaker.Columns["tran_codes"]).MaxInputLength = 2;

                    GrdMaker.Columns["front_image"].Visible = false;
                    GrdMaker.Columns["back_image"].Visible = false;
                    GrdMaker.Columns["status"].Visible = false;
                    GrdMaker.Columns["scan_id"].Visible = false;

                    HiglightRows(false);
                    GrdMaker.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GrdMaker.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GrdMaker.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GrdMaker.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GrdMaker.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HiglightRows(bool frmEdit)
        {
            // MessageBox.Show(GrdMaker.Rows.Count.ToString());

            for (int i = 0; i < GrdMaker.Rows.Count; i++)
            {
                string cn = GrdMaker.Rows[i].Cells["check_no"].Value.ToString();
                Color chColor = ((cn.Length != 6) ? Color.Yellow : Color.White);
                //GrdMaker[1, i].Style.BackColor = chColor;
                GrdMaker.Rows[i].Cells["check_no"].Style.BackColor = chColor;
                string sc = GrdMaker.Rows[i].Cells["sort_codes"].Value.ToString();
                bool contains = dtMicrList.AsEnumerable().Any(row => sc == row.Field<String>("MICR_CODE"));
                Color chColor1 = (sc.Length != 9 || !contains || (sc == "000000000")) ? Color.Yellow : Color.White;
                GrdMaker[2, i].Style.BackColor = chColor1;

                string bc = GrdMaker.Rows[i].Cells["base_codes"].Value.ToString();
                Color chColor2 = ((bc.Length != 6) || (bc == "") ? Color.Yellow : Color.White);
                GrdMaker[3, i].Style.BackColor = chColor2;

                string tc = GrdMaker.Rows[i].Cells["tran_codes"].Value.ToString();
                //Color chColor3 = tc.Length != 2 ? Color.Yellow : Color.White;
                bool contain = dtTranCodeList.AsEnumerable().Any(row => tc == row.Field<string>("tran_code"));
                Color chColor3 = (tc.Length != 2 || !contain) ? Color.Yellow : Color.White;
                GrdMaker[4, i].Style.BackColor = chColor3;

                if (frmEdit && chColor.Equals(Color.White) &&
                    chColor1.Equals(Color.White) &&
                    chColor2.Equals(Color.White) &&
                    chColor3.Equals(Color.White)
                )
                {
                    var slno = GrdMaker.Rows[i].Cells["serial_no"].Value.ToString();
                    var chequeNo = GrdMaker.Rows[i].Cells["check_no"].Value.ToString();
                    var sortCode = GrdMaker.Rows[i].Cells["sort_codes"].Value.ToString();
                    var baseCode = GrdMaker.Rows[i].Cells["base_codes"].Value.ToString();
                    var tranCode = GrdMaker.Rows[i].Cells["tran_codes"].Value.ToString();


                    //string find = "serial_no = '" + slno + "'";
                    //DataRow result = modifiedRecod.Select(find).FirstOrDefault();
                    //if (result != null)
                    //{
                    //    result.Delete();
                    //}
                    var modRecord = modifiedRecod.NewRow();
                    DataRow rw = modifiedRecod.AsEnumerable().FirstOrDefault(tt => tt.Field<string>("serial_no") == slno);
                    if (rw == null)
                    {
                        modRecord["serial_no"] = slno;
                        modRecord["check_no"] = chequeNo;
                        modRecord["sort_codes"] = sortCode;
                        modRecord["base_codes"] = baseCode;
                        modRecord["tran_codes"] = tranCode;
                        modifiedRecod.Rows.Add(modRecord);
                    }



                }

            }
            GrdMaker.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrdMaker.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrdMaker.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrdMaker.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GrdMaker.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        private void ValidateScannerData()
        {
            try
            {

                GrdMaker.Refresh();
                for (int i = 0; i < GrdMaker.Rows.Count; i++)
                {
                    var cellch = GrdMaker.Rows[i].Cells["check_no"].Value == "" ? "000000" : GrdMaker.Rows[i].Cells["check_no"].Value.ToString();
                    string cellchq = cellch.ToString();
                    Color chColor = ((cellchq.Length != 6) || (cellchq == "000000") ? Color.Yellow : Color.White);
                    GrdMaker[1, i].Style.BackColor = chColor;
                    GrdMaker[1, i].Value = cellch;

                    var cellso = GrdMaker.Rows[i].Cells["sort_codes"].Value == "" ? "000000000" : GrdMaker.Rows[i].Cells["sort_codes"].Value.ToString();
                    string cellsortcode = cellso.ToString();
                    bool contains = dtMicrList.AsEnumerable().Any(row => cellsortcode == row.Field<String>("MICR_CODE"));
                    Color chColor1 = (cellsortcode.Length != 9 || !contains || (cellchq == "000000000")) ? Color.Yellow : Color.White;
                    GrdMaker[2, i].Style.BackColor = chColor1;
                    GrdMaker[2, i].Value = cellsortcode;

                    var cellbs = GrdMaker.Rows[i].Cells["base_codes"].Value == "" ? "000000" : GrdMaker.Rows[i].Cells["base_codes"].Value.ToString();
                    string cellbasecode = cellbs.ToString();
                    Color chColor2 = ((cellbasecode.Length != 6) || (cellbasecode == "") ? Color.Yellow : Color.White);
                    GrdMaker[3, i].Style.BackColor = chColor2;
                    GrdMaker[3, i].Value = cellbasecode;

                    var celltc = GrdMaker.Rows[i].Cells["tran_codes"].Value == "" ? "00" : GrdMaker.Rows[i].Cells["tran_codes"].Value.ToString();
                    string celltrancode = celltc.ToString();
                    bool contain = dtTranCodeList.AsEnumerable().Any(row => celltc == row.Field<String>("tran_code"));
                    Color chColor3 = (celltrancode.Length != 2 || !contain) ? Color.Yellow : Color.White;

                    //Color chColor3 = celltrancode.Length != 2 || (celltrancode == "00") ? Color.Yellow : Color.White;
                    GrdMaker[4, i].Style.BackColor = chColor3;
                    GrdMaker[4, i].Value = celltrancode;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
                String tmp = " ";
                Double tmpWidth = 0;
                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }

                this.Text = tmp + this.Text.Trim();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveValidation()
        {
            bool isvaild = false;
            try
            {
                for (int i = 0; i < GrdMaker.Rows.Count; i++)
                {
                    if (GrdMaker[1, i].Style.BackColor == Color.Yellow)
                    {
                        isvaild = true;
                        break;
                    }
                    if (GrdMaker[2, i].Style.BackColor == Color.Yellow)
                    {
                        isvaild = true;
                        break;
                    }
                    if (GrdMaker[3, i].Style.BackColor == Color.Yellow)
                    {
                        isvaild = true;
                        break;
                    }
                    if (GrdMaker[4, i].Style.BackColor == Color.Yellow)
                    {
                        isvaild = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isvaild;
        }

        private void Testing()
        {
            string path = @"D:\My Projects\VSS\CMSDesktop\CheckManagementSystem\bin\Debug\Scanimage\BATCH-07-05-2019-0013\ScanimageBack1-5-9.Jpeg";
            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var writer = new StreamWriter(stream, Encoding.UTF8);
                writer.Write("Hello world");
                writer.Flush();
                writer.Close();
            }
        }

        #endregion

        #region Events
        private void MakerValidation_Load(object sender, EventArgs e)
        {
            try
            {
                ScannerBusiness sb = new ScannerBusiness();
                dtMicrList = sb.GetMicrList();
                dtTranCodeList = sb.GetTranCodeList();
                LoadMakerBatchDetails();
                //LoadMakerScannedDetails();
                LoadDatafromDB();
                //// rbt_all.Checked = true;
                //string Fbase = GrdMaker.Rows[0].Cells[5].Value.ToString();
                //string Bbase = GrdMaker.Rows[0].Cells[6].Value.ToString();
                //PicFrontSide.Image = ReturnImage(Fbase);
                //PicBackSide.Image = ReturnImage(Bbase);
                //GrdMaker.Focus();
                //GrdMaker.CurrentCell = GrdMaker.Rows[0].Cells[2];
                //rbt_hghlgt.Checked = true;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TheamClass.SetTheam(this);
        }
        private void btnToggle_Click(object sender, EventArgs e)
        {
            try
            {
                if (PicBackSide.Visible == true)
                {
                    PicBackSide.Visible = false;
                    PicFrontSide.Visible = true;
                }
                else if (PicFrontSide.Visible == true)
                {
                    PicBackSide.Visible = true;
                    PicFrontSide.Visible = false;
                }
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
                int rowindex = GrdMaker.CurrentCell.RowIndex;
                string Fbase = GrdMaker.Rows[rowindex].Cells["front_image"].Value.ToString();
                string Bbase = GrdMaker.Rows[rowindex].Cells["back_image"].Value.ToString();
                string micr_code = GrdMaker.Rows[rowindex].Cells["sort_codes"].Value.ToString();
                PicFrontSide.Image = ReturnImage(Fbase);
                PicBackSide.Image = ReturnImage(Bbase);
                string branchname = (dtMicrList.AsEnumerable().Where(p => p["MICR_CODE"].ToString() == micr_code).Select(p => p["BANK_BRANCH_CODE"].ToString())).FirstOrDefault();
                txtBranchName.Text = branchname == "" || branchname == null ? "NOT AVAILABLE" : branchname;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Maker Going to Save");
            bool isval = SaveValidation();
            if (isval == false)
            {
                int success = 0;
                int failed = 0;
                ScannerBusiness objscanner = new ScannerBusiness();
                PicBackSide.Image = null;
                PicFrontSide.Image = null;
                try
                {
                    int scanned = GrdMaker.Rows.Count;
                    //if (Convert.ToInt32(check_Count) == scanned)
                    //{
                    {
                        DataTable dt = new DataTable();
                        foreach (DataGridViewColumn col in GrdMaker.Columns)
                        {
                            dt.Columns.Add(col.Name);
                        }
                        foreach (DataGridViewRow row in GrdMaker.Rows)
                        {
                            DataRow dRow = dt.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dt.Rows.Add(dRow);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ScannerEntities scan = new ScannerEntities();
                            scan.batch_no = batch_num;
                            scan.cheq_no = dt.Rows[i]["check_no"].ToString() == "" ? "" : dt.Rows[i]["check_no"].ToString();
                            scan.sort_code = dt.Rows[i]["sort_codes"].ToString() == "" ? "" : dt.Rows[i]["sort_codes"].ToString();
                            scan.base_code = dt.Rows[i]["base_codes"].ToString() == "" ? "" : dt.Rows[i]["base_codes"].ToString();
                            scan.tran_code = dt.Rows[i]["tran_codes"].ToString() == "" ? "" : dt.Rows[i]["tran_codes"].ToString();
                            scan.front_image = dt.Rows[i]["front_image"].ToString() == "" ? "" : dt.Rows[i]["front_image"].ToString();
                            scan.back_image = dt.Rows[i]["back_image"].ToString() == "" ? "" : dt.Rows[i]["back_image"].ToString();
                            scan.status = dt.Rows[i]["status"].ToString() == "" ? "" : dt.Rows[i]["status"].ToString();
                            scan.scan_id = Convert.ToInt32(dt.Rows[i]["scan_id"].ToString()) == 0 ? 0 : Convert.ToInt32(dt.Rows[i]["scan_id"].ToString());
                            string[] result = objscanner.SaveScanedDetails(scan);
                            if (result[1] == "1")
                            {
                                success++;
                            }
                            else
                            {
                                failed++;
                            }
                        }
                        MessageBox.Show("Data Uploaded : " + success + "; Failed : " + failed);
                        this.Close();
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Shoult Not Exit Untill the Scan Completed");
                    //    if (GrdMaker.Rows.Count > 0)
                    //    {
                    //    }
                    //    else
                    //    {
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    //LogHelper.WriteLog(ex.ToString());
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Correct the Highlight Values", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Close the Maker Screen...");
            this.Close();
        }

        private void GrdMaker_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //var slno = GrdMaker.Rows[e.RowIndex].Cells["serial_no"].Value.ToString();
                //var chequeNo = GrdMaker.Rows[e.RowIndex].Cells["check_no"].Value.ToString();
                //var sortCode = GrdMaker.Rows[e.RowIndex].Cells["sort_codes"].Value.ToString();
                //var baseCode = GrdMaker.Rows[e.RowIndex].Cells["base_codes"].Value.ToString();
                //var tranCode = GrdMaker.Rows[e.RowIndex].Cells["tran_codes"].Value.ToString();


                //string find = "serial_no = '" + slno + "'";
                //DataRow result = modifiedRecod.Select(find).FirstOrDefault();
                //if(result!=null)
                //{
                //    result.Delete();
                //}
                //var modRecord = modifiedRecod.NewRow();

                //modRecord["serial_no"] = slno;
                //modRecord["check_no"] = chequeNo;
                //modRecord["sort_codes"] = sortCode;
                //modRecord["base_codes"] = baseCode;
                //modRecord["tran_codes"] = tranCode;
                //modifiedRecod.Rows.Add(modRecord);

                //DataTable modifieddt = new DataTable();

                HiglightRows(true);
                return;


                var cellch = GrdMaker.Rows[e.RowIndex].Cells["Cheque No"].Value == null ? "000000" : GrdMaker.Rows[e.RowIndex].Cells["Cheque No"].Value.ToString();
                string cellchq = cellch.ToString().Trim();
                Color chColor = ((cellchq.Length != 6) ? Color.Yellow : Color.White);
                GrdMaker[1, e.RowIndex].Style.BackColor = chColor;
                GrdMaker[1, e.RowIndex].Value = cellch;

                var cellso = GrdMaker.Rows[e.RowIndex].Cells["Sort Code"].Value == null ? "000000000" : GrdMaker.Rows[e.RowIndex].Cells["Sort Code"].Value.ToString();
                string cellsortcode = cellso.ToString().Trim();
                bool contains = dtMicrList.AsEnumerable().Any(row => cellsortcode == row.Field<String>("MICR_CODE"));
                Color chColor1 = (cellsortcode.Length != 9 || !contains || (cellchq == "000000000")) ? Color.Yellow : Color.White;
                GrdMaker[2, e.RowIndex].Style.BackColor = chColor1;
                GrdMaker[2, e.RowIndex].Value = cellsortcode;

                var cellbs = GrdMaker.Rows[e.RowIndex].Cells["Base Code"].Value == null ? "000000" : GrdMaker.Rows[e.RowIndex].Cells["Base Code"].Value.ToString();
                string cellbasecode = cellbs.ToString().Trim();
                //string cellbasecode = grdScanning.Rows[e.RowIndex].Cells["base_codes"].Value.ToString();
                Color chColor2 = ((cellbasecode.Length != 6) ? Color.Yellow : Color.White);
                GrdMaker[3, e.RowIndex].Style.BackColor = chColor2;
                GrdMaker[3, e.RowIndex].Value = cellbasecode;

                var celltc = GrdMaker.Rows[e.RowIndex].Cells["Tran Code"].Value == null ? "00" : GrdMaker.Rows[e.RowIndex].Cells["Tran Code"].Value.ToString();
                string celltrancode = celltc.ToString().Trim();
                bool contain = dtTranCodeList.AsEnumerable().Any(row => celltrancode == row.Field<string>("tran_code"));
                Color chColor3 = (celltrancode.Length != 2 || !contain ? Color.Yellow : Color.White);
                GrdMaker[4, e.RowIndex].Style.BackColor = chColor3;
                GrdMaker[4, e.RowIndex].Value = celltrancode;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("Refresh the Maker Screen");
            try
            {
                ScannerBusiness sb = new ScannerBusiness();
                dtMicrList = sb.GetMicrList();
                ValidateScannerData();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrdMaker_KeyDown(object sender, KeyEventArgs e)
        {

            sortcount = 0;
            basecount = 0;
            trancount = 0;

            //if (e.KeyData == System.Windows.Forms.Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //}
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    e.SuppressKeyPress = true;
                //    int iColumn = GrdMaker.CurrentCell.ColumnIndex;
                //    int iRow = GrdMaker.CurrentCell.RowIndex;
                //    if (iColumn == GrdMaker.Columns.Count - 1)
                //        GrdMaker.CurrentCell = GrdMaker[0, iRow + 1];
                //    else
                //        GrdMaker.CurrentCell = GrdMaker[iColumn + 1, iRow];
                //}
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gvscanlist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int iColumn = gvscanlist.CurrentCell.ColumnIndex;
                int iRow = gvscanlist.CurrentCell.RowIndex;
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;

                    if (iColumn == gvscanlist.Columns.Count - 1)
                        gvscanlist.CurrentCell = GrdMaker[0, iRow + 1];
                    else
                        gvscanlist.CurrentCell = GrdMaker[iColumn + 1, iRow];
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrdMaker_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (GrdMaker.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (GrdMaker.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (GrdMaker.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                //sortcount = 0;
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (GrdMaker.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (GrdMaker.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 48 && ascii <= 57) || (ascii == 8) || ascii == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void SortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 48 && ascii <= 57) || (ascii == 8) || ascii == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            //int ascii = Convert.ToInt16(e.KeyChar);
            //if (ascii == 8)
            //{
            //    e.Handled = false;
            //    return;
            //}
            //if ((ascii >= 48 && ascii <= 57) || ascii == 46)
            //{
            //    //e.Handled = false;
            //    if (sortcount == 0)
            //    {
            //        sortcount++;
            //        e.Handled = false;
            //    }
            //    else
            //    {
            //        if ((sender as TextBox).Text.Length > 8)
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }
        private void BaseCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if (ascii == 8)
            {
                e.Handled = false;
                return;
            }
            if ((ascii >= 48 && ascii <= 57) || ascii == 46)
            {
                //e.Handled = false;
                //if ((sender as TextBox).Text.Length > 5)
                //{
                //    e.Handled = true;
                //    return;
                //}

                if (basecount == 0)
                {
                    basecount++;
                    e.Handled = false;
                }
                else
                {
                    if ((sender as TextBox).Text.Length > 5)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }

        }
        private void TranCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if (ascii == 8)
            {
                e.Handled = false;
                return;
            }
            if ((ascii >= 48 && ascii <= 57) || ascii == 46)
            {
                //e.Handled = false;
                //if ((sender as TextBox).Text.Length > 1)
                //{
                //    e.Handled = true;
                //    return;
                //}
                if (trancount == 0)
                {
                    trancount++;
                    e.Handled = false;
                }
                else
                {
                    if ((sender as TextBox).Text.Length > 1)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        private void rbt_hghlgt_CheckedChanged(object sender, EventArgs e)
        {
            //LoadMakerScannedDetailsOnlyHiglight();
            // modifiedRecod.Rows.Clear();
            if (rbt_hghlgt.Checked == true)
            {
                LoadMakerScannedDetails();
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;

            }
        }

        private void rbt_all_CheckedChanged(object sender, EventArgs e)
        {
            //modifiedRecod.Rows.Clear();
            if (rbt_all.Checked == true)
            {
                LoadMakerScannedDetails();
            }
        }

        private void GrdMaker_KeyUp(object sender, KeyEventArgs e)
        {
            sortcount = 0;
            basecount = 0;
            trancount = 0;
        }
    }
}
