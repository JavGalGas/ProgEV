using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Defender : Player
    {
        public Defender(string name) : base(name)
        {
        }

        public override void ExecuteTurn(Match match)
        {
            if(HasBall)
            {
                match.VisitCharacters(defender =>
                {
                    
                });
            }
        }
    }
}
