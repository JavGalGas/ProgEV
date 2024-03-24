using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAMLib
{
    public class ItemSet<T>/*modificar, sobre todo el Equals(cambiar Add y Remove por el correcto)*/: ISet<T>
    {
        private class Item
        {
#nullable disable
            public T _element;
#nullable enable
            public int _hash;

        }
        private Item[] _items= new Item[0];

        private int _count = 0;

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not ItemSet<T>)
                return false;
            ItemSet<T> s = (ItemSet<T>)obj;
            return s._items == _items && s._count == _count;
        }

        public override int GetHashCode()
        {
            return _items.GetHashCode() * _items.GetHashCode() - Count * (_count.GetHashCode() / 77) + Count;
        }


        public int Count
        {
            get => _count;
        }

        public int IndexOf(T element)// implementar hash
        {
            // Javi: Y si element es null!?!?!??!?!
#nullable disable
            int hash = element.GetHashCode();
#nullable enable
            for (int i = 0; i < _items.Length; i++)
            {

                if (hash == _items[i]._hash)
                {
#nullable disable
                    if (_items[i].Equals(element))
#nullable enable
                    {
                        return i;
                    }
                }
#nullable disable
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                // Javi: MAL!!!!!!!!!!!!!!!!!!!!
                else if (_items[i].Equals(element))
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
        public void Add(T element) //implementar hash
        {
            if(Contains(element))
            {
                return;
            }
            else if (Count < _items.Length)
            {
                // Javi: No, ..., te creas una variable llamada index, o position o algo
                // y la usas _item[pos]
                _items[_count++]._element = element;
#nullable disable
                _items[Count]._hash = element.GetHashCode();
#nullable enable
            }
            else
            {
                Item[] NewArray = new Item[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    NewArray[i]._element = _items[i]._element;
                    NewArray[i]._hash = _items[i]._hash;
                }
                NewArray[_count++]._element = element;
#nullable disable
                NewArray[Count - 1]._hash = element.GetHashCode();
#nullable enable
                _items = NewArray;
            }
        }

        public void Remove(T element) //implementar hash
        {
            int aux = IndexOf(element);
            if (aux == -1)
                return;
            Item[] NewArray = new Item[--_count];

            for (int i = 0; i < aux; i++)
            {
                NewArray[i]._element = _items[i]._element;
                NewArray[i]._hash = _items[i]._hash;
            }
            for (int i = aux + 1; i <= NewArray.Length; i++)
            {
                NewArray[i - 1]._element = _items[i]._element;
                // Javi: GUIA DE ESTILO!!!!!!!!!!!
                NewArray[i-1]._hash = _items[i]._hash;
            }
            _items = NewArray;
        }

        //implementar hash
        //la direccion en la memoria ram donde se encuentra el entero (resultEntero), y es donde se encuentra la variable.
        //out, in y ref estan relacionados a direcciones de la memoria RAM

        // Javi: MAL!!, llama a index of
        public bool Contains(T element) //implementar hash
        {
            //if (IndexOf(element) == -1)
            //    return false;
            //return true;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 1; j < Count; j++)
                {
                    if (_items[i]._hash == _items[j]._hash)
                        return true;
                }
            }
            for (int i = 0; i < Count; i++)
            {
#nullable disable
                if (_items[i].Equals(element))
#nullable enable
                    return true;
            }
            return false;
        }
        public bool IsEmpty
        {
            get { return _count == 0; }
        }
    }
}
