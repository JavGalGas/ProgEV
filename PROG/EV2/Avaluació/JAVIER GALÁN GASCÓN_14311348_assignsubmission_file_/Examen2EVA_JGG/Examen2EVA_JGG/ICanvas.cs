using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EVA_JGG
{
    public interface ICanvas
    {
        // Javi: Por que has usado default properties!?!?!?!?
        int Width 
        { 
            get => 10; 
        }
        int Height 
        { 
            get => 2; 
        }
        Color CurrentColor 
        {
            get (0,0,0,0);
        }

        public void SetColor(Color color);
        public void DrawRectangle(Rect2D rectangle);
        public void DrawCircle(Rect2D rectangle);
        public void DrawPolygon(Point2D[] points);
    }
}
