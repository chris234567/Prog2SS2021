using System;

namespace Praktikum04
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person { Name = "doofus" };
            p.Next = new Person { Name = "pete" };

            Console.WriteLine(p.Name);
            Console.WriteLine(p?.Next.Name);

        }
    }
}
