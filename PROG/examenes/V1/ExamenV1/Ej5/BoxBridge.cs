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

        public override BoxType Type => BoxType.BOXBRIDGE;

        public override void ApplyEffect(Game game)//cambiar, no se puede matemática ni saber la posición de la caja
        {
            game.VisitPlayers(player => 
            { 
                if (player.Position == _boxPosition)
                    player.Position = (_boxPosition == 8) ? 14 : 8;
            });
        }
    }
}
