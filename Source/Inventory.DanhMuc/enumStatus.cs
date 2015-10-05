using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DanhMuc
{
    public enum enumStatus : byte { None = 0, Them , Xoa, Sua, LamMoi, Luu, Close };

    public class cls_Status
    {
        enumStatus status;

        public cls_Status()
        {
            status = enumStatus.None;
        }

        public enumStatus getStatus()
        {
            return status;
        }

        public bool isNone()
        {
            return (status == enumStatus.None) ? true : false;
        }

        public bool isThem()
        {
            return (status == enumStatus.Them) ? true : false;
        }

        public bool isXoa()
        {
            return (status == enumStatus.Xoa) ? true : false;
        }

        public bool isSua()
        {
            return (status == enumStatus.Sua) ? true : false;
        }

        public void Reset()
        {
            status = enumStatus.None;
        }

        public void setThem()
        {
            status = enumStatus.Them;
        }

        public void setXoa()
        {
            status = enumStatus.Xoa;
        }

        public void setSua()
        {
            status = enumStatus.Sua;
        }

        public void setLamMoi()
        {
            status = enumStatus.LamMoi;
        }

        public void setLuu()
        {
            status = enumStatus.Luu;
        }

        public void setClose()
        {
            status = enumStatus.Close;
        }
    }
    
}
