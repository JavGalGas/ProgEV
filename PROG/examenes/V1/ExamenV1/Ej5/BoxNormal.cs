using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxNormal : Box
    {
        public BoxNormal(int value) : base(value)
        {
        }

        public override BoxType Type => BoxType.BOXNORMAL;

        public override void ApplyEffect(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
