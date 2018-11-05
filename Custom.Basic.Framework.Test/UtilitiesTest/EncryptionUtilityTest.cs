using Custom.Basic.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.UtilitiesTest
{
    /// <summary>
    /// SymmetricEncryptTest
    /// </summary>
    public class EncryptionUtilityTest
    {
        [Fact]
        public void AES_DncryptTest()
        {
            string aesKey = "kvOc8G8saw5KJqpd702eJjeU86sL1t53ITGlPnog8yg";
            string encrypt = @"TbfUfp8KMtMOT8GzQmozQfiCLFSg+XPkoEabH+yrxWWhVzy7H7ZaaGD6oPNT3amMBEC5pyn2ZZuom1ThhfX0KWqpiJRbneQ6xJNd8qYqaKVM8AfuIrl+VOERRTRQO7\/e200f1FVtoaqHS9EqCZqLg1J+2Vz3JrGCJ8NVF6Iu+p9N0sqZqZrE1iQGH7KMEqln8KZrl\/AVOENPEWWqldFl6FQAf\/+xVVfW735afvtfVKkVtbrxDBHxAAuP6W4xe5eZTCWm9+xt8HmwH85sFECpfpZ7jZqx6SyIU3aF2D9FJg7jE1vVE\/1HHgNNws3W+u0zvYGU9+8d327l9WnxuZzgWg==";
            encrypt = encrypt.Replace("\\", "");

            aesKey += "=";
            byte[] bytes = Convert.FromBase64String(aesKey);

            //byte[] keyBytes = Convert.FromBase64String(aesKey).ToArray();
            //byte[] ivBytes = Convert.FromBase64String(aesKey).Take(16).ToArray();
            //string iv = Convert.ToBase64String(ivBytes);

            byte[] encryptByte = Convert.FromBase64String(encrypt);
            byte[] keyBytes = Convert.FromBase64String(aesKey).ToArray();
            byte[] ivBytes = Convert.FromBase64String(aesKey).Take(16).ToArray();


            byte[] encryBytes = EncryptionUtility.AES_DncryptByte(encryptByte, keyBytes, ivBytes);
            string result2 = Encoding.UTF8.GetString(encryBytes);

            string iv = Convert.ToBase64String(ivBytes);
            string result = EncryptionUtility.AES_Dncrypt(encrypt, aesKey, iv);

            //string json = EncryptionUtility.AES_Dncrypt(encrypt, keyBytes, ivBytes);

            Assert.True(false);

        }


    }
}
