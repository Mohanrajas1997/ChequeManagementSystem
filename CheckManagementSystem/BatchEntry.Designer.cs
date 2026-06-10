namespace CheckManagementSystem
{
    partial class BatchEntry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Location_Txt = new System.Windows.Forms.TextBox();
            this.BranchName_Txt = new System.Windows.Forms.TextBox();
            this.Remark_Txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chqcnt = new System.Windows.Forms.TextBox();
            this.lblbrcode = new System.Windows.Forms.Label();
            this.lblpickuplocation = new System.Windows.Forms.Label();
            this.lblcheckcount = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.Batch_panel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.txtRetypeAccNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCtsAccType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BatchAmt_Txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalChq_Txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cmb_CustomerName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Deposit_Txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cmb_ChqType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAddSubmit = new System.Windows.Forms.Panel();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.pnlUpdateSubmit = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.gvbatchlist = new System.Windows.Forms.DataGridView();
            this.Batch_Gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chq_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dep_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Batch_panel.SuspendLayout();
            this.pnlAddSubmit.SuspendLayout();
            this.pnlUpdateSubmit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvbatchlist)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Location_Txt);
            this.panel1.Controls.Add(this.BranchName_Txt);
            this.panel1.Controls.Add(this.Remark_Txt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chqcnt);
            this.panel1.Controls.Add(this.lblbrcode);
            this.panel1.Controls.Add(this.lblpickuplocation);
            this.panel1.Controls.Add(this.lblcheckcount);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lbldatetime);
            this.panel1.Location = new System.Drawing.Point(14, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 107);
            this.panel1.TabIndex = 1;
            // 
            // Location_Txt
            // 
            this.Location_Txt.Enabled = false;
            this.Location_Txt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location_Txt.Location = new System.Drawing.Point(115, 71);
            this.Location_Txt.MaxLength = 125;
            this.Location_Txt.Name = "Location_Txt";
            this.Location_Txt.Size = new System.Drawing.Size(449, 21);
            this.Location_Txt.TabIndex = 3;
            // 
            // BranchName_Txt
            // 
            this.BranchName_Txt.Enabled = false;
            this.BranchName_Txt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchName_Txt.Location = new System.Drawing.Point(115, 40);
            this.BranchName_Txt.MaxLength = 45;
            this.BranchName_Txt.Name = "BranchName_Txt";
            this.BranchName_Txt.Size = new System.Drawing.Size(449, 21);
            this.BranchName_Txt.TabIndex = 2;
            // 
            // Remark_Txt
            // 
            this.Remark_Txt.Enabled = false;
            this.Remark_Txt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remark_Txt.Location = new System.Drawing.Point(667, 8);
            this.Remark_Txt.MaxLength = 255;
            this.Remark_Txt.Multiline = true;
            this.Remark_Txt.Name = "Remark_Txt";
            this.Remark_Txt.Size = new System.Drawing.Size(422, 87);
            this.Remark_Txt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(570, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Inward Remark";
            // 
            // chqcnt
            // 
            this.chqcnt.Enabled = false;
            this.chqcnt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chqcnt.Location = new System.Drawing.Point(411, 10);
            this.chqcnt.MaxLength = 5;
            this.chqcnt.Name = "chqcnt";
            this.chqcnt.Size = new System.Drawing.Size(153, 21);
            this.chqcnt.TabIndex = 1;
            this.chqcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblbrcode
            // 
            this.lblbrcode.AutoSize = true;
            this.lblbrcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbrcode.Location = new System.Drawing.Point(13, 46);
            this.lblbrcode.Name = "lblbrcode";
            this.lblbrcode.Size = new System.Drawing.Size(81, 13);
            this.lblbrcode.TabIndex = 8;
            this.lblbrcode.Text = "Branch Name";
            // 
            // lblpickuplocation
            // 
            this.lblpickuplocation.AutoSize = true;
            this.lblpickuplocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpickuplocation.Location = new System.Drawing.Point(13, 75);
            this.lblpickuplocation.Name = "lblpickuplocation";
            this.lblpickuplocation.Size = new System.Drawing.Size(96, 13);
            this.lblpickuplocation.TabIndex = 7;
            this.lblpickuplocation.Text = "PickUp Location";
            // 
            // lblcheckcount
            // 
            this.lblcheckcount.AutoSize = true;
            this.lblcheckcount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcheckcount.Location = new System.Drawing.Point(291, 14);
            this.lblcheckcount.Name = "lblcheckcount";
            this.lblcheckcount.Size = new System.Drawing.Size(85, 13);
            this.lblcheckcount.TabIndex = 6;
            this.lblcheckcount.Text = "Cheque Count";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(115, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(153, 21);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatetime.Location = new System.Drawing.Point(13, 14);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(77, 13);
            this.lbldatetime.TabIndex = 0;
            this.lbldatetime.Text = "Inward Date";
            // 
            // Batch_panel
            // 
            this.Batch_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Batch_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Batch_panel.Controls.Add(this.label12);
            this.Batch_panel.Controls.Add(this.txtAccName);
            this.Batch_panel.Controls.Add(this.txtRetypeAccNo);
            this.Batch_panel.Controls.Add(this.label11);
            this.Batch_panel.Controls.Add(this.txtAccNo);
            this.Batch_panel.Controls.Add(this.label10);
            this.Batch_panel.Controls.Add(this.cmbCtsAccType);
            this.Batch_panel.Controls.Add(this.label9);
            this.Batch_panel.Controls.Add(this.BatchAmt_Txt);
            this.Batch_panel.Controls.Add(this.label6);
            this.Batch_panel.Controls.Add(this.TotalChq_Txt);
            this.Batch_panel.Controls.Add(this.label5);
            this.Batch_panel.Controls.Add(this.Cmb_CustomerName);
            this.Batch_panel.Controls.Add(this.label4);
            this.Batch_panel.Controls.Add(this.Deposit_Txt);
            this.Batch_panel.Controls.Add(this.label3);
            this.Batch_panel.Controls.Add(this.Cmb_ChqType);
            this.Batch_panel.Controls.Add(this.label2);
            this.Batch_panel.Controls.Add(this.pnlAddSubmit);
            this.Batch_panel.Controls.Add(this.pnlUpdateSubmit);
            this.Batch_panel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Batch_panel.Location = new System.Drawing.Point(14, 176);
            this.Batch_panel.Name = "Batch_panel";
            this.Batch_panel.Size = new System.Drawing.Size(1105, 137);
            this.Batch_panel.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(570, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Account Holder";
            // 
            // txtAccName
            // 
            this.txtAccName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAccName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccName.ForeColor = System.Drawing.Color.Red;
            this.txtAccName.Location = new System.Drawing.Point(667, 70);
            this.txtAccName.MaxLength = 0;
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.ReadOnly = true;
            this.txtAccName.Size = new System.Drawing.Size(422, 27);
            this.txtAccName.TabIndex = 8;
            this.txtAccName.TabStop = false;
            // 
            // txtRetypeAccNo
            // 
            this.txtRetypeAccNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetypeAccNo.Location = new System.Drawing.Point(411, 70);
            this.txtRetypeAccNo.MaxLength = 12;
            this.txtRetypeAccNo.Name = "txtRetypeAccNo";
            this.txtRetypeAccNo.Size = new System.Drawing.Size(153, 21);
            this.txtRetypeAccNo.TabIndex = 7;
            this.txtRetypeAccNo.Enter += new System.EventHandler(this.txtRetypeAccNo_Enter);
            this.txtRetypeAccNo.Leave += new System.EventHandler(this.txtRetypeAccNo_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(291, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Retype Account No";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccNo.Location = new System.Drawing.Point(115, 70);
            this.txtAccNo.MaxLength = 12;
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(153, 21);
            this.txtAccNo.TabIndex = 6;
            this.txtAccNo.TextChanged += new System.EventHandler(this.txtAccNo_TextChanged);
            this.txtAccNo.Enter += new System.EventHandler(this.txtAccNo_Enter);
            this.txtAccNo.Leave += new System.EventHandler(this.txtAccNo_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Account No";
            // 
            // cmbCtsAccType
            // 
            this.cmbCtsAccType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCtsAccType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCtsAccType.FormattingEnabled = true;
            this.cmbCtsAccType.Items.AddRange(new object[] {
            "SINGLE",
            "MULTIPLE"});
            this.cmbCtsAccType.Location = new System.Drawing.Point(115, 41);
            this.cmbCtsAccType.Name = "cmbCtsAccType";
            this.cmbCtsAccType.Size = new System.Drawing.Size(153, 21);
            this.cmbCtsAccType.TabIndex = 2;
            this.cmbCtsAccType.SelectedIndexChanged += new System.EventHandler(this.cmbCtsAccType_SelectedIndexChanged);
            this.cmbCtsAccType.Leave += new System.EventHandler(this.cmbCtsAccType_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "CTS A/C Type";
            // 
            // BatchAmt_Txt
            // 
            this.BatchAmt_Txt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchAmt_Txt.Location = new System.Drawing.Point(936, 41);
            this.BatchAmt_Txt.MaxLength = 15;
            this.BatchAmt_Txt.Name = "BatchAmt_Txt";
            this.BatchAmt_Txt.Size = new System.Drawing.Size(153, 21);
            this.BatchAmt_Txt.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(854, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Batch Amt";
            // 
            // TotalChq_Txt
            // 
            this.TotalChq_Txt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalChq_Txt.Location = new System.Drawing.Point(667, 41);
            this.TotalChq_Txt.MaxLength = 5;
            this.TotalChq_Txt.Name = "TotalChq_Txt";
            this.TotalChq_Txt.Size = new System.Drawing.Size(153, 21);
            this.TotalChq_Txt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(570, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cheque Count";
            // 
            // Cmb_CustomerName
            // 
            this.Cmb_CustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Cmb_CustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_CustomerName.FormattingEnabled = true;
            this.Cmb_CustomerName.Location = new System.Drawing.Point(411, 9);
            this.Cmb_CustomerName.Name = "Cmb_CustomerName";
            this.Cmb_CustomerName.Size = new System.Drawing.Size(678, 21);
            this.Cmb_CustomerName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(291, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Customer Name";
            // 
            // Deposit_Txt
            // 
            this.Deposit_Txt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deposit_Txt.Location = new System.Drawing.Point(411, 41);
            this.Deposit_Txt.MaxLength = 45;
            this.Deposit_Txt.Name = "Deposit_Txt";
            this.Deposit_Txt.Size = new System.Drawing.Size(153, 21);
            this.Deposit_Txt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Deposit Slip No";
            // 
            // Cmb_ChqType
            // 
            this.Cmb_ChqType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_ChqType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_ChqType.FormattingEnabled = true;
            this.Cmb_ChqType.Items.AddRange(new object[] {
            "CMS",
            "CTS"});
            this.Cmb_ChqType.Location = new System.Drawing.Point(115, 9);
            this.Cmb_ChqType.Name = "Cmb_ChqType";
            this.Cmb_ChqType.Size = new System.Drawing.Size(153, 21);
            this.Cmb_ChqType.TabIndex = 0;
            this.Cmb_ChqType.SelectedIndexChanged += new System.EventHandler(this.Cmb_ChqType_SelectedIndexChanged);
            this.Cmb_ChqType.Leave += new System.EventHandler(this.Cmb_ChqType_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cheque Type";
            // 
            // pnlAddSubmit
            // 
            this.pnlAddSubmit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddSubmit.Controls.Add(this.btncancel);
            this.pnlAddSubmit.Controls.Add(this.btnsave);
            this.pnlAddSubmit.Location = new System.Drawing.Point(897, 100);
            this.pnlAddSubmit.Name = "pnlAddSubmit";
            this.pnlAddSubmit.Size = new System.Drawing.Size(192, 32);
            this.pnlAddSubmit.TabIndex = 10;
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(98, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(87, 23);
            this.btncancel.TabIndex = 1;
            this.btncancel.Text = "&Close";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click_2);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(5, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(87, 23);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // pnlUpdateSubmit
            // 
            this.pnlUpdateSubmit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateSubmit.Controls.Add(this.btnUpdate);
            this.pnlUpdateSubmit.Controls.Add(this.btn_Close);
            this.pnlUpdateSubmit.Controls.Add(this.btn_delete);
            this.pnlUpdateSubmit.Location = new System.Drawing.Point(802, 100);
            this.pnlUpdateSubmit.Name = "pnlUpdateSubmit";
            this.pnlUpdateSubmit.Size = new System.Drawing.Size(287, 32);
            this.pnlUpdateSubmit.TabIndex = 9;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(5, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "&Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(192, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(87, 23);
            this.btn_Close.TabIndex = 9;
            this.btn_Close.Text = "&Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(98, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(87, 23);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "&Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // gvbatchlist
            // 
            this.gvbatchlist.AllowUserToAddRows = false;
            this.gvbatchlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvbatchlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Batch_Gid,
            this.Batch_No,
            this.chq_type,
            this.Dep_slip_no,
            this.Customer_name,
            this.chk_count,
            this.Batch_amount});
            this.gvbatchlist.Location = new System.Drawing.Point(12, 319);
            this.gvbatchlist.Name = "gvbatchlist";
            this.gvbatchlist.ReadOnly = true;
            this.gvbatchlist.Size = new System.Drawing.Size(1107, 204);
            this.gvbatchlist.TabIndex = 4;
            this.gvbatchlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvbatchlist_CellClick);
            // 
            // Batch_Gid
            // 
            this.Batch_Gid.HeaderText = "Batch Id";
            this.Batch_Gid.Name = "Batch_Gid";
            this.Batch_Gid.ReadOnly = true;
            this.Batch_Gid.Visible = false;
            // 
            // Batch_No
            // 
            this.Batch_No.HeaderText = "Batch No";
            this.Batch_No.Name = "Batch_No";
            this.Batch_No.ReadOnly = true;
            // 
            // chq_type
            // 
            this.chq_type.HeaderText = "Cheque Type";
            this.chq_type.Name = "chq_type";
            this.chq_type.ReadOnly = true;
            // 
            // Dep_slip_no
            // 
            this.Dep_slip_no.HeaderText = "Deposit Slip No";
            this.Dep_slip_no.Name = "Dep_slip_no";
            this.Dep_slip_no.ReadOnly = true;
            // 
            // Customer_name
            // 
            this.Customer_name.HeaderText = "Customer Name";
            this.Customer_name.Name = "Customer_name";
            this.Customer_name.ReadOnly = true;
            // 
            // chk_count
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chk_count.DefaultCellStyle = dataGridViewCellStyle1;
            this.chk_count.HeaderText = "Chq Count";
            this.chk_count.Name = "chk_count";
            this.chk_count.ReadOnly = true;
            // 
            // Batch_amount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Batch_amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Batch_amount.HeaderText = "Batch Amount";
            this.Batch_amount.Name = "Batch_amount";
            this.Batch_amount.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(10, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Inward Details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(14, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Batch Details";
            // 
            // BatchEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 530);
            this.Controls.Add(this.gvbatchlist);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Batch_panel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "BatchEntry";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Entry";
            this.Load += new System.EventHandler(this.BatchEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inward_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Batch_panel.ResumeLayout(false);
            this.Batch_panel.PerformLayout();
            this.pnlAddSubmit.ResumeLayout(false);
            this.pnlUpdateSubmit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvbatchlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblbrcode;
        private System.Windows.Forms.Label lblpickuplocation;
        private System.Windows.Forms.Label lblcheckcount;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.TextBox chqcnt;
        private System.Windows.Forms.TextBox Remark_Txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Location_Txt;
        private System.Windows.Forms.TextBox BranchName_Txt;
        private System.Windows.Forms.Panel Batch_panel;
        private System.Windows.Forms.ComboBox Cmb_ChqType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Deposit_Txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cmb_CustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotalChq_Txt;
        private System.Windows.Forms.TextBox BatchAmt_Txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gvbatchlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Gid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn chq_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dep_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_amount;
        private System.Windows.Forms.Panel pnlAddSubmit;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel pnlUpdateSubmit;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbCtsAccType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRetypeAccNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAccNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAccName;
    }
}