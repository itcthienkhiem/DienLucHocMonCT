using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Inventory.Utilities
{
    public static class clsThamSoUtilities
    {                                              //Data Source=KHIEM-PC\SQLEXPRESS;Initial Catalog=QLKhoDienLuc;persist security info=True;User Id=sa;Password=2051990;MultipleActiveResultSets=True;
        public static string connectionString; //= @"data source=KHIEM-PC\SQLEXPRESS" + ";initial catalog=QLKhoDienLuc" + ";persist security info=True;user id=sa" + ";password=2051990" + ";MultipleActiveResultSets=True;";


        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static string COException(Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame

            return st.ToString() + " \n ";
        }

       
    }
}
