namespace ExListJGG
{
    public delegate void VisitDelegate<T>(T item);
    public delegate bool SortDelegate<T>(T item, T item2);
    public delegate bool FilterDelegate<T>(T item);

    public class ExList<T>
    {
        private T[] _list = new T[0];
        public int Count => _list.Length;
        public T First => _list.Length > 0 ? _list[0] : throw new Exception();
        public T Last => _list.Length > 0 ? _list[Count-1] : throw new Exception();
        // Javi: Por qué private!?!?
        public ExList<T> Reversed => Reverse();
        //private int _count = 0;

        public ExList()
        {

        }

        private ExList(T[] items)    /*Constructor al que le paso una array de elementos, optimiza bastante las funciones de copia de arrays*/
        {
            _list = ToArray(items);
        }

        public T? GetElementAt(int index)
        {
            if(index < 0 || index >= _list.Length)
                return default(T);
            return _list[index];
        }

        public void SetElementAt(int index, T element)
        {
            if (index < 0 || index >= _list.Length|| element == null)
                return;
            _list[index] = element;
        }

        public void Add(T element)
        {
            if (element == null)
                return;
            int count = Count +1;
            T[] newList = new T[count];
            for (int i = 0; i < Count; i++)
            {
                newList[i] = _list[i];
            }
            newList[count-1] = element;
            //_count++;
            _list = newList;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _list.Length)
                return;
            int count = Count - 1;
            T[] newList = new T[count];
            for(int i = 0;i < index;i++)
            {
                newList[i] = _list[i];
            }
            for(int j = index; j < count;j++)
            {
                newList[j] = _list[j+1];
            }
            //_count--;
            _list = newList;
        }

        public void Clear()
        {
            _list = new T[0];
            //_count = 0;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index >= _list.Length || element == null)
                return;
            int count = Count + 1;
            T[] newList = new T[count];
            for (int i = 0; i < index; i++)
            {
                newList[i] = _list[i];
            }
            newList[index] = element;
            for(int j = index; j < count-1; j++)
            {
                newList[j+1] = _list[j];
            }
            //_count++;
            _list = newList;
        }

        public int IndexOf(T element)
        {
            for(int i=0; i< Count;i++)
            {
                // Javi: Muy listo ...., pero bien
                if (Equals(_list[i], element))
                    return i;
            }
            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) >= 0;
            // Javi: En serio!?!??!?!?!!? 3 lineas????
        }

        public void Visit(VisitDelegate<T> visit)
        {
            foreach(T element in _list)
                visit(element);
        }

        public void Sort(SortDelegate<T> filter)
        {
            for(int i = 0;i< Count-1;i++)
            {
                for(int j= i+1;j< Count;j++)
                {
                    if (filter(_list[i], _list[j]))
                        Swap(ref _list[i], ref _list[j]); // Javi: Ya te digo que esto está mal
                }

            }
            // Javi: Y esto1?!?!
        }//revisar

        public T[] Filter(FilterDelegate<T> found)
        {
            // Javi: Sin implementar, y además no compila

            T[] filteredArray = new T[0];
            foreach (T element in _list)
                if (found(element))
                    AddElementToArray(element, ref filteredArray);
            return filteredArray;
        }

        private void AddElementToArray(T element, ref T[] array)
        {
            T[] newArray = new T[array.Length+1];
            // Javi: Esto es un poco trampa
            //array.CopyTo(newArray, 0);
            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            newArray[array.Length] = element;
            array = newArray;
        }

        public ExList<T> Clone()
        {
            return new ExList<T>(_list);
            //ExList<T> clonedArray = new ExList<T>();
            //T[] array = ToArray();
            //foreach (T element in array)
            //    clonedArray.Add(element);
            //return clonedArray;
            // Javi: MAl
        }

        public T[] ToArray()
        {
            return ToArray(_list);
            //T[] toArray = new T[_list.Length];
            //_list.CopyTo(toArray, 0);
            //return toArray;
        }

        public static T[] ToArray(T[] array)
        {
            if (array == null)
                return new T[0];
            T[] newArray = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            return newArray;
        }

        // Javi: Mal
        private void Swap(ref T element, ref T element2)
        {
            T aux = element;
            element = element2;
            element2 = aux;
        }

        private ExList<T> Reverse()
        {
            int count = Count;  /*Asignación a una variable por optimización*/
            if (count == 0)
                return new ExList<T>();
            var result = new T[count];
            for (int i = 0, j = count -1; i <= j; i++, j--)
            {
                result[i] = _list[j];
                result[j] = _list[i];
            }
            return new ExList<T>(result);
            // Javi: Mala condición, ..., tanto que creo que hace que esto no funcione
        }
    }
}
