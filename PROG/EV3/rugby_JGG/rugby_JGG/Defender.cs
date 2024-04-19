using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Defender : Player
    {
        public Defender(string name, Team team, Position position) : base(name, team, position)
        {
        }

        public override void ExecuteTurn(IField field)
        {
            if(HasBall)
            {
                
            }
        }
    }
}
