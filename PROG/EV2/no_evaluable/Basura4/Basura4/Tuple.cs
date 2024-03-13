using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basura4
{
    public class Tuple
    {

        //(int, string) _tupleEx1 = (4,"hola");
        //Tuple<int, string> _tupleEx2 = new(5,"adios");

        //(r1, r2)
        //out r1, out r2
        //             __________
        //      -b +- v b^2 -4ac
        //x=    -----------------
        //              2a
        public static void Ecuation(double a, double b, double c, out double result1, out double result2)
        {
            SolveEquation2(a, b, c, out result1, out result2);
            //result1 = (-b + Math.Sqrt(Math.Pow(b,2) - 4.0 * a * c)) / (2.0 * a);
            //result2 = (-b - Math.Sqrt(Math.Pow(b, 2) - 4.0 * a * c)) / (2.0 * a);
            //var result = ((-b + Math.Sqrt(Math.Pow(b, 2) - 4*a * c)/(2*a)), (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c) / (2 * a)));

        }
        public static bool SolveEquation2(double a, double b, double c, out double result1, out double result2)
        {
            result1 = double.NaN;
            result2 = double.NaN;
            if (a == 0.0)
                return false;
            double r = Math.Pow(b, 2) - 4 * a * c;
            if ((Math.Pow(b, 2) - 4 * a * c) < 0)
                return false;
            double root = Math.Sqrt(r);
            double denom = 1.0 / (2.0 * a);
            result1 = (-b + root) * denom;
            result2 = (-b - root) * denom;
            return true;
        }


    }
}
