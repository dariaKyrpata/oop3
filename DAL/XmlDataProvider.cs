using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL;

public class XmlDataProvider : DataProvider
{
    public override void Save<T>(List<T> items, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, items);
        }
    }

    public override List<T> Load<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            return (List<T>)serializer.Deserialize(stream)!;
        }
    }
}