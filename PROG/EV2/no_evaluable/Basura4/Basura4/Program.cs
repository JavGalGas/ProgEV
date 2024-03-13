namespace Basura4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double result1=0.0;
            double result2=0.0;
            Tuple.Ecuation(2.1, 5.0, 2.0, out result1, out result2);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}