using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public static class Utils
    {
        private static Random r = new Random();

        public static int GetRandomBetween(int min, int max)
        {
            int dif = max - min + 1;
            return min + (r.Next() % dif);
        }

        public static bool ActivateWithProbability(double probability)
        {
            Random random = new Random();
            // Genera un número aleatorio entre 0 y 1
            double randomNumber = random.NextDouble();

            // Compara con la probabilidad deseada
            return randomNumber < probability;
        }

        public static (int, int) SetRandomPosition()//modificar
        {
            int x = Utils.GetRandomBetween(0, 10);
            int y = Utils.GetRandomBetween(0, 20);
            return (x, y);
        }
    }
}
