namespace ConsoleApp5
{
    public enum DireccionDelEquipo
    {
        HACIA_ARRIBA = -1,
        HACIA_ABAJO = 1
    }

    public class Equipo
    {
        public DireccionDelEquipo DireccionDelEquipo;
        public int Puntuacion;

        public Equipo(DireccionDelEquipo direccion)
        {
            DireccionDelEquipo = direccion;
        }
    }
}
