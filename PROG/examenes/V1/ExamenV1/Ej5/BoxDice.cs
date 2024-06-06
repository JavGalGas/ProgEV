using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxDice : Box
    {
        public BoxDice(int value) : base(value)
        {
        }

        public override BoxType Type => BoxType.BOXDICE;
    }
}
