using System.Collections.Generic;

namespace ConsoleApp5
{
    public class Utils
    {
        public static bool EstaLaPelotaAlAlcanceDelJugador(Jugador jugador, ICampo campo)
        {
            var casillas = GetPosicionesADistancia(jugador.Posicion, 1);
            casillas = Filtrar(casillas, campo);
            var posicionPelota = campo.GetPelota().Posicion;
            foreach (var casilla in casillas)
                if (casilla == posicionPelota)
                    return true;
            //String a;
            //a == "";
            return false;
        }

        public static List<Coordenadas> GetPosicionesADistancia(
            Coordenadas centro, int distancia)
        {
            List<Coordenadas> ret = new();
            {
                int x0 = centro.X - distancia;
                int y0 = centro.Y - distancia;
                int x1 = centro.X + distancia;
                int y1 = centro.Y - distancia;
                int x2 = centro.X + distancia;
                int y2 = centro.Y + distancia;
                int x3 = centro.X - distancia;
                int y3 = centro.Y + distancia;
                for (int i = 0; i < distancia * 2; i++, x0++, y1++, x2--, y3--)
                {
                    ret.Add(new Coordenadas(x0, y0));
                    ret.Add(new Coordenadas(x1, y1));
                    ret.Add(new Coordenadas(x2, y2));
                    ret.Add(new Coordenadas(x3, y3));
                }
            }

            {
                int y = centro.y - distancia;
                for (int x = centro.x - distancia; x <= centro.x + distancia; x++)
                    ret.Add(new Coordenadas(x, y));
            }
            {
                int y = centro.Y + distancia;
                for (int x = centro.X - distancia; x <= centro.X + distancia; x++)
                    ret.Add(new Coordenadas(x, y));
            }
            {
                int x = centro.X - distancia;
                for (int y = centro.Y - (distancia - 1); y <= centro.Y + (distancia - 1); y++)
                    ret.Add(new Coordenadas(x, y));
            }
            {
                int x = centro.X + distancia;
                for (int y = centro.Y - (distancia - 1); y <= centro.Y + (distancia - 1); y++)
                    ret.Add(new Coordenadas(x, y));
            }

            return ret;
        }

        public static List<Coordenadas> Filtrar(List<Coordenadas> coordenadas, ICampo campo)
        {
            List<Coordenadas> ret = new();
            foreach (var coords in coordenadas)
                if (campo.EstaDisponible(coords))
                    ret.Add(coords);
            return ret;
        }

        public static List<Jugador> GetJugadores(List<Coordenadas> coordenadas, ICampo campo)
        {
            List<Jugador> ret = new();
            foreach (var coords in coordenadas)
            {
                var pj = campo.GetPersonajeAt(coords);
                // Gracias Roberto
                if (pj is Jugador jugador)
                    ret.Add(jugador);
            }
            return ret;
        }

        public static Coordenadas GetPosicionCasillasDeDistancia(
            Coordenadas centro, int distancia, ICampo campo)
        {
            var lista = GetPosicionesADistancia(centro, distancia);
            lista = Filtrar(lista, campo);
            int index = GetRandom(0, lista.Count - 1);
            return lista[index];
        }

        //public static (int X, int Y) GetPosicionA2CasillasDeDistanciaVersionAngel()
        //{
        //    var coordenadas = GetPosicionA2CasillasDeDistancia();
        //    return (coordenadas.X, coordenadas.Y);
        //}


        public static void ConfigurarDefensa(Defensa defensa, int index)
        {
            var dir = defensa.Equipo.DireccionDelEquipo;
            int y = 0;
            if (dir == DireccionDelEquipo.HACIA_ABAJO)
                y = 19; // MAAAAAAAAAAAAALLL!!!!!!!!!!!!!!!!!!

            defensa.Posicion.Y = y;

            if (index == 0)
                defensa.Posicion.X = 0;
            else if (index == 1)
                defensa.Posicion.X = 0;
        }

        public static void ConfigurarDelantero(Jugador jugador, int index)
        {
            var dir = jugador.Equipo.DireccionDelEquipo;
            int y = 0;
            if (dir == DireccionDelEquipo.HACIA_ABAJO)
                y = 19; // MAAAAAAAAAAAAALLL!!!!!!!!!!!!!!!!!!

            jugador.Posicion.Y = y;

            if (index == 0)
                jugador.Posicion.X = 0;
            else if (index == 1)
                jugador.Posicion.X = 0;
        }

        public static int GetRandom(int min, int max)
        {
            return 1;
        }

        public static double GetRandomReal(double min, double max)
        {
            return 0.5;
        }
    }
}
