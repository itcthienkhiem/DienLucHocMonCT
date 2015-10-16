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
using Inventory.Utilities;
using System.IO;
using Inventory.Models;
namespace Inventory.DanhMuc
{
    public partial class frmKetNoi : Form
    {
        clsThongTinKetNoi ketnoi = null;
        public frmKetNoi()
        {
            InitializeComponent();
            try
            {

                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFile = System.IO.Path.Combine(appPath, "App.config");
                
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = configFile;
              

                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                var settings = config.AppSettings.Settings;
                txtServerName.Text = settings["server_Name"].Value;
                txtUser.Text = settings["user_Name"].Value;
                txtPwd.Text = settings["passwd"].Value;
                txtTenCSDL.Text = settings["ten_CSDL"].Value;
           //     cbKhoLamViec.SelectedIndex =int.Parse( settings["IDKho"].Value.ToString() )-1;
                clsThamSoUtilities.connectionString = config.AppSettings.Settings["ConnectionString"].Value;
               // clsThamSoUtilities.ID_Kho = int.Parse(config.AppSettings.Settings["IDkho"].Value.ToString());

            }
            catch (Exception ex) { }
        }
        public static void AddValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
           
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
                    try
                    {
                        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        string configFile = System.IO.Path.Combine(appPath, "App.config");
                        ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                        configFileMap.ExeConfigFilename = configFile;
                        System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                       
                        config.AppSettings.Settings["ConnectionString"].Value = "Data Source=" + txtServerName.Text + ";Initial Catalog=" + txtTenCSDL.Text + ";User ID=" + txtPwd.Text + ";password=" + txtPwd.Text;
                        config.Save();
                        clsThamSoUtilities.connectionString = config.AppSettings.Settings["ConnectionString"].Value;
                        DatabaseHelper help = new DatabaseHelper();
                        if (help.ConnectDatabase() == 1)
                        {
                            MessageBox.Show("Bạn đã kết nối thành công!");
                            this.Close();
                        }
                            
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    

                    

                   // config.Save(ConfigurationSaveMode.Modified);
            //        ConfigurationManager.RefreshSection("appSettings");

                    this.Close();

            
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
