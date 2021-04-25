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
            /// <summary>
            /// Goes through elements of priority list recursively and inserts a new element in a to its priority corresponding position.
            /// </summary>
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
            /// <summary>
            /// Goes through elements of priority list recursively and prints the current element and its task to the console.
            /// </summary>
            public void PrintElement()
            {
                Console.WriteLine(this);
                if (Successor != null) Successor.PrintElement(); 
            }
            public override string ToString() => $"{Priority,6}: {Task}";
        }
        Element First { get; set; } // Head of list
        /// <summary>
        /// Adds a new element with a specific task given as a parameter to the priority list.
        /// </summary>
        public void Insert(string task, Priority prio = Priority.normal)
        {
            if (First == null || (int)prio == 0)
            {
                var temp = First;
                First = new Element { Task = task, Priority = prio };

                if ((int) prio == 0)
                    First.Successor = temp;

                return; // early return, falls du's noch nicht kennst (http://www.itamarweiss.com/personal/2018/02/28/return-early-pattern.html)
            }

            First.Add(task, prio);
        }
        /// <summary>
        /// Removes top element of priority list and prints its task to the console.
        /// </summary>
        public void NextTask()
        {
            if (First == null) return; // is the list empty
        
            Console.WriteLine(First.Task);

            if (First.Successor != null) // List.Length > 1
                First = First.Successor;

            else First = null; // only one element -> list now empty
        }
        public void PrintNetwork()
        {
            if (First != null) First.PrintElement();
        }
    }
}
