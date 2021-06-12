using System.Collections;

namespace Praktikum04
{
    class VaccinationQueue<T1,T2> : IEnumerable where T1 : Person
    {
        public class VaccAssigner
        {
            public Person Person { get; set; }
            public VacCat VacCat { get; set; }
            public VaccAssigner(T1 newPerson, VacCat newVacCat)
            {
                Person = newPerson;
                VacCat = newVacCat;
            }
        }
        public VaccAssigner Head;
        public void RegisterPerson(T1 newPerson, T2 vaccCat)
        {

        }
        public Person Vaccinate()
        {
            if (Head == null) return null;
            VaccAssigner tmp = Head;

            if (Head.Person.Next != null) Head = Head.Person.Next;
            else Head = null;

            return tmp;
        }
        public T1[] VaccinateWholeCat(T2 vacCat)
        {
            int vaccCatCount = 0;
            VaccAssigner curr = Head;

            while (true)
            {
                if (curr. 


                curr = curr.Next;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
