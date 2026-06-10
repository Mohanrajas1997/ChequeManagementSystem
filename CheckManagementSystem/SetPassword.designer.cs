namespace CheckManagementSystem
{
    partial class SetPassword
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtRetypePwd = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(118, 88);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 24);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(203, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(19, 37);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "New Password";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(116, 34);
            this.txtNewPwd.MaxLength = 8;
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(165, 21);
            this.txtNewPwd.TabIndex = 13;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 64);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(105, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Retype Password";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRetypePwd
            // 
            this.txtRetypePwd.Location = new System.Drawing.Point(116, 61);
            this.txtRetypePwd.MaxLength = 8;
            this.txtRetypePwd.Name = "txtRetypePwd";
            this.txtRetypePwd.PasswordChar = '*';
            this.txtRetypePwd.Size = new System.Drawing.Size(165, 21);
            this.txtRetypePwd.TabIndex = 15;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(45, 10);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(62, 13);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Emp Code";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserCode
            // 
            this.txtUserCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserCode.Location = new System.Drawing.Point(116, 7);
            this.txtUserCode.MaxLength = 8;
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(165, 21);
            this.txtUserCode.TabIndex = 11;
            // 
            // SetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 118);
            this.Controls.Add(this.txtUserCode);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtRetypePwd);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Password";
            this.Load += new System.EventHandler(this.SetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtNewPwd;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtRetypePwd;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtUserCode;


    }
}