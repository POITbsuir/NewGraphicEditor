using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGraphicEditor.Models.ModelsShapes
{
    public class Rectangles : Polygons
    {
        public override int[] point => _point;
        public override string nameShapes => "Rectangle";
        protected override int countPoint => 6;
        public Rectangles() 
        {
            _point = new int[8];
            Info = NameShape = "Прямоугольник";
            Info = "Поочередно вводить координаты точек: " +
                   "(x1, y1); (x2, y2); (x3, y3), (x4, y4), так, чтобы стороны в обязательном порядке образовывали прямой угол";
        }
    }
}
