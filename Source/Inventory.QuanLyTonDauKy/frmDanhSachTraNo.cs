using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using Inventory.Models;
using Inventory.BusinessClass;

namespace Inventory.QuanLyTonDauKy
{
    public partial class frmDanhSachTraNo : Form
    {
        public frmDanhSachTraNo()
        {
            InitializeComponent();
            gridDSChiTietTraNo.DataSource = clsCanTruNoNhapNgoai.GetAll();
        }
    }
}
