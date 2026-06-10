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
    public partial class RHEVBackup : Form
    {
        public RHEVBackup()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            try
            {
                button1.Enabled = false;
                button2.Enabled = false;
                string result=string.Empty;
                ScannerBusiness busobj = new ScannerBusiness();
                RhevEntities obj = new RhevEntities();
                obj.from_date = fromdate.Value.ToString("yyyy/MM/dd");
                obj.to_date = todate.Value.ToString("yyyy/MM/dd");
                result= busobj.GetRHEVData(obj);
                button1.Enabled = true;
                button2.Enabled = true;
                if (result == "Success")
                {
                    MessageBox.Show("Data Backup  Successfuly Completed.....");
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                button1.Enabled = true;
                button2.Enabled = true;
            }
            PicLoad.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PicLoad.Visible = true;
            try
            {
                button1.Enabled = false;
                button2.Enabled = false;
                string result = string.Empty;
                ScannerBusiness busobj = new ScannerBusiness();
                RhevEntities obj = new RhevEntities();
                obj.from_date = fromdate.Value.ToString("yyyy/MM/dd");
                obj.to_date = todate.Value.ToString("yyyy/MM/dd");
                result=busobj.GetRestoreData(obj);
                button1.Enabled = true;
                button2.Enabled = true;
                if (result == "Success")
                {
                    MessageBox.Show("Data Restore  Successfuly Completed.....");
                }
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
            PicLoad.Visible = false;
        }

        private void fromdate_ValueChanged(object sender, EventArgs e)
        {
          //  todate.MinDate = new DateTime(Convert.ToInt32(fromdate.Value.Year),Convert.ToInt32(fromdate.Value.Month),Convert.ToInt32(fromdate.Value.Date));
        }

        private void RHEVBackup_Load(object sender, EventArgs e)
        {
            TheamClass.SetTheam(this);
        }

    }
}
