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
        private bool resizeShapeStatus = false;
        private bool drawing = false;

        private List<Shape> shapes;
        private Shape selectedShape = null;
        private Shape drawingShape = null;

        private int clicknumber = 0;
        private Point one, two, three;

        private MenuItem transformItem;

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
            // transform menu
            transformItem = new MenuItem();
            MenuItem resizeItem = new MenuItem();

            createItem.Text = "&Create";
            squareItem.Text = "&Square";
            triangleItem.Text = "&Triangle";
            circleItem.Text = "&Circle";
            selectItem.Text = "&Select";
            transformItem.Text = "&Transform";
            resizeItem.Text = "&Resize";

            transformItem.Enabled = !(selectedShape == null);
            
            mainMenu.MenuItems.Add(createItem);
            mainMenu.MenuItems.Add(selectItem);
            mainMenu.MenuItems.Add(transformItem);
            createItem.MenuItems.Add(squareItem);
            createItem.MenuItems.Add(triangleItem);
            createItem.MenuItems.Add(circleItem);
            transformItem.MenuItems.Add(resizeItem);

            selectItem.Click += new System.EventHandler(this.selectShape);
            squareItem.Click += new System.EventHandler(this.selectSquare);
            triangleItem.Click += new System.EventHandler(this.selectTriangle);
            circleItem.Click += new System.EventHandler(this.selectCircle);
            resizeItem.Click += new System.EventHandler(this.resizeShape);

            this.Menu = mainMenu;
            this.MouseClick += mouseClick;
            this.MouseDown += mouseDown;
            this.MouseMove += mouseMove;
            this.MouseUp += mouseUp;
            this.KeyUp += keyUp;
        }

        // Generally, all methods of the form are usually private
        private void selectSquare(object sender, EventArgs e)
        {
            selectSquareStatus = true;
            // MessageBox.Show("Click OK and then click once each at two locations to create a square");
        }

        private void selectTriangle(object sender, EventArgs e)
        {
            selectTriangleStatus = true;
            MessageBox.Show("Click OK and then click once each at three locations to create a triangle");
        }

        private void selectCircle(object sender, EventArgs e)
        {
            selectCircleStatus = true;
            // MessageBox.Show("Click OK and then click once each at two locations to create a circle");
        }

        private void selectShape(object sender, EventArgs e)
        {
            MessageBox.Show("You selected the Select option...");
        }

        private void resizeShape(object sender, EventArgs e)
        {
            resizeShapeStatus = true;
            new ResizeShapeWindow().Show();
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            // for rubber-banding
            // xor animation?
            if (clicknumber == 1 && e.Button == MouseButtons.Left)
            {
                drawing = true;

                Control control = (Control) sender;

                if (selectSquareStatus == true)
                {
                    drawingShape = drawSquare(one, e.Location, Pens.Red);
                }
                else if (selectCircleStatus == true)
                {
                    drawingShape = drawCircle(one, e.Location, Brushes.Red);
                }
            }
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                two = e.Location;
                clicknumber = 0;

                if (selectSquareStatus == true)
                {
                    selectSquareStatus = false;
                    ((Square)drawingShape).draw(this.CreateGraphics(), Pens.White);
                    drawingShape = null;
                    shapes.Add(drawSquare(one, two, Pens.Black));
                }
                else if (selectCircleStatus == true)
                {
                    selectCircleStatus = false;
                    ((Circle)drawingShape).Draw(this.CreateGraphics(), Brushes.White);
                    drawingShape = null;
                    shapes.Add(drawCircle(one, two, Brushes.Black));
                }
            }
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Point currentPoint = e.Location;

                if (selectSquareStatus == true)
                {
                    ((Square)drawingShape).draw(this.CreateGraphics(), Pens.White);
                    drawingShape = drawSquare(one, currentPoint, Pens.Red);
                }
                else if (selectCircleStatus == true)
                {
                    ((Circle)drawingShape).Draw(this.CreateGraphics(), Brushes.White);
                    drawingShape = drawCircle(one, currentPoint, Brushes.Red);
                }
            }
        }

        private Square drawSquare(Point p1, Point p2, Pen pen)
        {
            Graphics g = this.CreateGraphics();

            Square aShape = new Square(p1, p2);
            aShape.draw(g, pen);
            return aShape;
        }

        private Circle drawCircle(Point p1, Point p2, Brush brush)
        {

            Graphics g = this.CreateGraphics();
            Brush blackbrush = Brushes.Black;

            Circle circle = new Circle(one, Utils.Diff(one, two));
            circle.Draw(g, blackbrush);
            return circle;
        }

        // This method is quite important and detects all mouse clicks - other methods may need
        // to be implemented to detect other kinds of event handling eg keyboard presses.
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftClick(sender, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                rightClick(sender, e);
            }
        }

        private void leftClick(object sender, MouseEventArgs e)
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
                    if (drawing)
                    {
                        return;
                    }

                    two = new Point(e.X, e.Y);

                    clicknumber = 0;
                    selectSquareStatus = false;

                    shapes.Add(drawSquare(one, two, Pens.Black));
                }
            }
            else if (selectTriangleStatus == true)
            {
                if (clicknumber == 0)
                {
                    one = e.Location;
                    clicknumber = 1;
                }
                else if (clicknumber == 1)
                {
                    two = e.Location;
                    clicknumber = 2;
                }
                else
                {
                    three = e.Location;
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
                    one = e.Location;
                    clicknumber = 1;
                }
                else
                {
                    two = e.Location;
                    clicknumber = 0;
                    selectCircleStatus = false;

                    shapes.Add(drawCircle(one, two, Brushes.Black));
                }
            }
            else
            {
                // selecting shapes
            }
        }

        private void rightClick(object sender, MouseEventArgs e)
        {

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
            this.transformItem.Enabled = true;
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                // select previous shape
                case Keys.Left:
                    selectShape(-1);
                    break;
                // select next shape
                case Keys.Right:
                    selectShape(1);
                    break;
                // delete selected shape
                case Keys.Delete:
                    if (selectedShape != null)
                    {
                        redraw(selectedShape, Brushes.White);
                        shapes.Remove(selectedShape);
                        selectedShape = null;
                        this.transformItem.Enabled = false;
                    }
                    break;
                // deselect shape
                case Keys.Escape:
                    redraw(selectedShape, Brushes.Black);
                    selectedShape = null;
                    this.transformItem.Enabled = false;
                    break;
            }
        }
    }
}


