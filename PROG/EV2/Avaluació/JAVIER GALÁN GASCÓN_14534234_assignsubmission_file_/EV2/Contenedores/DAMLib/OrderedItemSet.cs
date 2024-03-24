using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMLib
{
    public class OrderedItemSet<T>/*Es ItemSet, pero con una copia ordenada de hash para optimizar la busqueda -- modificar*/ :ISet<T>
    {
        private class Item
        {
#nullable disable
            public T _element;
#nullable enable
            public int _hash;

        }
        private Item[] _items = new Item[0];

        private int _count = 0;

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not OrderedItemSet<T>)
                return false;
            OrderedItemSet<T> s = (OrderedItemSet<T>)obj;
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
#nullable disable
            int hash = element.GetHashCode();
#nullable enable
            for (int i = 0; i < Count; i++)
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
            if (Contains(element))
            {
                return;
            }
            else if (Count < _items.Length)
            {
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

        private int[] HashClone()
        {
            int[] clone = new int[Count];
            for(int i = 0; i< clone.Length;i++)
            {
                clone[i] = _items[i]._hash;
            }
            return clone;
        }

        private int[] OrderedHash()//>>1 : desplaza los bit hacia el lado de las flechas, tantas veces como el número que se añade al lado (88/2 == 88 >> 1 == 0101 1000 -> 0010 1100)
        {
            if ( _items == null || Count == 0)
                return new int[0];
            int[] _hash = HashClone();
            int m = Count;
            int n = m-1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (_hash[i] > _hash[j])
                    {
                        int aux;
                        aux = _hash[i];
                        _hash[i] = _hash[j];
                        _hash[j] = aux;
                    }
                }
            }
            return (_hash);
        }

        //private Item[]? SortItemSet()
        //{
        //    //int n = list.Count;
        //    //int m = n - 1;

        //    //if (list == null || list.Count == 0)
        //    //    return null;

        //    //for (int i = 0; i < m; i++)
        //    //{
        //    //    for (int j = i + 1; j < n; j++)
        //    //    {
        //    //        if (list[i] > list[j])
        //    //        {
        //    //            Swap(list[i], list[j]);
        //    //        }
        //    //    }
        //    //}
        //    //return (list);
        //    int length = Count;
        //    Item[] orderedItemSet = new Item[length];
        //    int[] orderedHash = OrderedHash();
        //    for (int i = 0;i < length;i++)
        //    {
        //        if(orderedHash[i] ==  )
        //    }
        //    return orderedItemSet;
        //}

        private static void Swap(int hash1, int hash2)
        {
            int aux = hash1;
            hash1 = hash2;
            hash2 = aux;
        }

        public void Remove(T element) //implementar hash
        {
            int aux = IndexOf(element);
            if (aux == -1)
                return;
            Item[] NewArray = new Item[--_count];
            int aux2 = NewArray.Length;

            for (int i = 0; i < aux; i++)
            {
                NewArray[i]._element = _items[i]._element;
                NewArray[i]._hash = _items[i]._hash;
            }
            for (int i = aux + 1; i <= aux2; i++)
            {
                NewArray[i - 1]._element = _items[i]._element;
                NewArray[i - 1]._hash = _items[i]._hash;
            }
            _items = NewArray;
        }

        public bool Contains(T element) //implementar hash
        {
            //if (IndexOf(element) == -1)
            //    return false;
            //return true;
            int length = Count;
            int[] orderedHash = OrderedHash();



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
