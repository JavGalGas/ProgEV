namespace ConsoleApp5
{
    public delegate void Visitor(Personaje personaje);

    public class Partido
    {
        private ICampo _campo = new CampoBasadoEnListaDeCosas();
        private List<Personaje> _personajeList = new();
        private Equipo _equipoA = new Equipo(DireccionDelEquipo.HACIA_ARRIBA);
        private Equipo _equipoB = new Equipo(DireccionDelEquipo.HACIA_ABAJO);

        private void GenerarPersonajes()
        {
            _personajeList.Add(new DefensaEspecial("a", _equipoA, 3, 1));

            var list = _campo.GetCasillasDisponibles();
            for (int i = 0; i < 4; i++)
            {
                var index = Utils.GetRandom(0, list.Count - 1);
                var coordenadas = list[index];
                var dementor = new Dementor(coordenadas);
                _campo.AddPersonaje(dementor);
                list.RemoveAt(index);
            }
        }

        private void MeterLosJugadoresAlCampo()
        {
            Visit(pj => _campo.AddPersonaje(pj));
        }

        private List<Jugador> GetPersonajesDeUnEquipo(Equipo equipo)
        {
            var ret = new List<Jugador>();

            foreach (var pj in _personajeList)
                if (pj is Jugador jugador && jugador.Equipo == equipo)
                    ret.Add(jugador);

            return ret;
        }

        public void Visit(Action<Personaje> visitor)
        {
            if (visitor == null)
                return;
            foreach (var p in _personajeList)
            {
                visitor(p);
            }
        }

        public void Inicializar()
        {
            GenerarPersonajes();
            MeterLosJugadoresAlCampo();
        }

        public void Jugar()
        {
            for (int round = 0; round < 1000; round++)
            {
                HacerQueLosJugadoresRealicenSuJugada();
                if (HayGol())
                {
                    SumarPuntuacionDeGolAlEquipoCorrespondiente();
                    PonerALosJugadoresEnSuPosicionDeOrigen();
                }
            }
        }

        private void PonerALosJugadoresEnSuPosicionDeOrigen(Equipo equipo)
        {
            var list = GetPersonajesDeUnEquipo(equipo);
            int defensaIndex = 0;
            int delanteroIndex = 0;
            foreach (var jugador in list)
            {
                if (jugador is DefensaEspecial)
                {
                    //
                }
                else if (jugador is Defensa defensa)
                {
                    Utils.ConfigurarDefensa(defensa, defensaIndex++);
                }
                else
                {
                    Utils.ConfigurarDelantero(jugador, delanteroIndex++);
                }
            }
        }

        private void PonerALosJugadoresEnSuPosicionDeOrigen()
        {
            PonerALosJugadoresEnSuPosicionDeOrigen(_equipoA);
            PonerALosJugadoresEnSuPosicionDeOrigen(_equipoB);
        }

        private Jugador? GetJugadorQueHaMarcado()
        {
            Pelota pelota = _campo.GetPelota();
            foreach (Personaje pj in _personajeList)
            {
                if (pj is Jugador jugador)
                {
                    if (jugador.HaMarcado(pelota))
                        return jugador;
                }
            }
            return null;
        }

        private bool HayGol()
        {
            return GetJugadorQueHaMarcado() != null;
        }

        private void SumarPuntuacionDeGolAlEquipoCorrespondiente()
        {
            Jugador? jugador = GetJugadorQueHaMarcado();
            if (jugador == null)
                return;

            if (jugador is DefensaEspecial)
                jugador.Equipo.Puntuacion += 1;
            else if (jugador is Defensa)
                jugador.Equipo.Puntuacion += 3;
            else if (jugador is Delantero)
                jugador.Equipo.Puntuacion += 10;
            else
                jugador.Equipo.Puntuacion += 1;
        }

        private void HacerQueLosJugadoresRealicenSuJugada()
        {
            foreach (var pj in _personajeList)
                pj.EjecutarTurno(_campo);
        }
    }
}
