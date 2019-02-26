using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ShapeRepresentation
{
    public partial class BresCircle : Form
    {
        int centreX, centreY, radius;
        Point plotPt;

        //Constructor
        public BresCircle()
        {
            // Size the frame to full screen 
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Black;

            centreX = 200;   // fixed values for illustration
            centreY = 200;
            radius = 150;
            plotPt = new Point(0, 0);
        }

        // Method fills in one pixel only
        void putPixel(Graphics g, Point pixel, Brush aBrush)
        {
            // FillRectangle call fills at location x y and is 1 pixel high by 1 pixel wide
            g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics; // Get on screen graphics tool
            drawCircle(g);
        }

        void drawCircle(Graphics g)
        {
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;  // initial value

            while (x <= y)
            {
                // put pixel in each octant
                plotPt.X = x + centreX;
                plotPt.Y = y + centreY;
                putPixel(g, plotPt, (Brush) Brushes.Red);

                plotPt.X = y + centreX;
                plotPt.Y = x + centreY;
                putPixel(g, plotPt, (Brush) Brushes.Orange);

                plotPt.X = y + centreX;
                plotPt.Y = -x + centreY;
                putPixel(g, plotPt, (Brush) Brushes.Yellow);

                plotPt.X = x + centreX;
                plotPt.Y = -y + centreY;
                putPixel(g, plotPt, (Brush) Brushes.Green);

                plotPt.X = -x + centreX;
                plotPt.Y = -y + centreY;
                putPixel(g, plotPt, (Brush) Brushes.Blue);

                plotPt.X = -y + centreX;
                plotPt.Y = -x + centreY;
                putPixel(g, plotPt, (Brush) Brushes.Indigo);

                plotPt.X = -y + centreX;
                plotPt.Y = x + centreY;
                putPixel(g, plotPt, (Brush)Brushes.BlueViolet);

                plotPt.X = -x + centreX;
                plotPt.Y = y + centreY;
                putPixel(g, plotPt, (Brush) Brushes.Violet);

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
                Thread.Sleep(100);
            }
        }
    } // end class
}
