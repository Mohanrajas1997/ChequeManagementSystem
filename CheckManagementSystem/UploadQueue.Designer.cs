namespace CheckManagementSystem
{
    partial class UploadQueue
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
            this.gvscanlist = new System.Windows.Forms.DataGridView();
            this.Batch_Gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pickup_Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valid_Chq_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rejected_Chq_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Chq_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.RdoPending = new System.Windows.Forms.RadioButton();
            this.btnGen = new System.Windows.Forms.Button();
            this.RdoReUpload = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.cmblocation = new System.Windows.Forms.ComboBox();
            this.lblpickuplocation = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Inward_Todate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Inward_Fromdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblscnlst = new System.Windows.Forms.Label();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // gvscanlist
            // 
            this.gvscanlist.AllowUserToAddRows = false;
            this.gvscanlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvscanlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Batch_Gid,
            this.Batch_Date,
            this.Batch_no,
            this.Pickup_Location,
            this.Valid_Chq_Count,
            this.Rejected_Chq_Count,
            this.Total_Chq_Count,
            this.Column1});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvscanlist.Location = new System.Drawing.Point(0, 67);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.Size = new System.Drawing.Size(1158, 459);
            this.gvscanlist.TabIndex = 1;
            this.gvscanlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellClick);
            this.gvscanlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvscanlist_KeyDown);
            // 
            // Batch_Gid
            // 
            this.Batch_Gid.HeaderText = "Batch Gid";
            this.Batch_Gid.Name = "Batch_Gid";
            this.Batch_Gid.Visible = false;
            // 
            // Batch_Date
            // 
            this.Batch_Date.HeaderText = "Batch Date";
            this.Batch_Date.Name = "Batch_Date";
            // 
            // Batch_no
            // 
            this.Batch_no.HeaderText = "Batch No";
            this.Batch_no.Name = "Batch_no";
            // 
            // Pickup_Location
            // 
            this.Pickup_Location.HeaderText = "Deposit Slip No";
            this.Pickup_Location.Name = "Pickup_Location";
            // 
            // Valid_Chq_Count
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Valid_Chq_Count.DefaultCellStyle = dataGridViewCellStyle1;
            this.Valid_Chq_Count.HeaderText = "Valid Chq Count";
            this.Valid_Chq_Count.Name = "Valid_Chq_Count";
            // 
            // Rejected_Chq_Count
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Rejected_Chq_Count.DefaultCellStyle = dataGridViewCellStyle2;
            this.Rejected_Chq_Count.HeaderText = "Rejected Chq Count";
            this.Rejected_Chq_Count.Name = "Rejected_Chq_Count";
            // 
            // Total_Chq_Count
            // 
            this.Total_Chq_Count.HeaderText = "Total Chq Count";
            this.Total_Chq_Count.Name = "Total_Chq_Count";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Select";
            this.Column1.Name = "Column1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.RdoPending);
            this.panel1.Controls.Add(this.btnGen);
            this.panel1.Controls.Add(this.RdoReUpload);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnref);
            this.panel1.Controls.Add(this.cmblocation);
            this.panel1.Controls.Add(this.lblpickuplocation);
            this.panel1.Controls.Add(this.cmbtype);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Inward_Todate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Inward_Fromdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 67);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(841, 34);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RdoPending
            // 
            this.RdoPending.AutoSize = true;
            this.RdoPending.Checked = true;
            this.RdoPending.Location = new System.Drawing.Point(481, 11);
            this.RdoPending.Name = "RdoPending";
            this.RdoPending.Size = new System.Drawing.Size(70, 17);
            this.RdoPending.TabIndex = 2;
            this.RdoPending.TabStop = true;
            this.RdoPending.Text = "Pending";
            this.RdoPending.UseVisualStyleBackColor = true;
            this.RdoPending.CheckedChanged += new System.EventHandler(this.RdoPending_CheckedChanged);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(673, 5);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(246, 23);
            this.btnGen.TabIndex = 4;
            this.btnGen.Text = "Generate Upload";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // RdoReUpload
            // 
            this.RdoReUpload.AutoSize = true;
            this.RdoReUpload.Location = new System.Drawing.Point(576, 11);
            this.RdoReUpload.Name = "RdoReUpload";
            this.RdoReUpload.Size = new System.Drawing.Size(84, 17);
            this.RdoReUpload.TabIndex = 3;
            this.RdoReUpload.Text = "Re-Upload";
            this.RdoReUpload.UseVisualStyleBackColor = true;
            this.RdoReUpload.CheckedChanged += new System.EventHandler(this.RdoReUpload_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(757, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(673, 34);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 23);
            this.btnref.TabIndex = 7;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // cmblocation
            // 
            this.cmblocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmblocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmblocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.FormattingEnabled = true;
            this.cmblocation.Location = new System.Drawing.Point(343, 36);
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.Size = new System.Drawing.Size(317, 21);
            this.cmblocation.TabIndex = 6;
            // 
            // lblpickuplocation
            // 
            this.lblpickuplocation.AutoSize = true;
            this.lblpickuplocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpickuplocation.Location = new System.Drawing.Point(252, 40);
            this.lblpickuplocation.Name = "lblpickuplocation";
            this.lblpickuplocation.Size = new System.Drawing.Size(81, 13);
            this.lblpickuplocation.TabIndex = 9;
            this.lblpickuplocation.Text = "Branch Name";
            // 
            // cmbtype
            // 
            this.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbtype.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(112, 36);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(120, 21);
            this.cmbtype.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cheque Type";
            // 
            // Inward_Todate
            // 
            this.Inward_Todate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Todate.Location = new System.Drawing.Point(343, 9);
            this.Inward_Todate.Name = "Inward_Todate";
            this.Inward_Todate.ShowCheckBox = true;
            this.Inward_Todate.Size = new System.Drawing.Size(122, 21);
            this.Inward_Todate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch To Date";
            // 
            // Inward_Fromdate
            // 
            this.Inward_Fromdate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Fromdate.Location = new System.Drawing.Point(112, 9);
            this.Inward_Fromdate.Name = "Inward_Fromdate";
            this.Inward_Fromdate.ShowCheckBox = true;
            this.Inward_Fromdate.Size = new System.Drawing.Size(122, 21);
            this.Inward_Fromdate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batch From Date";
            // 
            // lblscnlst
            // 
            this.lblscnlst.AutoSize = true;
            this.lblscnlst.Location = new System.Drawing.Point(6, 1);
            this.lblscnlst.Name = "lblscnlst";
            this.lblscnlst.Size = new System.Drawing.Size(74, 13);
            this.lblscnlst.TabIndex = 13;
            this.lblscnlst.Text = "Scan Listing";
            // 
            // PicLoad
            // 
            this.PicLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PicLoad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PicLoad.Location = new System.Drawing.Point(465, 179);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(182, 114);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 39;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // UploadQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 526);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvscanlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblscnlst);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UploadQueue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Queue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BatchQueue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvscanlist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblscnlst;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.DateTimePicker Inward_Fromdate;
        private System.Windows.Forms.DateTimePicker Inward_Todate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.ComboBox cmblocation;
        private System.Windows.Forms.Label lblpickuplocation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnref;
        private System.Windows.Forms.RadioButton RdoReUpload;
        private System.Windows.Forms.RadioButton RdoPending;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Gid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pickup_Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valid_Chq_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rejected_Chq_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Chq_Count;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Button btnClose;
    }
}