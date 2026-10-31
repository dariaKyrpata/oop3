using System.Collections.Generic;

namespace DAL;

public abstract class DataProvider
{
    public abstract void Save<T>(List<T> items, string filePath);

    public abstract List<T> Load<T>(string filePath);
}