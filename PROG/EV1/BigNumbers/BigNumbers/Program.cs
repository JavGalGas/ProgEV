namespace BigNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            BigNumber n1 = new BigNumber(6);
            BigNumber n2 = new BigNumber(-5);
            string n1String = n1.ConvertToString();
            string n2String = n2.ConvertToString();
            BigNumber n3 = BigNumber.Module(n1, n2);
            string result = n3.ConvertToString();
            Console.WriteLine("Número 1:" + n1String);
            Console.WriteLine("Número 2:" + n2String);
            Console.WriteLine("Resultado:" + result);
        }
    }
}