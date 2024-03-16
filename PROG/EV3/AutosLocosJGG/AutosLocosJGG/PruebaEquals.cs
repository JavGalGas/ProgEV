using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class PruebaEquals
    {
        public int Valor { get; set; }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not PruebaEquals)
                return false;
            PruebaEquals s = (PruebaEquals)obj;
            return s.Valor == Valor;
        }

        // Sobrescribe el método GetHashCode para cumplir con las recomendaciones de diseño
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
