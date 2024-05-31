namespace CharacterClass
{
    public class Warrior : Character
    {
        public Warrior(long id, string name, int level, int position, int element, ClassCharacter @class) : base(id, name, level, position, element, @class)
        {
        }

        public override void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}