using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Culture : IComparable<Culture>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Area { get; set; }
    public int Harvest { get; set; }

    public int CompareTo(Culture other)
    {
        return this.Area.CompareTo(other.Area);
    }
}

class CollectionType<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> _collection;
    public CollectionType()
    {
        _collection = new List<T>();
    }

    public void Add(T item)
    {
        _collection.Add(item);
    }
    public void Remove(T item)
    {
        _collection.Remove(item);
    }
    public T this[int index]
    {
        get { return _collection[index]; }
        set { _collection[index] = value; }
    }
    public int Count
    {
        get { return _collection.Count; }
    }
    public void Sort()
    {
        _collection.Sort();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        CollectionType<Culture> collection1 = new CollectionType<Culture>();
        collection1.Add(new Culture { Name = "Кукурудза", Type = "З", Area = 13000, Harvest = 45 });
        collection1.Add(new Culture { Name = "Пшениця", Type = "З", Area = 8000, Harvest = 17 });

        CollectionType<Culture> collection2 = new CollectionType<Culture>();
        collection2.Add(new Culture { Name = "Рис", Type = "З", Area = 25650, Harvest = 24 });

        // Сортування колекції за площею посіву
        collection1.Sort();

        // LINQ-запит: знайти культури з врожайністю більше 20
        var culturesWithHighHarvest = collection1.Where(c => c.Harvest > 20);

        foreach (var culture in culturesWithHighHarvest)
        {
            Console.WriteLine($"{culture.Name}, Врожайність: {culture.Harvest}");
        }

        Console.ReadLine();
    }
}