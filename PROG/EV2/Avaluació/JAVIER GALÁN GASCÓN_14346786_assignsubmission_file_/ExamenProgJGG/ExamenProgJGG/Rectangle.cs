using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Rectangle : Shape
    {
        private Rect2D rect;
        public Rectangle(Rect2D rect, string name, Color color) : base(name, color)
        {
            this.rect = rect;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(Color);
        }

        public override double GetArea()
        {
            return rect.Area;
        }

        public override Point2D GetCenter()
        {
            return rect.Center;
        }

        public override double GetPerimeter()
        {
            double segment1 = rect.MaxX - rect.MinX;
            double segment2 = rect.MaxY - rect.MinY;
            return 2*segment1 + 2*segment2;
        }

        public override Rect2D GetRect()
        {
            return rect;
        }

        public override bool ShapeHasArea()
        {
            return true;
        }

        public Point2D? GetBorder(int index) 
        {
            if (index < 0 || index >= 3)
                return null;
            Point2D result = new Point2D();
            if (index == 0)
            {
                result.X = rect.MinX;
                result.Y = rect.MaxY;
            }
            else if (index == 1)
            {
                result.X = rect.MaxX;
                result.Y = rect.MaxY;
            }
            else if (index == 2)
            {
                result.X = rect.MinX;
                result.Y = rect.MinY;
            }
            else if (index == 3)
            {
                result.X = rect.MaxX;
                result.Y = rect.MinY;
            }
            return result;
        }
    }
}
