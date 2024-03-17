using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Utils
    {

        public static double GetDistance(Point2D a, Point2D b)
        {
            return (a == null || b == null) ? 0 : Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static Rect2D GetBoundingBox(Point2D[] points)
        {
            if(points == null)
                return new Rect2D();
            Rect2D BoundingBox = new Rect2D();
            double minX = points[0].X;
            double minY = points[0].Y;
            double maxX = points[0].X;
            double maxY = points[0].Y;
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i].X < minX) minX = points[i].X;
                if (points[i].Y < minY) minY = points[i].Y;
                if (points[i].X > maxX) maxX = points[i].X;
                if (points[i].Y > maxY) maxY = points[i].Y;
            }
            BoundingBox.MinX= minX;
            BoundingBox.MinY= minY;
            BoundingBox.MaxX= maxX;
            BoundingBox.MaxY= maxY;
            return BoundingBox;
        }

        public static double GetArea(Point2D[] points)
        {
            if (points == null)
                return 0;
            double area = 0;
            int lastPosition = points.Length -1;

            for (int i = 0; i < lastPosition; i++)
            {
                int j = i + 1;
                area += (points[i].Y+points[j].Y)* (points[i].X - points[j].X);
            }
            area += (points[lastPosition].Y + points[0].Y) * (points[lastPosition].X - points[0].X);
            return area/2;
        }
        public static double GetPerimeter(Point2D[] points)
        {
            if (points == null)
                return 0;
            double perimeter = 0;
            int lastPosition = points.Length - 1;
            for (int i = 0; i <lastPosition; i++)
            {
                int j = i + 1;
                perimeter += GetDistance(points[i], points[j]);
            }
            perimeter += GetDistance(points[lastPosition], points[0]);
            return perimeter;
        }
    }
}
