using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace os_lab_1
{
    static class Xml
    {
        public static void Execute()
        {
            var data = new SomeData { number = 15, str = "this is a test string" };
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(data.GetType());

            var path = Directory.GetCurrentDirectory() + "\\data.xml";
            var writer = new StreamWriter(path);
            x.Serialize(writer, data);
            writer.Close();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            Console.WriteLine(doc.OuterXml);
            XmlNode newNode = doc.CreateNode("element", "new_node", "");
            newNode.InnerText = "This is a new node.";
            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine(doc.OuterXml);

            File.Delete(path);

        }
    }
}
