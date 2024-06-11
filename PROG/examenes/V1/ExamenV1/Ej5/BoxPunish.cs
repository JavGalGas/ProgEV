﻿using System;
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

        public override void ApplyEffect(Game game, Player player)
        {
            player.DisabledTurns = _boxPosition / 13;
        }
    }
}
