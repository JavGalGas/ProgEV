using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Exercise2
    {
        public static List<(int, int)>? Function2(List<int> list, int objetivo)
        {
            if (list == null)
                return null;

            List<(int, int)> resultList = new();

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] + list[j] == objetivo)
                        resultList.Add((list[i] , list[j]));
                }
            }
            return resultList;
        }
    }
}
