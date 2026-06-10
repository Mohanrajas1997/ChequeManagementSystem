using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class MasterFormateTemplate : Form
    {

        #region Initialization
        public int comp_id = 0;
        public string selectedTab;
        public int MaxRows = 10;
        int count = 0;
        #endregion

        #region PriavateMethods
        private void LoadGridRows(DataGridView dtgv)
        {
            try
            {
                dtgv.Rows.Add();
                count = dtgv.Rows.Count;
                dtgv.Rows[count - 1].Cells["seq_no"].Value = count;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        public MasterFormateTemplate()
        {
            InitializeComponent();
        }
        public MasterFormateTemplate(int _comp_id, string user_name)
        {
            InitializeComponent();
            comp_id = _comp_id;
        }
        private void CWDGridView1_RowCountChanged(object sender, EventArgs e)
        {
            CheckRowCount();
        }
        private void CheckRowCount()
        {
            if (CWDGridView1.Rows != null && CWDGridView1.Rows.Count > MaxRows)
            {
                CWDGridView1.AllowUserToAddRows = false;
            }
            else if (!CWDGridView1.AllowUserToAddRows)
            {
                CWDGridView1.AllowUserToAddRows = true;
            }
        }
        private void MasterFormateTemplate_Load(object sender, EventArgs e)
        {
            TheamClass.SetTheam(this);
            BMGridView1.Rows.Add();
            BMGridView1.Rows[count].Cells["seq_no"].Value = 1;
            BMGridView1.Columns[0].ReadOnly = true;
            BMcomboBox1.SelectedIndex = 0;
            //BMGridView1.RowCount = 10;
            //BRMGridView1.RowCount = 10;
            //LMGridView1.RowCount = 10;
            //CMGridView1.RowCount = 10;
            //AMGridView1.RowCount = 10;
            //CWDGridView1.RowCount = 10;
            //MBLGridView1.RowCount = 10;

            //BRMGridView1.Rows[0].Cells[0].Value = "BRANCH_NAME";
            //BRMGridView1.Rows[0].Cells[1].Value = "1";
            //BRMGridView1.Rows[0].Cells[2].Value = "AlphaNumeric";
            //BRMGridView1.Rows[0].Cells[3].Value = "250";
            //BRMGridView1.Rows[0].Cells[0].ReadOnly = true;
            //BRMGridView1.Rows[0].Cells[1].ReadOnly = true;
            //BRMGridView1.Rows[0].Cells[2].ReadOnly = true;
            //BRMGridView1.Rows[0].Cells[3].ReadOnly = true;
            //BRMGridView1.Rows[1].Cells[0].Value = "BANK_BRANCH_CODE";
            //BRMGridView1.Rows[1].Cells[1].Value = "2";
            //BRMGridView1.Rows[1].Cells[2].Value = "AlphaNumeric";
            //BRMGridView1.Rows[1].Cells[3].Value = "250";
            //BRMGridView1.Rows[1].Cells[0].ReadOnly = true;
            //BRMGridView1.Rows[1].Cells[1].ReadOnly = true;
            //BRMGridView1.Rows[1].Cells[2].ReadOnly = true;
            //BRMGridView1.Rows[1].Cells[3].ReadOnly = true;

            //LMGridView1.Rows[0].Cells[0].Value = "LOCATION_NAME";
            //LMGridView1.Rows[0].Cells[1].Value = "1";
            //LMGridView1.Rows[0].Cells[2].Value = "AlphaNumeric";
            //LMGridView1.Rows[0].Cells[3].Value = "250";
            //LMGridView1.Rows[0].Cells[0].ReadOnly = true;
            //LMGridView1.Rows[0].Cells[1].ReadOnly = true;
            //LMGridView1.Rows[0].Cells[2].ReadOnly = true;
            //LMGridView1.Rows[0].Cells[3].ReadOnly = true;
            //LMGridView1.Rows[1].Cells[0].Value = "LOCATION_CODE";
            //LMGridView1.Rows[1].Cells[1].Value = "2";
            //LMGridView1.Rows[1].Cells[2].Value = "AlphaNumeric";
            //LMGridView1.Rows[1].Cells[3].Value = "250";
            //LMGridView1.Rows[1].Cells[0].ReadOnly = true;
            //LMGridView1.Rows[1].Cells[1].ReadOnly = true;
            //LMGridView1.Rows[1].Cells[2].ReadOnly = true;
            //LMGridView1.Rows[1].Cells[3].ReadOnly = true;
            setGridVisible();
            combovisible();
            BMGridView1.Visible = true;
            BMcomboBox1.Visible = true;
            selectedTab = "Bank Master";
            LoadMasters();


        }
        public void setGridVisible()
        {
            BMGridView1.Visible = false;
            BRMGridView1.Visible = false;
            LMGridView1.Visible = false;
            CMGridView1.Visible = false;
            AMGridView1.Visible = false;
            CWDGridView1.Visible = false;

        }
        public void combovisible()
        {
            BMcomboBox1.Visible = false;
            BRMcomboBox1.Visible = false;
            LMcomboBox1.Visible = false;
            CMcomboBox1.Visible = false;
            AMcomboBox1.Visible = false;
            CWDcomboBox1.Visible = false;

        }
        private void LoadMasters()
        {
            tabMasters.Visible = true;

            //progress.Visible = true;
            try
            {
                //pnlFormat.Visible = true;
                MasterEntities.RoleMasterEntities.MastersList mast = new MasterEntities.RoleMasterEntities.MastersList();
                MasterEntities.RoleMasterEntities master = new MasterEntities.RoleMasterEntities();
                master.comp_id = 1;
                MasterBusiness objmaster = new MasterBusiness();
                mast = objmaster.GetMasters(master);
                //TabControl tabControl = new TabControl();
                //tabControl.Dock = DockStyle.Bottom;
                ////tabControl.Anchor = (AnchorStyles)(((AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom)));
                //tabControl.Location = new Point(0, 55);
                ////tabControl.Size = new System.Drawing.Size(138, 14);
                for (int i = 0; i < mast.Masters.Count; i++)
                {
                    string master_id = mast.Masters[i].master_id.ToString();
                    string master_name = mast.Masters[i].master_name.ToString();
                    string company_id = comp_id.ToString();


                    TabPage tabPage = new TabPage();
                    tabPage.Text = master_name;
                    tabPage.Name = master_name + "/" + master_id;
                    tabMasters.TabIndex = Convert.ToInt32(master_id);
                    tabMasters.Controls.Add(tabPage);
                    tabPage.BackColor = Color.White;
                    //tabPage.BackColor = Color.Red;
                    tabPage.ForeColor = Color.Blue;
                    this.Controls.Add(tabMasters);
                    //panMaster.Enabled = true;
                    //progress.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        #endregion

        #region Events
        private void tabMasters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(tabMasters.SelectedTab.ToString());
                setGridVisible();
                combovisible();
                string tabs = tabMasters.SelectedTab.Text;
                selectedTab = tabs;
                if ("Bank Master" == tabs)
                {
                    BMcomboBox1.SelectedIndex = 0;
                    bool valid = false;
                    for (int i = 0; i < BMGridView1.RowCount; i++)
                    {
                        string sfield = BMGridView1.Rows[i].Cells[1].Value == null ? "" : BMGridView1.Rows[i].Cells[1].Value.ToString();
                        string stype = BMGridView1.Rows[i].Cells[2].Value == null ? "" : BMGridView1.Rows[i].Cells[2].Value.ToString();
                        int ilength = Convert.ToInt32(BMGridView1.Rows[i].Cells[3].Value == null || BMGridView1.Rows[i].Cells[3].Value == "" ? "0" : BMGridView1.Rows[i].Cells[3].Value);
                        if (sfield != "" && stype != "" && ilength != 0)
                        {
                            valid = true;
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (valid == true)
                    {
                        LoadGridRows(BMGridView1);
                    }
                    BMGridView1.Visible = true;
                    BMcomboBox1.Visible = true;
                    BMcomboBox1.SelectedIndex = 0;
                }
                else if ("Location Master" == tabs)
                {
                    bool valid = false;
                    if (LMGridView1.RowCount > 0)
                    {
                        for (int i = 0; i < LMGridView1.RowCount; i++)
                        {
                            string sfield = LMGridView1.Rows[i].Cells[1].Value == null ? "" : LMGridView1.Rows[i].Cells[1].Value.ToString();
                            string stype = LMGridView1.Rows[i].Cells[2].Value == null ? "" : LMGridView1.Rows[i].Cells[2].Value.ToString();
                            int ilength = Convert.ToInt32(LMGridView1.Rows[i].Cells[3].Value == null || LMGridView1.Rows[i].Cells[3].Value == "" ? "0" : LMGridView1.Rows[i].Cells[3].Value);
                            if (sfield != "" && stype != "" && ilength != 0)
                            {
                                valid = true;
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        LMGridView1.Rows.Add();
                        LMGridView1.Rows[count].Cells[0].Value = 1;
                        LMGridView1.Columns[0].ReadOnly = true;
                    }
                    if (valid == true)
                    {
                        LoadGridRows(LMGridView1);
                    }
                    LMGridView1.Visible = true;
                    LMcomboBox1.Visible = true;
                    LMcomboBox1.SelectedIndex = 0;
                }
                else if ("Branch Master" == tabs)
                {
                    bool valid = false;
                    if (BRMGridView1.RowCount > 0)
                    {
                        for (int i = 0; i < BRMGridView1.RowCount; i++)
                        {
                            string sfield = BRMGridView1.Rows[i].Cells[1].Value == null ? "" : BRMGridView1.Rows[i].Cells[1].Value.ToString();
                            string stype = BRMGridView1.Rows[i].Cells[2].Value == null ? "" : BRMGridView1.Rows[i].Cells[2].Value.ToString();
                            int ilength = Convert.ToInt32(BRMGridView1.Rows[i].Cells[3].Value == null || BRMGridView1.Rows[i].Cells[3].Value == "" ? "0" : BRMGridView1.Rows[i].Cells[3].Value);
                            if (sfield != "" && stype != "" && ilength != 0)
                            {
                                valid = true;
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        BRMGridView1.Rows.Add();
                        BRMGridView1.Rows[count].Cells[0].Value = 1;
                        BRMGridView1.Columns[0].ReadOnly = true;
                    }
                    if (valid == true)
                    {
                        LoadGridRows(BRMGridView1);
                    }

                    BRMGridView1.Visible = true;
                    BRMcomboBox1.Visible = true;
                    BRMcomboBox1.SelectedIndex = 0;
                    //DataTable dt = new DataTable();
                    //BRMGridView1.Rows[0].Cells[""].Value.ToString() == "Name";
                    //dt.Columns.Add("Field Name");
                    //dt.Columns.Add("Seq No");
                    //dt.Columns.Add("Type");
                    //dt.Columns.Add("Length");
                    //dt.Rows.Add("Br Code/Name", "1", "AlphaNUmeric", "250");
                    //BRMGridView1.Columns.Clear();
                    //BMGridView1.DataSource = dt;
                    //BMGridView1.RowCount = 9;
                    //BRMGridView1.Columns["Field Name"].DefaultCellStyle.NullValue = "Br Code/Name";
                    //BRMGridView1.Rows[1].Cells["Field Name"].Value.ToString() == "";
                }
                else if ("Customer Master" == tabs)
                {
                    bool valid = false;
                    if (CMGridView1.RowCount > 0)
                    {
                        for (int i = 0; i < CMGridView1.RowCount; i++)
                        {
                            string sfield = CMGridView1.Rows[i].Cells[1].Value == null ? "" : CMGridView1.Rows[i].Cells[1].Value.ToString();
                            string stype = CMGridView1.Rows[i].Cells[2].Value == null ? "" : CMGridView1.Rows[i].Cells[2].Value.ToString();
                            int ilength = Convert.ToInt32(CMGridView1.Rows[i].Cells[3].Value == null || CMGridView1.Rows[i].Cells[3].Value == "" ? "0" : CMGridView1.Rows[i].Cells[3].Value);
                            if (sfield != "" && stype != "" && ilength != 0)
                            {
                                valid = true;
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        CMGridView1.Rows.Add();
                        CMGridView1.Rows[count].Cells[0].Value = 1;
                        CMGridView1.Columns[0].ReadOnly = true;
                    }
                    if (valid == true)
                    {
                        LoadGridRows(CMGridView1);
                    }
                    CMGridView1.Visible = true;
                    CMcomboBox1.Visible = true;
                    CMcomboBox1.SelectedIndex = 0;
                }
                else if ("Account Master" == tabs)
                {
                    bool valid = false;
                    if (AMGridView1.RowCount > 0)
                    {
                        for (int i = 0; i < AMGridView1.RowCount; i++)
                        {
                            string sfield = AMGridView1.Rows[i].Cells[1].Value == null ? "" : AMGridView1.Rows[i].Cells[1].Value.ToString();
                            string stype = AMGridView1.Rows[i].Cells[2].Value == null ? "" : AMGridView1.Rows[i].Cells[2].Value.ToString();
                            int ilength = Convert.ToInt32(AMGridView1.Rows[i].Cells[3].Value == null || AMGridView1.Rows[i].Cells[3].Value == "" ? "0" : AMGridView1.Rows[i].Cells[3].Value);
                            if (sfield != "" && stype != "" && ilength != 0)
                            {
                                valid = true;
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid == true)
                        {
                            LoadGridRows(AMGridView1);
                        }
                    }
                    else
                    {
                        AMGridView1.Rows.Add();
                        AMGridView1.Rows[count].Cells[0].Value = 1;
                        AMGridView1.Columns[0].ReadOnly = true;
                    }
                    AMGridView1.Visible = true;
                    AMcomboBox1.Visible = true;
                    AMcomboBox1.SelectedIndex = 0;
                }
                else if ("Customer Wise Source Dump" == tabs)
                {
                    bool valid = false;
                    if (CWDGridView1.RowCount > 0)
                    {
                        for (int i = 0; i < CWDGridView1.RowCount; i++)
                        {
                            string sfield = CWDGridView1.Rows[i].Cells[1].Value == null ? "" : CWDGridView1.Rows[i].Cells[1].Value.ToString();
                            string stype = CWDGridView1.Rows[i].Cells[2].Value == null ? "" : CWDGridView1.Rows[i].Cells[2].Value.ToString();
                            int ilength = Convert.ToInt32(CWDGridView1.Rows[i].Cells[3].Value == null || CWDGridView1.Rows[i].Cells[3].Value == "" ? "0" : CWDGridView1.Rows[i].Cells[3].Value);
                            if (sfield != "" && stype != "" && ilength != 0)
                            {
                                valid = true;
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid == true)
                        {
                            LoadGridRows(CWDGridView1);
                        }
                    }
                    else
                    {
                        CWDGridView1.Rows.Add();
                        CWDGridView1.Rows[count].Cells[0].Value = 1;
                        CWDGridView1.Columns[0].ReadOnly = true;
                    }
                    CWDGridView1.Visible = true;
                    CWDcomboBox1.Visible = true;
                    CWDcomboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }
        bool bValid = false;
        private bool IsValidGrid(DataGridView dg)
        {
            int count = 0;
            try
            {
                for (int i = 0; i < dg.RowCount; i++)
                {
                    string sseq_no = dg.Rows[i].Cells[0].Value == null ? "" : dg.Rows[i].Cells[0].Value.ToString();
                    string sfield = dg.Rows[i].Cells[1].Value == null ? "" : dg.Rows[i].Cells[1].Value.ToString();
                    string stype = dg.Rows[i].Cells[2].Value == null ? "" : dg.Rows[i].Cells[2].Value.ToString();
                    int ilength = Convert.ToInt32(dg.Rows[i].Cells[3].Value == null || dg.Rows[i].Cells[3].Value == "" ? "0" : dg.Rows[i].Cells[3].Value);
                    if (sfield != "")
                    {
                        if (stype != "" && ilength != 0)
                        {
                            count++;
                            bValid = true;
                        }
                        else
                        {
                            bValid = false;
                            break;
                        }
                    }
                    else
                    {
                        bValid = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(ex.ToString());
            }
            return bValid;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string uploadtype = "";
                DataTable dtn = new DataTable();
                DataGridView gv = new DataGridView();
                int rowcount = 0;
                if (BMcomboBox1.SelectedIndex > 0 || LMcomboBox1.SelectedIndex > 0 || BRMcomboBox1.SelectedIndex > 0 ||
                    CMcomboBox1.SelectedIndex > 0 || AMcomboBox1.SelectedIndex > 0 || CWDcomboBox1.SelectedIndex > 0 || AMcomboBox1.SelectedIndex > 0)
                {
                    if (selectedTab == "Bank Master")
                    {
                        gv = BMGridView1;
                        rowcount = gv.Rows.Count;
                        uploadtype = BMcomboBox1.SelectedItem.ToString();
                        IsValidGrid(BMGridView1);
                    }
                    else if (selectedTab == "Location Master")
                    {
                        gv = LMGridView1;
                        rowcount = gv.Rows.Count - 1;
                        uploadtype = LMcomboBox1.SelectedItem.ToString();
                        IsValidGrid(LMGridView1);
                    }
                    else if (selectedTab == "Branch Master")
                    {
                        gv = BRMGridView1;
                        BRMGridView1.Columns["Field Name"].DefaultCellStyle.NullValue = "Branch_code";
                        rowcount = gv.Rows.Count - 1;
                        uploadtype = BRMcomboBox1.SelectedItem.ToString();
                        IsValidGrid(BRMGridView1);
                    }
                    else if (selectedTab == "Customer Master")
                    {
                        gv = CMGridView1;
                        rowcount = gv.Rows.Count - 1;
                        uploadtype = CMcomboBox1.SelectedItem.ToString();
                        IsValidGrid(CMGridView1);
                    }
                    else if (selectedTab == "Account Master")
                    {
                        gv = AMGridView1;
                        rowcount = gv.Rows.Count - 1;
                        uploadtype = AMcomboBox1.SelectedItem.ToString();
                        IsValidGrid(AMGridView1);
                    }
                    else if (selectedTab == "Customer Wise Source Dump")
                    {
                        gv = CWDGridView1;
                        rowcount = gv.Rows.Count - 1;
                        uploadtype = CWDcomboBox1.SelectedItem.ToString();
                    }
                    //if (rowcount > 10)
                    //{
                    //    MessageBox.Show("Limitations Below 10 Row only in grid");
                    //}

                    if (rowcount > 0)
                    {
                        //if (uploadtype != "")
                        //{
                        foreach (DataGridViewColumn col in gv.Columns)
                        {
                            dtn.Columns.Add(col.Name);
                        }
                        foreach (DataGridViewRow row in gv.Rows)
                        {
                            DataRow dRow = dtn.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dtn.Rows.Add(dRow);
                        }
                        dtn = RemoveEmptyRowsFromDataTable(dtn);
                        //dtn = dtn.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field =>
                        //        field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

                        //DataTable dt = new DataTable();
                        //dt = dtn;
                        if (bValid)
                        {
                            dtn.Columns[0].SetOrdinal(1);
                            if (dtn.Rows.Count > 0)
                            {
                                System.Data.DataColumn newColumn = new System.Data.DataColumn("upload_type", typeof(System.String));
                                newColumn.DefaultValue = uploadtype;
                                dtn.Columns.Add(newColumn);


                                string[] fieldS = tabMasters.SelectedTab.Name.Split('/');
                                int master_id = Convert.ToInt32(fieldS[1].ToString());
                                MasterEntities.CreateMasterFieldswithTableEntities objMasterFields = new MasterEntities.CreateMasterFieldswithTableEntities();
                                objMasterFields.dttable = dtn;
                                objMasterFields.master_name = selectedTab;
                                objMasterFields.company_id = comp_id.ToString();
                                objMasterFields.master_id = master_id.ToString();

                                MasterBusiness objBusiness = new MasterBusiness();
                                objMasterFields = objBusiness.CreateMasterfieldsWithTables(objMasterFields);
                                MessageBox.Show("successfully Uploaded", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("There is no Data in Grid", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Fill the Missing Fields", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no Data in Grid", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Upload Type", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CWDGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CWDGridView1.Rows.Count <= 10)
                this.CWDGridView1.Rows.Add("This is a row.");
        }
        private void CheckRowExists(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int seq_no = Convert.ToInt32(dt.Rows[i]["seq_no"].ToString());
            }
        }
        DataTable RemoveEmptyRowsFromDataTable(DataTable dt)
        {
            try
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i][1] == DBNull.Value)
                        dt.Rows[i].Delete();
                }
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            return dt;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void AMGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (AMGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (AMGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void BMGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (BMGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (BMGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void BRMGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (BRMGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (BRMGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void CMGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (CMGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (CMGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void CWDGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (CWDGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (CWDGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void LMGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (LMGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (LMGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        #endregion

        #region GridEvents
        //private void BMGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {

        //        //if (e.ColumnIndex == 3)
        //        //{
        //        //    LoadGridRows(BMGridView1);
        //        //}
        //        if (e.ColumnIndex == 3)
        //        {
        //            int seq_no = Convert.ToInt32(BMGridView1.Rows[e.RowIndex].Cells[0].Value == null || BMGridView1.Rows[e.RowIndex].Cells[0].Value == "" ? "0" : BMGridView1.Rows[e.RowIndex].Cells[0].Value);
        //            string field = BMGridView1.Rows[e.RowIndex].Cells[1].Value == null ? "" : BMGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            string type = BMGridView1.Rows[e.RowIndex].Cells[2].Value == null ? "" : BMGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //            int length = Convert.ToInt32(BMGridView1.Rows[e.RowIndex].Cells[3].Value == null || BMGridView1.Rows[e.RowIndex].Cells[3].Value == "" ? "0" : BMGridView1.Rows[e.RowIndex].Cells[3].Value);
        //            if (field != "")
        //            {
        //                if (type != "")
        //                {
        //                    if (length > 0)
        //                    {
        //                        if (BMGridView1.Rows.Count < 10)
        //                        {
        //                            LoadGridRows(BMGridView1);
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            btn_save.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void BMGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        //if (e.ColumnIndex == 0)
        //        //{
        //        //    //int seq_no = Convert.ToInt32(BMGridView1.Rows[e.RowIndex].Cells[0].Value == "" ? BMGridView1.Rows[e.RowIndex].Cells[0].Value == "0" : BMGridView1.Rows[e.RowIndex].Cells[0].Value);
        //        //}
        //        //else if (e.ColumnIndex == 1)
        //        //{
        //        //    string field = BMGridView1.Rows[e.RowIndex].Cells[1].Value == null ? "" : BMGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //        //    if (field != "")
        //        //    {
        //        //        BMGridView1.Focus();
        //        //        BMGridView1.CurrentCell = BMGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
        //        //    }
        //        //    else
        //        //    {
        //        //        MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //        //BMGridView1.Focus();
        //        //        //BMGridView1.CurrentCell = BMGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //        //        return;
        //        //    }
        //        //}
        //        //else if (e.ColumnIndex == 2)
        //        //{
        //        //    string type = BMGridView1.Rows[e.RowIndex].Cells[2].Value == null ? "" : BMGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        //    if (type != "")
        //        //    {
        //        //        BMGridView1.Focus();
        //        //        BMGridView1.CurrentCell = BMGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
        //        //    }
        //        //    else
        //        //    {
        //        //        //BMGridView1.Focus();
        //        //        //BMGridView1.CurrentCell = BMGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //        //        MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //        return;
        //        //    }
        //        //}
        //        //else if (e.ColumnIndex == 3)
        //        //{
        //        //    string length = BMGridView1.Rows[e.RowIndex].Cells[3].Value == null ? "" : BMGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        //        //    if (length != "")
        //        //    {
        //        //        BMGridView1.Focus();
        //        //        BMGridView1.CurrentCell = BMGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
        //        //    }
        //        //    else
        //        //    {
        //        //        //BMGridView1.Focus();
        //        //        //BMGridView1.CurrentCell = BMGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //        //        MessageBox.Show("Field Length Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //        return;
        //        //    }

        //        //}

        //        //string field = BMGridView1.Rows[e.RowIndex].Cells[1].Value;
        //        //string type = BMGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        //int length = Convert.ToInt32(BMGridView1.Rows[3].Cells[1].Value);
        //        //if (field != "")
        //        //{
        //        //    if (type != "")
        //        //    {
        //        //        if (length > 0)
        //        //        {
        //        //            LoadGridRows(BMGridView1);
        //        //        }
        //        //        else
        //        //        {
        //        //            MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //        }
        //        //    }
        //        //    else
        //        //    {
        //        //        MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void MBLGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {

        //        //if (e.ColumnIndex == 3)
        //        //{
        //        //    LoadGridRows(BMGridView1);
        //        //}
        //        if (e.ColumnIndex == 3)
        //        {
        //            int seq_no = Convert.ToInt32(MBLGridView1.Rows[e.RowIndex].Cells[0].Value == null || MBLGridView1.Rows[e.RowIndex].Cells[0].Value == "" ? "0" : MBLGridView1.Rows[e.RowIndex].Cells[0].Value);
        //            string field = MBLGridView1.Rows[e.RowIndex].Cells[1].Value == null ? "" : MBLGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            string type = MBLGridView1.Rows[e.RowIndex].Cells[2].Value == null ? "" : MBLGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //            int length = Convert.ToInt32(MBLGridView1.Rows[e.RowIndex].Cells[3].Value == null || MBLGridView1.Rows[e.RowIndex].Cells[3].Value == "" ? "0" : MBLGridView1.Rows[e.RowIndex].Cells[3].Value);
        //            if (field != "")
        //            {
        //                if (type != "")
        //                {
        //                    if (length > 0)
        //                    {
        //                        if (MBLGridView1.Rows.Count < 10)
        //                        {
        //                            LoadGridRows(MBLGridView1);
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            btn_save.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }

        //}
        //private void AMGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 3)
        //        {
        //            int seq_no = Convert.ToInt32(AMGridView1.Rows[e.RowIndex].Cells[0].Value == null || AMGridView1.Rows[e.RowIndex].Cells[0].Value == "" ? "0" : AMGridView1.Rows[e.RowIndex].Cells[0].Value);
        //            string field = AMGridView1.Rows[e.RowIndex].Cells[1].Value == null ? "" : AMGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            string type = AMGridView1.Rows[e.RowIndex].Cells[2].Value == null ? "" : AMGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //            int length = Convert.ToInt32(AMGridView1.Rows[e.RowIndex].Cells[3].Value == null || AMGridView1.Rows[e.RowIndex].Cells[3].Value == "" ? "0" : AMGridView1.Rows[e.RowIndex].Cells[3].Value);
        //            if (field != "")
        //            {
        //                if (type != "")
        //                {
        //                    if (length > 0)
        //                    {
        //                        if (AMGridView1.Rows.Count < 10)
        //                        {
        //                            LoadGridRows(AMGridView1);
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            btn_save.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void BRMGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 3)
        //        {
        //            int seq_no = Convert.ToInt32(BRMGridView1.Rows[e.RowIndex].Cells[0].Value == null || BRMGridView1.Rows[e.RowIndex].Cells[0].Value == "" ? "0" : BRMGridView1.Rows[e.RowIndex].Cells[0].Value);
        //            string field = BRMGridView1.Rows[e.RowIndex].Cells[1].Value == null ? "" : BRMGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            string type = BRMGridView1.Rows[e.RowIndex].Cells[2].Value == null ? "" : BRMGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //            int length = Convert.ToInt32(BRMGridView1.Rows[e.RowIndex].Cells[3].Value == null || BRMGridView1.Rows[e.RowIndex].Cells[3].Value == "" ? "0" : BRMGridView1.Rows[e.RowIndex].Cells[3].Value);
        //            if (field != "")
        //            {
        //                if (type != "")
        //                {
        //                    if (length > 0)
        //                    {
        //                        if (BRMGridView1.Rows.Count < 10)
        //                        {
        //                            LoadGridRows(BRMGridView1);
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            btn_save.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void CMGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 3)
        //        {
        //            int seq_no = Convert.ToInt32(CMGridView1.Rows[e.RowIndex].Cells[0].Value == null || CMGridView1.Rows[e.RowIndex].Cells[0].Value == "" ? "0" : CMGridView1.Rows[e.RowIndex].Cells[0].Value);
        //            string field = CMGridView1.Rows[e.RowIndex].Cells[1].Value == null ? "" : CMGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            string type = CMGridView1.Rows[e.RowIndex].Cells[2].Value == null ? "" : CMGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //            int length = Convert.ToInt32(CMGridView1.Rows[e.RowIndex].Cells[3].Value == null || CMGridView1.Rows[e.RowIndex].Cells[3].Value == "" ? "0" : CMGridView1.Rows[e.RowIndex].Cells[3].Value);
        //            if (field != "")
        //            {
        //                if (type != "")
        //                {
        //                    if (length > 0)
        //                    {
        //                        if (CMGridView1.Rows.Count < 10)
        //                        {
        //                            LoadGridRows(CMGridView1);
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            btn_save.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        //private void LMGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 3)
        //        {
        //            int seq_no = Convert.ToInt32(LMGridView1.Rows[e.RowIndex].Cells[0].Value == null || LMGridView1.Rows[e.RowIndex].Cells[0].Value == "" ? "0" : LMGridView1.Rows[e.RowIndex].Cells[0].Value);
        //            string field = LMGridView1.Rows[e.RowIndex].Cells[1].Value == null ? "" : LMGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            string type = LMGridView1.Rows[e.RowIndex].Cells[2].Value == null ? "" : LMGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //            int length = Convert.ToInt32(LMGridView1.Rows[e.RowIndex].Cells[3].Value == null || LMGridView1.Rows[e.RowIndex].Cells[3].Value == "" ? "0" : LMGridView1.Rows[e.RowIndex].Cells[3].Value);
        //            if (field != "")
        //            {
        //                if (type != "")
        //                {
        //                    if (length > 0)
        //                    {
        //                        if (LMGridView1.Rows.Count < 10)
        //                        {
        //                            LoadGridRows(LMGridView1);
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            btn_save.Focus();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex.ToString());
        //    }
        //}
        #endregion

        private void BMGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                try
                {
                    int RowIndex = BMGridView1.Rows.Count - 1;
                    int seq_no = Convert.ToInt32(BMGridView1.Rows[RowIndex].Cells[0].Value == null || BMGridView1.Rows[RowIndex].Cells[0].Value == "" ? "0" : BMGridView1.Rows[RowIndex].Cells[0].Value);
                    string field = BMGridView1.Rows[RowIndex].Cells[1].Value == null ? "" : BMGridView1.Rows[RowIndex].Cells[1].Value.ToString();
                    string type = BMGridView1.Rows[RowIndex].Cells[2].Value == null ? "" : BMGridView1.Rows[RowIndex].Cells[2].Value.ToString();
                    int length = Convert.ToInt32(BMGridView1.Rows[RowIndex].Cells[3].Value == null || BMGridView1.Rows[RowIndex].Cells[3].Value == "" ? "0" : BMGridView1.Rows[RowIndex].Cells[3].Value);
                    if (field != "")
                    {
                        if (type != "")
                        {
                            if (length > 0)
                            {
                                if (BMGridView1.Rows.Count < 10)
                                {
                                    LoadGridRows(BMGridView1);
                                }
                                else
                                {
                                    MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btn_save.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        private void AMGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4)
            {
                try
                {
                    int RowIndex = AMGridView1.Rows.Count - 1;
                    int seq_no = Convert.ToInt32(AMGridView1.Rows[RowIndex].Cells[0].Value == null || AMGridView1.Rows[RowIndex].Cells[0].Value == "" ? "0" : AMGridView1.Rows[RowIndex].Cells[0].Value);
                    string field = AMGridView1.Rows[RowIndex].Cells[1].Value == null ? "" : AMGridView1.Rows[RowIndex].Cells[1].Value.ToString();
                    string type = AMGridView1.Rows[RowIndex].Cells[2].Value == null ? "" : AMGridView1.Rows[RowIndex].Cells[2].Value.ToString();
                    int length = Convert.ToInt32(AMGridView1.Rows[RowIndex].Cells[3].Value == null || AMGridView1.Rows[RowIndex].Cells[3].Value == "" ? "0" : AMGridView1.Rows[RowIndex].Cells[3].Value);
                    if (field != "")
                    {
                        if (type != "")
                        {
                            if (length > 0)
                            {
                                if (AMGridView1.Rows.Count < 10)
                                {
                                    LoadGridRows(BMGridView1);
                                }
                                else
                                {
                                    MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btn_save.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        private void BRMGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                try
                {
                    int RowIndex = BRMGridView1.Rows.Count - 1;
                    int seq_no = Convert.ToInt32(BRMGridView1.Rows[RowIndex].Cells[0].Value == null || BRMGridView1.Rows[RowIndex].Cells[0].Value == "" ? "0" : BRMGridView1.Rows[RowIndex].Cells[0].Value);
                    string field = BRMGridView1.Rows[RowIndex].Cells[1].Value == null ? "" : BRMGridView1.Rows[RowIndex].Cells[1].Value.ToString();
                    string type = BRMGridView1.Rows[RowIndex].Cells[2].Value == null ? "" : BRMGridView1.Rows[RowIndex].Cells[2].Value.ToString();
                    int length = Convert.ToInt32(BRMGridView1.Rows[RowIndex].Cells[3].Value == null || BRMGridView1.Rows[RowIndex].Cells[3].Value == "" ? "0" : BRMGridView1.Rows[RowIndex].Cells[3].Value);
                    if (field != "")
                    {
                        if (type != "")
                        {
                            if (length > 0)
                            {
                                if (BRMGridView1.Rows.Count < 10)
                                {
                                    LoadGridRows(BRMGridView1);
                                }
                                else
                                {
                                    MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btn_save.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        private void LMGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                try
                {
                    int RowIndex = LMGridView1.Rows.Count - 1;
                    int seq_no = Convert.ToInt32(LMGridView1.Rows[RowIndex].Cells[0].Value == null || LMGridView1.Rows[RowIndex].Cells[0].Value == "" ? "0" : LMGridView1.Rows[RowIndex].Cells[0].Value);
                    string field = LMGridView1.Rows[RowIndex].Cells[1].Value == null ? "" : LMGridView1.Rows[RowIndex].Cells[1].Value.ToString();
                    string type = LMGridView1.Rows[RowIndex].Cells[2].Value == null ? "" : LMGridView1.Rows[RowIndex].Cells[2].Value.ToString();
                    int length = Convert.ToInt32(LMGridView1.Rows[RowIndex].Cells[3].Value == null || LMGridView1.Rows[RowIndex].Cells[3].Value == "" ? "0" : LMGridView1.Rows[RowIndex].Cells[3].Value);
                    if (field != "")
                    {
                        if (type != "")
                        {
                            if (length > 0)
                            {
                                if (LMGridView1.Rows.Count < 10)
                                {
                                    LoadGridRows(LMGridView1);
                                }
                                else
                                {
                                    MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btn_save.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }

        private void CMGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                try
                {
                    int RowIndex = CMGridView1.Rows.Count - 1;
                    int seq_no = Convert.ToInt32(CMGridView1.Rows[RowIndex].Cells[0].Value == null || CMGridView1.Rows[RowIndex].Cells[0].Value == "" ? "0" : CMGridView1.Rows[RowIndex].Cells[0].Value);
                    string field = CMGridView1.Rows[RowIndex].Cells[1].Value == null ? "" : CMGridView1.Rows[RowIndex].Cells[1].Value.ToString();
                    string type = CMGridView1.Rows[RowIndex].Cells[2].Value == null ? "" : CMGridView1.Rows[RowIndex].Cells[2].Value.ToString();
                    int length = Convert.ToInt32(CMGridView1.Rows[RowIndex].Cells[3].Value == null || CMGridView1.Rows[RowIndex].Cells[3].Value == "" ? "0" : CMGridView1.Rows[RowIndex].Cells[3].Value);
                    if (field != "")
                    {
                        if (type != "")
                        {
                            if (length > 0)
                            {
                                if (CMGridView1.Rows.Count < 10)
                                {
                                    LoadGridRows(CMGridView1);
                                }
                                else
                                {
                                    MessageBox.Show("Maximum Field Reached", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btn_save.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Length Cannot Be Empty or Zero", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data Type Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Field Name Cannot Be Empty", "EASY PAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToString());
                }
            }
        }
    }
}
