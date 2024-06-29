using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamenE2
{
    public static class Utils
    {
        public static Random r = new Random();

        public static int GetRandom()
        {
            return r.Next();
        }

        public static int GetRandomBetween(int min, int max)
        {
            return r.Next(min, max);
        }
    }
}
