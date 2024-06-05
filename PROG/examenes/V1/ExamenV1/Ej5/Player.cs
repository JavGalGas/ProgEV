
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
        protected PlayerType _playerType;

        public string Name => _name;
        public int Position => _position;
        public int DiceThrow => _diceThrow;

        public Player(string name, int position) 
        {
            _name = name;
            _position = position;
        }

        public abstract int ThrowDice();

        public virtual void ExecuteTurn()
        {
            int diceThrow = ThrowDice();
            _diceThrow = diceThrow;
            SetPosition(_position + diceThrow);
        }

        public virtual void SetPosition(int position)
        {
            _position = position;
        }
    }
}