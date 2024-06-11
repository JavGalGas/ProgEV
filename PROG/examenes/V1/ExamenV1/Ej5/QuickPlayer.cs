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
        public QuickPlayer(string name, int diceCount) : base(name)
        {
            if (diceCount <= 0 || diceCount > 3)
                throw new ArgumentOutOfRangeException(nameof(diceCount));
            _diceCount = diceCount;
        }


        public override int ThrowDice()
        {
            int result = 0;
            for (int i = 0; i < _diceCount; i++)
            {
                int aux = Utils.GetRandomBetween(1, 6);
                if (aux > result)
                    result = aux;
            }
            return result;
        }
    }
}
