using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Tesseract;

namespace CheckManagementSystem
{
    public partial class ImageUpload : Form
    {
        List<xmlfileread> XmlData = new List<xmlfileread>();
        List<xmlfileread> DRXmlData = new List<xmlfileread>();
        List<string> Filename = new List<string>();
        List<string> ItemseqNo = new List<string>();
        List<string> itemsquenceremove = new List<string>();
        List<string> Ajentex = new List<string>();
        List<xmlfileread> Batch = new List<xmlfileread>();
        string filepath;

        public ImageUpload()
        {
            InitializeComponent();
        }
        private void btnBatch_Click(object sender, EventArgs e)
        {
            XmlNodeList xNodeList1;
            try
            {
                string mainPath = @"D:\CMSFiles\821Test";
                //folder with my xml files goes here, it's optional, you can change it to whatever you want
                foreach (string file in Directory.EnumerateFiles(mainPath, "*.xml"))
                {
                    XmlTextReader xml = new XmlTextReader(file);
                    xml.Read();
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(file);
                    var doc = xmlDoc.SelectNodes("Gender").OfType<XmlNode>().Select(n => n.InnerText).ToArray();
                    xNodeList1 = xmlDoc.GetElementsByTagName("ItemDetail");
                    foreach (XmlNode xNode in xNodeList1)
                    {
                        //string gn = xNode.ParentNode.InnerXml;
                        string gender = xNode.Attributes["Gender"].Value.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void GetImage(string imageExtesion, string type)
        {
            if (type == "CR")
            {

            }
            else if (type == "DR")
            {

            }
            else
            {

            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            // listxmlfilename.DataSource = Filename.ToList<string>();
            // listitemsquence.DataSource = itemsquenceremove.Distinct().ToList<string>();

        }

        private void listxmlfilename_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void ImageUpload_Load(object sender, EventArgs e)
        {
            cmbtype.DataSource = new BindingSource(DynamicCombo(), null);
            cmbtype.DisplayMember = "Value";
            cmbtype.ValueMember = "Key";
            InwardBusiness objinward = new InwardBusiness();

            DataTable dtbranch = objinward.GetBranches();
            DataRow rows = dtbranch.NewRow();
            rows["Branch Name"] = "--Select--";
            dtbranch.Rows.InsertAt(rows, 0);
            cmblocation.DataSource = dtbranch;
            cmblocation.DisplayMember = "Branch Name";
            cmblocation.ValueMember = "Branch Code";
        }

        private Dictionary<string, string> DynamicCombo()
        {

            // List<string> combo = new List<string>();
            Dictionary<string, string> combo = new Dictionary<string, string>();
            try
            {
                //var applicationSettings = ConfigurationManager.GetSection("branch") as NameValueCollection;
                ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("FilterHashKey");
                if (section != null)
                    foreach (FilterHashElement element in section.HashKeys)
                    {

                        combo.Add(element.Value, element.Value);
                    }
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(ex.ToString());
            }
            return combo;

        }


        private void listitemsquence_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Ajentex.Clear();

            //for (int c=0; c < XmlData.Count; c++)
            //{
            //    if (XmlData[c].BatchnoSeqNo == listitemsquence.SelectedItem.ToString().Substring(listitemsquence.SelectedItem.ToString().Length - 3))
            //    {

            //        Ajentex.Add(XmlData[c].ItemSeqNo.ToString()); 

            //    }
            //}

            //listBox1.DataSource = null;

            //listBox1.Items.Clear();

            //listBox1.DataSource = Ajentex;

            //listBox1.Refresh();  

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btnupload_Click(object sender, EventArgs e)
        {
            Batch.Clear();
            for (int a = 0; a < DRXmlData.Count; a++)
            {
                //if (DRXmlData[a].BatchnoSeqNo != DRXmlData[a].SeqNo)
                //{
                //    Batch.Add(DRXmlData[a]);
                //}
                Batch.Add(DRXmlData[a]);
            }
            if (Batch.Count > 0)
            {
                BatchBusiness objBusiness = new BatchBusiness();
                List<BatchEntities> batchEntitity = new List<BatchEntities>();
                BatchEntities batch = new BatchEntities();
                batch.inward_id = "1";
                batch.batch_no = "0";
                batch.branch_cheque_count = Batch.Count.ToString();
                batch.batch_amount = "0000000";
                batch.batch_dep_slip_no = "00000";
                batch.customer_code = "Image Upload";
                batchEntitity.Add(batch);
                DataTable dt = objBusiness.SaveBatching(batchEntitity);
                if (dt.Rows.Count > 0)
                {
                    LogHelper.WriteLog("Going to Save Scanned List....");
                    ScannerBusiness objscanner = new ScannerBusiness();
                    int success = 0;
                    int failed = 0;
                    for (int b = 0; b < Batch.Count; b++)
                    {
                        string filePaths1 = Batch[b].Filepath.ToString() + "\\" + Batch[b].FBFileName.ToString();
                        var img = new Bitmap(filePaths1);
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


                        ScannerEntities scan = new ScannerEntities();
                        scan.batch_no = dt.Rows[dt.Rows.Count - 1]["Batch No"].ToString();
                        scan.cheq_no = cheq_no;
                        scan.sort_code = sort_code;
                        scan.base_code = base_code;
                        scan.tran_code = tran_code;
                        scan.front_image = ConvertTo(Batch[b].Filepath + "//" + Batch[b].FBFileName);
                        scan.back_image = ConvertTo(Batch[b].Filepath + "//" + Batch[b].RBFileName);
                        scan.front_uv_image = ConvertTo(Batch[b].Filepath + "//" + Batch[b].FUFileName);
                        scan.greyfront_image = ConvertTo(Batch[b].Filepath + "//" + Batch[b].FGFileName);
                        scan.greyback_image = "NA";
                        scan.status = "";
                        scan.scan_id = 0;
                        //scan.front_uv_image = dt.Rows[i]["front_uv_image"].ToString() == "" ? "" : dt.Rows[i]["front_uv_image"].ToString();
                        //scan.back_uv_image = dt.Rows[i]["back_uv_image"].ToString() == "" ? "" : dt.Rows[i]["back_uv_image"].ToString();
                        string[] resultdata = objscanner.SaveScanedDetails(scan);
                        if (resultdata[1] == "1")
                        {
                            success++;
                        }
                        else
                        {
                            failed++;
                        }

                    }

                }
            }
        }



        public string ConvertTo(string Path)
        {
            //using (Image image = Image.FromFile(Path))
            //{
            //    using (MemoryStream m = new MemoryStream())
            //    {
            //        image.Save(m, image.RawFormat);

            //        byte[] imageBytes = m.ToArray();

            //        // Convert byte[] to Base64 String

            //        string base64String = Convert.ToBase64String(imageBytes);

            //        return base64String;
            //    }
            //}
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(Path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }


        }

        public string ConverttiffTobase64(string Path)
        {

            //var data = File.ReadAllBytes(Path);
            //string result = Convert.ToBase64String(data);
            //return result;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(Path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        private string[] GetCheMicBasTra(string inputStr)
        {
            string[] result = new string[4];
            try
            {

                // string amount = "";
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
                // amount = CheMicBasTrn[CheMicBasTrn.Length - 5];
                chequeNo = CheMicBasTrn[CheMicBasTrn.Length - 4];
                micrCode = CheMicBasTrn[CheMicBasTrn.Length - 3];
                //int a = CheMicBasTrn[CheMicBasTrn.Length - 2].Length;
                baseCode = CheMicBasTrn[CheMicBasTrn.Length - 2].Length == 0 ? "000000" : CheMicBasTrn[CheMicBasTrn.Length - 2].Replace("-", "");
                tranCode = CheMicBasTrn[CheMicBasTrn.Length - 1];

                //textBox1.Text = chequeNo.Trim() + "/" + micrCode.Trim() + "/" + baseCode.Trim() + "/" + tranCode.Trim();
                //return textBox1.Text;

                //amount = Regex.Replace(amount, "[^.0-9]", "");
                chequeNo = Regex.Replace(chequeNo, "[^.0-9]", "");
                micrCode = Regex.Replace(micrCode, "[^.0-9]", "");
                tranCode = Regex.Replace(tranCode, "[^.0-9]", "");
                baseCode = Regex.Replace(baseCode, "[^.0-9]", "");

                // result[0] = amount.Trim();
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
                //result[4] = "";
            }
            //return chequeNo + "/" + micrCode + "/" + baseCode + "/" + tranCode;
            return result;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string UploadFileName = folderDlg.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(UploadFileName);
                FileInfo[] fi = di.EnumerateFiles().Where(file => file.Extension == ".xml").ToArray();
                XmlData.Clear();
                DRXmlData.Clear();
                Filename.Clear();
                ItemseqNo.Clear();
                itemsquenceremove.Clear();
                for (int a = 0; a < fi.Length; a++)
                {
                    string FileName = fi[a].DirectoryName.ToString() + "\\" + fi[a].Name.ToString();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(FileName);
                    XmlNodeList elemList = doc.GetElementsByTagName("ItemDetail");
                    for (int i = 0; i < elemList.Count; i++)
                    {
                        string attrVal = elemList[i].Attributes["Gender"].Value;
                        if (attrVal == "CR")
                        {
                            string[] data = fi[a].Name.ToString().Split(new char[] { '_', '.' });
                            xmlfileread xmlobj = new xmlfileread();
                            xmlobj.FileName = fi[a].Name.ToString();
                            xmlobj.ItemSeqNo = elemList[i].Attributes["ItemSeqNo"].Value;
                            xmlobj.Batchno = data[7].ToString();
                            xmlobj.BatchnoSeqNo = data[6].ToString();
                            xmlobj.SeqNo = data[8].ToString();
                            xmlobj.Filepath = fi[a].DirectoryName.ToString();
                            xmlobj.FGFileName = elemList[i].Attributes["FGFileName"].Value;
                            xmlobj.FBFileName = elemList[i].Attributes["FBFileName"].Value;
                            xmlobj.FUFileName = elemList[i].Attributes["FUFileName"].Value;
                            xmlobj.RBFileName = elemList[i].Attributes["RBFileName"].Value;
                            xmlobj.Deptslipno = elemList[i].Attributes["ItemSeqNo"].Value.ToString().Substring(0, elemList[i].Attributes["ItemSeqNo"].Value.ToString().Length - 3);
                            xmlobj.ChequeCount = "0";
                            XmlData.Add(xmlobj);
                        }
                        else if (attrVal == "DR")
                        {
                            string[] data = fi[a].Name.ToString().Split(new char[] { '_', '.' });
                            xmlfileread xmlobj = new xmlfileread();
                            xmlobj.FileName = fi[a].Name.ToString();
                            xmlobj.ItemSeqNo = elemList[i].Attributes["ItemSeqNo"].Value;
                            xmlobj.Batchno = data[7].ToString();
                            xmlobj.BatchnoSeqNo = data[6].ToString();
                            xmlobj.SeqNo = data[8].ToString();
                            xmlobj.Filepath = fi[a].DirectoryName.ToString();
                            xmlobj.FGFileName = elemList[i].Attributes["FGFileName"].Value;
                            xmlobj.FBFileName = elemList[i].Attributes["FBFileName"].Value;
                            xmlobj.FUFileName = elemList[i].Attributes["FUFileName"].Value;
                            xmlobj.RBFileName = elemList[i].Attributes["RBFileName"].Value;
                            xmlobj.Deptslipno = elemList[i].Attributes["ItemSeqNo"].Value.ToString().Substring(0, elemList[i].Attributes["ItemSeqNo"].Value.ToString().Length - 3);
                            xmlobj.ChequeCount = "0";
                            DRXmlData.Add(xmlobj);
                        }
                    }
                }

                DataTable uploadTable = new DataTable();
                DataColumn dtColumn;
                DataRow dtRow;

                // Create id column  
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(string);
                dtColumn.ColumnName = "SlipNo";
                dtColumn.Caption = "Slip No";
                dtColumn.ReadOnly = true;
                uploadTable.Columns.Add(dtColumn);
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(string);
                dtColumn.ColumnName = "DepositSlipNo";
                dtColumn.Caption = "Deposit Slip No";
                uploadTable.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(string);
                dtColumn.ColumnName = "ChequeCount";
                dtColumn.Caption = "Cheque Count";
                dtColumn.ReadOnly = true;
                uploadTable.Columns.Add(dtColumn);

                // Add column to the DataColumnCollection. 
                // Create id column  
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(string);
                dtColumn.ColumnName = "Amount";
                dtColumn.Caption = "Amount";
                uploadTable.Columns.Add(dtColumn);
                // Add column to the DataColumnCollection.
                // Create id column             




                for (int b = 0; b < XmlData.Count; b++)
                {

                    Filename.Add(XmlData[b].FileName.ToString());
                    ItemseqNo.Add(XmlData[b].ItemSeqNo.ToString());
                    itemsquenceremove.Add(XmlData[b].ItemSeqNo.ToString().Substring(0, XmlData[b].ItemSeqNo.ToString().Length - 3));

                }
                var teamTotalScores = DRXmlData.GroupBy(T => new { T.Deptslipno }).Select(V => new xmlfileread
                {
                    Deptslipno = V.First().Deptslipno,
                    ChequeCount = V.Count().ToString(),
                }).ToList();

                List<string> Data = itemsquenceremove.Distinct().ToList<string>();
                if (Data.Count > 0)
                {
                    for (int c = 0; c < Data.Count; c++)
                    {
                        dtRow = uploadTable.NewRow();
                        dtRow["SlipNo"] = Data[c].ToString();
                        dtRow["DepositSlipNo"] = "";
                        dtRow["ChequeCount"] = teamTotalScores[c].ChequeCount.ToString();
                        dtRow["Amount"] = "";

                        //dtRow["CustomerName"] = "";
                        // dtRow["Status"] = "";
                        uploadTable.Rows.Add(dtRow);
                    }
                }
                grd_imageupload.DataSource = uploadTable;
                DataGridViewComboBoxColumn cmbcell = new DataGridViewComboBoxColumn();
                cmbcell.Name = "CustomerName";
                cmbcell.HeaderText = "Customer Name";
                MasterBusiness obj = new MasterBusiness();
                MasterEntities.CustomerMaster.Customers cust = new MasterEntities.CustomerMaster.Customers();
                cust = obj.GetCustomers();
                if (cust.Accounts != null)
                {
                    if (cust != null && cust.Accounts.Count != 0)
                    {
                        for (int j = 0; j < cust.Accounts.Count; j++)
                        {
                            cmbcell.Items.Add((string)cust.Accounts[j].account_name);
                        }
                        cmbcell.DisplayMember = cust.Accounts[0].account_name;

                    }
                    grd_imageupload.Columns.Add(cmbcell);
                }
                else
                {
                    MessageBox.Show("Please Update the Customer Master", "Check Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                grd_imageupload.Columns.Add("Status", "Status");
                grd_imageupload.Columns["SlipNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grd_imageupload.Columns["DepositSlipNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grd_imageupload.Columns["ChequeCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grd_imageupload.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            try
            {
                if (cmblocation.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Select PickUp Location ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {


                    if (grd_imageupload.Rows.Count > 0)
                    {
                        bool amtvalidate = true;
                        for (int a = 0; a < grd_imageupload.Rows.Count; a++)
                        {
                            if (grd_imageupload.Rows[a].Cells["Amount"].Value == "" || grd_imageupload.Rows[a].Cells["Amount"].Value == null)
                            {
                                amtvalidate = false;
                            }
                        }
                        if (amtvalidate)
                        {

                            for (int b = 0; b < grd_imageupload.Rows.Count; b++)
                            {
                                grd_imageupload.Rows[b].Cells["Status"].Value = "Inward Initiated";
                                InwardEntites objInward = new InwardEntites();
                                objInward.inward_datetime = DateTime.Now.ToString("yyyy-MM-dd");//dateTimePicker1.Value.ToShortDateString();
                                objInward.inward_type = cmbtype.SelectedValue.ToString();
                                objInward.lot_no = "";
                                //  var a = cmblocation.GetItemText(cmblocation.Items[cmblocation.SelectedIndex]); //cmblocation.Items[cmblocation.SelectedIndex].ToString();
                                //cmblocation.GetItemText(cmblocation.Items[cmblocation.SelectedIndex]);
                                objInward.branch_code_name = cmblocation.SelectedValue.ToString();//cmbbrcode.SelectedValue.ToString();
                                //objInward.pickup_location = cmblocation.GetItemText(cmblocation.Items[cmblocation.SelectedIndex]); //cmblocation.SelectedValue.ToString();
                                objInward.pickup_location = "";//cmblocation.SelectedValue.ToString(); //cmblocation.SelectedValue.ToString();
                                objInward.cheque_count = grd_imageupload.Rows[b].Cells["ChequeCount"].Value.ToString();
                                objInward.status = "Inward Completed";
                                objInward.created_by = "Image Upload";
                                InwardBusiness objBusiness = new InwardBusiness();
                                //objInward = objBusiness.SaveInward(objInward);
                                if (objInward.msg == "Record Saved successfully!")
                                {

                                    grd_imageupload.Rows[b].Cells["Status"].Value = objInward.status.ToString();

                                    Batch.Clear();
                                    for (int a = 0; a < DRXmlData.Count; a++)
                                    {
                                        if (grd_imageupload.Rows[b].Cells["SlipNo"].Value.ToString() == DRXmlData[a].Deptslipno)
                                        {
                                            Batch.Add(DRXmlData[a]);
                                        }
                                        //Batch.Add(DRXmlData[a]);
                                    }
                                    grd_imageupload.Rows[b].Cells["Status"].Value = "Batch Initiated";
                                    int success = 0;
                                    int failed = 0;
                                    if (Batch.Count > 0)
                                    {
                                        BatchBusiness objBusiness1 = new BatchBusiness();
                                        List<BatchEntities> batchEntitity = new List<BatchEntities>();
                                        BatchEntities batch = new BatchEntities();
                                        batch.inward_id = objInward.result.ToString();
                                        batch.batch_no = "0";
                                        batch.branch_cheque_count = Batch.Count.ToString();
                                        batch.batch_amount = grd_imageupload.Rows[b].Cells["Amount"].Value.ToString();
                                        batch.batch_dep_slip_no = grd_imageupload.Rows[b].Cells["DepositSlipNo"].Value.ToString();
                                        //batch.customer_code = "Image Upload";
                                        batch.customer_code = grd_imageupload.Rows[b].Cells["CustomerName"].Value.ToString();
                                        batchEntitity.Add(batch);
                                        DataTable dt = objBusiness1.SaveBatching(batchEntitity);
                                        if (dt.Rows.Count > 0)
                                        {
                                            grd_imageupload.Rows[b].Cells["Status"].Value = "Batch Completed";
                                            LogHelper.WriteLog("Going to Save Scanned List....");
                                            ScannerBusiness objscanner = new ScannerBusiness();
                                            grd_imageupload.Rows[b].Cells["Status"].Value = "Scanning  Initiated";
                                            LogHelper.WriteLog("Start to Read MICR Code From Image");
                                            for (int c = 0; c < Batch.Count; c++)
                                            {
                                                LogHelper.WriteLog("Image Read cheque Count :" + (c + 1));
                                                string filePaths1 = Batch[c].Filepath.ToString() + "\\" + Batch[c].FBFileName.ToString();
                                                LogHelper.WriteLog("Image reader File Path is " + filePaths1);

                                                var img = new Bitmap(filePaths1);
                                                string[] s = { "\\bin" };
                                                string path = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\tessdata";
                                                LogHelper.WriteLog("Tesseract path is..." + path);
                                                var ocr = new TesseractEngine(path, "mcr+oab", EngineMode.TesseractOnly);
                                                var page = ocr.Process(img);
                                                string ocrtxt = page.GetText();
                                                //string Che_Mic_Bas_Tra = GetCheMicBasTra(page.GetText().Trim());
                                                string[] result = GetCheMicBasTra(page.GetText().Trim());
                                                string cheq_no = result[0];
                                                string sort_code = result[1];
                                                string tran_code = result[2];
                                                string base_code = result[3];
                                                ScannerEntities scan = new ScannerEntities();
                                                scan.batch_no = dt.Rows[dt.Rows.Count - 1]["Batch No"].ToString();
                                                scan.cheq_no = cheq_no;
                                                scan.sort_code = sort_code;
                                                scan.base_code = base_code;
                                                scan.tran_code = tran_code;
                                                scan.front_image = ConverttiffTobase64(Batch[c].Filepath + "//" + Batch[c].FBFileName);
                                                scan.back_image = ConverttiffTobase64(Batch[c].Filepath + "//" + Batch[c].RBFileName);
                                                scan.front_uv_image = ConvertTo(Batch[c].Filepath + "//" + Batch[c].FUFileName);
                                                scan.greyfront_image = ConvertTo(Batch[c].Filepath + "//" + Batch[c].FGFileName);
                                                scan.greyback_image = "NA";
                                                scan.status = "";
                                                scan.scan_id = 0;
                                                //scan.front_uv_image = dt.Rows[i]["front_uv_image"].ToString() == "" ? "" : dt.Rows[i]["front_uv_image"].ToString();
                                                //scan.back_uv_image = dt.Rows[i]["back_uv_image"].ToString() == "" ? "" : dt.Rows[i]["back_uv_image"].ToString();
                                                string[] resultdata = objscanner.SaveScanedDetails(scan);
                                                if (resultdata[1] == "1")
                                                {
                                                    success++;
                                                }
                                                else
                                                {
                                                    failed++;
                                                }
                                            }
                                        }
                                        LogHelper.WriteLog("Image Uploading Completed Success ; " + success + " failed :" + failed);
                                    }
                                    if (Batch.Count == success)
                                    {
                                        grd_imageupload.Rows[b].Cells["Status"].Value = "Scanning  Completed";
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            PicLoad.Visible = false;
        }

        private void grd_imageupload_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                var comboBox = e.Control as DataGridViewComboBoxEditingControl;
                if (comboBox != null)
                {
                    comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                    comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void grd_imageupload_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = grd_imageupload.CurrentCell.ColumnIndex;
                    int iRow = grd_imageupload.CurrentCell.RowIndex;
                    if (iColumn == grd_imageupload.Columns.Count - 1)
                        grd_imageupload.CurrentCell = grd_imageupload[0, iRow + 1];
                    else
                        grd_imageupload.CurrentCell = grd_imageupload[iColumn + 1, iRow];
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
    }
}
