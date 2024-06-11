namespace Ej5
{
    public abstract class Box
    {
        protected int _boxPosition = 1;
        public int BoxPosition => _boxPosition;
        public Box(int value)
        {
            if (value <= 0 || value > 63)
                throw new ArgumentOutOfRangeException($"The value {value} is out of range. It has to be between 1 and 63.");
            _boxPosition = value;
        }

        public abstract void ApplyEffect(Game game, Player player);

    }
}