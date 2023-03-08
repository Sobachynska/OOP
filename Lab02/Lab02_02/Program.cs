using System;

class Company
{
    private static int objectCount = 0;

    public string Name { get; set; }
    public int NumProducts { get; set; }
    public int SalesVolume { get; set; }
    public double MarketShare { get; set; }

    public Company(string name, int numProducts, int salesVolume, double marketShare)
    {
        Name = name;
        NumProducts = numProducts;
        SalesVolume = salesVolume;
        MarketShare = marketShare;
        objectCount++;
    }

    public static int ObjectCount
    {
        get { return objectCount; }
    }

    public static Company[] CreateCompanyArray()
    {
        Company[] companies = new Company[3];
        companies[0] = new Company("Oracle", 1, 2500000000, 31.01);
        companies[1] = new Company("IBM", 2, 2400000000, 29.25);
        companies[2] = new Company("Microsoft", 3, 100000000, 13.01);

        return companies;
    }

    public static Company[] FindCompanies(Func<Company, bool> predicate, Company[] companies)
    {
        Company[] matchingCompanies = new Company[companies.Length];
        int index = 0;

        foreach (Company company in companies)
        {
            if (predicate(company))
            {
                matchingCompanies[index] = company;
                index++;
            }
        }

        Array.Resize(ref matchingCompanies, index);
        return matchingCompanies;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Company[] companies = Company.CreateCompanyArray();

        // Find companies with more than 2 products
        Company[] companiesWithMoreThanTwoProducts = Company.FindCompanies(
            c => c.NumProducts > 2,
            companies);

        // Find company with smallest number of products
        Company smallestNumProductsCompany = companies[0];
        for (int i = 1; i < companies.Length; i++)
        {
            if (companies[i].NumProducts < smallestNumProductsCompany.NumProducts)
            {
                smallestNumProductsCompany = companies[i];
            }
        }

        Console.WriteLine("Number of objects: " + Company.ObjectCount);

        if (Company.ObjectCount > 2)
        {
            Console.WriteLine("Message 1");
        }
        else
        {
            Console.WriteLine("Message 2");
        }
    }
}