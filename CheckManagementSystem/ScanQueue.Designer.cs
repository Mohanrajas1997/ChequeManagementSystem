namespace CheckManagementSystem
{
    partial class ScanQueue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanQueue));
            this.gvscanlist = new System.Windows.Forms.DataGridView();
            this.Batch_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chq_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pickup_Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dep_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmb_chq_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.LotNo_Txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmblocation = new System.Windows.Forms.ComboBox();
            this.lblpickuplocation = new System.Windows.Forms.Label();
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
            this.Batch_Date,
            this.Batch_No,
            this.Chq_type,
            this.Pickup_Location,
            this.Dep_slip_no,
            this.Cheque_Count});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvscanlist.Location = new System.Drawing.Point(0, 81);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.ReadOnly = true;
            this.gvscanlist.Size = new System.Drawing.Size(1256, 445);
            this.gvscanlist.TabIndex = 1;
            this.gvscanlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellClick);
            this.gvscanlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellContentClick);
            this.gvscanlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvscanlist_KeyDown);
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
            // Chq_type
            // 
            this.Chq_type.HeaderText = "Cheque Type";
            this.Chq_type.Name = "Chq_type";
            this.Chq_type.ReadOnly = true;
            // 
            // Pickup_Location
            // 
            this.Pickup_Location.HeaderText = "Pickup Location";
            this.Pickup_Location.Name = "Pickup_Location";
            this.Pickup_Location.ReadOnly = true;
            // 
            // Dep_slip_no
            // 
            this.Dep_slip_no.HeaderText = "Deposit Slip No";
            this.Dep_slip_no.Name = "Dep_slip_no";
            this.Dep_slip_no.ReadOnly = true;
            // 
            // Cheque_Count
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cheque_Count.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cheque_Count.HeaderText = "Cheque Count";
            this.Cheque_Count.Name = "Cheque_Count";
            this.Cheque_Count.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.cmb_chq_type);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnref);
            this.panel1.Controls.Add(this.LotNo_Txt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmblocation);
            this.panel1.Controls.Add(this.lblpickuplocation);
            this.panel1.Controls.Add(this.Inward_Todate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Inward_Fromdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1256, 81);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(990, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmb_chq_type
            // 
            this.cmb_chq_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_chq_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_chq_type.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_chq_type.FormattingEnabled = true;
            this.cmb_chq_type.Location = new System.Drawing.Point(576, 10);
            this.cmb_chq_type.Name = "cmb_chq_type";
            this.cmb_chq_type.Size = new System.Drawing.Size(187, 21);
            this.cmb_chq_type.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(488, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cheque Type";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(906, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(822, 41);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 23);
            this.btnref.TabIndex = 5;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // LotNo_Txt
            // 
            this.LotNo_Txt.Location = new System.Drawing.Point(117, 41);
            this.LotNo_Txt.Name = "LotNo_Txt";
            this.LotNo_Txt.Size = new System.Drawing.Size(122, 21);
            this.LotNo_Txt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Batch No";
            // 
            // cmblocation
            // 
            this.cmblocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmblocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmblocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.FormattingEnabled = true;
            this.cmblocation.Location = new System.Drawing.Point(881, 9);
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.Size = new System.Drawing.Size(187, 21);
            this.cmblocation.TabIndex = 3;
            // 
            // lblpickuplocation
            // 
            this.lblpickuplocation.AutoSize = true;
            this.lblpickuplocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpickuplocation.Location = new System.Drawing.Point(766, 13);
            this.lblpickuplocation.Name = "lblpickuplocation";
            this.lblpickuplocation.Size = new System.Drawing.Size(96, 13);
            this.lblpickuplocation.TabIndex = 9;
            this.lblpickuplocation.Text = "PickUp Location";
            // 
            // Inward_Todate
            // 
            this.Inward_Todate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Todate.Location = new System.Drawing.Point(356, 9);
            this.Inward_Todate.Name = "Inward_Todate";
            this.Inward_Todate.ShowCheckBox = true;
            this.Inward_Todate.Size = new System.Drawing.Size(122, 21);
            this.Inward_Todate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scan To Date";
            // 
            // Inward_Fromdate
            // 
            this.Inward_Fromdate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Fromdate.Location = new System.Drawing.Point(117, 9);
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
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan From Date";
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
            this.PicLoad.Image = ((System.Drawing.Image)(resources.GetObject("PicLoad.Image")));
            this.PicLoad.Location = new System.Drawing.Point(514, 179);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(182, 114);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 39;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // ScanQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 526);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvscanlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblscnlst);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ScanQueue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maker Queue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanQueue_Load);
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
        private System.Windows.Forms.ComboBox cmblocation;
        private System.Windows.Forms.Label lblpickuplocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LotNo_Txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnref;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chq_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pickup_Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dep_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_Count;
        private System.Windows.Forms.ComboBox cmb_chq_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}