using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Введіть дату, до якої потрібно порахувати дні
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.Write("Введіть дату у форматі dd/mm/yyyy: ");
        DateTime targetDate = DateTime.Parse(Console.ReadLine());

        // Обчислюємо кількість днів до цієї дати
        TimeSpan timeRemaining = targetDate - DateTime.Now;
        int daysRemaining = (int)Math.Ceiling(timeRemaining.TotalDays);

        // Виводимо результат
        if (daysRemaining > 0)
        {
            Console.WriteLine("До вказаної дати залишилось {0} днів.", daysRemaining);
        }
        else
        {
            Console.WriteLine("Вказана дата вже минула.");
        }

        Console.ReadLine();
    }
}