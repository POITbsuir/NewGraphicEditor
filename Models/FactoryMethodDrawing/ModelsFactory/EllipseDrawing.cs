using NewGraphicEditor.Controls;
using NewGraphicEditor.Models.ModelsShapes;
using NewGraphicEditor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    public class EllipseDrawing : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Ellipses ellipse)
            {
                var heigth = Math.Sqrt(((ellipse.point[2] - ellipse.point[0]) * (ellipse.point[2] - ellipse.point[0])) + (ellipse.point[3] - ellipse.point[1]) * (ellipse.point[3] - ellipse.point[1]));
                var width = Math.Sqrt(((ellipse.point[4] - ellipse.point[0]) * (ellipse.point[4] - ellipse.point[0])) + (ellipse.point[5] - ellipse.point[1]) * (ellipse.point[5] - ellipse.point[1]));
                var ellipce = new System.Windows.Shapes.Ellipse()
                {
                    Width = width,
                    Height = heigth,
                    Stroke = Brushes.Sienna,
                    Fill = Brushes.SeaGreen,
                    StrokeThickness = 2
                };

                Canvas.SetLeft(ellipce, ellipse.point[0]);
                Canvas.SetTop(ellipce, ellipse.point[1]);

                canvas.Children.Add(ellipce);
            }
        }
    }
}
