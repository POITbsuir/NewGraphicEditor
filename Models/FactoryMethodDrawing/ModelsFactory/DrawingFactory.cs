using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.FactoryMethodDrawing;
using NewGraphicEditor.Models.FactoryMethodDrawing.FactoryDrawingPolygonsShape;
using NewGraphicEditor.Models.ModelsShapes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Media3D;
namespace NewGraphicEditor.Models
{
    public static class DrawerFactory //фабрика для отрисовки фигура (использует рефлекцию)
    {
        private static Dictionary<Type, IDrawableShape> _drawers = new Dictionary<Type, IDrawableShape>();

        //добаление трапеции
        private static string pathLibrary = @"C:\Users\Константин\Desktop\ООП\NewGraphicEditor\TrapeziumLibrary\bin\Debug\TrapeziumLibrary.dll";
        

        static DrawerFactory()
        {  
            _drawers[typeof(Lines)] = new LinesDrawer();
            _drawers[typeof(Triangle)] = new TriangleDrawing();
            _drawers[typeof(Ellipses)] = new EllipseDrawing();
            _drawers[typeof(Rectangles)] = new RectanglesDrawing();
            _drawers[typeof(ClientModel)] = new ClientModelFactory();
            try
            {
                var asm = Assembly.LoadFrom(pathLibrary);
                _drawers[asm.GetType("TrapeziumLibrary.Trapezium")] =
               (IDrawableShape)Activator.CreateInstance(asm.GetType("TrapeziumLibrary.TrapeziumFactory"));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
         
            

        }

        public static IDrawableShape GetDrawer(Shapes shape)
        {
            Type shapeType = shape.GetType();

            if (_drawers.ContainsKey(shapeType))
            {
                return _drawers[shapeType];
            }

            throw new ArgumentException($"Неопределенный тип, неизвестная фигура: {shapeType.Name}"); //проверяю есть ли ошибка
        }
    }
}