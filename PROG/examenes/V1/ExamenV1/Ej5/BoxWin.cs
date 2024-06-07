using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class BoxWin : Box
    {
        public BoxWin(int value) : base(value)
        {
        }

        public override BoxType Type => BoxType.BOXWIN;

        public override void ApplyEffect(Game game)
        {
            game.VisitPlayers(player => 
            {
                if (player.Position == _boxPosition)
                    game._winner = player; 
            });
        }
    }
}
