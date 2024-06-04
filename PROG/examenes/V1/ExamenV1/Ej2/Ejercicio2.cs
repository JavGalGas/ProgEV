using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    public class Ejercicio2
    {
        public static int[] Merge(int[] array1, int[] array2)
        {
            if (array1 == null || array1.Length < 0)
                throw new ArgumentException();
            if (array2 == null || array2.Length < 0)
                throw new ArgumentException();

            int[] result = new int[array1.Length + array2.Length];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    result[k++] = array1[i++];
                }
                else
                {
                    result[k++] = array2[j++];
                }
            }

            while (i < array1.Length)
            {
                result[k++] = array1[i++];
            }

            while (j < array2.Length)
            {
                result[k++] = array2[j++];
            }

            return result;
        }
    }
}
