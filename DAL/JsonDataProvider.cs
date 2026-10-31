using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DAL;

public class JsonDataProvider : DataProvider
{
    public override void Save<T>(List<T> items, string filePath)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(items, options);

        File.WriteAllText(filePath, json);
    }

    public override List<T> Load<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }

        string json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<T>>(json)
               ?? new List<T>();
    }
}