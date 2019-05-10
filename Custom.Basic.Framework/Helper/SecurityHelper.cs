using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// 加解密
    /// </summary>
    public class SecurityHelper
    {
        private static DESCryptoServiceProvider crypt = new DESCryptoServiceProvider();
        private const string Key = "123";

        public static string DESEncryption(string express)
        {
            crypt.Key = Encoding.UTF8.GetBytes(Key);
            crypt.Mode = CipherMode.CBC;
            crypt.Padding = PaddingMode.PKCS7;

            //用UTF-8编码，转为byte[]
            byte[] bysData = Encoding.UTF8.GetBytes(express);
            //进行加密
            byte[] bysEncrypted = crypt.CreateEncryptor().TransformFinalBlock(bysData, 0, bysData.Length);
            //將byte[]轉為Base64的字串
            return Convert.ToBase64String(bysEncrypted);
        }

        //解密
        public static string DESDecrypt(string ciphertext)
        {
            crypt.Key = Encoding.UTF8.GetBytes(Key);
            crypt.Mode = CipherMode.CBC;
            crypt.Padding = PaddingMode.PKCS7;

            byte[] bysData = Convert.FromBase64String(ciphertext);

            //进行解密
            byte[] bysDecrypted = crypt.CreateDecryptor().TransformFinalBlock(bysData, 0, bysData.Length);
            return Encoding.UTF8.GetString(bysDecrypted);
        }

    }
}
