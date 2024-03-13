using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum Moneda
    {
        UNKNOWN,
        E_500, //= 50000,
        E_200, //= 20000,
        E_100, //= 10000,
        E_50, //= 5000,
        E_20, //= 2000,
        E_10, //= 1000,
        E_5, //= 500,
        E_2, //= 200,
        E_1, //= 100,
        E_050, //= 20000,
        E_020, //= 20000,
        E_010, //= 20000,
        E_005, //= 20000,
        E_002, //= 20000,
        E_001, //= 20000,
    }
    public class CoinChange
    {
        private static int[] _monedasValue = { 50000, 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
        public static Dictionary<int, Moneda> _diccionario = new Dictionary<int, Moneda>();

        static CoinChange()
        {
            _diccionario.Add(50000, Moneda.E_500);
            _diccionario.Add(20000, Moneda.E_200);
            _diccionario.Add(10000, Moneda.E_100);
            _diccionario.Add(5000, Moneda.E_50);
            _diccionario.Add(2000, Moneda.E_20);
            _diccionario.Add(1000, Moneda.E_10);
            _diccionario.Add(500, Moneda.E_5);
            _diccionario.Add(200, Moneda.E_2);
            _diccionario.Add(100, Moneda.E_1);
            _diccionario.Add(50, Moneda.E_050);
            _diccionario.Add(20, Moneda.E_020);
            _diccionario.Add(10, Moneda.E_010);
            _diccionario.Add(5, Moneda.E_005);
            _diccionario.Add(2, Moneda.E_002);
            _diccionario.Add(1, Moneda.E_001);
        }
        public static int ToNumber(Moneda coin)
        {
            int result = int.MinValue;
            foreach(var moneda in _diccionario)
            {
                if( moneda.Value == coin )
                {
                    result = moneda.Key;
                }
            }
            //if (coin == Moneda.E_500)
            //    return  50000;
            //if (coin == Moneda.E_200)
            //    return  20000;
            //if (coin == Moneda.E_100)
            //    return  10000;
            //if (coin == Moneda.E_50)
            //    return  5000;
            //if (coin == Moneda.E_20)
            //    return  2000;
            //if (coin == Moneda.E_10)
            //    return  1000;
            //if (coin == Moneda.E_5)
            //    return  500;
            //if (coin == Moneda.E_2)
            //    return  200;
            //if (coin == Moneda.E_1)
            //    return  100;
            //if (coin == Moneda.E_050)
            //    return  50;
            //if (coin == Moneda.E_020)
            //    return  20;
            //if (coin == Moneda.E_010)
            //    return  10;
            //if (coin == Moneda.E_005)
            //    return  5;
            //if (coin == Moneda.E_002)
            //    return  2;
            //return  1;

            //return (int)moneda;
            return result;
            //return _monedasValue[(int)coin];
        }

        public static Moneda ToMoneda(int centims)
        {
            //return (Moneda)centims;

            //if (centims == 50000)
            //    return Moneda.E_500;
            //if (centims == 20000)
            //    return Moneda.E_200;
            //if (centims == 10000)
            //    return Moneda.E_100;
            //if (centims == 5000)
            //    return Moneda.E_50;
            //if (centims == 2000)
            //    return Moneda.E_20;
            //if (centims == 1000)
            //    return Moneda.E_10;
            //if (centims == 500)
            //    return Moneda.E_5;
            //if (centims == 200)
            //    return Moneda.E_2;
            //if (centims == 100)
            //    return Moneda.E_1;
            //if (centims == 50)
            //    return Moneda.E_050;
            //if (centims == 20)
            //    return Moneda.E_020;
            //if (centims == 10)
            //    return Moneda.E_010;
            //if (centims == 5)
            //    return Moneda.E_005;
            //if (centims == 2)
            //    return Moneda.E_002;
            //return Moneda.E_001;

            Moneda result;
            if (_diccionario.TryGetValue(centims, out result) == false)
                return Moneda.UNKNOWN;
            return result;
        }

        public static Moneda GetCoin(int centims)
        {
            
            if (centims >= ToNumber(Moneda.E_500))
                return Moneda.E_500;
            else if (centims >= ToNumber(Moneda.E_200))
                return Moneda.E_200;
            else if (centims >= ToNumber(Moneda.E_100))
                return Moneda.E_100;
            else if (centims >= ToNumber(Moneda.E_50))
                return Moneda.E_50;
            else if (centims >= ToNumber(Moneda.E_20))
                return Moneda.E_20;
            else if (centims >= ToNumber(Moneda.E_10))
                return Moneda.E_10;
            else if (centims >= ToNumber(Moneda.E_5))
                return Moneda.E_5;
            else if (centims >= ToNumber(Moneda.E_2))
                return Moneda.E_2;
            else if (centims >= ToNumber(Moneda.E_1))
                return Moneda.E_1;
            else if (centims >= ToNumber(Moneda.E_050))
                return Moneda.E_050;
            else if (centims >= ToNumber(Moneda.E_020))
                return Moneda.E_020;
            else if (centims >= ToNumber(Moneda.E_010))
                return Moneda.E_010;
            else if (centims >= ToNumber(Moneda.E_005))
                return Moneda.E_005;
            else if (centims >= ToNumber(Moneda.E_002))
                return Moneda.E_002;
            else if (centims >= ToNumber(Moneda.E_001))
                return Moneda.E_001;
            return Moneda.UNKNOWN;
        }

        public static List<Moneda> GetCoins(int centims) //hacer una lista con las monedas de cada tipo que necesitas en la conversión, repitiendose si necesitas más de una. Ej:429 son [200,200,20,5,2,2,1]
        {
            List<Moneda> result = new List<Moneda>();
            while (centims > 0)
            {
                Moneda moneda = Moneda.UNKNOWN;
                if (centims >= ToNumber(Moneda.E_500))
                    moneda = Moneda.E_500;
                else if (centims >= ToNumber(Moneda.E_200))
                    moneda = Moneda.E_200;
                else if (centims >= ToNumber(Moneda.E_100))
                    moneda = Moneda.E_100;
                else if (centims >= ToNumber(Moneda.E_50))
                    moneda = Moneda.E_50;
                else if (centims >= ToNumber(Moneda.E_20))
                    moneda = Moneda.E_20;
                else if (centims >= ToNumber(Moneda.E_10))
                    moneda = Moneda.E_10;
                else if (centims >= ToNumber(Moneda.E_5))
                    moneda = Moneda.E_5;
                else if (centims >= ToNumber(Moneda.E_2))
                    moneda = Moneda.E_2;
                else if (centims >= ToNumber(Moneda.E_1))
                    moneda = Moneda.E_1;
                else if (centims >= ToNumber(Moneda.E_050))
                    moneda = Moneda.E_050;
                else if (centims >= ToNumber(Moneda.E_020))
                    moneda = Moneda.E_020;
                else if (centims >= ToNumber(Moneda.E_010))
                    moneda = Moneda.E_010;
                else if (centims >= ToNumber(Moneda.E_005))
                    moneda = Moneda.E_005;
                else if (centims >= ToNumber(Moneda.E_002))
                    moneda = Moneda.E_002;
                else if (centims >= ToNumber(Moneda.E_001))
                    moneda = Moneda.E_001;
                result.Add(moneda);
                centims -= ToNumber(moneda);
            }
            return result;
        }
    }
}
