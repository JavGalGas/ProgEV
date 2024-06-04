using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class NormalPlayer : Player
    {
        public NormalPlayer(string name, int position) : base(name, position)
        {
        }

        public override void ExecuteTurn()
        {
            throw new NotImplementedException();
        }

        public override int ThrowDice()
        {
            throw new NotImplementedException();
        }
    }
}
