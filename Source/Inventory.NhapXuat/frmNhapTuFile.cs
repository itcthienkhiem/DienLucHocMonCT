using Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.EntityClass;
using System.DirectoryServices;
namespace Inventory.NhapXuat
{
    public partial class frmNhapTuFile : Form
    {
        public frmNhapTuFile()
        {
            InitializeComponent();
        }

        private void btnDuyetFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialog theDialog = new OpenFileDialog();
            //theDialog.Title = "Open excel File";
            //theDialog.Filter = "xlsx files|*.xlsx";
            //theDialog.InitialDirectory = @"C:\";
            //if (theDialog.ShowDialog() == DialogResult.OK)
            //{
            //        txtTenDuongDan.Text =  (theDialog.FileName.ToString());
            //}
            FileStream stream = File.Open(txtTenDuongDan.Text, FileMode.Open, FileAccess.Read);

            //lấy định dạng 
            //nếu 2003 
            IExcelDataReader excelReader = null;
            if (stream.Name.Split('.')[1].Equals("xls"))
            {

                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            else
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();

            //4. DataSet - Create column names from first row
            //  excelReader.IsFirstRowAsColumnNames = true;
            //  DataSet result = excelReader.AsDataSet();
            gridDanhSachPhieuNhap.DataSource = result.Tables[0];
            this.gridDanhSachPhieuNhap.Sort(this.gridDanhSachPhieuNhap.Columns["column1"], ListSortDirection.Ascending);
            //5. Data Reader methods
            //while (excelReader.Read())
            //{
            //    //excelReader.GetInt32(0);
            //}
            //clsPhieuNhapKho pn = new clsPhieuNhapKho();

            //6. Free resources (IExcelDataReader is IDisposable)

        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            } return newSortDirection;


        }
      

        private void gridDanhSachPhieuNhap_Sorted(object sender, EventArgs e)
        {

        }
    }
}
