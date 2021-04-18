using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum02
{
    class PrioList
    {
        class Element
        {
            public string Task { get; set; }
            public Priority Priority { get; set; }
            public Element Successor { get; set; }
            public void Add(string task, Priority prio)
            {
                if ((int)Priority > (int)prio)
                {
                    var tmp1 = Task;
                    var tmp2 = Priority;
                    var tmp3 = Successor;

                    Task = task;
                    Priority = prio;
                    Successor = new Element { Task = tmp1, Priority = tmp2 };
                    Successor.Successor = tmp3;
                }
                else if (Successor == null)
                    Successor = new Element { Task = task, Priority = prio };
                
                else Successor.Add(task, prio); // recursive call advances through elements of list
            }
            public void Print()
            {
                Console.WriteLine(this);
                if (Successor == null) return; // no more elements to print
                Successor.Print();
            }
            public override string ToString() => $"{Priority,6}: {Task}";
        }
        Element First { get; set; } // Head of list
        public void Insert(string task, Priority prio = Priority.normal)
        {
            if (First == null)
            {
                First = new Element { Task = task, Priority = prio };
                return; // early return, falls du's noch nicht kennst (http://www.itamarweiss.com/personal/2018/02/28/return-early-pattern.html)
            }

            First.Add(task, prio);
        }
        public void NextTask()
        {
            if (First == null) return; // is the list empty
        
            Console.WriteLine(First.Task);

            if (First.Successor != null) // List.Length > 1
                First = First.Successor;
            else First = null; // only one element -> list now empty
        }
        public void Print()
        {
            if (First != null) First.Print();
        }
    }
}
