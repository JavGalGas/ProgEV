using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    public class Ejercicio1
    {
        public static List<int> FibonacciSerie(int index)
        {
            int num1 = 0;
            int num2 = 1;
            int num3;
            List<int> fibonacciList = new List<int>();
            
            if (index > 0)
            {
                fibonacciList.Add(num1);

                if (index > 1)
                {
                    fibonacciList.Add(num2);
                    for (int i = 2; i < index; i++)
                    {
                        num3 = num1 + num2;
                        num1 = num2;
                        num2 = num3;
                        fibonacciList.Add(num3);
                    }
                }
            }

            return fibonacciList;
        }
    }
}
