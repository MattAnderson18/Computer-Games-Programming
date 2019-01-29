using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGP
{
    public partial class SimpleDrawing: Form
    {
        public SimpleDrawing()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Create a pen object
            Pen blackPen = new Pen(Color.Black);

            // Draws a triangle 
            g.DrawLine(blackPen, 50, 50, 100, 100);
            g.DrawLine(blackPen, 100, 100, 200, 100);
            g.DrawLine(blackPen, 50, 50, 100, 100);
            g.DrawLine(blackPen, 200, 100, 50, 50);

            // Draw a rectangle
            g.DrawRectangle(blackPen, 200, 200, 150, 150);

            // Draw an ellipse
            g.DrawEllipse(blackPen, new Rectangle(250, 50, 150, 100));

            // Draw square
            Rectangle square = new Rectangle(50, 150, 100, 100);
            SolidBrush blue = new SolidBrush(Color.FromArgb(0, 0, 255));
            g.DrawRectangle(blackPen, square);
            g.FillRectangle(blue, square);
            // Draw circle within square
            Rectangle circle = new Rectangle(50, 150, 100, 100);
            SolidBrush red = new SolidBrush(Color.FromArgb(255, 0, 0));
            g.FillEllipse(red, circle);
            g.DrawEllipse(blackPen, circle);

            // Define points of a polygon
            Point[] pts = {
                            new Point(50, 300),
                            new Point(150, 300),
                            new Point(150, 400),
                            new Point(100, 350),
                            new Point(50, 400)
                          };

            // Define a colour for filling the polygon
            Color myColour = Color.FromArgb(0, 255, 0);
            SolidBrush brush = new SolidBrush(myColour);

            // Draw filled polygon
            g.FillPolygon(brush, pts);
        }
    }
}


