namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericDictionary<string, int> g = new();
            g.Add("a", 1);
            g.Add("b", 2);
            g.Add("c", 5);
            g.Add("d", 6);

            Console.WriteLine(g.TryGetValue("a"));

            Console.WriteLine("");

            List<string> keys = g.GetKeys();
            List<int> values = g.GetValues();

            for (int i = 0; i < keys.Count; i++)
            {
                Console.WriteLine($"Key: {keys[i]}   Value: {values[i]}");
            }

            Console.WriteLine("");

            Console.WriteLine(g.ContainsValue(4));
            Console.WriteLine(g.ContainsKey("a"));

            Console.WriteLine("");

            g.VisitDictionary(value =>
            {
                if (value < 5)
                {
                    Console.WriteLine("Menor que 5");
                }
            });
        }
    }
}