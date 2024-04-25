namespace ConsoleApp5
{
    public class GameObject
    {
        private Coordenadas _posicion;

        public Coordenadas Posicion => _posicion;

        public GameObject(Coordenadas posicion)
        {
            _posicion = posicion;
            if (_posicion == null)
            {
                _posicion = new Coordenadas()
                {
                    X = 0,
                    Y = 0
                };
            }
        }
    }
}
