using System.Security.Cryptography;
using System.Text;

namespace os_lab_2
{
    public static class HashBruteforcer
    {
        private static readonly int pass_length = 5;
        public static bool CheckHash(string password, string hash)
        {
            var mySHA256 = SHA256.Create();
            var testHash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));
            return HashToString(testHash) == hash;
        }

        private static string HashToString(byte[] hash)
        {
            StringBuilder builder = new StringBuilder();  
            for (int i = 0; i < hash.Length; i++)  
            {  
                builder.Append(hash[i].ToString("x2"));  
            }  
            return builder.ToString();  
        }
    }
}