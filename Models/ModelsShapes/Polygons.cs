using NewGraphicEditor.Data;
namespace NewGraphicEditor.Models.ModelsShapes
{
    public class Polygons : Shapes //класс многоугольника является наследником класса фигуры и является родителем для других многоугольников
    {
        protected int[] _point = new int[6];
        public override int[] point => _point;
        public override string nameShapes => "Polygon";
        protected override int countPoint => 6;
        public Polygons() { }
    }
}
