using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Point : Shape
    {
        Point2D point;
        public Point(Point2D point,string name, Color color) : base(name, color)
        {
            this.point = point;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(Color);
        }

        public override double GetArea()
        {
            return 0;
        }

        public override Point2D GetCenter()
        {
            return point;
        }

        public override double GetPerimeter()
        {
            return 0;
        }

        public override Rect2D GetRect()
        {
            Rect2D rect = new Rect2D();
            rect.MinX = point.X;
            rect.MinY = point.Y;
            rect.MaxX = point.X;
            rect.MaxY = point.Y;
            return rect;
        }

        public override bool ShapeHasArea()
        {
            return false;
        }
    }
}
