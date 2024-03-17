using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public abstract class Shape : IShape
    {
        protected string name;
        private Color color;

        public Shape(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }

        public string Name 
        {
            get => name;
            set => name = value;
        }
        public Color Color 
        {
            get => color;
            set => color = value;
        }

        public bool HasArea => ShapeHasArea();

        public double Area => GetArea();

        public double Perimeter => GetPerimeter();

        public Point2D Center => GetCenter();

        public Rect2D Rect => GetRect();

        public abstract void Draw(ICanvas canvas);

        public abstract bool ShapeHasArea();
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract Point2D GetCenter();
        public abstract Rect2D GetRect();
    }
}
