using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Hash
{
    public sealed class SHA1
    {
        public static String GerarHashSHA1(string input)
        {
            System.Security.Cryptography.SHA1 sha1Hash = System.Security.Cryptography.SHA1.Create();

            byte[] data = sha1Hash.ComputeHash(Encoding.ASCII.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
