namespace CheckManagementSystem
{
    partial class Scanner
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
            this.grdvwBactchlist = new System.Windows.Forms.DataGridView();
            this.batch_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depo_slip_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdvwBactchlist)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdvwBactchlist
            // 
            this.grdvwBactchlist.AllowUserToAddRows = false;
            this.grdvwBactchlist.AllowUserToDeleteRows = false;
            this.grdvwBactchlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdvwBactchlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdvwBactchlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batch_no,
            this.chk_count,
            this.batch_amount,
            this.depo_slip_no,
            this.cust_code,
            this.action});
            this.grdvwBactchlist.Location = new System.Drawing.Point(1, 35);
            this.grdvwBactchlist.Name = "grdvwBactchlist";
            this.grdvwBactchlist.ReadOnly = true;
            this.grdvwBactchlist.Size = new System.Drawing.Size(908, 536);
            this.grdvwBactchlist.TabIndex = 3;
            this.grdvwBactchlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdvwBactchlist_CellClick);
            this.grdvwBactchlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdvwBactchlist_KeyDown);
            // 
            // batch_no
            // 
            this.batch_no.HeaderText = "Batch No.";
            this.batch_no.Name = "batch_no";
            this.batch_no.ReadOnly = true;
            // 
            // chk_count
            // 
            this.chk_count.HeaderText = "Chq Count";
            this.chk_count.Name = "chk_count";
            this.chk_count.ReadOnly = true;
            // 
            // batch_amount
            // 
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
            // action
            // 
            this.action.HeaderText = "Action";
            this.action.Name = "action";
            this.action.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 29);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scanning Batch List";
            this.label1.Visible = false;
            // 
            // Scanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdvwBactchlist);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Scanner";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Scanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvwBactchlist)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdvwBactchlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn depo_slip_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn action;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

    }
}