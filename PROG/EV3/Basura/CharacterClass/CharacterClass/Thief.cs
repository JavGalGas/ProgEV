namespace CharacterClass
{
    public class Thief : Character
    {
        public Thief(long id, string name, int position, int element) : base(id, name, position, element)
        {
            _stad = new Stadistics(100, 100, 10, 12, 8);
        }

        public override ClassCharacter Class => ClassCharacter.THIEF;

        protected override void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}