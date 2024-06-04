using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExFiguras
{
    public abstract class PlainFigure : Figure, IPlainFigure
    {
        public override TypeFigure TypeFigure => TypeFigure.PLAIN;

        public abstract double GetArea();
    }
}
