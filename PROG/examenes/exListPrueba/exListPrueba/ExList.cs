using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exListPrueba
{
    public class ExList<T>
    {
        private T[] _list;

        public int Count => _list.Length;
        public T First => (_list.Length <= 0) ? throw new Exception() : _list[0];
        public T Last => (_list.Length <= 0) ? throw new Exception() : _list[_list.Length - 1];

        public Lis
    }
}
