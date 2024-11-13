using System;
using System.Diagnostics;
using System.Xml.Linq;

abstract class Goods
{
    public string Name { get; set; }
    public string ArticleNumber { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Goods(string name, string articleNumber, decimal price, int quantity)
    {
        Name = name;
        ArticleNumber = articleNumber;
        Price = price;
        Quantity = quantity;
    }

    public abstract decimal CalculateCost();
    public abstract void Display();
}

class Product : Goods
{
    public int ShelfLife { get; set; } 
    public Product(string name, string articleNumber, decimal price, int quantity, int shelfLife)
        : base(name, articleNumber, price, quantity)
    {
        ShelfLife = shelfLife;
    }

    public override decimal CalculateCost() => Price * Quantity;
    public override void Display()
    {
        Console.WriteLine($"| {Name,-20} | {ArticleNumber,-10} | {Price,10:C} | {Quantity,5} | Shelf Life: {ShelfLife} days |");
    }
}

class Equipment : Goods
{
    public int WarrantyPeriod { get; set; } 

    public Equipment(string name, string articleNumber, decimal price, int quantity, int warrantyPeriod)
        : base(name, articleNumber, price, quantity)
    {
        WarrantyPeriod = warrantyPeriod;
    }

    public override decimal CalculateCost() => Price * Quantity;
    public override void Display()
    {
        Console.WriteLine($"| {Name,-20} | {ArticleNumber,-10} | {Price,10:C} | {Quantity,5} | Warranty: {WarrantyPeriod} months |");
    }
}

class Tool : Goods
{
    public string QualityClass { get; set; } 

    public Tool(string name, string articleNumber, decimal price, int quantity, string qualityClass)
        : base(name, articleNumber, price, quantity)
    {
        QualityClass = qualityClass;
    }

    public override decimal CalculateCost() => Price * Quantity;
    public override void Display()
    {
        Console.WriteLine($"| {Name,-20} | {ArticleNumber,-10} | {Price,10:C} | {Quantity,5} | Quality: {QualityClass} |");
    }
}

class Program
{
    static void Main()
    {
        Goods[] goodsArray = {
            new Product("Milk", "P001", 1.99m, 10, 7),
            new Equipment("Drill", "E002", 59.99m, 5, 24),
            new Tool("Hammer", "T003", 19.99m, 15, "A"),
            new Product("Bread", "P004", 0.99m, 20, 3),
            new Equipment("Printer", "E005", 149.99m, 2, 12)
        };

  
        for (int i = 0; i < goodsArray.Length - 1; i++)
        {
            for (int j = 0; j < goodsArray.Length - i - 1; j++)
            {
                if (goodsArray[j].CalculateCost() > goodsArray[j + 1].CalculateCost())
                {
                    var temp = goodsArray[j];
                    goodsArray[j] = goodsArray[j + 1];
                    goodsArray[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("| Name                 | Article    | Price      | Qty   | Additional Info                     |");
        Console.WriteLine(new string('-', 80));
        foreach (var goods in goodsArray)
        {
            goods.Display();
        }
    }
}