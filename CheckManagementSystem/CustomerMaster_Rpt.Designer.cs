namespace CheckManagementSystem
{
    partial class CustomerMaster_Rpt
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
            this.CustomerName_Txt = new System.Windows.Forms.TextBox();
            this.CustomerCode_Txt = new System.Windows.Forms.TextBox();
            this.lstbtngen = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.btncls = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.lbluptype = new System.Windows.Forms.Label();
            this.lbltype = new System.Windows.Forms.Label();
            this.gvuploadgrid = new System.Windows.Forms.DataGridView();
            this.CUSTOMER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            this.pnlupload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvuploadgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlupload
            // 
            this.pnlupload.Controls.Add(this.CustomerName_Txt);
            this.pnlupload.Controls.Add(this.CustomerCode_Txt);
            this.pnlupload.Controls.Add(this.lstbtngen);
            this.pnlupload.Controls.Add(this.lblstatus);
            this.pnlupload.Controls.Add(this.btncls);
            this.pnlupload.Controls.Add(this.btnref);
            this.pnlupload.Controls.Add(this.lbluptype);
            this.pnlupload.Controls.Add(this.lbltype);
            this.pnlupload.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlupload.Location = new System.Drawing.Point(0, 0);
            this.pnlupload.Name = "pnlupload";
            this.pnlupload.Size = new System.Drawing.Size(1193, 74);
            this.pnlupload.TabIndex = 0;
            // 
            // CustomerName_Txt
            // 
            this.CustomerName_Txt.Location = new System.Drawing.Point(393, 11);
            this.CustomerName_Txt.Name = "CustomerName_Txt";
            this.CustomerName_Txt.Size = new System.Drawing.Size(160, 21);
            this.CustomerName_Txt.TabIndex = 13;
            // 
            // CustomerCode_Txt
            // 
            this.CustomerCode_Txt.Location = new System.Drawing.Point(111, 11);
            this.CustomerCode_Txt.Name = "CustomerCode_Txt";
            this.CustomerCode_Txt.Size = new System.Drawing.Size(160, 21);
            this.CustomerCode_Txt.TabIndex = 12;
            // 
            // lstbtngen
            // 
            this.lstbtngen.Location = new System.Drawing.Point(652, 9);
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
            this.lblstatus.Location = new System.Drawing.Point(833, 15);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(80, 13);
            this.lblstatus.TabIndex = 10;
            this.lblstatus.Text = "Processing....";
            this.lblstatus.Visible = false;
            // 
            // btncls
            // 
            this.btncls.Location = new System.Drawing.Point(736, 9);
            this.btncls.Name = "btncls";
            this.btncls.Size = new System.Drawing.Size(78, 23);
            this.btncls.TabIndex = 9;
            this.btncls.Text = "Close";
            this.btncls.UseVisualStyleBackColor = true;
            this.btncls.Click += new System.EventHandler(this.btncls_Click);
            // 
            // btnref
            // 
            this.btnref.Location = new System.Drawing.Point(568, 9);
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
            this.lbluptype.Location = new System.Drawing.Point(290, 15);
            this.lbluptype.Name = "lbluptype";
            this.lbluptype.Size = new System.Drawing.Size(97, 13);
            this.lbluptype.TabIndex = 3;
            this.lbluptype.Text = "Customer Name";
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Location = new System.Drawing.Point(12, 15);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(93, 13);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "Customer Code";
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
            this.CUSTOMER_CODE,
            this.CUSTOMER_NAME,
            this.gid});
            this.gvuploadgrid.Location = new System.Drawing.Point(0, 38);
            this.gvuploadgrid.Name = "gvuploadgrid";
            this.gvuploadgrid.ReadOnly = true;
            this.gvuploadgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvuploadgrid.Size = new System.Drawing.Size(1193, 493);
            this.gvuploadgrid.TabIndex = 1;
            this.gvuploadgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvuploadgrid_CellClick);
            this.gvuploadgrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvuploadgrid_KeyDown);
            // 
            // CUSTOMER_CODE
            // 
            this.CUSTOMER_CODE.HeaderText = "Customer Code";
            this.CUSTOMER_CODE.Name = "CUSTOMER_CODE";
            this.CUSTOMER_CODE.ReadOnly = true;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.HeaderText = "Customer Name";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
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
            this.PicLoad.Location = new System.Drawing.Point(513, 158);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(158, 105);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 35;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // CustomerMaster_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 528);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvuploadgrid);
            this.Controls.Add(this.pnlupload);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "CustomerMaster_Rpt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Master Report";
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
        private System.Windows.Forms.TextBox CustomerName_Txt;
        private System.Windows.Forms.TextBox CustomerCode_Txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn gid;
    }
}
