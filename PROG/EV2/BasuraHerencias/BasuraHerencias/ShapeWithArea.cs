using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public abstract class ShapeWithArea : Shape
    {
        protected ShapeWithArea(Point2D position, string name) : base(position, name)
        {
            
        }
        //public override double GetArea()
        //{
        //    return 
        //}
        public override bool HasArea()
        {
            return true;
        }
    }
}
