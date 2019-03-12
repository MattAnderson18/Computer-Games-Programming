using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Assignment
{
    public partial class GrafPack : Form
    {

        private MainMenu mainMenu;
        private bool selectSquareStatus = false;
        private bool selectTriangleStatus = false;
        private bool selectCircleStatus = false;

        private List<Shape> shapes;
        private Shape selectedShape = null;

        private int clicknumber = 0;
        private Point one, two, three;

        public GrafPack()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            this.shapes = new List<Shape>();

            // The following approach uses menu items coupled with mouse clicks
            MainMenu mainMenu = new MainMenu();
            MenuItem createItem = new MenuItem();
            MenuItem selectItem = new MenuItem();
            MenuItem squareItem = new MenuItem();
            MenuItem triangleItem = new MenuItem();
            MenuItem circleItem = new MenuItem();

            createItem.Text = "&Create";
            squareItem.Text = "&Square";
            triangleItem.Text = "&Triangle";
            circleItem.Text = "&Circle";
            selectItem.Text = "&Select";
            
            mainMenu.MenuItems.Add(createItem);
            mainMenu.MenuItems.Add(selectItem);
            createItem.MenuItems.Add(squareItem);
            createItem.MenuItems.Add(triangleItem);
            createItem.MenuItems.Add(circleItem);

            selectItem.Click += new System.EventHandler(this.selectShape);
            squareItem.Click += new System.EventHandler(this.selectSquare);
            triangleItem.Click += new System.EventHandler(this.selectTriangle);
            circleItem.Click += new System.EventHandler(this.selectCircle);

            this.Menu = mainMenu;
            this.MouseClick += mouseClick;
            this.MouseDown += mouseDown;
            this.KeyUp += keyUp;
        }

        // Generally, all methods of the form are usually private
        private void selectSquare(object sender, EventArgs e)
        {
            selectSquareStatus = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a square");
        }

        private void selectTriangle(object sender, EventArgs e)
        {
            selectTriangleStatus = true;
            MessageBox.Show("Click OK and then click once each at three locations to create a triangle");
        }

        private void selectCircle(object sender, EventArgs e)
        {
            selectCircleStatus = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a circle");
        }

        private void selectShape(object sender, EventArgs e)
        {
            MessageBox.Show("You selected the Select option...");
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            // for rubber-banding
            // xor animation?
        }

        // This method is quite important and detects all mouse clicks - other methods may need
        // to be implemented to detect other kinds of event handling eg keyboard presses.
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 'if' statements can distinguish different selected menu operations to implement.
                // There may be other (better, more efficient) approaches to event handling,
                // but this approach works.
                if (selectSquareStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectSquareStatus = false;

                        Graphics g = this.CreateGraphics();
                        Pen blackpen = new Pen(Color.Black);

                        Square aShape = new Square(one, two);
                        aShape.draw(g, blackpen);
                        shapes.Add(aShape);
                    }
                }
                else if (selectTriangleStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else if (clicknumber == 1)
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 2;
                    }
                    else
                    {
                        three = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectTriangleStatus = false;

                        Graphics g = this.CreateGraphics();
                        Pen blackpen = new Pen(Color.Black);

                        Triangle triangle = new Triangle(one, two, three);
                        triangle.Draw(g, blackpen);
                        shapes.Add(triangle);
                    }
                }
                else if (selectCircleStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectCircleStatus = false;

                        Graphics g = this.CreateGraphics();
                        Brush blackbrush = Brushes.Black;

                        Circle circle = new Circle(one, Utils.Diff(one, two));
                        circle.Draw(g, blackbrush);
                        shapes.Add(circle);
                    }
                }
                else
                {
                    // selecting shapes
                }
            }
        }

        private void redraw(Shape shape, Brush brush)
        {

            if (selectedShape is Square)
            {
                ((Square)selectedShape).draw(this.CreateGraphics(), new Pen(brush));
            }
            else if (selectedShape is Triangle)
            {
                ((Triangle)selectedShape).Draw(this.CreateGraphics(), new Pen(brush));
            }
            else if (selectedShape is Circle)
            {
                ((Circle)selectedShape).Draw(this.CreateGraphics(), brush);
            }
        }

        private void selectShape(int direction)
        {
            if (shapes.Count < 1)
            {
                return;
            }

            if (selectedShape != null)
            {
                redraw(selectedShape, Brushes.Black);

                int curIndex = shapes.IndexOf(selectedShape);

                if (direction > 0)
                {
                    // right (+1)
                    // curIndex + 1
                    if (curIndex + direction <= shapes.Count -1)
                    {
                        selectedShape = shapes[curIndex + direction];
                    }
                    else
                    {
                        selectedShape = shapes[0];
                    }
                }
                else
                {
                    // left (-1)
                    // curIndex + (-1)
                    if (curIndex + direction >= 0)
                    {
                        selectedShape = shapes[curIndex + direction];
                    }
                    else
                    {
                        selectedShape = shapes[shapes.Count - 1];
                    }
                }
            }
            else
            {
                selectedShape = shapes[0];
            }

            redraw(selectedShape, Brushes.Blue);
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left )
            {
                selectShape(-1);
            }
            else if (e.KeyCode == Keys.Right)
            {
                selectShape(1);
            }
        }
    }
}


