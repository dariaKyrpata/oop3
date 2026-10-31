using System;
using System.Collections.Generic;
using System.IO;

namespace DAL;

public class EntityContext
{
    private readonly Dictionary<string, DataProvider> providers;

    public EntityContext()
    {
        providers = new Dictionary<string, DataProvider>(
            StringComparer.OrdinalIgnoreCase
        )
        {
            ["json"] = new JsonDataProvider(),
            ["xml"] = new XmlDataProvider(),
            ["binary"] = new BinaryDataProvider(),
            ["custom"] = new CustomDataProvider()
        };
    }

    public void Save<T>(List<T> items, string filePath, string format)
    {
        DataProvider provider = GetProvider(format);

        string? directory = Path.GetDirectoryName(
            Path.GetFullPath(filePath)
        );

        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        provider.Save(items, filePath);
    }

    public List<T> Load<T>(string filePath, string format)
{
    if (!File.Exists(filePath))
    {
        throw new FileNotFoundException(
            $"File not found: {filePath}",
            filePath
        );
    }

    DataProvider provider = GetProvider(format);
    return provider.Load<T>(filePath);
}
    public void Delete(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public bool Exists(string filePath)
    {
        return File.Exists(filePath);
    }

    private DataProvider GetProvider(string format)
    {
        if (!providers.TryGetValue(format, out DataProvider? provider))
        {
            throw new ArgumentException(
                "Unsupported serialization format.",
                nameof(format)
            );
        }

        return provider;
    }
}