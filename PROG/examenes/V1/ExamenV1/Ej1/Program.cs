namespace Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> result = Ejercicio1.FibonacciSerie(-1);
            foreach (var value in result) 
            {
                Console.WriteLine(value);
            }
        }
    }
}