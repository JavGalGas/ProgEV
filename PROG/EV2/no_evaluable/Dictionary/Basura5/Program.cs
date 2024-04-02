using System.Globalization;

namespace Basura5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            //var result = d.Filter((key, value) =>
            //{
            //    return true; // return false; // return key.Contains("a") || key.Contains("A"); // return key.Contains("a") && value >3;
            //});

            //Console.WriteLine(result);
            d.AddKeyValue("3","Hotel");
            d.AddKeyValue("1", "Alfa");
            d.AddKeyValue("4", "Omega");
            d.AddKeyValue("2", "Foxtrot");
            for (int i = 0; i < d.Count; i++)
            {
                Console.WriteLine($"{d.GetKeyAt(i)}     {d.GetValueAt(i)}");
            }
            d.Remove("1");
            for (int i = 0; i < d.Count; i++)
            {
                Console.WriteLine($"{d.GetKeyAt(i)}     {d.GetValueAt(i)}");
            }

        }
    }
}