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

        public static bool ActivateWithProbability(double probability)
        {
            Random random = new Random();
            // Genera un número aleatorio entre 0 y 1
            double randomNumber = random.NextDouble();

            // Compara con la probabilidad deseada
            return randomNumber < probability;
        }
    }
}
