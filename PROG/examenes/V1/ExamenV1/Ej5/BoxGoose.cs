using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxGoose : Box
    {
        public BoxGoose(int value) : base(value)
        {
        }

        public override BoxType Type => BoxType.BOXGOOSE;
    }
}
