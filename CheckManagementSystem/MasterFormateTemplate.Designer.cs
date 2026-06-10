namespace CheckManagementSystem
{
    partial class MasterFormateTemplate
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
            this.BMGridView1 = new System.Windows.Forms.DataGridView();
            this.seq_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.field_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabMasters = new System.Windows.Forms.TabControl();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LMcomboBox1 = new System.Windows.Forms.ComboBox();
            this.BRMcomboBox1 = new System.Windows.Forms.ComboBox();
            this.CMcomboBox1 = new System.Windows.Forms.ComboBox();
            this.CWDcomboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_type = new System.Windows.Forms.Label();
            this.AMcomboBox1 = new System.Windows.Forms.ComboBox();
            this.BMcomboBox1 = new System.Windows.Forms.ComboBox();
            this.BRMGridView1 = new System.Windows.Forms.DataGridView();
            this.seq_no1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.field_name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.length1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bradd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LMGridView1 = new System.Windows.Forms.DataGridView();
            this.seq_no2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.field_name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.length2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmadd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CMGridView1 = new System.Windows.Forms.DataGridView();
            this.seq_no3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.field_name3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.length3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AMGridView1 = new System.Windows.Forms.DataGridView();
            this.seq_no4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.field_name4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.length4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CWDGridView1 = new System.Windows.Forms.DataGridView();
            this.seq_no5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.field_name5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.length5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BMGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BRMGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CWDGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BMGridView1
            // 
            this.BMGridView1.AllowUserToAddRows = false;
            this.BMGridView1.AllowUserToDeleteRows = false;
            this.BMGridView1.AllowUserToOrderColumns = true;
            this.BMGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BMGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BMGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BMGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq_no,
            this.field_name,
            this.data_type,
            this.length,
            this.Add});
            this.BMGridView1.Location = new System.Drawing.Point(94, 73);
            this.BMGridView1.Name = "BMGridView1";
            this.BMGridView1.Size = new System.Drawing.Size(605, 224);
            this.BMGridView1.TabIndex = 11;
            this.BMGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BMGridView1_CellClick);
            this.BMGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.BMGridView1_EditingControlShowing);
            // 
            // seq_no
            // 
            this.seq_no.HeaderText = "Seq No";
            this.seq_no.Name = "seq_no";
            this.seq_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // field_name
            // 
            this.field_name.HeaderText = "Field Name";
            this.field_name.Name = "field_name";
            this.field_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // data_type
            // 
            this.data_type.HeaderText = "Type";
            this.data_type.Items.AddRange(new object[] {
            "Numeric",
            "AlphaNumeric"});
            this.data_type.Name = "data_type";
            this.data_type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // length
            // 
            this.length.HeaderText = "Length";
            this.length.Name = "length";
            this.length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Add
            // 
            this.Add.HeaderText = "Add";
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.Text = "Add";
            this.Add.UseColumnTextForButtonValue = true;
            // 
            // tabMasters
            // 
            this.tabMasters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMasters.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMasters.Location = new System.Drawing.Point(5, 12);
            this.tabMasters.Name = "tabMasters";
            this.tabMasters.SelectedIndex = 0;
            this.tabMasters.Size = new System.Drawing.Size(774, 464);
            this.tabMasters.TabIndex = 3;
            this.tabMasters.SelectedIndexChanged += new System.EventHandler(this.tabMasters_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(335, 19);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 31);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "&Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(427, 19);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 31);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "&Close";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LMcomboBox1);
            this.panel1.Controls.Add(this.BRMcomboBox1);
            this.panel1.Controls.Add(this.CMcomboBox1);
            this.panel1.Controls.Add(this.CWDcomboBox1);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.lbl_type);
            this.panel1.Controls.Add(this.AMcomboBox1);
            this.panel1.Controls.Add(this.BMcomboBox1);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Location = new System.Drawing.Point(94, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 63);
            this.panel1.TabIndex = 14;
            // 
            // LMcomboBox1
            // 
            this.LMcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LMcomboBox1.FormattingEnabled = true;
            this.LMcomboBox1.Items.AddRange(new object[] {
            "--Select--",
            "Incremental",
            "Fresh"});
            this.LMcomboBox1.Location = new System.Drawing.Point(109, 20);
            this.LMcomboBox1.Name = "LMcomboBox1";
            this.LMcomboBox1.Size = new System.Drawing.Size(140, 23);
            this.LMcomboBox1.TabIndex = 22;
            // 
            // BRMcomboBox1
            // 
            this.BRMcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BRMcomboBox1.FormattingEnabled = true;
            this.BRMcomboBox1.Items.AddRange(new object[] {
            "--Select--",
            "Incremental",
            "Fresh"});
            this.BRMcomboBox1.Location = new System.Drawing.Point(109, 19);
            this.BRMcomboBox1.Name = "BRMcomboBox1";
            this.BRMcomboBox1.Size = new System.Drawing.Size(140, 23);
            this.BRMcomboBox1.TabIndex = 23;
            // 
            // CMcomboBox1
            // 
            this.CMcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMcomboBox1.FormattingEnabled = true;
            this.CMcomboBox1.Items.AddRange(new object[] {
            "--Select--",
            "Incremental",
            "Fresh"});
            this.CMcomboBox1.Location = new System.Drawing.Point(109, 20);
            this.CMcomboBox1.Name = "CMcomboBox1";
            this.CMcomboBox1.Size = new System.Drawing.Size(140, 23);
            this.CMcomboBox1.TabIndex = 24;
            // 
            // CWDcomboBox1
            // 
            this.CWDcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CWDcomboBox1.FormattingEnabled = true;
            this.CWDcomboBox1.Items.AddRange(new object[] {
            "--Select--",
            "Incremental",
            "Fresh"});
            this.CWDcomboBox1.Location = new System.Drawing.Point(109, 20);
            this.CWDcomboBox1.Name = "CWDcomboBox1";
            this.CWDcomboBox1.Size = new System.Drawing.Size(140, 23);
            this.CWDcomboBox1.TabIndex = 26;
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_type.Location = new System.Drawing.Point(12, 22);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(74, 15);
            this.lbl_type.TabIndex = 16;
            this.lbl_type.Text = "Upload Type";
            // 
            // AMcomboBox1
            // 
            this.AMcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AMcomboBox1.FormattingEnabled = true;
            this.AMcomboBox1.Items.AddRange(new object[] {
            "--Select--",
            "Incremental",
            "Fresh"});
            this.AMcomboBox1.Location = new System.Drawing.Point(109, 19);
            this.AMcomboBox1.Name = "AMcomboBox1";
            this.AMcomboBox1.Size = new System.Drawing.Size(140, 23);
            this.AMcomboBox1.TabIndex = 25;
            // 
            // BMcomboBox1
            // 
            this.BMcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BMcomboBox1.FormattingEnabled = true;
            this.BMcomboBox1.Items.AddRange(new object[] {
            "--Select--",
            "Incremental",
            "Fresh"});
            this.BMcomboBox1.Location = new System.Drawing.Point(109, 19);
            this.BMcomboBox1.Name = "BMcomboBox1";
            this.BMcomboBox1.Size = new System.Drawing.Size(140, 23);
            this.BMcomboBox1.TabIndex = 15;
            // 
            // BRMGridView1
            // 
            this.BRMGridView1.AllowUserToAddRows = false;
            this.BRMGridView1.AllowUserToDeleteRows = false;
            this.BRMGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BRMGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BRMGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BRMGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq_no1,
            this.field_name1,
            this.data_type1,
            this.length1,
            this.bradd});
            this.BRMGridView1.Location = new System.Drawing.Point(94, 73);
            this.BRMGridView1.Name = "BRMGridView1";
            this.BRMGridView1.Size = new System.Drawing.Size(605, 224);
            this.BRMGridView1.TabIndex = 17;
            this.BRMGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BRMGridView1_CellClick);
            this.BRMGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.BRMGridView1_EditingControlShowing);
            // 
            // seq_no1
            // 
            this.seq_no1.HeaderText = "Seq No";
            this.seq_no1.Name = "seq_no1";
            this.seq_no1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // field_name1
            // 
            this.field_name1.HeaderText = "Field Name";
            this.field_name1.Name = "field_name1";
            this.field_name1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // data_type1
            // 
            this.data_type1.HeaderText = "Type";
            this.data_type1.Items.AddRange(new object[] {
            "Numeric ",
            "AlphaNumeric"});
            this.data_type1.Name = "data_type1";
            this.data_type1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_type1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // length1
            // 
            this.length1.HeaderText = "Length";
            this.length1.Name = "length1";
            this.length1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // bradd
            // 
            this.bradd.HeaderText = "Add";
            this.bradd.Name = "bradd";
            this.bradd.Text = "Add";
            this.bradd.UseColumnTextForButtonValue = true;
            // 
            // LMGridView1
            // 
            this.LMGridView1.AllowUserToAddRows = false;
            this.LMGridView1.AllowUserToDeleteRows = false;
            this.LMGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LMGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LMGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LMGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq_no2,
            this.field_name2,
            this.data_type2,
            this.length2,
            this.lmadd});
            this.LMGridView1.Location = new System.Drawing.Point(94, 73);
            this.LMGridView1.Name = "LMGridView1";
            this.LMGridView1.Size = new System.Drawing.Size(605, 224);
            this.LMGridView1.TabIndex = 18;
            this.LMGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LMGridView1_CellClick);
            this.LMGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.LMGridView1_EditingControlShowing);
            // 
            // seq_no2
            // 
            this.seq_no2.HeaderText = "Seq No";
            this.seq_no2.Name = "seq_no2";
            this.seq_no2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // field_name2
            // 
            this.field_name2.HeaderText = "Field Name";
            this.field_name2.Name = "field_name2";
            this.field_name2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // data_type2
            // 
            this.data_type2.HeaderText = "Type";
            this.data_type2.Items.AddRange(new object[] {
            "Numeric\t",
            "AlphaNumeric"});
            this.data_type2.Name = "data_type2";
            this.data_type2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_type2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // length2
            // 
            this.length2.HeaderText = "Length";
            this.length2.Name = "length2";
            this.length2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lmadd
            // 
            this.lmadd.HeaderText = "Add";
            this.lmadd.Name = "lmadd";
            this.lmadd.Text = "Add";
            this.lmadd.UseColumnTextForButtonValue = true;
            // 
            // CMGridView1
            // 
            this.CMGridView1.AllowUserToAddRows = false;
            this.CMGridView1.AllowUserToDeleteRows = false;
            this.CMGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CMGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CMGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CMGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq_no3,
            this.field_name3,
            this.data_type3,
            this.length3,
            this.add3});
            this.CMGridView1.Location = new System.Drawing.Point(94, 73);
            this.CMGridView1.Name = "CMGridView1";
            this.CMGridView1.Size = new System.Drawing.Size(605, 224);
            this.CMGridView1.TabIndex = 19;
            this.CMGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CMGridView1_CellClick);
            this.CMGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.CMGridView1_EditingControlShowing);
            // 
            // seq_no3
            // 
            this.seq_no3.HeaderText = "Seq No";
            this.seq_no3.Name = "seq_no3";
            this.seq_no3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // field_name3
            // 
            this.field_name3.HeaderText = "Field Name";
            this.field_name3.Name = "field_name3";
            this.field_name3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // data_type3
            // 
            this.data_type3.HeaderText = "Type";
            this.data_type3.Items.AddRange(new object[] {
            "Numeric",
            "AlphaNumeric"});
            this.data_type3.Name = "data_type3";
            this.data_type3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_type3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // length3
            // 
            this.length3.HeaderText = "Length";
            this.length3.Name = "length3";
            this.length3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // add3
            // 
            this.add3.HeaderText = "Add";
            this.add3.Name = "add3";
            this.add3.Text = "Add";
            this.add3.UseColumnTextForButtonValue = true;
            // 
            // AMGridView1
            // 
            this.AMGridView1.AllowUserToAddRows = false;
            this.AMGridView1.AllowUserToDeleteRows = false;
            this.AMGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AMGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AMGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AMGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq_no4,
            this.field_name4,
            this.data_type4,
            this.length4});
            this.AMGridView1.Location = new System.Drawing.Point(94, 73);
            this.AMGridView1.Name = "AMGridView1";
            this.AMGridView1.Size = new System.Drawing.Size(605, 224);
            this.AMGridView1.TabIndex = 20;
            this.AMGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AMGridView1_CellClick);
            this.AMGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.AMGridView1_EditingControlShowing);
            // 
            // seq_no4
            // 
            this.seq_no4.HeaderText = "Seq No";
            this.seq_no4.Name = "seq_no4";
            this.seq_no4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // field_name4
            // 
            this.field_name4.HeaderText = "Field Name";
            this.field_name4.Name = "field_name4";
            this.field_name4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // data_type4
            // 
            this.data_type4.HeaderText = "Type";
            this.data_type4.Items.AddRange(new object[] {
            "Numeric",
            "AlphaNumeric"});
            this.data_type4.Name = "data_type4";
            this.data_type4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_type4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // length4
            // 
            this.length4.HeaderText = "Length";
            this.length4.Name = "length4";
            this.length4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CWDGridView1
            // 
            this.CWDGridView1.AllowUserToAddRows = false;
            this.CWDGridView1.AllowUserToDeleteRows = false;
            this.CWDGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CWDGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CWDGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CWDGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq_no5,
            this.field_name5,
            this.data_type5,
            this.length5});
            this.CWDGridView1.Location = new System.Drawing.Point(94, 73);
            this.CWDGridView1.Name = "CWDGridView1";
            this.CWDGridView1.Size = new System.Drawing.Size(605, 224);
            this.CWDGridView1.TabIndex = 21;
            this.CWDGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CWDGridView1_CellContentClick);
            this.CWDGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.CWDGridView1_EditingControlShowing);
            // 
            // seq_no5
            // 
            this.seq_no5.HeaderText = "Seq No";
            this.seq_no5.Name = "seq_no5";
            this.seq_no5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // field_name5
            // 
            this.field_name5.HeaderText = "Field Name";
            this.field_name5.Name = "field_name5";
            this.field_name5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // data_type5
            // 
            this.data_type5.HeaderText = "Type";
            this.data_type5.Items.AddRange(new object[] {
            "Numeric",
            "AlphaNumeric"});
            this.data_type5.Name = "data_type5";
            this.data_type5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_type5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // length5
            // 
            this.length5.HeaderText = "Length";
            this.length5.Name = "length5";
            this.length5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // MasterFormateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 529);
            this.Controls.Add(this.CWDGridView1);
            this.Controls.Add(this.AMGridView1);
            this.Controls.Add(this.CMGridView1);
            this.Controls.Add(this.LMGridView1);
            this.Controls.Add(this.BRMGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BMGridView1);
            this.Controls.Add(this.tabMasters);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MasterFormateTemplate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MasterFormateTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BMGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BRMGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CWDGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BMGridView1;
        private System.Windows.Forms.TabControl tabMasters;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox BMcomboBox1;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.DataGridView BRMGridView1;
        private System.Windows.Forms.DataGridView LMGridView1;
        private System.Windows.Forms.DataGridView CMGridView1;
        private System.Windows.Forms.DataGridView AMGridView1;
        private System.Windows.Forms.DataGridView CWDGridView1;
        private System.Windows.Forms.ComboBox LMcomboBox1;
        private System.Windows.Forms.ComboBox BRMcomboBox1;
        private System.Windows.Forms.ComboBox CMcomboBox1;
        private System.Windows.Forms.ComboBox AMcomboBox1;
        private System.Windows.Forms.ComboBox CWDcomboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq_no4;
        private System.Windows.Forms.DataGridViewTextBoxColumn field_name4;
        private System.Windows.Forms.DataGridViewComboBoxColumn data_type4;
        private System.Windows.Forms.DataGridViewTextBoxColumn length4;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq_no5;
        private System.Windows.Forms.DataGridViewTextBoxColumn field_name5;
        private System.Windows.Forms.DataGridViewComboBoxColumn data_type5;
        private System.Windows.Forms.DataGridViewTextBoxColumn length5;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn field_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn data_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq_no1;
        private System.Windows.Forms.DataGridViewTextBoxColumn field_name1;
        private System.Windows.Forms.DataGridViewComboBoxColumn data_type1;
        private System.Windows.Forms.DataGridViewTextBoxColumn length1;
        private System.Windows.Forms.DataGridViewButtonColumn bradd;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq_no3;
        private System.Windows.Forms.DataGridViewTextBoxColumn field_name3;
        private System.Windows.Forms.DataGridViewComboBoxColumn data_type3;
        private System.Windows.Forms.DataGridViewTextBoxColumn length3;
        private System.Windows.Forms.DataGridViewButtonColumn add3;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq_no2;
        private System.Windows.Forms.DataGridViewTextBoxColumn field_name2;
        private System.Windows.Forms.DataGridViewComboBoxColumn data_type2;
        private System.Windows.Forms.DataGridViewTextBoxColumn length2;
        private System.Windows.Forms.DataGridViewButtonColumn lmadd;
    }
}