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
    public class Character : GameObject// hacer que sea como coche y tipos de coche
    {
        private long _id;
        private string _name = string.Empty;    
        private int _level;
        private int _xCoordinate;
        protected int _element;
        protected ClassCharacter _class;
        private Stadistics _stadistics;
        public long Id => _id;
        public string Name => _name;
        public int Element => _element;
        public int Level => _level;
        public int XCoordinate => _xCoordinate;
        public ClassCharacter Class => _class;
        public Stadistics Stadistics => _stadistics;

        protected Character(long id, string name, int level, int position, int element, ClassCharacter @class, Stadistics stadistics) : base()
        {
            _id = id;
            _name = name;
            _level = level;
            _xCoordinate = position;
            _element = element;
            _class = @class;
            _stadistics = stadistics;
        }
    }
}
