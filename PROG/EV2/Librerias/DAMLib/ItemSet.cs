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

        public int Count => _count;
        public bool IsEmpty => _count == 0;

       
        public void Add(T element) //implementar hash
        {
            if(Contains(element) || element == null)
                return;

            if (_count < _items.Length)
            {
                _items[_count]._element = element;
#nullable disable
                _items[_count]._hash = element.GetHashCode();
#nullable enable
                _count++;
            }
            else
            {
                Item[] NewArray = new Item[_count + 1];
                for (int i = 0; i < _count; i++)
                {
                    NewArray[i]._element = _items[i]._element;
                    NewArray[i]._hash = _items[i]._hash;
                }
                NewArray[_count]._element = element;
#nullable disable
                NewArray[_count]._hash = element.GetHashCode();
#nullable enable
                _items = NewArray;
                _count++;
            }
        }

        public void Remove(T element) //implementar hash
        {
            int aux = IndexOf(element);
            if (aux >= 0)
            {
                Item[] NewArray = new Item[_count -1];

                for (int i = 0; i < aux; i++)
                {
                    NewArray[i]._element = _items[i]._element;
                    NewArray[i]._hash = _items[i]._hash;
                }
                for (int i = aux; i <= NewArray.Length; i++)
                {
                    NewArray[i]._element = _items[i + 1]._element;
                    NewArray[i]._hash = _items[i + 1]._hash;
                }
                _items = NewArray;
                _count--;
            }            
        }

 //implementar hash
    //la direccion en la memoria ram donde se encuentra el entero (resultEntero), y es donde se encuentra la variable.
    //out, in y ref estan relacionados a direcciones de la memoria RAM

        public bool Contains(T element) //implementar hash
        {
            return IndexOf(element) >= 0;
//            for (int i = 0; i < Count - 1; i++)
//            {
//                for (int j = 1; j < Count; j++)
//                {
//                    if (_items[i]._hash == _items[j]._hash)
//                        return true;
//                }
//            }
//            for (int i = 0; i < Count; i++)
//            {
//#nullable disable
//                if (_items[i].Equals(element))
//#nullable enable
//                    return true;
//            }
//            return false;
        }

        public int IndexOf(T element)// implementar hash
        {
            if(element == null)
                return -1;
#nullable disable
            int hash = element.GetHashCode();
#nullable enable
            for (int i = 0; i < _count; i++)
            {
                if (hash == _items[i]._hash && _items[i].Equals(element))
                    return i;
#nullable disable
                if (_items[i].Equals(element))
#nullable enable
                    return i;
            }
            return -1;
        }

        public void Clear()
        {
            _count = 0;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not ItemSet<T>)
                return false;
            ItemSet<T> s = (ItemSet<T>)obj;
            if (s._items == _items && s._count == _count)
                for (int i=0; i < _count; i++)
                    if (!Equals(s._items[i]._element, _items[i]._element))
                        return false;
            return false;
        }

        public override int GetHashCode()//comprobar si la función debía cambiar el hash de la clase o los hashes de los elementos
        {
            return _items.GetHashCode() * _items.GetHashCode() - Count * (_count.GetHashCode() / 77) + Count;
        }
    }
}
