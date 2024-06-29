namespace CharacterClass
{
    public class Support : Character
    {
        public Support(long id, string name, int position, int element) : base(id, name, position, element)
        {
            _stad = new Stadistics(120, 100, 8, 10, 10);
        }

        public override ClassCharacter Class => ClassCharacter.SUPPORT;

        public override void SimulateTurn()
        {
            throw new NotImplementedException();
        }
    }
}