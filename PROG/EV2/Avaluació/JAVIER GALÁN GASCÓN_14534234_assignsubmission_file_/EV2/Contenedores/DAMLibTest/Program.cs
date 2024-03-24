using DAMLib;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Basura3
{
    internal class Program
    {
        // Test de caja blanca
        public class Test1Results
        {

            public bool Empty1 { get; set; }

            public int Count1 { get; set; }

            public bool Contains { get; set; }

            public bool EmptyJuan { get; set; }

            public int CountJuan { get; set; }

            public bool ContainsJuan { get; set; }

            public bool EmptyJuan2 { get; set; }

            public int CountJuan2 { get; set; }

            public bool ContainsJuan2 { get; set; }

            public bool EmptyAna { get; set; }

            public int CountAna { get; set; }

            public bool ContainsAna2 { get; set; }

            public bool EmptyAna2 { get; set; }

            public int CountAna2 { get; set; }

            public bool ContainsAna { get; set; }

        }

        // Test de caja blanca

        public static Test1Results Test1(DAMLib.ISet<string> set)
        {
            Test1Results results = new Test1Results();
            {
                set.Clear();

//                results.Empty1 = set.IsEmpty;

//                results.Count1 = set.Count;
//#nullable disable
//                set.Remove(null);

//                set.Add(null);

//                set.Contains(null);
//#nullable enable

                set.Add("Juan");

                results.EmptyJuan = set.IsEmpty;

                results.CountJuan = set.Count;

                results.ContainsJuan = set.Contains("Juan");


                set.Add("Juan");

                results.EmptyJuan2 = set.IsEmpty;

                results.CountJuan2 = set.Count;

                results.ContainsJuan2 = set.Contains("Juan");


                set.Add("Ana");

                results.EmptyAna = set.IsEmpty;

                results.CountAna = set.Count;

                results.ContainsAna = set.Contains("Ana");


                set.Add("Ana");

                results.EmptyAna2 = set.IsEmpty;

                results.CountAna2 = set.Count;

                results.ContainsAna2 = set.Contains("Ana");

            }
            return results;
        }
        //Set
        //ItemSet
        //OrderedItemSet
        //SetWithHash
        public class Prueba
        {
            public string[] _hash = new string[6];

        }
        static void Main(string[] args)
        {
            //DAMLib.Stack<string> stack = new();
            //stack.Push("a");
            //stack.Push("b");
            //stack.Push("c");
            //stack.Push("d");
            //stack.Push("e");
            //stack.Push("f");
            //Console.WriteLine(stack.GetTop().ToString());
            //Console.WriteLine(stack.IsEmpty());
            //Console.WriteLine(stack.GetCount());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.GetTop().ToString());
            //Console.WriteLine(stack.IsEmpty());
            //Console.WriteLine(stack.GetCount());

            //Set<string> set = new();
            //set.Add("a");
            //set.Add("b");
            //set.Add("c");
            //set.Add("d");
            //set.Add("e");
            //Console.WriteLine(set.Cointains("c"));
            //Console.WriteLine(set.Equals(set));
            //set.Remove("c");
            //Console.WriteLine(set.Cointains("c"));

            //DAMLib.Queue<string> queue = new();

            //SetWithHash<string> s = new();
            //s.Add("hola");
            //s.Add("ho");
            //s.Add("hola");
            //s.Add("as");
            //s.Add("brd");
            //s.Add("negh");
            //s.Add("vrtd");
            //s.Add("nyt");
            //s.Add("vdfvg");
            //s.Add("ho");
            //s.Add("bdr");
            //s.Add("negh");
            //s.Add("nyt");
            //s.Add("bdgn");
            //s.Add("nty");
            //s.Add("as");
            //s.Add("brd");
            //Console.WriteLine(s.Cointains("ho"));
            //Console.WriteLine(s.Equals(s));
            //Console.WriteLine();

            //ItemSet<string> itemSet = new ItemSet<string>();
            //itemSet.Add("hola");
            //itemSet.Add("hola2");
            //itemSet.Add("hola3");
            //itemSet.Add("hola4");
            //itemSet.Add("hola5");
            //itemSet[1].Equals("hola2");

            Set<string> set = new Set<string>();
            Test1Results result1 = Test1(set);

            SetWithHash<string> set2 = new SetWithHash<string>();
            Test1Results result2 = Test1(set2);

            ItemSet<string> set3 = new ItemSet<string>();
            Test1Results result3 = Test1(set3);

            OrderedItemSet<string> set4 = new OrderedItemSet<string>();
            Test1Results result4 = Test1(set4);

            string stringResult = JsonSerializer.Serialize(result1);
            string stringResult2 = JsonSerializer.Serialize(result2);
            string stringResult3 = JsonSerializer.Serialize(result3);
            string stringResult4 = JsonSerializer.Serialize(result4);

            Console.WriteLine("---Test Result---");
            Console.WriteLine(stringResult == stringResult2);
            Console.WriteLine(stringResult2 == stringResult3);
            Console.WriteLine(stringResult3 == stringResult4);
            Console.WriteLine(stringResult4 == stringResult);
            Console.WriteLine(stringResult2 == stringResult4);
            Console.WriteLine(stringResult == stringResult3);
        }
        
    }
}