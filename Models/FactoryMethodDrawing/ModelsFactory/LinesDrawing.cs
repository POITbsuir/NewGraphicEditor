using NewGraphicEditor.Data;
using System.Windows.Controls;
using System.Windows.Media;
using NewGraphicEditor.Controls;
namespace NewGraphicEditor.Models
{
    public class LinesDrawer : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            // Проверяем, что это действительно линия
            if (shape is Lines line)
            {
                var wpfLine = new System.Windows.Shapes.Line
                {
                    X1 = line.point[0],
                    Y1 = line.point[1],
                    X2 = line.point[2],
                    Y2 = line.point[3],
                    Stroke = Brushes.Red,
                    StrokeThickness = 2
                };

                canvas.Children.Add(wpfLine);
            }
        }
    }
}