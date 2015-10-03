using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;

namespace coInventory.Mini.HoSo
{
    public partial class frmTimHoSo : Form
    {
        public int mBangKe_Id;
        public int mLoaiBangKe;
        public frmTimHoSo()
        {
            InitializeComponent();
        }

        private void frmTimHoSo_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value= dtpDenNgay.Value.AddMonths(-1);
            LoadGridview();
        }

        private void LoadGridview()
        {
            clsBangKe obj = new clsBangKe();
            dTableBangKe = obj.GetByKey(dtpTuNgay.Value, dtpDenNgay.Value, mLoaiBangKe);
            gridMaster.DataSource = dTableBangKe;
        }

        private void gridMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMaster.SelectedRows.Count > 0)
            {
                mBangKe_Id = int.Parse(gridMaster.CurrentRow.Cells["BangKe_Id"].Value.ToString());
                Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            clsBangKe obj = new clsBangKe();
            dTableBangKe= obj.GetByKey(dtpTuNgay.Value, dtpDenNgay.Value,mLoaiBangKe);
            gridMaster.DataSource = dTableBangKe;
        }

        private void txtTimNhanh_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dTableBangKe;
            string search = "MaKhamChuaBenh like '%"+txtTimNhanh.Text+"%' or HoTen like '%"+txtTimNhanh.Text+"%'";
            bs.Filter = search;
            gridMaster.DataSource = bs;
        }

        private void gridMaster_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(gridMaster.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 5, e.RowBounds.Location.Y + 5);
            }
        }



     

        
    }
}
