using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public enum ClassCharacter
    {
       TANK,
       ATTACKER,
       HEALER,
       THIEF,
       MAGE
    }
    public abstract class Character : GameObject// hacer que sea como coche y tipos de coche
    {
        protected long _id;
        private string _name = string.Empty;    
        private int _level;
        private int _xCoordinate;
        protected int _element;
        protected ClassCharacter _class;
        protected Stadistics _stad;

        public long Id => _id;
        public string Name => _name;
        public int Element => _element;
        public int Level => _level;
        public int XCoordinate => _xCoordinate;
        public ClassCharacter Class => _class;

        protected Character(long id, string name, int level, int position, int element, ClassCharacter @class) : base()
        {
            _id = id;
            _name = name;
            _level = level;
            _xCoordinate = position;
            _element = element;
            _class = @class;
        }

        public void LevelUp()
        {

        }
    }
}
