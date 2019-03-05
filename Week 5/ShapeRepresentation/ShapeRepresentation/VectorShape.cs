using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShapeRepresentation
{

    public partial class VectorShape : Form
    {
        Point[] points = new Point[]
        {
            new Point(10, 10),
            new Point(160, 10),
            new Point(310, 10),
            new Point(160, 85),
            new Point(310, 85),
            new Point(10, 160),
            new Point(160, 160),
            new Point(310, 160),
            new Point(10, 235),
            new Point(310, 235)
        };

        string[] lines = new string[]
        {
            "0,1",
            "1,2",
            "1,3",
            "4,3",
            "3,6",
            "6,7",
            "7,9",
            "9,8",
            "8,5",
            "5,0",
            "5,6",
            "2,4"
        };

        public VectorShape()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] linePoints = lines[i].Split(',');
                int p0index = Int32.Parse(linePoints[0]);
                int p1index = Int32.Parse(linePoints[1]);

                Point p0 = points[p0index];
                Point p1 = points[p1index];

                g.DrawLine(blackPen, p0, p1);
            }
        }
    }
}
