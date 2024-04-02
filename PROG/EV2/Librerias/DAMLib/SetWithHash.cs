using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMLib
{
    public class SetWithHash<T> : ISet<T>
    {
        private T[] _set = new T[0];
        private int[] _hash = new int[0];
        private int _count = 0;

        public int Count => _count;
        public bool IsEmpty => (_count == 0);
        
        public void Add(T element) //implementar hash
        {
            if (Contains(element) || element == null)
                return;

            if (_count < _set.Length)
            {
                _set[_count] = element;
#nullable disable
                _hash[_count] = element.GetHashCode();
#nullable enable
                _count++;
            }
            else
            {
                T[] NewSet = new T[_count + 1];
                int[] NewHash = new int[_count + 1];
                for (int i = 0; i < _count; i++)
                {
                    NewSet[i] = _set[i];
                    NewHash[i] = _hash[i];
                }
                NewSet[_count] = element;
#nullable disable
                NewHash[_count] = element.GetHashCode();
#nullable enable
                _set = NewSet;
                _hash = NewHash;
                _count++;
            }
        }

        public void Remove(T element) //implementar hash
        {
            int aux = IndexOf(element);
            if (aux >= 0)
            {
                T[] NewSet = new T[_count - 1];
                int[] NewHash = new int[_count - 1];

                for (int i = 0; i < aux; i++)
                {
                    NewSet[i] = _set[i];
                    NewHash[i] = _hash[i];
                }
                for (int j = aux; j < NewSet.Length; j++)
                {
                    NewSet[j] = _set[j + 1];
                    NewHash[j] = _hash[j + 1];
                }
                _set = NewSet;
                _hash = NewHash;
                _count--;
            }            
        }

        public int IndexOf(T element)// implementar hash
        {
            if (element == null)
                return -1;
#nullable disable
            int h = element.GetHashCode();
#nullable enable
            for (int i = 0; i < _count; i++)
            {
#nullable disable
                if (h == _hash[i] && _set[i].Equals(element))
#nullable enable
                    return i;

#nullable disable
                if (_set[i].Equals(element))
#nullable enable
                    return i;
            }
            return -1;
        }

        public void Clear()
        {
            _count = 0;
        }
        public bool Contains(T element) //implementar hash
        {
            return IndexOf(element) >= 0;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not SetWithHash<T>)
                return false;
            SetWithHash<T> s = (SetWithHash<T>)obj;
            return s._set == _set && s._count == _count;
        }

        public override int GetHashCode()//comprobar si la función debía cambiar el hash de la clase o los hashes del array
        {
            return _hash.GetHashCode() * _set.GetHashCode() - Count * (_count.GetHashCode() / 77) + Count;
        }

    }
}
