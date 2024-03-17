namespace Examen3
{
    public class Segment : Shape
    {
        public Point2D MinP = new Point2D();
        public Point2D MaxP = new Point2D();
        public override bool HasArea => false;

        public override double Area => 0;

        public override double Perimeter => GetPerimeter();

        public override Point2D Center => GetCenter();

        public override Rect2D Rect => GetRect();

        public Segment(string name, Color color) : base(name, color)
        {
        }

        public double GetPerimeter()
        {
            return Utils.GetDistance(MinP, MaxP);
        }
        public Point2D GetCenter()
        {
            return new Point2D()
            {
                X = MaxP.X - MinP.X,
                Y = MaxP.Y - MinP.Y,
            };
        }
        public Rect2D GetRect()
        {
            return new Rect2D()
            {
                MinX = MinP.X,
                MaxX = MaxP.X,
                MinY = MinP.Y,
                MaxY = MaxP.Y
            };
        }
    }
}
