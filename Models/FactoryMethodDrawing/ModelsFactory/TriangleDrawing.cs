using NewGraphicEditor.Models.ModelsShapes;
using NewGraphicEditor.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NewGraphicEditor.Controls;
namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    public class TriangleDrawing : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Triangle triangle)
            {
                var points = new PointCollection();
                for (int i = 0; i < triangle.point.Length; i += 2)
                {
                    points.Add(new Point(triangle.point[i], triangle.point[i + 1]));
                }

                var polygon = new System.Windows.Shapes.Polygon()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.LightBlue,
                    Points = points
                };

                canvas.Children.Add(polygon);
            }
        }
    }
}
