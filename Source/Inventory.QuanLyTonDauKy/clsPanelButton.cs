using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory.QuanLyTonDauKy
{
    public enum enumButton : byte { None = 0, Them, Xoa, Sua, LamMoi, Luu, Huy, Dong, ThemLuoi, XoaLuoi, SuaLuoi };

    public enum enumFormAction : byte { None = 0, LoadData, CloseForm, setFormData, ResetInputForm, disableInputForm, Huy, Dong };

    public delegate void FormActionDelegate(enumFormAction val);

    public class clsPanelButton
    {
        Dictionary<enumButton, bool> btnStatus = new Dictionary<enumButton, bool>();

        FormActionDelegate frmAct;

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

        public void setDelegateFormAction(FormActionDelegate frmAct)
        {
            this.frmAct = frmAct;
        }

        public void AddButton(enumButton eBtn, ref Button btn)
        {
            setButtonStatus(eBtn, true);
            switch (eBtn)
            {
                case enumButton.None:
                    break;
                case enumButton.Them:
                    btnThem = btn;
                    btnThem.EnabledChanged += new System.EventHandler(btnThem_EnabledChanged);
                    //btnThem.Click += new System.EventHandler(this.btnThem_Click);
                    break;
                case enumButton.Xoa:
                    btnXoa = btn;
                    btnXoa.EnabledChanged += new System.EventHandler(btnXoa_EnabledChanged);
                    //btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
                    break;
                case enumButton.Sua:
                    btnSua = btn;
                    btnSua.EnabledChanged += new System.EventHandler(btnSua_EnabledChanged);
                    //btnSua.Click += new System.EventHandler(this.btnSua_Click);
                    break;
                case enumButton.LamMoi:
                    btnLamMoi = btn;
                    btnLamMoi.EnabledChanged += new System.EventHandler(btnLamMoi_EnabledChanged);
                    //btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
                    break;
                case enumButton.Luu:
                    btnLuu = btn;
                    btnLuu.EnabledChanged += new System.EventHandler(btnLuu_EnabledChanged);
                    break;
                case enumButton.Huy:
                    btnHuy = btn;
                    btnHuy.EnabledChanged += new System.EventHandler(btnHuy_EnabledChanged);
                    //btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
                    break;
                case enumButton.Dong:
                    btnDong = btn;
                    //btnDong.Click += new System.EventHandler(this.btnDong_Click);
                    break;
                default:
                    break;
            }
        }

        public void setButtonClickEvent(enumButton eBtn)
        {

            switch (eBtn)
            {
                case enumButton.None:
                    break;
                case enumButton.Them:
                    btnThem.Click += new System.EventHandler(this.btnThem_Click);
                    break;
                case enumButton.Xoa:
                    btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
                    break;
                case enumButton.Sua:
                    btnSua.Click += new System.EventHandler(this.btnSua_Click);
                    break;
                case enumButton.LamMoi:
                    btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
                    break;
                case enumButton.Luu:
                    break;
                case enumButton.Huy:
                    btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
                    break;
                case enumButton.Dong:
                    btnDong.Click += new System.EventHandler(this.btnDong_Click);
                    break;
                default:
                    break;
            }
        }

        public void setButtonStatus(enumButton eBtn, bool bStatus)
        {
            if (!btnStatus.ContainsKey(eBtn))
            {
                btnStatus.Add(eBtn, bStatus);
            }
            else {
                btnStatus[eBtn] = bStatus;
            }
        }

        public bool getButtonStatus(enumButton eBtn)
        {
            if (btnStatus.ContainsKey(eBtn))
            {
                return btnStatus[eBtn];
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Thêm, xóa, sửa, làm mới -> True | Lưu, Hủy -> False
        /// </summary>
        public void ResetButton()
        {
            if (isClickNone())
            {
                if (btnThem != null && getButtonStatus(enumButton.Them)) btnThem.Enabled = true;
                if (btnXoa != null && getButtonStatus(enumButton.Xoa)) btnXoa.Enabled = true;
                if (btnSua != null && getButtonStatus(enumButton.Sua)) btnSua.Enabled = true;
                if (btnLamMoi != null && getButtonStatus(enumButton.LamMoi)) btnLamMoi.Enabled = true;

                if (btnLuu != null && getButtonStatus(enumButton.Luu)) btnLuu.Enabled = false;
                if (btnHuy != null && getButtonStatus(enumButton.Huy)) btnHuy.Enabled = false;
            }
        }

        /// <summary>
        /// Fire when stt Thêm, Xóa, Sửa | Enable -> Hủy, Lưu
        /// </summary>
        public void Enable_btn_Luu_Huy()
        {
            if (isClickThem() || isClickXoa() || isClickSua())
            {
                if (btnThem != null && getButtonStatus(enumButton.Them)) btnThem.Enabled = false;
                if (btnSua != null && getButtonStatus(enumButton.Sua)) btnSua.Enabled = false;
                if (btnXoa != null && getButtonStatus(enumButton.Xoa)) btnXoa.Enabled = false;
                if (btnLamMoi != null && getButtonStatus(enumButton.LamMoi)) btnLamMoi.Enabled = false;

                if (btnLuu != null && getButtonStatus(enumButton.Luu)) btnHuy.Enabled = true;
                if (btnHuy != null && getButtonStatus(enumButton.Huy)) btnLuu.Enabled = true;
            }
        }

        ////////////////////
        //GET Click Status
        public enumButton getClickStatus()
        {
            return clickStatus;
        }

        public void setClickStatus(enumButton stt)
        {
            this.clickStatus = stt;
        }

        ////////////////////////////
        //BOOL: Return Click Status
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
        ///////////


        //RESET Click Status
        public void ResetClickStatus()
        {
            clickStatus = enumButton.None;
        }


        ///////
        //SET Click Status
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
        /////////

        //Event

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmAct.Invoke(enumFormAction.CloseForm);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!isClickNone())
            {
                ResetClickStatus();

                ResetButton();

                frmAct.Invoke(enumFormAction.disableInputForm);
                frmAct.Invoke(enumFormAction.ResetInputForm);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isClickNone())
            {
                setClickThem();

                Enable_btn_Luu_Huy();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (isClickNone())
            {
                setClickXoa();

                Enable_btn_Luu_Huy();

                frmAct.Invoke(enumFormAction.setFormData);

                /*Int32 selectedRowCount = gridDMDonViTinh.CurrentCell.RowIndex;
                txtTenDonVi.Text = gridDMDonViTinh.Rows[selectedRowCount].Cells["Ten_don_vi_tinh"].Value.ToString();*/
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isClickNone())
            {
                setClickSua();

                Enable_btn_Luu_Huy();

                frmAct.Invoke(enumFormAction.setFormData);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (btnThem != null && getButtonStatus(enumButton.Them)) btnThem.Enabled = false;
            if (btnXoa != null && getButtonStatus(enumButton.Xoa)) btnXoa.Enabled = false;
            if (btnSua != null && getButtonStatus(enumButton.Sua)) btnSua.Enabled = false;

            frmAct.Invoke(enumFormAction.LoadData);

            ResetButton();
        }

        /*
         [x] Add ICON khi Enable & Disable
         */
        private void btnThem_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.addFile_omc;
            else
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.addfile_disable;
        }

        private void btnXoa_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.cancel_gmc;
            else
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.cancel_disable;
        }

        private void btnSua_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.edit_gmc;
            else
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.edit_disable;
        }

        private void btnLamMoi_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.refresh_omc;
            else
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.refresh_disable;
        }

        private void btnHuy_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.close_gmc;
            else
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.close_disable;
        }

        private void btnLuu_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.save_bmc;
            else
                b.BackgroundImage = global::Inventory.QuanLyTonDauKy.Properties.Resources.save_disable;
        }
        /*
         END. --> Add ICON khi Enable & Disable
         */
    }
}
