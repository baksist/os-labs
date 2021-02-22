using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace os_lab_1
{
    static class Files
    {
        public static void Execute()
        {
            Console.WriteLine("Enter file name: ");
            var filename = Console.ReadLine();
            filename = Directory.GetCurrentDirectory() + $"\\{filename}";

            var writer = new StreamWriter(filename);
            Console.WriteLine("Enter any string: ");
            var content = Console.ReadLine();
            writer.WriteLine(content);
            writer.Close();

            var reader = new StreamReader(filename);
            Console.WriteLine($"Your string: {reader.ReadToEnd()}");
            reader.Close();

            File.Delete(filename);
        }
    }
}
