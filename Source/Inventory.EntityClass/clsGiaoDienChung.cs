using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory.EntityClass
{
   public class clsGiaoDienChung
    {
       /// <summary>
       ///đây là hàm rất hữu ích để tạo ra autocombobox mà không cần quan tâm đến nó là gì?
       /// </summary>
       /// <param name="cbb">combobox</param>
       /// <param name="entCls">cls nào kế thừa thì truyền vào</param>
       /// <param name="tencot">tên cột muốn lấy </param>
       /// <param name="ValueMember">giá trị hiển thị</param>
       /// <param name="DisplayMember">tên hiển thị</param>
       public static void initCombobox(ComboBox cbb, ObjecEntity entCls, string tencot, string ValueMember, string DisplayMember)
       {
         cbb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
         cbb.AutoCompleteSource = AutoCompleteSource.CustomSource;

         AutoCompleteStringCollection combData1 =  entCls.getListToCombobox(tencot);// new AutoCompleteStringCollection();

           cbb.AutoCompleteCustomSource = combData1;
           cbb.DataSource = entCls.GetAllData();
           cbb.DisplayMember = DisplayMember;
           cbb.ValueMember = ValueMember;
           cbb.SelectedIndex = -1;
       }
    }
}
