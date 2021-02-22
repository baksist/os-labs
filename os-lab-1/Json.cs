using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace os_lab_1
{

    static class Json
    {
        public static void Execute()
        {
            var path = Directory.GetCurrentDirectory() + "\\data.json";

            var writer = new StreamWriter(path);
            writer.WriteLine("{ \"str\":\"Happy birthday!\",\"number\":19}");
            writer.Close();

            var reader = new StreamReader(path);
            var data = JsonSerializer.Deserialize<SomeData>(reader.ReadToEnd());
            reader.Close();

            data.str = "This is an edited string";
            data.number = 1337;
            
            writer = new StreamWriter(path);
            writer.WriteLine(JsonSerializer.Serialize<SomeData>(data));
            writer.Close();

            reader = new StreamReader(path);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            File.Delete(path);
        }
    }
}
