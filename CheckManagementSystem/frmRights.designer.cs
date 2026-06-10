namespace CheckManagementSystem
{
    partial class frmRights
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboUserGrp = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.tvwRights = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point(108, 447);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(353, 13);
            this.lblInfo.TabIndex = 20;
            this.lblInfo.Text = "* When Double Click the Main Menu,Sub Menu will be selected";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chkSelectAll.Location = new System.Drawing.Point(6, 445);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(78, 17);
            this.chkSelectAll.TabIndex = 19;
            this.chkSelectAll.Text = "Selec&t All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(432, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 24);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(332, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 24);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboUserGrp
            // 
            this.cboUserGrp.FormattingEnabled = true;
            this.cboUserGrp.Location = new System.Drawing.Point(99, 7);
            this.cboUserGrp.Name = "cboUserGrp";
            this.cboUserGrp.Size = new System.Drawing.Size(209, 21);
            this.cboUserGrp.TabIndex = 16;
            this.cboUserGrp.TextChanged += new System.EventHandler(this.cboUserGrp_TextChanged);
            this.cboUserGrp.Click += new System.EventHandler(this.cboUser_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 11);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 13);
            this.Label4.TabIndex = 15;
            this.Label4.Text = "User Group";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvwRights
            // 
            this.tvwRights.CheckBoxes = true;
            this.tvwRights.Location = new System.Drawing.Point(6, 37);
            this.tvwRights.Name = "tvwRights";
            this.tvwRights.Size = new System.Drawing.Size(516, 404);
            this.tvwRights.TabIndex = 14;
            this.tvwRights.DoubleClick += new System.EventHandler(this.tvwRights_DoubleClick);
            // 
            // frmRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 463);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboUserGrp);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.tvwRights);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Group Rights";
            this.Load += new System.EventHandler(this.frmRights_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblInfo;
        internal System.Windows.Forms.CheckBox chkSelectAll;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.ComboBox cboUserGrp;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TreeView tvwRights;
    }
}