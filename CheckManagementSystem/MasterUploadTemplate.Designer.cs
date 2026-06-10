namespace CheckManagementSystem
{
    partial class MasterUploadTemplate
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
            this.pnl_upl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblfilepath = new System.Windows.Forms.Label();
            this.txtfilepath = new System.Windows.Forms.TextBox();
            this.btndownloadtemplate = new System.Windows.Forms.Button();
            this.cmb_master = new System.Windows.Forms.ComboBox();
            this.pnl_upl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_upl
            // 
            this.pnl_upl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_upl.Controls.Add(this.label1);
            this.pnl_upl.Controls.Add(this.lblStatus);
            this.pnl_upl.Controls.Add(this.btnUpload);
            this.pnl_upl.Controls.Add(this.btnBrowse);
            this.pnl_upl.Controls.Add(this.lblfilepath);
            this.pnl_upl.Controls.Add(this.txtfilepath);
            this.pnl_upl.Controls.Add(this.btndownloadtemplate);
            this.pnl_upl.Controls.Add(this.cmb_master);
            this.pnl_upl.Location = new System.Drawing.Point(12, 2);
            this.pnl_upl.Name = "pnl_upl";
            this.pnl_upl.Size = new System.Drawing.Size(535, 122);
            this.pnl_upl.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Master Name";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(94, 86);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Loading.......";
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(438, 81);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(78, 23);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(351, 81);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(78, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblfilepath
            // 
            this.lblfilepath.AutoSize = true;
            this.lblfilepath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfilepath.Location = new System.Drawing.Point(9, 52);
            this.lblfilepath.Name = "lblfilepath";
            this.lblfilepath.Size = new System.Drawing.Size(52, 13);
            this.lblfilepath.TabIndex = 8;
            this.lblfilepath.Text = "FilePath";
            // 
            // txtfilepath
            // 
            this.txtfilepath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilepath.Location = new System.Drawing.Point(97, 48);
            this.txtfilepath.Name = "txtfilepath";
            this.txtfilepath.Size = new System.Drawing.Size(419, 21);
            this.txtfilepath.TabIndex = 7;
            // 
            // btndownloadtemplate
            // 
            this.btndownloadtemplate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndownloadtemplate.Location = new System.Drawing.Point(351, 9);
            this.btndownloadtemplate.Name = "btndownloadtemplate";
            this.btndownloadtemplate.Size = new System.Drawing.Size(165, 25);
            this.btndownloadtemplate.TabIndex = 6;
            this.btndownloadtemplate.Text = "Download Template";
            this.btndownloadtemplate.UseVisualStyleBackColor = true;
            this.btndownloadtemplate.Click += new System.EventHandler(this.btndownloadtemplate_Click);
            // 
            // cmb_master
            // 
            this.cmb_master.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_master.FormattingEnabled = true;
            this.cmb_master.Location = new System.Drawing.Point(97, 12);
            this.cmb_master.Name = "cmb_master";
            this.cmb_master.Size = new System.Drawing.Size(238, 21);
            this.cmb_master.TabIndex = 1;
            this.cmb_master.SelectedIndexChanged += new System.EventHandler(this.cmb_master_SelectedIndexChanged);
            // 
            // MasterUploadTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(557, 135);
            this.Controls.Add(this.pnl_upl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasterUploadTemplate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MasterUploadTemplate_Load);
            this.pnl_upl.ResumeLayout(false);
            this.pnl_upl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_upl;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblfilepath;
        private System.Windows.Forms.TextBox txtfilepath;
        private System.Windows.Forms.Button btndownloadtemplate;
        private System.Windows.Forms.ComboBox cmb_master;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;

    }
}