using NewGraphicEditor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewGraphicEditor.Models.ModelsShapes
{
    public class Triangle : Shapes
    {
        private int[] _point = new int[6];
        public override int[] point => _point;
        public override string nameShapes => "Triangle";
        protected override int countPoint => 6;

        public Triangle()
        {
            NameShape = "Треугольник";
            Info = "Поочередно вводить координаты точек: " +
                   "(x1, y1); (x2, y2); (x3, y3)";
        }
    }
}
