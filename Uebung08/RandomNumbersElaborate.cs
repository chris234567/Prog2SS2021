using System;
using System.Collections;

namespace Uebung08
{
    public class RandomNumbersElaborate : IEnumerable
    {
        public class Number
        {
            public int data;
            public Number()
            {
                data = new Random().Next(0, 9);
            }
        }
        private Number[] numbers;
        public int iterations;
        public RandomNumbersElaborate(int iterations)
        {
            numbers = new Number[iterations];
            for (int i = 0; i < iterations; i++)
            {
                numbers[i] = new Number();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public NumbersEnum GetEnumerator()
        {
            return new NumbersEnum(numbers);
        }
    }
    public class NumbersEnum : IEnumerator
    {
        public RandomNumbersElaborate.Number[] numbers;
        int position = -1;
        public NumbersEnum(RandomNumbersElaborate.Number[] list)
        {
            numbers = list;
        }

        object IEnumerator.Current => Current;
        public RandomNumbersElaborate.Number Current
        {
            get
            {
                return numbers[position];
            }
        }
        public bool MoveNext()
        {
            position++;
            return (position < numbers.Length);
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
