using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task2
    {
            abstract class Shape
        {
            public abstract double Area();
            public abstract double Perimeter();
            public abstract string Name { get; }
        }

        class Round : Shape
        {
            private double radius;

            public Round(double radius)
            {
                this.radius = radius;
            }

            public override double Area()
            {
                return Math.PI * radius * radius;
            }

            public override double Perimeter()
            {
                return 2 * Math.PI * radius;
            }

            public override string Name => "Круг";
        }

        class Square : Shape
        {
            private double side;

            public Square(double side)
            {
                this.side = side;
            }

            public override double Area()
            {
                return side * side;
            }

            public override double Perimeter()
            {
                return 4 * side;
            }

            public override string Name => "Квадрат";
        }

        class Triangle : Shape
        {
            private double[] sides;

            public Triangle(double[] sides)
            {
                if (sides.Length != 3)
                {
                    throw new ArgumentException("Массив должен содержать ровно 3 элемента.");
                }
                this.sides = (double[])sides.Clone();
                Array.Sort(this.sides);
            }

            public override double Area()
            {
                double p = (sides[0] + sides[1] + sides[2]) / 2;
                return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
            }

            public override double Perimeter()
            {
                return sides[0] + sides[1] + sides[2];
            }

            public override string Name => "Треугольник";
        }

        class Program
        {
            static void Main()
            {
                Shape[] shapes = new Shape[]
                {
            new Round(5),
            new Round(3),
            new Square(4),
            new Square(6),
            new Triangle(new double[] { 3, 4, 5 }),
            new Triangle(new double[] { 5, 5, 8 }),
            new Round(2),
            new Square(5),
            new Triangle(new double[] { 7, 8, 9 }),
            new Triangle(new double[] { 6, 6, 6 })
                };
                Array.Sort(shapes, (s1, s2) => s2.Area().CompareTo(s1.Area()));
                Console.WriteLine($"{"Название",-15}{"Периметр",-15}{"Площадь",-15}");
                Console.WriteLine(new string('=', 45));

                foreach (var shape in shapes)
                {
                    Console.WriteLine($"{shape.Name,-15}{shape.Perimeter(),-15:F2}{shape.Area(),-15:F2}");
                }
            }
        }
    }
}
