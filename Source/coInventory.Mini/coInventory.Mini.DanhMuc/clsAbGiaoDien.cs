using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clsDanhMucAbtract
{
    public partial class clsAbGiaoDien : Form
    {
        /// <summary>
        /// doi tượng cần hiển thị là loại gì ?
        /// </summary>
       
        public clsAbGiaoDien()
        {
            InitializeComponent();
        }
        public object obj;
        public delegate void CapNhatDuLieu(object sender,int id);
        
        // Create instance (null)
        public CapNhatDuLieu capNhat;
        public void SetObject(object ob)
        {
            obj = ob;
        }
    }
}
