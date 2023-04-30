using System;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }


    public int CalculateAge()
    {
        return DateTime.Now.Year - PublicationYear;
    }

    public int CalculateDaysSincePublication()
    {
        DateTime publicationDate = new DateTime(PublicationYear, 1, 1);
        return (DateTime.Now - publicationDate).Days;
    }

    public virtual string GetObjectInfo()
    {
        return $"Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}";
    }
}

class Bookstore : Book
{
    public double Price { get; set; }

    public Bookstore(string title, string author, int publicationYear, double price)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        Price = price;
    }

    public void DecreasePriceIfOlderThanFiveYears()
    {
        if (CalculateAge() > 5)
        {
            Price *= 0.8;
        }
    }

    public new string GetObjectInfo()
    {
        return base.GetObjectInfo() + $", Price: {Price}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book { Title = "ЖИТТЯ МАРIЇ", Author = "СЕРГIЙ ЖАДАН", PublicationYear = 2015 };
        Console.WriteLine("Book info: " + book.GetObjectInfo());
        Console.WriteLine("Book age: " + book.CalculateAge());
        Console.WriteLine("Days since publication: " + book.CalculateDaysSincePublication());

        Bookstore bookstore = new Bookstore("ЖИТТЯ МАРIЇ", "СЕРГIЙ ЖАДАН", 2015, 240.0);
        Console.WriteLine("Bookstore info: " + bookstore.GetObjectInfo());
        bookstore.DecreasePriceIfOlderThanFiveYears();
        Console.WriteLine("Bookstore info after price decrease: " + bookstore.GetObjectInfo());
    }
}