using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;


namespace CheckManagementSystem
{

    public partial class Inward : Form
    {
        public string cmbbrcodename;
        DataTable dtbranch1;
        string user_name = string.Empty;
        public string ModeFlag;
        public int id = 0;

        Getinwardbusiness objfetch = new Getinwardbusiness();
        public Inward()
        {
            InitializeComponent();
        }
        public Inward(string _user_name)
        {
            InitializeComponent();
            user_name = _user_name;
            ModeFlag = "New";
        }
        public Inward (int InwardId)
        {
            InitializeComponent();
            ModeFlag = "Edit";
            DataTable dt = new DataTable();
            InwardBusiness objBusiness = new InwardBusiness();
            LoadInwardDetails();
            dt = objBusiness.GetSingleInwardDetails(InwardId);

            id = Convert.ToInt32(dt.Rows[0]["inward_gid"]);
            dateTimePicker1.Text = dt.Rows[0]["inward_date"].ToString();
            cmbbrcode.Text = dt.Rows[0]["Branch Name"].ToString();
            cmblocation.Text = dt.Rows[0]["Location Name"].ToString();
            chqcnt.Text = dt.Rows[0]["chq_count"].ToString();
            Remark_Txt.Text = dt.Rows[0]["inward_remark"].ToString();
        }

        public bool InWardValidation()
        {
            string chqCount = chqcnt.Text;

            if (cmbbrcode.SelectedIndex == 0)
            {
                MessageBox.Show("Branch Code/Name Cannot be Empty! Please Fill the Branch Code/Name", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbbrcode.Focus();
                return false;
            }
            if (cmblocation.SelectedIndex == 0)
            {
                MessageBox.Show("Pickup Location Cannot be Empty! Please Fill the Inward Location", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmblocation.Focus();
                return false;
            }
            if (chqCount == "" || chqCount == null || chqCount == "0")
            {
                MessageBox.Show("Check Count Cannot be Empty! Please Fill the Check Count", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chqcnt.Focus();
                return false;
            }
            if (Convert.ToInt32(chqcnt.Text) > 10000)
            {
                MessageBox.Show("Cheque Count can't be greater than 10000", "Check Mandate System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chqcnt.Text = "0";
                chqcnt.Focus();
                return false;
            }
            return true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to save the record?", "", MessageBoxButtons.YesNo))
                {
                    if (chqcnt.Text.ToString() == "")
                    {
                        MessageBox.Show("cheque count Can't Empty ");
                    }
                    else
                    {
                        if (Convert.ToInt32(chqcnt.Text.ToString()) > 0)
                        {
                            if (InWardValidation())
                            {
                                DataTable dtInward = new DataTable();
                                InwardEntites objInward = new InwardEntites();
                                if (id == 0)
                                {
                                    objInward.inward_gid = 0;
                                    objInward.inward_datetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");//dateTimePicker1.Value.ToShortDateString();                           
                                    objInward.lot_no = "";
                                    cmblocation.GetItemText(cmblocation.Items[cmblocation.SelectedIndex]);
                                    objInward.branch_code_name = cmbbrcode.SelectedValue.ToString();
                                    objInward.pickup_location = cmblocation.SelectedValue.ToString(); //cmblocation.SelectedValue.ToString();
                                    objInward.cheque_count = chqcnt.Text.Trim();
                                    objInward.created_by = user_name;
                                    objInward.action = "Insert";
                                    objInward.remarks = Remark_Txt.Text.Trim();
                                }
                                else
                                {
                                    objInward.inward_gid = id;
                                    objInward.inward_datetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");//dateTimePicker1.Value.ToShortDateString();                           
                                    objInward.lot_no = "";
                                    cmblocation.GetItemText(cmblocation.Items[cmblocation.SelectedIndex]);
                                    objInward.branch_code_name = cmbbrcode.SelectedValue.ToString();
                                    objInward.pickup_location = cmblocation.SelectedValue.ToString(); //cmblocation.SelectedValue.ToString();
                                    objInward.cheque_count = chqcnt.Text.Trim();
                                    objInward.created_by = user_name;
                                    objInward.action = "Update";
                                    objInward.remarks = Remark_Txt.Text.Trim();
                                }
                                InwardBusiness objBusiness = new InwardBusiness();
                                string[] result = objBusiness.SaveInward(objInward);
                                objInward.msg = result[0].ToString();

                                MessageBox.Show(result[0].ToString());

                                if (result[1].ToString() == "1")
                                {

                                    if (DialogResult.Yes == MessageBox.Show("Do you want to add the record?", "", MessageBoxButtons.YesNo))
                                    {
                                        Clear();
                                        Inward_Load(sender, e);
                                        chqcnt.Focus();
                                    }
                                    else
                                    {
                                        Close();
                                    }

                                }
                                else
                                {
                                    Close();
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Cheque No");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(user_name + "-" + ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if( cmbtype.SelectedIndex == "select")

            //PicLoad.Visible = false;
        }

        private void Clear()
        {
            //cmbtype.Text = "";
            cmbbrcode.Text = "";
            cmblocation.Text = "";
            chqcnt.Text = "";
            Remark_Txt.Text = "";

        }


        private Dictionary<string, string> DynamicCombo()
        {

            // List<string> combo = new List<string>();
            Dictionary<string, string> combo = new Dictionary<string, string>();
            try
            {
                //var applicationSettings = ConfigurationManager.GetSection("branch") as NameValueCollection;
                ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("FilterHashKey");
                if (section != null)
                    foreach (FilterHashElement element in section.HashKeys)
                    {

                        combo.Add(element.Value, element.Value);
                    }
            }
            catch (Exception ex)
            {

                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return combo;

        }
        private Dictionary<string, string> DynamicCombo1()
        {

            // List<string> combo = new List<string>();
            Dictionary<string, string> combo = new Dictionary<string, string>();
            try
            {
                //var applicationSettings = ConfigurationManager.GetSection("branch") as NameValueCollection;
                ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("FilterHashKey");
                if (section != null)
                    foreach (FilterHashElement element in section.HashKeys1)
                    {

                        combo.Add(element.Code, element.Value);
                    }
            }
            catch (Exception ex)
            {

                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return combo;

        }
        private Dictionary<string, string> DynamicCombo2()
        {

            //List<string> combo = new List<string>();
            Dictionary<string, string> combo = new Dictionary<string, string>();
            try
            {
                //var applicationSettings = ConfigurationManager.GetSection("branch") as NameValueCollection;
                ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("FilterHashKey");
                if (section != null)
                    foreach (FilterHashElement element in section.HashKeys2)
                    {

                        combo.Add(element.Value, element.Value);
                    }
            }
            catch (Exception ex)
            {

                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return combo;

        }
        private void Inward_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Enabled = false;
            try
            {
                if (ModeFlag == "New")
                {


                    Clear();
                    dateTimePicker1.MaxDate = DateTime.Now;
                    chqcnt.ShortcutsEnabled = false;
                    LoadInwardDetails();

                   
                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadInwardDetails()
        {
            try
            {
                InwardBusiness objinward = new InwardBusiness();
                DataSet dslist = new DataSet();
                DataTable dtbranch = new DataTable();
                DataTable dtlocation = new DataTable();
                dslist = objinward.GetBranchLocation();

                if (dslist.Tables[0].Rows.Count > 0)
                {
                    dtbranch = dslist.Tables[0];
                }
                if (dslist.Tables[1].Rows.Count > 0)
                {
                    dtlocation = dslist.Tables[1];
                }
                //DataTable dtbranch = objinward.GetBranches();
                DataRow rows = dtbranch.NewRow();
                rows["Branch Name"] = "--Select--";
                dtbranch.Rows.InsertAt(rows, 0);
                cmbbrcode.DataSource = dtbranch;
                cmbbrcode.DisplayMember = "Branch Name";
                cmbbrcode.ValueMember = "Branch Code";

                //DataTable dtlocation = objinward.GetLocation();
                DataRow dr = dtlocation.NewRow();
                dr["LOCATION_CODE"] = "--Select--";
                dtlocation.Rows.InsertAt(dr, 0);               
                cmblocation.DataSource = dtlocation;
                cmblocation.DisplayMember = "LOCATION_CODE";
                cmblocation.ValueMember = "LOCATION_CODE";

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // To Supress the event 
        }

        private void chqcnt_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //   chqcnt.TextAlign = HorizontalAlignment.Right;

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
            //Clear();
        }

        private void cmbbrcode_TextChanged(object sender, EventArgs e)
        {
            cmbbrcodename = cmbbrcode.Text;
            //string[] items = new string[cmbbrcode.Items.Count];

            //for (int i = 0; i < cmbbrcode.Items.Count; i++)
            //{
            //    items[i] = cmbbrcode.Items[i].ToString();
            //}
        }

        private void cmblocation_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbbrcode_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbbrcode_Leave(object sender, EventArgs e)
        {
            //bool isContains = false;

            //foreach (DataRowView s in cmbbrcode.Items)
            //{

            //    if (s.Row.ItemArray.Contains(cmbbrcodename))
            //    {
            //        isContains = true;
            //    }
            //}

            //if (!isContains)
            //{
            //    cmbbrcode.Focus();
            //    MessageBox.Show("Kinldy Enter / Select the value from the list");
            //}

        }



        private void Inward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }



        private void cmbbrcode_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void chqcnt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Remark_Txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

