namespace CharacterClass
{
    public class Mage : Character
    {
        public Mage(long id, string name, int position, int element) : base(id, name, position, element)
        {
            _stad = new Stadistics(80, 120, 10, 10, 10);
        }

        public override ClassCharacter Class => ClassCharacter.MAGE;

        public override void SimulateTurn()
        {
            throw new NotImplementedException();
        }
    }
}