namespace CharacterClass
{
    public class Warrior : Character
    {
        public Warrior(long id, string name, int position, int element) : base(id, name, position, element)
        {
            _stad = new Stadistics(100, 80, 12, 10, 10);
        }

        public override ClassCharacter Class => ClassCharacter.WARRIOR;


    }
}