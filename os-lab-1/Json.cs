﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace os_lab_1
{
    static class Json
    {
        public static void Execute()
        {
            var path = Directory.GetCurrentDirectory() + "\\data.json";

            var genData = new DataExample()
            {
                DataString = "test string",
                DataInt = 42,
                DataBool = true,
                DataIntList = new List<int>() {1, 2, 3}
            };
            var jsonString = JsonSerializer.Serialize(genData, new JsonSerializerOptions(){WriteIndented = true});
            Console.WriteLine("Original JSON:");
            Console.WriteLine(jsonString);
            Console.WriteLine();
            
            var writer = new StreamWriter(path);
            writer.WriteLine(jsonString);
            writer.Close();

            var reader = new StreamReader(path);
            var data = JsonSerializer.Deserialize<DataExample>(reader.ReadToEnd());
            reader.Close();

            data.DataString = "edited string";
            data.DataInt = 1337;
            data.DataBool = false;
            data.DataIntList.Add(123);
            
            writer = new StreamWriter(path);
            writer.WriteLine(JsonSerializer.Serialize(data, new JsonSerializerOptions(){WriteIndented = true}));
            writer.Close();

            reader = new StreamReader(path);
            Console.WriteLine("Edited JSON:");
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            File.Delete(path);
        }
    }

    class DataExample
    {
        public string DataString { get; set; }
        public int DataInt { get; set; }
        public bool DataBool { get; set; }
        public List<int> DataIntList { get; set; }
    }
}
