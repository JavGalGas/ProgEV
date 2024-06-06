
namespace Ej5
{
    public enum PlayerType
    {
        NORMAL_PLAYER,
        QUICK_PLAYER,
        CHEAT_PLAYER
    }

    public abstract class Player
    {
        private string _name;
        protected int _position;
        protected int _diceThrow;
        protected int disabledTurns;

        public string Name => _name;
        public int Position 
        { 
            get => _position;
            set 
            {
                if (value <= 0 || value > 63) 
                {
                   throw new ArgumentOutOfRangeException(nameof(value));
                }
                _position = value;
            }
        }
        public int DiceThrow
        {
            get => _diceThrow;
            set 
            {
                if (value <=0 || value > 6)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _diceThrow = value;
            }
        }
        public abstract PlayerType PlayerType { get; }

        public Player(string name, int position) 
        {
            _name = name;
            _position = position;
        }

        public abstract int ThrowDice();

        public virtual void SimulateTurn()
        {
            _diceThrow = ThrowDice();
            _position += _diceThrow;
        }
    }
}