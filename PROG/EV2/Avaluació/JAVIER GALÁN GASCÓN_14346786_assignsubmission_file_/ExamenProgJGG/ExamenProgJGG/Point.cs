using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{
    public class Point : Shape
    {
        public double X, Y;
        public override bool HasArea => Area > 0;

        public override double Area =>0;

        public override double Perimeter => 0;

        public override Point2D Center => new Point2D()
        {
            X = this.X,
            Y = this.Y,
        };

        public override Rect2D Rect => new Rect2D()
        {
            MinY = Y - 1,
            MaxY = Y + 1,
            MinX = X - 1,
            MaxX = X + 1,
        };
        public Point(string name, Color color) : base(name, color)
        {
        }


    }
}
