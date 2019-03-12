using System;
using System.Drawing;

namespace Assignment
{
    class Triangle : Shape
    {
        Point p1, p2, p3;

        public Triangle(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public void Draw(Graphics g, Pen pen)
        {
            g.DrawLines(pen, new Point[] { p1, p2, p3, p1 });
        }
    }
}
