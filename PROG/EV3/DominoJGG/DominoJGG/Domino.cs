using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class Domino
    {
        private int _value1;
        private int _value2;

        public int Value1 { get => _value1; }
        public int Value2 { get => _value2; }

        public int TotalValue {  get => _value1 + _value2; }
        public bool IsDouble { get => _value1 == _value2; }

        private Domino(int v1, int v2)
        {
            _value1 = v1;
            _value2 = v2;
        }

        public static Domino? CreatePiece(int v1, int v2)
        {
            if (v1 >= 6 || v1 <= 0)
                return null;
            else if (v2 > 6 || v2 < 0)
                return null;
            return new Domino(v1, v2);
        }

        public bool IsEquals(Domino? other)
        {
            if (other == null)
                return false;
            return (_value1 == other._value1 && _value2 == other._value2) ||
                (_value1 == other._value2 && _value2 == other._value1);
        }

        public Domino SwapValues()
        {
            return new Domino(Value2, Value1);
        }
    }
}
