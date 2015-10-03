using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace eHospital.Mini.Utilities
{
    public class Util
    {
        public static List<int> GetListYear()
        {
            List<int> ls = new List<int>();
            DateTime dateNow = DateTime.Now;
            for (int i = dateNow.Year; i > dateNow.Year - 10; i--)
            {
                ls.Add(i);
            }
            return ls;
        }

        public static BindingList<ComboboxData> GetTrangThai()
        {
            BindingList<ComboboxData> ls = new BindingList<ComboboxData>();
            ComboboxData data1 = new ComboboxData("Tạo mới", "TaoMoi");
            ComboboxData data2 = new ComboboxData("Đã gửi BHXH", "DaGuiBHXH");

            ls.Add(data1);
            ls.Add(data2);
            return ls;
        }

        public static BindingList<ComboboxData> GetKhuVucSong()
        {
            BindingList<ComboboxData> ls = new BindingList<ComboboxData>();
            ComboboxData data1 = new ComboboxData("K1", "K1");
            ComboboxData data2 = new ComboboxData("K2", "K2");
            ComboboxData data3 = new ComboboxData("K3", "K3");

            ls.Add(data1);
            ls.Add(data2);
            ls.Add(data3);
            return ls;
        }

        public static BindingList<ComboboxData> GetGioiTinh()
        {
            BindingList<ComboboxData> ls = new BindingList<ComboboxData>();
            ComboboxData data1 = new ComboboxData("Nam", "1");
            ComboboxData data2 = new ComboboxData("Nữ", "0");

            ls.Add(data1);
            ls.Add(data2);
            return ls;
        }

        public static BindingList<ComboboxData> GetTuyenKham()
        {
            BindingList<ComboboxData> ls = new BindingList<ComboboxData>();
            ComboboxData data1 = new ComboboxData("Trái tuyến", "0");
            ComboboxData data2 = new ComboboxData("Đúng tuyến", "1");
            ComboboxData data3 = new ComboboxData("Cấp cứu", "2");

            ls.Add(data1);
            ls.Add(data2);
            ls.Add(data3);
            return ls;
        }

    }

    public class ComboboxData
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Value;

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public ComboboxData(string _name, string _value)
        {
            Name = _name;
            Value = _value;
        }
    }
}
