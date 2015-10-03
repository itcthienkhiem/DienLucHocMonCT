using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;

namespace coInventory.Mini.DanhMuc
{
    public partial class frmCauHinh : Form
    {
        SystemConfig conf = SystemConfig.Instance;
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void frmCauHinh_Load(object sender, EventArgs e)
        {
            LoadMayIn();


            //SystemConfig conf = SystemConfig.Instance;
            try
            {
                string[] arr = conf.Path_Database.Split(';');
                if (arr.Length >= 2)
                {
                    string[] arr1 = arr[0].Split('=');
                    if (arr1.Length == 2)
                    {
                        txtPathCSDL.Text = arr1[1];
                    }
                }
                else if (arr.Length == 1)
                {
                    txtPathCSDL.Text = conf.Path_Database;
                }
                txtTenDangNhap.Text = conf.Username;
                txtMatKhau.Text = conf.Password;
                txtMaCoSoKCB.Text = conf.MaCSKCB.Trim() == "" ? "": conf.MaCSKCB;
                txtPathXML.Text = conf.PathXML.Trim();

                txtPathBackup.Text = conf.PathBackup.Trim();
                txtMaChiNhanh.Text = conf.MaChiNhanh.Trim();
                txtPathXML.Text = conf.PathXML.Trim();
                txtPathBackup.Text = conf.PathBackup.Trim();

                txtAuth_Username.Text = conf.Auth_Username;
                txtAuth_Pass.Text = conf.Auth_Password;
                txtAuth_Domain.Text = conf.Auth_Domain;
                txtTenSoYTe.Text = conf.TenSYT;
                

                cboTuyen.DataSource = Utilities.Utils.GetTuyen();
                cboTuyen.DisplayMember = "Name";
                cboTuyen.ValueMember = "Value";

                LoadThongTin();
            }
            catch { }
        }

        private PrintDocument printDoc = new PrintDocument();

        private void LoadMayIn()
        {

            // Add list of installed printers found to the combo box. 
            // The pkInstalledPrinters string will be used to provide the display string. 
            int i;
            string pkInstalledPrinters;

            cboMayIn.Items.Clear();
            for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cboMayIn.Items.Add(pkInstalledPrinters);
                if (printDoc.PrinterSettings.IsDefaultPrinter)
                {
                    cboMayIn.Text = printDoc.PrinterSettings.PrinterName;
                }
            }
        }


        private void LoadThongTin()
        {
            try
            {
                clsDM_CSKCB obj = new clsDM_CSKCB();
                obj.GetByKey(txtMaCoSoKCB.Text);
                lblTenCSKCB.Text = obj.TenCSKCB;

                cboTuyen.SelectedValue = obj.Tuyen.ToString();
            }
            catch { }
        }

        private void txtMaCoSoKCB_TextChanged(object sender, EventArgs e)
        {
            if (txtMaCoSoKCB.Text.Length == 6)
            {
                LoadThongTin();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (txtPathCSDL.Text.Trim().Length == 0)
                msg += "- Chọn đường dẫn tập tin CSDL." + Environment.NewLine;
            if (txtMaCoSoKCB.Text.Replace("-", "").Trim().Length< 5)
                msg += "- Nhập mã cơ sở KCB";
            if (msg.Trim() != "")
            {
                MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FileInfo fi = new FileInfo(txtPathCSDL.Text);
            bool exists = fi.Exists;
            if (exists == false)
            {
                MessageBox.Show("Không tồn tại tập tin CSDL.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //SystemConfig conf = SystemConfig.Instance;
            conf.Path_Database = txtPathCSDL.Text.Replace(@"\", @"/");
            conf.MaCSKCB = txtMaCoSoKCB.Text;
            conf.Password = txtMatKhau.Text;
            conf.Username = txtTenDangNhap.Text;
            conf.PathXML = txtPathXML.Text;
            conf.PathBackup = txtPathBackup.Text;
            conf.MaChiNhanh = txtMaChiNhanh.Text;
            
            conf.TenSYT = txtTenSoYTe.Text;


            if (conf.UpdateConfig() == 1)
            {
                MessageBox.Show("Cập nhật thông tin cấu hình thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin cấu hình không thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Database Files (.db)|*.db|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathCSDL.Text = openFileDialog.FileName;                
            }

            
        }

        private void btnMacDinhMayIn_Click(object sender, EventArgs e)
        {
            //Set default may in

            myPrinters.SetDefaultPrinter(cboMayIn.Text);
            LoadMayIn();
            MessageBox.Show("Cấu hình máy in " + cboMayIn.Text + " mặc định.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathXML.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnPathBackup_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathBackup.Text = (folderBrowserDialog.SelectedPath+@"\Database").Replace(@"\\",@"\");
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sao lưu CSDL?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                btnChon.Enabled = false;
                btnPathBackup.Enabled = false;
                btnSaoLuu.Enabled = false;
                btnRestore.Enabled = false;
                btnXML.Enabled = false;
                btnSave.Enabled = false;
                btnMacDinhMayIn.Enabled = false;

                string pathCurrent = Directory.GetCurrentDirectory();
                FileInfo file = null;
                try
                {
                    file = new FileInfo(txtPathCSDL.Text);
                }
                catch
                {
                    file = new FileInfo(pathCurrent + txtPathCSDL.Text);
                }
                if (file != null)
                {
                    progressBar.Visible = true;
                    try
                    {

                        if (!Directory.Exists(txtPathBackup.Text))
                        {
                            Directory.CreateDirectory(txtPathBackup.Text);
                        }

                        XCopy.Copy(file.FullName, txtPathBackup.Text + "\\" + file.Name + ".bak", true, true, (o, pce) =>
                        {
                            progressBar.Value = pce.ProgressPercentage;
                        });

                        

                        MessageBox.Show("Backup thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Backup lỗi, "+Environment.NewLine+ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    progressBar.Visible = false;
                }

                btnChon.Enabled = true;
                btnPathBackup.Enabled = true;
                btnSaoLuu.Enabled = true;
                btnRestore.Enabled = true;
                btnXML.Enabled = true;
                btnSave.Enabled = true;
                btnMacDinhMayIn.Enabled = true;
            }
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn phục hồi CSDL?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                btnChon.Enabled = false;
                btnPathBackup.Enabled = false;
                btnSaoLuu.Enabled = false;
                btnRestore.Enabled = false;
                btnXML.Enabled = false;
                btnSave.Enabled = false;
                btnMacDinhMayIn.Enabled = false;

                string pathCurrent = Directory.GetCurrentDirectory();
                FileInfo file = null;
                try
                {
                    file = new FileInfo(txtPathCSDL.Text);
                }
                catch
                {
                    file = new FileInfo(pathCurrent + txtPathCSDL.Text);
                }
                if (file != null)
                {
                    progressBar.Visible = true;
                    try
                    {
                        

                        XCopy.Copy(txtPathBackup.Text + "\\" + file.Name + ".bak", file.FullName, true, true, (o, pce) =>
                        {
                            progressBar.Value = pce.ProgressPercentage;
                            
                        });

                        
                        MessageBox.Show("Restore thành công.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Restore lỗi," + Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    progressBar.Visible = false;
                }

                btnChon.Enabled = true;
                btnPathBackup.Enabled = true;
                btnSaoLuu.Enabled = true;
                btnRestore.Enabled = true;
                btnXML.Enabled = true;
                btnSave.Enabled = true;
                btnMacDinhMayIn.Enabled = true;
            }
        }

        private void frmCauHinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtMaChiNhanh_Enter(object sender, EventArgs e)
        {
            txtMaChiNhanh.SelectAll();
        }



    }

    public static class myPrinters
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);

    }
}
