using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public class Tank : Character
    {
        public Tank(long id, string name, int position, int element) : base(id, name, position, element)
        {
            _stad = new Stadistics(100, 100, 10, 12, 8);
        }

        public override ClassCharacter Class => ClassCharacter.TANK;

 

    }
}
