using NewGraphicEditor.Data;

namespace NewGraphicEditor.Models.ModelsShapes
{
    public class ClientModel : Shapes
    {
        //дореализую позже
        private int[] _point = new int[6];
        public override int[] point => _point;
        public override string nameShapes => "ClientsModel";
        protected override int countPoint => 6;

        public ClientModel()
        {
            NameShape = "Пользовательская фигура";
            Info = "Поочередно вводить координаты точек: " +
                   "(x1, y1); (x2, y2); (x3, y3)";
        }
    }
}
