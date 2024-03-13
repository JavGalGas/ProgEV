using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMLib
{
    public class Queue<T>
    {
        private T[] _queue = new T[0];
        private int _count = 0;

        public int Count
        {
            get => _count;
        }
        public T First
        {
            get
            {
#nullable disable
                return (IsEmpty) ? default(T) :  _queue[0];
#nullable enable
            }
        }
        public T Last
        {
            get
            {
#nullable disable
                return (IsEmpty) ? default(T) : _queue[Count - 1];
#nullable enable
            }
        }
        public bool IsEmpty
        {
            get => Count == 0;
        }

        public void Enqueue(T element)
        {
            if (Count < _queue.Length)
                _queue[_count++] = element;
            else
            {
                T[] NewQueue = new T[Count + 1];
                for (int i = 0; i < Count; i++)
                {
                    NewQueue[i] = _queue[i];
                }
                NewQueue[Count-1] = element;
                _queue = NewQueue;
            }
        }
        public T Dequeue()
        {
            if (IsEmpty)
#nullable disable
                return default(T);
#nullable enable
            T element = First;
            T[] NewQueue = new T[Count - 1];
            for (int i = 1; i < Count - 1; i++)
            {
                NewQueue[i] = _queue[i];
            }
            _queue = NewQueue;
            return element;
        }
       
        public void Clear()
        {
            _count = 0;
        }
 
         
    }
}
