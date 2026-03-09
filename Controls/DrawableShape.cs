using NewGraphicEditor.Data;
using System.Windows.Controls;

namespace NewGraphicEditor.Controls
{
    public interface  IDrawableShape //интерфейс для реализации отрисовки фигуры
    {
        void Draw(Canvas canvas, Shapes shape);
    }
}
