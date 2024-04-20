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
        protected int _x;
        protected int _y;

        public Character(Position position) : base(position)
        {
        }
        public abstract void ExecuteTurn(IField field);
        public abstract CharacterType GetCharacterType();
        public virtual void SetPosition((int,int) position)
        {
            _x = position.Item1;
            _y = position.Item2;
        }
    }
}
