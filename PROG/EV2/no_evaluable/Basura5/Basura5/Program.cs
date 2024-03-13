using System.Globalization;

namespace Basura5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            //var result = d.Filter((key, value) =>
            //{
            //    return true; // return false; // return key.Contains("a") || key.Contains("A"); // return key.Contains("a") && value >3;
            //});

            //Console.WriteLine(result);
            d.AddKeyValue("Hotel", 3);
            d.AddKeyValue("Alfa", 1);
            d.AddKeyValue("Omega", 4);
            d.AddKeyValue("Foxtrot", 2);
            for (int i = 0; i < d.Count; i++)
            {
                Console.WriteLine(d.GetKeyAt(i));
                Console.Write("   ");
                Console.Write(d.GetValueAt(i));
            }
            d.Remove("Alfa");
            for (int i = 0; i < d.Count; i++)
            {
                Console.WriteLine(d.GetKeyAt(i));
                Console.Write("   ");
                Console.Write(d.GetValueAt(i));
            }

        }
    }
}