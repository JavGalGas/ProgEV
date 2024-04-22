using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static Position SetRandomPosition()//modificar
        {
            int x = Utils.GetRandomBetween(0, 10);
            int y = Utils.GetRandomBetween(0, 20);
            return new(x, y);
        }

        public static void ConfigureDefender(Defender defender, int index)
        {
            var dir = defender.Team.teamDirection;
            int y = 0;
            if (dir == TeamDirection.HACIA_ARRIBA)
                y = 19;
             defender.SetPosition(new(index,y));
        }

        public static void ConfigureStriker(Striker striker, int index)
        {
            var dir = striker.Team.teamDirection;
            int y = 1;
            if (dir == TeamDirection.HACIA_ARRIBA)
                y = 18;
            striker.SetPosition(new(index, y));
        }

        public static void ConfigureSpecialDefender(SpecialDefender specialDefender, int index)//modificar
        {
            var dir = specialDefender.Team.teamDirection;
            int y = 0;
            if (dir == TeamDirection.HACIA_ARRIBA)
                y = 19;
            if (index == 0)
            {
                specialDefender.SetPosition(new(0, y));
            }
        }
    }
}
