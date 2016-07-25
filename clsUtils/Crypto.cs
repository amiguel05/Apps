using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace clsUtils
{
    public static class Crypto
    {
        public static string ToCrypto(this string texto)
        {
            string textoEncriptado;
            char[] oByte;

            textoEncriptado = "";
            oByte = texto.ToCharArray();

            foreach (char myByte in oByte)
            {
                textoEncriptado = textoEncriptado + (char)(((char)((int)myByte ^ 16) ^ 128));

            }

            return textoEncriptado;
        }

        private static byte[] Getkey(string pharse)
        {
            var hashProvider = new MD5CryptoServiceProvider();
            var tdesKey = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(pharse));
            return tdesKey;
        }
        public static string Encrypt(this string input, string key = "EXPRESS PARCEL SERVICE")
        {
            var inputArray = Encoding.UTF8.GetBytes(input);
            var generatedKey = Getkey(key);
            var tripleDES = new TripleDESCryptoServiceProvider
            {
                Key = generatedKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tripleDES.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            var x = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return x;
        }

        public static string Decrypt(this string input, string key = "EXPRESS PARCEL SERVICE")
        {
            var inputArray = Convert.FromBase64String(input);
            var generatedKey = Getkey(key);

            var tripleDES = new TripleDESCryptoServiceProvider
            {
                Key = generatedKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tripleDES.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }


    }
}
