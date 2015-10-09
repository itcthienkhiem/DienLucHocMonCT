using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory.XuatTamVatTu
{
    public enum enumButton2 : byte { None = 0, Them, Xoa, Sua, LamMoi, Luu, Huy, Dong, ThemLuoi, XoaLuoi, SuaLuoi };

    public enum enumFormAction2 : byte { None = 0, LoadData, CloseForm, setFormData, ResetInputForm, disableInputForm, Huy, Dong };

    public delegate void FormActionDelegate2(enumFormAction2 val);

    class clsPanelButton2
    {
        Dictionary<enumButton2, bool> btnStatus = new Dictionary<enumButton2, bool>();

        FormActionDelegate2 frmAct;

        enumButton2 clickStatus;

        //enumFormAction FormActionStatus;

        private Button btnThem = null;
        private Button btnXoa = null;
        private Button btnSua = null;
        private Button btnLamMoi = null;
        private Button btnLuu = null;
        private Button btnHuy = null;
        private Button btnDong = null;

        public clsPanelButton2()
        {
            clickStatus = enumButton2.None;
        }

        public void setDelegateFormAction(FormActionDelegate2 frmAct)
        {
            this.frmAct = frmAct;
        }

        public void AddButton(enumButton2 eBtn, ref Button btn)
        {
            setButtonStatus(eBtn, true);
            switch (eBtn)
            {
                case enumButton2.None:
                    break;
                case enumButton2.Them:
                    btnThem = btn;
                    btnThem.EnabledChanged += new System.EventHandler(btnThem_EnabledChanged);
                    //btnThem.Click += new System.EventHandler(this.btnThem_Click);
                    break;
                case enumButton2.Xoa:
                    btnXoa = btn;
                    btnXoa.EnabledChanged += new System.EventHandler(btnXoa_EnabledChanged);
                    //btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
                    break;
                case enumButton2.Sua:
                    btnSua = btn;
                    btnSua.EnabledChanged += new System.EventHandler(btnSua_EnabledChanged);
                    //btnSua.Click += new System.EventHandler(this.btnSua_Click);
                    break;
                case enumButton2.LamMoi:
                    btnLamMoi = btn;
                    btnLamMoi.EnabledChanged += new System.EventHandler(btnLamMoi_EnabledChanged);
                    //btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
                    break;
                case enumButton2.Luu:
                    btnLuu = btn;
                    btnLuu.EnabledChanged += new System.EventHandler(btnLuu_EnabledChanged);
                    break;
                case enumButton2.Huy:
                    btnHuy = btn;
                    btnHuy.EnabledChanged += new System.EventHandler(btnHuy_EnabledChanged);
                    //btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
                    break;
                case enumButton2.Dong:
                    btnDong = btn;
                    //btnDong.Click += new System.EventHandler(this.btnDong_Click);
                    break;
                default:
                    break;
            }
        }

        public void setButtonClickEvent(enumButton2 eBtn)
        {

            switch (eBtn)
            {
                case enumButton2.None:
                    break;
                case enumButton2.Them:
                    btnThem.Click += new System.EventHandler(this.btnThem_Click);
                    break;
                case enumButton2.Xoa:
                    btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
                    break;
                case enumButton2.Sua:
                    btnSua.Click += new System.EventHandler(this.btnSua_Click);
                    break;
                case enumButton2.LamMoi:
                    btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
                    break;
                case enumButton2.Luu:
                    break;
                case enumButton2.Huy:
                    btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
                    break;
                case enumButton2.Dong:
                    btnDong.Click += new System.EventHandler(this.btnDong_Click);
                    break;
                default:
                    break;
            }
        }

        public void setButtonStatus(enumButton2 eBtn, bool bStatus)
        {
            if (!btnStatus.ContainsKey(eBtn))
            {
                btnStatus.Add(eBtn, bStatus);
            }
            else {
                btnStatus[eBtn] = bStatus;
            }
        }

        public bool getButtonStatus(enumButton2 eBtn)
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
                if (btnThem != null && getButtonStatus(enumButton2.Them)) btnThem.Enabled = true;
                if (btnXoa != null && getButtonStatus(enumButton2.Xoa)) btnXoa.Enabled = true;
                if (btnSua != null && getButtonStatus(enumButton2.Sua)) btnSua.Enabled = true;
                if (btnLamMoi != null && getButtonStatus(enumButton2.LamMoi)) btnLamMoi.Enabled = true;

                if (btnLuu != null && getButtonStatus(enumButton2.Luu)) btnLuu.Enabled = false;
                if (btnHuy != null && getButtonStatus(enumButton2.Huy)) btnHuy.Enabled = false;
            }
        }

        /// <summary>
        /// Fire when stt Thêm, Xóa, Sửa | Enable -> Hủy, Lưu
        /// </summary>
        public void Enable_btn_Luu_Huy()
        {
            if (isClickThem() || isClickXoa() || isClickSua())
            {
                if (btnThem != null && getButtonStatus(enumButton2.Them)) btnThem.Enabled = false;
                if (btnSua != null && getButtonStatus(enumButton2.Sua)) btnSua.Enabled = false;
                if (btnXoa != null && getButtonStatus(enumButton2.Xoa)) btnXoa.Enabled = false;
                if (btnLamMoi != null && getButtonStatus(enumButton2.LamMoi)) btnLamMoi.Enabled = false;

                if (btnLuu != null && getButtonStatus(enumButton2.Luu)) btnHuy.Enabled = true;
                if (btnHuy != null && getButtonStatus(enumButton2.Huy)) btnLuu.Enabled = true;
            }
        }

        ////////////////////
        //GET Click Status
        public enumButton2 getClickStatus()
        {
            return clickStatus;
        }

        public void setClickStatus(enumButton2 stt)
        {
            this.clickStatus = stt;
        }

        ////////////////////////////
        //BOOL: Return Click Status
        public bool isClickNone()
        {
            return (clickStatus == enumButton2.None) ? true : false;
        }

        public bool isClickThem()
        {
            return (clickStatus == enumButton2.Them) ? true : false;
        }

        public bool isClickXoa()
        {
            return (clickStatus == enumButton2.Xoa) ? true : false;
        }

        public bool isClickSua()
        {
            return (clickStatus == enumButton2.Sua) ? true : false;
        }
        //END BOOL
        ///////////


        //RESET Click Status
        public void ResetClickStatus()
        {
            clickStatus = enumButton2.None;
        }


        ///////
        //SET Click Status
        public void setClickThem()
        {
            clickStatus = enumButton2.Them;
        }

        public void setClickXoa()
        {
            clickStatus = enumButton2.Xoa;
        }

        public void setClickSua()
        {
            clickStatus = enumButton2.Sua;
        }

        public void setClickLamMoi()
        {
            clickStatus = enumButton2.LamMoi;
        }

        public void setClickLuu()
        {
            clickStatus = enumButton2.Luu;
        }

        public void setClickDong()
        {
            clickStatus = enumButton2.Dong;
        }
        //END SET
        /////////

        //Event

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmAct.Invoke(enumFormAction2.CloseForm);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!isClickNone())
            {
                ResetClickStatus();

                ResetButton();

                frmAct.Invoke(enumFormAction2.disableInputForm);
                frmAct.Invoke(enumFormAction2.ResetInputForm);
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

                frmAct.Invoke(enumFormAction2.setFormData);

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

                frmAct.Invoke(enumFormAction2.setFormData);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (btnThem != null) btnThem.Enabled = false;
            if (btnXoa != null) btnXoa.Enabled = false;
            if (btnSua != null) btnSua.Enabled = false;

            frmAct.Invoke(enumFormAction2.LoadData);

            ResetButton();
        }

        /*
         [x] Add ICON khi Enable & Disable
         */
        private void btnThem_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)//Inventory.XuatTamVatTu
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.addFile_omc;
            else
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.addFile_disable;
        }

        private void btnXoa_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.cancel_gmc;
            else
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.cancel_disable;
        }

        private void btnSua_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.edit_gmc;
            else
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.edit_disable;
        }

        private void btnLamMoi_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.refresh_omc;
            else
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.refresh_disable;
        }

        private void btnHuy_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.close_gmc;
            else
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.close_disable;
        }

        private void btnLuu_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Enabled)
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.save_bmc;
            else
                b.BackgroundImage = global::Inventory.XuatTamVatTu.Properties.Resources.save_disable;
        }
        /*
         END. --> Add ICON khi Enable & Disable
         */
    }
}
