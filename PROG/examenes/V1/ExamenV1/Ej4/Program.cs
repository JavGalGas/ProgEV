namespace Ej4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPool<string> pool = Pool<string>.CreatePool();
                //Console.WriteLine(pool.First);
                //Console.WriteLine(pool.Last);

                Console.WriteLine("");
                pool.Release("a");
                pool.Release("b");
                pool.Release("c");
                Console.WriteLine(pool.First);
                Console.WriteLine(pool.Last);
                Console.WriteLine("");
                pool.Acquire();
                Console.WriteLine(pool.First);
                Console.WriteLine(pool.Last);
                Console.WriteLine("");
                string[] array = pool.ToArray();
                foreach(string item in array)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}