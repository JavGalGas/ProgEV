namespace Ej5
{
    public abstract class Box
    {
        private int _boxPosition;

        public int BoxPosition => _boxPosition;

        public Box(int value)
        {
            _boxPosition = value;
        }
    }
}