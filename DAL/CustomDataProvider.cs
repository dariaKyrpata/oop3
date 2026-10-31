using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DAL;

public class CustomDataProvider : DataProvider
{
    public override void Save<T>(List<T> items, string filePath)
    {
        using StreamWriter writer = new StreamWriter(filePath);

        foreach (T item in items)
        {
            string json = JsonSerializer.Serialize(item);

            string encoded = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(json)
            );

            writer.WriteLine(encoded);
        }
    }

    public override List<T> Load<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }

        List<T> items = new List<T>();

        foreach (string line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new InvalidDataException("Invalid custom data.");
            }

            byte[] bytes = Convert.FromBase64String(line);

            string json = Encoding.UTF8.GetString(bytes);

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
