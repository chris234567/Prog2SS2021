using System;

namespace Uebung05
{
    class Program
    {
        class List
        {
            internal class Node
            {
                public int Address { set; get; }
                public Node Prev { get; set; }
                public Node Next { get; set; }
                public void Add(int Address)
                {
                    if (Next == null)
                    {
                        Next = new Node()
                        {
                            Address = Address,
                            Prev = this
                        };
                        return;
                    }
                    Next.Add(Address);
                }
                public void Sort()
                {
                    if (Next == null) return;

                    if (Address > Next.Address)
                    {
                        Prev.Next = Next;
                        Next.Prev = Prev;
                        Prev = Next;
                        var temp = Next.Next;
                        Next.Next = this;
                        Next = temp;
                        if (Next == null) return;
                        Next.Prev = this;
                    }
                    Next.Sort();
                }
                public void Print()
                {
                    if (this == null) return;
                    Console.WriteLine($"Node {Address}");
                    if (Next == null) return;
                    Next.Print();
                }
                public void Reverse()
                {
                    if (Next == null)
                    {
                        var temp_1 = Prev;
                        Prev = Next;
                        Next = temp_1;
                        return;
                    }
                    Next.Reverse();
                    var temp = Prev;
                    Prev = Next;
                    Next = temp;
                }
            }
            public Node Head { get; set; }
            public Node Tail { get; set; }
            public int Count { get; set; }
            public void Add(int Address)
            {
                Count++;
                if (Head == null) Head = new Node() { Address = Address };
                else Head.Add(Address);
            }
            public void Sort()
            {
                if (Head == null || Head.Next == null) return;

                if (Head.Address > Head.Next.Address)
                {
                    var prevHead = Head;
                    var newHead = Head.Next;

                    newHead.Prev = null;
                    prevHead.Next = newHead.Next;
                    newHead.Next = prevHead;
                    prevHead.Prev = newHead;
                    prevHead.Next.Prev = prevHead;

                    Head = newHead;
                }
                Head.Next.Sort();
            }
            public bool CheckSort()
            {
                var b = true;
                var curr = Head;

                for (int i = 0; i < this.Count - 1; i++)
                {
                    b = false;
                    if (curr.Next == null) continue;
                    if (curr.Address > curr.Next.Address)
                    {
                        b = true;
                        continue;
                    }
                    curr = curr.Next;
                }
                return b;
            }
            public void Reverse()
            {
                Head.Reverse();

                var curr = Head;
                while (true)
                {
                    if (curr.Prev == null) break;
                    curr = curr.Prev;
                }
                Head = curr;
            }
        }
        static void Main(string[] args)
        {
            #region list
            var list = new List();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Random().Next(1, 101));
            }

            Console.WriteLine("U n s o r t e d !");
            list.Head.Print();
            Console.WriteLine();

            bool b = true;

            while (b)
            {
                b = list.CheckSort();
                list.Sort();
            }

            Console.WriteLine("S o r t e d !");
            list.Head.Print();
            Console.WriteLine();

            Console.WriteLine("R e v e r s e d !");
            list.Reverse();
            list.Head.Print();
            #endregion

            #region Stack
            Console.WriteLine();
            Console.WriteLine("S t a c k !");
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine(stack.Pop());
            stack.Peek();
            #endregion

            #region Queue
            Console.WriteLine();
            Console.WriteLine("Q u e u e !");
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine(queue.Dequeue());
            queue.Peek();
            #endregion
        }
    }
}
