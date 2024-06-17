﻿namespace CharacterClass
{
    public class Support : Character
    {
        public Support(long id, string name, int position, int element) : base(id, name, position, element)
        {
            _stad = new Stadistics(100, 100, 10, 12, 8);
        }

        public override ClassCharacter Class => ClassCharacter.SUPPORT;

        protected override void LevelUp()
        {
            _experience -= LevelCapExperience;
            _level += 1;
            _stad.IncreaseStadistics(this);
        }
    }
}