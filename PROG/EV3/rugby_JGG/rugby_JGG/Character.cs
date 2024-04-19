using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public abstract class Character
    {
        protected int _x;
        protected int _y;

        public Character()
        {
        }
        public abstract void ExecuteTurn(Match match);

        public virtual void SetPosition((int,int) position)
        {
            _x = position.Item1;
            _y = position.Item2;
        }
    }
}
