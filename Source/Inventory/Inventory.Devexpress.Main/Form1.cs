using Inventory.DanhMuc;
using Inventory.Models;
using Inventory.QuanLyNguoiDung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Inventory.Devexpress.Main
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DM_Vattu f = new DM_Vattu();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DocFileCauHinh();
        }

        private void DocFileCauHinh()
        {
            try
            {

                XmlDocument XmlDoc = new XmlDocument();
                //Loading the Config file
                XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                // XmlDoc.Load("App.config");
                foreach (XmlElement xElement in XmlDoc.DocumentElement)
                {
                    if (xElement.Name == "connectionStrings")
                    {
                        //setting the coonection string
                        var temp = xElement.LastChild.Attributes[1].Value;
                        try
                        {
                            DatabaseHelper help = new DatabaseHelper();
                            if (help.CheckConnection((string)temp) == 0)
                            {
                                frmKetNoi frm = new frmKetNoi();
                                frm.MdiParent = this;
                                // Display the new form.
                                frm.Show();
                            }
                            else
                            {
                                Utilities.clsThamSoUtilities.connectionString = temp;
                                help.CloseDatabase();
                            }//
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    if (xElement.Name == "appSettings")
                    {
                        bool temp = bool.Parse(xElement.ChildNodes.Item(0).Attributes[1].Value);
                        if (temp == true)
                        {
                            frmDangNhap frm = new frmDangNhap();
                            frm.MdiParent = this;
                            // Display the new form.
                            frm.Show();
                            return;
                        }
                        Utilities.clsThamSoUtilities.isSectionLogin = true;
                    }
                }
                //writing the connection string in config file
                //    XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                //clsThamSoUtilities.ID_Kho = int.Parse(config.AppSettings.Settings["IDkho"].Value.ToString());
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Chưa cấu hình CSDL! Vui lòng cấu hình hệ thống trước.");
            }
        }
    }
}
