using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class DB : IComparable<DB>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Selling { get; set; }
    public int Marketpart { get; set; }

    public int CompareTo(DB other)
    {
        return this.Selling.CompareTo(other.Selling);
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
        CollectionType<DB> collection1 = new CollectionType<DB>();
        collection1.Add(new DB { Name = "Oracle", Type = "1", Selling = 250000000, Marketpart = 31 });
        collection1.Add(new DB { Name = "IBM", Type = "З", Selling = 240000000, Marketpart = 29 });

        CollectionType<DB> collection2 = new CollectionType<DB>();
        collection2.Add(new DB { Name = "Microsoft", Type = "2", Selling = 100000000, Marketpart = 13 });

        
        collection1.Sort();

        
        var dbWithHighMarketpart = collection1.Where(c => c.Marketpart > 25);

        foreach (var db in dbWithHighMarketpart)
        {
            Console.WriteLine($"{db.Name}, Частина ринку: {db.Marketpart}");
        }

        Console.ReadLine();
    }
}