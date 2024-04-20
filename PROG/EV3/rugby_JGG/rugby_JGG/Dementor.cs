using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Dementor : Character
    {
        public Dementor(Position position) : base(position)
        {

        }
        public override void ExecuteTurn(IField field)
        {
            
        }

        public override CharacterType GetCharacterType()
        {
            return CharacterType.DEMENTOR;
        }
    }
}
