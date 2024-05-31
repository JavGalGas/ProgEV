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
<<<<<<< Updated upstream
        private Stadistics _stad;
        public Tank(long id, string name, int level, int position, int element, ClassCharacter @class, Stadistics stadistics) : base(id, name, level, position, element, @class, stadistics)
=======
        private Stadistics _stad = new Stadistics(10, 10, 10, 12, 8);
        public Tank(long id, string name, int level, int position, int element, ClassCharacter @class) : base(id, name, level, position, element, @class)
>>>>>>> Stashed changes
        { 
            _id = id;
            _stad = GetStadistics();
        }
<<<<<<< Updated upstream

        private Stadistics GetStadistics()
        {
            return new Stadistics(10,);
        }
=======
>>>>>>> Stashed changes
    }
}
