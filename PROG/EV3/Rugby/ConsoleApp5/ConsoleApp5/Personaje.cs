namespace ConsoleApp5
{
    public abstract class Personaje : GameObject
    {
        protected Personaje(Coordenadas posicion) : base(posicion)
        {
        }

        public abstract void EjecutarTurno(ICampo campo);
    }
}
