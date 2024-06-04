using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public static class Utils
    {
        public static int GetRandom()
        {
            Random r = new Random();
            return r.Next();
        }

        public static int GetRandomBetween(int min, int max)
        {
            int r = GetRandom();
            return r * (max-min) + min;
        }
    }
}
