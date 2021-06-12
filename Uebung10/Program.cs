using System;
using System.Collections;
using System.Collections.Generic;

namespace Uebung10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Max: " + Maximum( new int[] { -1, 3, 0, 2 }));
            Console.WriteLine("Max: " + Maximum( new string[] { "Auto", "Zeppelin", "Baum" }));

            var myList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                myList.Add(new Random().Next(1, 10));
            }
            Console.WriteLine();

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Max: " + Maximum(myList));
        }
        public static T Maximum<T>(T param) where T : ICollection, IEnumerable
        {
            var array = new T[param.Count];
            var enumerator = param.GetEnumerator();

            for (int i = 0; i < param.Count; i++)
            {
                enumerator.MoveNext();
                array[i] = enumerator.Current as T;
            }
            Array.Sort(array);
            return array[^1];
        }
    }
}
