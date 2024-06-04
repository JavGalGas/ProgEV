namespace PruebaExFiguras
{
    public abstract class Figure : IFigure
    {
        public abstract TypeFigure TypeFigure { get; }
        public abstract string Name { get; protected set; }

        protected Figure(string name) 
        {
            Name = name;
        }

        public abstract double GetPerimeter();

        public static double GetDistance(Point2D a, Point2D b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X,2) + Math.Pow(b.Y -a.Y, 2));
        }
    }
}