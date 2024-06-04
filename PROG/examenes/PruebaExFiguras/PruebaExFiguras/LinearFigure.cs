using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExFiguras
{
    public abstract class LinearFigure : Figure
    {
        public override TypeFigure TypeFigure => TypeFigure.LINEAR;

        public LinearFigure(string name) : base(name) 
        {
            
        }
        public override double GetPerimeter()
        {
            return 0;
        }
    }
}
