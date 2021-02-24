using System;
using System.IO;

namespace os_lab_1
{
    static class Files
    {
        public static void Execute()
        {
            var path = Directory.GetCurrentDirectory() + "\\test-file.txt";
            
            var writer = new StreamWriter(path);
            Console.WriteLine("Enter a string to be written to file: ");
            var content = Console.ReadLine();
            writer.WriteLine(content);
            writer.Close();

            var reader = new StreamReader(path);
            Console.WriteLine($"File opened: {path}");
            Console.Write($"Contents: {reader.ReadToEnd()}");
            reader.Close();

            File.Delete(path);
            Console.WriteLine("File deleted");
        }
    }
}
