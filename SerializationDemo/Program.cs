using System;
using System.Collections.Generic;

Console.WriteLine("=== OOP LAB 3.3 / VARIANT 14 ===");
Console.WriteLine("=== PART 1: SERIALIZATION ===");

StringData[] items =
{
    new StringData("abc123"),
    new StringData("45hello"),
    new StringData("a1b2c3"),
    new StringData("test789")
};

Console.WriteLine("\n=== ORIGINAL OBJECTS ===");

foreach (StringData item in items)
{
    Console.WriteLine(item);
}

Console.WriteLine("\n=== JSON SERIALIZATION ===");
JsonSerializerDemo.Run(items);

Console.WriteLine("\n=== XML SERIALIZATION ===");
XmlSerializerDemo.Run(items);

Console.WriteLine("\n=== BINARY SERIALIZATION ===");
BinarySerializerDemo.Run(items);

Console.WriteLine("\n=== CUSTOM SERIALIZATION ===");
CustomSerializerDemo.Run(items);

Console.WriteLine("\n=== COLLECTION SERIALIZATION ===");

List<StringData> list = new List<StringData>(items);

string listJson = System.Text.Json.JsonSerializer.Serialize(
    list,
    new System.Text.Json.JsonSerializerOptions { WriteIndented = true }
);

System.IO.File.WriteAllText("strings-list.json", listJson);

List<StringData> restoredList =
    System.Text.Json.JsonSerializer.Deserialize<List<StringData>>(
        System.IO.File.ReadAllText("strings-list.json")
    ) ?? new List<StringData>();

Console.WriteLine("Restored collection:");

foreach (StringData item in restoredList)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nArray and List serialization completed.");
Console.WriteLine("\nPart 1 completed successfully.");

Console.ReadKey();