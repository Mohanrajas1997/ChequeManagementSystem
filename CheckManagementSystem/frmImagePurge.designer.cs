namespace CheckManagementSystem
{
    partial class frmImagePurge
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Batch_to_Date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Batch_Fromdate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Run);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.Batch_to_Date);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Batch_Fromdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 71);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // Batch_to_Date
            // 
            this.Batch_to_Date.Checked = false;
            this.Batch_to_Date.CustomFormat = "dd-MM-yyyy";
            this.Batch_to_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Batch_to_Date.Location = new System.Drawing.Point(255, 9);
            this.Batch_to_Date.MaxDate = new System.DateTime(2021, 1, 13, 0, 0, 0, 0);
            this.Batch_to_Date.Name = "Batch_to_Date";
            this.Batch_to_Date.ShowCheckBox = true;
            this.Batch_to_Date.Size = new System.Drawing.Size(122, 21);
            this.Batch_to_Date.TabIndex = 20;
            this.Batch_to_Date.Value = new System.DateTime(2021, 1, 13, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "To";
            // 
            // Batch_Fromdate
            // 
            this.Batch_Fromdate.Checked = false;
            this.Batch_Fromdate.CustomFormat = "dd-MM-yyyy";
            this.Batch_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Batch_Fromdate.Location = new System.Drawing.Point(82, 9);
            this.Batch_Fromdate.MaxDate = new System.DateTime(2021, 1, 13, 0, 0, 0, 0);
            this.Batch_Fromdate.Name = "Batch_Fromdate";
            this.Batch_Fromdate.ShowCheckBox = true;
            this.Batch_Fromdate.Size = new System.Drawing.Size(122, 21);
            this.Batch_Fromdate.TabIndex = 19;
            this.Batch_Fromdate.Value = new System.DateTime(2021, 1, 13, 0, 0, 0, 0);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(82, 44);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 13);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Processing.......";
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(220, 39);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 23);
            this.btn_Run.TabIndex = 23;
            this.btn_Run.Text = "&Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(302, 39);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 24;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // frmImagePurge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 79);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImagePurge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Purge";
            this.Load += new System.EventHandler(this.frmImagePurge_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Batch_to_Date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Batch_Fromdate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Run;
    }
}