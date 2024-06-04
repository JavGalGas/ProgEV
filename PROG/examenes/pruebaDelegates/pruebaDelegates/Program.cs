using System.Security.Cryptography.X509Certificates;

namespace pruebaDelegates
{
    public delegate int SortDelegate<T>(T element1, T element2);
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

        }

        public void Sort<T>(T[] list, SortDelegate<T> found)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (list.Length <= 0)
                throw new ArgumentException(nameof(list));
            if (found == null) 
                throw new ArgumentNullException(nameof(found));
            for (int i = 0; i < list.Length-1; i++)
            {
                for(int j = i+1; j<list.Length; j++)
                {
                    if (found(list[i], list[j]) == 1)
                    {
                        Swap(ref list[i], ref list[j]);
                    }
                }  
            }
        }
        public static void Swap<T>(ref T element1, ref T element2)
        {
            T aux = element1;
            element1 = element2;
            element2 = aux;
        }
    }
}
