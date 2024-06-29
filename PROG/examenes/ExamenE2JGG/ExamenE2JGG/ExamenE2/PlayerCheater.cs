using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenE2
{
    public class PlayerCheater : Player
    {
        public PlayerCheater(string name) : base(name)
        {
            _playerType = PlayerType.CHEATER;
        }

        public override int ThrowDice()
        {
            return Utils.GetRandomBetween(1,8);
        }

    }
}
