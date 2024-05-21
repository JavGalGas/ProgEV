using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public enum ClassCharacter
    {
        CLOSE_COMBAT,
        RANGE,
        MECHA,
        HEALER,
        HERO,
    }
    public class Character
    {
        public long Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public int Element {  get; set; }
        public int Level { get; set; }
        public int XCoordinate { get; set; }

        public ClassCharacter Class { get; set; }

        public void CreateCharacter(string name, int element, int level, int xCoordinate, ClassCharacter @class)
        {
            if (name == null)
                throw new ArgumentNullException("Name");
            else if (element < 0 || element > 4)
                throw new ArgumentOutOfRangeException("Element");
            else if (level < 0 || level > 99)
                throw new ArgumentOutOfRangeException("Level");
            else if (!Utils.CheckCoordinate(xCoordinate))
                throw new ArgumentException("X coordinate");
            else
            {
                Character c = new Character()
                {
                    Name = name,
                    Element = element,
                    Level = level,
                    XCoordinate = xCoordinate,
                    Class = @class
                };
            }
        }
    }
}
