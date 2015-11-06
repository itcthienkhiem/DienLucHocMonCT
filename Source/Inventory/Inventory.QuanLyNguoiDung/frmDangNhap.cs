using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Utilities;
namespace Inventory.QuanLyNguoiDung
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text;
            string passwd = txtPwd.Text;
            string hash =clsThamSoUtilities. CalculateMD5Hash(passwd);
            clsUser user = new clsUser();
            if (user.checkPasswd(username, hash)==true)
            {
                Utilities.clsThamSoUtilities.isSectionLogin = true;
                MessageBox.Show("Bạn đã đăng nhập thành công!");
                this.Close();
            }
        }
        
    }
}
