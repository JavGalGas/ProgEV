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

        public override void ApplyEffect(Game game, Player player)
        {
            player.Box = game.GetBox(53);
            player.SimulateTurn(game);
        }
    }
}
