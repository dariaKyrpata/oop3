using System;
using System.Linq;

public class StringData
{
    public string Value { get; set; } = "";

    public int Length => Value.Length;

    public StringData()
    {
    }

    public StringData(string value)
    {
        Value = value ?? "";
    }

    public string GetDigits()
    {
        return new string(Value.Where(char.IsDigit).ToArray());
    }

    public string GetLetters()
    {
        return new string(Value.Where(char.IsLetter).ToArray());
    }

    public void Reorder()
    {
        string letters = GetLetters();
        string digits = GetDigits();

        string other = new string(
            Value.Where(c => !char.IsLetterOrDigit(c)).ToArray()
        );

        Value = letters + digits + other;
    }

    public override string ToString()
    {
        return $"Value: {Value}, Length: {Length}";
    }
}