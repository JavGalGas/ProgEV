using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class SpecialDefender : Defender
    {
        public SpecialDefender(string name, Team team, Position position, double abilityToStealBall) : base(name, team, position, abilityToStealBall)
        {
        }

        public SpecialDefender(string name, Team team, int x, int y, double abilityToStealBall) : this(name, team, new Position(x,y), abilityToStealBall)
        {
        }

        public override void ExecuteTurn(IField field)
        {
            
        }

        public override CharacterType GetCharacterType()
        {
            return CharacterType.SP_DEFENDER;
        }
    }
}
