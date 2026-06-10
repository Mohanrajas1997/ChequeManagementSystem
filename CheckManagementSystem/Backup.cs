using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public partial class Backup : Form
    {
        private MySqlConnection con;
        private MySqlConnection conn;
        private MySqlCommand cmd;
        MySqlTransaction trans;
        string constring = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        public Backup()
        {
            InitializeComponent();
        }
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    string sd = Convert.ToDateTime(dtStartDate.Text).ToString("yyyy-MM-dd");
                    string ed = Convert.ToDateTime(dtEndDate.Text).ToString("yyyy-MM-dd");

                    conn.Open();
                    using (trans = conn.BeginTransaction())
                    {
                        using (MySqlCommand command = conn.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO cms_trn_scanningtemp(batch_no,cheq_no,sort_code,base_code,tran_code,front_image, " +
"back_image,front_uv_image,back_uv_image,status,created_datetime,created_by,modified_datetime,modified_by,grey_front,grey_back)  " +
" SELECT batch_no,cheq_no,sort_code,base_code,tran_code, front_image,back_image,front_uv_image,back_uv_image," +
"status,created_datetime,created_by,modified_datetime,modified_by,grey_front,grey_back" +
 " FROM cms_trn_scanning where cast(created_datetime as date) >= '" + sd + "' and cast(created_datetime as date) >= '" + ed + "'";
                            command.ExecuteNonQuery();
                            command.CommandText = "DELETE FROM cms_trn_scanning where cast(created_datetime as date) >= '" + sd + "' and cast(created_datetime as date) >= '" + ed + "'";
                            command.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
        }
        private void Backup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
