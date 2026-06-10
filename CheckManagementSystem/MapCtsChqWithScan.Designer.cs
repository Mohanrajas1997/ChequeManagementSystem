namespace CheckManagementSystem
{
    partial class MapCtsChqWithScan
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
            this.picChq = new System.Windows.Forms.PictureBox();
            this.dgvCtsChqEntry = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCtsAccName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCtsAccNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtChqAmt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChqNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.txtChqId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picChq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtsChqEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // picChq
            // 
            this.picChq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picChq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picChq.ErrorImage = null;
            this.picChq.Location = new System.Drawing.Point(1, 1);
            this.picChq.Name = "picChq";
            this.picChq.Size = new System.Drawing.Size(1150, 381);
            this.picChq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChq.TabIndex = 35;
            this.picChq.TabStop = false;
            // 
            // dgvCtsChqEntry
            // 
            this.dgvCtsChqEntry.AllowUserToAddRows = false;
            this.dgvCtsChqEntry.AllowUserToDeleteRows = false;
            this.dgvCtsChqEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtsChqEntry.Location = new System.Drawing.Point(1, 390);
            this.dgvCtsChqEntry.Name = "dgvCtsChqEntry";
            this.dgvCtsChqEntry.ReadOnly = true;
            this.dgvCtsChqEntry.Size = new System.Drawing.Size(617, 128);
            this.dgvCtsChqEntry.TabIndex = 36;
            this.dgvCtsChqEntry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtsChqEntry_CellContentClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(637, 450);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "CTS A/C Holder";
            // 
            // txtCtsAccName
            // 
            this.txtCtsAccName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCtsAccName.ForeColor = System.Drawing.Color.Red;
            this.txtCtsAccName.Location = new System.Drawing.Point(733, 447);
            this.txtCtsAccName.MaxLength = 128;
            this.txtCtsAccName.Name = "txtCtsAccName";
            this.txtCtsAccName.ReadOnly = true;
            this.txtCtsAccName.Size = new System.Drawing.Size(418, 21);
            this.txtCtsAccName.TabIndex = 44;
            this.txtCtsAccName.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(658, 423);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "CTS A/C No";
            // 
            // txtCtsAccNo
            // 
            this.txtCtsAccNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCtsAccNo.Location = new System.Drawing.Point(733, 420);
            this.txtCtsAccNo.MaxLength = 32;
            this.txtCtsAccNo.Name = "txtCtsAccNo";
            this.txtCtsAccNo.ReadOnly = true;
            this.txtCtsAccNo.Size = new System.Drawing.Size(418, 21);
            this.txtCtsAccNo.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(932, 398);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Chq Amount";
            // 
            // txtChqAmt
            // 
            this.txtChqAmt.Location = new System.Drawing.Point(1014, 393);
            this.txtChqAmt.MaxLength = 15;
            this.txtChqAmt.Name = "txtChqAmt";
            this.txtChqAmt.ReadOnly = true;
            this.txtChqAmt.Size = new System.Drawing.Size(137, 21);
            this.txtChqAmt.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(682, 398);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Chq No";
            // 
            // txtChqNo
            // 
            this.txtChqNo.Location = new System.Drawing.Point(733, 393);
            this.txtChqNo.MaxLength = 6;
            this.txtChqNo.Name = "txtChqNo";
            this.txtChqNo.ReadOnly = true;
            this.txtChqNo.Size = new System.Drawing.Size(137, 21);
            this.txtChqNo.TabIndex = 38;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1070, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(986, 488);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(78, 23);
            this.btnMap.TabIndex = 45;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // txtChqId
            // 
            this.txtChqId.Location = new System.Drawing.Point(700, 488);
            this.txtChqId.MaxLength = 6;
            this.txtChqId.Name = "txtChqId";
            this.txtChqId.Size = new System.Drawing.Size(137, 21);
            this.txtChqId.TabIndex = 47;
            this.txtChqId.Text = "0";
            this.txtChqId.Visible = false;
            // 
            // MapCtsChqWithScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 523);
            this.Controls.Add(this.txtChqId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtCtsAccName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCtsAccNo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtChqAmt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtChqNo);
            this.Controls.Add(this.dgvCtsChqEntry);
            this.Controls.Add(this.picChq);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapCtsChqWithScan";
            this.Text = "Map CTS Cheque With Scan";
            this.Load += new System.EventHandler(this.MapCtsChqWithScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picChq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtsChqEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picChq;
        private System.Windows.Forms.DataGridView dgvCtsChqEntry;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCtsAccName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCtsAccNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtChqAmt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtChqNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.TextBox txtChqId;
    }
}