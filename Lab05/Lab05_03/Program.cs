using System;
using System.Text;

interface IManClothes
{
    void DressMan();
}

interface IWomanClothes
{
    void DressWoman();
}

abstract class Clothing
{
    protected string size;
    protected double price;
    protected string color;

    public Clothing(string size, double price, string color)
    {
        this.size = size;
        this.price = price;
        this.color = color;
    }

    public string Size
    {
        get { return size; }
        set { size = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }
}

class TShirt : Clothing, IManClothes, IWomanClothes
{
    public TShirt(string size, double price, string color) : base(size, price, color)
    {
    }

    public void DressMan()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8; // на всякий випадок
        Console.WriteLine("Одягаємо чоловіка в футболку розміру - {0}, кольору - {1} за ціною - {2} грн.", size, color, price);
    }

    public void DressWoman()
    {
        Console.WriteLine("Одягаємо жінку в футболку розміру - {0}, кольору - {1} за ціною - {2} грн.", size, color, price);
    }
}

class Pants : Clothing, IManClothes, IWomanClothes
{
    public Pants(string size, double price, string color) : base(size, price, color)
    {
    }

    public void DressMan()
    {
        Console.WriteLine("Одягаємо чоловіка в штани розміру - {0}, кольору - {1} за ціною - {2} грн.", size, color, price);
    }

    public void DressWoman()
    {
        Console.WriteLine("Одягаємо жінку в штани розміру - {0}, кольору - {1} за ціною - {2} грн.", size, color, price);
    }
}

class Skirt : Clothing, IWomanClothes
{
    public Skirt(string size, double price, string color) : base(size, price, color)
    {
    }

    public void DressWoman()
    {
        Console.WriteLine("Одягаємо жінку в спідницю розміру - {0}, кольору - {1} за ціною - {2} грн.", size, color, price);
    }
}

class Tie : Clothing, IManClothes
{
    public Tie(string size, double price, string color) : base(size, price, color)
    {
    }

    public void DressMan()
    {
        Console.WriteLine("Одягаємо чоловіка в краватку розміру - {0}, кольору - {1} за ціною - {2} грн.", size, color, price);
    }
}

class Shop
{
    private string[] sizes = { "XXS", "XS", "S", "M", "L" };
    private int[] euroSizes = { 32, 34, 36, 38, 40 };
    public string GetSizeDescription(string size)
    {
        if (size == "XXS")
        {
            return "Дитячий розмір";
        }
        else
        {
            return "Дорослий розмір";
        }
    }

    public int GetEuroSize(string size)
    {
        int index = Array.IndexOf(sizes, size);
        return euroSizes[index];
    }

    public void DressMan(IManClothes[] clothes)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8; // на всякий випадок
        Console.WriteLine("Одягаємо чоловіка:");
        foreach (var item in clothes)
        {
            item.DressMan();
        }
    }

    public void DressWoman(IWomanClothes[] clothes)
    {
        Console.WriteLine("Одягаємо жінку:");
        foreach (var item in clothes)
        {
            item.DressWoman();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();
        Clothing[] clothes = new Clothing[]
        {
            new TShirt("M", 200.0, "білий"),
            new Pants("S", 300.0, "сірий"),
            new Skirt("XS", 250.0, "рожевий"),
            new Tie("L", 100.0, "чорний")
        };
        IManClothes[] manClothes = Array.FindAll(clothes, item => item is IManClothes).Cast<IManClothes>().ToArray();
        IWomanClothes[] womanClothes = Array.FindAll(clothes, item => item is IWomanClothes).Cast<IWomanClothes>().ToArray();

        shop.DressMan(manClothes);
        Console.WriteLine();
        shop.DressWoman(womanClothes);

        Console.ReadLine();
    }
}