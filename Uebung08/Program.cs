using System;

namespace Uebung08
{
    class Program
    {
        static void Main(string[] args)
        {
            var myFractions = new Fraction[10];

            for (int i = 0; i < 10; i++)
            {
                var myFraction = new Fraction();
                {
                    myFraction.den = new Random().Next(1, 10);
                    myFraction.num = new Random().Next(1, 10);
                }
                myFractions[i] = myFraction;
            }

            Array.Sort(myFractions);

            foreach (var fraction in myFractions)
            {
                Console.WriteLine(fraction);
            }
            Console.WriteLine();

            // ----------------

            var nums = new RandomNumbers(10);
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // ----------------

            var numsTwo = new RandomNumbersElaborate(10);
            foreach (RandomNumbersElaborate.Number item in numsTwo)
            {
                Console.WriteLine(item.data);
            }
        }
    }
}
