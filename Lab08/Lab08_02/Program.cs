using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        // Ввід раціонального значення змінної
        Console.Write("Введіть значення x: ");
        double x = double.Parse(Console.ReadLine());

        Console.OutputEncoding = UTF8Encoding.UTF8;
        // Ввід коефіцієнтів многочлена з файлу
        Console.Write("Введіть ім'я файлу з коефіцієнтами: ");
        string fileName = Console.ReadLine();

        string[] lines = File.ReadAllLines(fileName);
        int n = lines.Length;
        int[] numerators = new int[n / 2];
        int[] denominators = new int[n / 2];

        for (int i = 0; i < n / 2; i++)
        {
            string[] parts = lines[i].Split('/');
            numerators[i] = int.Parse(parts[0]);
            denominators[i] = int.Parse(parts[1]);
        }

        // Обчислення значення многочлена
        double result = (double)numerators[n / 2 - 1] / denominators[n / 2 - 1];

        for (int i = n / 2 - 2; i >= 0; i--)
        {
            result = result * x + (double)numerators[i] / denominators[i];
        }

        // Вивід результату
        Console.WriteLine("Значення многочлена: " + result);
    }
}