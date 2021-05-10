using System;

namespace Uebung05
{
    public class Queue<T>
    {
        T[] Values = new T[0];
        public void Enqueue(T value)
        {
            var newValues = new T[Values.Length + 1];
            for (int i = 0; i < Values.Length; i++)
            {
                newValues[i + 1] = Values[i];
            }
            newValues[0] = value;
            Values = newValues;
        }
        public T Dequeue() => Peek(true);
        public T Peek(bool b = false)
        {
            var value = Values[0];
            if (b)
            {
                Values = Values[1..];
                return value;
            }
            Console.WriteLine(value);
            return value; // value doesnt get used
        }
    }
}
