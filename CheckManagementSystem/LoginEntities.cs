using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManagementSystem
{
    public class LoginEntities
    {
        public int user_id { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string pwd_exp_date { get; set; }

        public int usergroup_gid { get; set; }
        public string pwd_reset_flag { get; set; }
        public string first_login_flag { get; set; }
        public string public_ip { get; set; }
        public string local_ip { get; set; }
        public string msg { get; set; }
        public int result { get; set; }
        public string login_mode { get; set; }
        public string new_pwd { get; set; }
        public string user_mail_id { get; set; }
        public string user_otp { get; set; }
        public string comp_name { get; set; }
        public string comp_code { get; set; }
        public string user_role { get; set; }
        public string user_status { get; set; }
        public int comp_id { get; set; }
    }
}
