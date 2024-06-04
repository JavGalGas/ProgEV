
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
        private int _position;
        protected PlayerType _playerType;

        public string Name => _name;
        public int Position => _position;

        public Player(string name, int position) 
        {
            _name = name;
            _position = position;
        }

        public abstract int ThrowDice();

        public abstract void ExecuteTurn();
    }
}