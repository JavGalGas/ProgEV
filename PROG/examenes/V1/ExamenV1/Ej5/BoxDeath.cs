using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxDeath : Box
    {
        public BoxDeath(int value) : base(value)
        {
        }

        public override void ApplyEffect(Game game, Player player)
        {
            player.Box = game.GetBox(1);
        }
    }
}
