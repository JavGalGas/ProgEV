namespace Examen3
{
    public abstract class Shape : IShape
    {
        protected string _name;
        private Color _color;
        public string Name { get => _name; set => SetName(value); }
        public Color Color { get => _color; set => SetColor(value); }

        // Javi: No es lo que pedía, ..., pero lo acepto
        public abstract bool HasArea { get; }

        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public abstract Point2D Center { get; }

        public abstract Rect2D Rect { get; }

        private bool _hasArea;
        public bool HasArea2 
        {
            get 
            { 
                return _hasArea; 
            }
            set 
            { 
                _hasArea = GetHasArea(); 
            }
        }

        public Shape(string name, Color color)
        {
            _name = name;
            _color = color;
        }

        public void SetName(string name) 
        {
            _name = name;
        }
        public void SetColor(Color color)
        {
            if (color == null)
                return;
            _color = color;
        }
        public virtual void Draw(ICanvas canvas)
        {
            if (canvas != null && _color != null)
                canvas.SetColor(_color);
        }

        public abstract bool GetHasArea();
    }
}
