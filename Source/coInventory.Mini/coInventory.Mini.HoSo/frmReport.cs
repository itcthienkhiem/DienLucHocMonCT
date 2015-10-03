using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using coInventory.Mini.EntityClass;
using System.IO;
using CrystalDecisions.Shared;

namespace coInventory.Mini.HoSo
{
    public partial class frmReport : Form
    {
        public int m_BangKe_Id;
        public int m_LoaiBangKe;

        public string m_SoLuuTru;
        public string m_LoaiGiay;

        private string reportname;
        public frmReport(string _reporname)
        {
            InitializeComponent();
            reportname = _reporname;
        }


        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {
                clsBaoCao bc = new clsBaoCao();
                clsDM_CSKCB objCSKCB = new clsDM_CSKCB();
                SystemConfig sys = SystemConfig.Instance;

                objCSKCB.GetByKey(sys.MaCSKCB);


                ParameterFields paramFields = new ParameterFields();

                //add ten benh vien
                ParameterField paramField = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "TenBenhVien";
                paramDiscreteValue.Value = objCSKCB.TenCSKCB;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
                // 
                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "TenSYT";
                paramDiscreteValue1.Value = sys.TenSYT;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);
                DataTable dt = new DataTable("BaoCao");
                if (reportname.Trim().ToLower() == "BCVP".ToLower())
                {




                    dt = bc.GetBangKeNhom1(m_BangKe_Id);
                    dt.Columns.Add("BarCode", typeof(byte[]));

                    //BarcodeLib.Barcode b = new BarcodeLib.Barcode();

                    //if (dt.Rows.Count > 0)
                    //{
                    //    if (!string.IsNullOrEmpty(dt.Rows[0]["MaNguoiBenh"].ToString()))
                    //    {
                    //        Image bar = b.Encode(BarcodeLib.TYPE.CODE128, dt.Rows[0]["MaNguoiBenh"].ToString(), Color.Black, Color.White, 300, 150);
                    //        byte[] imageData = converterByte(bar);
                    //        dt.Rows[0]["BarCode"] = imageData;
                    //    }
                    //}

                    string path = string.Format("{0}/Reports/BCVP_{1}.rpt", Directory.GetCurrentDirectory(), m_LoaiBangKe);
                    rpDocument.Load(path);
                    rpDocument.SetDataSource(dt);

                    repordView.ParameterFieldInfo = paramFields;
                    repordView.ReportSource = rpDocument;
                }
                else
                {
                    dt = bc.GetBySoLuuTru(m_SoLuuTru, m_LoaiGiay);

                    string path = string.Format("{0}/Reports/{1}.rpt", Directory.GetCurrentDirectory(), reportname);
                    rpDocument.Load(path);
                    rpDocument.SetDataSource(dt);

                    repordView.ParameterFieldInfo = paramFields;
                    repordView.ReportSource = rpDocument;
                }
            }
            catch(Exception ex)
            {
            }

        }
        public static byte[] converterByte(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
    }
}
