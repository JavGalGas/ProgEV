using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public interface IShape
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        bool HasArea { get; }
        double Area { get; }
        double Perimeter { get;}
        Point2D Center { get; }
        Rect2D Rect { get; }
        public void Draw(ICanvas canvas);
    }
}
