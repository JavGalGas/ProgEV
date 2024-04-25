namespace ConsoleApp5
{
    public interface ICampo
    {
        const int WIDTH = 10;
        const int HEIGHT = 20;

        bool EstaDisponible(int x, int y);
        Personaje? GetPersonajeAt(int x, int y);
        void AddPersonaje(Personaje personaje);
        Pelota GetPelota();

        bool EstaDisponible(Coordenadas posicion)
        {
            return posicion == null ? false : EstaDisponible(posicion.X, posicion.Y);
        }

        Personaje? GetPersonajeAt(Coordenadas posicion)
        {
            return posicion == null ? null : GetPersonajeAt(posicion.X, posicion.Y);
        }

        List<Coordenadas> GetCasillasDisponibles()
        {
            List<Coordenadas> ret = new();

            for (int x = 0; x < ICampo.WIDTH; x++)
            {
                for (int y = 0; y < ICampo.HEIGHT; y++)
                {
                    if (EstaDisponible(x, y))
                        ret.Add(new Coordenadas(x, y));
                }
            }

            return ret;
        }
    }

    public class CampoBasadoEnListaDeCosas : ICampo
    {
        private Pelota _pelota = new Pelota(new Coordenadas(0, 0));
        private List<Personaje> _personajeList = new();
        
        public void AddPersonaje(Personaje personaje)
        {
            if (personaje == null)
                throw new Exception("El personaje es null");
            if (!((ICampo)this).EstaDisponible(personaje.Posicion))
                throw new Exception("Personaje con posicion invalida");
            if (Contains(personaje))
                throw new Exception("El personaje ya existe");
            _personajeList.Add(personaje);
        }

        public bool Contains(Personaje personaje)
        {
            return IndexOf(personaje) >= 0;
        }

        public int IndexOf(Personaje personaje)
        {
            for (int i = 0; i < _personajeList.Count; i++)
                if (_personajeList[i] == personaje)
                    return i;
            return -1;
        }

        public bool EstaDisponible(int x, int y)
        {
            if (x < 0 || x >= ICampo.WIDTH)
                return false;
            if (y < 0 || y >= ICampo.HEIGHT)
                return false;
            if (GetPersonajeAt(x, y) != null)
                return false;
            return true;
        }

        public Pelota GetPelota()
        {
            return _pelota;
        }

        public Personaje? GetPersonajeAt(int x, int y)
        {
            foreach (var p in _personajeList)
                if (p.Posicion.X == x && p.Posicion.Y == y)
                    return p;
            return null;
        }
    }

    public class CampoBasadoEnArray : ICampo
    {
        public void AddPersonaje(Personaje personaje)
        {
            throw new NotImplementedException();
        }

        public bool EstaDisponible(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Pelota GetPelota()
        {
            throw new NotImplementedException();
        }

        public Personaje? GetPersonajeAt(int x, int y)
        {
            throw new NotImplementedException();
        }
    }

}