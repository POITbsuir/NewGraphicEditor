using NewGraphicEditor.Data;
namespace NewGraphicEditor.Models.ModelsShapes
{
    public class Ellipses : Shapes //дочерник класс Эллипс
    {
        private int[] _point = new int[6];
        public override int[] point => _point;
        public override string nameShapes => "Ellipse";
        protected override int countPoint => 6;

        public Ellipses()
        {
            NameShape = "Эллипс";
            Info = "Поочередно вводить координаты точек: " +
                   "(x1, y1); (x2, y2); (x3, y3)";
        }
    }
}
