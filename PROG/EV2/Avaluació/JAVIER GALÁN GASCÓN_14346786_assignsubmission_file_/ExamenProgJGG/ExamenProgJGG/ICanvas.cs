using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public interface ICanvas
    {
        int Width { get; }
        int Height { get; }
        Color CurrentColor { get; }

        void SetColor(Color color);
        void DrawRectangle(Rect2D rectangle);
        void DrawCircle(Rect2D rectangle);
        void DrawPolygon(Point2D[] points);
    }
}
