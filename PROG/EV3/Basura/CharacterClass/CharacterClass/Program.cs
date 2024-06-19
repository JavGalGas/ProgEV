namespace CharacterClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int aux = 1;
            for (int i = aux; i <= 99; i++)
            {
                result += i*10;
            }
            int result2 = 0;
            int count = 0;
            while (result2 < result)
            {
                result2 += 5;
                count++;
            }
            Console.WriteLine(count);

        }
    }
}