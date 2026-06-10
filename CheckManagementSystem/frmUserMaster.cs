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
    public partial class frmUserMaster : Form
    {
        public string cmbbrcodename;
        DataTable dtbranch1;
        string user_name = string.Empty;
        public string ModeFlag;
        public int id = 0;
        public int UserGid = 0;
        public string Action = "";

        Getinwardbusiness objfetch = new Getinwardbusiness();
        public frmUserMaster(string UserName)
        {
            InitializeComponent();
            user_name = UserName;
            pnlSave.Visible = true;
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            try
            {

                cboSex.Items.Clear();
                cboSex.Items.Add("MALE");
                cboSex.Items.Add("FEMALE");

                LoadInwardDetails();
                pnlButtons.Visible = false;
                
                pnlMain.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadInwardDetails()
        {
            try
            {
                InwardBusiness objinward = new InwardBusiness();
                DataTable dtgroup = new DataTable();
                dtgroup = objinward.GetUserGroup();
                DataRow rows = dtgroup.NewRow();
                rows["usergroup_name"] = "--Select--";
                dtgroup.Rows.InsertAt(rows, 0);
                cboUserGrp.DataSource = dtgroup;
                cboUserGrp.DisplayMember = "usergroup_name";
                cboUserGrp.ValueMember = "usergroup_gid";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
           this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to save the record?", "", MessageBoxButtons.YesNo))
                {
                    if (txtCode.Text == "")
                    {
                        MessageBox.Show("User code cannot be empty ! ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCode.Focus();
                        return;
                    }
                    if (cboSex.Text == "")
                    {
                        MessageBox.Show("Gender cannot be empty ! ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboSex.Focus();
                        return;
                    }
                    if (txtName.Text == "")
                    {
                        MessageBox.Show("user name cannot be empty ! ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Focus();
                        return;
                    }
                    if (txtAddr1.Text == "")
                    {
                        MessageBox.Show("Address cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAddr1.Focus();
                        return;
                    }
                    if (txtCity.Text == "")
                    {
                        MessageBox.Show("City name cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCity.Focus();
                        return;
                    }
                    if (txtDesig.Text == "")
                    {
                        MessageBox.Show("Designation cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDesig.Focus();
                        return;
                    }
                    if (txtDept.Text == "")
                    {
                        MessageBox.Show("Department name cannot be empty !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDept.Focus();
                        return;
                    }
                    if (cboSex.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select valid gender !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboSex.Focus();
                        return;
                    }
                    if (cboUserGrp.SelectedIndex==-1)
                    {
                        MessageBox.Show("Please select valid User Group !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboUserGrp.Focus();
                        return;
                    }
                    //UserMaster
                    UserMaster Obj_UserMaster = new UserMaster();

                    Obj_UserMaster.user_gid = UserGid;
                    Obj_UserMaster.user_code = txtCode.Text.Trim();
                    Obj_UserMaster.user_name = txtName.Text.Trim();
                    Obj_UserMaster.addr1 = txtAddr1.Text.Trim();
                    Obj_UserMaster.addr2 = txtAddr2.Text.Trim();
                    Obj_UserMaster.addr3 = txtAddr3.Text.Trim();
                    Obj_UserMaster.addr4 = txtAddr4.Text.Trim();
                    Obj_UserMaster.city = txtCity.Text.Trim();
                    Obj_UserMaster.pincode = txtPincode.Text.Trim();
                    Obj_UserMaster.contact_no = txtContactNo.Text.Trim();
                    Obj_UserMaster.sex = cboSex.Text;
                    Obj_UserMaster.dob = dtpDob.Value.ToString("yyyy-MM-dd");
                    Obj_UserMaster.doj = dtpDoj.Value.ToString("yyyy-MM-dd");
                    Obj_UserMaster.desig_name = txtDesig.Text.Trim();
                    Obj_UserMaster.dept_name = txtDept.Text.Trim();
                    Obj_UserMaster.user_status = txtUserStatus.Text.Trim();
                    Obj_UserMaster.pwd_flag = false;
                    Obj_UserMaster.usergroup_gid = Convert.ToInt32(cboUserGrp.SelectedValue.ToString());
                    Obj_UserMaster.action = Action;

                    InwardBusiness objBusiness = new InwardBusiness();
                    string[] result = objBusiness.SaveUserMaster(Obj_UserMaster);
                    MessageBox.Show(result[0].ToString());
                    if (result[1].ToString() == "1")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Do you want to add the record?", "", MessageBoxButtons.YesNo))
                        {
                            Clear();
                            frmUserMaster_Load(sender, e);
                        }
                        else
                        {
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtCode.Text = "";
            txtName.Text = "";
            cboSex.Text = "";
            txtAddr1.Text = "";
            txtAddr2.Text = "";
            txtAddr3.Text = "";
            txtAddr4.Text = "";
            txtCity.Text = "";
            txtContactNo.Text = "";
            txtDept.Text = "";
            txtDesig.Text = "";
            txtPincode.Text = "";
            txtUserStatus.Text = "";
        }

        private void EmpCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string empcode = txtCode.Text.Trim();
                if (empcode!="")
                {
                    DataTable dt = new DataTable();
                    InwardBusiness objBusiness = new InwardBusiness();
                    dt = objBusiness.GetUserDetails(empcode);
                    if (dt.Rows.Count>0)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Emp Code already is there, Are you sure you want to edit the record?", "", MessageBoxButtons.YesNo))
                        {
                            pnlButtons.Visible = true;
                            pnlSave.Visible = false;
                            UserGid = Convert.ToInt32(dt.Rows[0]["user_gid"]);
                            txtCode.Text = dt.Rows[0]["user_code"].ToString();
                            txtName.Text = dt.Rows[0]["user_name"].ToString();
                            cboSex.Text = dt.Rows[0]["sex"].ToString();
                            txtAddr1.Text = dt.Rows[0]["addr1"].ToString();
                            txtAddr2.Text = dt.Rows[0]["addr2"].ToString();
                            txtAddr3.Text = dt.Rows[0]["addr3"].ToString();
                            txtAddr4.Text = dt.Rows[0]["addr4"].ToString();
                            txtCity.Text = dt.Rows[0]["city"].ToString();
                            txtContactNo.Text = dt.Rows[0]["contact_no"].ToString();
                            txtDept.Text = dt.Rows[0]["dept_name"].ToString();
                            txtDesig.Text = dt.Rows[0]["desig_name"].ToString();
                            txtPincode.Text = dt.Rows[0]["pincode"].ToString();
                            txtUserStatus.Text = dt.Rows[0]["user_status"].ToString();
                            cboUserGrp.Text = dt.Rows[0]["usergroup_name"].ToString();
                            if (dt.Rows[0]["user_status"].ToString() == "Y")
                            {
                                chkActivate.Checked = true;
                            }
                            else
                            {
                                chkActivate.Checked = false;
                            }
                            dtpDob.Text = dt.Rows[0]["dob"].ToString();
                            dtpDoj.Text = dt.Rows[0]["doj"].ToString();
                            dtpDor.Text = dt.Rows[0]["dor"].ToString();
                            Action = "Update";

                        }
                        else
                        {
                            Clear();
                            Action = "Insert";
                        }
                    }
                    else
                    {
                        Action = "Insert";
                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               
                UserMaster Obj_UserMaster = new UserMaster();

                Obj_UserMaster.user_gid = UserGid;
                Obj_UserMaster.user_code = "";
                Obj_UserMaster.user_name = "";
                Obj_UserMaster.addr1 = "";
                Obj_UserMaster.addr2 = "";
                Obj_UserMaster.addr3 = "";
                Obj_UserMaster.addr4 = "";
                Obj_UserMaster.city = "";
                Obj_UserMaster.pincode = "";
                Obj_UserMaster.contact_no = "";
                Obj_UserMaster.sex = "";
                Obj_UserMaster.dob = dtpDob.Value.ToString("yyyy-MM-dd");
                Obj_UserMaster.doj = dtpDoj.Value.ToString("yyyy-MM-dd");
                Obj_UserMaster.desig_name = "";
                Obj_UserMaster.dept_name = "";
                Obj_UserMaster.user_status = "";
                Obj_UserMaster.pwd_flag = false;
                Obj_UserMaster.usergroup_gid = 0;
                Obj_UserMaster.action = "DELETE";

                InwardBusiness objBusiness = new InwardBusiness();
                string[] result = objBusiness.SaveUserMaster(Obj_UserMaster);
                MessageBox.Show(result[0].ToString());
                if (result[1].ToString() == "1")
                {
                    if (DialogResult.Yes == MessageBox.Show("Do you want to add the record?", "", MessageBoxButtons.YesNo))
                    {
                        Clear();
                        frmUserMaster_Load(sender, e);
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(sender,e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
