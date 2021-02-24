using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVC_Form
{
    class Hash
    {
        public string CreateMD5(int roll, List<string> coins, string selection, string txID)
        {
            string allCoins = string.Empty;
            foreach (var coin in coins)
                allCoins += String.Format("{0},", coin);
            string concat = String.Concat(coins.Count.ToString(), "/", roll.ToString(), "|", allCoins, "|", selection, "|", txID);

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(concat);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                md5.Dispose();
                return sb.ToString();
            }
        }

        public string EncodeBase64(DateTime time, int type, int price, double marketCap)
        {
            string concat = String.Concat(time.ToFileTimeUtc(), "|", type.ToString(), "|", price.ToString(), "|", marketCap.ToString());
            var bytes = Encoding.UTF8.GetBytes(concat);
            var encodedString = Convert.ToBase64String(bytes);

            return encodedString;
        }

        public string DecodeBase64(string encodedString)
        {
            var bytes = Convert.FromBase64String(encodedString);

            var decodedString = Encoding.UTF8.GetString(bytes);

            return decodedString;
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
