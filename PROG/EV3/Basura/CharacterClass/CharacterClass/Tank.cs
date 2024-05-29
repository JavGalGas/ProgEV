using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public class Tank : Character
    {
        private long _id;
        private Stadistics _stad = GetStadistics();
        public Tank(long id, string name, int level, int position, int element, ClassCharacter @class, Stadistics stadistics) : base(id, name, level, position, element, @class, stadistics)
        { 
            _id = id;
        }

        private Stadistics GetStadistics()
        {
            return new Stadistics()
            {
                
            };
        }
    }
}
