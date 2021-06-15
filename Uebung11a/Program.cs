using System;
using System.Collections.Generic;
using System.Linq;

namespace Uebung11a
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = Enumerable
                .Range(-5, 11)
                .ToList();

            intList.ForEach(Console.WriteLine);
            Console.WriteLine();

            FilterClass.Filter(intList, new FilterClass.SingleFilter(FilterClass.Mod2))
                .ForEach(Console.WriteLine);
            Console.WriteLine();

            FilterClass.Filter(intList, new FilterClass.SingleFilter(FilterClass.Pos))
                .ForEach(Console.WriteLine);
            Console.WriteLine();

            var multiFilter = new FilterClass.MultiFilter(FilterClass.AddNullElem);
            multiFilter += FilterClass.TimesTwo;

            FilterClass.Filter(
                intList, 
                new FilterClass.SingleFilter(FilterClass.Pos), 
                multiFilter
            ).ForEach(Console.WriteLine);
            Console.WriteLine();

            double[] doubleArray = new double[] { -2.5, 5.1, 74.2, -1.2 };

            var calc = new Calc(AbsVal);
            calc += TimesTwo;
            calc += PlusOne;

            InPlace(ref doubleArray, calc);
            foreach (var item in doubleArray)
                Console.WriteLine(item);

        }
        public delegate void Calc(ref double d);
        public static void AbsVal(ref double d) => d = Math.Abs(d);
        public static void TimesTwo(ref double d) => d *= 2;
        public static void PlusOne(ref double d) => d++;
        public static void InPlace(ref double[] doubleArray, Calc calc)
        {
            for (int i = 0; i < doubleArray.Length; i++)
                calc(ref doubleArray[i]);
        }
    }
    class FilterClass
    {
        public delegate bool SingleFilter(int i);
        public delegate void MultiFilter(List<int> l);
        public static List<int> Filter(List<int> intList, FilterClass.SingleFilter filter)
        {
            var intListCopy = new List<int>(intList);  // create copy - only works for value types
            for (int i = 0; i < intListCopy.Count; i++)
            {
                if (!filter(intListCopy[i]))
                {
                    intListCopy.Remove(intListCopy[i]);
                    i--;  // reset counter one step if element was removed
                }
            }
            return intListCopy;
        }
        public static List<int> Filter(List<int> intList, SingleFilter singleFilter, MultiFilter multiFilter)
        {
            var intListCopy = new List<int>(intList);  // create copy - only works for value types
            
            for (int i = 0; i < intListCopy.Count; i++)
            {
                if (!singleFilter(intListCopy[i]))
                {
                    intListCopy.Remove(intListCopy[i]);
                    i--;  // reset counter one step if element was removed
                }
            }
            multiFilter(intListCopy);

            return intListCopy;
        }
        public static bool Mod2(int i) => i % 2 == 0;
        public static bool Pos(int i) => i > 0;
        public static void AddNullElem(List<int> intList) => intList.Add(0);
        public static void TimesTwo(List<int> intList)
        {
            var count = 2 * intList.Count;
            for (int i = 0; i < count; i += 2)
            {
                intList.Insert(i + 1, intList[i]);
            }
        }
    }
}
