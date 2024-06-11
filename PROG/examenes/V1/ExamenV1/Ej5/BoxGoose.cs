using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxGoose : Box
    {
        public BoxGoose(int value) : base(value)
        {
        }

        public override void ApplyEffect(Game game, Player player)
        {
            int newBoxIndex = player.Box!.BoxPosition + 6;
            player.Box = game.GetBox(newBoxIndex);
            player.SimulateTurn(game);
        }
    }
}
