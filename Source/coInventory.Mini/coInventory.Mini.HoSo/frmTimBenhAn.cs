using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;

namespace coInventory.Mini.HoSo
{
    public partial class frmTimBenhAn : Form
    {
        public string m_Loai="";
        public string m_SoLuuTru = "";
        public frmTimBenhAn()
        {
            InitializeComponent();
        }

        private void frmTimBenhAn_Load(object sender, EventArgs e)
        {
            LoadGridview();
        }
        private void LoadGridview()
        {
            clsBenhAn obj = new clsBenhAn();
            dTableBenhAn = obj.GetAll(m_Loai);
            gridMaster.DataSource = dTableBenhAn;
        }

        private void gridMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void gridMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMaster.SelectedRows.Count > 0)
            {
                m_SoLuuTru = gridMaster.CurrentRow.Cells["SoLuuTru"].Value.ToString();
                Close();
            }
        }

    }
}
