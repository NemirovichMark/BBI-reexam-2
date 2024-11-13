using System;

struct Goods
{
    public string Name;
    public string ArticleNumber;
    public decimal Price;
    public int Quantity;

    public Goods(string name, string articleNumber, decimal price, int quantity)
    {
        Name = name;
        ArticleNumber = articleNumber;
        Price = price;
        Quantity = quantity;
    }

    public void Display()
    {
        Console.WriteLine($"| {Name,-20} | {ArticleNumber,-10} | {Price,10:C} | {Quantity,5} |");
    }
}

class Program
{
    static void Main()
    {
        Goods[] goodsArray = {
            new Goods("Laptop", "A123", 999.99m, 5),
            new Goods("Monitor", "B456", 199.99m, 10),
            new Goods("Keyboard", "C789", 49.99m, 20),
            new Goods("Mouse", "D012", 19.99m, 50),
            new Goods("Printer", "E345", 149.99m, 7)
        };

  
        for (int i = 0; i < goodsArray.Length - 1; i++)
        {
            for (int j = 0; j < goodsArray.Length - i - 1; j++)
            {
                if (goodsArray[j].Price > goodsArray[j + 1].Price)
                {
                    var temp = goodsArray[j];
                    goodsArray[j] = goodsArray[j + 1];
                    goodsArray[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("| Name                 | Article    | Price      | Qty   |");
        Console.WriteLine(new string('-', 52));
        foreach (var goods in goodsArray)
        {
            goods.Display();
        }
    }
}