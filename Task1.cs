using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task1
    {
            class Triangle
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

            public string TypeOfTriangle()
            {
                if (sides[0] == sides[1] && sides[1] == sides[2])
                {
                    return "Равносторонний";
                }
                else if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
                {
                    return "Равнобедренный";
                }
                else
                {
                    return "Разносторонний";
                }
            }

            public double Area()
            {
                double p = (sides[0] + sides[1] + sides[2]) / 2;
                return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
            }

            public string Info()
            {
                return $"Стороны: {string.Join(", ", sides)}, Площадь: {Area():F2}, Тип: {TypeOfTriangle()}";
            }

            public double GetArea()
            {
                return Area();
            }
        }


        class Program
        {
            static void Main()
            {
                Triangle[] triangles = new Triangle[]
                {
            new Triangle(new double[] { 3, 4, 5 }),
            new Triangle(new double[] { 6, 6, 6 }),
            new Triangle(new double[] { 5, 5, 8 }),
            new Triangle(new double[] { 7, 8, 9 }),
            new Triangle(new double[] { 10, 10, 10 })
                };
                Array.Sort(triangles, (t1, t2) => t2.GetArea().CompareTo(t1.GetArea()));
                Console.WriteLine($"{"Стороны",-20}{"Площадь",-15}{"Тип",-20}");
                Console.WriteLine(new string('=', 55));

                foreach (var triangle in triangles)
                {
                    Console.WriteLine(triangle.Info());
                }
            }
        }

       }
    }

