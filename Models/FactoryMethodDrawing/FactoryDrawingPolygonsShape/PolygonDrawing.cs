using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using System.Windows.Controls;

namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    public abstract class PolygonDrawing : IDrawableShape 
    {
        public abstract void Draw(Canvas canvas, Shapes shape);
    }
}
