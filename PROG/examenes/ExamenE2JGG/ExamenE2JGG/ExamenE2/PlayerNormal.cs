using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenE2
{
    public class PlayerNormal : Player
    {
        public PlayerNormal(string name) : base(name)
        {
            _playerType = PlayerType.NORMAL;
        }

        public override int ThrowDice()
        {
            return Utils.GetRandomBetween(1,6);
        }
    }
}
