namespace CheckManagementSystem
{
    partial class RejectionQueue
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
            this.gvscanlist = new System.Windows.Forms.DataGridView();
            this.Inward_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chq_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chq_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChqAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccHolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChqStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncls = new System.Windows.Forms.Button();
            this.rdoRevoke = new System.Windows.Forms.RadioButton();
            this.rdoRejection = new System.Windows.Forms.RadioButton();
            this.chqno_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.Batch_No,
            this.Chq_Type,
            this.Customer_Code,
            this.Customer_Name,
            this.Chq_Date,
            this.ChqNo,
            this.ChqAmount,
            this.AccNo,
            this.AccHolderName,
            this.ChqStatus});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvscanlist.Location = new System.Drawing.Point(0, 81);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.ReadOnly = true;
            this.gvscanlist.Size = new System.Drawing.Size(1250, 445);
            this.gvscanlist.TabIndex = 1;
            this.gvscanlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellClick);
            this.gvscanlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvscanlist_KeyDown);
            // 
            // Inward_Date
            // 
            this.Inward_Date.HeaderText = "Batch Date";
            this.Inward_Date.Name = "Inward_Date";
            this.Inward_Date.ReadOnly = true;
            // 
            // Batch_No
            // 
            this.Batch_No.HeaderText = "Batch No";
            this.Batch_No.Name = "Batch_No";
            this.Batch_No.ReadOnly = true;
            // 
            // Chq_Type
            // 
            this.Chq_Type.HeaderText = "Chq Type";
            this.Chq_Type.Name = "Chq_Type";
            this.Chq_Type.ReadOnly = true;
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
            // Chq_Date
            // 
            this.Chq_Date.HeaderText = "Chq Date";
            this.Chq_Date.Name = "Chq_Date";
            this.Chq_Date.ReadOnly = true;
            // 
            // ChqNo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ChqNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChqNo.HeaderText = "Chq No";
            this.ChqNo.Name = "ChqNo";
            this.ChqNo.ReadOnly = true;
            // 
            // ChqAmount
            // 
            this.ChqAmount.HeaderText = "Chq Amount";
            this.ChqAmount.Name = "ChqAmount";
            this.ChqAmount.ReadOnly = true;
            // 
            // AccNo
            // 
            this.AccNo.HeaderText = "Acc No";
            this.AccNo.Name = "AccNo";
            this.AccNo.ReadOnly = true;
            // 
            // AccHolderName
            // 
            this.AccHolderName.HeaderText = "Acc Holder Name";
            this.AccHolderName.Name = "AccHolderName";
            this.AccHolderName.ReadOnly = true;
            // 
            // ChqStatus
            // 
            this.ChqStatus.HeaderText = "Chq Status";
            this.ChqStatus.Name = "ChqStatus";
            this.ChqStatus.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btncls);
            this.panel1.Controls.Add(this.rdoRevoke);
            this.panel1.Controls.Add(this.rdoRejection);
            this.panel1.Controls.Add(this.chqno_txt);
            this.panel1.Controls.Add(this.label5);
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
            this.panel1.Size = new System.Drawing.Size(1250, 81);
            this.panel1.TabIndex = 0;
            // 
            // btncls
            // 
            this.btncls.Location = new System.Drawing.Point(1021, 45);
            this.btncls.Name = "btncls";
            this.btncls.Size = new System.Drawing.Size(78, 23);
            this.btncls.TabIndex = 10;
            this.btncls.Text = "Close";
            this.btncls.UseVisualStyleBackColor = true;
            this.btncls.Click += new System.EventHandler(this.btncls_Click);
            // 
            // rdoRevoke
            // 
            this.rdoRevoke.AutoSize = true;
            this.rdoRevoke.Location = new System.Drawing.Point(597, 49);
            this.rdoRevoke.Name = "rdoRevoke";
            this.rdoRevoke.Size = new System.Drawing.Size(68, 17);
            this.rdoRevoke.TabIndex = 7;
            this.rdoRevoke.TabStop = true;
            this.rdoRevoke.Text = "Revoke";
            this.rdoRevoke.UseVisualStyleBackColor = true;
            this.rdoRevoke.CheckedChanged += new System.EventHandler(this.rdoRevoke_CheckedChanged);
            // 
            // rdoRejection
            // 
            this.rdoRejection.AutoSize = true;
            this.rdoRejection.Checked = true;
            this.rdoRejection.Location = new System.Drawing.Point(510, 49);
            this.rdoRejection.Name = "rdoRejection";
            this.rdoRejection.Size = new System.Drawing.Size(79, 17);
            this.rdoRejection.TabIndex = 6;
            this.rdoRejection.TabStop = true;
            this.rdoRejection.Text = "Rejection";
            this.rdoRejection.UseVisualStyleBackColor = true;
            this.rdoRejection.CheckedChanged += new System.EventHandler(this.rdoRejection_CheckedChanged);
            // 
            // chqno_txt
            // 
            this.chqno_txt.Location = new System.Drawing.Point(372, 47);
            this.chqno_txt.Name = "chqno_txt";
            this.chqno_txt.Size = new System.Drawing.Size(122, 21);
            this.chqno_txt.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(261, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cheque No";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(937, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(853, 45);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 23);
            this.btnref.TabIndex = 8;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // LotNo_Txt
            // 
            this.LotNo_Txt.Location = new System.Drawing.Point(125, 47);
            this.LotNo_Txt.Name = "LotNo_Txt";
            this.LotNo_Txt.Size = new System.Drawing.Size(122, 21);
            this.LotNo_Txt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 51);
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
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch To Date";
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
            this.PicLoad.Location = new System.Drawing.Point(511, 179);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(182, 114);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 39;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // RejectionQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 526);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvscanlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblscnlst);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RejectionQueue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rejection Queue";
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
        private System.Windows.Forms.TextBox chqno_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inward_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chq_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chq_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChqAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccHolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChqStatus;
        private System.Windows.Forms.RadioButton rdoRejection;
        private System.Windows.Forms.RadioButton rdoRevoke;
        private System.Windows.Forms.Button btncls;
    }
}