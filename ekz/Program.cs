using System;
using System.Text;

public interface ILamp
{
    string Type { get; set; }
    string Manufacturer { get; set; }
    int Power { get; set; }
    string LightType { get; set; }
    int NumberOfElements { get; set; }

    void PrintInfo();
    void ChangePower(int newPower);
}

public interface ICamera
{
    string Type { get; set; }
    string Manufacturer { get; set; }
    int OpticalSensitivity { get; set; }

    void PrintInfo();
    void ChangeSensitivity(int newSensitivity);
}

public class PhotoStudio : ILamp, ICamera
{
    public string Type { get; set; }
    public string Manufacturer { get; set; }
    public int Power { get; set; }
    public string LightType { get; set; }
    public int NumberOfElements { get; set; }
    public int OpticalSensitivity { get; set; }

    public void PrintInfo()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Інформація про лампу:");
        Console.WriteLine($"Тип: {Type}");
        Console.WriteLine($"Виробник: {Manufacturer}");
        Console.WriteLine($"Потужність: {Power} люменів");
        Console.WriteLine($"Тип світла: {LightType}");
        Console.WriteLine($"Кількість елементів: {NumberOfElements}");

        Console.WriteLine();

        Console.WriteLine("Інформація про камеру:");
        Console.WriteLine($"Тип: {Type}");
        Console.WriteLine($"Виробник: {Manufacturer}");
        Console.WriteLine($"Оптична чутливість: {OpticalSensitivity}");
    }

    public void ChangePower(int newPower)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Power = newPower;
        Console.WriteLine($"Потужність лампи змінено на: {Power} люменів");
    }

    public void ChangeSensitivity(int newSensitivity)
    {
        Console.OutputEncoding = Encoding.UTF8;
        OpticalSensitivity = newSensitivity;
        Console.WriteLine($"Оптичну чутливість камери змінено на: {OpticalSensitivity}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        PhotoStudio studio1 = new PhotoStudio()
        {
            Type = "Студійна лампа",
            Manufacturer = "RZTK",
            Power = 1000,
            LightType = "Світлодіодна",
            NumberOfElements = 5,
            OpticalSensitivity = 200
        };

        PhotoStudio studio2 = new PhotoStudio()
        {
            Type = "Портативна лампа",
            Manufacturer = "Rozetka",
            Power = 500,
            LightType = "Люмінесцентний",
            NumberOfElements = 3,
            OpticalSensitivity = 300
        };

        studio1.PrintInfo();
        Console.WriteLine();
        studio2.PrintInfo();
        Console.WriteLine();

        studio1.ChangeSensitivity(400);
        Console.WriteLine();

        studio1.PrintInfo();
    }
}
