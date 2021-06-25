using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeKlausurWS2020
{
    class AnimalList
    {
        private class Element
        {
            public Animal a;
            public Element next;
            public Element previous;
            public Element(Animal a, Element previous, Element next)
            {
                this.a = a;
                this.previous = previous;
                this.next = next;
            }
        }
        private Element head = null;
        private Element tail = null;
        //... hier ihr code

        public static AnimalList operator + (AnimalList aL, Animal a) => new AnimalList { head = new Element(a, null, aL.head) };
        public static AnimalList operator * (AnimalList aL, int n)
        {
            for (Element curr = aL.head; curr != null; curr = curr.next)
            {
                for (int i = n; i > 0; i--)
                {
                    curr.a.Sound += " " + curr.a.Sound;
                }
            }
            return aL;
        }
        public static implicit operator string(AnimalList aL)
        {
            string s = "";

            for (Element curr = aL.head; curr != null; curr = curr.next)
            {
                if (curr != aL.head) s += " ";
                s += curr.a.Name;
            }
            return s;
        }
    }
    class Animal
    {
        public string Name;
        public string Sound;
        public void MakeSound()
        {
            Console.WriteLine(Sound);
        }
        public Animal(string name, string sound)
        {
            this.Sound = sound;
            this.Name = name;
        }
    }
}
