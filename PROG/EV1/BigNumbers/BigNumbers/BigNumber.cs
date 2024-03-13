using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace BigNumbers
{
    public class BigNumber
    {
        private List<int> _list= new List<int>();

        public BigNumber()
        {

        }

        public BigNumber(long value)
        {
            Set(value);
        }
        public BigNumber (string value)
        {
            Set(value);
            Correct();
        }

        public void Set(long value)
        {
            while (Math.Abs(value) / 10 > 0)
            {
                _list.Add((int)(Math.Abs(value) % 10));
                value /= 10;
            }
            _list.Add((int) value);
            
        }
        public void Set(string value)
        {
            if (value.Length == 0)
                return;
            for (int i = value.Length-1; i >= 0; i--)
            {
                char c = value[i];
                if (c == '-' && i==0)
                {
                    int aux = 1;
                    while (_list[_list.Count - aux] == 0)
                        aux++;
                    _list[_list.Count - aux] *=-1 ;
                }
                else
                {
                    switch(c)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            {
                                int n = c - '0';
                                _list.Add(n);
                            }
                            break;
                        default: break;
                    }
                    
                }
            }

        }
        public string ConvertToString()
        {
            string result = "";
            for(int i=GetDigitCount()-1; i>=0; i--)
            {
                result = result + GetDigitAt(i).ToString();
            }
            return result;
        }

        public void Correct()
        {
            int i = _list.Count-1 ;
            while (GetDigitAt(i)==0)
            {
                if (_list.Count == 1)
                    break;
                _list.RemoveAt(i--);
            }
        }

        public static BigNumber Correct(BigNumber value)
        {
            int i = value._list.Count - 1;
            while (value._list[i] == 0)
            {
                if (value._list.Count == 1)
                    break;
                value._list.RemoveAt(i--);
            }
            return value;
        }

        public static BigNumber GetGreaterBetween(BigNumber n1, BigNumber n2)
        {
            for (int i = n1.GetDigitCount(); i < n2.GetDigitCount(); i++)
            {
                n1._list.Add(0);
            }
            for (int i = n2.GetDigitCount(); i < n1.GetDigitCount(); i++)
            {
                n2._list.Add(0);
            }
            for (int i = n1.GetDigitCount()-1; i >=0 ; i--)
            {
                if(n1.GetDigitAt(i) < n2.GetDigitAt(i))
                {
                    return n2;
                }
                if (n1.GetDigitAt(i) > n2.GetDigitAt(i))
                {
                    return n1;
                }
            }
            return n1;
        }

        public static BigNumber GetLesserBetween(BigNumber n1, BigNumber n2)
        {
            for (int i = n1.GetDigitCount(); i < n2.GetDigitCount(); i++)
            {
                n1._list.Add(0);
            }
            for (int i = n2.GetDigitCount(); i < n1.GetDigitCount(); i++)
            {
                n2._list.Add(0);
            }
            for (int i = n1.GetDigitCount()-1; i >=0 ; i--)
            {
                if (n1.GetDigitAt(i) < n2.GetDigitAt(i))
                {
                    return n1;
                }
                if (n1.GetDigitAt(i) > n2.GetDigitAt(i))
                {
                    return n2;
                }
            }
            return n2;
        }

        public static BigNumber GetAbsoluteValue(BigNumber value)
        {
            int i = value.GetDigitCount()-1;
                if(value.GetDigitAt(i)<0)
                    value._list[i] *= -1;
            return value;
        }

        public static bool IsNumNegative(BigNumber num)
        {
            return (num.GetDigitAt(num.GetDigitCount()-1) < 0);
        }

        public static int GetNumSign(BigNumber num)
        {
            return IsNumNegative(num) ? -1 : 1;
        }


        public static BigNumber Add(BigNumber n1, BigNumber n2) //sumar dos números, si pasa del 9 suma al siguiente dígito
        {
            if (n1._list.Count == 0 || n2._list.Count == 0)
                return new BigNumber(0);
            BigNumber result = new BigNumber();
            if (IsNumNegative(n1))
            {
                if (IsNumNegative(n2))// negativo + negativo || negativo - positivo
                {
                    result=Operation3(n1, n2);
                    return result;
                }
                else//negativo + positivo || negativo - negativo
                {
                    result = Operation2(n1, n2);
                    return result;
                }
            }
            if (IsNumNegative(n2))//positivo + negativo || positivo - positivo 
            {
                result = Operation2(n1, n2);
                return result;
            }
            result= Operation1(n1, n2);
            return result;
        }
        public static BigNumber Substract(BigNumber n1, BigNumber n2) // restar 2 numeros
        {
            if (n1._list.Count == 0 || n2._list.Count == 0)
                return new BigNumber(0);
            BigNumber result = new BigNumber();

            if (IsNumNegative(n1))
            {
                if(IsNumNegative(n2))//negativo - negativo || negativo + positivo
                {
                    result = Operation2(n1, n2);
                    return result;
                }
                else//negativo - positivo || negativo + negativo (suma *-1)
                {
                    result = Operation3(n1, n2);
                    return result;
                }
            }
            if (IsNumNegative(n2))
            {
                result = Operation1(n1, n2);
                return result;
            }
            result = Operation2(n1, n2);
            return result;
        }

        private static BigNumber Operation1(BigNumber n1, BigNumber n2)//positive + positive || positive - negative
        {
            n1 = GetAbsoluteValue(n1);
            n2 = GetAbsoluteValue(n2);
            BigNumber result = new BigNumber();
            int aux = 0;

            for (int i = n1.GetDigitCount(); i < n2.GetDigitCount(); i++)
            {
                n1._list.Add(0);
            }
            for (int i = n2.GetDigitCount(); i < n1.GetDigitCount(); i++)
            {
                n2._list.Add(0);
            }
            for (int i = 0; i < n1.GetDigitCount(); i++)
            {
                int sum = n1.GetDigitAt(i) + n2.GetDigitAt(i) + aux;
                aux = sum / 10;
                sum %= 10;
                result._list.Add(sum);
            }
            if (aux != 0)
                result._list.Add(aux);
            return result;
        }
        private static BigNumber Operation2(BigNumber n1, BigNumber n2)//positive + negative || positive - positive || negative + positive || negative - negative
        {//modificar
            int n1sign = GetNumSign(n1);
            int n2sign = GetNumSign(n2);
            n1 = GetAbsoluteValue(n1);
            n2 = GetAbsoluteValue(n2);
            BigNumber result = new BigNumber();
            int aux = 0;
            BigNumber aux1 = GetGreaterBetween(n1, n2);
            BigNumber aux2 = GetLesserBetween(n1, n2);

            for (int i = 0; i < aux1.GetDigitCount(); i++)
            {
                int sub = aux1.GetDigitAt(i) - aux2.GetDigitAt(i) - aux;
                aux = ((sub - 9) * -1) / 10;
                if (sub < 0)
                {
                    sub += 10;
                }
                result._list.Add(sub);
            }
            Correct(result);
            if ((aux1 == n1 && n1sign==-1)||(aux1 == n2))
                result._list[result._list.Count-1] *= -1;
            return result;
        }
        private static BigNumber Operation3(BigNumber n1, BigNumber n2) //negative + negative || negative - positive
        {
            n1=GetAbsoluteValue(n1);
            n2=GetAbsoluteValue(n2);
            BigNumber result = new BigNumber();
            int aux = 0;

            for (int i = n1.GetDigitCount(); i < n2.GetDigitCount(); i++)
            {
                n1._list.Add(0);
            }
            for (int i = n2.GetDigitCount(); i < n1.GetDigitCount(); i++)
            {
                n2._list.Add(0);
            }
            for (int i = 0; i < n1.GetDigitCount(); i++)
            {
                int sum = n1.GetDigitAt(i) + n2.GetDigitAt(i) + aux;
                aux = sum / 10;
                sum %= 10;
                result._list.Add(sum);
            }
            if (aux != 0)
                result._list.Add(aux);
            result._list[result._list.Count - 1] *= -1;
            return result;
        }

        public static BigNumber Reverse(BigNumber value)
        {
            BigNumber result = new BigNumber();
            for (int i = value.GetDigitCount() - 1; i >= 0; i--)
            {
                result._list.Add(value.GetDigitAt(i));
            }
            return result;
        }

        public static BigNumber Multiply(BigNumber n1, BigNumber n2) // multiplicar 2 números
        {
            if (n1._list.Count == 0 || n2._list.Count == 0)
                return new BigNumber(0);
            int n1sign = GetNumSign(n1);//1
            int n2sign = GetNumSign(n2);//1
            n1 = GetAbsoluteValue(n1);//[4],[4]
            n2 = GetAbsoluteValue(n2);//[3],[2]
            BigNumber list1 = new BigNumber();
            BigNumber list2 = new BigNumber(0);
            int aux = 0;
            int count = 0;
            for (int i = 0; i < n2.GetDigitCount(); i++)// i=0 || i=1
            {
                list1._list.Clear();//[]
                for (int k = count; k > 0; k--)//[] -->[0] -->[0],[0] -->...
                {
                    list1._list.Add(0);
                }
                for (int j = 0; j < n1.GetDigitCount(); j++)// j=0 || j=1
                {
                    int mul = n1.GetDigitAt(j) * n2.GetDigitAt(i) + aux; //mul = 4*3+0 = 12 || mul = 4*3+1=13
                    if (mul > 9)
                    {
                        aux = mul / 10;//1 ||1
                        mul%= 10;//2 ||3
                    }
                    list1._list.Add(mul);//[2],[3]
                }
                if (aux != 0)
                {
                    list1._list.Add(aux); //[2],[3],[1]
                    aux = 0;
                }
                    
                list2 = Add(list2, list1);
                count++;
            }
            //if (aux != 0)
            //    list2._list.Add(aux); //[0],[0],[2]
            list2._list[list2._list.Count - 1] = list2._list[list2._list.Count - 1] * n1sign * n2sign;
            return list2;
        }
        public static BigNumber Divide(BigNumber n1, BigNumber n2) // dividir 2 numeros <-- Module
        {
            if (n1._list.Count == 0 || n2._list.Count == 0)
                return new BigNumber(0);
            int n1sign = GetNumSign(n1);
            int n2sign = GetNumSign(n2);
            n1 = GetAbsoluteValue(n1);
            n2 = GetAbsoluteValue(n2);
            BigNumber number = Clone(n1);
            int aux = 0;
            while (GetLesserBetween(number, n2) == n2)
            {
                number = Substract(number, n2);
                aux++;
            }
            BigNumber result = new BigNumber(aux);
            result._list[result.GetDigitCount() - 1] = result.GetDigitAt(result.GetDigitCount() - 1) * n1sign * n2sign;
            return result;
        }

        public static BigNumber Module(BigNumber n1, BigNumber n2) // conseguir el resto de la división de 2 numeros --> Divide
        {
            if (n1._list.Count == 0 || n2._list.Count == 0)
                return new BigNumber(0);
            n1 = GetAbsoluteValue(n1);
            n2 = GetAbsoluteValue(n2);
            BigNumber result = Substract(n1, Multiply(Divide(n1,n2),n2));
            return result;
        }

        public int GetDigitCount()
        {
            return _list.Count();
        }
        public int GetDigitAt(int index)
        {
            return _list[index];
        }
        public BigNumber Clone()
        {
            return this.Clone();
        }
        public static BigNumber Clone(BigNumber number)
        {
            BigNumber clone = new BigNumber();

            for(int i =0; i< number._list.Count; i++)
                clone._list.Add(number._list[i]);
            return clone;
        }
    }
}
