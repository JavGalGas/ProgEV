using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Polygon : Shape
    {
        private Point2D[] points;
        private int PointCount { get => points.Length; }
        private bool closed = false;
        public Polygon(Point2D[] points, string name, Color color) : base(name, color)
        {
            this.points = points;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(Color);
        }

        public override double GetArea()
        {
            return (closed) ? Utils.GetArea(points) : 0;
        }

        public override Point2D GetCenter()
        {
            return Utils.GetBoundingBox(points).Center;
        }

        public override double GetPerimeter()
        {
            return Utils.GetPerimeter(points);
        }

        public override Rect2D GetRect()
        {
            return Utils.GetBoundingBox(points);
        }

        public override bool ShapeHasArea()
        {
            return closed && points.Length > 0;
        }

        public void Clear()
        {
            points = new Point2D[0];
        }

        public void Close()
        {
            closed = true;
        }

        public void AddPoint(Point2D point)
        {
            int length = PointCount;
            int newlength = length+1;
            Point2D[] newPolygon = new Point2D[newlength];
            for (int i = 0; i < length; i++)
                newPolygon[i] = points[i];
            newPolygon[length] = point;
            points = newPolygon;
        }

        public Point2D? GetPointAt(int index) 
        {
            return (index < 0 || index >= PointCount) ? null : points[index];
        }
    }
}
