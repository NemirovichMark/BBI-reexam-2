using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task2
    {
        public Task2()
        {

        }
    }
}

abstract class Animal
{
    public string Name { get; set; }
    public string DietType { get; set; }

    public abstract string MakeSound();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Название: {Name}, Тип питания: {DietType}, Звук: {MakeSound()}");
    }
}

abstract class Herbivorous : Animal
{
    public Herbivorous()
    {
        DietType = "Травоядное";
    }
}

abstract class Carnivorous : Animal
{
    public Carnivorous()
    {
        DietType = "Хищное";
    }
}

abstract class Omnivorous : Animal
{
    public Omnivorous()
    {
        DietType = "Всеядное";
    }
}

class Giraffe : Herbivorous
{
    public Giraffe()
    {
        Name = "Жираф";
    }

    public override string MakeSound()
    {
        return "Грррр";
    }
}

class Elephant : Herbivorous
{
    public Elephant()
    {
        Name = "Слон";
    }

    public override string MakeSound()
    {
        return "Трубящий звук";
    }
}

class Lion : Carnivorous
{
    public Lion()
    {
        Name = "Лев";
    }

    public override string MakeSound()
    {
        return "Ррррр";
    }
}

class Tiger : Carnivorous
{
    public Tiger()
    {
        Name = "Тигр";
    }

    public override string MakeSound()
    {
        return "Ррррр";
    }
}

class Pig : Omnivorous
{
    public Pig()
    {
        Name = "Свинья";
    }

    public override string MakeSound()
    {
        return "Хрю";
    }
}

class Monkey : Omnivorous
{
    public Monkey()
    {
        Name = "Обезьяна";
    }

    public override string MakeSound()
    {
        return "У-у-у";
    }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[]
        {
            new Giraffe(),
            new Elephant(),
            new Giraffe(),
            new Lion(),
            new Tiger(),
            new Lion(),
            new Pig(),
            new Monkey(),
            new Pig()
        };

        Console.WriteLine("Травоядные животные:");
        foreach (var animal in animals)
        {
            if (animal is Herbivorous)
                animal.DisplayInfo();
        }

        Console.WriteLine("\nХищные животные:");
        foreach (var animal in animals)
        {
            if (animal is Carnivorous)
                animal.DisplayInfo();
        }

        Console.WriteLine("\nВсеядные животные:");
        foreach (var animal in animals)
        {
            if (animal is Omnivorous)
                animal.DisplayInfo();
        }
    }
}
