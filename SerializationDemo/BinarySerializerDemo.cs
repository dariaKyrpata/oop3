using System;
using System.IO;

public static class BinarySerializerDemo
{
    public static void Run(StringData[] items)
    {
        string filePath = "strings.bin";

        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            writer.Write(items.Length);

            foreach (StringData item in items)
            {
                writer.Write(item.Value);
            }
        }

        Console.WriteLine("Binary serialization completed.");

        StringData[] restoredItems;

        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            int count = reader.ReadInt32();

            restoredItems = new StringData[count];

            for (int i = 0; i < count; i++)
            {
                string value = reader.ReadString();
                restoredItems[i] = new StringData(value);
            }
        }

        Console.WriteLine("Binary deserialization:");

        foreach (StringData item in restoredItems)
        {
            Console.WriteLine(item);
        }
    }
}