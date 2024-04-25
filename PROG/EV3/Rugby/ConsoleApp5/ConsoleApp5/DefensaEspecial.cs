namespace ConsoleApp5
{
    public class DefensaEspecial : Defensa
    {
        public DefensaEspecial(string name, Equipo equipo, Coordenadas posicion) : base(name, equipo, posicion)
        {
        }

        public DefensaEspecial(string name, Equipo equipo, int x, int y) : this(name, equipo, new Coordenadas() { X = x, Y = y})
        {
        }

        public override void EjecutarTurno(ICampo campo)
        {
        }
    }
}
