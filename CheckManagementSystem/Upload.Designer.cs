namespace CheckManagementSystem
{
    partial class Upload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Upload));
            this.pnlupload = new System.Windows.Forms.Panel();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.rdoupload = new System.Windows.Forms.RadioButton();
            this.lstbtngen = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.btncls = new System.Windows.Forms.Button();
            this.btngen = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.cmbloc = new System.Windows.Forms.ComboBox();
            this.lblloc = new System.Windows.Forms.Label();
            this.cmbuptype = new System.Windows.Forms.ComboBox();
            this.lbluptype = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.lbltype = new System.Windows.Forms.Label();
            this.gvuploadgrid = new System.Windows.Forms.DataGridView();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chq_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_code_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            this.pnlupload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvuploadgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlupload
            // 
            this.pnlupload.Controls.Add(this.rdoall);
            this.pnlupload.Controls.Add(this.rdoupload);
            this.pnlupload.Controls.Add(this.lstbtngen);
            this.pnlupload.Controls.Add(this.lblstatus);
            this.pnlupload.Controls.Add(this.btncls);
            this.pnlupload.Controls.Add(this.btngen);
            this.pnlupload.Controls.Add(this.btnref);
            this.pnlupload.Controls.Add(this.cmbloc);
            this.pnlupload.Controls.Add(this.lblloc);
            this.pnlupload.Controls.Add(this.cmbuptype);
            this.pnlupload.Controls.Add(this.lbluptype);
            this.pnlupload.Controls.Add(this.cmbtype);
            this.pnlupload.Controls.Add(this.lbltype);
            this.pnlupload.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlupload.Location = new System.Drawing.Point(0, 0);
            this.pnlupload.Name = "pnlupload";
            this.pnlupload.Size = new System.Drawing.Size(898, 85);
            this.pnlupload.TabIndex = 0;
            // 
            // rdoall
            // 
            this.rdoall.AutoSize = true;
            this.rdoall.Location = new System.Drawing.Point(656, 60);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(77, 19);
            this.rdoall.TabIndex = 13;
            this.rdoall.Text = "Uploaded";
            this.rdoall.UseVisualStyleBackColor = true;
            this.rdoall.CheckedChanged += new System.EventHandler(this.rdoall_CheckedChanged);
            // 
            // rdoupload
            // 
            this.rdoupload.AutoSize = true;
            this.rdoupload.Checked = true;
            this.rdoupload.Location = new System.Drawing.Point(570, 60);
            this.rdoupload.Name = "rdoupload";
            this.rdoupload.Size = new System.Drawing.Size(69, 19);
            this.rdoupload.TabIndex = 12;
            this.rdoupload.TabStop = true;
            this.rdoupload.Text = "Pending";
            this.rdoupload.UseVisualStyleBackColor = true;
            this.rdoupload.CheckedChanged += new System.EventHandler(this.rdoupload_CheckedChanged);
            // 
            // lstbtngen
            // 
            this.lstbtngen.Location = new System.Drawing.Point(76, 51);
            this.lstbtngen.Name = "lstbtngen";
            this.lstbtngen.Size = new System.Drawing.Size(139, 27);
            this.lstbtngen.TabIndex = 11;
            this.lstbtngen.Text = "Generate Upload";
            this.lstbtngen.UseVisualStyleBackColor = true;
            this.lstbtngen.Click += new System.EventHandler(this.lstbtngen_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblstatus.Location = new System.Drawing.Point(774, 63);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(76, 15);
            this.lblstatus.TabIndex = 10;
            this.lblstatus.Text = "Processing....";
            this.lblstatus.Visible = false;
            // 
            // btncls
            // 
            this.btncls.Location = new System.Drawing.Point(264, 51);
            this.btncls.Name = "btncls";
            this.btncls.Size = new System.Drawing.Size(87, 27);
            this.btncls.TabIndex = 9;
            this.btncls.Text = "Close";
            this.btncls.UseVisualStyleBackColor = true;
            this.btncls.Click += new System.EventHandler(this.btncls_Click);
            // 
            // btngen
            // 
            this.btngen.Location = new System.Drawing.Point(365, 51);
            this.btngen.Name = "btngen";
            this.btngen.Size = new System.Drawing.Size(141, 27);
            this.btngen.TabIndex = 8;
            this.btngen.Text = "Old Generate Upload";
            this.btngen.UseVisualStyleBackColor = true;
            this.btngen.Visible = false;
            this.btngen.Click += new System.EventHandler(this.btngen_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(817, 12);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(78, 27);
            this.btnref.TabIndex = 7;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = true;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // cmbloc
            // 
            this.cmbloc.FormattingEnabled = true;
            this.cmbloc.Location = new System.Drawing.Point(636, 16);
            this.cmbloc.Name = "cmbloc";
            this.cmbloc.Size = new System.Drawing.Size(140, 23);
            this.cmbloc.TabIndex = 6;
            this.cmbloc.SelectedIndexChanged += new System.EventHandler(this.cmbloc_SelectedIndexChanged_1);
//            this.cmbloc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbloc_KeyPress);
            // 
            // lblloc
            // 
            this.lblloc.AutoSize = true;
            this.lblloc.Location = new System.Drawing.Point(549, 20);
            this.lblloc.Name = "lblloc";
            this.lblloc.Size = new System.Drawing.Size(53, 15);
            this.lblloc.TabIndex = 5;
            this.lblloc.Text = "Location";
            // 
            // cmbuptype
            // 
            this.cmbuptype.FormattingEnabled = true;
            this.cmbuptype.Location = new System.Drawing.Point(366, 12);
            this.cmbuptype.Name = "cmbuptype";
            this.cmbuptype.Size = new System.Drawing.Size(140, 23);
            this.cmbuptype.TabIndex = 4;
            this.cmbuptype.SelectedIndexChanged += new System.EventHandler(this.cmbuptype_SelectedIndexChanged_1);
            //this.cmbuptype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbuptype_KeyPress);
            // 
            // lbluptype
            // 
            this.lbluptype.AutoSize = true;
            this.lbluptype.Location = new System.Drawing.Point(261, 16);
            this.lbluptype.Name = "lbluptype";
            this.lbluptype.Size = new System.Drawing.Size(74, 15);
            this.lbluptype.TabIndex = 3;
            this.lbluptype.Text = "Upload Type";
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(76, 12);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(140, 23);
            this.cmbtype.TabIndex = 2;
            this.cmbtype.SelectedIndexChanged += new System.EventHandler(this.cmbtype_SelectedIndexChanged);
            //this.cmbtype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbtype_KeyPress);
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Location = new System.Drawing.Point(12, 16);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(33, 15);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "Type";
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
            this.batch_no,
            this.chq_cnt,
            this.batch_amt,
            this.dep_no,
            this.cus_code_name,
            this.select});
            this.gvuploadgrid.Location = new System.Drawing.Point(0, 84);
            this.gvuploadgrid.Name = "gvuploadgrid";
            this.gvuploadgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvuploadgrid.Size = new System.Drawing.Size(898, 529);
            this.gvuploadgrid.TabIndex = 1;
            this.gvuploadgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvuploadgrid_CellClick);
            this.gvuploadgrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvuploadgrid_KeyDown);
            // 
            // batch_no
            // 
            this.batch_no.HeaderText = "Batch No";
            this.batch_no.Name = "batch_no";
            // 
            // chq_cnt
            // 
            this.chq_cnt.HeaderText = "Cheque Count";
            this.chq_cnt.Name = "chq_cnt";
            // 
            // batch_amt
            // 
            this.batch_amt.HeaderText = "Batch Amount";
            this.batch_amt.Name = "batch_amt";
            // 
            // dep_no
            // 
            this.dep_no.HeaderText = "Dep Slip No";
            this.dep_no.Name = "dep_no";
            // 
            // cus_code_name
            // 
            this.cus_code_name.HeaderText = "Cus Code/Name";
            this.cus_code_name.Name = "cus_code_name";
            // 
            // select
            // 
            this.select.HeaderText = "Select";
            this.select.MinimumWidth = 4;
            this.select.Name = "select";
            // 
            // PicLoad
            // 
            this.PicLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PicLoad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PicLoad.Image = ((System.Drawing.Image)(resources.GetObject("PicLoad.Image")));
            this.PicLoad.Location = new System.Drawing.Point(366, 182);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(158, 121);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 35;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 609);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvuploadgrid);
            this.Controls.Add(this.pnlupload);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Upload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button btngen;
        private System.Windows.Forms.Button btnref;
        private System.Windows.Forms.ComboBox cmbloc;
        private System.Windows.Forms.Label lblloc;
        private System.Windows.Forms.ComboBox cmbuptype;
        private System.Windows.Forms.Label lbluptype;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.DataGridView gvuploadgrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chq_cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_code_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.Button lstbtngen;
        private System.Windows.Forms.RadioButton rdoall;
        private System.Windows.Forms.RadioButton rdoupload;
    }
}