using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaExFiguras
{
    public enum TypeFigure
    {
        LINEAR,
        PLAIN
    }

    public interface IFigure
    {
        public TypeFigure TypeFigure { get; }
        string Name { get; }
        double GetPerimeter();
    }
}
