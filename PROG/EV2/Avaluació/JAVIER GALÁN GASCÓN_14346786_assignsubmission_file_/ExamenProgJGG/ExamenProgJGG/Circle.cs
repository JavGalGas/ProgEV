namespace Examen3
{
    public class Circle : Shape
    {
        public double Radio {  get; set; }
        public override bool HasArea => Area > 0;

        public override double Area => GetArea();

        public override double Perimeter => GetPerimeter();

        public override Point2D Center => GetCenter();

        public override Rect2D Rect => throw new NotImplementedException();

        public Circle(string name, Color color) : base(name, color)
        {
        }

        public double GetArea()
        {
            return Math.PI * (Radio * Radio);
        }
        public double GetPerimeter()
        {
            return 2* Math.PI * (Radio * Radio);
        }
        public Point2D GetCenter()
        {
            // Javi: Mal
            return new Point2D()
            {
                X = 0,
                Y = Radio
            };
        }
        public Rect2D GetRect() 
        {
            // Javi: Cálculos erróneos
            return new Rect2D()
            {
                MinX = (Radio * Math.PI)/3,
                MaxX = Radio,
                MinY = 0,
                MaxY = (Radio * Math.PI)/2
            };
        }
        
    }
}
