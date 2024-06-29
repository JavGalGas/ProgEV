namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Este array es par, */
            int[] array = { 1, 2, 3, -2, 8, 4 };
            int minPosition;
            int maxPosition;
            int mediana;
            Exercise1.Function1(array, out minPosition, out maxPosition, out mediana);
            Console.WriteLine($"Minimum Position : {minPosition}.");
            Console.WriteLine($"Maximum Position : {maxPosition}.");
            Console.WriteLine($"Mediana : {mediana}.");
        }
    }
}