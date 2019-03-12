using System;
using System.Drawing;

namespace Assignment
{
    class Utils
    {
        /*
         * diff p1, p2
         * 
         * p1 = (0, 0)
         * p2 = (5, 1)
         * 
         * diff(p1.X, p2.X) = 5 = a,
         * diff(p1.Y, p2.Y) = 1 = b,
         * a^2 + b^2 = c^2
         * 25 + 1 = c^2 = 26
         * 
         * c = sqrt(26) = 5.099 = diff(p1, p2)
         * 
         */

        public static int Diff(Point p1, Point p2)
        {

            double a = Math.Abs(p2.X - p1.X);
            double b = Math.Abs(p2.Y - p1.Y);

            return (int)Math.Round(Math.Sqrt(Math.Pow(a, 2.0) + Math.Pow(b, 2.0)));
        }
    }
}
