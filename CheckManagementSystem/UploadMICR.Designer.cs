namespace CheckManagementSystem
{
    partial class UploadMICR
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
            this.txtexmicr = new System.Windows.Forms.TextBox();
            this.lblexmicr = new System.Windows.Forms.Label();
            this.cmbloc = new System.Windows.Forms.ComboBox();
            this.lblloc = new System.Windows.Forms.Label();
            this.lblupdmicr = new System.Windows.Forms.Label();
            this.txtupdmicr = new System.Windows.Forms.TextBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.GrdUpdMicr = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GrdUpdMicr)).BeginInit();
            this.SuspendLayout();
            // 
            // txtexmicr
            // 
            this.txtexmicr.Location = new System.Drawing.Point(106, 40);
            this.txtexmicr.MaxLength = 9;
            this.txtexmicr.Name = "txtexmicr";
            this.txtexmicr.Size = new System.Drawing.Size(100, 20);
            this.txtexmicr.TabIndex = 0;
            this.txtexmicr.Click += new System.EventHandler(this.txtexmicr_Click);
            this.txtexmicr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtexmicr_KeyPress);
            this.txtexmicr.Leave += new System.EventHandler(this.txtexmicr_Leave);
            // 
            // lblexmicr
            // 
            this.lblexmicr.AutoSize = true;
            this.lblexmicr.Location = new System.Drawing.Point(36, 43);
            this.lblexmicr.Name = "lblexmicr";
            this.lblexmicr.Size = new System.Drawing.Size(50, 13);
            this.lblexmicr.TabIndex = 1;
            this.lblexmicr.Text = "EX MiCR";
            // 
            // cmbloc
            // 
            this.cmbloc.FormattingEnabled = true;
            this.cmbloc.Items.AddRange(new object[] {
            "Chennai",
            "Bangalore",
            "Delhi"});
            this.cmbloc.Location = new System.Drawing.Point(327, 40);
            this.cmbloc.Name = "cmbloc";
            this.cmbloc.Size = new System.Drawing.Size(121, 21);
            this.cmbloc.TabIndex = 2;
            this.cmbloc.SelectedIndexChanged += new System.EventHandler(this.cmbloc_SelectedIndexChanged);
            this.cmbloc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbloc_KeyPress);
            this.cmbloc.Leave += new System.EventHandler(this.cmbloc_Leave);
            // 
            // lblloc
            // 
            this.lblloc.AutoSize = true;
            this.lblloc.Location = new System.Drawing.Point(242, 43);
            this.lblloc.Name = "lblloc";
            this.lblloc.Size = new System.Drawing.Size(48, 13);
            this.lblloc.TabIndex = 3;
            this.lblloc.Text = "Location";
            // 
            // lblupdmicr
            // 
            this.lblupdmicr.AutoSize = true;
            this.lblupdmicr.Location = new System.Drawing.Point(507, 43);
            this.lblupdmicr.Name = "lblupdmicr";
            this.lblupdmicr.Size = new System.Drawing.Size(72, 13);
            this.lblupdmicr.TabIndex = 4;
            this.lblupdmicr.Text = "Update MICR";
            // 
            // txtupdmicr
            // 
            this.txtupdmicr.Location = new System.Drawing.Point(608, 43);
            this.txtupdmicr.MaxLength = 9;
            this.txtupdmicr.Name = "txtupdmicr";
            this.txtupdmicr.Size = new System.Drawing.Size(100, 20);
            this.txtupdmicr.TabIndex = 5;
            this.txtupdmicr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtupdmicr_KeyPress);
            this.txtupdmicr.Leave += new System.EventHandler(this.txtupdmicr_Leave);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(352, 81);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 6;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // GrdUpdMicr
            // 
            this.GrdUpdMicr.AllowUserToAddRows = false;
            this.GrdUpdMicr.AllowUserToDeleteRows = false;
            this.GrdUpdMicr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrdUpdMicr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdUpdMicr.Location = new System.Drawing.Point(159, 156);
            this.GrdUpdMicr.Name = "GrdUpdMicr";
            this.GrdUpdMicr.ReadOnly = true;
            this.GrdUpdMicr.Size = new System.Drawing.Size(440, 187);
            this.GrdUpdMicr.TabIndex = 7;
            // 
            // UploadMICR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 492);
            this.Controls.Add(this.GrdUpdMicr);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.txtupdmicr);
            this.Controls.Add(this.lblupdmicr);
            this.Controls.Add(this.lblloc);
            this.Controls.Add(this.cmbloc);
            this.Controls.Add(this.lblexmicr);
            this.Controls.Add(this.txtexmicr);
            this.Name = "UploadMICR";
            this.Text = "UploadMICR";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UploadMICR_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GrdUpdMicr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtexmicr;
        private System.Windows.Forms.Label lblexmicr;
        private System.Windows.Forms.ComboBox cmbloc;
        private System.Windows.Forms.Label lblloc;
        private System.Windows.Forms.Label lblupdmicr;
        private System.Windows.Forms.TextBox txtupdmicr;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.DataGridView GrdUpdMicr;
    }
}