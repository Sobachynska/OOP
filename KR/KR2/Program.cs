using System;
using System.Text;

interface ITree
{
    void DisplayType();
    void DisplayName();
    int CrownHeight { get; set; }
    string Name { get; set; }
}

class Bush : ITree
{
    public void DisplayType()
    {
        Console.WriteLine("Це кущ.");
    }

    public void DisplayName()
    {
        Console.WriteLine("Назва куща: " + Name);
    }

    public int CrownHeight { get; set; }
    public string Name { get; set; }
}

class Tree : ITree
{
    public void DisplayType()
    {
        Console.WriteLine("Це дерево.");
    }

    public void DisplayName()
    {
        Console.WriteLine("Назва дерева: " + Name);
    }

    public int CrownHeight { get; set; }
    public string Name { get; set; }
}

class Grass : ITree
{
    public void DisplayType()
    {
        Console.WriteLine("Це трава.");
    }

    public void DisplayName()
    {
        Console.WriteLine("Назва трави: " + Name);
    }

    public int CrownHeight { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.WriteLine("Спочатку вводьте 3 кущі, потім 3 дерева, потім 3 трав'яних рослини");
        Bush bush1 = new Bush();
        Bush bush2 = new Bush();
        Bush bush3 = new Bush();

        Tree tree1 = new Tree();
        Tree tree2 = new Tree();
        Tree tree3 = new Tree();

        Grass grass1 = new Grass();
        Grass grass2 = new Grass();
        Grass grass3 = new Grass();

        ITree[] trees = new ITree[] { bush1, bush2, bush3, tree1, tree2, tree3, grass1, grass2, grass3 };

        EnterNamesAndCrownHeights(trees); // Вводимо назви та висоти крон

        ExecuteMethods(trees);
    }

    static void EnterNamesAndCrownHeights(ITree[] trees)
    {
        foreach (var tree in trees)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.Write("Введіть назву для рослини: ");
            string name = Console.ReadLine();
            Console.Write("Введіть висоту крони для рослини " + name + ": ");
            int crownHeight = Convert.ToInt32(Console.ReadLine());

            tree.Name = name;
            tree.CrownHeight = crownHeight;
        }
    }

    static void ExecuteMethods(ITree[] trees)
    {
        foreach (var tree in trees)
        {
            tree.DisplayType();
            tree.DisplayName();
            Console.WriteLine("Висота крони: " + tree.CrownHeight);
            Console.WriteLine();
        }
    }
}
