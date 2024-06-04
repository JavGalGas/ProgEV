using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    public class Pool<T> : IPool<T>
    {
        private List<T> _pool = new List<T>();

        public T? First  
        {  
            get => (_pool.Count <= 0) ? default : _pool[_pool.Count-1];
        }

        public T? Last
        {
            get => (_pool.Count <= 0) ? default : _pool[0];
        }

        public int Count {  get => _pool.Count; }

        private Pool()
        {
        }

        public static Pool<T> CreatePool()
        {
            Pool<T> pool = new Pool<T>();
            return pool;
        }

        public IPool<T> Clone()
        {
            Pool<T> auxPool = new Pool<T>();
            foreach (var item in _pool)
            {
                auxPool._pool.Add(item);
            }
            return auxPool;
        }

        public void Release(T element)
        {
            if (element == null) 
                throw new ArgumentNullException(nameof(element));
            _pool.Add(element);
        }

        public T Acquire()
        {
            T result = _pool[Count-1];
            _pool.RemoveAt(Count-1);
            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                result[i] = _pool[i];
            }
            return result;
        }
    }
}
