namespace Ej4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPool<string> pool = Pool<string>.CreatePool();

                pool.Release("a");
                pool.Release("b");
                pool.Release("c");

                pool.Acquire();

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