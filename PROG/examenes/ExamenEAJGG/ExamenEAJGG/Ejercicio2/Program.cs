namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(2);
            list.Add(4);             
            list.Add(3);
            list.Add(5);
            list.Add(7);
            list.Add(8);
            list.Add(9);

            List<(int, int)>? result = Exercise2.Function2(list, 10);
            if (result != null)
            {
               for (int i = 0; i < result.Count; i++)
               {
                    Console.WriteLine(result[i]);
               }
            }
        }
    }
}