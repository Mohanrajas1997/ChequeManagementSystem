namespace CheckManagementSystem
{
    partial class ScannerRangers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerRangers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdScanning = new System.Windows.Forms.DataGridView();
            this.serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tran_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.front_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.front_image_fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back_image_fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.front_uv_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.front_uv_image_fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.front_grey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.front_gray_image_filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back_grey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back_grey_image_filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCorrection = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnrange = new System.Windows.Forms.Button();
            this.axRanger1 = new AxRANGERLib.AxRanger();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.vtnexit = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnuvscan = new System.Windows.Forms.Button();
            this.btnImgScan = new System.Windows.Forms.Button();
            this.pictureScannedImageBack = new System.Windows.Forms.PictureBox();
            this.GrVwBatching = new System.Windows.Forms.DataGridView();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depo_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scan_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicbxScannedFront = new System.Windows.Forms.PictureBox();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdScanning)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axRanger1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureScannedImageBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrVwBatching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicbxScannedFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // grdScanning
            // 
            this.grdScanning.AllowUserToAddRows = false;
            this.grdScanning.AllowUserToDeleteRows = false;
            this.grdScanning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grdScanning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdScanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdScanning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial_no,
            this.check_no,
            this.sort_codes,
            this.base_codes,
            this.tran_codes,
            this.front_image,
            this.front_image_fileName,
            this.back_image,
            this.back_image_fileName,
            this.front_uv_image,
            this.front_uv_image_fileName,
            this.front_grey,
            this.front_gray_image_filename,
            this.back_grey,
            this.back_grey_image_filename});
            this.grdScanning.Location = new System.Drawing.Point(-46, 3);
            this.grdScanning.MultiSelect = false;
            this.grdScanning.Name = "grdScanning";
            this.grdScanning.ReadOnly = true;
            this.grdScanning.Size = new System.Drawing.Size(985, 290);
            this.grdScanning.TabIndex = 29;
            this.grdScanning.SelectionChanged += new System.EventHandler(this.grdScanning_SelectionChanged);
            // 
            // serial_no
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.serial_no.DefaultCellStyle = dataGridViewCellStyle1;
            this.serial_no.HeaderText = "Serial No";
            this.serial_no.Name = "serial_no";
            this.serial_no.ReadOnly = true;
            // 
            // check_no
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.check_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.check_no.HeaderText = "Cheque No";
            this.check_no.Name = "check_no";
            this.check_no.ReadOnly = true;
            // 
            // sort_codes
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sort_codes.DefaultCellStyle = dataGridViewCellStyle3;
            this.sort_codes.HeaderText = "Sort Code";
            this.sort_codes.Name = "sort_codes";
            this.sort_codes.ReadOnly = true;
            // 
            // base_codes
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.base_codes.DefaultCellStyle = dataGridViewCellStyle4;
            this.base_codes.HeaderText = "Base Code";
            this.base_codes.Name = "base_codes";
            this.base_codes.ReadOnly = true;
            // 
            // tran_codes
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tran_codes.DefaultCellStyle = dataGridViewCellStyle5;
            this.tran_codes.HeaderText = "Tran Code";
            this.tran_codes.Name = "tran_codes";
            this.tran_codes.ReadOnly = true;
            // 
            // front_image
            // 
            this.front_image.HeaderText = "Front Image";
            this.front_image.Name = "front_image";
            this.front_image.ReadOnly = true;
            this.front_image.Visible = false;
            // 
            // front_image_fileName
            // 
            this.front_image_fileName.HeaderText = "Front Image FileName";
            this.front_image_fileName.Name = "front_image_fileName";
            this.front_image_fileName.ReadOnly = true;
            this.front_image_fileName.Visible = false;
            // 
            // back_image
            // 
            this.back_image.HeaderText = "Back Image";
            this.back_image.Name = "back_image";
            this.back_image.ReadOnly = true;
            this.back_image.Visible = false;
            // 
            // back_image_fileName
            // 
            this.back_image_fileName.HeaderText = "Back Image FileName";
            this.back_image_fileName.Name = "back_image_fileName";
            this.back_image_fileName.ReadOnly = true;
            this.back_image_fileName.Visible = false;
            // 
            // front_uv_image
            // 
            this.front_uv_image.HeaderText = "Front UV";
            this.front_uv_image.Name = "front_uv_image";
            this.front_uv_image.ReadOnly = true;
            this.front_uv_image.Visible = false;
            // 
            // front_uv_image_fileName
            // 
            this.front_uv_image_fileName.HeaderText = "Front UV Image FileName";
            this.front_uv_image_fileName.Name = "front_uv_image_fileName";
            this.front_uv_image_fileName.ReadOnly = true;
            this.front_uv_image_fileName.Visible = false;
            // 
            // front_grey
            // 
            this.front_grey.HeaderText = "Front Grey";
            this.front_grey.Name = "front_grey";
            this.front_grey.ReadOnly = true;
            this.front_grey.Visible = false;
            // 
            // front_gray_image_filename
            // 
            this.front_gray_image_filename.HeaderText = "FGImageFileName";
            this.front_gray_image_filename.Name = "front_gray_image_filename";
            this.front_gray_image_filename.ReadOnly = true;
            this.front_gray_image_filename.Visible = false;
            // 
            // back_grey
            // 
            this.back_grey.HeaderText = "Back Grey";
            this.back_grey.Name = "back_grey";
            this.back_grey.ReadOnly = true;
            this.back_grey.Visible = false;
            // 
            // back_grey_image_filename
            // 
            this.back_grey_image_filename.HeaderText = "BGImageFileName";
            this.back_grey_image_filename.Name = "back_grey_image_filename";
            this.back_grey_image_filename.ReadOnly = true;
            this.back_grey_image_filename.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdScanning);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 397);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1169, 302);
            this.panel2.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btCorrection);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnrange);
            this.panel3.Controls.Add(this.axRanger1);
            this.panel3.Controls.Add(this.btnToggle);
            this.panel3.Controls.Add(this.lblstatus);
            this.panel3.Controls.Add(this.vtnexit);
            this.panel3.Controls.Add(this.btnContinue);
            this.panel3.Controls.Add(this.btnuvscan);
            this.panel3.Controls.Add(this.btnImgScan);
            this.panel3.Location = new System.Drawing.Point(945, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel3.Size = new System.Drawing.Size(212, 287);
            this.panel3.TabIndex = 28;
            // 
            // btCorrection
            // 
            this.btCorrection.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btCorrection.ForeColor = System.Drawing.Color.White;
            this.btCorrection.Location = new System.Drawing.Point(7, 223);
            this.btCorrection.Name = "btCorrection";
            this.btCorrection.Size = new System.Drawing.Size(106, 30);
            this.btCorrection.TabIndex = 47;
            this.btCorrection.Text = "Correction";
            this.btCorrection.UseVisualStyleBackColor = false;
            this.btCorrection.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(7, 187);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 30);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnrange
            // 
            this.btnrange.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnrange.ForeColor = System.Drawing.Color.White;
            this.btnrange.Location = new System.Drawing.Point(7, 33);
            this.btnrange.Name = "btnrange";
            this.btnrange.Size = new System.Drawing.Size(106, 30);
            this.btnrange.TabIndex = 45;
            this.btnrange.Text = "Start Ranger";
            this.btnrange.UseVisualStyleBackColor = false;
            this.btnrange.Click += new System.EventHandler(this.button1_Click);
            // 
            // axRanger1
            // 
            this.axRanger1.Enabled = true;
            this.axRanger1.Location = new System.Drawing.Point(115, 151);
            this.axRanger1.Name = "axRanger1";
            this.axRanger1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRanger1.OcxState")));
            this.axRanger1.Size = new System.Drawing.Size(96, 93);
            this.axRanger1.TabIndex = 44;
            this.axRanger1.TransportNewState += new AxRANGERLib._DRangerEvents_TransportNewStateEventHandler(this.axRanger1_TransportNewState);
            this.axRanger1.TransportChangeOptionsState += new AxRANGERLib._DRangerEvents_TransportChangeOptionsStateEventHandler(this.axRanger1_TransportChangeOptionsState);
            this.axRanger1.TransportFeedingStopped += new AxRANGERLib._DRangerEvents_TransportFeedingStoppedEventHandler(this.axRanger1_TransportFeedingStopped);
            this.axRanger1.TransportNewItem += new System.EventHandler(this.axRanger1_TransportNewItem);
            this.axRanger1.TransportSetItemOutput += new AxRANGERLib._DRangerEvents_TransportSetItemOutputEventHandler(this.axRanger1_TransportSetItemOutput);
            this.axRanger1.TransportItemInPocket += new AxRANGERLib._DRangerEvents_TransportItemInPocketEventHandler(this.axRanger1_TransportItemInPocket);
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnToggle.Enabled = false;
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.Location = new System.Drawing.Point(7, 115);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(106, 30);
            this.btnToggle.TabIndex = 35;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.ForeColor = System.Drawing.Color.Red;
            this.lblstatus.Location = new System.Drawing.Point(6, 8);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(91, 15);
            this.lblstatus.TabIndex = 5;
            this.lblstatus.Text = "Processing.........";
            this.lblstatus.Visible = false;
            // 
            // vtnexit
            // 
            this.vtnexit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.vtnexit.Enabled = false;
            this.vtnexit.ForeColor = System.Drawing.Color.White;
            this.vtnexit.Location = new System.Drawing.Point(7, 151);
            this.vtnexit.Name = "vtnexit";
            this.vtnexit.Size = new System.Drawing.Size(106, 30);
            this.vtnexit.TabIndex = 34;
            this.vtnexit.Text = "Save / Exit";
            this.vtnexit.UseVisualStyleBackColor = false;
            this.vtnexit.Click += new System.EventHandler(this.vtnexit_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnContinue.Enabled = false;
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(136, 79);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(67, 30);
            this.btnContinue.TabIndex = 33;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Visible = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnuvscan
            // 
            this.btnuvscan.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnuvscan.Enabled = false;
            this.btnuvscan.ForeColor = System.Drawing.Color.White;
            this.btnuvscan.Location = new System.Drawing.Point(136, 115);
            this.btnuvscan.Name = "btnuvscan";
            this.btnuvscan.Size = new System.Drawing.Size(71, 30);
            this.btnuvscan.TabIndex = 31;
            this.btnuvscan.Text = "UV Scan";
            this.btnuvscan.UseVisualStyleBackColor = false;
            this.btnuvscan.Visible = false;
            this.btnuvscan.Click += new System.EventHandler(this.btnuvscan_Click);
            // 
            // btnImgScan
            // 
            this.btnImgScan.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImgScan.Enabled = false;
            this.btnImgScan.ForeColor = System.Drawing.Color.White;
            this.btnImgScan.Location = new System.Drawing.Point(7, 73);
            this.btnImgScan.Name = "btnImgScan";
            this.btnImgScan.Size = new System.Drawing.Size(106, 30);
            this.btnImgScan.TabIndex = 30;
            this.btnImgScan.Text = "Image Scan";
            this.btnImgScan.UseVisualStyleBackColor = false;
            this.btnImgScan.Click += new System.EventHandler(this.btnImgScan_Click);
            // 
            // pictureScannedImageBack
            // 
            this.pictureScannedImageBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureScannedImageBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureScannedImageBack.Location = new System.Drawing.Point(0, 58);
            this.pictureScannedImageBack.Name = "pictureScannedImageBack";
            this.pictureScannedImageBack.Size = new System.Drawing.Size(1169, 319);
            this.pictureScannedImageBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureScannedImageBack.TabIndex = 29;
            this.pictureScannedImageBack.TabStop = false;
            // 
            // GrVwBatching
            // 
            this.GrVwBatching.AllowUserToAddRows = false;
            this.GrVwBatching.AllowUserToDeleteRows = false;
            this.GrVwBatching.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrVwBatching.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GrVwBatching.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batch_no,
            this.chk_count,
            this.batch_amount,
            this.depo_slip_no,
            this.cust_code,
            this.scan_Count,
            this.difference});
            this.GrVwBatching.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrVwBatching.Location = new System.Drawing.Point(0, 0);
            this.GrVwBatching.Name = "GrVwBatching";
            this.GrVwBatching.ReadOnly = true;
            this.GrVwBatching.Size = new System.Drawing.Size(1169, 57);
            this.GrVwBatching.TabIndex = 28;
            // 
            // batch_no
            // 
            this.batch_no.HeaderText = "Batch No.";
            this.batch_no.Name = "batch_no";
            this.batch_no.ReadOnly = true;
            // 
            // chk_count
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chk_count.DefaultCellStyle = dataGridViewCellStyle6;
            this.chk_count.HeaderText = "Chq Count";
            this.chk_count.Name = "chk_count";
            this.chk_count.ReadOnly = true;
            // 
            // batch_amount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.batch_amount.DefaultCellStyle = dataGridViewCellStyle7;
            this.batch_amount.HeaderText = "Batch Amount";
            this.batch_amount.Name = "batch_amount";
            this.batch_amount.ReadOnly = true;
            // 
            // depo_slip_no
            // 
            this.depo_slip_no.HeaderText = "Dep Slip No.";
            this.depo_slip_no.Name = "depo_slip_no";
            this.depo_slip_no.ReadOnly = true;
            // 
            // cust_code
            // 
            this.cust_code.HeaderText = "Cust Code/ Name";
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            // 
            // scan_Count
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.scan_Count.DefaultCellStyle = dataGridViewCellStyle8;
            this.scan_Count.HeaderText = "Scan Count";
            this.scan_Count.Name = "scan_Count";
            this.scan_Count.ReadOnly = true;
            // 
            // difference
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.difference.DefaultCellStyle = dataGridViewCellStyle9;
            this.difference.HeaderText = "Difference";
            this.difference.Name = "difference";
            this.difference.ReadOnly = true;
            // 
            // PicbxScannedFront
            // 
            this.PicbxScannedFront.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicbxScannedFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicbxScannedFront.ErrorImage = null;
            this.PicbxScannedFront.Location = new System.Drawing.Point(-3, 58);
            this.PicbxScannedFront.Name = "PicbxScannedFront";
            this.PicbxScannedFront.Size = new System.Drawing.Size(1169, 319);
            this.PicbxScannedFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicbxScannedFront.TabIndex = 33;
            this.PicbxScannedFront.TabStop = false;
            // 
            // PicLoad
            // 
            this.PicLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PicLoad.Image = ((System.Drawing.Image)(resources.GetObject("PicLoad.Image")));
            this.PicLoad.Location = new System.Drawing.Point(447, 227);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(167, 132);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 34;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // ScannerRangers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 699);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.PicbxScannedFront);
            this.Controls.Add(this.pictureScannedImageBack);
            this.Controls.Add(this.GrVwBatching);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ScannerRangers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ScannerRangers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScannerRangers_KeyDown);
            this.Resize += new System.EventHandler(this.ScannerRangers_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdScanning)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axRanger1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureScannedImageBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrVwBatching)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicbxScannedFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdScanning;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Button vtnexit;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnuvscan;
        private System.Windows.Forms.Button btnImgScan;
        private System.Windows.Forms.PictureBox pictureScannedImageBack;
        private System.Windows.Forms.DataGridView GrVwBatching;
        private AxRANGERLib.AxRanger axRanger1;
        private System.Windows.Forms.PictureBox PicbxScannedFront;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn depo_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn scan_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn difference;
        private System.Windows.Forms.Button btnrange;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tran_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn front_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn front_image_fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn back_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn back_image_fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn front_uv_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn front_uv_image_fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn front_grey;
        private System.Windows.Forms.DataGridViewTextBoxColumn front_gray_image_filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn back_grey;
        private System.Windows.Forms.DataGridViewTextBoxColumn back_grey_image_filename;
        private System.Windows.Forms.Button btCorrection;
    }
}