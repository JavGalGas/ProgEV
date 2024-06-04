using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class QuickPlayer : Player
    {
        private int _diceCount = 1;
        public QuickPlayer(string name, int position, int diceCount) : base(name, position)
        {
            _diceCount = diceCount;
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
