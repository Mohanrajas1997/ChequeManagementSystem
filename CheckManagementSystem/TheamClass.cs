using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace CheckManagementSystem
{
    class TheamClass
    {
        public static void SetTheam(System.Windows.Forms.Form InFrm)
        {
            Font pnlfont = new Font("Calibri", 12.0f, FontStyle.Regular);
            Font grdfont = new Font("Calibri", 12.0f, FontStyle.Regular);
            InFrm.BackColor = Color.White;
            //Control.ControlCollection cc = InFrm.Controls;           
            //for (int i = 0; i < cc.Count; i++)
            //{
            //   string s= cc[i].GetType().ToString();
            //    //if (cc[i].GetType == System.Windows.Forms.MenuStrip)
            //   if (cc[i].GetType() == typeof(System.Windows.Forms.MenuStrip))
            //   {
            //       MessageBox.Show(cc[i].ToString());
            //      // setLanguageText(cc[i].Controls);
            //   }

            //}

            if (InFrm.IsMdiChild == true)
            {
                //InFrm.Left = 0;
                //InFrm.Top = 0;
                //InFrm.Size = ParentForm.ClientRectangle.Size;
                List<Control> controls = InFrm.Controls.Cast<Control>().ToList();
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i].GetType() == typeof(System.Windows.Forms.Panel))
                    {
                        
                        controls[i].BackColor = Color.White;//Color.FromArgb(60, 141, 188);
                        controls[i].ForeColor = Color.Blue;
                        controls[i].Font = pnlfont;
                        GetChildPanelControl(controls[i]);
                    }
                    if (controls[i].GetType() == typeof(System.Windows.Forms.ToolStrip))
                    {
                        controls[i].BackColor = Color.FromArgb(60, 141, 188);
                        controls[i].Font = pnlfont;
                        GetToolStripControl(controls[i]);
                    }
                    if (controls[i].GetType() == typeof(System.Windows.Forms.DataGridView))
                    {
                        controls[i].BackColor = Color.FromArgb(60, 141, 188);
                        controls[i].Font = pnlfont;
                        controls[i].ForeColor= Color.Black;
                        GetDataGridControl(controls[i]);
                    }
                    if (controls[i].GetType() == typeof(System.Windows.Forms.TabControl))
                    {
                        controls[i].BackColor = Color.White;//Color.FromArgb(60, 141, 188);
                        controls[i].ForeColor = Color.Blue;
                    }
                    if (controls[i].GetType() == typeof(System.Windows.Forms.TabPage))
                    {
                        controls[i].BackColor = Color.White;//Color.FromArgb(60, 141, 188);
                        controls[i].ForeColor = Color.Blue;
                    }
                }
            }
            else
            {
                List<Control> controls = InFrm.Controls.Cast<Control>().ToList();
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i].GetType() == typeof(System.Windows.Forms.Panel))
                    {
                        controls[i].BackColor = Color.White;//Color.FromArgb(60, 141, 188);
                        controls[i].ForeColor = Color.Blue;
                        controls[i].Font = pnlfont;
                        GetPanelControl(controls[i]);
                    }
                    if (controls[i].GetType() == typeof(System.Windows.Forms.ToolStrip))
                    {
                        controls[i].BackColor = Color.FromArgb(60, 141, 188);
                        controls[i].Font = pnlfont;
                        GetToolStripControl(controls[i]);
                    }
                }
            }
        }
        public static void SetBGAndFGClor(System.Windows.Forms.Form InFrm)
        {
            Control.ControlCollection cc = InFrm.Controls;
            for (int i = 0; i < cc.Count; i++)
            {
                if (InFrm.IsMdiChild)
                {
                    InFrm.BackColor = System.Drawing.Color.Wheat;
                    cc[i].BackColor = System.Drawing.Color.Wheat;
                    cc[i].ForeColor = System.Drawing.Color.Black;
                }
            }
            //return 0;
        }

        public static void GetMenuStyle(Control menuStrip)
        {
            MenuStrip cc = (MenuStrip)menuStrip;
            cc.BackColor = Color.FromArgb(60, 141, 188);
            cc.ForeColor = System.Drawing.Color.White;
            foreach (ToolStripMenuItem mainmenu in cc.Items)
            {
                mainmenu.BackColor = Color.FromArgb(60, 141, 188);
                mainmenu.ForeColor = System.Drawing.Color.White;
                int k = 0;
                foreach (ToolStripItem item in mainmenu.DropDownItems)
                {
                    item.BackColor = Color.FromArgb(60, 141, 188);
                    item.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        public static void GetPanelControl(Control panel)
        {
            List<Control> controls = panel.Controls.Cast<Control>().ToList();

            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(System.Windows.Forms.MenuStrip))
                {
                    controls[i].BackColor = Color.FromArgb(60, 141, 188);
                    GetMenuStyle(controls[i]);
                }
                if (controls[i].GetType() == typeof(System.Windows.Forms.Panel))
                {
                    controls[i].BackColor = Color.White;   // Color.FromArgb(60, 141, 188);
                    GetPanelControl(controls[i]);
                }
            }
        }

        public static void GetChildPanelControl(Control panel)
        {
            List<Control> controls = panel.Controls.Cast<Control>().ToList();

            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(System.Windows.Forms.MenuStrip))
                {
                    controls[i].BackColor = Color.FromArgb(60, 141, 188);
                    GetMenuStyle(controls[i]);
                }
                if (controls[i].GetType() == typeof(System.Windows.Forms.Panel))
                {
                    controls[i].BackColor = Color.FromArgb(60, 141, 188);
                    GetPanelControl(controls[i]);
                    List<Control> controls1 = panel.Controls.Cast<Control>().ToList();
                    for (int b = 0; b < controls.Count; b++)
                    {
                        if (controls1[b].GetType() == typeof(System.Windows.Forms.DataGridView))
                        {
                            controls[b].BackColor = Color.FromArgb(60, 141, 188);
                            controls[b].Font = new Font("Calibri", 14, FontStyle.Regular);
                            controls[b].ForeColor = Color.Black;
                            GetDataGridControl(controls1[b]);
                        }
                    }
                     
                }
                if (controls[i].GetType() == typeof(System.Windows.Forms.Button))
                {
                    controls[i].BackColor = Color.FromArgb(60, 141, 188);
                    controls[i].ForeColor = Color.White;
                    //controls[i].Height = 28;
                }
            }
        }

        public static void GetToolStripControl(Control ToolStrip)
        {
            ToolStrip cc = (ToolStrip)ToolStrip;
            cc.BackColor = Color.FromArgb(60, 141, 188);
            cc.ForeColor = System.Drawing.Color.White;
            foreach (ToolStripButton mainmenu in cc.Items)
            {
                mainmenu.BackColor = Color.FromArgb(60, 141, 188);
                mainmenu.ForeColor = System.Drawing.Color.White;
                int k = 0;
                //foreach (ToolStripItem item in mainmenu.DropDownItems)
                //{
                //    item.BackColor = Color.FromArgb(60, 141, 188);
                //    item.ForeColor = System.Drawing.Color.White;
                //}
            }
        }

        public static void GetDataGridControl(Control ToolStrip)
        {
            // Font font = new Font("Comic Sans MS, Verdana", 10.0f, FontStyle.Regular | FontStyle.Regular | FontStyle.Regular);
            DataGridView cc = (DataGridView)ToolStrip;
            cc.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);
            //cc.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.MenuHighlight;
            //cc.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            cc.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            cc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cc.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn c in cc.Columns)
            {
                c.HeaderCell.Style.ForeColor = Color.White;
                c.DefaultCellStyle.Font = new Font("Calibri", 12, GraphicsUnit.Pixel);
            }
        }

        //public static void GetDataGridControl(Control ToolStrip)
        //{
        //    // Font font = new Font("Comic Sans MS, Verdana", 10.0f, FontStyle.Regular | FontStyle.Regular | FontStyle.Regular);
        //    DataGridView cc = (DataGridView)ToolStrip;
        //    foreach (DataGridViewColumn c in cc.Columns)
        //    {
        //        c.DefaultCellStyle.Font = new Font("Comic Sans MS, Verdana", 20.0F, GraphicsUnit.Pixel);
        //    }
        //}

    }
}
