using System;
using System.Collections.Generic;
using System.Linq;

public class DB
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Selling { get; set; }
    public int Marketpart { get; set; }
}

public class DBCollections
{
    private List<List<DB>> _collections;

    public DBCollections()
    {
        _collections = new List<List<DB>>();
    }

    public void AddCollection(List<DB> collection)
    {
        _collections.Add(collection);
    }

    public List<DB> this[int index]
    {
        get
        {
            if (index >= 0 && index < _collections.Count)
            {
                return _collections[index];
            }
            throw new IndexOutOfRangeException("Index is out of range");
        }
        set
        {
            if (index >= 0 && index < _collections.Count)
            {
                _collections[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }
    }

    public int CollectionsCount
    {
        get { return _collections.Count; }
    }

    public int CountCollectionsWithSize(int size)
    {
        return _collections.Count(c => c.Count == size);
    }

    public List<DB> GetMaxCollection()
    {
        return _collections.OrderByDescending(c => c.Count).First();
    }

    public List<DB> GetMinCollection()
    {
        return _collections.OrderBy(c => c.Count).First();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<DB> collection1 = new List<DB>
        {
            new DB { Name = "Oracle", Type = "1", Selling = 250000000, Marketpart = 31  },
            new DB { Name = "IBM", Type = "З", Selling = 240000000, Marketpart = 29 }
        };
        // числа скоротила на 1 нуль

        List<DB> collection2 = new List<DB>
        {
            new DB { Name = "Microsoft", Type = "2", Selling = 100000000, Marketpart = 13 }
        };

        DBCollections dbCollections = new DBCollections();
        dbCollections.AddCollection(collection1);
        dbCollections.AddCollection(collection2);

        // Знайти кількість колекцій розміру 2
        int countOfSize2 = dbCollections.CountCollectionsWithSize(2);
        Console.WriteLine($"Кількість колекцій розміру 2: {countOfSize2}");

        // Знайти максимальну колекцію
        List<DB> maxCollection = dbCollections.GetMaxCollection();
        Console.WriteLine("Максимальна колекція:");
        foreach (DB db in maxCollection)
        {
            Console.WriteLine($"{db.Name}, Річний об'єм продажу: {db.Selling}, Частина ринку: {db.Marketpart}");
        }

        // Знайти мінімальну колекцію
        List<DB> minCollection = dbCollections.GetMinCollection();
        Console.WriteLine("Мінімальна колекція:");
        foreach (DB db in minCollection)
        {
            Console.WriteLine($"{db.Name}, Річний об'єм продажу: {db.Selling}, Частина ринку: {db.Marketpart}");
        }

        // Вивести елемент з індексом 1 з першої колекції
        DB db1 = dbCollections[0][1];
        Console.WriteLine($"Елемент з індексом 1 з першої колекції: {db1.Name}, Річний об'єм продажу: {db1.Selling}, Частина ринку: {db1.Marketpart}");
    }
}