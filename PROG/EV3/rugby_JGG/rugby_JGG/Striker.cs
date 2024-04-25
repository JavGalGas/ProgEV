using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rugby_JGG
{
    public class Striker : Player
    {
        private double _abilityToStealBall;
        public Striker(string name, Team team, Position position, double abilityToStealBall) : base(name, team, position)
        {
            _abilityToStealBall = abilityToStealBall;
            if (abilityToStealBall < 0.4)
                _abilityToStealBall = 0.4;
            if (abilityToStealBall > 0.6)
                _abilityToStealBall = 0.6;
        }

        public Striker(string name, Team team, int x, int y, double abilityToStealBall) : this(name, team, new Position(x, y), abilityToStealBall)
        {
        }

        public override void ExecuteTurn(IField field)
        {
            if(field.GetBall().Position! == Position!)
                _hasBall = true;
        }

        public override CharacterType GetCharacterType()
        {
            return CharacterType.STRIKER;
        }
    }
}
