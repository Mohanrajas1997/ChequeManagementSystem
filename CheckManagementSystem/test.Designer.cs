namespace CheckManagementSystem
{
    partial class test
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
            this.grdScanning = new System.Windows.Forms.DataGridView();
            this.serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tran_codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.images_files = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdScanning)).BeginInit();
            this.SuspendLayout();
            // 
            // grdScanning
            // 
            this.grdScanning.AllowUserToAddRows = false;
            this.grdScanning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdScanning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdScanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdScanning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial_no,
            this.check_no,
            this.sort_codes,
            this.base_codes,
            this.tran_codes,
            this.images_files});
            this.grdScanning.Location = new System.Drawing.Point(35, 49);
            this.grdScanning.MultiSelect = false;
            this.grdScanning.Name = "grdScanning";
            this.grdScanning.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdScanning.Size = new System.Drawing.Size(716, 213);
            this.grdScanning.TabIndex = 24;
            this.grdScanning.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdScanning_DefaultValuesNeeded);
            // 
            // serial_no
            // 
            this.serial_no.FillWeight = 39.96638F;
            this.serial_no.HeaderText = "Serial No.";
            this.serial_no.Name = "serial_no";
            this.serial_no.ReadOnly = true;
            // 
            // check_no
            // 
            this.check_no.FillWeight = 253.8071F;
            this.check_no.HeaderText = "Cheque No";
            this.check_no.Name = "check_no";
            // 
            // sort_codes
            // 
            this.sort_codes.FillWeight = 68.74217F;
            this.sort_codes.HeaderText = "sort_code";
            this.sort_codes.Name = "sort_codes";
            // 
            // base_codes
            // 
            this.base_codes.FillWeight = 68.74217F;
            this.base_codes.HeaderText = "Base Code";
            this.base_codes.Name = "base_codes";
            // 
            // tran_codes
            // 
            this.tran_codes.FillWeight = 68.74217F;
            this.tran_codes.HeaderText = "Tran Code";
            this.tran_codes.Name = "tran_codes";
            // 
            // images_files
            // 
            this.images_files.HeaderText = "Image Files";
            this.images_files.Name = "images_files";
            this.images_files.Visible = false;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 341);
            this.Controls.Add(this.grdScanning);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdScanning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdScanning;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tran_codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn images_files;
    }
}