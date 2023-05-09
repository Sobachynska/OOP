using System;
using System.Collections.Generic;
using System.Linq;

class CollectionType
{
    private List<string> _strings;

    public CollectionType()
    {
        _strings = new List<string>();
    }

    public void Add(params string[] values)
    {
        _strings.AddRange(values);
    }

    public IEnumerable<string> FindContaining(string value)
    {
        return _strings.Where(s => s.Contains(value));
    }

    public int CountByLength(int length)
    {
        return _strings.Count(s => s.Length == length);
    }

    public void Sort(bool ascending = true)
    {
        _strings.Sort();
        if (!ascending)
        {
            _strings.Reverse();
        }
    }

    public override string ToString()
    {
        return string.Join(", ", _strings);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CollectionType collection = new CollectionType();
        collection.Add("Anna", "Angelina", "Varvara", "Yana", "Madina");

        Console.WriteLine($"Введення-виведення: {collection}");

        Console.WriteLine("\nРядки, що містять 'i':");
        Console.WriteLine(string.Join(", ", collection.FindContaining("i")));

        Console.WriteLine($"\nКількість рядків довжини 5: {collection.CountByLength(5)}");

        collection.Sort();
        Console.WriteLine($"\nСортування у зростаючому порядку: {collection}");

        collection.Sort(false);
        Console.WriteLine($"\nСортування у спадному порядку: {collection}");
    }
}
