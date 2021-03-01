using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace os_lab_2
{
    public static class PassDict
    {
        private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string path = "../../../passdict.txt";
        
        public static void GenerateDictionary(int length)
        {
            var writer = new StreamWriter(path);
            var passwords = GetPermutationsWithRept(alphabet, length);
            foreach (var pass in passwords)
            {
                writer.WriteLine(String.Concat(pass));
            }
            writer.Close();
        }
        
        private static IEnumerable<IEnumerable<T>> 
            GetPermutationsWithRept<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutationsWithRept(list, length - 1)
                .SelectMany(t => list, 
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}