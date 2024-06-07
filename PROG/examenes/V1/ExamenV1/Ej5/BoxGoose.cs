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

        public override BoxType Type => BoxType.BOXGOOSE;

        public override void ApplyEffect(Game game)
        {
            game.VisitPlayers(player =>
            {
                if (player.Position == _boxPosition)
                {
                    player.Position += 6;
                    player.SimulateTurn();
                }
            });
        }
    }
}
