using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{//implementar Swap con lambda
    public static class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }
        private static Random r = new Random();
        public static int GetRandomBetween(int min, int max)
        {
            int dif = max - min + 1;
            return min + (r.Next() % dif);
        }

        public static IList<T> Swap<T>(this IList<T> list, int i, int j)
        {
            T aux = list[i];
            list[i] = list[j];
            list[j] = aux;
            return list;
        }
    }
}
