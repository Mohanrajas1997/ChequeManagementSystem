namespace CheckManagementSystem
{
    partial class MicrMaster_Rpt
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
            this.BranchName_Txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BankName_Txt = new System.Windows.Forms.TextBox();
            this.MicrCode_Txt = new System.Windows.Forms.TextBox();
            this.lstbtngen = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.btncls = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.lbluptype = new System.Windows.Forms.Label();
            this.lbltype = new System.Windows.Forms.Label();
            this.gvuploadgrid = new System.Windows.Forms.DataGridView();
            this.micr_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            this.Cmb_ChqType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlupload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvuploadgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlupload
            // 
            this.pnlupload.Controls.Add(this.Cmb_ChqType);
            this.pnlupload.Controls.Add(this.label2);
            this.pnlupload.Controls.Add(this.BranchName_Txt);
            this.pnlupload.Controls.Add(this.label1);
            this.pnlupload.Controls.Add(this.BankName_Txt);
            this.pnlupload.Controls.Add(this.MicrCode_Txt);
            this.pnlupload.Controls.Add(this.lstbtngen);
            this.pnlupload.Controls.Add(this.lblstatus);
            this.pnlupload.Controls.Add(this.btncls);
            this.pnlupload.Controls.Add(this.btnref);
            this.pnlupload.Controls.Add(this.lbluptype);
            this.pnlupload.Controls.Add(this.lbltype);
            this.pnlupload.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlupload.Location = new System.Drawing.Point(0, 0);
            this.pnlupload.Name = "pnlupload";
            this.pnlupload.Size = new System.Drawing.Size(1327, 74);
            this.pnlupload.TabIndex = 0;
            // 
            // BranchName_Txt
            // 
            this.BranchName_Txt.Location = new System.Drawing.Point(578, 12);
            this.BranchName_Txt.Name = "BranchName_Txt";
            this.BranchName_Txt.Size = new System.Drawing.Size(160, 21);
            this.BranchName_Txt.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Branch Name";
            // 
            // BankName_Txt
            // 
            this.BankName_Txt.Location = new System.Drawing.Point(321, 12);
            this.BankName_Txt.Name = "BankName_Txt";
            this.BankName_Txt.Size = new System.Drawing.Size(160, 21);
            this.BankName_Txt.TabIndex = 13;
            // 
            // MicrCode_Txt
            // 
            this.MicrCode_Txt.Location = new System.Drawing.Point(80, 12);
            this.MicrCode_Txt.Name = "MicrCode_Txt";
            this.MicrCode_Txt.Size = new System.Drawing.Size(160, 21);
            this.MicrCode_Txt.TabIndex = 12;
            // 
            // lstbtngen
            // 
            this.lstbtngen.Location = new System.Drawing.Point(1022, 12);
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
            this.lblstatus.Location = new System.Drawing.Point(1190, 15);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(80, 13);
            this.lblstatus.TabIndex = 10;
            this.lblstatus.Text = "Processing....";
            this.lblstatus.Visible = false;
            // 
            // btncls
            // 
            this.btncls.Location = new System.Drawing.Point(1106, 12);
            this.btncls.Name = "btncls";
            this.btncls.Size = new System.Drawing.Size(78, 23);
            this.btncls.TabIndex = 9;
            this.btncls.Text = "Close";
            this.btncls.UseVisualStyleBackColor = true;
            this.btncls.Click += new System.EventHandler(this.btncls_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(938, 12);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 23);
            this.btnref.TabIndex = 7;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // lbluptype
            // 
            this.lbluptype.AutoSize = true;
            this.lbluptype.Location = new System.Drawing.Point(245, 16);
            this.lbluptype.Name = "lbluptype";
            this.lbluptype.Size = new System.Drawing.Size(70, 13);
            this.lbluptype.TabIndex = 3;
            this.lbluptype.Text = "Bank Name";
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Location = new System.Drawing.Point(12, 15);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(62, 13);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "Micr Code";
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
            this.micr_code,
            this.bank_name,
            this.Branch_Name,
            this.gid});
            this.gvuploadgrid.Location = new System.Drawing.Point(0, 39);
            this.gvuploadgrid.Name = "gvuploadgrid";
            this.gvuploadgrid.ReadOnly = true;
            this.gvuploadgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvuploadgrid.Size = new System.Drawing.Size(1327, 492);
            this.gvuploadgrid.TabIndex = 1;
            this.gvuploadgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvuploadgrid_CellClick);
            this.gvuploadgrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvuploadgrid_KeyDown);
            // 
            // micr_code
            // 
            this.micr_code.HeaderText = "Micr Code";
            this.micr_code.Name = "micr_code";
            this.micr_code.ReadOnly = true;
            // 
            // bank_name
            // 
            this.bank_name.HeaderText = "Bank Name";
            this.bank_name.Name = "bank_name";
            this.bank_name.ReadOnly = true;
            // 
            // Branch_Name
            // 
            this.Branch_Name.HeaderText = "Branch Name";
            this.Branch_Name.Name = "Branch_Name";
            this.Branch_Name.ReadOnly = true;
            // 
            // gid
            // 
            this.gid.HeaderText = "Id";
            this.gid.Name = "gid";
            this.gid.ReadOnly = true;
            // 
            // PicLoad
            // 
            this.PicLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PicLoad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PicLoad.Location = new System.Drawing.Point(580, 158);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(158, 105);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 35;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // Cmb_ChqType
            // 
            this.Cmb_ChqType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_ChqType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_ChqType.FormattingEnabled = true;
            this.Cmb_ChqType.Items.AddRange(new object[] {
            "CMS",
            "CTS"});
            this.Cmb_ChqType.Location = new System.Drawing.Point(833, 12);
            this.Cmb_ChqType.Name = "Cmb_ChqType";
            this.Cmb_ChqType.Size = new System.Drawing.Size(100, 21);
            this.Cmb_ChqType.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(747, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cheque Type";
            // 
            // MicrMaster_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 528);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvuploadgrid);
            this.Controls.Add(this.pnlupload);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "MicrMaster_Rpt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Micr Master Report";
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
        private System.Windows.Forms.Label lbluptype;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.DataGridView gvuploadgrid;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.Button lstbtngen;
        private System.Windows.Forms.TextBox BankName_Txt;
        private System.Windows.Forms.TextBox MicrCode_Txt;
        private System.Windows.Forms.TextBox BranchName_Txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn micr_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gid;
        private System.Windows.Forms.ComboBox Cmb_ChqType;
        private System.Windows.Forms.Label label2;
    }
}