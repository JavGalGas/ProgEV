using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenE2
{
    public class PlayerQuick : Player
    {
        private int _numDices;

        public int NumDices => _numDices;
        public PlayerQuick(string name, int numDices) : base(name)
        {
            if (numDices < 1 || numDices > 3)
                throw new ArgumentOutOfRangeException(nameof(numDices));
            _numDices = numDices;
            _playerType = PlayerType.QUICK;
        }

        public override int ThrowDice()
        {
            int result = 0;
            int throwValue;
            for (int i = 0; i < _numDices; i++)
            {
                throwValue = Utils.GetRandomBetween(1, 6);
                if (result < throwValue)
                    result = throwValue;
            }
            return result;
        }
    }
}
