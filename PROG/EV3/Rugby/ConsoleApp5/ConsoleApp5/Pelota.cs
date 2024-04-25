
namespace ConsoleApp5
{
    public class Pelota : GameObject
    {
        public Jugador? JugadorQueTieneLaPelota;

        public Pelota(Coordenadas posicion) : base(posicion)
        {
        }

        public Coordenadas GetCoordenadas()
        {
            if (JugadorQueTieneLaPelota != null)
                return JugadorQueTieneLaPelota.Posicion;
            return Posicion;
        }
    }
}
