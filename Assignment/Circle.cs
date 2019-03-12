using System;
using System.Drawing;

namespace Assignment
{
    class Circle : Shape
    {
        Point center;
        int radius;

        public Circle(Point center, int radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public void putPixel(Graphics g, Point pixel, Brush brush)
        {
            g.FillRectangle(brush, pixel.X, pixel.Y, 1, 1);
        }

        public void Draw(Graphics g, Brush brush)
        {
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;
            Point pt = new Point(0, 0);

            while (x <= y)
            {
                pt.X = x + center.X;
                pt.Y = y + center.Y;
                putPixel(g, pt, brush);

                pt.X = y + center.X;
                pt.Y = x + center.Y;
                putPixel(g, pt, brush);

                pt.X = y + center.X;
                pt.Y = -x + center.Y;
                putPixel(g, pt, brush);

                pt.X = x + center.X;
                pt.Y = -y + center.Y;
                putPixel(g, pt, brush);

                pt.X = -x + center.X;
                pt.Y = -y + center.Y;
                putPixel(g, pt, brush);

                pt.X = -y + center.X;
                pt.Y = -x + center.Y;
                putPixel(g, pt, brush);

                pt.X = -y + center.X;
                pt.Y = x + center.Y;
                putPixel(g, pt, brush);

                pt.X = -x + center.X;
                pt.Y = y + center.Y;
                putPixel(g, pt, brush);

                // update d value 
                if (d <= 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }
    }
}
