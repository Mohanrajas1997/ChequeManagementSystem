namespace CheckManagementSystem
{
    partial class CMSMaker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMSMaker));
            this.gvscanlist = new System.Windows.Forms.DataGridView();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depo_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblscnlst = new System.Windows.Forms.Label();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // gvscanlist
            // 
            this.gvscanlist.AllowUserToAddRows = false;
            this.gvscanlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvscanlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batch_no,
            this.chk_count,
            this.batch_amount,
            this.depo_slip_no,
            this.cust_code});
            this.gvscanlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvscanlist.Location = new System.Drawing.Point(0, 28);
            this.gvscanlist.Name = "gvscanlist";
            this.gvscanlist.ReadOnly = true;
            this.gvscanlist.Size = new System.Drawing.Size(807, 538);
            this.gvscanlist.TabIndex = 12;
            this.gvscanlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvscanlist_CellClick);
            this.gvscanlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvscanlist_KeyDown);
            // 
            // batch_no
            // 
            this.batch_no.HeaderText = "Batch No.";
            this.batch_no.Name = "batch_no";
            this.batch_no.ReadOnly = true;
            // 
            // chk_count
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chk_count.DefaultCellStyle = dataGridViewCellStyle1;
            this.chk_count.HeaderText = "Chq Count";
            this.chk_count.Name = "chk_count";
            this.chk_count.ReadOnly = true;
            // 
            // batch_amount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.batch_amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.batch_amount.HeaderText = "Batch Amount";
            this.batch_amount.Name = "batch_amount";
            this.batch_amount.ReadOnly = true;
            // 
            // depo_slip_no
            // 
            this.depo_slip_no.HeaderText = "Dep Slip No.";
            this.depo_slip_no.Name = "depo_slip_no";
            this.depo_slip_no.ReadOnly = true;
            // 
            // cust_code
            // 
            this.cust_code.HeaderText = "Cust Code/ Name";
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 28);
            this.panel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scanned Batch List";
            // 
            // lblscnlst
            // 
            this.lblscnlst.AutoSize = true;
            this.lblscnlst.Location = new System.Drawing.Point(5, 1);
            this.lblscnlst.Name = "lblscnlst";
            this.lblscnlst.Size = new System.Drawing.Size(70, 14);
            this.lblscnlst.TabIndex = 13;
            this.lblscnlst.Text = "Scan Listing";
            // 
            // PicLoad
            // 
            this.PicLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PicLoad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PicLoad.Image = ((System.Drawing.Image)(resources.GetObject("PicLoad.Image")));
            this.PicLoad.Location = new System.Drawing.Point(305, 193);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(156, 123);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 39;
            this.PicLoad.TabStop = false;
            this.PicLoad.Visible = false;
            // 
            // CMSMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 566);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.gvscanlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblscnlst);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CMSMaker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CMSMaker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvscanlist)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvscanlist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblscnlst;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn depo_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.PictureBox PicLoad;

    }
}