using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxPunish : Box
    {
        public BoxPunish(int value) : base(value)
        {
        }

        public override BoxType Type => BoxType.BOXPUNISH;

        public override void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                player.DisabledTurns = _boxPosition / 13;
            });
        }
    }
}
