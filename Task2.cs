using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task2
    {
        public abstract class Shape
        {
            public abstract double Volume { get; }

            public abstract void DisplayInfo();
        }

        public class Sphere : Shape
        {
            private double radius;

            public Sphere(double radius)
            {
                this.radius = radius;
            }

            public override double Volume => (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

            public override void DisplayInfo()
            {
                Console.WriteLine($"Sphere with radius {radius}: Volume = {Volume:F2}");
            }
        }

        public class Cube : Shape
        {
            private double length;

            public Cube(double length)
            {
                this.length = length;
            }

            public override double Volume => Math.Pow(length, 3);

            public override void DisplayInfo()
            {
                Console.WriteLine($"Cube with length {length}: Volume = {Volume:F2}");
            }
        }

        public class Cylinder : Shape
        {
            private double radius;
            private double height;

            public Cylinder(double radius, double height)
            {
                this.radius = radius;
                this.height = height;
            }

            public override double Volume => Math.PI * Math.Pow(radius, 2) * height;

            public override void DisplayInfo()
            {
                Console.WriteLine($"Cylinder with radius {radius} and height {height}: Volume = {Volume:F2}");
            }
        }

        static void Main(string[] args)
        {

            Sphere[] spheres = new Sphere[5];
            Cube[] cubes = new Cube[5];
            Cylinder[] cylinders = new Cylinder[5];


            spheres[0] = new Sphere(1);
            spheres[1] = new Sphere(2);
            spheres[2] = new Sphere(3);
            spheres[3] = new Sphere(4);
            spheres[4] = new Sphere(5);

            cubes[0] = new Cube(1);
            cubes[1] = new Cube(2);
            cubes[2] = new Cube(3);
            cubes[3] = new Cube(4);
            cubes[4] = new Cube(5);

            cylinders[0] = new Cylinder(1, 2);
            cylinders[1] = new Cylinder(2, 3);
            cylinders[2] = new Cylinder(3, 4);
            cylinders[3] = new Cylinder(4, 5);
            cylinders[4] = new Cylinder(5, 6);


            int n = spheres.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (spheres[j].Volume > spheres[i].Volume)
                    {
                        Sphere temp = spheres[i];
                        spheres[i] = spheres[j];
                        spheres[j] = temp;
                    }

            n = cubes.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (cubes[j].Volume > cubes[i].Volume)
                    {
                        Cube temp = cubes[i];
                        cubes[i] = cubes[j];
                        cubes[j] = temp;
                    }

            n = cylinders.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (cylinders[j].Volume > cylinders[i].Volume)
                    {
                        Cylinder temp = cylinders[i];
                        cylinders[i] = cylinders[j];
                        cylinders[j] = temp;
                    }


            Console.WriteLine("Sphere array:");
            PrintArray(spheres);

            Console.WriteLine("\nCube array:");
            PrintArray(cubes);

            Console.WriteLine("\nCylinder array:");
            PrintArray(cylinders);


            int m = spheres.Length + cubes.Length + cylinders.Length;
            Shape[] allShapes = new Shape[m];
            int k = 0;

            for (int i = 0; i < spheres.Length; i++)
                allShapes[k++] = spheres[i];

            for (int i = 0; i < cubes.Length; i++)
                allShapes[k++] = cubes[i];

            for (int i = 0; i < cylinders.Length; i++)
                allShapes[k++] = cylinders[i];


            for (int i = 0; i < m - 1; i++)
                for (int j = i + 1; j < m; j++)
                    if (allShapes[j].Volume > allShapes[i].Volume)
                    {
                        Shape temp = allShapes[i];
                        allShapes[i] = allShapes[j];
                        allShapes[j] = temp;
                    }

            Console.WriteLine("\nAll shapes sorted by volume:");
            PrintArray(allShapes);
        }

        static void PrintArray<T>(T[] array) where T : Shape
        {
            foreach (var shape in array)
            {
                shape.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}