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

        public override BoxType Type => BoxType.BOXDICE;

        public override void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Position == _boxPosition)
                    player.Position = (_boxPosition == 27) ? 53 : 27;
            });
        }
    }
}
