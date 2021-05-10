using System;

namespace Uebung05
{
    public class Stack<T>
    {
        T[] Values = new T[0];
        public void Push(T value)
        {
            var newValues = new T[Values.Length + 1];
            for (int i = 0; i < Values.Length; i++)
            {
                newValues[i] = Values[i];
            }
            newValues[^1] = value;
            Values =  newValues;
        }
        public T Pop() => Peek(true);
        public T Peek(bool b = false)
        {
            var value = Values[^1];
            if (b)
            {
                Values = Values[..^1];
                return value;
            }
            Console.WriteLine(value);
            return value; // value doesnt get used
        }
    }
}
