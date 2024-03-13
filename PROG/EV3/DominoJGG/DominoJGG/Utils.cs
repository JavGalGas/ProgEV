using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoJGG
{
    public class Utils
    {
        private static Random r = new Random();
        public static int GetRandomBetween(int min, int max)
        {
            int dif = max - min + 1;
            return min + (r.Next() % dif);
        }
    }
}
