namespace Ej5
{
    public enum BoxType
    {
        BOXWIN,
        BOXDEATH,
        BOXBRIDGE,
        BOXGOOSE,
        BOXNORMAL,
        BOXPUNISH,
        BOXDICE,
        DEFAULT
    }
    public abstract class Box
    {
        protected int _boxPosition = 1;

        public int BoxPosition => _boxPosition;

        public abstract BoxType Type { get; }

        public Box(int value)
        {
            if (value <= 0 || value > 63)
                throw new ArgumentOutOfRangeException($"The value {value} is out of range. It has to be between 1 and 63.");
            _boxPosition = value;
        }

        public abstract void ApplyEffect(Game game);
    }
}