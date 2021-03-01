using System;
using System.Collections.Generic;
using System.IO;

namespace os_lab_2
{
    class Program
    {
        private static string hashes_file = "../../../hashes.txt";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Please choose input method:");
            Console.WriteLine("1. Read hashes from file");
            Console.WriteLine("2. Read hashes from console");
            
            int choice;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                choice = 0;
            }

            List<string> hashes = new List<string>();
            switch (choice)
            {
                case 1:
                    hashes = ReadHashesFile(); 
                    break;
                case 2:
                    hashes = ReadHashesConsole();
                    break;
                default:
                    Console.WriteLine("Unknown option");
                    break;
            }
            
        }

        private static List<string> ReadHashesFile()
        {
            var reader = new StreamReader(hashes_file);
            var hashes = new List<string>();
            while (!reader.EndOfStream)
                hashes.Add(reader.ReadLine());
            reader.Close();
            return hashes;
        }

        private static List<string> ReadHashesConsole()
        {
            Console.Write("Enter your hashes line-by-line; Enter 0 to stop");
            var hashes = new List<string>();
            while (true)
            {
                var hash = Console.ReadLine();
                if (hash != "0")
                    hashes.Add(hash);
                else
                    break;
            }
            return hashes;
        }
    }
}