using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMLib
{

    public class Set<T> : ISet<T>
    {
        private T[] _set = new T[0];
        // Javi: realmente el _count no te haría falta, a no ser que hayas hecho una implementación del set
        // que diferencie entre Count y Capacity
        private int _count = 0;    

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not Set<T>)
                return false;
            Set<T> s = (Set<T>)obj;
            // Javi: Hasta aquí todo correcto, pero el return es incorrecto
            return s._set == _set && s._count == _count;
        }

        public int Count
        {
            get => _count;
        }

        public int IndexOf(T element)
        {
            // Javi: element puede ser null?

            for (int i = 0; i < _set.Length; i++)
            {
#nullable disable
                if (_set[i].Equals(element))
#nullable enable
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            _count = 0;
        }
        public void Add(T element)
        {
            if(Contains(element))
            {
                return;
            } // Javi: Y este intro??

            else if (Count < _set.Length)
            {
                _set[_count++] = element;
            }
            else
            {
                // Javi: camelCase
                T[] NewSet = new T[Count+1]; // Javi: espacios
                for (int i = 0; i < Count; i++)
                {
                    NewSet[i] = _set[i];
                }
                NewSet[_count++] = element;
                _set = NewSet;
            }
        }
        public void Remove(T element)
        {
            // Javi: mejor llámalo index
            int aux = IndexOf(element);
            if (aux == -1)
                return;
            T[] NewSet = new T[--_count];
            
            //for (int i = 0; i < Count - 1; i++)
            //{
            //    if (i == aux)
            //        continue;
            //    NewSet[i] = _set[i];
            //}

            for(int i = 0; i < aux; i++)
                NewSet[i]=_set[i];
            // Javi: guia de estilo
            for (int i = aux+1; i <= NewSet.Length; i++)
                NewSet[i-1] = _set[i];

            _set = NewSet;
        }

        // Javi: MAL!!!!!!!!!!!!!
        // Esta función llama al index of
        public bool Contains(T element)
        {
            //if (IndexOf(element) == -1)
            //    return false;
            //return true;

            for (int i = 0; i < Count; i++)
            {
#nullable disable
                if (_set[i].Equals(element))
#nullable enable
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
           return base.GetHashCode();
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }
    }
}
