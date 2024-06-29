using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Exercise1
    {
        public static void Function1(int[] array, out int minPosition, out int maxPosition, out int mediana)
        {
            if(array == null || array.Length == 0)
            {
                minPosition = -1;
                maxPosition = -1;
                mediana = int.MinValue;
                return;
            }

            int[] auxArray = CloneArray(array);
            int aux = auxArray.Length / 2;

            for (int i = 0; i < auxArray.Length -1; i++)
            {
                for (int j = i+1; j < auxArray.Length; j++)
                {
                    if (auxArray[i] > auxArray[j])
                    {
                        Swap(ref auxArray[i], ref auxArray[j]);
                    }
                }
            }

            minPosition = 0;
            maxPosition = auxArray.Length - 1;


            if (auxArray.Length % 2 == 0)
            {             
                mediana = (auxArray[aux -1] + auxArray[aux + 1])/2;
            }
            else
            {
                mediana = auxArray[aux + 1];
            }
        }

        private static int[] CloneArray(int[] array)
        {
            int[] auxArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                auxArray[i] = array[i];
            }
            return auxArray;
        }

        private static void Swap(ref int num1, ref int num2)
        {
            int aux = num1;
            num1 = num2;
            num2 = aux;
        }
    }
}
