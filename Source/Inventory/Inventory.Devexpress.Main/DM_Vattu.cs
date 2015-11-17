using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.EntityClass;
namespace Inventory.Devexpress.Main
{
    public partial class DM_Vattu : DevExpress.XtraEditors.XtraForm
    {
        public DM_Vattu()
        {
            InitializeComponent();
        }
        DataTable tb = new DataTable();
        private void DM_Vattu_Load(object sender, EventArgs e)
        {
            gridControl.DataSource = new clsDMVatTu().GetAllData();
        }
    }
}