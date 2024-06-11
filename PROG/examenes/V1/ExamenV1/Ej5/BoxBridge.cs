using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxBridge : Box
    {
        public BoxBridge(int value) : base(value)
        {
        }

        public override void ApplyEffect(Game game, Player player)//cambiar, no se puede matemática ni saber la posición de la caja
        {
            player.Box = (_boxPosition == 8) ? game.GetBox(14) : game.GetBox(8);
            player.SimulateTurn(game);
        }
    }
}
