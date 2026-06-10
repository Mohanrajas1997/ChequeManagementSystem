namespace CheckManagementSystem
{
    partial class frmMain
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserCreation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUserGrp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserGrpRights = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUserLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImagepurge = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTran = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInward = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatching = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScanning = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMaker = new System.Windows.Forms.ToolStripMenuItem();
            this.checkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMicrUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRejectionHandling = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMasterReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccountMaterRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLocationMasterRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMicrMasterRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomerMasterRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlternateMicrRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInwardRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatchRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChequeRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUploadRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRejectionRpt = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdmin,
            this.mnuMaintenance,
            this.mnuTran,
            this.mnuReport,
            this.WindowsMenu,
            this.mnuExit});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.MdiWindowListItem = this.WindowsMenu;
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // mnuAdmin
            // 
            this.mnuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserCreation,
            this.mnuSetPassword,
            this.ToolStripMenuItem9,
            this.mnuUserGrp,
            this.mnuUserGrpRights,
            this.ToolStripMenuItem10,
            this.mnuUserLog,
            this.menuImagepurge});
            this.mnuAdmin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuAdmin.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.mnuAdmin.Name = "mnuAdmin";
            this.mnuAdmin.Size = new System.Drawing.Size(55, 20);
            this.mnuAdmin.Text = "Admin";
            // 
            // mnuUserCreation
            // 
            this.mnuUserCreation.Name = "mnuUserCreation";
            this.mnuUserCreation.Size = new System.Drawing.Size(176, 22);
            this.mnuUserCreation.Text = "User Creation";
            this.mnuUserCreation.Click += new System.EventHandler(this.mnuUserCreation_Click);
            // 
            // mnuSetPassword
            // 
            this.mnuSetPassword.Name = "mnuSetPassword";
            this.mnuSetPassword.Size = new System.Drawing.Size(176, 22);
            this.mnuSetPassword.Text = "Set Password";
            this.mnuSetPassword.Click += new System.EventHandler(this.mnuSetPassword_Click);
            // 
            // ToolStripMenuItem9
            // 
            this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
            this.ToolStripMenuItem9.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuUserGrp
            // 
            this.mnuUserGrp.Name = "mnuUserGrp";
            this.mnuUserGrp.Size = new System.Drawing.Size(176, 22);
            this.mnuUserGrp.Text = "User Group";
            this.mnuUserGrp.Click += new System.EventHandler(this.mnuUserGroup_Click);
            // 
            // mnuUserGrpRights
            // 
            this.mnuUserGrpRights.Name = "mnuUserGrpRights";
            this.mnuUserGrpRights.Size = new System.Drawing.Size(176, 22);
            this.mnuUserGrpRights.Text = "User Group Rights";
            this.mnuUserGrpRights.Click += new System.EventHandler(this.mnuUserGrpRights_Click);
            // 
            // ToolStripMenuItem10
            // 
            this.ToolStripMenuItem10.Name = "ToolStripMenuItem10";
            this.ToolStripMenuItem10.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuUserLog
            // 
            this.mnuUserLog.Name = "mnuUserLog";
            this.mnuUserLog.Size = new System.Drawing.Size(176, 22);
            this.mnuUserLog.Text = "User Log";
            this.mnuUserLog.Click += new System.EventHandler(this.mnuUserLog_Click);
            // 
            // menuImagepurge
            // 
            this.menuImagepurge.Name = "menuImagepurge";
            this.menuImagepurge.Size = new System.Drawing.Size(176, 22);
            this.menuImagepurge.Text = "Image Purge";
            this.menuImagepurge.Click += new System.EventHandler(this.menuImagepurge_Click);
            // 
            // mnuMaintenance
            // 
            this.mnuMaintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMasterImport});
            this.mnuMaintenance.Name = "mnuMaintenance";
            this.mnuMaintenance.Size = new System.Drawing.Size(92, 20);
            this.mnuMaintenance.Text = "Maintenance";
            // 
            // mnuMasterImport
            // 
            this.mnuMasterImport.Name = "mnuMasterImport";
            this.mnuMasterImport.Size = new System.Drawing.Size(157, 22);
            this.mnuMasterImport.Text = "Master Import";
            this.mnuMasterImport.Click += new System.EventHandler(this.mnuMasterImport_Click);
            // 
            // mnuTran
            // 
            this.mnuTran.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInward,
            this.mnuBatching,
            this.ToolStripMenuItem3,
            this.mnuScanning,
            this.toolStripSeparator1,
            this.mnuMaker,
            this.checkerToolStripMenuItem,
            this.toolStripSeparator2,
            this.mnuMicrUpdate,
            this.mnuUpload,
            this.mnuRejectionHandling});
            this.mnuTran.Name = "mnuTran";
            this.mnuTran.Size = new System.Drawing.Size(86, 20);
            this.mnuTran.Text = "Transaction";
            this.mnuTran.Click += new System.EventHandler(this.mnuTran_Click);
            // 
            // mnuInward
            // 
            this.mnuInward.Name = "mnuInward";
            this.mnuInward.Size = new System.Drawing.Size(180, 22);
            this.mnuInward.Text = "Inward";
            this.mnuInward.Click += new System.EventHandler(this.mnuInward_Click);
            // 
            // mnuBatching
            // 
            this.mnuBatching.Name = "mnuBatching";
            this.mnuBatching.Size = new System.Drawing.Size(180, 22);
            this.mnuBatching.Text = "Batching";
            this.mnuBatching.Click += new System.EventHandler(this.mnuBatching_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuScanning
            // 
            this.mnuScanning.Name = "mnuScanning";
            this.mnuScanning.Size = new System.Drawing.Size(180, 22);
            this.mnuScanning.Text = "Scanning";
            this.mnuScanning.Click += new System.EventHandler(this.mnuScanning_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuMaker
            // 
            this.mnuMaker.Name = "mnuMaker";
            this.mnuMaker.Size = new System.Drawing.Size(180, 22);
            this.mnuMaker.Text = "Maker";
            this.mnuMaker.Click += new System.EventHandler(this.mnuMaker_Click);
            // 
            // checkerToolStripMenuItem
            // 
            this.checkerToolStripMenuItem.Name = "checkerToolStripMenuItem";
            this.checkerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkerToolStripMenuItem.Text = "Checker";
            this.checkerToolStripMenuItem.Click += new System.EventHandler(this.mnuChecker_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuMicrUpdate
            // 
            this.mnuMicrUpdate.Name = "mnuMicrUpdate";
            this.mnuMicrUpdate.Size = new System.Drawing.Size(180, 22);
            this.mnuMicrUpdate.Text = "Micr Update";
            this.mnuMicrUpdate.Click += new System.EventHandler(this.mnuMicrUpdate_Click);
            // 
            // mnuUpload
            // 
            this.mnuUpload.Name = "mnuUpload";
            this.mnuUpload.Size = new System.Drawing.Size(180, 22);
            this.mnuUpload.Text = "Upload";
            this.mnuUpload.Click += new System.EventHandler(this.mnuUpload_Click);
            // 
            // mnuRejectionHandling
            // 
            this.mnuRejectionHandling.Name = "mnuRejectionHandling";
            this.mnuRejectionHandling.Size = new System.Drawing.Size(180, 22);
            this.mnuRejectionHandling.Text = "Rejection Handling";
            this.mnuRejectionHandling.Click += new System.EventHandler(this.mnuRejectionHandling_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMasterReport,
            this.mnuInwardRpt,
            this.mnuBatchRpt,
            this.mnuChequeRpt,
            this.mnuUploadRpt,
            this.mnuRejectionRpt});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(58, 20);
            this.mnuReport.Text = "Report";
            // 
            // mnuMasterReport
            // 
            this.mnuMasterReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAccountMaterRpt,
            this.mnuLocationMasterRpt,
            this.mnuMicrMasterRpt,
            this.mnuCustomerMasterRpt,
            this.mnuAlternateMicrRpt});
            this.mnuMasterReport.Name = "mnuMasterReport";
            this.mnuMasterReport.Size = new System.Drawing.Size(170, 22);
            this.mnuMasterReport.Text = "Master";
            // 
            // mnuAccountMaterRpt
            // 
            this.mnuAccountMaterRpt.Name = "mnuAccountMaterRpt";
            this.mnuAccountMaterRpt.Size = new System.Drawing.Size(202, 22);
            this.mnuAccountMaterRpt.Text = "Account Master";
            this.mnuAccountMaterRpt.Click += new System.EventHandler(this.mnuAccountMasterRpt_Click);
            // 
            // mnuLocationMasterRpt
            // 
            this.mnuLocationMasterRpt.Name = "mnuLocationMasterRpt";
            this.mnuLocationMasterRpt.Size = new System.Drawing.Size(202, 22);
            this.mnuLocationMasterRpt.Text = "Location Master";
            this.mnuLocationMasterRpt.Click += new System.EventHandler(this.mnuLocationMasterRpt_Click);
            // 
            // mnuMicrMasterRpt
            // 
            this.mnuMicrMasterRpt.Name = "mnuMicrMasterRpt";
            this.mnuMicrMasterRpt.Size = new System.Drawing.Size(202, 22);
            this.mnuMicrMasterRpt.Text = "Micr Master";
            this.mnuMicrMasterRpt.Click += new System.EventHandler(this.mnuMicrMasterRpt_Click);
            // 
            // mnuCustomerMasterRpt
            // 
            this.mnuCustomerMasterRpt.Name = "mnuCustomerMasterRpt";
            this.mnuCustomerMasterRpt.Size = new System.Drawing.Size(202, 22);
            this.mnuCustomerMasterRpt.Text = "Customer Master";
            this.mnuCustomerMasterRpt.Click += new System.EventHandler(this.mnuCustomerMasterRpt_Click);
            // 
            // mnuAlternateMicrRpt
            // 
            this.mnuAlternateMicrRpt.Name = "mnuAlternateMicrRpt";
            this.mnuAlternateMicrRpt.Size = new System.Drawing.Size(202, 22);
            this.mnuAlternateMicrRpt.Text = "Altermate Micr Master";
            this.mnuAlternateMicrRpt.Click += new System.EventHandler(this.mnuAlternateMicrRpt_Click);
            // 
            // mnuInwardRpt
            // 
            this.mnuInwardRpt.Name = "mnuInwardRpt";
            this.mnuInwardRpt.Size = new System.Drawing.Size(170, 22);
            this.mnuInwardRpt.Text = "Inward Report";
            this.mnuInwardRpt.Click += new System.EventHandler(this.mnuInwardRpt_Click);
            // 
            // mnuBatchRpt
            // 
            this.mnuBatchRpt.Name = "mnuBatchRpt";
            this.mnuBatchRpt.Size = new System.Drawing.Size(170, 22);
            this.mnuBatchRpt.Text = "Batch Report";
            this.mnuBatchRpt.Click += new System.EventHandler(this.mnuBatchRpt_Click);
            // 
            // mnuChequeRpt
            // 
            this.mnuChequeRpt.Name = "mnuChequeRpt";
            this.mnuChequeRpt.Size = new System.Drawing.Size(170, 22);
            this.mnuChequeRpt.Text = "Cheque Report";
            this.mnuChequeRpt.Click += new System.EventHandler(this.mnuChequeRpt_Click);
            // 
            // mnuUploadRpt
            // 
            this.mnuUploadRpt.Name = "mnuUploadRpt";
            this.mnuUploadRpt.Size = new System.Drawing.Size(170, 22);
            this.mnuUploadRpt.Text = "Upload Report";
            this.mnuUploadRpt.Click += new System.EventHandler(this.mnuUploadRpt_Click);
            // 
            // mnuRejectionRpt
            // 
            this.mnuRejectionRpt.Name = "mnuRejectionRpt";
            this.mnuRejectionRpt.Size = new System.Drawing.Size(170, 22);
            this.mnuRejectionRpt.Text = "Rejection Report";
            this.mnuRejectionRpt.Click += new System.EventHandler(this.mnuRejectionRpt_Click);
            // 
            // WindowsMenu
            // 
            this.WindowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CascadeToolStripMenuItem,
            this.TileVerticalToolStripMenuItem,
            this.TileHorizontalToolStripMenuItem,
            this.CloseAllToolStripMenuItem,
            this.ArrangeIconsToolStripMenuItem});
            this.WindowsMenu.Name = "WindowsMenu";
            this.WindowsMenu.Size = new System.Drawing.Size(69, 20);
            this.WindowsMenu.Text = "&Windows";
            // 
            // CascadeToolStripMenuItem
            // 
            this.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem";
            this.CascadeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.CascadeToolStripMenuItem.Text = "&Cascade";
            // 
            // TileVerticalToolStripMenuItem
            // 
            this.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem";
            this.TileVerticalToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.TileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            // 
            // TileHorizontalToolStripMenuItem
            // 
            this.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem";
            this.TileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            // 
            // CloseAllToolStripMenuItem
            // 
            this.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem";
            this.CloseAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.CloseAllToolStripMenuItem.Text = "C&lose All";
            // 
            // ArrangeIconsToolStripMenuItem
            // 
            this.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem";
            this.ArrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(40, 20);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.StatusStrip.Location = new System.Drawing.Point(0, 239);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip.Size = new System.Drawing.Size(800, 22);
            this.StatusStrip.TabIndex = 3;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Check Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MenuStrip;
        internal System.Windows.Forms.ToolStripMenuItem mnuAdmin;
        internal System.Windows.Forms.ToolStripMenuItem mnuUserCreation;
        internal System.Windows.Forms.ToolStripMenuItem mnuSetPassword;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem9;
        internal System.Windows.Forms.ToolStripMenuItem mnuUserGrp;
        internal System.Windows.Forms.ToolStripMenuItem mnuUserGrpRights;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem10;
        internal System.Windows.Forms.ToolStripMenuItem mnuUserLog;
        internal System.Windows.Forms.ToolStripMenuItem mnuMaintenance;
        internal System.Windows.Forms.ToolStripMenuItem mnuMasterImport;
        internal System.Windows.Forms.ToolStripMenuItem mnuTran;
        internal System.Windows.Forms.ToolStripMenuItem mnuInward;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem mnuBatching;
        internal System.Windows.Forms.ToolStripMenuItem mnuScanning;
        internal System.Windows.Forms.ToolStripMenuItem mnuReport;
        internal System.Windows.Forms.ToolStripMenuItem mnuMasterReport;
        internal System.Windows.Forms.ToolStripMenuItem mnuInwardRpt;
        internal System.Windows.Forms.ToolStripMenuItem WindowsMenu;
        internal System.Windows.Forms.ToolStripMenuItem CascadeToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TileVerticalToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TileHorizontalToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CloseAllToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ArrangeIconsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ToolStripMenuItem mnuMaker;
        private System.Windows.Forms.ToolStripMenuItem checkerToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem mnuMicrUpdate;
        internal System.Windows.Forms.ToolStripMenuItem mnuUpload;
        internal System.Windows.Forms.ToolStripMenuItem mnuRejectionHandling;
        private System.Windows.Forms.ToolStripMenuItem mnuAccountMaterRpt;
        internal System.Windows.Forms.ToolStripMenuItem mnuLocationMasterRpt;
        internal System.Windows.Forms.ToolStripMenuItem mnuMicrMasterRpt;
        internal System.Windows.Forms.ToolStripMenuItem mnuCustomerMasterRpt;
        internal System.Windows.Forms.ToolStripMenuItem mnuAlternateMicrRpt;
        internal System.Windows.Forms.ToolStripMenuItem mnuBatchRpt;
        private System.Windows.Forms.ToolStripMenuItem mnuChequeRpt;
        internal System.Windows.Forms.ToolStripMenuItem mnuUploadRpt;
        internal System.Windows.Forms.ToolStripMenuItem mnuRejectionRpt;
        internal System.Windows.Forms.StatusStrip StatusStrip;
        internal System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem menuImagepurge;
    }
}