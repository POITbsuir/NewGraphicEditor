using System.ComponentModel;

namespace NewGraphicEditor.Data
{
    public abstract class Shapes : INotifyPropertyChanged //абстрактный класс всех фигур, от него идет наследование всех остальных
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _nameShape;
        public string NameShape
        {
            get => _nameShape;
            set
            {
                _nameShape = value;
                OnPropertyChanged(nameof(NameShape));
            }
        }

        public abstract int[] point { get; }
        public abstract string nameShapes { get; }
        protected abstract int countPoint { get; }

        private string _info;
        public string Info
        {
            get => _info;
            set
            {
                _info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        public Shapes() { }
    }
}