

namespace Classes
{
    public class DominoPiece
    {
       
        private int _value1;
        private int _value2;

        public DominoPiece(int v1, int v2)
        {
            /*this.*/_value1 = v1;
            /*this.*/_value2 = v2;
        }

        public int GetValue1()
        {
            return _value1;
        }

        public int GetValue2()
        {
            return _value2;
        }

        public int GetTotalValue()
        {
            return _value1 + _value2;
        }

        public bool IsDouble()
        {
            if(_value1 == _value2)
                return true;
            return false;
        }


        public static DominoPiece? CreatePiece(int v1, int v2)
        {
            if (v1 >= 6 || v1 <= 0)
                return null;
            else if (v2 > 6 || v2 < 0)
                return null;
            return new DominoPiece(v1, v2);
        }

        public bool IsEquals(DominoPiece? other)
        {
            if (other == null)
                return false;
            return (_value1 == other._value1 && _value2==other._value2)||(_value1 == other._value2 && _value2 == other._value1);
        }
    }
}
