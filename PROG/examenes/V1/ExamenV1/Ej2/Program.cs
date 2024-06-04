namespace Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 7, 9, 12, 20 };
            int[] array2 = new int[] { 2, 3, 9};
            try
            {
                int[] result = Ejercicio2.Merge(array1, array2);
                foreach (int i in result)
                    Console.WriteLine(i);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}