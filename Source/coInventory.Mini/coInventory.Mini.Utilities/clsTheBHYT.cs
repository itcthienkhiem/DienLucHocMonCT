using System.Text;
using System;

public class clsTheBHYT
{
    private string m_strMaThe;
    private string m_strHoTen;
    private string m_strHoTenHEX;
    private System.DateTime m_dtNgaySinh;
    private string m_strGioiTinh;
    private string m_strDiaChi;
    private string m_strDiaChiHEX;
    private string m_strMaCoSoDKKCB;
    private System.DateTime m_dtTuNgay;
    private System.DateTime m_dtDenNgay;
    private System.DateTime m_dtNgayCap;
    private string m_strMaCoQuanQuanLy;

    private string m_strChuoiKiemTra;

    private char m_DELIMITER = '|';
    #region "Members"
    public string MaThe
    {
        get { return m_strMaThe; }
        set { value = m_strMaThe; }
    }


    public string HoTen
    {
        get { return m_strHoTen; }
        set { value = m_strHoTen; }
    }

    public string HoTenHEX
    {
        get { return m_strHoTenHEX; }
        set { value = m_strHoTenHEX; }
    }

    public System.DateTime NgaySinh
    {
        get { return m_dtNgaySinh; }
        set { value = m_dtNgaySinh; }
    }

    public string GioiTinh
    {
        get { return m_strGioiTinh; }
        set { value = m_strGioiTinh; }
    }

    public string DiaChi
    {
        get { return m_strDiaChi; }
        set { value = m_strDiaChi; }
    }

    public string DiaChiHEX
    {
        get { return m_strDiaChiHEX; }
        set { value = m_strDiaChiHEX; }
    }

    public string MaCoSoDKKCB
    {
        get { return m_strMaCoSoDKKCB; }
        set { value = m_strMaCoSoDKKCB; }
    }

    public System.DateTime TuNgay
    {
        get { return m_dtTuNgay; }
        set { value = m_dtTuNgay; }
    }

    public System.DateTime DenNgay
    {
        get { return m_dtDenNgay; }
        set { value = m_dtDenNgay; }
    }

    public System.DateTime NgayCap
    {
        get { return m_dtNgayCap; }
        set { value = m_dtNgayCap; }
    }

    public string MaCoQuanQuanLy
    {
        get { return m_strMaCoQuanQuanLy; }
        set { value = m_strMaCoQuanQuanLy; }
    }

    public string ChuoiKiemTra
    {
        get { return m_strChuoiKiemTra; }
        set { value = m_strChuoiKiemTra; }
    }
    #endregion

    private string ConvertHexStrToUnicode(string hexString)
    {
        int length = hexString.Length;
        byte[] bytes = new byte[length / 2 - 1];

        for (int i = 0; i <= length - 1; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
        }
        return Encoding.UTF8.GetString(bytes);
    }

    public bool Parse(string strBarcode)
    {
        try
        {
            string[] strList;
            strList = strBarcode.Split(m_DELIMITER);

            if (strList.Length != 12)
            {
                throw new Exception("Barcode không hợp lệ");
            }

            this.m_strMaThe = strList[0];
            this.m_strHoTenHEX = strList[1];
            this.m_strHoTen = this.ConvertHexStrToUnicode(this.m_strHoTenHEX);
            this.m_dtNgaySinh = System.DateTime.ParseExact(strList[2], "dd/MM/yyyy", null);
            if (strList[3] == "1")
            {
                this.m_strGioiTinh = "T";
            }
            else
            {
                this.m_strGioiTinh = "G";
            }
            this.m_strDiaChiHEX = strList[4];
            this.m_strDiaChi = this.ConvertHexStrToUnicode(this.m_strDiaChiHEX);

            this.m_strMaCoSoDKKCB = strList[5];
            this.m_strMaCoSoDKKCB = this.m_strMaCoSoDKKCB.Replace(" ", "");
            this.m_strMaCoSoDKKCB = this.m_strMaCoSoDKKCB.Replace("-", "");

            this.m_dtTuNgay = System.DateTime.ParseExact(strList[6], "dd/MM/yyyy", null);
            this.m_dtDenNgay = System.DateTime.ParseExact(strList[7], "dd/MM/yyyy", null);
            this.m_dtNgayCap = System.DateTime.ParseExact(strList[8], "dd/MM/yyyy", null);
            this.m_strMaCoQuanQuanLy = strList[9];
            this.m_strChuoiKiemTra = strList[10];

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return true;
    }


}