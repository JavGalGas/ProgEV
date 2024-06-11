using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class CheaterPlayer : Player
    {
        public CheaterPlayer(string name) : base(name)
        {

        }

        public override int ThrowDice()
        {
            return Utils.GetRandomBetween(1, 8);
        }
    }
}
