using NewGraphicEditor.Data;
namespace NewGraphicEditor.Models

{
    public class Lines : Shapes
    {
        private int[] _point = new int[4];
        public override int[] point => _point;
        public override string nameShapes => "Line";
        protected override int countPoint => 4;

        public Lines()
        {
            NameShape = "Отрезок";
            Info = "Поочередно вводить координаты точек: " +
                   "(x1, y1); (x2, y2)";
        }
    }
}