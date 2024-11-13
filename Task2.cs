using System;

namespace BBI_reexam_2
{
    internal class Task2
    {
        public Task2()
        {

        }
            

class Number
        {
            public int RealPart { get; }

            public Number(int realPart)
            {
                RealPart = realPart;
            }

            public virtual void Print()
            {
                Console.WriteLine($"Number = {RealPart}");
            }
        }

        class ComplexNumber : Number
        {
            public int ImaginaryPart { get; }

            public ComplexNumber(int realPart, int imaginaryPart) : base(realPart)
            {
                ImaginaryPart = imaginaryPart;
            }

            public static ComplexNumber Add(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(a.RealPart + b.RealPart, a.ImaginaryPart + b.ImaginaryPart);
            }

            public static ComplexNumber Subtract(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(a.RealPart - b.RealPart, a.ImaginaryPart - b.ImaginaryPart);
            }

            public static ComplexNumber Multiply(ComplexNumber a, ComplexNumber b)
            {
                int real = a.RealPart * b.RealPart - a.ImaginaryPart * b.ImaginaryPart;
                int imaginary = a.RealPart * b.ImaginaryPart + a.ImaginaryPart * b.RealPart;
                return new ComplexNumber(real, imaginary);
            }

            public static ComplexNumber Divide(ComplexNumber a, ComplexNumber b)
            {
                if (b.RealPart == 0 && b.ImaginaryPart == 0)
                {
                    throw new DivideByZeroException("Деление на ноль невозможно.");
                }

                int real = (a.RealPart * b.RealPart + a.ImaginaryPart * b.ImaginaryPart) /
                           (b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart);
                int imaginary = (a.ImaginaryPart * b.RealPart - a.RealPart * b.ImaginaryPart) /
                                (b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart);

                return new ComplexNumber(real, imaginary);
            }

            public override void Print()
            {
                Console.WriteLine($"ComplexNumber = {RealPart} + {ImaginaryPart}i");
            }
        }

        class Program
        {
            private static void Main(string[] args)
            {
                
                ComplexNumber num1 = new ComplexNumber(3, 2); 
                ComplexNumber num2 = new ComplexNumber(1, 7); 

               
                ComplexNumber sum = ComplexNumber.Add(num1, num2);
                ComplexNumber difference = ComplexNumber.Subtract(num1, num2);
                ComplexNumber product = ComplexNumber.Multiply(num1, num2);
                ComplexNumber quotient = ComplexNumber.Divide(num1, num2);

               
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

