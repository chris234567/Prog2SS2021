using System;
using System.Collections;

namespace ProbeKlausurWS2020
{
    public enum PassengerCat
    {
        FirstClass,
        BusinessClass,
        EconomyClass
    }
    class AirportQueue<T1,T2> where T2 : IComparable, IEnumerable
    {
        public class Node
        {
            public T1 passanger;
            public T2 passengerCat;
            public Node next;
        }
        public Node head;
        public void Enqueue(T1 passanger, T2 passengerCat)
        {
            if (head is null)
            {
                head = new Node { passanger = passanger, passengerCat = passengerCat };
                return;
            }
            else if (head.next is null)
            {
                if (passengerCat.CompareTo(head.next.passengerCat) < 0)
                {
                    head = new Node 
                    { 
                        passanger = passanger, passengerCat = passengerCat,
                        next = head
                    };
                    return;
                }
            }
            for (Node curr = head; curr.next != null; curr = curr.next)
            {
                if (passengerCat.CompareTo(curr.next.passengerCat) < 0)
                {
                    curr.next = new Node
                    {
                        passanger = passanger,
                        passengerCat = passengerCat,
                        next = curr.next
                    };
                    return;
                }
            }
        }
        public Node Dequeue()
        {
            var tmp = head;
            head = head?.next;
            return tmp;  // returns null if head was null
        }
        public T1[] DequeueCat()
        {
            if (head is null) return new T1[] { };

            var cat = head.passengerCat;
            var count = 0;

            for (Node curr = head; curr != null; curr = curr.next)
            {
                if (cat.CompareTo(curr.passengerCat) != 0) break;  // not same category
                count++;
            }

            var arrayT1 = new T1[count];
            count = 0;

            for (Node curr = head; curr != null; curr = curr.next)
            {
                if (cat.CompareTo(curr.passengerCat) == 0) 
                {
                    arrayT1[count] = curr.passanger;
                }
                count++;
            }

            return arrayT1;
        }
        public IEnumerator GetEnumerator()  // foreach
        {
            for (var curr = head; curr != null; curr = curr.next)
                yield return curr.passanger.ToString();
        }
        public override string ToString()
        {
            if (head is null) throw new EmptyQueueException();

            string s = "";
            for (Node curr = head; curr != null; curr = curr.next)
            {
                s += $"{curr.passanger.ToString()}, {curr.passengerCat}\n";  // \n -> per line one person
            }
            return s;
        }
    }
    class EmptyQueueException : Exception { }
    class Passanger
    {
        string name;
        string passPortId;
        string nationality;
        public override string ToString()
        {
            return $"{name} {passPortId} {nationality}";
        }
    }
}
