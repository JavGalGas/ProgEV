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

        public static double GetRandomBetweenReal(double min, double max)
        {
            double dif = max - min + 1;
            return min + (r.NextDouble() % dif);
        }

        public static bool IsBallAtReach(Player player, IField field)
        {

            var casillas = GetPositionsAtDistance(player.Position!, 1);
            casillas = Filter(casillas, field);
            var posicionPelota = field.GetBall().Position;
            foreach (var casilla in casillas)
            {
                if (casilla == posicionPelota!) return true;
            }
            return false;
        }

        public static bool ActivateWithProbability(double probability)
        {
            Random random = new Random();
            // Genera un número aleatorio entre 0 y 1
            double randomNumber = random.NextDouble();

            // Compara con la probabilidad deseada
            return randomNumber < probability;
        }

        public static Position GetPositionAt2CasillasOfDistance(Position centro, int distance, IField field)
        {
            var lista = GetPositionsAtDistance(centro, distance);
            lista = Filter(lista, field);
            int index = GetRandomBetween(0, lista.Count);
            return lista[index];
        }

        public static List<Position> GetPositionsAtDistance(Position centro, int distance)
        {

            List<Position> ret = new();
            {
                int x0 = centro.X - distance;
                int y0 = centro.Y - distance;
                int x1 = centro.X + distance;
                int y1 = centro.Y - distance;
                int x2 = centro.X + distance;
                int y2 = centro.Y + distance;
                int x3 = centro.X - distance;
                int y3 = centro.Y + distance;

                for (int i = 0; i < distance * 2; i++, x0++, y1++, x2--, y3--)
                {
                    ret.Add(new Position(x0, y0));
                    ret.Add(new Position(x1, y1));
                    ret.Add(new Position(x2, y2));
                    ret.Add(new Position(x3, y3));

                }
            }
            {
                int y = centro.Y - distance;
                for (int x = centro.X - distance; x <= centro.X + distance; x++)
                    ret.Add(new Position(x, y));
            }
            {
                int y = centro.Y - distance;
                for (int x = centro.X - distance; x <= centro.X + distance; x++)
                    ret.Add(new Position(x, y));
            }
            {
                int x = centro.X - distance;
                for (int y = centro.Y - distance - 1; y <= centro.Y + (distance - 1); y++)
                    ret.Add(new Position(x, y));
            }
            {
                int x = centro.X - distance;
                for (int y = centro.Y - distance - 1; y <= centro.Y + (distance - 1); y++)
                    ret.Add(new Position(x, y));
            }


            return ret;
        }

        public static List<Position> Filter(List<Position> coordenadas, IField field)
        {
            List<Position> ret = new();
            foreach (var coords in coordenadas)
            {
                var pj = field.GetCharacterAt(coords);
                if (field.IsAvailable(coords))
                    ret.Add(coords);
            }
            return ret;
        }

        //public static (int X, int Y) GetPositionsAt2CasillasOfDistance()
        //{
        //    var coordenadas = GetPositionsAt2CasillasOfDistance();
        //    return (coordenadas.X, coordenadas.Y);
        //}

        //generar array con todas las casillas en las que puedo caer
        //con un random elijo una de esas casillas

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
