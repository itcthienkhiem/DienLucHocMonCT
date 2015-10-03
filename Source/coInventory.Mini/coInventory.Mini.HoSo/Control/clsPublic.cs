using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using coInventory.Mini.EntityClass;

namespace coInventory.Mini.HoSo.Control
{
    public class clsPublic
    {
        public string TuyenKham;
        public string MaCSKCB;


        public string GetThongTinCSKCB()
        {
            SystemConfig conf = SystemConfig.Instance;
            string thongtin = conf.GetThongTinCSKCB();
            TuyenKham = conf.TuyenKham;
            MaCSKCB = conf.MaCSKCB;
            return thongtin;
        }

        public string TenUngDung()
        {
            SystemConfig conf = SystemConfig.Instance;
            return conf.TenUngDung;
        }

        public bool ShowCauHinh()
        {
            SystemConfig conf = SystemConfig.Instance;
            if (conf.Username.Trim().Length == 0 || conf.Password.Trim().Length == 0 || conf.MaCSKCB.Trim().Length == 0 || conf.Path_Database.Trim().Length == 0)
                return true;
            return false;
        }
    }
}
