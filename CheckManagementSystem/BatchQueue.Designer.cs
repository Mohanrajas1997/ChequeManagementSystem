namespace CheckManagementSystem
{
    partial class BatchQueue
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
            this.Inward_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brn_code_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pickup_Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batched_Cheque_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InwardRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.LotNo_Txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmblocation = new System.Windows.Forms.ComboBox();
            this.lblpickuplocation = new System.Windows.Forms.Label();
            this.cmbbrcode = new System.Windows.Forms.ComboBox();
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
            this.Inward_Date,
            this.Lot_No,
            this.Brn_code_Name,
            this.Pickup_Location,
            this.chk_count,
            this.Batched_Cheque_Count,
            this.InwardRemarks});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvscanlist.Location = new System.Drawing.Point(0, 81);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.ReadOnly = true;
            this.gvscanlist.Size = new System.Drawing.Size(1209, 445);
            this.gvscanlist.TabIndex = 1;
            this.gvscanlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellClick);
            this.gvscanlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellContentClick);
            this.gvscanlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvscanlist_KeyDown);
            // 
            // Inward_Date
            // 
            this.Inward_Date.HeaderText = "Inward Date";
            this.Inward_Date.Name = "Inward_Date";
            this.Inward_Date.ReadOnly = true;
            // 
            // Lot_No
            // 
            this.Lot_No.HeaderText = "Lot No";
            this.Lot_No.Name = "Lot_No";
            this.Lot_No.ReadOnly = true;
            // 
            // Brn_code_Name
            // 
            this.Brn_code_Name.HeaderText = "Brn code /Name";
            this.Brn_code_Name.Name = "Brn_code_Name";
            this.Brn_code_Name.ReadOnly = true;
            // 
            // Pickup_Location
            // 
            this.Pickup_Location.HeaderText = "Pickup Location";
            this.Pickup_Location.Name = "Pickup_Location";
            this.Pickup_Location.ReadOnly = true;
            // 
            // chk_count
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chk_count.DefaultCellStyle = dataGridViewCellStyle1;
            this.chk_count.HeaderText = "Chq Count";
            this.chk_count.Name = "chk_count";
            this.chk_count.ReadOnly = true;
            // 
            // Batched_Cheque_Count
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Batched_Cheque_Count.DefaultCellStyle = dataGridViewCellStyle2;
            this.Batched_Cheque_Count.HeaderText = "Batched Cheque Count";
            this.Batched_Cheque_Count.Name = "Batched_Cheque_Count";
            this.Batched_Cheque_Count.ReadOnly = true;
            // 
            // InwardRemarks
            // 
            this.InwardRemarks.HeaderText = "Remarks";
            this.InwardRemarks.Name = "InwardRemarks";
            this.InwardRemarks.ReadOnly = true;
            this.InwardRemarks.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnref);
            this.panel1.Controls.Add(this.LotNo_Txt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmblocation);
            this.panel1.Controls.Add(this.lblpickuplocation);
            this.panel1.Controls.Add(this.cmbbrcode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Inward_Todate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Inward_Fromdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1209, 81);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1021, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(937, 41);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(853, 41);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 23);
            this.btnref.TabIndex = 5;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // LotNo_Txt
            // 
            this.LotNo_Txt.Location = new System.Drawing.Point(125, 41);
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
            this.cmblocation.Location = new System.Drawing.Point(912, 9);
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.Size = new System.Drawing.Size(187, 21);
            this.cmblocation.TabIndex = 3;
            // 
            // lblpickuplocation
            // 
            this.lblpickuplocation.AutoSize = true;
            this.lblpickuplocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpickuplocation.Location = new System.Drawing.Point(797, 13);
            this.lblpickuplocation.Name = "lblpickuplocation";
            this.lblpickuplocation.Size = new System.Drawing.Size(96, 13);
            this.lblpickuplocation.TabIndex = 9;
            this.lblpickuplocation.Text = "PickUp Location";
            // 
            // cmbbrcode
            // 
            this.cmbbrcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbbrcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbbrcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbrcode.FormattingEnabled = true;
            this.cmbbrcode.Location = new System.Drawing.Point(597, 9);
            this.cmbbrcode.Name = "cmbbrcode";
            this.cmbbrcode.Size = new System.Drawing.Size(187, 21);
            this.cmbbrcode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(510, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Branch Name";
            // 
            // Inward_Todate
            // 
            this.Inward_Todate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Todate.Location = new System.Drawing.Point(372, 9);
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
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inward To Date";
            // 
            // Inward_Fromdate
            // 
            this.Inward_Fromdate.CustomFormat = "dd-MM-yyyy";
            this.Inward_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Inward_Fromdate.Location = new System.Drawing.Point(125, 9);
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
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inward From Date";
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
            this.PicLoad.Location = new System.Drawing.Point(490, 179);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(182, 114);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 39;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // BatchQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 526);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvscanlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblscnlst);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BatchQueue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan Queue";
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
        private System.Windows.Forms.ComboBox cmbbrcode;
        private System.Windows.Forms.ComboBox cmblocation;
        private System.Windows.Forms.Label lblpickuplocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LotNo_Txt;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnref;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inward_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brn_code_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pickup_Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batched_Cheque_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn InwardRemarks;
        private System.Windows.Forms.Button btnClose;
    }
}