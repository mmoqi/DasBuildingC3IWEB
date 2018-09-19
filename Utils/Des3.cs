using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using MicroProgram.Utils;

namespace WeiXinTest
{
    /// <summary>
    /// DES3加密解密
    /// </summary>
    public class Des3
    {
        public static byte[] iv = new byte[8] { 117, 20, 36, 64, 5, 89, 7, 29 };
        #region CBC模式**

        /// <summary>
        /// DES3 CBC模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            //复制于MSDN

            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public static string Des3EncodeCBCStr(string keyStr, string dataStr)
        {
            //--向量值固定
            byte[] key;
            byte[] data;
            string rtnString;
            key = System.Text.Encoding.UTF8.GetBytes(keyStr.Substring(3, 24));
            data = System.Text.Encoding.UTF8.GetBytes(dataStr);
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();
                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.

                rtnString = keyStr + "@#" + StringUtils.BytesToString(ret, 0, ret.Length);
                return rtnString;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return "";
            }
        }

        public static string Des3EncodeCBCStrWithNoKey(string keyStr, string dataStr)
        {
            //--向量值固定
            byte[] key;
            byte[] data;
            string rtnString;
            key = System.Text.Encoding.UTF8.GetBytes(keyStr.Substring(3, 24));
            data = System.Text.Encoding.UTF8.GetBytes(dataStr);
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();
                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.

                rtnString = StringUtils.BytesToString(ret, 0, ret.Length);
                return rtnString;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return "";
            }
        }


        /// <summary>
        /// DES3 CBC模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public static string Des3DecodeCBCStr(string dataStr)
        {

            byte[] key;

            byte[] data;
            string[] tempData = dataStr.Split(new string[] { "@#" }, StringSplitOptions.RemoveEmptyEntries);
            string rtnString;
            key = System.Text.Encoding.UTF8.GetBytes(tempData[0].Substring(3, 24));
            data = StringUtils.StringToBytes(tempData[1]);
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                //   return fromEncrypt;
                rtnString = System.Text.Encoding.UTF8.GetString(fromEncrypt).Replace("\0", "");

                //Convert the buffer into a string and return it.
                return rtnString;

            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }






        #endregion

        #region ECB模式

        /// <summary>
        /// DES3 ECB模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        /// <summary>
        /// DES3 ECB模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public static string Des3DecodeECBStr(string dataStr)
        {
            byte[] key;
            byte[] data;
            byte[] iv = new byte[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
            string[] tempData = dataStr.Split(new string[] { "@#" }, StringSplitOptions.RemoveEmptyEntries);
            string rtnString;
            key = System.Text.Encoding.UTF8.GetBytes(tempData[0]);
            data = StringUtils.StringToBytes(tempData[1]);
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                rtnString = System.Text.Encoding.UTF8.GetString(fromEncrypt);

                //Convert the buffer into a string and return it.
                return rtnString;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }


        #endregion


        //Des 加密
        public static byte[] DESDecrypt(byte[] data, byte[] desKey)
        {
            byte[] desIV = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            MemoryStream fout = new MemoryStream();
            try
            {
                fout.SetLength(0);
                byte[] bin = new byte[100];

                long totlen = data.Length;


                DES des = new DESCryptoServiceProvider();
                des.Mode = CipherMode.ECB;
                // des.Padding = PaddingMode.PKCS7;
                des.Padding = PaddingMode.Zeros;

                CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);

                //Read from the input file, then encrypt and write to the output file.
                int k = 0;
                while (totlen > 100)
                {
                    Array.Copy(data, k * 100, bin, 0, 100);
                    totlen = totlen - 100;
                    k++;
                    encStream.Write(bin, 0, 100);

                }
                if (totlen > 0)
                {
                    Array.Copy(data, k * 100, bin, 0, totlen);

                    encStream.Write(bin, 0, (int)totlen);
                }
                encStream.Close();
                fout.Close();

            }
            catch (System.Security.Cryptography.CryptographicException)
            {

                fout.Close();
                return new byte[] { };
            }
            catch (Exception e)
            {

                return new byte[] { };
            }
            return fout.ToArray();
        }
        public static byte[] DESEncrypt(byte[] data, byte[] desKey)
        {

            byte[] desIV = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            MemoryStream fout = new MemoryStream();
            try
            {
                fout.SetLength(0);
                byte[] bin = new byte[100];

                long totlen = data.Length;

                DES des = new DESCryptoServiceProvider();
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.Zeros;
                // tdsp.Padding = PaddingMode.None;  //不填充模式
                CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);

                //Read from the input file, then encrypt and write to the output file.
                int k = 0;
                while (totlen > 100)
                {
                    Array.Copy(data, k * 100, bin, 0, 100);
                    totlen = totlen - 100;
                    k++;
                    encStream.Write(bin, 0, 100);

                }
                if (totlen > 0)
                {
                    Array.Copy(data, k * 100, bin, 0, totlen);

                    encStream.Write(bin, 0, (int)totlen);
                }
                encStream.Close();
                fout.Close();

            }
            catch (System.Security.Cryptography.CryptographicException)
            {


                fout.Close();
                return new byte[] { };
            }
            catch (Exception e)
            {

                return new byte[] { };
            }
            return fout.ToArray();

        }



        ///// <summary>
        ///// 类测试
        ///// </summary>
        //public static void Test()
        //{
        //    System.Text.Encoding utf8 = System.Text.Encoding.UTF8;

        //    //key为abcdefghijklmnopqrstuvwx的Base64编码
        //    byte[] key = Convert.FromBase64String("YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4");
        //    byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };      //当模式为ECB时，IV无用
        //    byte[] data = utf8.GetBytes("中国ABCabc123");

        //    System.Console.WriteLine("ECB模式:");
        //    byte[] str1 = Des3.Des3EncodeECB(key, iv, data);
        //    byte[] str2 = Des3.Des3DecodeECB(key, iv, str1);
        //    System.Console.WriteLine(Convert.ToBase64String(str1));
        //    System.Console.WriteLine(System.Text.Encoding.UTF8.GetString(str2));

        //    System.Console.WriteLine();

        //    System.Console.WriteLine("CBC模式:");
        //    byte[] str3 = Des3.Des3EncodeCBC(key, iv, data);
        //    byte[] str4 = Des3.Des3DecodeCBC(key, iv, str3);
        //    System.Console.WriteLine(Convert.ToBase64String(str3));
        //    System.Console.WriteLine(utf8.GetString(str4));

        //    System.Console.WriteLine();

        //}
    }
}