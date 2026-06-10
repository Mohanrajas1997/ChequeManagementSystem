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
    public partial class frmRights : Form
    {
        MenuStrip msl = new MenuStrip();
        public frmRights(MenuStrip ms)
        {
            InitializeComponent();
            msl = ms;
        }

        private void frmRights_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInwardDetails();
                LoadTreeView();
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
        public void LoadTreeView()
        {
            try
            {


                tvwRights.Nodes.Clear();

                for (int i = 0; i < msl.Items.Count; i++)
                {
                    Application.DoEvents();
                    tvwRights.Nodes.Add(msl.Items[i].Name, msl.Items[i].Text.Replace("&", ""), 1);
                    tvwRights.ExpandAll();
                    //ToolStripDropDownItem drp = (ToolStripDropDownItem)msl.Items[i];

                    LoadSubMenuItems(msl.Items[i]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubMenuItems(ToolStripItem toolStripItem)
        {
            try
            {

                ToolStripDropDownItem drp = (ToolStripDropDownItem)toolStripItem;
                if (drp.DropDownItems.Count > 0)
                {
                    for (int i = 0; i < drp.DropDownItems.Count; i++)
                    {
                        if (drp.DropDownItems[i].Text != "")
                        {
                            Application.DoEvents();
                            tvwRights.Nodes.Find(toolStripItem.Name, true)[0].Nodes.Add(drp.DropDownItems[i].Name, drp.DropDownItems[i].Text.Replace("&", ""), 2);


                            tvwRights.ExpandAll();

                            LoadSubMenuItems(drp.DropDownItems[i]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tvwRights.Nodes.Count; i++)
                {
                    tvwRights.Nodes[i].Checked = chkSelectAll.Checked;
                    lf_CheckSubNodes(tvwRights.Nodes[i], chkSelectAll.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lf_CheckSubNodes(TreeNode treeNode, bool lb_check)
        {
            try
            {
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    treeNode.Nodes[i].Checked = chkSelectAll.Checked;
                    lf_CheckSubNodes(treeNode.Nodes[i], chkSelectAll.Checked);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int usergroupid = 0;
                if (cboUserGrp.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select valid User Group !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboUserGrp.Focus();
                    return;
                }
                usergroupid = Convert.ToInt32(cboUserGrp.SelectedValue);
                if (usergroupid > 0)
                {
                    AdminMasterBusiness Obj_UserBusiness = new AdminMasterBusiness();
                    string[] result = Obj_UserBusiness.DeleteUserGroupRights(usergroupid);

                    if (result[1].ToString() == "1")
                    {
                        for (int i = 0; i < tvwRights.Nodes.Count; i++)
                        {
                            InsertSubNode(tvwRights.Nodes[i], usergroupid);
                        }
                    }
                    else
                    {
                        MessageBox.Show(result[0].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("Save Sucessfully!");
                cboUserGrp.Text = "";
                LoadTreeView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertSubNode(TreeNode e, int UserGroupId)
        {
            string lsMenuName = "";
            int lnRights = 0;
            try
            {
                lsMenuName = e.Name;
                if (e.Checked == true)
                {
                    lnRights = 1;
                }
                else
                {
                    lnRights = 0;
                }
                AdminMasterBusiness Obj_Saverights = new AdminMasterBusiness();

                string[] result = Obj_Saverights.SaveUserGroupRights(lsMenuName, lnRights, UserGroupId);

                if (result[1].ToString() == "0")
                {
                    MessageBox.Show(result[0].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < e.Nodes.Count; i++)
                {
                    if (e.Nodes[i].Nodes.Count > 0)
                    {
                        InsertSubNode(e.Nodes[i], UserGroupId);
                    }
                    else
                    {
                        lsMenuName = e.Nodes[i].Name;
                        if (e.Nodes[i].Checked == true)
                        {
                            lnRights = 1;
                        }
                        else
                        {
                            lnRights = 0;
                        }
                        string[] results = Obj_Saverights.SaveUserGroupRights(lsMenuName, lnRights, UserGroupId);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadUserGrp(int UserGrpId)
        {
            for (int i = 0; i < tvwRights.Nodes.Count; i++)
            {
                LoadSubNode(tvwRights.Nodes[i], UserGrpId);
            }
        }
        private void LoadSubNode(TreeNode e, int UserGrpId)
        {
            try
            {
                string lsMenuName = "";
                int lnRights = 0;
                lsMenuName = e.Name;

                AdminMasterBusiness Obj_GetRight = new AdminMasterBusiness();
                DataTable dt = new DataTable();
                dt = Obj_GetRight.GetUserGroupRights(lsMenuName, UserGrpId);
                if(dt.Rows.Count>0)
                {
                    lnRights = Convert.ToInt32(dt.Rows[0]["rights_flag"]);
                }
               
                if (lnRights == 1)
                {
                    e.Checked = true;
                }
                else
                {
                    e.Checked = false;
                }

                for (int i = 0; i < e.Nodes.Count; i++)
                {
                    if (e.Nodes[i].Nodes.Count > 0)
                    {
                        LoadSubNode(e.Nodes[i], UserGrpId);
                    }
                    else
                    {
                        lsMenuName = e.Nodes[i].Name;
                        DataTable dts = new DataTable();
                        dts = Obj_GetRight.GetUserGroupRights(lsMenuName, UserGrpId);
                        if (dts.Rows.Count>0)
                        {
                            lnRights = Convert.ToInt32(dts.Rows[0]["rights_flag"]);
                        }
                        
                        if (lnRights == 1)
                        {
                            e.Nodes[i].Checked = true;
                        }
                        else
                        {
                            e.Nodes[i].Checked = false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboUser_Click(object sender, EventArgs e)
        {
            if (cboUserGrp.SelectedIndex != -1 && cboUserGrp.SelectedIndex != 0)
            {
                int UserGroupid = Convert.ToInt32(cboUserGrp.SelectedValue);
                LoadUserGrp(UserGroupid);
            }
        }

        private void cboUserGrp_TextChanged(object sender, EventArgs e)
        {
            if (cboUserGrp.Text != "" && cboUserGrp.SelectedIndex == -1)
            {
                LoadInwardDetails();
                cboUser_Click(sender, e);
            }
        }

        private void tvwRights_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                 if (tvwRights.SelectedNode.Nodes.Count != 0)
                {
                     if(tvwRights.SelectedNode.Checked == true)
                     {
                         tvwRights.SelectedNode.Checked = false;
                         for (int i = 0; i<tvwRights.Nodes.Count;i++ )
                         {
                             if (tvwRights.SelectedNode.Checked == false)
                             {
                                 tvwRights.SelectedNode.Nodes[i].Checked = false;
                                 lf_SingleCheckSubNodes(tvwRights.SelectedNode.Nodes[i], tvwRights.SelectedNode.Nodes[i].Checked);
                             }
                         }
                     }
                     else
                     {
                         if (tvwRights.SelectedNode.Checked == true)
                         {
                             tvwRights.SelectedNode.Checked = true;
                             for (int i = 0; i < tvwRights.Nodes.Count;i++ )
                             {
                                 if (tvwRights.SelectedNode.Checked == true)
                                 {
                                     tvwRights.SelectedNode.Nodes[i].Checked = true;
                                     lf_SingleCheckSubNodes(tvwRights.SelectedNode.Nodes[i], tvwRights.SelectedNode.Nodes[i].Checked);
                                 }
                             }
                         }
                     }
                }
            }
            catch(Exception ex)
            {
                 MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void  lf_SingleCheckSubNodes(TreeNode e,Boolean lb_Checked)
        {
            try
            {
                for (int k = 0; k < e.Nodes.Count;k++ )
                {
                     e.Nodes[k].Checked = lb_Checked;
                     lf_SingleCheckSubNodes(e.Nodes[k], lb_Checked);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
