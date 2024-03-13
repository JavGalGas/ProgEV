using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public class Circle2D : ShapeWithArea
    {
        private double _radius;

        public Circle2D(double radius, Point2D position, string name) : base(position, name)
        {
            _radius = radius;
        }

        public double GetRadius()
        {
            return _radius;
        }
        public void SetRadius(double radius)
        {
            _radius = radius;
        }
        public override double GetArea()
        { 
            return Math.Pow(_radius,2)*Math.PI;
        }

        public override ShapeType GetShapeType()
        {
            return ShapeType.CIRCLE2D;
        }
    }
}
