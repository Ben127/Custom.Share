using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    //// <summary>
    /// RSAHelper
    /// </summary>
    public class RSAHelper
    {
        private RSAKEY _key = new RSAKEY();
        public RSAKEY Key
        {
            get { return _key; }
        }

        public RSAHelper(bool generateKey = false)
        {
            if (generateKey)
            {
                using (RSACryptoServiceProvider ras = new RSACryptoServiceProvider())
                {
                    Key.Set(Convert.ToBase64String(ras.ExportCspBlob(true)), Convert.ToBase64String(ras.ExportCspBlob(false)));
                }
            }
        }


        public void GenerateKey()
        {
            using (RSACryptoServiceProvider ras = new RSACryptoServiceProvider())
            {
                _key.Set(Convert.ToBase64String(ras.ExportCspBlob(true)), Convert.ToBase64String(ras.ExportCspBlob(false)));
            }
        }

        public string Encrypt(string input, string publicKey)
        {
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] DataToEncrypt = ByteConverter.GetBytes(input);

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.ImportCspBlob(Convert.FromBase64String(publicKey));

                byte[] bytes_Cypher_Text = RSA.Encrypt(DataToEncrypt, false);
                string encryptText = Convert.ToBase64String(bytes_Cypher_Text);
                return encryptText;
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }

        public string Decrypt(string input, string privateKey)
        {
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] DataToDecrypt = Convert.FromBase64String(input);

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.ImportCspBlob(Convert.FromBase64String(privateKey));

                byte[] bytes_Cypher_Text = RSA.Decrypt(DataToDecrypt, false);
                string decryptText = Convert.ToBase64String(bytes_Cypher_Text);
                decryptText = Base64ToString(decryptText);

                return decryptText;
            }
            catch (CryptographicException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }


        private string Base64ToString(string input)
        {
            string result = "";
            try
            {
                byte[] c = Convert.FromBase64String(input);
                result = System.Text.Encoding.Default.GetString(c);

            }
            catch (Exception ex)
            {
                return input;
            }
            return result;
        }

    }


    public struct RSAKEY
    {
        private string pivateKey { get; set; }
        private string publicKey { get; set; }

        public void Set(string _privateKey, string _publicKey)
        {
            pivateKey = _privateKey;
            publicKey = _publicKey;
        }

    }



}
