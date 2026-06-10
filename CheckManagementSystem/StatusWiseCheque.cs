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
    public partial class StatusWiseCheque : Form
    {
        DataTable dtwise;
        string screen = "";
        public StatusWiseCheque(DataTable dt)
        {
            InitializeComponent();
            dtwise = dt;
        }
        public StatusWiseCheque(DataTable dt, string _screen)
        {
            InitializeComponent();
            dtwise = dt;
            screen = _screen;
        }
        private void StatusWiseCheque_Load(object sender, EventArgs e)
        {
            TheamClass.SetTheam(this);
            if (dtwise.Rows.Count > 0)
            {
                gvstatuswise.DataSource = dtwise;
            }
            if (screen != "")
            {
                lblstatus.Text = "Lot No Against Batch No";
                gvstatuswise.ReadOnly = true;
                //StatusWiseCheque.this.he = "Lot No Against Batch No";
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
