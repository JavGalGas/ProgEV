using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum Estado
    {
        Esperando,
        Procesando_moneda,
        Retirando_producto,
        Devolviendo_cambio
    }
    public class CoffeeMachine
    {
        private Estado state;

        public CoffeeMachine()
        {
            state=Estado.Esperando;
        }

        public Estado GetState()
        {
            return state;
        }
        
        public Estado ChangeToNextState()
        {
            if (state == Estado.Esperando)
                return state = Estado.Procesando_moneda;
            else if(state == Estado.Procesando_moneda)
                return state = Estado.Retirando_producto;
            else if(state == Estado.Retirando_producto)
                return state = Estado.Devolviendo_cambio;
            else
                return state = Estado.Esperando;
        }
    }
}
