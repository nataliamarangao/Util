using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Util.Criptografia
{
    public sealed class MD5
    {
        public static string Encryptografar(string hash, string descriptografado)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(descriptografado);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDESC = new TripleDESCryptoServiceProvider();

            tripDESC.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripDESC.Mode = CipherMode.ECB;

            ICryptoTransform cryptoTransform = tripDESC.CreateEncryptor();
            byte[] resultado = cryptoTransform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(resultado);
        }

        public static string Descriptografar(string hash, string criptografado)
        {
            byte[] data = Convert.FromBase64String(criptografado);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDESC = new TripleDESCryptoServiceProvider();

            tripDESC.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripDESC.Mode = CipherMode.ECB;

            ICryptoTransform cryptoTransform = tripDESC.CreateDecryptor();
            byte[] resultado = cryptoTransform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(resultado);
        }
    }
}
