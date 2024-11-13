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
abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public abstract double GetAverageGrade();
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Pupil : Person
{
    public string Class { get; set; }
    public string Specialization { get; set; }
    public int[,] Grades { get; set; }
    public Pupil(string name, int age, string className, string specialization, int[,] grades)
    {
        Name = name;
        Age = age;
        Class = className;
        Specialization = specialization;
        Grades = grades;
    }
    public override double GetAverageGrade()
    {
        double sum = 0;
        int count = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
            count++;
        }
        return sum / count;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Class: {Class}, Specialization: {Specialization}");
    }
}

class Student : Person
{
    public string Group { get; set; }
    public bool IsDebtor { get; private set; }
    public string StudentId { get; set; }
    public int[,] Grades { get; set; }
    public Student(string name, int age, string group, string studentId, int[,] grades)
    {
        Name = name;
        Age = age;
        Group = group;
        StudentId = studentId;
        Grades = grades;
        IsDebtor = CalculateDebtorStatus();
    }
    private bool CalculateDebtorStatus()
    {
        return Grades.Cast<int>().Any(grade => grade == 2);
    }
    public override double GetAverageGrade()
    {
        double sum = 0;
        int count = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
            count++;
        }
        return sum / count;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Group: {Group}, Student ID: {StudentId}, Is Debtor: {IsDebtor}");
    }
}

class Programm
{
    static void Main(string[] args)
    {
        var pupils = new Pupil[]
        {
            new Pupil("Иван Смачный", 16, "10A", "Математика", new int[,] { { 5, 4, 5, 4, 5 }, { 4, 5, 5, 5, 4 }, { 5, 5, 5, 5, 5 } }),
            new Pupil("Светлана Петрова", 15, "9B", "Физика", new int[,] { { 3, 4, 5, 4, 5 }, { 4, 5, 3, 4, 5 }, { 5, 5, 4, 5, 4 } }),
            new Pupil("Алексей Сидоров", 17, "11C", "Химия", new int[,] { { 5, 5, 4, 5, 4 }, { 5, 5, 5, 5, 5 }, { 5, 4, 5, 5, 5 } })
        };
        var students = new Student[]
        {
            new Student("Дмитрий Смирнов", 19, "ХИМ101", "123456", new int[,] { { 5, 5, 5, 5, 5 }, { 5, 5, 5, 5, 5 } }),
            new Student("Ольга Кузнецова", 21, "МАТ202", "789101", new int[,] { { 5, 4, 3, 4, 5 }, { 2, 5, 5, 4, 5 } }),
            new Student("Михаил Фролов", 20, "БИО103", "112233", new int[,] { { 5, 5, 5, 5, 5 }, { 5, 5, 5, 5, 5 } })
        };

        var allPeople = pupils.Cast<Person>().Concat(students.Cast<Person>()).ToArray();
        Console.WriteLine("Pupils по средней оценке:");
        var sortedPupils = pupils.OrderByDescending(p => p.GetAverageGrade()).ToArray();
        foreach (var pupil in sortedPupils)
        {
            pupil.PrintInfo();
            Console.WriteLine($"Средняя оценка: {pupil.GetAverageGrade():F2}\n");
        }
        Console.WriteLine("Students по средней оценке :");
        var sortedStudents = students.OrderByDescending(s => s.GetAverageGrade()).ToArray();
        foreach (var student in sortedStudents)
        {
            student.PrintInfo();
            Console.WriteLine($"Средняя оценка: {student.GetAverageGrade():F2}\n");
        }

        Console.WriteLine("Краснодипломники:");
        var redDiplomHolders = allPeople
            .Where(p => p.GetAverageGrade() >= 4.5)
            .ToArray();

        foreach (var person in redDiplomHolders)
        {
            person.PrintInfo();
            Console.WriteLine($"Средняя оценка: {person.GetAverageGrade():F2}\n");
        }
    }
}
