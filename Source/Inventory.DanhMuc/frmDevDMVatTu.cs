﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.EntityClass;
using System.Data.Entity;

namespace Inventory.DanhMuc
{
    public partial class frmDevDMVatTu : DevExpress.XtraEditors.XtraForm
    {
        public frmDevDMVatTu()
        {
            InitializeComponent();


          //  dataTable1 = new clsDMVatTu().GetAllData();
       
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
      
        }
        DataTable tb = new DataTable();
        private void DM_Vattu_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = new clsUser().GetAllData();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //GridView view = sender as GridView;

            ////Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert[/B]
            //if (view.IsNewItemRow(e.RowHandle))
            //{
            //    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại[/B]
            //    string insert = "insert into hocsinh(hoten, ngaysinh, gioitinh,diachi) values ('"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "','"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[2]).ToString() + "','"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[3]).ToString() + "','"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[4]).ToString() + "')";
            //    con.Open();
            //    OdbcCommand ocmd = new OdbcCommand(insert, con);
            //    ocmd.ExecuteNonQuery();
            //    con.Close();

            //}
            ////Cũ thì update
            //else
            //{
            //    string update = "update hocsinh set hoten='"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "', ngaysinh ='"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[2]).ToString() + "', gioitinh ='"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[3]).ToString() + "', diachi ='"
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[4]).ToString() + "' where id ="
            //    + view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString();
            //    con.Open();
            //    OdbcCommand ocmd = new OdbcCommand(update, con);
            //    ocmd.ExecuteNonQuery();
            //    con.Close();

            //}
            //LoadData();
        }

        private void gridControl1_Validated(object sender, EventArgs e)
        {

        }
    }
}