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
       WARRIOR,
       SUPPORT,
       THIEF,
       MAGE
    }
    public abstract class Character : GameObject// hacer que sea como coche y tipos de coche
    {
        protected long _id;
        private string _name = string.Empty;    
        protected int _level = 1;
        protected int _element;
        protected Stadistics _stad = new Stadistics();
        protected int _experience = 1;
        private int _levelCapExperience;
        protected int _potionTurns;
        public long Id => _id;
        public string Name => _name;
        public int Element => _element;
        public int Level => _level;
        public abstract ClassCharacter Class { get; }
        public int Experience => _experience;
        public int LevelCapExperience => _levelCapExperience;

        public Stadistics Stadistics => _stad;

        protected Character(long id, string name, int position, int element) : base()
        {
            _id = id;
            _name = name;
            if (position < 0 || position >= 5)
            _element = element;
        }

        public virtual void SetExperience(Character character)
        {
            if (_level == 100 && _experience == _levelCapExperience)
                return;

            _experience += ((character._experience + character._level * character._level) / 5) + 1;

            while (_experience > _levelCapExperience || _level < 100)
            {
                LevelUp();
                _levelCapExperience = GetLevelCapExperience();
            }

            if (_level == 100 && _experience > _levelCapExperience)
            {
                _experience = _levelCapExperience;
            }
        }
        private int GetLevelCapExperience()
        {
            int capLevel = _level + 1;
            return (capLevel) * (capLevel) * (capLevel);
        }

        protected virtual void LevelUp()
        {
            _experience -= LevelCapExperience;
            _level += 1;
            _stad.IncreaseStadistics(this);
        }

        public abstract void SimulateTurn();

    }
}
