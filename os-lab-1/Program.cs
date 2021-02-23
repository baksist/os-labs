using System;

namespace os_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PrintOptions();
                Int32.TryParse(Console.ReadLine(), out var choice);
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Drives.Execute();
                        break;
                    case 2:
                        Files.Execute();
                        break;
                    case 3:
                        Json.Execute();
                        break;
                    case 4:
                        Xml.Execute();
                        break;
                    case 5:
                        Zip.Execute();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void PrintOptions()
        {
            Console.WriteLine("1. Drives info");
            Console.WriteLine("2. Files");
            Console.WriteLine("3. JSON");
            Console.WriteLine("4. XML");
            Console.WriteLine("5. Zip archives");
            Console.WriteLine("Choose task (1-5) or quit(0):");
        }
    }
}
