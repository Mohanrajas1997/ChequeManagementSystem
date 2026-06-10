namespace CheckManagementSystem
{
    partial class ReviewCheckAmount
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
            this.dtgvReviewAmount = new System.Windows.Forms.DataGridView();
            this.a = new System.Windows.Forms.Panel();
            this.lblreview = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnverify = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvReviewAmount)).BeginInit();
            this.a.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvReviewAmount
            // 
            this.dtgvReviewAmount.AllowUserToAddRows = false;
            this.dtgvReviewAmount.AllowUserToDeleteRows = false;
            this.dtgvReviewAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvReviewAmount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvReviewAmount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvReviewAmount.Location = new System.Drawing.Point(0, 43);
            this.dtgvReviewAmount.Name = "dtgvReviewAmount";
            this.dtgvReviewAmount.Size = new System.Drawing.Size(552, 414);
            this.dtgvReviewAmount.TabIndex = 0;
            this.dtgvReviewAmount.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvReviewAmount_CellEndEdit);
            this.dtgvReviewAmount.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgvReviewAmount_EditingControlShowing);
            // 
            // a
            // 
            this.a.Controls.Add(this.lblreview);
            this.a.Dock = System.Windows.Forms.DockStyle.Top;
            this.a.Location = new System.Drawing.Point(0, 0);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(552, 27);
            this.a.TabIndex = 1;
            // 
            // lblreview
            // 
            this.lblreview.AutoSize = true;
            this.lblreview.Location = new System.Drawing.Point(7, 7);
            this.lblreview.Name = "lblreview";
            this.lblreview.Size = new System.Drawing.Size(231, 15);
            this.lblreview.TabIndex = 0;
            this.lblreview.Text = "Review Checks Account No With Amount";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnverify);
            this.panel2.Controls.Add(this.btnclose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 38);
            this.panel2.TabIndex = 2;
            // 
            // btnverify
            // 
            this.btnverify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnverify.Location = new System.Drawing.Point(359, 3);
            this.btnverify.Name = "btnverify";
            this.btnverify.Size = new System.Drawing.Size(69, 25);
            this.btnverify.TabIndex = 1;
            this.btnverify.Text = "Verify";
            this.btnverify.UseVisualStyleBackColor = true;
            this.btnverify.Click += new System.EventHandler(this.btnverify_Click);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.Location = new System.Drawing.Point(434, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(78, 25);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // ReviewCheckAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(552, 498);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.a);
            this.Controls.Add(this.dtgvReviewAmount);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReviewCheckAmount";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                   ";
            this.Load += new System.EventHandler(this.ReviewCheckAmount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvReviewAmount)).EndInit();
            this.a.ResumeLayout(false);
            this.a.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvReviewAmount;
        private System.Windows.Forms.Panel a;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnverify;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label lblreview;
    }
}