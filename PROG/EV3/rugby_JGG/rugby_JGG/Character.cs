using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public abstract class Character
    {
        private int _x;
        private int _y;

        public Character(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public abstract void ExecuteTurn();
    }
}
