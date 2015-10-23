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
using System.Xml;
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

             
            }
            catch (Exception ex) { }
        }
        public static void AddValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
           
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }
        public void updateConfigFile(string con)
        {
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            // XmlDoc.Load("App.config");
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //setting the coonection string
                    xElement.LastChild.Attributes[1].Value = con;
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
           // XmlDoc.Save("App.config");
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {

           // @"data source=KHIEM-PC\SQLEXPRESS" + ";initial catalog=QLKhoDienLuc" + ";persist security info=True;user id=sa" + ";password=2051990" + ";MultipleActiveResultSets=True;";
            StringBuilder Con = new StringBuilder("Data Source=");
            Con.Append(txtServerName.Text);
            Con.Append(";Initial Catalog=");
            Con.Append(txtTenCSDL.Text);
            if (String.IsNullOrEmpty(txtUser.Text) && String.IsNullOrEmpty(txtPwd.Text))
                Con.Append(";Integrated Security=true;");
            else
            {
                Con.Append(";persist security info=True");
                Con.Append(";User Id=");
                Con.Append(txtUser.Text);
                Con.Append(";Password=");
                Con.Append(txtPwd.Text);
                Con.Append(";MultipleActiveResultSets=True;");
            }

            string strCon = Con.ToString();
            DatabaseHelper help = new DatabaseHelper();
            if (help.CheckConnection(strCon) == 0)
            {
                MessageBox.Show("Kết nối thất bại vui lòng kiểm tra lại thông tin ");
                return;
            }
            else
            {
                Utilities.clsThamSoUtilities.connectionString = strCon;
                help.CloseDatabase();
                updateConfigFile(strCon);
                this.Close();
            }
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
