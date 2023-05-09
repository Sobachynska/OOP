using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Створення масиву об'єктів CollectionType
        CollectionType[] collections = new CollectionType[]
        {
            new CollectionType("Collection1", new List<int> { 1, 2, 3 }),
            new CollectionType("Collection2", new List<int> { 4, 5 }),
            new CollectionType("Collection3", new List<int> { 1, 7, 8 }),
            new CollectionType("Collection4", new List<int> { 1, 2 })
        };

        int sizeToFind = 2;

        // Знайти кількість колекцій, рівних заданому розміру
        int collectionsWithSizeCount = collections.Count(c => c.Collection.Count == sizeToFind);

        Console.WriteLine($"Number of collections with size {sizeToFind}: {collectionsWithSizeCount}");

        // Знайти максимальну колекцію в масиві
        CollectionType maxCollection = collections.OrderByDescending(c => c.Collection.Count).FirstOrDefault();

        if (maxCollection != null)
        {
            Console.WriteLine($"Maximum collection: {maxCollection.Name}");
        }
        else
        {
            Console.WriteLine("No collections found");
        }

        // Знайти мінімальну колекцію в масиві
        CollectionType minCollection = collections.OrderBy(c => c.Collection.Count).FirstOrDefault();

        if (minCollection != null)
        {
            Console.WriteLine($"Minimum collection: {minCollection.Name}");
        }
        else
        {
            Console.WriteLine("No collections found");
        }

        Console.ReadKey();
    }
}

// Клас CollectionType, який містить назву та узагальнену колекцію List
class CollectionType
{
    public string Name { get; set; }
    public List<int> Collection { get; set; }

    public CollectionType(string name, List<int> collection)
    {
        Name = name;
        Collection = collection;
    }
}
