using System.Drawing;

namespace Classes
{
    public enum Palo
    {
        CLOVER,
        HEARTS,
        DIAMOND,
        SPADES,
    }
    public enum Color
    {
        BLACK,
        RED,
        UNKNOWN,
    }
    public enum Figure
    {
        KING,
        QUEEN,
        JACK,
        AS,
        JOCKER,
        NONE,
        UNKNOWN,
    }
    class Card
    {
        private Palo _cardType;
        private int _number;

        public Card(int v1, Palo v2)
        {
            _number = v1;
            _cardType = v2;
        }

        public bool IsValid()
        {
            return (_number < 0 || _number > 13) ? false : true;
        }
        public Palo GetPalo()
        {
            return _cardType;
        }
        public Color GetColor()
        {
            if(!IsValid())
                return Color.UNKNOWN;
            else if(GetPalo()==Palo.DIAMOND|| GetPalo()==Palo.HEARTS)
                return Color.RED;
            return Color.BLACK;
        }
        public Figure GetFigure()
        {
            if (!IsValid())
                return Figure.UNKNOWN;
            else if (_number == 13)
                return Figure.KING;
            else if (_number == 12)
                return Figure.QUEEN;
            else if (_number == 11)
                return Figure.JACK;
            else if (_number == 1)
                return Figure.AS;
            else if (_number == 0)
                return Figure.JOCKER;
            return Figure.NONE;
        }
        public bool IsFigure()
        {
            if (!IsValid())
                return false;
            else if (_number > 1 && _number < 11)
                return false;
            return true;

            //return GetFigure() != Figure.NONE;
        }
        public int GetValue()
        {
            return IsValid() ? _number : -1;
        }
        /*
        public Card? CreateCard(int v1, Palo v2)
        {
            if(IsValid())
                return new Card(v1, v2);
            return null;
        }*/
    }
}
