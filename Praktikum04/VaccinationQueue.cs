using System;
using System.Collections;

namespace Praktikum04
{
    class NoPersonException : Exception
    {
        public NoPersonException() { }
    }
    class VaccinationQueue<T1,T2> : IEnumerable where T1 : Person where T2 : IComparable
    {
        public class VaccAssigner
        {
            public VaccAssigner Next { get; set; }
            public Person Person { get; set; }
            public VacCat VacCat { get; set; }
            public VaccAssigner(T1 newPerson, VacCat newVacCat)
            {
                Person = newPerson;
                VacCat = newVacCat;
            }
            public void Add(VaccAssigner newPerson)
            {
                if (Next is null)
                {
                    Next = newPerson;
                    return;
                }
                if (Next.VacCat.CompareTo(newPerson.VacCat) > 0)
                {
                    var temp = Next;
                    Next = newPerson;
                    Next.Next = temp;
                    return;
                }
                Next.Add(newPerson);
            }
            public void Remove(VacCat cat)
            {
                if (Next is null) return;

                if (Next.VacCat == cat) Next = Next.Next;

                Next.Remove(cat);
            }
        }
        public VaccAssigner Head;
        public void RegisterPerson(T1 newPerson, VacCat vacCat)
        {
            if (Head == null)
            {
                Head = new VaccAssigner(newPerson, vacCat);
                return;
            }
            if (Head.VacCat.CompareTo(vacCat) > 0)
            {
                Head = new VaccAssigner(newPerson, vacCat) { Next = Head };
                return;
            }
            if (Head.Next is null)
            {
                Head.Next = new VaccAssigner(newPerson, vacCat);
                return;
            }
            Head.Add(new VaccAssigner(newPerson, vacCat));
        }
        public VaccAssigner Vaccinate()
        {
            var prevHead = Head;
            Head = Head?.Next;

            return prevHead;
        }
        public T1[] VaccinateWholeCat()
        {
            if (Head is null) return null;

            var cat = Head.VacCat;
            var vaccCatCount = 0;

            for (var curr = Head; curr != null; curr = curr.Next) // if head is null -> skip for_loop
            {
                if (curr.VacCat == cat) vaccCatCount++;
            }
            var vaccinated = new T1[vaccCatCount];

            var cnt = 0;
            for (var curr = Head; curr != null; curr = curr.Next)
            {
                if (curr.VacCat == cat)
                {
                    vaccinated[cnt] = (T1)curr.Person;
                    cnt++;
                }
            }
            Head.Remove(cat);
            if (Head.VacCat == cat) Head = Head.Next;

            return vaccinated;
        }
        public IEnumerator GetEnumerator()
        {
            for (var curr = Head; curr != null; curr = curr.Next) 
                yield return curr.Person;
        }
        public override string ToString()
        {
            if (Head is null) throw new NoPersonException();

            var queueString = "";
            var curr = Head;
            while (curr != null)
            {
                queueString += $"{curr.Person}   | Category: {curr.VacCat}\n";
                curr = curr.Next;
            }
            return queueString;
        }
    }
}
