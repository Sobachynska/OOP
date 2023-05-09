using System;
using System.Collections.Generic;

public abstract class TTriad
{
    protected int[] Numbers = new int[3];

    public abstract void Increment();
    public abstract void Decrement();

    public override string ToString()
    {
        return $"{Numbers[0]}.{Numbers[1]}.{Numbers[2]}";
    }
}

public class TDate : TTriad
{
    public TDate(int day, int month, int year)
    {
        Numbers[0] = day;
        Numbers[1] = month;
        Numbers[2] = year;
    }

    public override void Increment()
    {
        // Logic to increment date
    }

    public override void Decrement()
    {
        if (--Numbers[0] < 1)
        {
            Numbers[0] = 31;
            if (--Numbers[1] < 1)
            {
                Numbers[1] = 12;
                --Numbers[2];
            }
        }
    }

    public bool IsValidTime()
    {
        // Logic to check if date is valid time
        return Numbers[0] <= 24 && Numbers[1] <= 60 && Numbers[2] <= 60;
    }
}

public class TTime : TTriad
{
    public TTime(int hour, int minute, int second)
    {
        Numbers[0] = hour;
        Numbers[1] = minute;
        Numbers[2] = second;
    }

    public override void Increment()
    {
        // Logic to increment time
    }

    public override void Decrement()
    {
        // Logic to decrement time
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        List<TDate> dates = new List<TDate>();
        List<TTime> times = new List<TTime>();

        for (int i = 0; i < 10; i++)
        {
            dates.Add(new TDate(rand.Next(1, 31), rand.Next(1, 13), rand.Next(2000, 2023)));
            times.Add(new TTime(rand.Next(0, 24), rand.Next(0, 60), rand.Next(0, 60)));
        }

        foreach (var date in dates)
        {
            Console.WriteLine("Оригiнальна дата: " + date.ToString());
            if (!date.IsValidTime())
            {
                date.Decrement();
                Console.WriteLine("Скоригована дата: " + date.ToString());
            }
        }
    }
}