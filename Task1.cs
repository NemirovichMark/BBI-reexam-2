using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task1
    {
        public struct Dot
        {

            public int X;
            public int Y;
            public int Z;

            public Dot(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        public struct Vector
        {
            private Dot start;
            private Dot end;

            public Vector(Dot start, Dot end)
            {
                this.start = start;
                this.end = end;
            }

            public double Length()
            {
                int dx = end.X - start.X;
                int dy = end.Y - start.Y;
                int dz = end.Z - start.Z;
                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Start: ({start.X}, {start.Y}, {start.Z})");
                Console.WriteLine($"End: ({end.X}, {end.Y}, {end.Z})");
                Console.WriteLine($"Length: {Length()}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Vector[] vectors = new Vector[]
                {
            new Vector(new Dot(1, 2, 3), new Dot(4, 5, 6)),
            new Vector(new Dot(7, 8, 9), new Dot(10, 11, 12)),
            new Vector(new Dot(13, 14, 15), new Dot(16, 17, 18)),
            new Vector(new Dot(19, 20, 21), new Dot(22, 23, 24)),
            new Vector(new Dot(25, 26, 27), new Dot(28, 29, 30))
                };


                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 0; i < vectors.Length - 1; i++)
                    {
                        Vector current = vectors[i];
                        Vector next = vectors[i + 1];

                        if (current.Length() < next.Length())
                        {
                            vectors[i] = next;
                            vectors[i + 1] = current;
                            swapped = true;
                        }
                    }
                } while (swapped);

                foreach (var vec in vectors)
                {
                    vec.PrintInfo();
                    Console.WriteLine();
                }
            }
        }
    }
}
