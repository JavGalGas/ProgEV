using System;

namespace ExamenE2
{
    public enum PlayerType
    {
        NORMAL,
        QUICK,
        CHEATER
    }
    public abstract class Player
    {
        private string _name;
        protected int _throwValue;
        private int _disabledTurns = 0;
        private IBox _boxPosition = new Box(1);
        protected PlayerType _playerType;

        public string Name => _name;
        public int ThrowValue => _throwValue;
        //cambio: utilizo la propiedad Box en vez de utilizar solo la posición.
        public int DisabledTurns => _disabledTurns;
        public IBox Box => _boxPosition;
        public PlayerType PlayerType => _playerType;

        public Player(string name)
        {
            _name = name;
        }

        public virtual void SetStartThrow()
        {
            _throwValue = ThrowDice();
        }
        public abstract int ThrowDice();

        public virtual void SimulatePlayer(Game game)
        {
            if (_disabledTurns > 0)
            {
                _disabledTurns--;
                return;
            }
            int throwValue = ThrowDice();
            SetPlayerPosition(_boxPosition.BoxPosition + throwValue,  game);
            _boxPosition.ApplyEffect(game);
        }

        public void AddDisabledTurns(int disabledTurns)
        {
            if (disabledTurns < 0)
            {
                throw new Exception($"{nameof(disabledTurns)} must not be negative");
            }
            _disabledTurns += disabledTurns;
        }

        public virtual void SetPlayerPosition(int playerPosition, Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));
            if (playerPosition < 0)
                throw new Exception($"{nameof(playerPosition)} must not be negative.");
            game.VisitBoxField(box =>
            {
                if (box.BoxPosition == playerPosition)
                    _boxPosition = box;
            });
        }
    }
}