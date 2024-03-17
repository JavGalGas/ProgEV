namespace Examen3
{
    public class Polygon : Shape
    {
        private Point2D[] _points = new Point2D[0];
        private bool _isClose = false;

        // Javi: Por qué -1????
        public int PointCount => _points.Length - 1;
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
        public Point2D GetCenter()
        {
            if (_isClose)
            {
                return new Point2D
                {
                    // Javi: EIN?!?!?!?!?
                    X = Perimeter / 2,
                    Y = Perimeter / 2,
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
            return Utils.GetPerimeter(_points);
        }

        public Rect2D GetBoundingBox()
        {
            return Utils.GetBoundingBox(_points);
        }
        public Point2D? GetPoint(int index)
        { 
            if (index < 0 || index > _points.Length - 1)
                return null;
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
            for (int i = 0; i < _points.Length -1; i++)
            {
                Point2D pt = _points[i];
                if (index == pt.X || index == pt.Y)
                    return pt;
            }
            return null;
            
        }


    }
}
