using System;
using System.IO;
using System.Text.Json;

public static class JsonSerializerDemo
{
    public static void Run(StringData[] items)
    {
        string filePath = "strings.json";

        string json = JsonSerializer.Serialize(
            items,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(filePath, json);

        Console.WriteLine("JSON serialization completed.");

        string savedJson = File.ReadAllText(filePath);

        StringData[] restoredItems =
            JsonSerializer.Deserialize<StringData[]>(savedJson)
            ?? Array.Empty<StringData>();

        Console.WriteLine("JSON deserialization:");

        foreach (StringData item in restoredItems)
        {
            Console.WriteLine(item);
        }
    }
}