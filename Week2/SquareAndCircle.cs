﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rectangles
{
    public partial class SquareAndCircle : Form
    {
        Rectangle aCircle;
        Rectangle aSquare;

        public SquareAndCircle()
        {
            // Maximises the form whilst retaining the menu bar;
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;

            // Create the square and circle
            aSquare = new Rectangle(50, 50, 100, 100);
            aCircle = new Rectangle(300, 300, 200, 200);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Create a pen for drawing
            Pen blackPen = new Pen(Color.Black);
            // Draw the square and the circle
            g.DrawRectangle(blackPen, aSquare);
            g.DrawEllipse(blackPen, aCircle);
        }

        public static void Main()
        {
            Application.Run(new SquareAndCircle());
        }
    }
}
