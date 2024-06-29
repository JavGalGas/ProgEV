namespace CharacterClass
{
    public class Thief : Character
    {
        public Thief(long id, string name, int position, int element) : base(id, name, position, element)
        {
            _stad = new Stadistics(100, 100, 10, 8, 12);
        }

        public override ClassCharacter Class => ClassCharacter.THIEF;

        public override void SimulateTurn()
        {
            throw new NotImplementedException();
        }
    }
}