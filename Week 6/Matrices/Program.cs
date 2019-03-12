using System;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix2D m1 = new Matrix2D(new int[]{ 5, 2 }, new int[]{ 3, 8 });
            Matrix2D m2 = new Matrix2D(new int[]{ 3, 6 }, new int[]{ 9, 1 });

            m1.DisplayData();
            Console.WriteLine();
            m2.DisplayData();
            Console.WriteLine();
            MatrixMultiplier.Multiply(m1, m2);
            Console.ReadKey();
        }
    }
}
