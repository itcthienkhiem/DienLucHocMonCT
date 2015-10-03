using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using System.Configuration;
namespace Inventory.DanhMuc
{
    public partial class frmKetNoi : Form
    {
        clsThongTinKetNoi ketnoi = null;
        public frmKetNoi()
        {
            InitializeComponent();

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            txtServerName.Text = settings["server_Name"].Value;
            txtUser.Text = settings["user_Name"].Value;
            txtPwd.Text = settings["passwd"].Value;
            txtTenCSDL.Text = settings["ten_CSDL"].Value;

        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {

          
           
               

                ketnoi = new clsThongTinKetNoi(txtServerName.Text, txtUser.Text, txtPwd.Text, txtTenCSDL.Text);

                if (ketnoi.Connect() == true)
                {


                    MessageBox.Show("Kết nối thành công!");
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                    var settings = config.AppSettings.Settings;
                    settings["server_Name"].Value = ketnoi.server_Name;
                    settings["user_Name"].Value = ketnoi.user_Name;
                    settings["passwd"].Value =ketnoi. passwd;
                    settings["ten_CSDL"].Value =ketnoi. ten_CSDL;

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    this.Close();

                }
                else
                    MessageBox.Show("Kết nối thất bại! Vui lòng kiểm tra lại thông tin đăng nhập");

          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
