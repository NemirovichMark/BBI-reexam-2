using System;

namespace BBI_reexam_2
{
    internal class Task1
    {
        public Task1()
        { }

        readonly struct Number
        {
            public int RealPart { get; }

            public Number(int realPart)
            {
                RealPart = realPart;
            }

            public static Number Add(Number a, Number b)
            {
                return new Number(a.RealPart + b.RealPart);
            }

            public static Number Subtract(Number a, Number b)
            {
                return new Number(a.RealPart - b.RealPart);
            }

            public static Number Multiply(Number a, Number b)
            {
                return new Number(a.RealPart * b.RealPart);
            }

            public static Number Divide(Number a, Number b)
            {
                if (b.RealPart == 0)
                {
                    throw new DivideByZeroException("Деление на ноль невозможно.");
                }
                return new Number(a.RealPart / b.RealPart);
            }

            public void Print()
            {
                Console.WriteLine($"Number = {RealPart}");
            }
        }

        class Program
        {
            private static void Main(string[] args)
            {
                Number num1 = new Number(10);
                Number num2 = new Number(5);
                Number sum = Number.Add(num1, num2);
                Number difference = Number.Subtract(num1, num2);
                Number product = Number.Multiply(num1, num2);
                Number quotient = Number.Divide(num1, num2);
                num1.Print();
                num2.Print();
                sum.Print();
                difference.Print();
                product.Print();
                quotient.Print();
            }
        }
    }
}