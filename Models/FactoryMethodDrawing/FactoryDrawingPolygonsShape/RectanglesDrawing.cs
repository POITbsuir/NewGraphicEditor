using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing.FactoryDrawingPolygonsShape
{
    public class RectanglesDrawing : PolygonDrawing
    {
        public override void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Rectangles rc)
            {
                var points = new PointCollection();

                //вычисляю условие ортогональности векторов
                int ax = rc.point[2] - rc.point[0];
                int ay = rc.point[4] - rc.point[2];
                int bx = rc.point[3] - rc.point[1];
                int by = rc.point[5] - rc.point[3];

                int result = (ax * bx) + (ay * by);
                if (result == 0)
                {
                    rc.point[6] = rc.point[0] + rc.point[4] - rc.point[2];
                    rc.point[7] = rc.point[1] + rc.point[5] - rc.point[3];
                    for (int i = 0; i <  rc.point.Length; i += 2)
                    {
                        points.Add(new Point(rc.point[i], rc.point[i + 1]));
                    }

                    var rectangle = new System.Windows.Shapes.Polygon()
                    {
                        Stroke = Brushes.Red,
                        StrokeThickness = 2,
                        Fill = Brushes.LightBlue
                    };

                    rectangle.Points = points;
                    canvas.Children.Add(rectangle);
                }
                else
                    MessageBox.Show("Прямоугольник с такими координатами невозможен...");
            }
        }
    }
}
