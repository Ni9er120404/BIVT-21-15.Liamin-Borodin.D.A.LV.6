using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LaboratoryWork.OOP._6
{
	public partial class MainWindow : Window
	{
		private readonly Random random = new Random();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			DrawShapes();
		}

		private void DrawShapes()
		{
			DrawCircles();
			DrawRectangles();
		}

		private void DrawCircles()
		{
			for (int i = 0; i < 5; i++)
			{
				int radius = random.Next(10, 200);
				int x = random.Next(radius, (int)canvas.ActualWidth - radius);
				int y = random.Next(radius, (int)canvas.ActualHeight - radius);

				Ellipse circle = new Ellipse()
				{
					Width = radius * 2,
					Height = radius * 2,
					Fill = new SolidColorBrush(RandomColor()),
					Stroke = new SolidColorBrush(Colors.Black),
					StrokeThickness = 1
				};

				Canvas.SetLeft(circle, x - radius);
				Canvas.SetTop(circle, y - radius);

				_ = canvas.Children.Add(circle);
			}
		}

		private void DrawRectangles()
		{
			for (int i = 0; i < 6; i++)
			{
				int width = random.Next(10, 200);
				int height = random.Next(10, 200);
				int x = random.Next(width / 2, (int)canvas.ActualWidth - (width / 2));
				int y = random.Next(height / 2, (int)canvas.ActualHeight - (height / 2));

				Rectangle rectangle = new Rectangle()
				{
					Width = width,
					Height = height,
					Fill = new SolidColorBrush(RandomColor()),
					Stroke = new SolidColorBrush(Colors.Black),
					StrokeThickness = 1
				};

				Canvas.SetLeft(rectangle, x - (width / 2));
				Canvas.SetTop(rectangle, y - (height / 2));

				_ = canvas.Children.Add(rectangle);
			}
		}

		private Color RandomColor()
		{
			return Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
		}

		private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			foreach (UIElement element in canvas.Children)
			{
				if (element is Ellipse circle && IsMouseOverShape(circle))
				{
					double radius = circle.Width / 2;
					double area = Math.PI * radius * radius;
					_ = MessageBox.Show($"Area of the circle: {Math.Round(area, 2)}");
				}
				else if (element is Rectangle rectangle && IsMouseOverShape(rectangle))
				{
					double area = rectangle.Width * rectangle.Height;
					_ = MessageBox.Show($"Area of the rectangle: {Math.Round(area, 2)}");
				}
			}
		}

		private bool IsMouseOverShape(Shape shape)
		{
			Point mousePosition = Mouse.GetPosition(canvas);
			return mousePosition.X >= Canvas.GetLeft(shape) && mousePosition.X <= Canvas.GetLeft(shape) + shape.Width
				   && mousePosition.Y >= Canvas.GetTop(shape) && mousePosition.Y <= Canvas.GetTop(shape) + shape.Height;
		}
	}
}