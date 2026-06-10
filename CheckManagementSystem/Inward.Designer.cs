namespace CheckManagementSystem
{
    partial class Inward
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
            this.Remark_Txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.chqcnt = new System.Windows.Forms.TextBox();
            this.cmblocation = new System.Windows.Forms.ComboBox();
            this.cmbbrcode = new System.Windows.Forms.ComboBox();
            this.lblbrcode = new System.Windows.Forms.Label();
            this.lblpickuplocation = new System.Windows.Forms.Label();
            this.lblcheckcount = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Remark_Txt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.chqcnt);
            this.panel1.Controls.Add(this.cmblocation);
            this.panel1.Controls.Add(this.cmbbrcode);
            this.panel1.Controls.Add(this.lblbrcode);
            this.panel1.Controls.Add(this.lblpickuplocation);
            this.panel1.Controls.Add(this.lblcheckcount);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lbldatetime);
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 251);
            this.panel1.TabIndex = 0;
            // 
            // Remark_Txt
            // 
            this.Remark_Txt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remark_Txt.Location = new System.Drawing.Point(111, 94);
            this.Remark_Txt.MaxLength = 255;
            this.Remark_Txt.Name = "Remark_Txt";
            this.Remark_Txt.Size = new System.Drawing.Size(336, 21);
            this.Remark_Txt.TabIndex = 3;
            this.Remark_Txt.TextChanged += new System.EventHandler(this.Remark_Txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Remarks";
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(372, 132);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "&Close";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(292, 132);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 4;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // chqcnt
            // 
            this.chqcnt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chqcnt.Location = new System.Drawing.Point(326, 10);
            this.chqcnt.MaxLength = 5;
            this.chqcnt.Name = "chqcnt";
            this.chqcnt.Size = new System.Drawing.Size(121, 21);
            this.chqcnt.TabIndex = 0;
            this.chqcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chqcnt.TextChanged += new System.EventHandler(this.chqcnt_TextChanged);
            this.chqcnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chqcnt_KeyPress_1);
            // 
            // cmblocation
            // 
            this.cmblocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmblocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmblocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.FormattingEnabled = true;
            this.cmblocation.Location = new System.Drawing.Point(111, 67);
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.Size = new System.Drawing.Size(336, 21);
            this.cmblocation.TabIndex = 2;
            this.cmblocation.SelectedIndexChanged += new System.EventHandler(this.cmblocation_SelectedIndexChanged);
            // 
            // cmbbrcode
            // 
            this.cmbbrcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbbrcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbbrcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbrcode.FormattingEnabled = true;
            this.cmbbrcode.Location = new System.Drawing.Point(111, 37);
            this.cmbbrcode.Name = "cmbbrcode";
            this.cmbbrcode.Size = new System.Drawing.Size(336, 21);
            this.cmbbrcode.TabIndex = 1;
            this.cmbbrcode.SelectedIndexChanged += new System.EventHandler(this.cmbbrcode_SelectedIndexChanged);
            this.cmbbrcode.TabIndexChanged += new System.EventHandler(this.cmbbrcode_TabIndexChanged);
            this.cmbbrcode.TextChanged += new System.EventHandler(this.cmbbrcode_TextChanged);
            this.cmbbrcode.Leave += new System.EventHandler(this.cmbbrcode_Leave);
            // 
            // lblbrcode
            // 
            this.lblbrcode.AutoSize = true;
            this.lblbrcode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbrcode.Location = new System.Drawing.Point(11, 43);
            this.lblbrcode.Name = "lblbrcode";
            this.lblbrcode.Size = new System.Drawing.Size(81, 13);
            this.lblbrcode.TabIndex = 8;
            this.lblbrcode.Text = "Branch Name";
            // 
            // lblpickuplocation
            // 
            this.lblpickuplocation.AutoSize = true;
            this.lblpickuplocation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpickuplocation.Location = new System.Drawing.Point(9, 70);
            this.lblpickuplocation.Name = "lblpickuplocation";
            this.lblpickuplocation.Size = new System.Drawing.Size(96, 13);
            this.lblpickuplocation.TabIndex = 7;
            this.lblpickuplocation.Text = "PickUp Location";
            // 
            // lblcheckcount
            // 
            this.lblcheckcount.AutoSize = true;
            this.lblcheckcount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcheckcount.Location = new System.Drawing.Point(257, 13);
            this.lblcheckcount.Name = "lblcheckcount";
            this.lblcheckcount.Size = new System.Drawing.Size(64, 13);
            this.lblcheckcount.TabIndex = 6;
            this.lblcheckcount.Text = "Chq Count";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatetime.Location = new System.Drawing.Point(11, 14);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(65, 13);
            this.lbldatetime.TabIndex = 0;
            this.lbldatetime.Text = "Date Time";
            // 
            // Inward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 175);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inward";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inward Entry";
            this.Load += new System.EventHandler(this.Inward_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inward_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbbrcode;
        private System.Windows.Forms.Label lblbrcode;
        private System.Windows.Forms.Label lblpickuplocation;
        private System.Windows.Forms.Label lblcheckcount;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.ComboBox cmblocation;
        private System.Windows.Forms.TextBox chqcnt;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox Remark_Txt;
        private System.Windows.Forms.Label label1;
    }
}