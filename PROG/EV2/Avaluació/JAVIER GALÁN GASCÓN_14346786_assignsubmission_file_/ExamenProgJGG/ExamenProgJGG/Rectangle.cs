namespace Examen3
{
    public class Rectangle : Shape
    {
        public double MinX;
        public double MinY;
        public double MaxX;
        public double MaxY;

        public override bool HasArea => Area > 0;

        public override double Area => GetArea();

        public override double Perimeter => MinY + MaxY + MaxX + MinX;

        public override Point2D Center => GetCenter();

        public override Rect2D Rect => GetRect();


        public Rectangle(string name, Color color, double MinX, double MinY, double MaxX, double MaxY) : base(name, color)
        {
            this.MinY = MinY;
            this.MaxY = MaxY;
            this.MaxX = MaxX;
            this.MinX = MinX;
        }

        // Javi: La esquina es un punto
        public double GetEsquina(double index)
        {
            if (index == MinY)
                return MinY;
            if (index == MinX)
                return MinX;
            if (index == MaxY)
                return MaxY;
            if (index == MaxX)
                return MaxX;
            return -1.0;
        }
        public double GetArea()
        {
            return (MaxX * MaxY);
        }
        public Point2D GetCenter()
        {
            return new Point2D()
            {
                X = (MaxX - MinX),
                Y = (MaxY - MinY)
            };
        }
        public Rect2D GetRect()
        {
            return new Rect2D()
            {
               MinY = MinY + 1,
               MaxY = MaxY + 1,
               MinX = MinX + 1,
               MaxX = MaxX + 1,
            };
        }
    }
}
