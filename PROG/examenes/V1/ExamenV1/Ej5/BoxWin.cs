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

        public override void ApplyEffect(Game game, Player player)
        {
            game._winner = player;
        }
    }
}
