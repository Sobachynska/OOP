using System;

class Bank
{
    public string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
    }
}

class Branch
{
    public string Name { get; set; }
    public decimal TotalDepositAmount { get; set; }

    public Branch(string name)
    {
        Name = name;
    }
}

class Deposit
{
    public string DepositorName { get; set; }
    public decimal Amount { get; set; }

    public virtual decimal CalculateDepositAmount(int months)
    {
        return Amount * months;
    }
}

class LongTermDeposit : Deposit
{
    public override decimal CalculateDepositAmount(int months)
    {
        try
        {
            if (months <= 0)
            {
                throw new KilkistException("Кількість місяців має бути більшою за 0.");
            }

            decimal interestRate = 0.1M; // 10% річних
            decimal totalAmount = Amount;
            for (int i = 1; i <= months; i++)
            {
                totalAmount += totalAmount * interestRate / 12;
            }
            return totalAmount - Amount;
        }
        catch (KilkistException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            return 0;
        }
    }
}

class DemandDeposit : Deposit
{
    public override decimal CalculateDepositAmount(int months)
    {
        try
        {
            if (months <= 0)
            {
                throw new KilkistException("Кількість місяців має бути більшою за 0.");
            }

            decimal interestRate = 0.05M; // 5% per annum
            return Amount * months * interestRate / 12;
        }
        catch (KilkistException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            return 0;
        }
    }
}

class KilkistException : Exception
{
    public KilkistException(string message) : base(message)
    {
    }
}

class VkladException : Exception
{
    public VkladException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Приклад виклику конструктора класу Вклад
            Deposit deposit = new Deposit();
            deposit.DepositorName = "Собачинська Анна";
            deposit.Amount = -1000; // негативне значення

            if (deposit.Amount < 0)
            {
                throw new VkladException($"Неможливо створити вклад - вказана негативна сума вкладу: {deposit.Amount}");
            }
        }
        catch (VkladException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            // повторний виклик конструктора класу Вклад з позитивним значенням
        }
    }
}