using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public class Tank : Character
    {
        private Stadistics _stad = new Stadistics(100, 100, 10, 12, 8);

        public Stadistics Stadistics => _stad;
        public Tank(long id, string name, int level, int position, int element, ClassCharacter @class) : base(id, name, level, position, element, @class)
        { 

        }

        public override void LevelUp()
        {
            _stad.IncreaseStadistics(this);
        }
    }
}
