using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace coInventory.Mini.Utilities
{
    public class Utils
    {
        public static decimal convertDecimal(string strDecimal, System.Globalization.NumberStyles numberStyles, System.Globalization.CultureInfo enUS)
        {
            try
            {

                Decimal x = 0;

                x = Decimal.Parse(strDecimal,numberStyles,enUS);
                if (x == decimal.MinValue)
                    return 0;
                return x;

            }

            catch (Exception E)
            {

                return 0;

            }
        }
        public static Decimal convertDecimal(string strDecimal)
        {

            try
            {

                Decimal x = 0;

                x = Convert.ToDecimal(strDecimal);
                if (x == decimal.MinValue)
                    return 0;
                return x;

            }

            catch (Exception E)
            {

                return 0;

            }

        }
        public static DateTime convertDateTime(string strDecimal)
        {

            try
            {

                DateTime x ;

                x = Convert.ToDateTime(strDecimal);

                return x;

            }

            catch (Exception E)
            {

                return DateTime.MinValue;

            }

        }
        public static int? convertInt(string strDecimal)
        {

            try
            {

                int x = 0;

                x = Convert.ToInt16(strDecimal);

                return x;

            }

            catch (Exception E)
            {

                return null;

            }

        }
        
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
            ComboboxData data0 = new ComboboxData("", "");
            ComboboxData data1 = new ComboboxData("K1", "K1");
            ComboboxData data2 = new ComboboxData("K2", "K2");
            ComboboxData data3 = new ComboboxData("K3", "K3");
            ls.Add(data0);
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

        public static BindingList<ComboboxData> GetTuyen()
        {
            BindingList<ComboboxData> ls = new BindingList<ComboboxData>();
            ComboboxData data1 = new ComboboxData("Tuyến Xã", "40");
            ComboboxData data2 = new ComboboxData("Tuyến Huyện", "30");
            ComboboxData data3 = new ComboboxData("Tuyến Tỉnh", "20");
            ComboboxData data4 = new ComboboxData("Tuyến TW", "10");

            ls.Add(data1);
            ls.Add(data2);
            ls.Add(data3);
            ls.Add(data4);
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
