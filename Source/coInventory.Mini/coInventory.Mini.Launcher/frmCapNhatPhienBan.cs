using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using Ionic.Zip;
using System.Diagnostics;
using System.Configuration;

namespace coInventory.Mini.Launcher
{
    public partial class frmCapNhatPhienBan : Form
    {

        Configuration config;
        public frmCapNhatPhienBan()
        {
            this.Hide();
            InitializeComponent();
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = Directory.GetCurrentDirectory() + "/coInventory.Mini.exe.Config";
            config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }
        string TapTin = "";
        string TenPhienBan = "";
        int RevisionNew = 0;
        int RevisionCurrent = 0;
        string MoTa = "";
        string WebService = "";
        string LinkUpdate = "";
        private void CapNhatPhienBanMoi()
        {
            try
            {
                //Lấy phiên bản hiện tại

                if (!string.IsNullOrEmpty(config.AppSettings.Settings["Revision"].Value))
                {
                    RevisionCurrent = int.Parse(config.AppSettings.Settings["Revision"].Value);
                }

                //Đọc link từ file config
                string LinkMayChu = "";
                if (config.AppSettings.Settings["LinkUpdate"] != null)
                {
                    LinkMayChu = config.AppSettings.Settings["LinkUpdate"].Value;
                }


                //Đọc thông tin phiên bản
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(LinkMayChu + "/Version.xml");
                req.Timeout = 1000 * 5; // 10s 
                System.Net.WebResponse res = req.GetResponse();
                Stream responseStream = res.GetResponseStream();
                XmlDocument xml = new XmlDocument();
                xml.Load(responseStream);

                //Đọc phiên bản mới từ Máy chủ
                if (!string.IsNullOrEmpty(xml.SelectSingleNode("/CapNhat").Attributes["Revision"].Value))
                {
                    RevisionNew = int.Parse(xml.SelectSingleNode("/CapNhat").Attributes["Revision"].Value);
                    TenPhienBan = (xml.SelectSingleNode("/CapNhat").Attributes["TenPhienBan"].Value);
                }



                if (LinkMayChu.Trim() != xml.SelectSingleNode("/CapNhat/MayChu").InnerText.Trim())
                {
                    LinkUpdate = xml.SelectSingleNode("/CapNhat/MayChu").InnerText;
                }
                //end cap nh

                MoTa = xml.SelectSingleNode("/CapNhat/MoTa").InnerText;
                WebService = xml.SelectSingleNode("/CapNhat/WebService").InnerText;

                //Nếu phiên bản
                if (RevisionNew > RevisionCurrent)
                {
                    if (MessageBox.Show("Phiên bản " + TenPhienBan + ": " + MoTa + Environment.NewLine + "Bạn có muốn cập nhật phiên bản mới?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        this.Show();
                        TapTin = xml.SelectSingleNode("/CapNhat/TapTin").InnerText;

                        string MayChu = xml.SelectSingleNode("/CapNhat/MayChu").InnerText;

                        string DuongDanHienTai = Directory.GetCurrentDirectory();


                        WebClient client = new WebClient();
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

                        // Starts the download
                        client.DownloadFileAsync(new Uri(MayChu + "/" + TapTin), string.Format("{0}/{1}", DuongDanHienTai, TapTin));
                        return;
                    }

                }

            }
            catch
            {
            }
            Process.Start("coInventory.Mini.exe");
            Close();
        }

        public void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var settings = config.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            string dangtai = "";
            string tongdungluong = "";

            if (bytesIn / (1024 * 1024) < 1)
            {
                dangtai += Math.Round(bytesIn / (1024), 2, MidpointRounding.ToEven) + " KB";
            }
            else if (bytesIn / (1024 * 1024) >= 1)
            {
                dangtai += Math.Round(bytesIn / (1024 * 1024), 2, MidpointRounding.ToEven) + " MB";
            }

            if ((totalBytes / 1024) < 1024)
            {
                tongdungluong += Math.Round(totalBytes / (1024), 2, MidpointRounding.ToEven) + " KB";
            }
            else if ((totalBytes / 1024) >= 1024)
            {
                tongdungluong += Math.Round(totalBytes / (1024 * 1024), 2, MidpointRounding.ToEven) + " MB";
            }

            lblDungLuong.Text = dangtai + "/" + tongdungluong;
            double percentage = (bytesIn / totalBytes) * 100;

            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                Process[] lst = Process.GetProcessesByName("coInventory.Mini");
                if (lst.Length > 0)
                {
                    foreach (var process in Process.GetProcessesByName("coInventory.Mini"))
                    {
                        process.Kill();
                    }
                }
                using (ZipFile zip = ZipFile.Read(TapTin))
                {
                    zip.ExtractAll(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);
                }
                MoveDirectory(Directory.GetCurrentDirectory() + "/" + TapTin.Replace(".zip", ""), Directory.GetCurrentDirectory());
                if (File.Exists(TapTin))
                {
                    File.Delete(TapTin);
                }
                AddOrUpdateAppSettings("Revision", RevisionNew.ToString());
                AddOrUpdateAppSettings("TenPhienBan", TenPhienBan);
                AddOrUpdateAppSettings("WebService", WebService);
                if (LinkUpdate != "")
                {
                    AddOrUpdateAppSettings("LinkUpdate", LinkUpdate);
                }
            }
            catch
            {
                MessageBox.Show("Cập nhật dữ liệu không thành công!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Process.Start("coInventory.Mini.exe");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapNhatPhienBanMoi();
        }
        public static void MoveDirectory(string source, string target)
        {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                    string targetFile = Path.Combine(folders.Target, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }

                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                }
            }
            Directory.Delete(source, true);
        }
        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target)
            {
                Source = source;
                Target = target;
            }
        }

        private void frmCapNhatPhienBan_Load(object sender, EventArgs e)
        {
            CapNhatPhienBanMoi();
        }
    }
}
