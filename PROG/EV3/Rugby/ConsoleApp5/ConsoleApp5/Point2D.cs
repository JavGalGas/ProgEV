namespace ConsoleApp5
{
    public class Coordenadas
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordenadas()
        {
        }

        public Coordenadas(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double GetDistancia(Coordenadas coords)
        {
            int dx = coords.X - X;
            int dy = coords.Y - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static bool operator == (Coordenadas a, Coordenadas b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator != (Coordenadas a, Coordenadas b)
        {
            return !(a == b);
        }
    }
}
