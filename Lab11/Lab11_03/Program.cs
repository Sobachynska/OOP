using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // Введіть рядок з трьома датами, розділеними комою
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введіть рядок з трьома датами у форматі dd/MM/yyyy, dd/MM/yyyy, dd/MM/yyyy: ");
        string input = Console.ReadLine();

        // Розділяємо рядок на окремі дати
        string[] dates = input.Split(',');

        // Обробляємо кожну дату
        int minYear = int.MaxValue;
        DateTime latestDate = DateTime.MinValue;
        foreach (string dateStr in dates)
        {
            // Парсимо рядок у дату
            DateTime date;
            if (DateTime.TryParseExact(dateStr.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                // Знаходимо рік з найменшим номером
                if (date.Year < minYear)
                {
                    minYear = date.Year;
                }

                // Знаходимо всі весняні дати
                if (date.Month >= 3 && date.Month <= 5)
                {
                    Console.WriteLine("{0:d}", date);
                }

                // Знаходимо саму пізнішу дату
                if (date > latestDate)
                {
                    latestDate = date;
                }
            }
            else
            {
                Console.WriteLine("Помилка: Неправильний формат дати - {0}", dateStr);
            }
        }

        // Виводимо результати
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Рік з найменшим номером: {0}", minYear);
        Console.WriteLine("Сама пізніша дата: {0:d}", latestDate);

        Console.ReadLine();
    }
}
