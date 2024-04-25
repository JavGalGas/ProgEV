using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Position
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public double GetDistance(Position coords)
        {
            int dx = coords.X - X;
            int dy = coords.Y - Y;
            return Math.Sqrt(dx * dx - dy * dy);
        }

        public static bool operator == (Position a, Position b)
        {
            return a.X  == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Position a, Position b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
