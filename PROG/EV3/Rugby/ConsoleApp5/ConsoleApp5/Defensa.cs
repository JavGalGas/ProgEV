
using System.Xml;

namespace ConsoleApp5
{
    public class Defensa : Jugador
    {
        private double _habilidadDeRobarLaPelota;

        public Defensa(string name, Equipo equipo, Coordenadas posicion, double habilidadDeRobarLaPelota) : base(name, equipo, posicion)
        {
            _habilidadDeRobarLaPelota = habilidadDeRobarLaPelota; // Utils.GetRandomReal(0.4, 0.6);
            if (_habilidadDeRobarLaPelota < 0.4)
                _habilidadDeRobarLaPelota = 0.4;
        }

        private void EjecutarTurnoSinPelota(ICampo campo)
        {
            var pelota = campo.GetPelota();
            bool pelotaAlAlcance = Utils.EstaLaPelotaAlAlcanceDelJugador(this, campo);
            bool pelotaSinDueño = pelota.JugadorQueTieneLaPelota == null;
            if (pelotaAlAlcance)
            {
                if (pelotaSinDueño)
                {
                    pelota.JugadorQueTieneLaPelota = this;
                }
                else
                {
                    if (dados < _habilidadDeRobarLaPelota &&
                        pelota.JugadorQueTieneLaPelota.Equipo != Equipo)
                        pelota.JugadorQueTieneLaPelota = this;

                }
            }
            else
            {
                var dados = Utils.GetRandomReal(0, 1);
                if (dados < 0.5)
                {
                    IrAPorAlguienDelEquipoContrario(campo);
                }
                else
                {
                    IrAPorLAPelota(campo);
                }
            }

        }

        private void IrAPorLAPelota(ICampo campo)
        {
            var pelota = campo.GetPelota();
            var lista = Utils.GetPosicionesADistancia(Posicion, 1);
            lista = Utils.Filtrar(lista, campo);
            lista.Sort((a, b) => 
            {
                if (a.GetDistancia(pelota.Posicion) < b.GetDistancia(pelota.Posicion))
                    return -1;
                if (b.GetDistancia(pelota.Posicion) < a.GetDistancia(pelota.Posicion))
                    return 1;
                return 0;
            });
            if (lista.Count > 0)
            {
                Posicion.X = lista[0].X;
                Posicion.Y = lista[0].Y;
            }
        }

        private void IrAPorAlguienDelEquipoContrario(ICampo campo)
        {
            throw new NotImplementedException();
        }

        public override void EjecutarTurno(ICampo campo)
        {
            bool tengoLaPelota = TengoLaPelota(campo);
            var dados = Utils.GetRandomReal(0, 1);
            if (tengoLaPelota)
            {
                if (dados < 0.6)
                    Avanzar(campo);
                else
                    PasarLaPelota(campo);
            }
            else
            {
                EjecutarTurnoSinPelota(campo);
            }
        }

        private void PasarLaPelota(ICampo campo)
        {
            throw new NotImplementedException();
        }

        private void Avanzar(ICampo campo)
        {
            throw new NotImplementedException();
        }
    }
}
