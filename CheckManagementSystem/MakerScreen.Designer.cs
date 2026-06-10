namespace CheckManagementSystem
{
    partial class MakerScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScanCount_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BatchAmount_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChqCount_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chqtype_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CustomerName_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Depslipno_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BatchNo_Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FrontImage = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gvmicrentry = new System.Windows.Forms.DataGridView();
            this.Chq_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheque_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Micr_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tran_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrontImage)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvmicrentry)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batch Detail";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ScanCount_txt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.BatchAmount_txt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ChqCount_txt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chqtype_txt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CustomerName_txt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Depslipno_txt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BatchNo_Txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 65);
            this.panel1.TabIndex = 1;
            // 
            // ScanCount_txt
            // 
            this.ScanCount_txt.Location = new System.Drawing.Point(585, 34);
            this.ScanCount_txt.Name = "ScanCount_txt";
            this.ScanCount_txt.ReadOnly = true;
            this.ScanCount_txt.Size = new System.Drawing.Size(130, 21);
            this.ScanCount_txt.TabIndex = 13;
            this.ScanCount_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Scan Count";
            // 
            // BatchAmount_txt
            // 
            this.BatchAmount_txt.Location = new System.Drawing.Point(364, 34);
            this.BatchAmount_txt.Name = "BatchAmount_txt";
            this.BatchAmount_txt.ReadOnly = true;
            this.BatchAmount_txt.Size = new System.Drawing.Size(130, 21);
            this.BatchAmount_txt.TabIndex = 11;
            this.BatchAmount_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Batch Amount";
            // 
            // ChqCount_txt
            // 
            this.ChqCount_txt.Location = new System.Drawing.Point(98, 35);
            this.ChqCount_txt.Name = "ChqCount_txt";
            this.ChqCount_txt.ReadOnly = true;
            this.ChqCount_txt.Size = new System.Drawing.Size(165, 21);
            this.ChqCount_txt.TabIndex = 9;
            this.ChqCount_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cheque Count";
            // 
            // chqtype_txt
            // 
            this.chqtype_txt.Location = new System.Drawing.Point(364, 7);
            this.chqtype_txt.Name = "chqtype_txt";
            this.chqtype_txt.ReadOnly = true;
            this.chqtype_txt.Size = new System.Drawing.Size(130, 21);
            this.chqtype_txt.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cheque Type";
            // 
            // CustomerName_txt
            // 
            this.CustomerName_txt.Location = new System.Drawing.Point(824, 7);
            this.CustomerName_txt.Name = "CustomerName_txt";
            this.CustomerName_txt.ReadOnly = true;
            this.CustomerName_txt.Size = new System.Drawing.Size(214, 21);
            this.CustomerName_txt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(724, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Customer Name";
            // 
            // Depslipno_txt
            // 
            this.Depslipno_txt.Location = new System.Drawing.Point(585, 7);
            this.Depslipno_txt.Name = "Depslipno_txt";
            this.Depslipno_txt.ReadOnly = true;
            this.Depslipno_txt.Size = new System.Drawing.Size(130, 21);
            this.Depslipno_txt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dep Slip No";
            // 
            // BatchNo_Txt
            // 
            this.BatchNo_Txt.Location = new System.Drawing.Point(98, 7);
            this.BatchNo_Txt.Name = "BatchNo_Txt";
            this.BatchNo_Txt.ReadOnly = true;
            this.BatchNo_Txt.Size = new System.Drawing.Size(165, 21);
            this.BatchNo_Txt.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Batch No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Scanning Image";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.FrontImage);
            this.panel2.Location = new System.Drawing.Point(12, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 278);
            this.panel2.TabIndex = 3;
            // 
            // FrontImage
            // 
            this.FrontImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FrontImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FrontImage.Location = new System.Drawing.Point(3, 3);
            this.FrontImage.Name = "FrontImage";
            this.FrontImage.Size = new System.Drawing.Size(1034, 270);
            this.FrontImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FrontImage.TabIndex = 0;
            this.FrontImage.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 400);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Micr Entry";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.gvmicrentry);
            this.pnlGrid.Location = new System.Drawing.Point(12, 416);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1044, 219);
            this.pnlGrid.TabIndex = 5;
            // 
            // gvmicrentry
            // 
            this.gvmicrentry.AllowUserToAddRows = false;
            this.gvmicrentry.AllowUserToDeleteRows = false;
            this.gvmicrentry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvmicrentry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvmicrentry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvmicrentry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chq_id,
            this.Serial_no,
            this.Cheque_No,
            this.Micr_Code,
            this.Tran_code,
            this.Base_Code});
            this.gvmicrentry.Location = new System.Drawing.Point(3, 3);
            this.gvmicrentry.MultiSelect = false;
            this.gvmicrentry.Name = "gvmicrentry";
            this.gvmicrentry.ReadOnly = true;
            this.gvmicrentry.Size = new System.Drawing.Size(1033, 209);
            this.gvmicrentry.TabIndex = 0;
            this.gvmicrentry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvmicrentry_CellClick);
            this.gvmicrentry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvmicrentry_CellContentClick);
            this.gvmicrentry.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvmicrentry_CellContentDoubleClick);
            this.gvmicrentry.SelectionChanged += new System.EventHandler(this.gvmicrentry_SelectionChanged);
            this.gvmicrentry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvmicrentry_KeyDownClick);
            // 
            // Chq_id
            // 
            this.Chq_id.HeaderText = "ChqId";
            this.Chq_id.Name = "Chq_id";
            this.Chq_id.ReadOnly = true;
            this.Chq_id.Visible = false;
            // 
            // Serial_no
            // 
            this.Serial_no.HeaderText = "Serial No";
            this.Serial_no.Name = "Serial_no";
            this.Serial_no.ReadOnly = true;
            // 
            // Cheque_No
            // 
            this.Cheque_No.HeaderText = "Cheque No";
            this.Cheque_No.Name = "Cheque_No";
            this.Cheque_No.ReadOnly = true;
            // 
            // Micr_Code
            // 
            this.Micr_Code.HeaderText = "Micr Code";
            this.Micr_Code.Name = "Micr_Code";
            this.Micr_Code.ReadOnly = true;
            // 
            // Tran_code
            // 
            this.Tran_code.HeaderText = "Tran Code";
            this.Tran_code.Name = "Tran_code";
            this.Tran_code.ReadOnly = true;
            // 
            // Base_Code
            // 
            this.Base_Code.HeaderText = "Base Code";
            this.Base_Code.Name = "Base_Code";
            this.Base_Code.ReadOnly = true;
            // 
            // MakerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 641);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MakerScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maker Screen";
            this.Activated += new System.EventHandler(this.MakerScreen_Activated);
            this.Load += new System.EventHandler(this.MakerScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FrontImage)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvmicrentry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox BatchNo_Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Depslipno_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CustomerName_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox chqtype_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ChqCount_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BatchAmount_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ScanCount_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox FrontImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView gvmicrentry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chq_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheque_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Micr_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tran_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base_Code;
    }
}