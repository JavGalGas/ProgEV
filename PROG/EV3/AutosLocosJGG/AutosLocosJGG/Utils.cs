using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public static class Utils
    {
        private static Random r = new Random();

        public static double GetRandomBetween(double min, double max)
        {
            double dif = max - min + 1;
            return min + (r.NextDouble() % dif);
        }
    }
}
