using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public class Tank : Character
    {
        private int _id;

        public Tank(long id, string name, int level, int position, int element, ClassCharacter @class, Stadistics stadistics) : base(id, name, level, position, element, @class, stadistics) 
        { 
            
        }

    }
}
