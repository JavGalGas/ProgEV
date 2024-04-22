using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public enum CharacterType
    {
        STRIKER,
        DEFENDER,
        SP_DEFENDER,
        DEMENTOR
    }
    public abstract class Character : GameObject
    {

        public Character(Position position) : base(position)
        {
        }
        public abstract void ExecuteTurn(IField field);
        public abstract CharacterType GetCharacterType();
        public virtual void SetPosition(Position position)// revisar
        {
            base.Position = position;
        }
    }
}
