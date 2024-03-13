using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public class PointShape2D : ShapeWithoutArea
    {
        private List<Point2D> _points = new List<Point2D>();

        public void AddPoint()
        {
            _points.Add(_position);
        }

        public override double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
