using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
//using WebService.Model.Utility;
//using WebService.Model;
using System.IO;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace coInventory.Mini.EntityClass
{

    //public class Token
    //{
    //    public static string GetToken(string URL)
    //    {
    //        string token = string.Empty;
    //        string response = HttpRequest.WSRequest(URL, "GET", string.Empty);
    //        int index = response.IndexOf("Error:");
    //        if (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1)
    //        {
    //            token = XMLUtils.DeSerializeToObject<string>(response);
    //        }

    //        return token;
    //    }

    //}
    public enum EnumTuyen : byte
    {
        Xa = 40,
        Huyen = 30,
        Tinh = 20,
        TW = 10
    };
    public enum EnumHinhThucKham : byte
    {
        NgoaiTru = 10,
        NoiTru = 20
    };

    public class SystemConfig
    {
        public string Path_Database { set; get; }

        public string TenSYT { set; get; }
        public string MaCSKCB { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string PathXML { set; get; }
        public string PathBackup { set; get; }
        public string TenUngDung { set; get; }

        public string TuyenKham { set; get; }

        public string MaChiNhanh { set; get; }

        public string ServiceURL { set; get; }
        public string Auth_Username { set; get; }
        public string Auth_Password { set; get; }
        public string Auth_Domain { set; get; }
        public string TOKEN { set; get; }

        private static SystemConfig instance;

        public static SystemConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemConfig(); ;
                }
                return instance;
            }
        }

        private void GetSettings()
        {
            try
            {
                Path_Database = ConfigurationManager.AppSettings["ConnectionString"];
                MaCSKCB = ConfigurationManager.AppSettings["MaCSKCB"];



                TenUngDung = ConfigurationManager.AppSettings["TenUngDung"];

                //Username = ConfigurationManager.AppSettings["TenDangNhap"];
                string m_username = ConfigurationManager.AppSettings["TenDangNhap"];
                Username = (m_username == "") ? "" : Crypto.DecryptStringAES(m_username, Crypto.CodeSecret);

                //Password = ConfigurationManager.AppSettings["MatKhau"];
                string m_password = ConfigurationManager.AppSettings["MatKhau"];
                Password = m_password == "" ? "" : Crypto.DecryptStringAES(m_password, Crypto.CodeSecret);

                string path_xml = ConfigurationManager.AppSettings["PathXML"];
                string path_backup = ConfigurationManager.AppSettings["PathBackup"];
                if (path_xml == null)
                    path_xml = "";
                if (path_backup == null)
                    path_backup = "";
                string _tensyt = ConfigurationManager.AppSettings["TenSYT"];
                if (_tensyt == null)
                    _tensyt = "";

                TenSYT = _tensyt;

                PathXML = (path_xml.Trim().Length == 0) ? Path.GetPathRoot(Environment.SystemDirectory) + "FileXML" : path_xml;
                PathBackup = (path_backup.Trim().Length == 0) ? Path.GetPathRoot(Environment.SystemDirectory) + "Database" : path_backup;


                string m_MaChiNhanh = ConfigurationManager.AppSettings["MaChiNhanh"];
                MaChiNhanh = (m_MaChiNhanh == null) ? "" : m_MaChiNhanh;

                Auth_Username = ConfigurationManager.AppSettings["Auth_Username"];
                Auth_Password = ConfigurationManager.AppSettings["Auth_Password"];
                Auth_Domain = ConfigurationManager.AppSettings["Auth_Domain"];
                ServiceURL = ConfigurationManager.AppSettings["WebService"];
            }
            catch { }
        }
        private SystemConfig()
        {
            GetSettings();
        }

        public int UpdateConfig()
        {
            try
            {
                AddOrUpdateAppSettings("ConnectionString", string.Format("Data Source={0};Version=3;", Path_Database));
                AddOrUpdateAppSettings("MaCSKCB", MaCSKCB);
                AddOrUpdateAppSettings("TenDangNhap", Username.Trim() == "" ? "" : Crypto.EncryptStringAES(Username, Crypto.CodeSecret));
                AddOrUpdateAppSettings("MatKhau", Password.Trim() == "" ? "" : Crypto.EncryptStringAES(Password, Crypto.CodeSecret));
                AddOrUpdateAppSettings("PathXML", PathXML);
                AddOrUpdateAppSettings("PathBackup", PathBackup);
                AddOrUpdateAppSettings("MaChiNhanh", MaChiNhanh);
                AddOrUpdateAppSettings("Auth_Password", Auth_Password);
                AddOrUpdateAppSettings("Auth_Username", Auth_Username);
                AddOrUpdateAppSettings("Auth_Domain", Auth_Domain);
                AddOrUpdateAppSettings("TenSYT", TenSYT);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }

        public void KiemTraBanCapNhat()
        {

        }




        public string GetLinkWS()
        {
            return ServiceURL;// ConfigurationManager.AppSettings["WebService"];
        }

        public string GetAuth_Username()
        {
            return Auth_Username;
        }

        public string GetAuth_Password()
        {
            return Auth_Password;
        }

        public string GetAuth_Domain()
        {
            return Auth_Domain;
        }

        public string GetToken()
        {
            //TOKEN = null;
            //if (!string.IsNullOrEmpty(ServiceURL) && !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            //{
            //    string URL = string.Format("{0}GetAccessToken/{1}/{2}", ServiceURL, Username, Password);
            //    string response = HttpRequest.WSRequest(URL, "GET", string.Empty, string.Empty, Auth_Username, Auth_Password, Auth_Domain);
            //    if (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1)
            //    {
            //        TOKEN = XMLUtils.DeSerializeToObject<string>(response);
            //    }
            //}
            return null;// TOKEN;
        }

        public string SendRequest(string param, string method, string postData)
        {
            //string result = string.Empty;
            //do
            //{
            //    if (string.IsNullOrEmpty(TOKEN))
            //    {
            //        TOKEN = GetToken();
            //        if (string.IsNullOrEmpty(TOKEN))
            //        {
            //            result = "Error: Kiểm tra cấu hình và kết nối mạng";
            //            break;
            //        }
            //    }

            //    string URL = string.Format("{0}{1}", ServiceURL, param);
            //    string response = HttpRequest.WSRequest(URL, method, postData, TOKEN, Auth_Username, Auth_Password, Auth_Domain);
            //    if ((response.IndexOf("Error: MaCSKCB") != -1) || (!string.IsNullOrEmpty(response) && response.IndexOf("Error:") == -1))
            //    {
            //        result = response;
            //        break;
            //    }
            //} while (string.IsNullOrEmpty(TOKEN));

            return null;// result == null;
        }

        //public bool CheckConnection(string path)
        //{
        //    try
        //    {
        //        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
        //        m_dbConnection.Open();
        //        m_dbConnection.Close();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public string GetThongTinCSKCB()
        {
            try
            {
                clsDM_CSKCB m_CSKCB = new clsDM_CSKCB();
                m_CSKCB.GetByKey(MaCSKCB);

                if (m_CSKCB.MaCSKCB != null)
                {
                    string LoaiTuyen = "";
                    switch (m_CSKCB.Tuyen)
                    {
                        case (byte)EnumTuyen.Xa:
                            LoaiTuyen = "Tuyến Xã";
                            TuyenKham = "xa";
                            break;

                        case (byte)EnumTuyen.Huyen:
                            LoaiTuyen = "Tuyến Huyện";
                            TuyenKham = "huyen";
                            break;
                        case (byte)EnumTuyen.Tinh:
                            LoaiTuyen = "Tuyến Tỉnh";
                            TuyenKham = "tinh";
                            break;
                        case (byte)EnumTuyen.TW:
                            LoaiTuyen = "Tuyến TƯ";
                            TuyenKham = "tw";
                            break;
                        default:
                            LoaiTuyen = "";
                            TuyenKham = "t";
                            break;

                    }

                    return "Mã CSKCB: " + m_CSKCB.MaCSKCB + " - " + m_CSKCB.TenCSKCB + " - " + LoaiTuyen;
                }
                else
                {
                    TuyenKham = string.Empty;
                    return "";
                }
            }
            catch
            {
                TuyenKham = string.Empty;
                return "Không tìm thấy CSDL.";
            }
        }
    }

    /// <summary>
    /// Ma hoa 
    /// </summary>
    /// 

    public static class Crypto
    {
        public static string CodeSecret = "FPTGMC";
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        /// <summary>
        /// Encrypt the given string using AES.  The string can be decrypted using 
        /// DecryptStringAES().  The sharedSecret parameters must match.
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
        public static string EncryptStringAES(string plainText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // prepend the IV
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());

                    outStr = outStr.Replace("+", "-").Replace("/", "_").Replace("=", ".");
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        /// <summary>
        /// Decrypt the given string.  Assumes the string was encrypted using 
        /// EncryptStringAES(), using an identical sharedSecret.
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
        public static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            cipherText = cipherText.Replace("-", "+").Replace("_", "/").Replace(".", "=");

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();

                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }
    }
}
