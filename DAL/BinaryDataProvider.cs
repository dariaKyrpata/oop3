using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DAL;

public class BinaryDataProvider : DataProvider
{
    public override void Save<T>(List<T> items, string filePath)
    {
        using BinaryWriter writer = new BinaryWriter(
            File.Open(filePath, FileMode.Create),
            Encoding.UTF8
        );

        writer.Write(items.Count);

        foreach (T item in items)
        {
            string json = JsonSerializer.Serialize(item);
            writer.Write(json);
        }
    }

    public override List<T> Load<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }

        using BinaryReader reader = new BinaryReader(
            File.Open(filePath, FileMode.Open),
            Encoding.UTF8
        );

        int count = reader.ReadInt32();

        if (count < 0)
        {
            throw new InvalidDataException("Invalid item count.");
        }

        List<T> items = new List<T>();

        for (int i = 0; i < count; i++)
        {
            string json = reader.ReadString();

            T? item = JsonSerializer.Deserialize<T>(json);

            if (item == null)
            {
                throw new InvalidDataException("Invalid item data.");
            }

            items.Add(item);
        }

        return items;
    }
}