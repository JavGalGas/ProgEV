namespace Examen3
{
    public class Utils
    {
        public static double GetDistance(Point2D a, Point2D b)
        {
            if (a == null || b == null) 
                return 0;
            double ax = a.X - b.X;
            double ay = a.Y - b.Y;
            double raiz = Math.Sqrt(ax * ax + ay * ay);
          
            return raiz;
        }

        public static Rect2D GetBoundingBox(Point2D[] points)
        {
            Rect2D rect = new Rect2D();
            if (points == null)
                return rect;
            if (points.Length == 0)
                return rect;
            for (int i = 0; i < points.Length; i++) 
            {
                Point2D pt = points[i];
                if (pt == null) 
                    continue;
                // Javi: Esto está mal
                if (pt.X < rect.MinX)
                    rect.MinX = pt.X;
                if (pt.X > rect.MaxX)
                     rect.MaxX = pt.X;
                if (pt.Y < rect.MinY)
                     rect.MinY = pt.Y;
                if (pt.Y > rect.MaxY)
                    rect.MaxY = pt.Y;
            }
            return rect;
        }
        public static double GetArea(Point2D[] points)
        {
            double area = 0;
            for (int i = 0;i < points.Length - 1;i++) 
            {
                Point2D pt = points[i];
                Point2D pt2 = points[i + 1];
                if (pt == null || pt2 == null)
                    continue;
                area += (pt.Y + pt2.Y) * (pt.X - pt2.X);  
            }
            area += (points[points.Length - 1].Y + points[0].Y) * (points[points.Length - 1].X - points[0].X);
            return area * 0.5;
        }
        public static double GetPerimeter(Point2D[] points) 
        {
            double perimeter = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                Point2D pt = points[i];
                Point2D pt2 = points[i + 1];
                if (pt == null || pt2 == null)
                    continue;
                // Javi: Mal
                perimeter += GetDistance(pt,pt2);
            }
            return perimeter;
        } 


    }
}
