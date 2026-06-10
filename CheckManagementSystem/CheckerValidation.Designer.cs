namespace CheckManagementSystem
{
    partial class CheckerValidation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckerValidation));
            this.gvscanlist = new System.Windows.Forms.DataGridView();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depo_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scan_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_entered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.differecne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicFrontSide = new System.Windows.Forms.PictureBox();
            this.pnlinfo = new System.Windows.Forms.Panel();
            this.btn_persist = new System.Windows.Forms.Button();
            this.txtaccname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Refersh = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbldate = new System.Windows.Forms.Label();
            this.txtchequeamt = new System.Windows.Forms.TextBox();
            this.chqdtpicker = new System.Windows.Forms.TextBox();
            this.cmbodraweename = new System.Windows.Forms.ComboBox();
            this.txtaccno = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btntogg = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtchqamt = new System.Windows.Forms.TextBox();
            this.lbldrwname = new System.Windows.Forms.Label();
            this.lblaccno = new System.Windows.Forms.Label();
            this.lblchqamt = new System.Windows.Forms.Label();
            this.lblchqdate = new System.Windows.Forms.Label();
            this.GrdScannedList = new System.Windows.Forms.DataGridView();
            this.PicBackSide = new System.Windows.Forms.PictureBox();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFrontSide)).BeginInit();
            this.pnlinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdScannedList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBackSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // gvscanlist
            // 
            this.gvscanlist.AllowUserToAddRows = false;
            this.gvscanlist.AllowUserToDeleteRows = false;
            this.gvscanlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvscanlist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gvscanlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batch_no,
            this.chk_count,
            this.batch_amount,
            this.depo_slip_no,
            this.cust_code,
            this.scan_count,
            this.amount_entered,
            this.differecne});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvscanlist.Location = new System.Drawing.Point(0, 0);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.ReadOnly = true;
            this.gvscanlist.Size = new System.Drawing.Size(1190, 48);
            this.gvscanlist.TabIndex = 3;
            // 
            // batch_no
            // 
            this.batch_no.HeaderText = "Batch No.";
            this.batch_no.Name = "batch_no";
            this.batch_no.ReadOnly = true;
            // 
            // chk_count
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chk_count.DefaultCellStyle = dataGridViewCellStyle26;
            this.chk_count.HeaderText = "Chq Count";
            this.chk_count.Name = "chk_count";
            this.chk_count.ReadOnly = true;
            // 
            // batch_amount
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.batch_amount.DefaultCellStyle = dataGridViewCellStyle27;
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
            // scan_count
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.scan_count.DefaultCellStyle = dataGridViewCellStyle28;
            this.scan_count.HeaderText = "Scan Count";
            this.scan_count.Name = "scan_count";
            this.scan_count.ReadOnly = true;
            // 
            // amount_entered
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount_entered.DefaultCellStyle = dataGridViewCellStyle29;
            this.amount_entered.HeaderText = "Amount Entered";
            this.amount_entered.Name = "amount_entered";
            this.amount_entered.ReadOnly = true;
            // 
            // differecne
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.differecne.DefaultCellStyle = dataGridViewCellStyle30;
            this.differecne.HeaderText = "Difference";
            this.differecne.Name = "differecne";
            this.differecne.ReadOnly = true;
            // 
            // PicFrontSide
            // 
            this.PicFrontSide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicFrontSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicFrontSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicFrontSide.ErrorImage = null;
            this.PicFrontSide.Location = new System.Drawing.Point(0, 59);
            this.PicFrontSide.Name = "PicFrontSide";
            this.PicFrontSide.Size = new System.Drawing.Size(912, 276);
            this.PicFrontSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicFrontSide.TabIndex = 11;
            this.PicFrontSide.TabStop = false;
            // 
            // pnlinfo
            // 
            this.pnlinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlinfo.Controls.Add(this.btn_persist);
            this.pnlinfo.Controls.Add(this.txtaccname);
            this.pnlinfo.Controls.Add(this.panel1);
            this.pnlinfo.Controls.Add(this.btn_Refersh);
            this.pnlinfo.Controls.Add(this.btnReview);
            this.pnlinfo.Controls.Add(this.btnUpdate);
            this.pnlinfo.Controls.Add(this.lbldate);
            this.pnlinfo.Controls.Add(this.txtchequeamt);
            this.pnlinfo.Controls.Add(this.chqdtpicker);
            this.pnlinfo.Controls.Add(this.cmbodraweename);
            this.pnlinfo.Controls.Add(this.txtaccno);
            this.pnlinfo.Controls.Add(this.btnCancel);
            this.pnlinfo.Controls.Add(this.btntogg);
            this.pnlinfo.Controls.Add(this.btnSave);
            this.pnlinfo.Controls.Add(this.txtchqamt);
            this.pnlinfo.Controls.Add(this.lbldrwname);
            this.pnlinfo.Controls.Add(this.lblaccno);
            this.pnlinfo.Controls.Add(this.lblchqamt);
            this.pnlinfo.Controls.Add(this.lblchqdate);
            this.pnlinfo.Location = new System.Drawing.Point(920, 58);
            this.pnlinfo.Name = "pnlinfo";
            this.pnlinfo.Size = new System.Drawing.Size(272, 284);
            this.pnlinfo.TabIndex = 12;
            // 
            // btn_persist
            // 
            this.btn_persist.Location = new System.Drawing.Point(114, 150);
            this.btn_persist.Name = "btn_persist";
            this.btn_persist.Size = new System.Drawing.Size(82, 28);
            this.btn_persist.TabIndex = 26;
            this.btn_persist.Text = "Persist";
            this.btn_persist.UseVisualStyleBackColor = true;
            this.btn_persist.Click += new System.EventHandler(this.btn_persist_Click);
            // 
            // txtaccname
            // 
            this.txtaccname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtaccname.Location = new System.Drawing.Point(120, 116);
            this.txtaccname.Name = "txtaccname";
            this.txtaccname.Size = new System.Drawing.Size(131, 22);
            this.txtaccname.TabIndex = 19;
            this.txtaccname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccname_KeyPress);
            this.txtaccname.Leave += new System.EventHandler(this.txtaccname_Leave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(5, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 20);
            this.panel1.TabIndex = 18;
            this.panel1.Visible = false;
            // 
            // btn_Refersh
            // 
            this.btn_Refersh.Location = new System.Drawing.Point(215, 213);
            this.btn_Refersh.Name = "btn_Refersh";
            this.btn_Refersh.Size = new System.Drawing.Size(49, 28);
            this.btn_Refersh.TabIndex = 24;
            this.btn_Refersh.Text = "Refersh";
            this.btn_Refersh.UseVisualStyleBackColor = true;
            this.btn_Refersh.Visible = false;
            this.btn_Refersh.Click += new System.EventHandler(this.btn_Refersh_Click);
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(215, 144);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(55, 28);
            this.btnReview.TabIndex = 25;
            this.btnReview.Text = "Review";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Visible = false;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(114, 214);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 28);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(124, 1);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(55, 14);
            this.lbldate.TabIndex = 5;
            this.lbldate.Text = "DDMMYY";
            // 
            // txtchequeamt
            // 
            this.txtchequeamt.Location = new System.Drawing.Point(114, 185);
            this.txtchequeamt.Name = "txtchequeamt";
            this.txtchequeamt.Size = new System.Drawing.Size(131, 22);
            this.txtchequeamt.TabIndex = 22;
            this.txtchequeamt.Visible = false;
            // 
            // chqdtpicker
            // 
            this.chqdtpicker.Location = new System.Drawing.Point(120, 22);
            this.chqdtpicker.MaxLength = 6;
            this.chqdtpicker.Name = "chqdtpicker";
            this.chqdtpicker.Size = new System.Drawing.Size(131, 22);
            this.chqdtpicker.TabIndex = 0;
            this.chqdtpicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chqdtpicker_KeyPress);
            this.chqdtpicker.Leave += new System.EventHandler(this.chqdtpicker_Leave);
            this.chqdtpicker.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // cmbodraweename
            // 
            this.cmbodraweename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbodraweename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbodraweename.FormattingEnabled = true;
            this.cmbodraweename.Location = new System.Drawing.Point(119, 116);
            this.cmbodraweename.Name = "cmbodraweename";
            this.cmbodraweename.Size = new System.Drawing.Size(131, 22);
            this.cmbodraweename.TabIndex = 3;
            this.cmbodraweename.Visible = false;
            // 
            // txtaccno
            // 
            this.txtaccno.Location = new System.Drawing.Point(120, 85);
            this.txtaccno.Name = "txtaccno";
            this.txtaccno.Size = new System.Drawing.Size(131, 22);
            this.txtaccno.TabIndex = 2;
            this.txtaccno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtaccno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccno_KeyPress);
            this.txtaccno.Leave += new System.EventHandler(this.txtaccno_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(17, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 28);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btntogg
            // 
            this.btntogg.Location = new System.Drawing.Point(16, 150);
            this.btntogg.Name = "btntogg";
            this.btntogg.Size = new System.Drawing.Size(82, 28);
            this.btntogg.TabIndex = 19;
            this.btntogg.Text = "Toggle";
            this.btntogg.UseVisualStyleBackColor = true;
            this.btntogg.Click += new System.EventHandler(this.btntogg_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtchqamt
            // 
            this.txtchqamt.Location = new System.Drawing.Point(120, 54);
            this.txtchqamt.Name = "txtchqamt";
            this.txtchqamt.Size = new System.Drawing.Size(131, 22);
            this.txtchqamt.TabIndex = 1;
            this.txtchqamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtchqamt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtchqamt_KeyPress);
            this.txtchqamt.Leave += new System.EventHandler(this.txtchqamt_Leave);
            // 
            // lbldrwname
            // 
            this.lbldrwname.AutoSize = true;
            this.lbldrwname.Location = new System.Drawing.Point(8, 119);
            this.lbldrwname.Name = "lbldrwname";
            this.lbldrwname.Size = new System.Drawing.Size(84, 14);
            this.lbldrwname.TabIndex = 3;
            this.lbldrwname.Text = "Drawee Name";
            // 
            // lblaccno
            // 
            this.lblaccno.AutoSize = true;
            this.lblaccno.Location = new System.Drawing.Point(8, 88);
            this.lblaccno.Name = "lblaccno";
            this.lblaccno.Size = new System.Drawing.Size(88, 14);
            this.lblaccno.TabIndex = 2;
            this.lblaccno.Text = "Drawee A/C No";
            // 
            // lblchqamt
            // 
            this.lblchqamt.AutoSize = true;
            this.lblchqamt.Location = new System.Drawing.Point(8, 54);
            this.lblchqamt.Name = "lblchqamt";
            this.lblchqamt.Size = new System.Drawing.Size(93, 14);
            this.lblchqamt.TabIndex = 1;
            this.lblchqamt.Text = "Cheque Amount";
            // 
            // lblchqdate
            // 
            this.lblchqdate.AutoSize = true;
            this.lblchqdate.BackColor = System.Drawing.SystemColors.Control;
            this.lblchqdate.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.lblchqdate.Location = new System.Drawing.Point(8, 25);
            this.lblchqdate.Name = "lblchqdate";
            this.lblchqdate.Size = new System.Drawing.Size(77, 14);
            this.lblchqdate.TabIndex = 0;
            this.lblchqdate.Text = "Cheque Date";
            // 
            // GrdScannedList
            // 
            this.GrdScannedList.AllowUserToAddRows = false;
            this.GrdScannedList.AllowUserToDeleteRows = false;
            this.GrdScannedList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrdScannedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdScannedList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdScannedList.Location = new System.Drawing.Point(0, 403);
            this.GrdScannedList.Name = "GrdScannedList";
            this.GrdScannedList.ReadOnly = true;
            this.GrdScannedList.Size = new System.Drawing.Size(1190, 241);
            this.GrdScannedList.TabIndex = 1;
            this.GrdScannedList.SelectionChanged += new System.EventHandler(this.GrdScannedList_SelectionChanged);
            this.GrdScannedList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrdScannedList_KeyPress);
            // 
            // PicBackSide
            // 
            this.PicBackSide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBackSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBackSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBackSide.ErrorImage = null;
            this.PicBackSide.Location = new System.Drawing.Point(0, 59);
            this.PicBackSide.Name = "PicBackSide";
            this.PicBackSide.Size = new System.Drawing.Size(912, 274);
            this.PicBackSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBackSide.TabIndex = 20;
            this.PicBackSide.TabStop = false;
            this.PicBackSide.Visible = false;
            this.PicBackSide.Click += new System.EventHandler(this.PicBackSide_Click);
            // 
            // PicLoad
            // 
            this.PicLoad.Image = ((System.Drawing.Image)(resources.GetObject("PicLoad.Image")));
            this.PicLoad.Location = new System.Drawing.Point(402, 211);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(177, 122);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 40;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // CheckerValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 644);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.PicBackSide);
            this.Controls.Add(this.GrdScannedList);
            this.Controls.Add(this.pnlinfo);
            this.Controls.Add(this.PicFrontSide);
            this.Controls.Add(this.gvscanlist);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CheckerValidation";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CheckerValidation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFrontSide)).EndInit();
            this.pnlinfo.ResumeLayout(false);
            this.pnlinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdScannedList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBackSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvscanlist;
        private System.Windows.Forms.PictureBox PicFrontSide;
        private System.Windows.Forms.Panel pnlinfo;
        private System.Windows.Forms.TextBox txtaccno;
        private System.Windows.Forms.TextBox txtchqamt;
        private System.Windows.Forms.Label lbldrwname;
        private System.Windows.Forms.Label lblaccno;
        private System.Windows.Forms.Label lblchqamt;
        private System.Windows.Forms.Label lblchqdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btntogg;
        private System.Windows.Forms.ComboBox cmbodraweename;
        private System.Windows.Forms.DataGridView GrdScannedList;
        private System.Windows.Forms.TextBox chqdtpicker;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn depo_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn scan_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_entered;
        private System.Windows.Forms.DataGridViewTextBoxColumn differecne;
        private System.Windows.Forms.PictureBox PicBackSide;
        private System.Windows.Forms.TextBox txtaccname;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btn_Refersh;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.Button btn_persist;
        private System.Windows.Forms.TextBox txtchequeamt;
    }
}