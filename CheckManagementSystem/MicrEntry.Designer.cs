namespace CheckManagementSystem
{
    partial class MicrEntry
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.NewMicrNo_Txt = new System.Windows.Forms.TextBox();
            this.OldMicrNo_Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PicPlus = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PicPlus);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.NewMicrNo_Txt);
            this.panel1.Controls.Add(this.OldMicrNo_Txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 99);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(169, 67);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 67);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NewMicrNo_Txt
            // 
            this.NewMicrNo_Txt.Location = new System.Drawing.Point(91, 39);
            this.NewMicrNo_Txt.MaxLength = 9;
            this.NewMicrNo_Txt.Name = "NewMicrNo_Txt";
            this.NewMicrNo_Txt.Size = new System.Drawing.Size(153, 21);
            this.NewMicrNo_Txt.TabIndex = 1;
            this.NewMicrNo_Txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewMicrNo_Txt_KeyPress);
            // 
            // OldMicrNo_Txt
            // 
            this.OldMicrNo_Txt.Location = new System.Drawing.Point(91, 7);
            this.OldMicrNo_Txt.Name = "OldMicrNo_Txt";
            this.OldMicrNo_Txt.ReadOnly = true;
            this.OldMicrNo_Txt.Size = new System.Drawing.Size(153, 21);
            this.OldMicrNo_Txt.TabIndex = 0;
            this.OldMicrNo_Txt.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Micr No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Micr No";
            // 
            // PicPlus
            // 
            this.PicPlus.Image = global::CheckManagementSystem.Properties.Resources.plus__2_;
            this.PicPlus.Location = new System.Drawing.Point(250, 3);
            this.PicPlus.Name = "PicPlus";
            this.PicPlus.Size = new System.Drawing.Size(29, 25);
            this.PicPlus.TabIndex = 4;
            this.PicPlus.TabStop = false;
            this.PicPlus.Click += new System.EventHandler(this.PicPlus_Click);
            // 
            // MicrEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 111);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MicrEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Micr Entry";
            this.Load += new System.EventHandler(this.MicrEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MicrEntry_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPlus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox NewMicrNo_Txt;
        private System.Windows.Forms.TextBox OldMicrNo_Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox PicPlus;
    }
}