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
        public Striker(string name, Team team, Position position) : base(name, team, position)
        {
        }

        public Striker(string name, Team team, int x, int y) : this(name, team, new Position(x, y))
        {
        }

        public override void ExecuteTurn(IField field)
        {
            if(field.GetBall().position == Position)
                _hasBall = true;
        }

        public override CharacterType GetCharacterType()
        {
            return CharacterType.STRIKER;
        }
    }
}
