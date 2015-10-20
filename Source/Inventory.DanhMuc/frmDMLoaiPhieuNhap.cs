using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Models;
using System.Reflection;
namespace Inventory.DanhMuc
{
    /// <summary>
    /// Write by Khiêm
    /// 
    /// Editing...
    /// To-Do LIST
    /// [x] Chuyển Status về class, use func thay gì set trực tiếp
    /// [.] B1: Chuyển phần set button về func tập trung --> B2: Tạo 1 class làm việc này
    /// * Problem
    /// [ ] Bỏ tính năng xóa trực tiếp, chuyển dùng biến trạng thái True == Deleted | False.
    /// [ ] ?
    /// </summary>
    public partial class frmDMLoaiPhieuNhap : Form
    {
        FormActionDelegate frmAction;

        //Data
        clsLoaiPhieuNhap DM_Kho1;

        //Quản lý Button
        clsPanelButton PanelButton;

        public frmDMLoaiPhieuNhap()
        {
            InitializeComponent();

            //Init Data
            //  Loai_Phieu_Nhap DM_Kho1= new clsLoaiPhieuNhap();

            //Init cls Button
            PanelButton = new clsPanelButton();

            frmAction = new FormActionDelegate(FormAction);
            PanelButton.setDelegateFormAction(frmAction);

            //enumButton dùng định danh button
            PanelButton.AddButton(enumButton.Them, ref btnThem);
            PanelButton.AddButton(enumButton.Xoa, ref btnXoa);
            PanelButton.AddButton(enumButton.Sua, ref btnSua);
            PanelButton.AddButton(enumButton.LamMoi, ref btnLamMoi);
            PanelButton.AddButton(enumButton.Luu, ref btnLuu);
            PanelButton.AddButton(enumButton.Huy, ref btnHuy);
            PanelButton.AddButton(enumButton.Dong, ref btnDong);

            LoadData();

            PanelButton.ResetButton();
        }

        public void FormAction(enumFormAction frmAct)
        {
            switch (frmAct)
            {
                case enumFormAction.None:
                    break;
                case enumFormAction.LoadData:
                    LoadData();
                    break;
                case enumFormAction.CloseForm:
                    CloseForm();
                    break;
                case enumFormAction.setFormData:
                    setFormData();
                    break;
                case enumFormAction.ResetInputForm:
                    ResetInputForm();
                    break;
                case enumFormAction.Luu:
                    break;
                case enumFormAction.Huy:
                    break;
                case enumFormAction.Dong:
                    break;
                default:
                    break;
            }
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void setFormData()
        {
            Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;

            DataGridViewRow SelectedRow = gridDMKho.Rows[selectedRowCount];

            txtTenLoai.Text = SelectedRow.Cells["Ten_loai_phieu_nhap"].Value.ToString();
            txtMaLoai.Text = SelectedRow.Cells["Ma_loai_phieu_nhap"].Value.ToString();

        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        /// <summary>
        /// Data --> Grid.
        /// </summary>
        public void LoadData()
        {

            gridDMKho.DataSource = new clsLoaiPhieuNhap().GetAllData() ;

            gridDMKho.Refresh();
        }

        /// <summary>
        /// Resets the input form.
        /// </summary>
        public void ResetInputForm()
        {
            if (PanelButton.isClickNone())
            {
                txtTenLoai.Text = "";
            }
        }


        /// <summary>
        /// Lưu -> Thêm, Xóa, Sửa | Tùy theo Button nào dc Click
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_Kho1 = new clsLoaiPhieuNhap();
            if (txtTenLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên kho không được phép rỗng!");
                return;
            }
            switch (PanelButton.getClickStatus())
            {
                case enumButton.Them:
                    {
                        DM_Kho1.Ma_LPN = txtMaLoai.Text.Trim();
                        DM_Kho1.Ten_LPN = txtTenLoai.Text.Trim();
                        
                        if (!DM_Kho1.KiemTraTrungMa())
                        {
                            if (DM_Kho1.Insert() == 1)
                            {
                                //MessageBox.Show("Bạn đã thêm thành công !");
                                AutoClosingMessageBox.Show("Bạn đã thêm thành công !", "Thông báo", 1000);

                                //Reset status
                                PanelButton.ResetClickStatus();
                                gridDMKho.Refresh();
                                LoadData();

                                PanelButton.ResetButton();

                                //Reset input
                                ResetInputForm();
                            }
                            else
                                //AutoClosingMessageBox.Show("Lỗi: Bạn đã thêm thất bại!", "Thông báo", 1000);
                                MessageBox.Show("Lỗi: Bạn đã thêm thất bại!");

                        }
                        else
                            //AutoClosingMessageBox.Show("Lỗi: Kho đã tồn tại!", "Thông báo", 1000);
                            MessageBox.Show("Lỗi: Kho đã tồn tại!");
                        break;
                    }
                case enumButton.Xoa:
                    {
                        DM_Kho1.Ma_LPN = txtMaLoai.Text;

                        Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
                        DM_Kho1.Ma_LPN = (gridDMKho.Rows[selectedRowCount].Cells["Ma_loai_phieu_nhap"].Value.ToString());
                        DM_Kho1.Ten_LPN = (gridDMKho.Rows[selectedRowCount].Cells["Ten_loai_phieu_nhap"].Value.ToString());
                        DM_Kho1.ID_LPN =int.Parse (gridDMKho.Rows[selectedRowCount].Cells["ID_loai_phieu_nhap"].Value.ToString());

                        DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn xóa không ?", "Cảnh báo!", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            Loai_Phieu_Nhap kho = new Loai_Phieu_Nhap();
                            kho.ID_Loai_Phieu_Nhap = DM_Kho1.ID_LPN;
                            kho.Ma_loai_phieu_nhap = DM_Kho1.Ma_LPN;
                            kho.Ten_loai_phieu_nhap= DM_Kho1.Ten_LPN;
                            if (DM_Kho1.Delete(kho) == 1)
                            {
                                //MessageBox.Show("Bạn đã xóa thành công !");

                                //Reset
                                PanelButton.ResetClickStatus();

                                LoadData();

                                PanelButton.ResetButton();

                                ResetInputForm();
                            }
                            else
                                //AutoClosingMessageBox.Show("Lỗi: Bạn đã xóa thất bại!", "Thông báo", 1000);
                                MessageBox.Show("Lỗi: Bạn đã xóa thất bại!");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                        break;
                    }
                case enumButton.Sua:
                    {
                        DM_Kho1 = new clsLoaiPhieuNhap();
                        DM_Kho1.Ma_LPN = txtMaLoai.Text;
                        DM_Kho1.Ten_LPN= txtTenLoai.Text;

                        Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;

                        if (selectedRowCount >= 0)
                        {
                            DM_Kho1.ID_LPN= int.Parse(gridDMKho.Rows[selectedRowCount].Cells["ID_loai_phieu_nhap"].Value.ToString());
                            Loai_Phieu_Nhap kho = new Loai_Phieu_Nhap();
                            kho.ID_Loai_Phieu_Nhap= DM_Kho1.ID_LPN;
                            kho.Ma_loai_phieu_nhap = DM_Kho1.Ma_LPN;
                            kho.Ten_loai_phieu_nhap = DM_Kho1.Ten_LPN;

                            if (DM_Kho1.Update(kho) == 1)
                            {
                                //MessageBox.Show("Bạn đã cập nhật thành công !");
                                AutoClosingMessageBox.Show("Bạn đã cập nhật thành công !", "Thông báo", 1000);

                                //Reset
                                PanelButton.ResetClickStatus();
                                //   gridDMKho.Refresh();


                                PanelButton.ResetButton();
                                LoadData();
                                ResetInputForm();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi: Bạn đã cập nhật thất bại!");
                                //AutoClosingMessageBox.Show("Lỗi: Bạn đã cập nhật thất bại!", "Thông báo", 1000);
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Đổi stt --> khi Xóa | Sửa
        /// </summary>
        private void gridDMKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = gridDMKho.CurrentCell.RowIndex;
            if (selectedRowCount >= 0 && PanelButton.isClickXoa() || PanelButton.isClickSua())
            {
                txtTenLoai.Text = gridDMKho.Rows[selectedRowCount].Cells["Ten_kho"].Value.ToString();
            }
            // txtTenKho.Text = cell.Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
