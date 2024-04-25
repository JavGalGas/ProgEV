namespace ConsoleApp5
{
    public abstract class Jugador : Personaje
    {
        public string Name { get; set; }
        private Equipo _equipo;

        public DireccionDelEquipo DireccionDelEquipo => _equipo.DireccionDelEquipo;
        public Equipo Equipo => _equipo;

        public Jugador(string name, Equipo equipo, Coordenadas posicion) : base(posicion)
        {
            Name = name;
            _equipo = equipo;
        }

        public bool TengoLaPelota(ICampo campo)
        {
            return TengoLaPelota(campo.GetPelota());
        }

        public bool TengoLaPelota(Pelota pelota)
        {
            return pelota.JugadorQueTieneLaPelota == this;
        }

        public bool HaMarcado(Pelota pelota)
        {
            bool tengoLaPelota = pelota.JugadorQueTieneLaPelota == this;

            if (tengoLaPelota)
            {
                if (DireccionDelEquipo == DireccionDelEquipo.HACIA_ARRIBA)
                {
                    if (Posicion.Y == 0)
                        return true;
                }
                else
                {
                    if (Posicion.Y == ICampo.HEIGHT - 1)
                        return true;                        
                }
            }
            return false;
        }
    }
}
