using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CheckManagementSystem;
using System.Configuration;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public class AdminMasterBusiness
    {
        public static string Usercode;
        public static int Usergroupid;
        public static int UserId;
        public static string Password;

        public DataTable GetUsermaster(string Usercode)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_usercode", Usercode);
                dt = con.RunProc("pr_get_usercode", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetPasswordDtls(int UserId, string newpwd, int slno, string selectflag)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_userid", UserId);
                values.Add("In_newpwd", newpwd);
                values.Add("In_slno", slno);
                values.Add("In_SelectFlag", selectflag);
                dt = con.RunProc("pr_get_passwordhis", values);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public string[] SavePasswordHistory(int UserId, string NewPwd, int PwdSlno, int PwdId, string Action)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_userid", UserId);
                values.Add("In_newpwd", NewPwd);
                values.Add("In_pwdslno", PwdSlno);
                values.Add("In_pwdId", PwdId);
                values.Add("In_action", Action);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("pr_ins_password", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public string[] UpdatePassword(int UserId, string NewPwd, int Slno, string Action)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_userid", UserId);
                values.Add("In_newpwd", NewPwd);
                values.Add("In_slno", Slno);
                values.Add("In_action", Action);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("pr_upd_usermaster", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;

        }

        public string[] SetPassword(string UserName, string OldPwd, string NewPwd, int Slno)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_user_code", UserName);
                values.Add("in_old_pwd", OldPwd);
                values.Add("in_new_pwd", NewPwd);
                values.Add("in_max_pwd_sno", Slno);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("pr_set_password", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public string[] SaveUserGroup(int usergroupid, string usergroupname)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_groupid", usergroupid);
                values.Add("In_groupname", usergroupname);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("pr_ins_usergroup", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public string[] DeleteUserGroupRights(int UserGroupId)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_UserGroupid", UserGroupId);            
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("pr_del_userrights", values);
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public string[] SaveUserGroupRights(string MenuName,int rightsflag,int usergrouprights)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_menu_name", MenuName);
                values.Add("In_rights_flag", rightsflag);
                values.Add("In_usergroup_gid", usergrouprights);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("pr_ins_usergrouprights", values);
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;

        }
        public DataTable GetUserGroupRights(string MenuName,int userGroupid)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_usergroupid", userGroupid);
                values.Add("In_menuname", MenuName);
                dt = con.RunProc("pr_get_usergrouprights", values);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public DataTable GetUserMenuAccess(string MenuName,int usergid,int usergroupid,string usercode,string pwd)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_menu_name", MenuName);
                values.Add("in_user_gid", usergid);
                values.Add("in_usergroup_gid", usergroupid);
                values.Add("in_user_code", usercode);
                values.Add("in_pwd", pwd);
                dt = con.RunProc("pr_get_menuaccess", values);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public string[] SetScanImagePurge (string BatchFromdate,string BatchTodate)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_fromdate", BatchFromdate);
                values.Add("In_todate", BatchTodate);                
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_set_imagepurge", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

    }
}
