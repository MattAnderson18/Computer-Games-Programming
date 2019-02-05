using System;
using System.Drawing;
using System.Windows.Forms;

namespace Triangles
{
    public partial class Triangles : Form
    {
        public Triangles()
        {
            InitializeComponent();            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // DrawTriangle(g, new Point(100, 100), new Point(500, 100), new Point(300, 446));
            // DrawTriangle(g, new Point(300, 100), new Point(200, 268), new Point(400, 268));
            // DrawTriangle(g, new Point(250, 184), new Point(350, 184), new Point(300, 268));

            Point p1 = new Point(100, 100);
            Point p2 = new Point(500, 100);
            Point p3 = new Point(300, 446);

            /* for (int i = 0; i < 3; i++)
            {
                DrawTriangle(g, p1, p2, p3);

                Point p1temp = p1;
                Point p2temp = p2;

                p1 = MidPoint(p1temp, p2temp);
                p2 = MidPoint(p1temp, p3);
                p3 = MidPoint(p2temp, p3);
            }*/

            bool done = false;

            do
            {
                DrawShape(g, p1, p2, p3);

                Point p1temp = p1;
                Point p2temp = p2;

                p1 = MidPoint(p1temp, p2temp);
                p2 = MidPoint(p1temp, p3);
                p3 = MidPoint(p2temp, p3);

                if (p2.X - p1.X < 5 && p2.Y - p1.Y < 5 && p3.X - p1.X < 5 && p3.Y - p1.Y < 5)
                {
                    done = true;
                }
            } while (!done);
        }

        private void DrawShape(Graphics g, params Point[] points)
        {
            Pen blackPen = new Pen(Color.Black);
            g.DrawPolygon(blackPen, points);
        }

        private Point MidPoint(Point p1, Point p2)
        {
            return new Point(p1.X + ((p2.X - p1.X) / 2), p1.Y + ((p2.Y - p1.Y) / 2));
        }
    }
}
