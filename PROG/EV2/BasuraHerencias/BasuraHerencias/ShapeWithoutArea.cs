using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public abstract class ShapeWithoutArea : Shape
    {
        protected ShapeWithoutArea(Point2D position, string name) : base(position, name)
        {

        }
        public override bool HasArea()
        {
            return false;
        }
    }
}
