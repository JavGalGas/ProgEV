namespace ExListJGG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExList<int> list = new ExList<int>();
            list.Add(9);
            list.Add(-2);
            list.Add(3);
            list.Add(-4);
            list.Add(5);
            list.Add(6);
            list.Add(-7);
            list.Insert(2, 2);
            list.Insert(5, 4);
            Console.WriteLine(list.Contains(2));
            Console.WriteLine(list.Contains(10));
            Console.WriteLine(list.First);
            Console.WriteLine(list.Last);
            Console.WriteLine(list.Count);
            Console.WriteLine();
            list.Sort((item, item2) =>
            {
                return item < item2;
            });
            ExList<int> reversed = list.Reversed;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.GetElementAt(i));
            }
            Console.WriteLine();
            for (int i = 0; i < reversed.Count; i++)
            {
                Console.WriteLine(reversed.GetElementAt(i));
            }
            Console.WriteLine();
            int[] filter = list.Filter(item => item < 5 && item *2 -3 > 2);
            for (int i = 0; i < filter.Length; i++)
            {
                Console.WriteLine(filter[i]);
            }
        }
    }
}
