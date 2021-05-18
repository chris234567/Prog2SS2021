using System;
using System.Collections;

namespace Uebung08
{
    class RandomNumbers : IEnumerable
    {
        public int[] nums;
        public RandomNumbers(int iterations)
        {
            nums = new int[iterations];
            for (int i = 0; i < iterations; i++)
                nums[i] = new Random().Next(0, 9);
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var ele in nums)
                yield return ele;
        }
    }
}
