using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Canvas : ICanvas
    {
        private Color _color = new Color();

        public int Width => 1920;

        public int Height => 1080;

        public Color CurrentColor => _color;

        public void DrawCircle(Rect2D rectangle)
        {
            Console.WriteLine($"Dibujando el círculo {GetRectString(rectangle)} con el color {GetColorString()}");
        }

        private static string GetRectString(Rect2D rectangle)
        {
            return $"({rectangle.MinX}, {rectangle.MinY}, {rectangle.MaxX}, {rectangle.MaxY})";
        }

        private static string GetPolygonString(Point2D[] points)
        {
            string ret = "";
            foreach (var point in points)
                ret += "(" + point.X + "," + point.Y + ")";
            return ret;
        }

        private string GetColorString()
        {
            return $"({_color.R}, {_color.G}, {_color.B}, {_color.A})";
        }

        public void DrawPolygon(Point2D[] points)
        {
            Console.WriteLine($"Dibujando el polígono {GetPolygonString(points)} con el color {GetColorString()}");
        }

        public void DrawRectangle(Rect2D rectangle)
        {
            Console.WriteLine($"Dibujando el rectángulo {GetRectString(rectangle)} con el color {GetColorString()}");
        }

        public void SetColor(Color color)
        {
            if (color != null)
            {
                _color = color;
            }
        }
    }
}
