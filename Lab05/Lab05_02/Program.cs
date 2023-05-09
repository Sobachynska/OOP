using System;

interface Instrument
{
    void play();
    string KEY { get; }
}

class Guitar : Instrument
{
    private int numberOfStrings;
    public Guitar(int numberOfStrings)
    {
        this.numberOfStrings = numberOfStrings;
    }
    public void play()
    {
        Console.WriteLine("Playing guitar with {0} strings", numberOfStrings);
    }
    public string KEY
    {
        get { return "До мажор"; }
    }
}

class Drums : Instrument
{
    private string size;
    public Drums(string size)
    {
        this.size = size;
    }
    public void play()
    {
        Console.WriteLine("Playing drums with size {0}", size);
    }
    public string KEY
    {
        get { return "До мажор"; }
    }
}

class Trumpet : Instrument
{
    private double diameter;
    public Trumpet(double diameter)
    {
        this.diameter = diameter;
    }
    public void play()
    {
        Console.WriteLine("Playing trumpet with diameter {0}", diameter);
    }
    public string KEY
    {
        get { return "До мажор"; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Instrument[] instruments = new Instrument[] {
            new Guitar(6),
            new Drums("large"),
            new Trumpet(11)
        };

        foreach (Instrument instrument in instruments)
        {
            Console.Write("Playing {0} with KEY {1}: ", instrument.GetType().Name, instrument.KEY);
            instrument.play();
        }
    }
}