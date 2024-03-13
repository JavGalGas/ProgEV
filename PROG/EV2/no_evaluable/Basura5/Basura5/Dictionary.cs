namespace Basura5
{
    public delegate bool DictionaryFilterDelegate<K, V>(K key, V value);
    public delegate int ComparatorDelegate<T>(T n1, T n2);

    public class Dictionary<K, V>
    {
        private int _count = 0;
        private class Item
        {
#nullable disable
            public K _key;
            public V _value;
#nullable enable
        }

        private Item[] _items = new Item[0];
        public int Count => _count;
        public bool IsEmpty => _count == 0;

        public void Clear()
        {
            _count = 0;
        }

        public void Add(K key, V value)
        {
            if (Contains(key))
            {
                return;
            }
            else if (Count < _items.Length)
            {
                _items[_count++]._key = key;
#nullable disable
                _items[Count]._value = value;
#nullable enable
            }
            else
            {
                Item[] NewArray = new Item[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    NewArray[i]._key = _items[i]._key;
                    NewArray[i]._value = _items[i]._value;
                }
                NewArray[_count++]._key = key;
#nullable disable
                NewArray[Count - 1]._value = value;
#nullable enable
                _items = NewArray;
            }
        }
        public bool Contains(K key)
        {
            for (int i = 0; i < Count; i++)
            {

#nullable disable
                if (_items[i]._key.Equals(key))
#nullable enable
                {
                    return true;
                }
            }
            return false;
        }

        public int GetKey(K key)
        {
            if (Contains(key))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (_items[i]._key.Equals(key))
                        return i;
                }
            }
            return -1;
        }

        public K GetKeyAt(int index)
        {
            return _items[index]._key;
        }
        public V GetValueAt(int index)
        {
            return _items[index]._value;
        }

        public void AddKeyValue(K key, V value)//igual que el Add, pero organiza (ahora mismo no sabemos organizar por K)
        {
            Item[] NewArray = new Item[++_count];
            for (int i = 0; i < Count - 1; i++)
            {
                NewArray[i]._key = _items[i]._key;
                NewArray[i]._value = _items[i]._value;
            }
            NewArray[Count - 1]._key = key;
#nullable disable
            NewArray[Count - 1]._value = value;
#nullable enable
            Sort(NewArray, (a, b) =>
            {
                if (a._key.Equals(b._key))
                    return 0;
                if (a._key == null || b._key == null)
                    return -1;
#nullable disable
                string key1 = a._key.ToString();
                string key2 = b._key.ToString();
                return key1.CompareTo(key2);
#nullable enable

            });
            _items = NewArray;

        }


        public void Remove(K key)
        {
            int aux = GetKey(key);
            if (aux == -1)
                return;
            Item[] NewArray = new Item[--_count];

            for (int i = 0; i < aux; i++)
            {
                NewArray[i]._key = _items[i]._key;
                NewArray[i]._value = _items[i]._value;
            }
            for (int j = aux + 1; j <= NewArray.Length; j++)
            {
                int aux2 = j - 1;
                NewArray[aux2]._key = _items[j]._key;
                NewArray[aux2]._value = _items[j]._value;
            }
            _items = NewArray;
        }

        public V GetValueWithKey(K key)//modificar
        {
            if (TryGetValue(key, out var v))
            { return v; }
            return v;
        }

        public bool TryGetValue(K key, out V value)//modificar
        {
            for (int i = 0; i < _items.Length; i++)
            {
#nullable disable
                if (key.Equals(_items[i]._key))
                {
                    if (_items[i]._value == null)
                    {
                        value = default;
#nullable enable
                        return false;
                    }
                    else
                    {
                        value = _items[i]._value;
                        return true;
                    }
                }
            }
#nullable disable
            value = default;
#nullable enable
            return false;
        }

        //una lambda cambia el parámetro que normalmente pasamos por una función
        public Dictionary<K, V> Filter(DictionaryFilterDelegate<K, V> where)
        {
            var ret = new Dictionary<K, V>();
            for (int i = 0; i < Count; i++)
            {
                Item item = _items[i];
                bool found = where(item._key, item._value);
                if (found)
                    ret.AddKeyValue(item._key, item._value);
            }
            return ret;
        }

        //igual que Remove(), pero varios key a la vez
        public void Remove(DictionaryFilterDelegate<K, V> where)
        {
            if (where == null)
                return;
            for (int i = 0; i < Count; i++)
            {
                Item item = _items[i];
                bool found = where(item._key, item._value);
                if (found)
                {
                    Remove(item._key);
                    i--;
                }
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }
        public static void Sort<T>(T[] array, ComparatorDelegate<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer(array[i], array[j]) < 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not Dictionary<K, V>)
                return false;
            Dictionary<K, V> s = (Dictionary<K, V>)obj;
            return s._items == _items && s._count == _count;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
