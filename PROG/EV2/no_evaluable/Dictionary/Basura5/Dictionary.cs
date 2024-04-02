using System;

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
            else if (_count < _items.Length)
            {
                _items[_count]._key = key;
#nullable disable
                _items[_count]._value = value;
#nullable enable
                _count++;
            }
            else
            {
                Item[] NewArray = new Item[_count + 1];
                for (int i = 0; i < _count; i++)
                {
                    NewArray[i]._key = _items[i]._key;
                    NewArray[i]._value = _items[i]._value;
                }
                NewArray[_count]._key = key;
#nullable disable
                NewArray[_count]._value = value;
#nullable enable
                _items = NewArray;
                _count++;
            }
        }
        public bool Contains(K key)
        {
            if(key == null)
                throw new Exception();
            for (int i = 0; i < _count; i++)
                if (_items[i]._key.Equals(key))
                    return true;
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

        public K? GetKeyAt(int index)
        {
            if (index < 0 || index >= Count)
                return default;
            return _items[index]._key;
        }
        public V? GetValueAt(int index)
        {
            if (index < 0 || index >= Count)
                return default;
            return _items[index]._value;
        }

        public void AddKeyValue(K key, V value)//igual que el Add, pero organiza (ahora mismo no sabemos organizar por K)
        {
            Item[] NewArray = new Item[_count+1];
            for (int i = 0; i < _count; i++)
            {
                NewArray[i]._key = _items[i]._key;
                NewArray[i]._value = _items[i]._value;
            }
            NewArray[_count]._key = key;
#nullable disable
            NewArray[_count]._value = value;
            _count++;
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
            Item[] NewArray = new Item[_count-1];

            for (int i = 0; i < aux; i++)
            {
                NewArray[i]._key = _items[i]._key;
                NewArray[i]._value = _items[i]._value;
            }
            for (int j = aux; j < NewArray.Length; j++)
            {
                int aux2 = j+1;
                NewArray[j]._key = _items[aux2]._key;
                NewArray[j]._value = _items[aux2]._value;
            }
            _items = NewArray;
            _count--;
        }

        public V GetValueWithKey(K key)//modificar
        {
            if (TryGetValue(key, out var v))
                return v; 
            return v;
        }

        public bool TryGetValue(K key, out V value)//modificar
        {
            int keyIndex = GetKey(key);
#nullable disable
            value = default;
#nullable enable
            if (keyIndex < 0)
                return false;
            value = _items[keyIndex]._value;
            return true;
        }

        //una lambda cambia el parámetro que normalmente pasamos por una función
        public Dictionary<K, V> Filter(DictionaryFilterDelegate<K, V> where)
        {
            if (where == null)
                throw new Exception();
            var result = new Dictionary<K, V>();
            for (int i = 0; i < _count; i++)
            {
                Item item = _items[i];
                bool found = where(item._key, item._value);
                if (found)
                    result.AddKeyValue(item._key, item._value);
            }
            return result;
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
                        Swap(ref array[i], ref array[j]);
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
