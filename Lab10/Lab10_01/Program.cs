using System;
using System.Collections.Generic;

public class CharSet
{
    private HashSet<char> set;

    public CharSet()
    {
        set = new HashSet<char>();
    }

    public CharSet(params char[] elements)
    {
        set = new HashSet<char>(elements);
    }

    public bool Contains(char element)
    {
        return set.Contains(element);
    }

    public static CharSet operator *(CharSet set1, CharSet set2)
    {
        CharSet result = new CharSet();
        foreach (char element in set1.set)
        {
            if (set2.Contains(element))
                result.set.Add(element);
        }
        return result;
    }

    public static bool operator >(CharSet set1, CharSet set2)
    {
        foreach (char element in set2.set)
        {
            if (!set1.Contains(element))
                return false;
        }
        return true;
    }

    public static bool operator <(CharSet set1, CharSet set2)
    {
        return set2 > set1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CharSet set1 = new CharSet('a', 'b', 'c');
        CharSet set2 = new CharSet('b', 'c', 'd');

        Console.WriteLine("Set 1: " + string.Join(", ", set1));
        Console.WriteLine("Set 2: " + string.Join(", ", set2));
        Console.WriteLine();

        Console.WriteLine("Set 1 contains 'a': " + set1.Contains('a'));
        Console.WriteLine("Set 2 contains 'd': " + set2.Contains('d'));
        Console.WriteLine();

        CharSet intersection = set1 * set2;
        Console.WriteLine("Intersection: " + string.Join(", ", intersection));
        Console.WriteLine();

        Console.WriteLine("Set 1 is a subset of Set 2: " + (set1 < set2));
        Console.WriteLine("Set 2 is a subset of Set 1: " + (set2 < set1));
    }
}