namespace Basura6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n1 = 1;
            double n2 = 2;
            Utils.Swap(ref n1, ref n2);

            double[] array = new double[10];

            Utils.Sort(array, (a, b) => {
                if (a == b)
                    return 0;
                if (a > b)
                    return 1;
                return -1;
            });



            Utils.Sort(array, (a, b) => a.CompareTo(b));
        }
    }
}