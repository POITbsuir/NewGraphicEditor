using NewGraphicEditor.Data;
using NewGraphicEditor.Models;
using NewGraphicEditor.Models.ModelsShapes;
using NewGraphicEditor.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
namespace NewGraphicEditor.ViewModels
{
    public class ApplicationMainClass : INotifyPropertyChanged
    {
        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        // Определение фигур
        private Shapes _shape;
        public Shapes Shape
        {
            get => _shape;
            set
            {
                 _shape = value;
                 _currentPointIndex = 0; //индекс для отрисовки
                 OnPropertyChanged(nameof(Shape));
                
            }
        }
        public ShapesCollection<Shapes> CollectionShapes { get; set; }  // Список для хранения объектов

        // Поля для координат
        private int _inputX;
        public int InputX
        {
            get => _inputX;
            set
            {
                _inputX = value;
                OnPropertyChanged(nameof(InputX));
            }
        }

        private int _inputY;
        public int InputY
        {
            get => _inputY;
            set
            {
                _inputY = value;
                OnPropertyChanged(nameof(InputY));
            }
        }

        // Команда для добавления точки
        private ApplicationCommands _addPointCommand;
        private int _currentPointIndex = 0;

        public ApplicationCommands AddPointCommand
        {
            get
            {
                return _addPointCommand ?? (_addPointCommand = new ApplicationCommands(obj =>
                {
                    var canvas = obj as Canvas;

                    if (canvas != null && Shape != null)
                    {
                        ProcessShape(canvas, Shape);
                    }
                }));
            }
        }

        //реализация третьей таски (сериализация коллекции, добавление нового элемента, удаление элементов из коллекции)

        private ApplicationCommands _serializerCollection;

        private FileSystem _fileSystem = new FileSystem();
        private string _filePath = @"C:\Users\Константин\Desktop\ООП\NewGraphicEditor\NewGraphicEditor\Data\MyCollectionShapes.xml";
        public ApplicationCommands SerializerCollection
        {
            get 
            {
                return _serializerCollection ?? (_serializerCollection = new ApplicationCommands(obj =>
                {
                    _fileSystem.SaveToFile(_filePath, CollectionShapes.ListShapes); //исправить
                }));
            }
        }

        private ApplicationCommands _addNewShape;
        public ApplicationCommands AddNewShape
        {
            get 
            {
                return _addNewShape ?? (_addNewShape = new ApplicationCommands(obj =>
                {
                    //ClientModel clientModel = new ClientModel();
                    //CollectionShapes.Add(clientModel);
                    //Shape = clientModel;
                    MessageBox.Show("Модель добавлена"); //для отслеживания правильности работы кнопки и команды

                }));
            }
        }

        private ApplicationCommands _deleteShape;
        public ApplicationCommands DeleteShape
        {
            get
            {
                return _deleteShape ?? (_deleteShape = new ApplicationCommands(obj =>
                {
                    //реализация удаления их списка фигуры
                    Shapes shape = obj as Shapes;
                    if (shape != null)
                    {
                        CollectionShapes.RemoveNewShape(shape);
                        MessageBox.Show($"Удалена фигура {shape.NameShape}");
                    }
                }, (obj) => CollectionShapes.ListShapes.Count > 0));

            }
        }


      
        

        // Метод для обработки добавления точек
        private void ProcessShape(Canvas canvas, Shapes shape)
        {
            int pointsNeeded = 0;

            if (shape is Lines)
                pointsNeeded = 4; 
            if(shape is Triangle)
                pointsNeeded = 6;
            if (shape is Ellipses)
                pointsNeeded = 6;
            if(shape is Rectangles)
                pointsNeeded = 8;
            if (shape is ClientModel)
                pointsNeeded =6;

            //вынести это нужно(но сейчас лень, так что будет пока что так)
            string pathLibrary = @"C:\Users\Константин\Desktop\ООП\NewGraphicEditor\TrapeziumLibrary\bin\Debug\TrapeziumLibrary.dll";
            Assembly asm = Assembly.LoadFrom(pathLibrary);
            Type type = asm.GetType("TrapeziumLibrary.Trapezium");
            if (type != null)
            {
                if (shape.GetType().Name == "Trapezium" || shape.GetType().FullName == "TrapeziumLibrary.Trapezium")
                {
                    pointsNeeded = 8;
                }


            }

            if (_currentPointIndex < shape.point.Length)
            {
                shape.point[_currentPointIndex] = InputX;
                shape.point[_currentPointIndex + 1] = InputY;
                _currentPointIndex += 2;

                //Для обновлдения информации о текущем состоянии
                shape.Info = $"Добавлена точка ({InputX}, {InputY}). Осталось точек: {(pointsNeeded - _currentPointIndex) / 2}";

                if (_currentPointIndex >= pointsNeeded)
                {
                    var drawer = DrawerFactory.GetDrawer(shape);
                    if (drawer == null)
                    {
                        shape.Info = "Ошибка: не найден класс для отрисовки фигуры";
                        return;
                    }

                    drawer.Draw(canvas, shape);

                    _currentPointIndex = 0;
                    shape.Info = "Фигура нарисована!/Или возникла ошибка!";
                    InputX = 0;
                    InputY = 0;
                }
            }
            else
            {
                shape.Info = "Ошибка: превышен лимит точек для фигуры";
            }
        }

        public ApplicationMainClass()
        {
            CollectionShapes = new ShapesCollection<Shapes>()
            {
                new Lines() { NameShape = "Отрезок" },
                new Triangle() {NameShape = "Треугольник" },
                new Ellipses() {NameShape = "Эллипс" },
                new Rectangles() {NameShape = "Прямоугольник" }
            };

              //реализация 4-ой таски
            string pathLibrary = @"C:\Users\Константин\Desktop\ООП\NewGraphicEditor\TrapeziumLibrary\bin\Debug\TrapeziumLibrary.dll";

            try
            {
                Assembly asm = Assembly.LoadFrom(pathLibrary);
                Type type = asm.GetType("TrapeziumLibrary.Trapezium");
                if (type != null)
                {
                    var Trapezium = (Shapes)Activator.CreateInstance(type);
                    Trapezium.NameShape = "Трапеция";
                    CollectionShapes.Add(Trapezium);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}