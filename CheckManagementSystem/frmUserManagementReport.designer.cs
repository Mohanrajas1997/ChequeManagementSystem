namespace CheckManagementSystem
{
    partial class frmUserManagementReport
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
            this.pnlupload = new System.Windows.Forms.Panel();
            this.cmbRptType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Inward_to_Date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Inward_Fromdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lstbtngen = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.btncls = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.gvuploadgrid = new System.Windows.Forms.DataGridView();
            this.Login_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.System_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            this.pnlupload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvuploadgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlupload
            // 
            this.pnlupload.Controls.Add(this.cmbRptType);
            this.pnlupload.Controls.Add(this.label1);
            this.pnlupload.Controls.Add(this.Inward_to_Date);
            this.pnlupload.Controls.Add(this.label3);
            this.pnlupload.Controls.Add(this.Inward_Fromdate);
            this.pnlupload.Controls.Add(this.label2);
            this.pnlupload.Controls.Add(this.lstbtngen);
            this.pnlupload.Controls.Add(this.lblstatus);
            this.pnlupload.Controls.Add(this.btncls);
            this.pnlupload.Controls.Add(this.btnref);
            this.pnlupload.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlupload.Location = new System.Drawing.Point(0, 0);
            this.pnlupload.Name = "pnlupload";
            this.pnlupload.Size = new System.Drawing.Size(1123, 74);
            this.pnlupload.TabIndex = 0;
            // 
            // cmbRptType
            // 
            this.cmbRptType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRptType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRptType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRptType.FormattingEnabled = true;
            this.cmbRptType.Location = new System.Drawing.Point(504, 9);
            this.cmbRptType.Name = "cmbRptType";
            this.cmbRptType.Size = new System.Drawing.Size(187, 21);
            this.cmbRptType.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Report Type";
            // 
            // Inward_to_Date
            // 
            this.Inward_to_Date.Checked = false;
            this.Inward_to_Date.CustomFormat = "dd-MM-yyyy";
            this.Inward_to_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_to_Date.Location = new System.Drawing.Point(282, 8);
            this.Inward_to_Date.Name = "Inward_to_Date";
            this.Inward_to_Date.ShowCheckBox = true;
            this.Inward_to_Date.Size = new System.Drawing.Size(122, 21);
            this.Inward_to_Date.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "To Date";
            // 
            // Inward_Fromdate
            // 
            this.Inward_Fromdate.Checked = false;
            this.Inward_Fromdate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Fromdate.Location = new System.Drawing.Point(96, 8);
            this.Inward_Fromdate.Name = "Inward_Fromdate";
            this.Inward_Fromdate.ShowCheckBox = true;
            this.Inward_Fromdate.Size = new System.Drawing.Size(122, 21);
            this.Inward_Fromdate.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "From Date";
            // 
            // lstbtngen
            // 
            this.lstbtngen.Location = new System.Drawing.Point(533, 39);
            this.lstbtngen.Name = "lstbtngen";
            this.lstbtngen.Size = new System.Drawing.Size(78, 23);
            this.lstbtngen.TabIndex = 11;
            this.lstbtngen.Text = "Export";
            this.lstbtngen.UseVisualStyleBackColor = true;
            this.lstbtngen.Click += new System.EventHandler(this.lstbtngen_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblstatus.Location = new System.Drawing.Point(204, 44);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(80, 13);
            this.lblstatus.TabIndex = 10;
            this.lblstatus.Text = "Processing....";
            this.lblstatus.Visible = false;
            // 
            // btncls
            // 
            this.btncls.Location = new System.Drawing.Point(613, 39);
            this.btncls.Name = "btncls";
            this.btncls.Size = new System.Drawing.Size(78, 23);
            this.btncls.TabIndex = 9;
            this.btncls.Text = "Close";
            this.btncls.UseVisualStyleBackColor = true;
            this.btncls.Click += new System.EventHandler(this.btncls_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(451, 39);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 23);
            this.btnref.TabIndex = 7;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // gvuploadgrid
            // 
            this.gvuploadgrid.AllowUserToAddRows = false;
            this.gvuploadgrid.AllowUserToDeleteRows = false;
            this.gvuploadgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvuploadgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvuploadgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvuploadgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login_Date,
            this.User_Code,
            this.System_IP});
            this.gvuploadgrid.Location = new System.Drawing.Point(0, 73);
            this.gvuploadgrid.Name = "gvuploadgrid";
            this.gvuploadgrid.ReadOnly = true;
            this.gvuploadgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvuploadgrid.Size = new System.Drawing.Size(1123, 458);
            this.gvuploadgrid.TabIndex = 1;
            // 
            // Login_Date
            // 
            this.Login_Date.HeaderText = "Login Date";
            this.Login_Date.Name = "Login_Date";
            this.Login_Date.ReadOnly = true;
            // 
            // User_Code
            // 
            this.User_Code.HeaderText = "User Code";
            this.User_Code.Name = "User_Code";
            this.User_Code.ReadOnly = true;
            // 
            // System_IP
            // 
            this.System_IP.HeaderText = "System IP";
            this.System_IP.Name = "System_IP";
            this.System_IP.ReadOnly = true;
            // 
            // PicLoad
            // 
            this.PicLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PicLoad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PicLoad.Location = new System.Drawing.Point(478, 158);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(158, 105);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 35;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // frmUserManagementReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 528);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvuploadgrid);
            this.Controls.Add(this.pnlupload);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmUserManagementReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Log Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Upload_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Upload_KeyDown);
            this.pnlupload.ResumeLayout(false);
            this.pnlupload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvuploadgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlupload;
        private System.Windows.Forms.Button btncls;
        private System.Windows.Forms.Button btnref;
        private System.Windows.Forms.DataGridView gvuploadgrid;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.Button lstbtngen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Inward_Fromdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Inward_to_Date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRptType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn System_IP;
    }
}