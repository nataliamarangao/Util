﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Util.Hash
{
    public sealed class MD5
    {
        public static string GerarHashMd5(string input)
        {
            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();
            
            //Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            //Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            //Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
