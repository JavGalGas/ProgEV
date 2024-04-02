using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExListJGG
{
    public delegate void Visitor<T>(T item);
    public delegate bool Filter<T> (T item, T item2);

    public class ExList<T>
    {
        private T[] list = new T[0];
        public int Count => list.Length;
        public T First => list.Length > 0 ? list[0] : throw new Exception();
        public T Last => list.Length > 0 ? list[Count-1] : throw new Exception();
        // Javi: Por qué private!?!?
        public T[] Reversed => Reverse();
        int 


        public T? GetElementAt(int index)
        {
            if(index < 0 || index >= list.Length)
                return default(T);
            return list[index];
        }

        public void SetElementAt(int index, T element)
        {
            if (index < 0 || index >= list.Length|| element == null)
                return;
            list[index] = element;
        }

        public void Add(T element)
        {
            if (element == null)
                return;
            int count = Count +1;
            T[] newList = new T[count];
            for (int i = 0; i < Count; i++)
            {
                newList[i] = list[i];
            }
            newList[count-1] = element;
            list = newList;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= list.Length)
                return;
            int count = Count - 1;
            T[] newList = new T[count];
            for(int i = 0;i < index;i++)
            {
                newList[i] = list[i];
            }
            for(int j = index; j < count;j++)
            {
                newList[j] = list[j+1];
            }
            list = newList;
        }

        public void Clear()
        {
            list = new T[0];
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index >= list.Length || element == null)
                return;
            int count = Count + 1;
            T[] newList = new T[count];
            for (int i = 0; i < index; i++)
            {
                newList[i] = list[i];
            }
            newList[index] = element;
            for(int j = index; j < count-1; j++)
            {
                newList[j+1] = list[j];
            }
            list = newList;
        }

        public int IndexOf(T element)
        {
            for(int i=0; i< Count;i++)
            {
                // Javi: Muy listo ...., pero bien
                if (Equals(list[i], element))
                    return i;

            }
            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) < 0;
            // Javi: En serio!?!??!?!?!!? 3 lineas????
        }

        public void Visit(Visitor<T> visit)
        {
            foreach(T element in list)
                visit(element);
        }

        public void Sort(Filter<T> filter)
        {
            for(int i = 0;i< Count-1;i++)
            {
                for(int j=1;j< Count;j++)
                {
                    bool found = filter(list[i], list[j]);
                    if (found)
                        SortElements(list[i], list[j]); // Javi: Ya te digo que esto está mal
                }

            }
            // Javi: Y esto1?!?!
            foreach (T element in list)
            {
                
            }
                    
        }//revisar

        public T[] Filter(Filter<T> filter)
        {
            // Javi: Sin implementar, y además no compila

            //T[] filteredArray = new T[0];
            //foreach (T element in list)
            //    if (filter(element))
            //        AddElementToArray(element,filteredArray);
            //return filteredArray;
        }

        public void AddElementToArray(T element, T[] array)
        {
            T[] newArray = new T[array.Length+1];
            // Javi: Esto es un poco trampa
            array.CopyTo( newArray, 0 );
            newArray[array.Length] = element;
            array = newArray;
        }

        public T[] Clone()
        {
            // Javi: MAl
            T[] clonedArray = new T[list.Length];
            return clonedArray;
        }

        public T[] ToArray()
        {
            T[] toArray = new T[list.Length];
            list.CopyTo(toArray, 0);
            return toArray;
        }

        // Javi: Mal
        private void SortElements(T element, T element2)
        {
            T aux = element;
            element = element2;
            element2 = element;
        }

        public T[] Reverse()
        {
            T[] reverseArray = Clone();
            // Javi: Mala condición, ..., tanto que creo que hace que esto no funcione
            for (int i = 0, j= Count-1; i < Count; i++, j--)
            {
                reverseArray[i] = list[j];
            }
            return reverseArray;
        }
    }
}
