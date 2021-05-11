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
                    myFraction.den = new Random().Next(0, 10);
                    myFraction.num = new Random().Next(0, 10);
                }
                myFractions[i] = myFraction;
            }

            Array.Sort(myFractions);

            foreach (var fraction in myFractions)
            {
                Console.WriteLine(fraction);
            }
        }
    }
}
