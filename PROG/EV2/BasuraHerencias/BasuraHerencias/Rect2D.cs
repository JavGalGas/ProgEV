using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public class Rect2D : ShapeWithArea
    {
        private Point2D _min = new Point2D(), _max = new Point2D();

        public Rect2D(Point2D position, string name) : base(position,name)
        {

        }

        public override double GetArea()//base * altura
        {
            return (_min.x + _max.x) * (_min.y + _max.y);
        }

        public void SetMin(Point2D point)
        {
            _min.x = point.x;
            _min.y = point.y;
        }
        public void SetMax(Point2D point)
        {
            _max.x = point.x;
            _max.y = point.y;
        }
        public Point2D GetMin(Point2D point)
        {
            return _min;
        }
        public Point2D GetMax(Point2D point)
        {
            return _max;
        }
        public double GetHeight()
        {
            double height = 0;
            return height;
        }
        public double GetWidth()
        {
            double width = 0;
            return width;
        }

        public override ShapeType GetShapeType()
        {
            return ShapeType.RECT2D;
        }
    }
}
