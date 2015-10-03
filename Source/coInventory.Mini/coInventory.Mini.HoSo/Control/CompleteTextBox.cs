using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace coInventory.Mini.HoSo
{
    public class CompleteTextBox : TextBox
    {
        private DataGridView _dvgData;
        private bool _isAdded;
        private DataTable _values;
        private String _formerValue = String.Empty;

        private String _DisplayerMember = String.Empty;
        private String _ValueMember = String.Empty;
        private Size _DropDownSize = new Size(400, 155);

        private bool _ManyObject;

        public bool ManyObject
        {
            get { return _ManyObject; }
            set { _ManyObject = value; }
        }

        public Size DropDownSize
        {
            get { return _DropDownSize; }
            set { _DropDownSize = value; }
        }


        public List<CDisplayColumns> DisplayColumns = new List<CDisplayColumns>();

        public CompleteTextBox()
        {
            InitializeComponent();


            this._dvgData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._dvgData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this._dvgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dvgData.Location = new Point(0, 0);
            this._dvgData.Name = "dgvData";
            this._dvgData.Size = _DropDownSize;
            this._dvgData.TabIndex = 0;
            this._dvgData.ReadOnly = true;
            this._dvgData.MultiSelect = false;
            this._dvgData.AllowUserToAddRows = false;
            this._dvgData.AllowUserToDeleteRows = false;
            this._dvgData.RowHeadersVisible = false;
            this._dvgData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this._dvgData.BorderStyle = BorderStyle.Fixed3D;
            this._dvgData.AllowUserToAddRows = false;
            this._dvgData.AllowUserToDeleteRows = false;
            this._dvgData.AllowUserToOrderColumns = true;
            this._dvgData.AllowUserToResizeColumns = false;
            this._dvgData.AllowUserToResizeRows = false;
            this._dvgData.ScrollBars = ScrollBars.Vertical;
            this._dvgData.AutoGenerateColumns = false;
            this._dvgData.BorderStyle = BorderStyle.Fixed3D;

            ((System.ComponentModel.ISupportInitialize)(this._dvgData)).EndInit();
            this.ResumeLayout(false);

            this._dvgData.BackgroundColor = SystemColors.Control;



            _dvgData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            _dvgData.CellClick += new DataGridViewCellEventHandler(dgvData_CellClick);


            //_dvgData.MouseWheel += new MouseEventHandler(_dvgData_MouseWheel);

            ResetListBox();


        }


        private void AddColumnsProgrammatically()
        {
            // I created these columns at function scope but if you want to access 
            // easily from other parts of your class, just move them to class scope.
            // E.g. Declare them outside of the function...

            foreach (CDisplayColumns c in DisplayColumns)
            {
                if (c.isShow)
                {
                    var col = new DataGridViewTextBoxColumn();
                    col.HeaderText = c.ColumnHeader;
                    col.Name = c.ColumnName;
                    col.DataPropertyName = c.ColumnName;
                    _dvgData.Columns.Add(col);
                }
            }


        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dvgData.Visible)
            {
                SelectObject();
                this.Focus();
            }
            ResetListBox();
            //break;
        }



        private void InitializeComponent()
        {
            _dvgData = new DataGridView();
            this.KeyDown += this_KeyDown;
            this.KeyUp += this_KeyUp;
            this.LostFocus += this_Focus;
        }

        public void ShowListBox()
        {
            if (!_isAdded)
            {
                Form parentForm = this.FindForm(); // new line added
                parentForm.Controls.Add(_dvgData); // adds it to the form
                Point positionOnForm = parentForm.PointToClient(this.Parent.PointToScreen(this.Location)); // absolute position in the form
                _dvgData.Left = positionOnForm.X;
                _dvgData.Top = positionOnForm.Y + Height;
                AddColumnsProgrammatically();
                _dvgData.DataSource = Values;
                _isAdded = true;
            }
            _dvgData.Visible = true;
            _dvgData.BringToFront();
        }



        private void ResetListBox()
        {
            _dvgData.Visible = false;
            //_dvgData.ClearSelection();
            this.Invalidate();
        }

        private void this_Focus(object sender, EventArgs e)
        {
            if (_dvgData.Focused)
            {
                return;
            }

            if (_dvgData.Visible)
            {

                SelectObject();

                //this.Focus();
            }
        }


        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }

        private void SelectObject()
        {
            if (_dvgData.SelectedRows.Count > 0)
            {
                if (_ManyObject == true)
                {
                    string[] tmp = Text.Split(';');
                    tmp[tmp.Length - 1] = _DisplayerMember.Trim() == "" ? _dvgData.SelectedRows[0].Cells[0].Value.ToString() : _dvgData.SelectedRows[0].Cells[_DisplayerMember].Value.ToString();
                    Text = "";
                    foreach(string s in tmp)
                    {
                        Text += s + ";";
                    }
                    Text = Text.Substring(0, Text.Length - 1);
                }
                else
                    Text = _DisplayerMember.Trim() == "" ? _dvgData.SelectedRows[0].Cells[0].Value.ToString() : _dvgData.SelectedRows[0].Cells[_DisplayerMember].Value.ToString();

                this.SelectionStart = 0;
                ResetListBox();
                _formerValue = Text;
                this.Select(this.Text.Length, 0);
            }

        }


        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.OemSemicolon:
                case Keys.Enter:
                case Keys.Tab:
                    {
                        if (_dvgData.Visible)
                        {
                            SelectObject();
                            e.Handled = true;
                            //this.Focus();
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_dvgData.Visible) && (_dvgData.SelectedRows[0].Index < _dvgData.RowCount - 1))
                        {
                            _dvgData.Rows[_dvgData.SelectedRows[0].Index + 1].Selected = true;
                            _dvgData.FirstDisplayedScrollingRowIndex = _dvgData.SelectedRows[0].Index;
                        }
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_dvgData.Visible) && (_dvgData.SelectedRows[0].Index > 0))
                        {
                            _dvgData.Rows[_dvgData.SelectedRows[0].Index - 1].Selected = true;
                            _dvgData.FirstDisplayedScrollingRowIndex = _dvgData.SelectedRows[0].Index;
                        }
                        e.Handled = true;
                        break;
                    }
                case Keys.Escape:
                    {
                        ResetListBox();
                        e.Handled = true;
                        break;
                    }


            }
        }


        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    if (_dvgData.Visible && this.Text.Trim().Length > 0)
                        return true;
                    else
                        return false;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void UpdateListBox()
        {

            if (Text == _formerValue)
                return;


            _formerValue = this.Text;
            string word = this.Text;

            string[] strArr = word.Split(';');
            word = strArr[strArr.Length - 1];
            if (_values != null && word.Length >=2)
            {
                // _values.CaseSensitive=true;
                BindingSource bs = new BindingSource();
                bs.DataSource = _values;
                string search = "";
                if (_values.Columns.Count > 0)
                {
                    foreach (CDisplayColumns c in DisplayColumns)
                    {
                        if (c.isSearch)
                        {
                            search += c.ColumnName + " like '%" + word + "%' OR ";
                        }

                    }
                    search = search.Substring(0, search.Length - 3);
                }

                bs.Filter = search;
                //if (bs.Count == 1)
                //{
                //    ShowListBox();
                //    _dvgData.DataSource = bs;
                //    SelectObject();
                //    Focus();
                //}
                //else 
                if (bs.Count > 0)
                {

                    ShowListBox();
                    _dvgData.DataSource = bs;
                    foreach (DataGridViewColumn c in _dvgData.Columns)
                    {

                        if (c.Name.ToLower().Contains("gia"))
                        {
                            c.DefaultCellStyle.Format = "#,##0.00";
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        if (c.Name.ToLower().Contains("ten"))
                            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        else
                            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    Focus();

                }
                else
                {
                    ResetListBox();
                    // ClearSelection();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        public DataTable Values
        {
            get
            {
                return _values;
            }
            set
            {
                this._dvgData.Size = _DropDownSize;
                _values = value;
            }
        }


        public String DisplayMember
        {
            get
            {
                return _DisplayerMember;
            }
            set
            {
                _DisplayerMember = value;
            }
        }

        public String ValueMember
        {
            get
            {
                return _ValueMember;
            }
            set
            {
                _ValueMember = value;
            }
        }



        //public List<CDisplayColumns> DisplayColumns
        //{
        //    get
        //    {
        //        return _DisplayColumns;
        //    }
        //    set
        //    {
        //        _DisplayColumns = value;
        //    }
        //}
        public DataRow SelectedValues
        {
            get
            {

                DataRow row;
                if (_dvgData.SelectedRows.Count > 0 && Text.Length > 0)
                {
                    DataRowView currentDataRowView = (DataRowView)_dvgData.SelectedRows[0].DataBoundItem;
                    row = currentDataRowView.Row;
                    //String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    return row;
                }
                else
                {
                    row = _values.NewRow();

                }
                return row;
            }
        }

        public void UpdateData()
        {
            UpdateListBox();
            _dvgData.Visible = false;
        }

        public void ClearSelection()
        {
            //get
            // {
            _dvgData.ClearSelection();

            //}
        }
        public void ClearValues()
        {
            //get
            // {
            Values = null;

            //}
        }
    }
    public class CDisplayColumns
    {
        public String ColumnName;
        public String ColumnHeader;
        public bool isSearch = false;
        public bool isShow = false;

        public CDisplayColumns(string name, string headerText, bool search, bool show)
        {
            ColumnName = name;
            ColumnHeader = headerText;
            isSearch = search;
            isShow = show;


        }

    }


}
