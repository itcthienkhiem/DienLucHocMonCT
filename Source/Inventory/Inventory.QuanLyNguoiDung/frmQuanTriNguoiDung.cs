using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Utilities;
namespace Inventory.QuanLyNguoiDung
{
    public partial class frmQuanTriNguoiDung : Form
    {
        public frmQuanTriNguoiDung()
        {
            InitializeComponent();
            clsUser user = new clsUser();
            gridUser.DataSource = user .GetAllData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clsUser user = new clsUser();
            user.User_name = txtTenNguoiDung.Text;
            user.Password = clsThamSoUtilities.CalculateMD5Hash(txtPwd.Text);
            if (user.Insert() == 1)
            {
                MessageBox.Show("Thêm thành công!");
                
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
