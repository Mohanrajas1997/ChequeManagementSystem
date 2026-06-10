namespace CheckManagementSystem
{
    partial class Checker_Rpt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlupload = new System.Windows.Forms.Panel();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChyType = new System.Windows.Forms.ComboBox();
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
            this.Batch_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deposit_Slip_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account_Holder_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Micr_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tran_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chq_valid_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc_Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Micr_valid_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_Gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_Gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            this.pnlupload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvuploadgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlupload
            // 
            this.pnlupload.Controls.Add(this.cmbCustomerName);
            this.pnlupload.Controls.Add(this.label4);
            this.pnlupload.Controls.Add(this.cmbChyType);
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
            // cmbCustomerName
            // 
            this.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(845, 10);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(187, 21);
            this.cmbCustomerName.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(743, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Customer Name";
            // 
            // cmbChyType
            // 
            this.cmbChyType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbChyType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChyType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChyType.FormattingEnabled = true;
            this.cmbChyType.Location = new System.Drawing.Point(550, 9);
            this.cmbChyType.Name = "cmbChyType";
            this.cmbChyType.Size = new System.Drawing.Size(187, 21);
            this.cmbChyType.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Cheque Type";
            // 
            // Inward_to_Date
            // 
            this.Inward_to_Date.Checked = false;
            this.Inward_to_Date.CustomFormat = "dd-MM-yyyy";
            this.Inward_to_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_to_Date.Location = new System.Drawing.Point(328, 8);
            this.Inward_to_Date.Name = "Inward_to_Date";
            this.Inward_to_Date.ShowCheckBox = true;
            this.Inward_to_Date.Size = new System.Drawing.Size(122, 21);
            this.Inward_to_Date.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 12);
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
            this.Inward_Fromdate.Location = new System.Drawing.Point(140, 8);
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
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Batch From Date";
            // 
            // lstbtngen
            // 
            this.lstbtngen.Location = new System.Drawing.Point(870, 39);
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
            this.lblstatus.Location = new System.Drawing.Point(137, 44);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(80, 13);
            this.lblstatus.TabIndex = 10;
            this.lblstatus.Text = "Processing....";
            this.lblstatus.Visible = false;
            // 
            // btncls
            // 
            this.btncls.Location = new System.Drawing.Point(954, 39);
            this.btncls.Name = "btncls";
            this.btncls.Size = new System.Drawing.Size(78, 23);
            this.btncls.TabIndex = 9;
            this.btncls.Text = "Close";
            this.btncls.UseVisualStyleBackColor = true;
            this.btncls.Click += new System.EventHandler(this.btncls_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(786, 39);
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
            this.Batch_Date,
            this.Batch_No,
            this.Cheque_Type,
            this.Deposit_Slip_No,
            this.Customer_Code,
            this.Customer_Name,
            this.Cheque_Date,
            this.Cheque_No,
            this.Cheque_Amount,
            this.Account_No,
            this.Account_Holder_Name,
            this.Micr_Code,
            this.Tran_Code,
            this.Base_Code,
            this.Chq_valid_flag,
            this.Disc_Reason,
            this.Micr_valid_flag,
            this.Batch_Gid,
            this.Cheque_Gid});
            this.gvuploadgrid.Location = new System.Drawing.Point(0, 73);
            this.gvuploadgrid.Name = "gvuploadgrid";
            this.gvuploadgrid.ReadOnly = true;
            this.gvuploadgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvuploadgrid.Size = new System.Drawing.Size(1123, 458);
            this.gvuploadgrid.TabIndex = 1;
            // 
            // Batch_Date
            // 
            this.Batch_Date.HeaderText = "Batch Date";
            this.Batch_Date.Name = "Batch_Date";
            this.Batch_Date.ReadOnly = true;
            // 
            // Batch_No
            // 
            this.Batch_No.HeaderText = "Batch No";
            this.Batch_No.Name = "Batch_No";
            this.Batch_No.ReadOnly = true;
            // 
            // Cheque_Type
            // 
            this.Cheque_Type.HeaderText = "Cheque Type";
            this.Cheque_Type.Name = "Cheque_Type";
            this.Cheque_Type.ReadOnly = true;
            // 
            // Deposit_Slip_No
            // 
            this.Deposit_Slip_No.HeaderText = "Deposit Slip No";
            this.Deposit_Slip_No.Name = "Deposit_Slip_No";
            this.Deposit_Slip_No.ReadOnly = true;
            // 
            // Customer_Code
            // 
            this.Customer_Code.HeaderText = "Customer Code";
            this.Customer_Code.Name = "Customer_Code";
            this.Customer_Code.ReadOnly = true;
            // 
            // Customer_Name
            // 
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            // 
            // Cheque_Date
            // 
            this.Cheque_Date.HeaderText = "Cheque Date";
            this.Cheque_Date.Name = "Cheque_Date";
            this.Cheque_Date.ReadOnly = true;
            // 
            // Cheque_No
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cheque_No.DefaultCellStyle = dataGridViewCellStyle5;
            this.Cheque_No.HeaderText = "Cheque No";
            this.Cheque_No.Name = "Cheque_No";
            this.Cheque_No.ReadOnly = true;
            // 
            // Cheque_Amount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cheque_Amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.Cheque_Amount.HeaderText = "Cheque Amount";
            this.Cheque_Amount.Name = "Cheque_Amount";
            this.Cheque_Amount.ReadOnly = true;
            // 
            // Account_No
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Account_No.DefaultCellStyle = dataGridViewCellStyle7;
            this.Account_No.HeaderText = "Account No";
            this.Account_No.Name = "Account_No";
            this.Account_No.ReadOnly = true;
            // 
            // Account_Holder_Name
            // 
            this.Account_Holder_Name.HeaderText = "Account Holder Name";
            this.Account_Holder_Name.Name = "Account_Holder_Name";
            this.Account_Holder_Name.ReadOnly = true;
            // 
            // Micr_Code
            // 
            this.Micr_Code.HeaderText = "Micr Code";
            this.Micr_Code.Name = "Micr_Code";
            this.Micr_Code.ReadOnly = true;
            // 
            // Tran_Code
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tran_Code.DefaultCellStyle = dataGridViewCellStyle8;
            this.Tran_Code.HeaderText = "Tran_Code";
            this.Tran_Code.Name = "Tran_Code";
            this.Tran_Code.ReadOnly = true;
            // 
            // Base_Code
            // 
            this.Base_Code.HeaderText = "Base Code";
            this.Base_Code.Name = "Base_Code";
            this.Base_Code.ReadOnly = true;
            // 
            // Chq_valid_flag
            // 
            this.Chq_valid_flag.HeaderText = "Chq valid flag";
            this.Chq_valid_flag.Name = "Chq_valid_flag";
            this.Chq_valid_flag.ReadOnly = true;
            // 
            // Disc_Reason
            // 
            this.Disc_Reason.HeaderText = "Disc Reason";
            this.Disc_Reason.Name = "Disc_Reason";
            this.Disc_Reason.ReadOnly = true;
            // 
            // Micr_valid_flag
            // 
            this.Micr_valid_flag.HeaderText = "Micr valid flag";
            this.Micr_valid_flag.Name = "Micr_valid_flag";
            this.Micr_valid_flag.ReadOnly = true;
            // 
            // Batch_Gid
            // 
            this.Batch_Gid.HeaderText = "Batch Gid";
            this.Batch_Gid.Name = "Batch_Gid";
            this.Batch_Gid.ReadOnly = true;
            // 
            // Cheque_Gid
            // 
            this.Cheque_Gid.HeaderText = "Cheque Gid";
            this.Cheque_Gid.Name = "Cheque_Gid";
            this.Cheque_Gid.ReadOnly = true;
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
            // Checker_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 528);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvuploadgrid);
            this.Controls.Add(this.pnlupload);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "Checker_Rpt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checker Report";
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
        private System.Windows.Forms.ComboBox cmbChyType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposit_Slip_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account_Holder_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micr_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tran_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chq_valid_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc_Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micr_valid_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Gid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_Gid;
    }
}