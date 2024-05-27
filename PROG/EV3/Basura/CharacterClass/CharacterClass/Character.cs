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
    public class Character// hacer que sea como coche y tipos de coche
    {
        private long _id;
        private string _name = string.Empty;    
        private int _level;
        private int _xCoordinate;
        protected int _element;
        protected ClassCharacter _class;
        private Stadistics stadistics;
        public long Id => _id;
        public string Name => _name;
        public int Element => _element;
        public int Level => _level;
        public int XCoordinate => _xCoordinate;

        public ClassCharacter Class => _class;

        public void CreateCharacter(string name, int element, int level, int xCoordinate, ClassCharacter @class)
        {
            if (name == null)
                throw new ArgumentNullException("Name");
            else if (element < 0 || element > 4)
                throw new ArgumentOutOfRangeException("Element");
            else if (level < 0 || level > 99)
                throw new ArgumentOutOfRangeException("Level");
            else if (xCoordinate < 0 || xCoordinate > 5)
                throw new ArgumentException("X coordinate");
            else
            {
                Character c = new Character()
                {
                    _name = name,
                    _element = element,
                    _level = level,
                    _xCoordinate = xCoordinate,
                    _class = @class
                };
            }
        }
    }
}
