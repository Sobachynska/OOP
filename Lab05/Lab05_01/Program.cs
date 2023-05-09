// Опис інтерфейсу IFigure
interface IFigure
{
    void PrintType();
    void PrintArea(); 
    double Length { get; } 
    double Width { get; } 
    void PrintDiagonal(); 
}

interface IColoredFigure : IFigure
{
    string Color { get; }
    void PrintColor();
}
e
class Rectangle : IFigure
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public void PrintType()
    {
        Console.WriteLine("Type: Rectangle");
    }

    public void PrintArea()
    {
        Console.WriteLine($"Area: {Length * Width}");
    }

    public void PrintDiagonal()
    {
        Console.WriteLine($"Diagonal: {Math.Sqrt(Length * Length + Width * Width)}");
    }
}

class ColoredRectangle : Rectangle, IColoredFigure
{
    public string Color { get; set; }

    public ColoredRectangle(double length, double width, string color) : base(length, width)
    {
        Color = color;
    }

    public void PrintColor()
    {
        Console.WriteLine($"Color: {Color}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо екземпляри класів Rectangle та ColoredRectangle
        Rectangle rect1 = new Rectangle(25, 13);
        Rectangle rect2 = new Rectangle(12, 9);
        Rectangle rect3 = new Rectangle(18, 10);

        ColoredRectangle colRect1 = new ColoredRectangle(20, 16, "black");
        ColoredRectangle colRect2 = new ColoredRectangle(8, 5, "blue");
        ColoredRectangle colRect3 = new ColoredRectangle(14, 7, "pink");

        IFigure[] figures = new IFigure[] { rect1, rect2, rect3, colRect1, colRect2, colRect3 };

        foreach (IFigure figure in figures)
        {
            if (figure is IColoredFigure)
            {
                IColoredFigure colFigure = (IColoredFigure)figure;
                Console.WriteLine();
                colFigure.PrintType();
                colFigure.PrintArea();
                colFigure.PrintDiagonal();
                colFigure.PrintColor();
            }
        }
    }
}