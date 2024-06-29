namespace ExamenE2
{
    public class Box : IBox
    {
        private int _boxPosition = 1;
        public int BoxPosition => _boxPosition;


        public Box(int position)
        {
            _boxPosition = position;
        }

        public void ApplyEffect(Game game)
        {
        }
    }
}