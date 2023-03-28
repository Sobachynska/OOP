using System;

class Company
{
    private static int objectCount = 0;
    private string name;
    private int productCount;
    private decimal annualSales;
    private decimal marketShare;

    public Company(string name, int productCount, decimal annualSales, decimal marketShare)
    {
        this.name = name;
        this.productCount = productCount;
        this.annualSales = annualSales;
        this.marketShare = marketShare;
        objectCount++;
    }

    public static int ObjectCount
    {
        get { return objectCount; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int ProductCount
    {
        get { return productCount; }
        set { productCount = value; }
    }

    public decimal AnnualSales
    {
        get { return annualSales; }
        set { annualSales = value; }
    }

    public decimal MarketShare
    {
        get { return marketShare; }
        set { marketShare = value; }
    }

    public static Company[] FindByMarketShare(decimal threshold)
    {
        int count = 0;
        foreach (Company company in companies)
        {
            if (company.MarketShare > threshold)
            {
                count++;
            }
        }

        Company[] result = new Company[count];
        int i = 0;
        foreach (Company company in companies)
        {
            if (company.MarketShare > threshold)
            {
                result[i] = company;
                i++;
            }
        }

        return result;
    }

    public static Company FindByMinProductCount()
    {
        Company result = null;
        int minProductCount = int.MaxValue;
        foreach (Company company in companies)
        {
            if (company.ProductCount < minProductCount)
            {
                minProductCount = company.ProductCount;
                result = company;
            }
        }

        return result;
    }

    public static void CheckObjectCount(int limit1, int limit2)
    {
        if (objectCount > limit1)
        {
            Console.WriteLine("The number of objects ({0}) exceeds the limit ({1}).", objectCount, limit1);
        }
        else if (objectCount < limit2)
        {
            Console.WriteLine("The number of objects ({0}) is less than the limit ({1}).", objectCount, limit2);
        }
    }

    private static Company[] companies = new Company[] {
        new Company("Oracle", 1, 2500000000m, 31.01m),
        new Company("IBM", 3, 2400000000m, 29.25m),
        new Company("Microsoft", 2, 1000000000m, 13.01m),
        new Company("Apple", 2, 2400000000m, 30.23m),
        new Company("Amazon", 2, 3300000000m, 40.34m),
        new Company("Square", 1, 1000000000m, 10.50m),
        new Company("Tencent", 2, 2000000000m, 23.54m),
        new Company("HBO", 1, 2300000000m, 12.43m),
        new Company("Tesla Motors", 2, 1200000000m, 23.54m),
        new Company("Jawbone", 3, 2300000000m, 14.43m)
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Total number of objects: {0}", Company.ObjectCount);
        Console.WriteLine();

        // Finding companies with market share above 30%
        Console.WriteLine("Companies with market share above 30%:");
        Company[] highMarketShareCompanies = Company.FindByMarketShare(30m);
        foreach (Company company in highMarketShareCompanies)
        {
            Console.WriteLine(company.Name);
        }
        Console.WriteLine();

        // Finding the company with the minimum number of products
        Console.WriteLine("Company with the minimum number of products:");
        Company minProductCountCompany = Company.FindByMinProductCount();
        Console.WriteLine(minProductCountCompany.Name);
        Console.WriteLine();

        // Checking the number of objects
        Company.CheckObjectCount(15, 10);

        Console.ReadLine();
    }
}