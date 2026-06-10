using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckManagementSystem
{
    public class ComboBoxColumn : DataGridViewComboBoxColumn
    {
        public ComboBoxColumn()
        {
            ComboBoxCell cbc = new ComboBoxCell();
            this.CellTemplate = cbc;
        }
    }
    public class ComboBoxCell : DataGridViewComboBoxCell
    {
        public ComboBoxCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            ComboBoxControl ctl = DataGridView.EditingControl as ComboBoxControl;
            //ctl.DropDownStyle = ComboBoxStyle.DropDownList;
            if (ctl != null)
            {
                ctl.DropDownStyle = ComboBoxStyle.Simple;
                ctl.SelectedIndex = 0;
            }
        }
    }
    public class ComboBoxControl : ComboBox, IDataGridViewEditingControl
    {
        private int index_ = 0;
        private DataGridView dataGridView_ = null;
        private bool valueChanged_ = false;

        public ComboBoxControl()
            : base()
        {
            this.SelectedIndexChanged += new EventHandler(ComboBoxControl_SelectedIndexChanged);
        }

        public void ComboBoxControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I will add code here
            NotifyDataGridViewOfValueChange();
        }


        protected virtual void NotifyDataGridViewOfValueChange()
        {
            this.valueChanged_ = true;
            if (this.dataGridView_ != null)
            {
                this.dataGridView_.NotifyCurrentCellDirty(true);
            }
        }

        #region IDataGridViewEditingControl members


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }


        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView_;
            }
            set
            {
                dataGridView_ = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return base.SelectedValue;
            }
            set
            {
                base.SelectedValue = value;
                NotifyDataGridViewOfValueChange();
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return index_;
            }
            set
            {
                index_ = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged_;
            }
            set
            {
                valueChanged_ = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            if (keyData == Keys.Return)
                return true;
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Return:
                    return true;
                default:
                    return false;
            }
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue.ToString();
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }
        #endregion
    }
}
