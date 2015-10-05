using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory.DanhMuc
{
    public enum enumButton : byte { None = 0, Them, Xoa, Sua, LamMoi, Luu, Huy, Dong };

    class clsPanelButton
    {
        enumButton clickStatus;

        private Button btnThem = null;
        private Button btnXoa = null;
        private Button btnSua = null;
        private Button btnLamMoi = null;
        private Button btnLuu = null;
        private Button btnHuy = null;
        private Button btnDong = null;

        public clsPanelButton()
        {
            clickStatus = enumButton.None;
        }

        public void AddButton(enumButton eBtn, ref Button btn)
        {
            switch (eBtn)
            {
                case enumButton.None:
                    break;
                case enumButton.Them:
                    btnThem = btn;
                    btnThem.EnabledChanged += new System.EventHandler(btnThem_EnabledChanged);
                    break;
                case enumButton.Xoa:
                    btnXoa = btn;
                    btnXoa.EnabledChanged += new System.EventHandler(btnXoa_EnabledChanged);
                    break;
                case enumButton.Sua:
                    btnSua = btn;
                    btnSua.EnabledChanged += new System.EventHandler(btnSua_EnabledChanged);
                    break;
                case enumButton.LamMoi:
                    btnLamMoi = btn;
                    btnLamMoi.EnabledChanged += new System.EventHandler(btnLamMoi_EnabledChanged);
                    break;
                case enumButton.Luu:
                    btnLuu = btn;
                    btnLuu.EnabledChanged += new System.EventHandler(btnLuu_EnabledChanged);
                    break;
                case enumButton.Huy:
                    btnHuy = btn;
                    btnHuy.EnabledChanged += new System.EventHandler(btnHuy_EnabledChanged);
                    break;
                case enumButton.Dong:
                    btnDong = btn;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Thêm, xóa, sửa, làm mới -> True | Lưu, Hủy -> False
        /// </summary>
        public void ResetButton()
        {
            if (isClickNone())
            {
                if (btnThem != null) btnThem.Enabled = true;
                if (btnXoa != null) btnXoa.Enabled = true;
                if (btnSua != null) btnSua.Enabled = true;
                if (btnLamMoi != null) btnLamMoi.Enabled = true;

                if (btnLuu != null) btnLuu.Enabled = false;
                if (btnHuy != null) btnHuy.Enabled = false;
            }
        }

        /// <summary>
        /// Fire when stt Thêm, Xóa, Sửa | Enable -> Hủy, Lưu
        /// </summary>
        public void Enable_btn_Luu_Huy()
        {
            if (isClickThem() || isClickXoa() || isClickSua())
            {
                if (btnThem != null) btnThem.Enabled = false;
                if (btnSua != null) btnSua.Enabled = false;
                if (btnXoa != null) btnXoa.Enabled = false;
                if (btnLamMoi != null) btnLamMoi.Enabled = false;

                if (btnLuu != null) btnHuy.Enabled = true;
                if (btnHuy != null) btnLuu.Enabled = true;
            }
        }

        //GET
        public enumButton getClickStatus()
        {
            return clickStatus;
        }

        //BOOL
        public bool isClickNone()
        {
            return (clickStatus == enumButton.None) ? true : false;
        }

        public bool isClickThem()
        {
            return (clickStatus == enumButton.Them) ? true : false;
        }

        public bool isClickXoa()
        {
            return (clickStatus == enumButton.Xoa) ? true : false;
        }

        public bool isClickSua()
        {
            return (clickStatus == enumButton.Sua) ? true : false;
        }
        //END BOOL

        //RESET
        public void ResetClickStatus()
        {
            clickStatus = enumButton.None;
        }

        //SET
        public void setClickThem()
        {
            clickStatus = enumButton.Them;
        }

        public void setClickXoa()
        {
            clickStatus = enumButton.Xoa;
        }

        public void setClickSua()
        {
            clickStatus = enumButton.Sua;
        }

        public void setClickLamMoi()
        {
            clickStatus = enumButton.LamMoi;
        }

        public void setClickLuu()
        {
            clickStatus = enumButton.Luu;
        }

        public void setClickDong()
        {
            clickStatus = enumButton.Dong;
        }
        //END SET

        /*
         [x] Add ICON khi Enable & Disable
         */
        private void btnThem_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.addFile_omc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.addFile_disable;
        }

        private void btnXoa_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.cancel_gmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.cancel_disable;
        }

        private void btnSua_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.edit_gmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.edit_disable;
        }

        private void btnLamMoi_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.refresh_omc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.refresh_disable;
        }

        private void btnHuy_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.close_gmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.close_disable;
        }

        private void btnLuu_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.save_bmc;
            else
                b.BackgroundImage = global::Inventory.DanhMuc.Properties.Resources.save_disable;
        }
        /*
         END. --> Add ICON khi Enable & Disable
         */

    }
}
