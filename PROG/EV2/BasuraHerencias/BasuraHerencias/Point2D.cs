using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public class Point2D
    {
        public double x, y;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Point2D()
        {

        }
        public static bool Equals(Point2D p1, Point2D p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        //public bool Equals(Point2D other)
        //{
        //    return x == other.x && y == other.y;
        //}

        public override bool Equals(object? obj)
        {
            if(this == obj)
                return true;
            if(obj == null)
                return false;
            if(obj is not Point2D)
                return false;
            Point2D p = (Point2D)obj;
            return Equals(this, p);
        }

        //public bool Contains(T item)
        //{

        //}

        public static bool operator == (Point2D p1, Point2D p2)
        {
            return Equals(p1, p2);
        }
        public static bool operator !=(Point2D p1, Point2D p2)
        {
            return !Equals(p1, p2);
        }
    }
}
