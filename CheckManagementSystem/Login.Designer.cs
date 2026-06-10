namespace CheckManagementSystem
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_pswd = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pswd = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_frg_pswd = new System.Windows.Forms.Label();
            this.btncrt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_user.AutoSize = true;
            this.lbl_user.BackColor = System.Drawing.Color.Transparent;
            this.lbl_user.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user.ForeColor = System.Drawing.Color.Gold;
            this.lbl_user.Location = new System.Drawing.Point(389, 261);
            this.lbl_user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(134, 21);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "User Name :";
            // 
            // lbl_pswd
            // 
            this.lbl_pswd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_pswd.AutoSize = true;
            this.lbl_pswd.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pswd.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pswd.ForeColor = System.Drawing.Color.Gold;
            this.lbl_pswd.Location = new System.Drawing.Point(390, 300);
            this.lbl_pswd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pswd.Name = "lbl_pswd";
            this.lbl_pswd.Size = new System.Drawing.Size(133, 21);
            this.lbl_pswd.TabIndex = 1;
            this.lbl_pswd.Text = "Password  :";
            // 
            // txt_user
            // 
            this.txt_user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_user.BackColor = System.Drawing.Color.Wheat;
            this.txt_user.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Location = new System.Drawing.Point(530, 259);
            this.txt_user.Margin = new System.Windows.Forms.Padding(4);
            this.txt_user.MaxLength = 10;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(137, 31);
            this.txt_user.TabIndex = 2;
            // 
            // txt_pswd
            // 
            this.txt_pswd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_pswd.BackColor = System.Drawing.Color.Wheat;
            this.txt_pswd.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pswd.Location = new System.Drawing.Point(530, 300);
            this.txt_pswd.Margin = new System.Windows.Forms.Padding(4);
            this.txt_pswd.MaxLength = 10;
            this.txt_pswd.Name = "txt_pswd";
            this.txt_pswd.PasswordChar = '*';
            this.txt_pswd.Size = new System.Drawing.Size(137, 31);
            this.txt_pswd.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_login.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_login.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_login.Location = new System.Drawing.Point(602, 341);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(65, 32);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_frg_pswd
            // 
            this.btn_frg_pswd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_frg_pswd.AutoSize = true;
            this.btn_frg_pswd.BackColor = System.Drawing.Color.IndianRed;
            this.btn_frg_pswd.ForeColor = System.Drawing.Color.Blue;
            this.btn_frg_pswd.Location = new System.Drawing.Point(531, 382);
            this.btn_frg_pswd.Name = "btn_frg_pswd";
            this.btn_frg_pswd.Size = new System.Drawing.Size(123, 19);
            this.btn_frg_pswd.TabIndex = 5;
            this.btn_frg_pswd.Text = "Forgot Password";
            // 
            // btncrt
            // 
            this.btncrt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncrt.BackColor = System.Drawing.SystemColors.Desktop;
            this.btncrt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncrt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncrt.Location = new System.Drawing.Point(530, 341);
            this.btncrt.Margin = new System.Windows.Forms.Padding(4);
            this.btncrt.Name = "btncrt";
            this.btncrt.Size = new System.Drawing.Size(65, 32);
            this.btncrt.TabIndex = 6;
            this.btncrt.Text = "Create";
            this.btncrt.UseVisualStyleBackColor = false;
            this.btncrt.Visible = false;
            this.btncrt.Click += new System.EventHandler(this.btncrt_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1074, 604);
            this.Controls.Add(this.btncrt);
            this.Controls.Add(this.btn_frg_pswd);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_pswd);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.lbl_pswd);
            this.Controls.Add(this.lbl_user);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_pswd;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pswd;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label btn_frg_pswd;
        private System.Windows.Forms.Button btncrt;
    }
}