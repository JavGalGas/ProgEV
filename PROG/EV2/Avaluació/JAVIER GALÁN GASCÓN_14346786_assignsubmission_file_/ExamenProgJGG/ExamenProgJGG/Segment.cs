using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Segment : Shape
    {
        private Point2D point1;
        private Point2D point2;
        public Segment(Point2D point1, Point2D point2, string name, Color color) : base(name, color)
        {
            this.point1 = point1;
            this.point2 = point2;
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
            Point2D center = new Point2D();
            center.X = point2.X-point1.X;
            center.Y = point2.Y-point1.Y;
            return point1;
        }

        public override double GetPerimeter()
        {
            Point2D[] points = new Point2D[2];
            points[0] = point1;
            points[1] = point2;
            return Utils.GetPerimeter(points);
        }

        public override Rect2D GetRect()
        {
            Rect2D rect = new Rect2D();
            if(point1.X < point2.X)
            {
                rect.MinX = point1.X;
                rect.MaxX = point2.X;
            }
            else
            {
                rect.MinX = point2.X;
                rect.MaxX = point1.X;
            }
            if (point1.Y < point2.Y)
            {
                rect.MinY = point1.Y;
                rect.MaxY = point2.Y;
            }
            else
            {
                rect.MaxY = point1.Y;
                rect.MinY = point2.Y;
            }
            return rect;
        }

        public override bool ShapeHasArea()
        {
            return false;
        }
    }
}
