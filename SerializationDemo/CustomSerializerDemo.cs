using System;
using System.IO;
using System.Text;

public static class CustomSerializerDemo
{
    public static void Run(StringData[] items)
    {
        string filePath = "strings.custom";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (StringData item in items)
            {
                string encoded = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(item.Value)
                );

                writer.WriteLine(encoded);
            }
        }

        Console.WriteLine("Custom serialization completed.");

        string[] lines = File.ReadAllLines(filePath);

        StringData[] restoredItems = new StringData[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            byte[] bytes = Convert.FromBase64String(lines[i]);

            string value = Encoding.UTF8.GetString(bytes);

            restoredItems[i] = new StringData(value);
        }

        Console.WriteLine("Custom deserialization:");

        foreach (StringData item in restoredItems)
        {
            Console.WriteLine(item);
        }
    }
}