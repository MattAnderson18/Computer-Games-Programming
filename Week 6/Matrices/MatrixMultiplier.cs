using System;
using System.Collections.Generic;
using System.Text;

namespace Matrices
{
    class MatrixMultiplier
    {

        public static void Multiply(Matrix2D matrix1, Matrix2D matrix2)
        {
            // int[,] m1Data = matrix1.Data;
            // int[,] m2Data = matrix2.Data;

            List<int[]> m1Data = matrix1.Data;
            List<int[]> m2Data = matrix2.Data;

            // int result00, result01, result10, result11;

            /*
             *     0       1
             * 0 a(0, 0) a(0, 1)
             * 1 a(1, 0) a(1, 1)  
             * 
             * 0 b(0, 0) b(0, 1)
             * 1 b(1, 0) b(1, 1)
             * 
             * 0 r(0, 0) r(0, 1)
             * 1 r(1, 0) r(1, 1)
             *
             * r0, 0 = (a0, 0 * b0, 0) + (a0, 1 * b1, 0)
             * r0, 1 = (a0, 0 * b0, 1) + (a0, 1 * b1, 1)
             * r1, 0 = (a1, 0 * b0, 0) + (a1, 1 * b1, 0)
             * r1, 1 = (a1, 0 * b0, 1) + (a1, 1 * b1, 1)
             */

            // result00 = (m1Data[0, 0] * m2Data[0, 0]) + (m1Data[0, 1] * m2Data[1, 0]);
            // result01 = (m1Data[0, 0] * m2Data[0, 1]) + (m1Data[0, 1] * m2Data[1, 1]);
            // result10 = (m1Data[1, 0] * m2Data[0, 0]) + (m1Data[1, 1] * m2Data[1, 0]);
            // result11 = (m1Data[1, 0] * m2Data[0, 1]) + (m1Data[1, 1] * m2Data[1, 1]);

            // Matrix2D result = new Matrix2D(result00, result01, result11, result11);
            // result.DisplayData();
        }
    }
}
