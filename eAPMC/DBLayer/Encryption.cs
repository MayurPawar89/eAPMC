using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public static class Encryption
    {

        private static byte[] _key;
        private static byte[] _iv = { 18, 52, 86, 120, 144, 171, 205, 239 };
        private static string encryptionKey = "EAPMC517";//ProjectNameMonthYear

        public static string EncryptToBase64String(string stringToEncrypt)
        {
            try
            {
                _key = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string DecryptFromBase64String(string stringToDecrypt)
        {
            try
            {
                byte[] inputByteArray = new byte[stringToDecrypt.Length];
                _key = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
                inputByteArray = Convert.FromBase64String(stringToDecrypt);

                MemoryStream ms = new MemoryStream();
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(_key, _iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
