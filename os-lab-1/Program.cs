using System;

namespace os_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Drives info");
            Console.WriteLine("2. Files");
            Console.WriteLine("3. JSON");
            Console.WriteLine("4. XML");
            Console.WriteLine("5. Zip archives");
            Console.WriteLine("Please choose task (1-5):");

            while (true)
            {
                var choice = Int32.Parse(Console.ReadLine());
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
                    default:
                        break;
                }
            }
        }
    }
}
