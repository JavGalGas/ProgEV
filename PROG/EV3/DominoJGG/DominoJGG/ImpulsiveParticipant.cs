using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class ImpulsiveParticipant : Participant
    {
        public ImpulsiveParticipant(string name) : base(name)
        {
        }

        public override Domino ChooseDominoe()
        {
            throw new NotImplementedException();
        }
    }
}
