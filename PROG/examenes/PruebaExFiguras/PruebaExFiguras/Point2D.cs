using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExFiguras
{
    public class Point2D : LinearFigure
    {
        public double X { get;}
        public double Y { get;}

        public Point2D(double x, double y) : base("Punto")
        {
            X = x;
            Y = y;
        }

    }
}
