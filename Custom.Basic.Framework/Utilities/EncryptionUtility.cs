using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Utilities
{
    /// <summary>
    /// 加密工具类
    /// </summary>
    public static class EncryptionUtility
    {

        /// <summary>
        /// AES 对称加密
        /// </summary>
        /// <param name="encryText">需要加密的内容</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns>返回加密后的字节</returns>
        public static byte[] AES_EncryptByte(string encryText, byte[] Key, byte[] IV)
        {
            if (string.IsNullOrEmpty(encryText))
                throw new ArgumentNullException("encryTextByte");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("加密密钥缺失 Key is not null.");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("加密初始化向量缺失 IV is not null.");

            byte[] encrypted;

            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // 创建对称加密执行流转换器
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(encryText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;

        }

        /// <summary>
        /// AES 对称加密
        /// </summary>
        /// <param name="encryText">需要加密的内容</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns>返回加密后字符串</returns>
        public static string AES_Encrypt(string encryText, byte[] key, byte[] IV)
        {
            byte[] encryBytes = Convert.FromBase64String(encryText);
            byte[] result = AES_DncryptByte(encryBytes, key, IV);

            return Encoding.UTF8.GetString(result);

        }


        /// <summary>
        /// AES 对称解密
        /// </summary>
        /// <param name="encryText">需要解密的内容 base64</param>
        /// <param name="Key">密钥 base64</param>
        /// <param name="IV">初始化向量 base64</param>
        /// <returns>返回解密后的字节</returns>
        public static byte[] AES_DncryptByte(byte[] encryTextByte, byte[] Key, byte[] IV)
        {
            if (encryTextByte == null || encryTextByte.Length <= 0)
                throw new ArgumentNullException("没有需要解密的内容 encryTextByte is not null.");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("解密密钥缺失 Key is not null.");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("解密初始化向量缺失 IV is not null.");

            // 解密后的字节
            byte[] resultDncryptBytes;

            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // 创建对称解密器容器
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream ms = new MemoryStream(encryTextByte))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {

                        using (StreamReader sr = new StreamReader(csDecrypt))
                        {

                            List<char> result = new List<char>();
                            char[] resutChars = null;
                            while (sr.Peek() >= 0)
                            {
                                resutChars = new char[1];
                                sr.Read(resutChars, 0, resutChars.Length);

                                result.AddRange(resutChars);
                            }

                            resultDncryptBytes = Encoding.UTF8.GetBytes(result.ToArray());

                        }
                    }
                }

            }

            return resultDncryptBytes;

        }



        /// <summary>
        /// AES 对称解密
        /// </summary>
        /// <param name="encryText">需要解密的内容字节</param>
        /// <param name="key">密钥</param>
        /// <param name="ivStr">初始化向量</param>
        /// <returns>返回解密后的字符串</returns>
        public static string AES_Dncrypt(string encryText, string key, string ivStr)
        {
            // 字符串 转 8位 base64
            byte[] encryBytes = Convert.FromBase64String(encryText);
            byte[] keyByte = Convert.FromBase64String(key);
            byte[] ivByte = Convert.FromBase64String(ivStr);
            byte[] result = AES_DncryptByte(encryBytes, keyByte, ivByte);

            return Encoding.UTF8.GetString(result);
        }


        /// <summary>
        /// 标准MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string text = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                text += bytes[i].ToString("x").PadLeft(2, '0');
            }
            return text;
        }

        /// <summary>
        /// 16位的MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5_16(string str)
        {
            return MD5(str).Substring(8, 16);
        }

        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string Base64_Encode(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// base64解码
        /// </summary>
        /// <param name="str">待解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string Base64_Decode(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            string result = Convert.ToBase64String(bytes);

            return result;
        }
    }
}
