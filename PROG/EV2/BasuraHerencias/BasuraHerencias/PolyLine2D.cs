using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public class PolyLine2D : ShapeWithArea
    {
        private List<Point2D> _points = new List<Point2D>();
        private bool _isClosed;

        public PolyLine2D(Point2D position, string name) : base(position, name)
        {
            
        }
        public void AddPoint(Point2D point)
        {

        }
        public int GetPointsCount()
        {
            return _points.Count;
        }
        public Point2D? GetPointAt(int index)
        {
            if(index < 0 || index >= GetPointsCount())
                return null;
            return _points[index];
        }
        public void SetPointAt(int index, Point2D point2D)
        {
            if(index < 0 || index >= GetPointsCount())
                return;
            _points[index] = point2D;
        }
        public void RemovePointAt()//puede que Point2D
        {
            
        }
        public void SetClosedPolylineAttribute()
        {
            if(_points.Count <=0)
                return;
            Point2D initPoint = _points[0];
            Point2D finalPoint = _points[^1];

            if(initPoint.Equals(finalPoint))
                _isClosed = true;
        }

        public override bool HasArea()
        {
            return base.HasArea();
        }
        public override double GetArea()
        {
            if(_isClosed)
            {
                double a = 0;
                double p = 0;
                return (a * p) / 2;
            }
            return -1;
        }


        public override ShapeType GetShapeType()
        {
            return ShapeType.POLYLINE2D;
        }
    }
}
