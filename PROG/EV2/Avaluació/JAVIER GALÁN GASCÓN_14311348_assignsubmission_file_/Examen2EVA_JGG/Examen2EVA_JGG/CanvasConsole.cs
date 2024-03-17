using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EVA_JGG
{
    public class CanvasConsole : ICanvas
    {
        private int Width;

        private int Height;

        public Color CurrentColor;

        public CanvasConsole(int width, int height, Color color)
        {
            Width = width;
            Height = height;

        }

        public void DrawCircle(Rect2D rectangle)
        {
            // Javi: Comprueba los null
            Console.WriteLine($"Pintando un círculo de color ({CurrentColor.R}, {CurrentColor.G}, {CurrentColor.B}, {CurrentColor.A}) en las coordenadas ({rectangle.x}, {rectangle.y},{rectangle.x2},{rectangle.y2})");
        }

        public void DrawPolygon(Point2D[] points)
        {
            // Javi:  Lo mismo
            Console.WriteLine($"Pintando un rectángulo de color ({CurrentColor.R}, {CurrentColor.G}, {CurrentColor.B}, {CurrentColor.A}) en las coordenadas ({rectangle.x}, {rectangle.y},{rectangle.x2},{rectangle.y2})");
        }
        public void DrawRectangle(Rect2D rectangle)
        {
            Console.WriteLine($"Pintando un rectángulo de color ({CurrentColor.R}, {CurrentColor.G}, {CurrentColor.B}, {CurrentColor.A}) en las coordenadas ({rectangle.x}, {rectangle.y},{rectangle.x2},{rectangle.y2})");
        }
        public void SetColor(Color color)
        { 
            CurrentColor = color;
        }
    }
}
