using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
            string temp = st.ToString() + " \n ";
          
            // Get the top stack frame
           

            return temp;
        }
        /// <summary>
        /// hàm này dùng để ren ra mã  hash MD5 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
