namespace CheckManagementSystem
{
    partial class MakerValidation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvscanlist = new System.Windows.Forms.DataGridView();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depo_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scan_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicBackSide = new System.Windows.Forms.PictureBox();
            this.PicFrontSide = new System.Windows.Forms.PictureBox();
            this.GrdMaker = new System.Windows.Forms.DataGridView();
            this.serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tran_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.front_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back_image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scan_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnToggle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbt_all = new System.Windows.Forms.RadioButton();
            this.rbt_hghlgt = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBackSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFrontSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMaker)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.scan_count});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvscanlist.Location = new System.Drawing.Point(0, 0);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.ReadOnly = true;
            this.gvscanlist.Size = new System.Drawing.Size(1219, 55);
            this.gvscanlist.TabIndex = 4;
            this.gvscanlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvscanlist_KeyDown);
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
            // scan_count
            // 
            this.scan_count.HeaderText = "Scan Count";
            this.scan_count.Name = "scan_count";
            this.scan_count.ReadOnly = true;
            // 
            // PicBackSide
            // 
            this.PicBackSide.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.PicBackSide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBackSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicBackSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBackSide.ErrorImage = null;
            this.PicBackSide.Location = new System.Drawing.Point(12, -29);
            this.PicBackSide.Name = "PicBackSide";
            this.PicBackSide.Size = new System.Drawing.Size(1212, 295);
            this.PicBackSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBackSide.TabIndex = 15;
            this.PicBackSide.TabStop = false;
            this.PicBackSide.Visible = false;
            // 
            // PicFrontSide
            // 
            this.PicFrontSide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicFrontSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicFrontSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicFrontSide.ErrorImage = null;
            this.PicFrontSide.Location = new System.Drawing.Point(3, 0);
            this.PicFrontSide.Name = "PicFrontSide";
            this.PicFrontSide.Size = new System.Drawing.Size(1212, 266);
            this.PicFrontSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicFrontSide.TabIndex = 16;
            this.PicFrontSide.TabStop = false;
            // 
            // GrdMaker
            // 
            this.GrdMaker.AllowUserToAddRows = false;
            this.GrdMaker.AllowUserToDeleteRows = false;
            this.GrdMaker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdMaker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrdMaker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdMaker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial_no,
            this.check_no,
            this.sort_codes,
            this.base_codes,
            this.tran_codes,
            this.front_image,
            this.back_image,
            this.status,
            this.scan_id});
            this.GrdMaker.Location = new System.Drawing.Point(-4, 350);
            this.GrdMaker.MultiSelect = false;
            this.GrdMaker.Name = "GrdMaker";
            this.GrdMaker.Size = new System.Drawing.Size(1219, 282);
            this.GrdMaker.TabIndex = 30;
            this.GrdMaker.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdMaker_CellEndEdit);
            this.GrdMaker.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.GrdMaker_EditingControlShowing);
            this.GrdMaker.SelectionChanged += new System.EventHandler(this.grdScanning_SelectionChanged);
            this.GrdMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdMaker_KeyDown);
            this.GrdMaker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GrdMaker_KeyUp);
            // 
            // serial_no
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.serial_no.DefaultCellStyle = dataGridViewCellStyle1;
            this.serial_no.HeaderText = "Serial No";
            this.serial_no.Name = "serial_no";
            this.serial_no.ReadOnly = true;
            // 
            // check_no
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.check_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.check_no.HeaderText = "Cheque No";
            this.check_no.Name = "check_no";
            // 
            // sort_codes
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sort_codes.DefaultCellStyle = dataGridViewCellStyle3;
            this.sort_codes.HeaderText = "Sort Code";
            this.sort_codes.MaxInputLength = 9;
            this.sort_codes.Name = "sort_codes";
            // 
            // base_codes
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.base_codes.DefaultCellStyle = dataGridViewCellStyle4;
            this.base_codes.HeaderText = "Base Code";
            this.base_codes.Name = "base_codes";
            // 
            // tran_codes
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tran_codes.DefaultCellStyle = dataGridViewCellStyle5;
            this.tran_codes.HeaderText = "Tran Code";
            this.tran_codes.Name = "tran_codes";
            // 
            // front_image
            // 
            this.front_image.HeaderText = "Front Image";
            this.front_image.Name = "front_image";
            this.front_image.Visible = false;
            // 
            // back_image
            // 
            this.back_image.HeaderText = "Bak Image";
            this.back_image.Name = "back_image";
            this.back_image.Visible = false;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.Visible = false;
            // 
            // scan_id
            // 
            this.scan_id.HeaderText = "Scan ID";
            this.scan_id.Name = "scan_id";
            this.scan_id.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PicBackSide);
            this.panel1.Controls.Add(this.PicFrontSide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 269);
            this.panel1.TabIndex = 31;
            // 
            // btnToggle
            // 
            this.btnToggle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToggle.Location = new System.Drawing.Point(1152, 0);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(63, 33);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.rbt_all);
            this.panel2.Controls.Add(this.rbt_hghlgt);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnToggle);
            this.panel2.Location = new System.Drawing.Point(0, 638);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1215, 33);
            this.panel2.TabIndex = 32;
            // 
            // rbt_all
            // 
            this.rbt_all.AutoSize = true;
            this.rbt_all.Location = new System.Drawing.Point(749, 7);
            this.rbt_all.Name = "rbt_all";
            this.rbt_all.Size = new System.Drawing.Size(141, 19);
            this.rbt_all.TabIndex = 5;
            this.rbt_all.TabStop = true;
            this.rbt_all.Text = "All Without Highlight";
            this.rbt_all.UseVisualStyleBackColor = true;
            this.rbt_all.CheckedChanged += new System.EventHandler(this.rbt_all_CheckedChanged);
            // 
            // rbt_hghlgt
            // 
            this.rbt_hghlgt.AutoSize = true;
            this.rbt_hghlgt.Location = new System.Drawing.Point(647, 5);
            this.rbt_hghlgt.Name = "rbt_hghlgt";
            this.rbt_hghlgt.Size = new System.Drawing.Size(75, 19);
            this.rbt_hghlgt.TabIndex = 4;
            this.rbt_hghlgt.TabStop = true;
            this.rbt_hghlgt.Text = "Highlight";
            this.rbt_hghlgt.UseVisualStyleBackColor = true;
            this.rbt_hghlgt.CheckedChanged += new System.EventHandler(this.rbt_hghlgt_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Location = new System.Drawing.Point(911, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 33);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(1026, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(1089, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "BRANCH NAME";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchName.Location = new System.Drawing.Point(112, 322);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(321, 27);
            this.txtBranchName.TabIndex = 34;
            // 
            // MakerValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 674);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GrdMaker);
            this.Controls.Add(this.gvscanlist);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MakerValidation";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MakerValidation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBackSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicFrontSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMaker)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvscanlist;
        private System.Windows.Forms.PictureBox PicBackSide;
        private System.Windows.Forms.PictureBox PicFrontSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn depo_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn scan_count;
        private System.Windows.Forms.DataGridView GrdMaker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton rbt_all;
        private System.Windows.Forms.RadioButton rbt_hghlgt;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tran_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn front_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn back_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn scan_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBranchName;
    }
}