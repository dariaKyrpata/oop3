using System;
using System.IO;
using System.Xml.Serialization;

public static class XmlSerializerDemo
{
    public static void Run(StringData[] items)
    {
        string filePath = "strings.xml";

        XmlSerializer serializer = new XmlSerializer(typeof(StringData[]));

        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, items);
        }

        Console.WriteLine("XML serialization completed.");

        StringData[] restoredItems;

        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            restoredItems = (StringData[])serializer.Deserialize(stream)!;
        }

        Console.WriteLine("XML deserialization:");

        foreach (StringData item in restoredItems)
        {
            Console.WriteLine(item);
        }
    }
}