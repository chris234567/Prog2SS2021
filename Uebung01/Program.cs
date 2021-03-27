using System;

namespace Uebung01
{
    class Program
    {
        static void Main(string[] args)
        {
            var randArr = new double[10];

            for (int i = 0; i < randArr.Length; i++)
            {
                var rand = new Random();
                randArr[i] = rand.Next(0, 10);
            }
            foreach (var num in randArr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"sum: {Sum(randArr)}");
            Console.WriteLine($"average: {Average(randArr)}");

            var arr1 = new double[] { 10, 1, 8, 2};
            var arr2 = new double[] { 4, 3, 2, 2, 1 };

            Console.WriteLine(sorted(arr1));
            Console.WriteLine(sorted(arr2));

            barGraph(arr1);
        }

        public static double Sum (double[] nums)
        {
            double sum = 0;

            foreach (var num in nums)
            {
                sum += num;
            }
            return sum;
        }
        public static double Average(double[] nums)
        {
            return Sum(nums) / nums.Length;
        }
        public static string sorted(double[] nums)
        {
            bool lire = true;
            bool reli = true;
            for (int i = 1; i < nums.Length; i++)
            {
                if (!(nums[i - 1] <= nums[i]))
                    lire = false;
                else if (!(nums[i - 1] >= nums[i]))
                    reli = false;
            }
            return lire ? "von links nach rechts incrementiert" : reli ? "von rechts nach links incrementiert" : "nicht sortiert";
        }
        public static void barGraph(double[] bars)
        {
            while (true)
            {
                for (int i = 0; i < bars.Length; i++)
                {
                    if (bars[i] >= 0)
                    {
                        Console.Write("#   ");
                        bars[i]--;
                    }
                    else
                        Console.Write("    ");
                }
                Console.WriteLine();
                int counter = 0;

                foreach (var num in bars)
                {
                    if (num < 0)
                        counter++;
                }
                if (counter == bars.Length)
                    break;
            }
        }
    }
}
