using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Striker : Player
    {
        public Striker(string name, Team team, Position position) : base(name, team, position)
        {
        }

        public override void ExecuteTurn(IField field)
        {
            
        }
    }
}
