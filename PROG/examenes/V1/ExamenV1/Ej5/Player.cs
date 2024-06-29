
namespace Ej5
{

    public abstract class Player
    {
        private string _name;
        protected Box? _box;
        protected int _diceThrow;
        protected int disabledTurns;

        public string Name => _name;
        public Box? Box 
        { 
            get => _box;
            set 
            {
                if (value!.BoxPosition <= 0 || value.BoxPosition > 63) 
                {
                   throw new ArgumentOutOfRangeException(nameof(value));
                }
                _box = value;
            }
        }
        public int DiceThrow
        {
            get => _diceThrow;
            set 
            {
                int maxValue = this is CheaterPlayer ? 8 : 6;
                if (value <= 0 || value > maxValue)
                    throw new ArgumentOutOfRangeException(nameof(value));
                else
                    _diceThrow = value;
            }
        }

        public int DisabledTurns 
        {
            get { return disabledTurns; }
            set => disabledTurns = value; 
        }

        public Player(string name) 
        {
            _name = name;
        }

        //public Player()
        //{
        //    _name = string.Empty;
        //}

        public abstract int ThrowDice();

        public virtual void SimulateTurn(Game game)
        {
            if(disabledTurns > 0)
            {
                disabledTurns--;
                return;
            }
            _diceThrow = ThrowDice();
            _box = game.GetBox(_box!.BoxPosition + _diceThrow);
            _box.ApplyEffect(game, this);
        }
    }
}