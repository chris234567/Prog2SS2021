using System;

namespace Praktikum04
{
    class Program
    {
        static void Main(string[] args)
        {
            var coronaQueue = new VaccinationQueue<Person, VacCat>();

            coronaQueue.RegisterPerson(
                new Person("Koichi Hirose", "4567", "Capri 4"),
                VacCat.normal
            );
            coronaQueue.RegisterPerson(
                new Person ("Bruno Bucciarati", "1234", "Naples 1"),
                VacCat.high
            );
            coronaQueue.RegisterPerson(
                new Person("Jean Pierre Polnareff", "5678", "Rome 2"),
                VacCat.high
            ); 
            coronaQueue.RegisterPerson(
                new Person("Prosciutto", "8912", "Venice 5"),
                VacCat.low
            );
            coronaQueue.RegisterPerson(
                new Person("Trisha Una", "9123", "Costa Smeralda 3"),
                VacCat.high
            ); 

            PrintQueue(coronaQueue);

            coronaQueue.Vaccinate();
            PrintQueue(coronaQueue);

            coronaQueue.VaccinateWholeCat();
            PrintQueue(coronaQueue);

            Console.WriteLine(coronaQueue);
        }
        public static void PrintQueue(VaccinationQueue<Person, VacCat> queue)
        {
            foreach (var person in queue) Console.WriteLine(person);
            Console.WriteLine();
        }
    }
}
