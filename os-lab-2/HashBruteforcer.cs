using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public static string BruteForceSingle(string hash)
        {
            if (!File.Exists(PassDict.path))
                PassDict.GenerateDictionary(pass_length);
            var reader = new StreamReader(PassDict.path);
            while (!reader.EndOfStream)
            {
                var pass = reader.ReadLine();
                if (CheckHash(pass, hash))
                {
                    reader.Close();
                    return pass;
                }
            }
            reader.Close();
            return null;
        }

        public static async Task<string> BruteForceMulti(string hash, int threadAmount)
        {
            if (!File.Exists(PassDict.path))
                PassDict.GenerateDictionary(pass_length);
            var dict = File.ReadLines(PassDict.path).ToList();
            
            var passPositions = new List<Tuple<int, int>>();
            var curStart = 0;
            var defaultInterval = dict.Count / threadAmount;
            for (var i = 0; i < threadAmount - 1; i++)
            {
                passPositions.Add(new Tuple<int, int>(curStart, defaultInterval));
                curStart += defaultInterval;
            }
            passPositions.Add(new Tuple<int, int>(curStart, defaultInterval + 
                dict.Count % defaultInterval - 1));

            var tasks = new List<Task<string>>();
            for (var i = 0; i < threadAmount; i++)
            {
                var seg = dict.GetRange(passPositions[i].Item1,passPositions[i].Item2);
                var task = Task<string>.Run(() => BruteforceTask(seg, hash));
                tasks.Add(task);
            }
            
            while (tasks.Any())
            {
                Task<string> finishedTask = await Task.WhenAny(tasks);
                if (finishedTask.Result != null)
                    return finishedTask.Result;
                tasks.Remove(finishedTask);
            }
            return null;
        }

        private static string BruteforceTask(List<string> segment, string hash)
        {
            string result = null;
            foreach (var pass in segment)
            {
                if (CheckHash(pass, hash))
                {
                    result = pass;
                    break;
                }            
            }
            return result;
        }
    }
}