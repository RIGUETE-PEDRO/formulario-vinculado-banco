using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ifesFood
{
    public class Sha1Hasher
    {
        public static string ComputeSha1Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                // Convert the input string to a byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute the hash
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                // Convert the hash byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // "x2" formats as two hexadecimal digits
                }
                return sb.ToString();
            }
        }
    }
}