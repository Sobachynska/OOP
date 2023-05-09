interface IFigure
{
    void PrintType(); // метод, що виводить на екран тип фігури
    void PrintArea(); // метод, що виводить на екран площу фігури
    double Length { get; } // властивість, що відповідає за перший лінійний розмір фігури 
    double Width { get; } // властивість, що відповідає за другий лінійний розмір фігури
    void PrintDiagonal(); // метод, що виводить на екран довжину діагоналі фігури
}

interface IColoredFigure : IFigure
{
    string Color { get; }
    void PrintColor();
}

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
        Rectangle rect1 = new Rectangle(15, 8);
        Rectangle rect2 = new Rectangle(10, 6);
        Rectangle rect3 = new Rectangle(16, 6);

        ColoredRectangle colRect1 = new ColoredRectangle(22, 9, "black");
        ColoredRectangle colRect2 = new ColoredRectangle(9, 4, "blue");
        ColoredRectangle colRect3 = new ColoredRectangle(10, 6, "pink");

        IFigure[] figures = new IFigure[] { rect1, rect2, rect3, colRect1, colRect2, colRect3 };

        foreach (IFigure figure in figures)
        {
            if (figure is IColoredFigure)
            {
                IColoredFigure colFigure = (IColoredFigure)figure;
                Console.WriteLine("");
                colFigure.PrintType();
                colFigure.PrintArea();
                colFigure.PrintDiagonal();
                colFigure.PrintColor();
            }
        }
    }
}