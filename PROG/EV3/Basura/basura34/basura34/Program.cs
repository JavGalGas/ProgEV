namespace basura34
{
    internal class Program
    {
        public delegate double MathFunction(double x);
        public static double CalculateIntegralArea(MathFunction f, double x0, double x1, double dx = 0.0001)
        {
            if (f == null)
            {
                return double.MinValue;
            }
            double resul = 0.0;
            double y = 0.0;
            while (x0 <= x1) 
            { 
                y = f(x0);
                resul += y * dx;
                x0 += dx;
            }
            //resul = (x1 - x0) * f(x0);

            //resul = ((x1 - x0)) * (f(x0) + f(x1)) / 2;

            //resul = ((x1 - x0) / 6) * (f(x0) + 4 * f((x0 + x1) / 2) + f(x1));
            return resul;
        }
        static void Main(string[] args)
        {
            double integral = CalculateIntegralArea(x =>
            {
                return 2 * (x * x * x) + x;
            }, 0.0, 5.0);

            Console.WriteLine(integral);
        }
    }
}