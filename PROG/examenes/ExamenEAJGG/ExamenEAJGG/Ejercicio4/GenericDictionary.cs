using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    public class GenericDictionary<K, V>
    {
        public delegate void VisitDelegate<T>(T element);

        private List<(K,V)> _dictionary = new List<(K, V)>();

        public bool TryGetValue(K key, out V value)
        {
            foreach (var item in _dictionary)
            {
                if (Equals(item.Item1, key))
                {
                    value = item.Item2;

                }
                if (item.Item1.Equals(key))
                {

                }
            }
            value = 
            return default;
        }


        public List<K> GetKeys()
        {
            List<K> result = new List<K> ();
            foreach (var item in _dictionary)
            {
                result.Add(item.Item1);
            }
            return result;
        }

        public List<V> GetValues()
        {
            List<V> result = new List<V>();
            foreach (var item in _dictionary)
            {
                result.Add(item.Item2);
            }
            return result;
        }

        public void VisitDictionary(VisitDelegate<V> visit)
        {
            foreach (var item in _dictionary)
            {
                visit(item.Item2);
            }
        }

        public void Add(K key, V value)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            _dictionary.Add((key,value));
        }

        public bool ContainsKey(K key)
        {
            foreach (var item in _dictionary)
            {
                if (Equals(item.Item1, key))
                    return true;
            }
            return false;
        }

        public bool ContainsValue(V value)
        {
            foreach (var item in _dictionary)
            {
                if (Equals(item.Item2, value))
                    return true;
            }
            return false;
        }

    }
}
