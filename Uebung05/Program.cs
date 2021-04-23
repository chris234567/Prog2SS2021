using System;

namespace Uebung05
{
    class Program
    {
        class Node
        {
            public int Address { set; get; }
            public Node Predeccessor { get; set; }
            public Node Successor { get; set; }
            static int Count { get; set; }
            public Node()
            {
                Address = Count++;
            }
            public Node(int Address)
            {
                this.Address = Address;
            }
            public void Add()
            {
                if (Successor == null)
                {
                    Successor = new Node
                    {
                        Predeccessor = this
                    };
                    return;
                }
                Successor.Add();
            }
            public void Add(int Address)
            {
                if (Successor == null)
                {
                    Successor = new Node
                    {
                        Predeccessor = this
                    };
                    Successor.Address = Address;
                    return;
                }
                Successor.Add(Address);
            }
            public void Sort()
            {
                if (Successor == null) return;
                if (Address > Successor.Address)
                {
                    Successor.Predeccessor = Predeccessor;
                    Successor = Successor.Successor;
                    Predeccessor = Successor;
                    Successor.Successor = this;
                }
                Successor.Sort();
            }
            public void Print()
            {
                if (this == null) return;
                Console.WriteLine($"Node {Address}");
                if (Successor == null) return;
                Successor.Print();
            }
        }
        class List
        {
            public Node Head { get; set; }
            public Node Tail { get; set; }
            public void Add()
            {
                if (Head == null) Head = new Node();
                else Head.Add();
            }
            public void Add(int Address)
            {
                if (Head == null) Head = new Node(Address);
                else Head.Add(Address);
            }
            public void Sort()
            {
                if (Head == null) return;
                Head.Sort();
            }
        }
        static void Main(string[] args)
        {
            var list = new List();

            list.Add(6);
            list.Add(3);
            list.Add(3);
            list.Add(4);
            list.Add(2);
            list.Add(6);
            list.Add(2);

            list.Sort();

            list.Head.Print();
        }
    }
}
