using System.Reflection.Metadata;

namespace Examen3
{
    public class Polygon : Shape
    {
        private Point2D[] _points = new Point2D[0];
        private bool _isClose = false;

        // Javi: Por qué -1????
        public int PointCount => _points.Length;
        public override bool HasArea => Area < 0;

        public override double Area => GetArea();

        public override double Perimeter => GetPerimeter();

        public override Point2D Center => GetCenter();

        public override Rect2D Rect => GetBoundingBox();
        public Polygon(string name, Color color) : base(name, color)
        {

        }
        public void Clear()
        {
            _points = new Point2D[0];
        }
        
        public void Close()
        {
            _isClose = true;
        }

        public void AddPoint(Point2D point)
        {
            if (point == null)
                return;
            Point2D[] points = new Point2D[_points.Length + 1];
            for( int i = 0; i < _points.Length -1; i++) 
            {
                Point2D pt = _points[i];
                points[i] = pt.Clone();
            }
            points[_points.Length] = point;
            _points = points;
        }
        public Point2D? GetCenter()
        {
            if (_isClose)
            {
                double ValuesX = 0.0;
                double ValuesY = 0.0;
                foreach(Point2D pt in _points)
                {
                    ValuesX += pt.X;
                    ValuesY += pt.Y;
                }
                return new Point2D
                {
                    X = ValuesX / PointCount,
                    Y = ValuesY / PointCount,
                    // Javi: EIN?!?!?!?!?
                };
            }
            return null;
        }
        public double GetArea()
        {
            if (_isClose)
            {
                return Utils.GetArea(_points);
            }
            return -1;
        }
        public double GetPerimeter()
        {
            double perimeter = Utils.GetPerimeter(_points);
            //if (_isClose && perimeter > 0)
            //{
            //    perimeter += Utils.GetDistance(_points[_points.Length-1], _points[0]);
            //}           
            //return perimeter;

            return (_isClose && perimeter > 0) ? perimeter + Utils.GetDistance(_points[_points.Length - 1], _points[0]) : perimeter;
        }
        public Rect2D GetBoundingBox()
        {
            return Utils.GetBoundingBox(_points);
        }
        public Point2D? GetPoint(int index)
        { 
            if (index < 0 || index > _points.Length - 1)
                return null;
            return _points[index];
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Javi: MAL!!!!!!!!!!!!!!!!!!!!!!!!!!!


        }


    }
}
