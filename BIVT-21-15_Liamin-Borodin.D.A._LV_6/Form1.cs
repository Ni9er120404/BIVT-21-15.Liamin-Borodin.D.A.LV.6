namespace BIVT_21_15_Liamin_Borodin.D.A._LV_6
{
    public partial class Form1 : Form
    {
        internal Circle[] Circle { get; }

        internal Rectangle[] Rectangle { get; }

        public Form1()
        {
            InitializeComponent();
            Circle = new Circle[]
            {
                new Circle(this, Color.Red, Color.Black),
                new Circle(this, Color.Green, Color.Black),
                new Circle(this, Color.Blue, Color.Black),
                new Circle(this, Color.Yellow, Color.Black),
                new Circle(this, Color.Black, Color.Black)
            };
            Rectangle = new Rectangle[]
            {
                new Rectangle(this, Color.Red, Color.Black),
                new Rectangle(this, Color.Green, Color.Black),
                new Rectangle(this, Color.Blue, Color.Black),
                new Rectangle(this, Color.Yellow, Color.Black),
                new Rectangle(this, Color.Black, Color.Black),
                new Rectangle(this, Color.Purple, Color.Black)
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Circle v in Circle)
            {
                v.Draw();
            }
            foreach (Rectangle v1 in Rectangle)
            {
                v1.Draw();
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Circle v in Circle)
            {
                if (v.CheckPoint(new Point(e.X, e.Y)))
                {
                    MessageBox.Show("Площадь круга = " + Math.Round(v.GetCalcArea(), 2).ToString());
                    v.Draw(true);
                }
            }
            foreach (Rectangle item in Rectangle)
            {
                if (item.CheckPoint(new Point(e.X, e.Y)))
                {
                    MessageBox.Show("Площадь прямоугольника = " + Math.Round(item.CalcArea(), 2).ToString());
                    item.Draw(true);
                }
            }
        }
    }
    internal class Geometric_Shape
    {
        protected Point Central_Point;
        public Color Fill_Color { get; private set; }
        public Color Line_Color { get; private set; }
        protected float Thinness_Of_Lines { get; set; }
        protected static Random Random { get; set; } = new();

        public Geometric_Shape(Color fill_Color, Color line_Color)
        {
            Fill_Color = fill_Color;
            Line_Color = line_Color;
        }
        protected void ChangeColor(Color fill_Color, Color line_Color)
        {
            Fill_Color = fill_Color;
            Line_Color = line_Color;
        }
    }
    internal class Rectangle : Geometric_Shape
    {
        public Form Form { get; }

        public Graphics Graphics { get; }

        public int Width1 { get; }

        public int Height1 { get; }

        public Rectangle(Form form, Color fill_Color, Color line_Color) : base(fill_Color, line_Color)
        {
            Form = form;
            int a = Random.Next(10, 200);
            Width1 = a;
            Height1 = a;
            Central_Point = new Point()
            {
                X = Random.Next(Width1 / 2, form.ClientSize.Width - (Width1 / 2)),
                Y = Random.Next(Height1 / 2, form.ClientSize.Height - (Height1 / 2))
            };
            Thinness_Of_Lines = 1;
            Graphics = form.CreateGraphics();
        }
        public void Draw(bool fill_Random = false)
        {
            if (fill_Random)
            {
                ChangeColor(Color.FromArgb(Random.Next(0, 256), Random.Next(0, 256), Random.Next(0, 256)),
                            Color.FromArgb(Random.Next(0, 256), Random.Next(0, 256), Random.Next(0, 256)));
                Thinness_Of_Lines = Random.Next(1, 11);
                int x = Central_Point.X - (Width1 / 2);
                int y = Central_Point.Y - (Height1 / 2);
                Graphics.FillRectangle(new SolidBrush(Fill_Color),
                                       x + (int)(Thinness_Of_Lines / 2),
                                       y + (int)(Thinness_Of_Lines / 2),
                                       Width1,
                                       Height1);
                Graphics.DrawRectangle(new Pen(Line_Color, Thinness_Of_Lines),
                                       x,
                                       y,
                                       Width1,
                                       Height1);
            }
            else
            {
                Draw();
            }
        }
        private void Draw()
        {
            int x = Central_Point.X - (Width1 / 2);
            int y = Central_Point.Y - (Height1 / 2);
            Graphics.FillRectangle(new SolidBrush(Fill_Color),
                                   x + (int)(Thinness_Of_Lines / 2),
                                   y + (int)(Thinness_Of_Lines / 2),
                                   Width1,
                                   Height1);
            Graphics.DrawRectangle(new Pen(Line_Color, Thinness_Of_Lines),
                                   x,
                                   y,
                                   Width1,
                                   Height1);
        }
        public double CalcArea()
        {
            return Width1 * Height1;
        }
        public bool CheckPoint(Point point)
        {
            return point.X >= Central_Point.X - (Width1 / 2)
                   && point.X <= Central_Point.X + (Width1 / 2)
                   && point.Y >= Central_Point.Y - (Height1 / 2) & point.Y <= Central_Point.Y + (Height1 / 2);
        }
    }
    internal class Circle : Geometric_Shape
    {
        public Form Form { get; }

        public int Radius1 { get; }

        public Graphics Graphics { get; }

        public Circle(Form form,
                      Color fill_Color,
                      Color line_Color) : base(fill_Color, line_Color)
        {
            Form = form;
            int radius = Random.Next(10, 200);
            Radius1 = radius;
            Central_Point = new Point()
            {
                X = Random.Next(radius, form.ClientSize.Width - radius),
                Y = Random.Next(radius, form.ClientSize.Height - radius)
            };
            Thinness_Of_Lines = 1;
            Graphics = form.CreateGraphics();
        }
        public void Draw(bool fill_Random = false)
        {
            if (fill_Random)
            {
                ChangeColor(Color.FromArgb(Random.Next(0, 256), Random.Next(0, 256), Random.Next(0, 256)),
                            Color.FromArgb(Random.Next(0, 256), Random.Next(0, 256), Random.Next(0, 256)));
                Thinness_Of_Lines = Random.Next(1, 11);
                int x = Central_Point.X - Radius1;
                int y = Central_Point.Y - Radius1;
                Graphics.FillEllipse(
                    new SolidBrush(Fill_Color),
                    x,
                    y,
                    Radius1 * 2,
                    Radius1 * 2);
                Graphics.DrawEllipse(
                    new Pen(Line_Color, Thinness_Of_Lines),
                    x,
                    y,
                    Radius1 * 2,
                    Radius1 * 2);
            }
            else
            {
                Draw();
            }
        }
        private void Draw()
        {
            int x = Central_Point.X - Radius1;
            int y = Central_Point.Y - Radius1;
            Graphics.FillEllipse(
                new SolidBrush(Fill_Color),
                x,
                y,
                Radius1 * 2,
                Radius1 * 2);
            Graphics.DrawEllipse(
                new Pen(Line_Color, Thinness_Of_Lines),
                x,
                y,
                Radius1 * 2,
                Radius1 * 2);
        }

        public double GetCalcArea()
        {
            return Math.PI * Math.Pow(Radius1, 2);
        }

        public bool CheckPoint(Point point)
        {
            return Math.Sqrt(Math.Pow(Central_Point.X - point.X, 2) + Math.Pow(Central_Point.Y - point.Y, 2)) <= Radius1;
        }
    }
}