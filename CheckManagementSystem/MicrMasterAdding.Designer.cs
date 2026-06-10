namespace CheckManagementSystem
{
    partial class MicrMasterAdding
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
            this.BranchName_Txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.BankName_Txt = new System.Windows.Forms.TextBox();
            this.MicrNo_Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BranchName_Txt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.BankName_Txt);
            this.panel1.Controls.Add(this.MicrNo_Txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 117);
            this.panel1.TabIndex = 0;
            // 
            // BranchName_Txt
            // 
            this.BranchName_Txt.Location = new System.Drawing.Point(91, 66);
            this.BranchName_Txt.MaxLength = 3000;
            this.BranchName_Txt.Name = "BranchName_Txt";
            this.BranchName_Txt.Size = new System.Drawing.Size(153, 21);
            this.BranchName_Txt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Branch Name";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(169, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BankName_Txt
            // 
            this.BankName_Txt.Location = new System.Drawing.Point(91, 37);
            this.BankName_Txt.MaxLength = 128;
            this.BankName_Txt.Name = "BankName_Txt";
            this.BankName_Txt.Size = new System.Drawing.Size(153, 21);
            this.BankName_Txt.TabIndex = 1;
            // 
            // MicrNo_Txt
            // 
            this.MicrNo_Txt.Location = new System.Drawing.Point(91, 7);
            this.MicrNo_Txt.Name = "MicrNo_Txt";
            this.MicrNo_Txt.ReadOnly = true;
            this.MicrNo_Txt.Size = new System.Drawing.Size(153, 21);
            this.MicrNo_Txt.TabIndex = 0;
            this.MicrNo_Txt.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bank Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Micr No";
            // 
            // MicrMasterAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 129);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MicrMasterAdding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Micr Adding";
            this.Load += new System.EventHandler(this.MicrEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MicrEntry_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox BankName_Txt;
        private System.Windows.Forms.TextBox MicrNo_Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox BranchName_Txt;
        private System.Windows.Forms.Label label3;
    }
}