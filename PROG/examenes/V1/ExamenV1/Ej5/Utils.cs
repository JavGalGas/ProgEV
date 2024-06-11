using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public static class Utils
    {

        public static int GetRandomBetween(int min, int max)
        {
            Random random = new Random();
            int result = random.Next(min,max);
            return result;
        }
    }
}
