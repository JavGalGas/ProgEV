using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Circle : Shape
    {
        private Point2D _center;
        private double Radio {get; set;}
        public Circle(Point2D point, double radio, string name, Color color) : base(name, color)
        {
            _center = point;
            Radio = radio;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(Color);
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radio,2);
        }

        public override Point2D GetCenter()
        {
            return _center;
        }

        public override double GetPerimeter()
        {
            return 2*Math.PI*Radio;
        }

        public override Rect2D GetRect()
        {
            Rect2D rect = new Rect2D();
            rect.MinX = _center.X-Radio;
            rect.MinY = _center.Y-Radio;
            rect.MaxX = _center.X+Radio;
            rect.MaxY = _center.Y+Radio;
            return rect;
        }

        public override bool ShapeHasArea()
        {
            return true;
        }
    }
}
