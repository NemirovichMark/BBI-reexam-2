using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task1
    {
        public Task1() 
        { 

        }
    }
}
public struct Disciple
{
    public string FirstName;
    public string LastName;
    public int Age;
    public int[] Grades;
    public double AverageGrade;
    public bool IsRedDiplom;

    public Disciple(string firstName, string lastName, int age, int[,] gradesMatrix)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Grades = new int[gradesMatrix.GetLength(0) * gradesMatrix.GetLength(1)];
        int index = 0;
        for (int i = 0; i < gradesMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < gradesMatrix.GetLength(1); j++)
            {
                Grades[index++] = gradesMatrix[i, j];
            }
        }
        AverageGrade = Grades.Average();
        IsRedDiplom = AverageGrade > 4.5;
    }

    public void PrintGrades()
    {
        Console.WriteLine($"Оценки для {FirstName} {LastName}: {string.Join(", ", Grades)}");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Имя: {FirstName} {LastName}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Средний балл: {AverageGrade:F2}");
        Console.WriteLine($"Красный диплом: {(IsRedDiplom ? "Да" : "Нет")}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Disciple[] disciples = new Disciple[]
        {
            new Disciple("Иван", "Петров", 20, new int[,] { { 4, 5, 5 }, { 5, 5, 5 } }),
            new Disciple("Анна", "Смирнова", 22, new int[,] { { 5, 5, 5 }, { 5, 4, 5 } }),
            new Disciple("Петр", "Иванов", 21, new int[,] { { 4, 4, 5 }, { 5, 4, 5 } }),
            new Disciple("Мария", "Кузнецова", 23, new int[,] { { 5, 5, 5 }, { 5, 5, 4 } }),
            new Disciple("Дмитрий", "Сергеев", 24, new int[,] { { 3, 4, 5 }, { 4, 3, 4 } })
        };

        var sortedDisciples = disciples.OrderBy(d => d.LastName).ToArray();

        Console.WriteLine("Таблица учеников:");
        Console.WriteLine("Фамилия    Имя    Возраст  Средний балл  Красный диплом");
        Console.WriteLine("------------------------------------------------------------");

        foreach (var disciple in sortedDisciples)
        {
            Console.WriteLine($"{disciple.LastName,-10} {disciple.FirstName,-6} {disciple.Age,-8} {disciple.AverageGrade,-12:F2} {((disciple.IsRedDiplom) ? "Есть" : "Отсутсвует")}");
        }

        Console.WriteLine();

        foreach (var disciple in sortedDisciples)
        {
            disciple.PrintInfo();
        }
    }
}
