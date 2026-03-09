using System.Collections;
using System.Collections.Generic;
using NewGraphicEditor.Data;
namespace NewGraphicEditor.Models
{
    //реализую собствыенную коллекцию фигур
    public class ShapesCollection<T> : IEnumerable<T>
    {
        private List<Shapes> _listShapes = new List<Shapes>();
        public ShapesCollection() { }
        public void Add(Shapes shape) => _listShapes.Add(shape);
        public void RemoveNewShape(Shapes shape) => _listShapes.Remove(shape);
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_listShapes).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public List<Shapes> ListShapes => _listShapes;
    }
}
