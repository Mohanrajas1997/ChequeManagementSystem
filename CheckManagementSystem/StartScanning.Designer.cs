namespace CheckManagementSystem
{
    partial class StartScanning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScanning));
            this.GrVwBatching = new System.Windows.Forms.DataGridView();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depo_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scan_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureScannedImageBack = new System.Windows.Forms.PictureBox();
            this.PicbxScannedFront = new System.Windows.Forms.PictureBox();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefersh = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.vtnexit = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnuvscan = new System.Windows.Forms.Button();
            this.btnImgScan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdScanning = new System.Windows.Forms.DataGridView();
            this.serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tran_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image_files = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrVwBatching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureScannedImageBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicbxScannedFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScanning)).BeginInit();
            this.SuspendLayout();
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
            this.GrVwBatching.Size = new System.Drawing.Size(1169, 53);
            this.GrVwBatching.TabIndex = 2;
            // 
            // batch_no
            // 
            this.batch_no.HeaderText = "Batch No.";
            this.batch_no.Name = "batch_no";
            this.batch_no.ReadOnly = true;
            // 
            // chk_count
            // 
            this.chk_count.HeaderText = "Chq Count";
            this.chk_count.Name = "chk_count";
            this.chk_count.ReadOnly = true;
            // 
            // batch_amount
            // 
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
            this.scan_Count.HeaderText = "Scan Count";
            this.scan_Count.Name = "scan_Count";
            this.scan_Count.ReadOnly = true;
            // 
            // difference
            // 
            this.difference.HeaderText = "Difference";
            this.difference.Name = "difference";
            this.difference.ReadOnly = true;
            // 
            // pictureScannedImageBack
            // 
            this.pictureScannedImageBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureScannedImageBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureScannedImageBack.Location = new System.Drawing.Point(2, 53);
            this.pictureScannedImageBack.Name = "pictureScannedImageBack";
            this.pictureScannedImageBack.Size = new System.Drawing.Size(1165, 408);
            this.pictureScannedImageBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureScannedImageBack.TabIndex = 9;
            this.pictureScannedImageBack.TabStop = false;
            // 
            // PicbxScannedFront
            // 
            this.PicbxScannedFront.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicbxScannedFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicbxScannedFront.ErrorImage = null;
            this.PicbxScannedFront.Location = new System.Drawing.Point(2, 53);
            this.PicbxScannedFront.Name = "PicbxScannedFront";
            this.PicbxScannedFront.Size = new System.Drawing.Size(1165, 408);
            this.PicbxScannedFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicbxScannedFront.TabIndex = 10;
            this.PicbxScannedFront.TabStop = false;
            // 
            // PicLoad
            // 
            this.PicLoad.Image = ((System.Drawing.Image)(resources.GetObject("PicLoad.Image")));
            this.PicLoad.Location = new System.Drawing.Point(514, 211);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(100, 66);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 25;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRefersh);
            this.panel3.Controls.Add(this.btnToggle);
            this.panel3.Controls.Add(this.lblstatus);
            this.panel3.Controls.Add(this.vtnexit);
            this.panel3.Controls.Add(this.btnContinue);
            this.panel3.Controls.Add(this.btnuvscan);
            this.panel3.Controls.Add(this.btnImgScan);
            this.panel3.Location = new System.Drawing.Point(1003, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel3.Size = new System.Drawing.Size(166, 246);
            this.panel3.TabIndex = 28;
            // 
            // btnRefersh
            // 
            this.btnRefersh.Location = new System.Drawing.Point(7, 86);
            this.btnRefersh.Name = "btnRefersh";
            this.btnRefersh.Size = new System.Drawing.Size(124, 28);
            this.btnRefersh.TabIndex = 36;
            this.btnRefersh.Text = "Referesh";
            this.btnRefersh.UseVisualStyleBackColor = true;
            this.btnRefersh.Click += new System.EventHandler(this.btnRefersh_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(7, 194);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(124, 26);
            this.btnToggle.TabIndex = 35;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblstatus.Location = new System.Drawing.Point(4, 0);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(94, 15);
            this.lblstatus.TabIndex = 5;
            this.lblstatus.Text = "Processing.........";
            this.lblstatus.Visible = false;
            // 
            // vtnexit
            // 
            this.vtnexit.Location = new System.Drawing.Point(7, 160);
            this.vtnexit.Name = "vtnexit";
            this.vtnexit.Size = new System.Drawing.Size(126, 28);
            this.vtnexit.TabIndex = 34;
            this.vtnexit.Text = "Save / Exit";
            this.vtnexit.UseVisualStyleBackColor = true;
            this.vtnexit.Click += new System.EventHandler(this.vtnexit_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(7, 126);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(124, 28);
            this.btnContinue.TabIndex = 33;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnuvscan
            // 
            this.btnuvscan.Enabled = false;
            this.btnuvscan.Location = new System.Drawing.Point(7, 52);
            this.btnuvscan.Name = "btnuvscan";
            this.btnuvscan.Size = new System.Drawing.Size(124, 28);
            this.btnuvscan.TabIndex = 31;
            this.btnuvscan.Text = "UV Scan";
            this.btnuvscan.UseVisualStyleBackColor = true;
            // 
            // btnImgScan
            // 
            this.btnImgScan.Location = new System.Drawing.Point(5, 18);
            this.btnImgScan.Name = "btnImgScan";
            this.btnImgScan.Size = new System.Drawing.Size(128, 28);
            this.btnImgScan.TabIndex = 30;
            this.btnImgScan.Text = "Image Scan";
            this.btnImgScan.UseVisualStyleBackColor = true;
            this.btnImgScan.Click += new System.EventHandler(this.btnImgScan_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdScanning);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 467);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1169, 252);
            this.panel2.TabIndex = 27;
            // 
            // grdScanning
            // 
            this.grdScanning.AllowUserToAddRows = false;
            this.grdScanning.AllowUserToDeleteRows = false;
            this.grdScanning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdScanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdScanning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial_no,
            this.check_no,
            this.sort_codes,
            this.base_codes,
            this.tran_codes,
            this.image_files});
            this.grdScanning.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdScanning.Location = new System.Drawing.Point(0, 0);
            this.grdScanning.MultiSelect = false;
            this.grdScanning.Name = "grdScanning";
            this.grdScanning.Size = new System.Drawing.Size(999, 252);
            this.grdScanning.TabIndex = 29;
            this.grdScanning.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdScanning_CellEndEdit);
            this.grdScanning.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdScanning_EditingControlShowing);
            this.grdScanning.SelectionChanged += new System.EventHandler(this.grdScanning_SelectionChanged);
            this.grdScanning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdScanning_KeyDown);
            // 
            // serial_no
            // 
            this.serial_no.HeaderText = "Serial No";
            this.serial_no.Name = "serial_no";
            this.serial_no.ReadOnly = true;
            // 
            // check_no
            // 
            this.check_no.HeaderText = "Cheque No";
            this.check_no.Name = "check_no";
            // 
            // sort_codes
            // 
            this.sort_codes.HeaderText = "Sort Code";
            this.sort_codes.Name = "sort_codes";
            // 
            // base_codes
            // 
            this.base_codes.HeaderText = "Base Code";
            this.base_codes.Name = "base_codes";
            // 
            // tran_codes
            // 
            this.tran_codes.HeaderText = "Tran Code";
            this.tran_codes.Name = "tran_codes";
            // 
            // image_files
            // 
            this.image_files.HeaderText = "Image Files";
            this.image_files.Name = "image_files";
            this.image_files.Visible = false;
            // 
            // StartScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 719);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.PicbxScannedFront);
            this.Controls.Add(this.pictureScannedImageBack);
            this.Controls.Add(this.GrVwBatching);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StartScanning";
            this.Text = "StartScanning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StartScanning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrVwBatching)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureScannedImageBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicbxScannedFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScanning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GrVwBatching;
        private System.Windows.Forms.PictureBox pictureScannedImageBack;
        private System.Windows.Forms.PictureBox PicbxScannedFront;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn depo_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn scan_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn difference;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button vtnexit;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnuvscan;
        private System.Windows.Forms.Button btnImgScan;
        private System.Windows.Forms.DataGridView grdScanning;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tran_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn image_files;
        private System.Windows.Forms.Button btnRefersh;
    }
}