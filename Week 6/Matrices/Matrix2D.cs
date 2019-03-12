using System;
using System.Collections.Generic;

namespace Matrices
{
    class Matrix2D
    {
        private readonly List<int[]> data;

        public Matrix2D(int[] x, int[] y)
        {
            /*
             * (0, 0)  (0, 1)
             * (1, 0)  (1, 1)
             */

            data = new List<int[]> { x, y };

        }

        public List<int[]> Data
        {
            get
            {
                return data;
            }
        }

        public void DisplayData()
        {
            Console.Out.WriteLine("{0,-2} | {1,-2}\n-------\n{2,-2} | {3,-2}", data[0][0], data[0][1], data[1][0], data[1][1]);
        }
    }
}
