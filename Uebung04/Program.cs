using System;

namespace Uebung04
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            var n = new Network();

            while (true)
            {
                Console.WriteLine("Status des Ringpuffernetzwerks:");
                n.Print();
                Console.WriteLine("Menue:");
                Console.WriteLine($"(1) Neue Geraete hinzufuegen");
                Console.WriteLine($"(2) Geraet entfernen");
                Console.WriteLine($"(3) Datenpaket versenden");
                Console.WriteLine($"(4) Programm beenden");
                Console.Write(">");
                int input = GetInputInt();

                if (input == 1)
                {
                    Console.WriteLine($"Neue Geraete hinzufuegen...");
                    int address = -1;

                    if (n.Head != null)
                    {
                        Console.Write("Adresse des Vorgaenger-Geraets > ");
                        address = GetInputInt();
                    }
                    Console.Write("Anzahl neuer Geraete > ");
                    var count = GetInputInt();

                    for (int i = 0; i < count; i++) n.Add(address);

                }
                if (input == 2)
                {
                    Console.WriteLine($"Geraet entfernen...");
                    Console.Write("Adresse des Geraets > ");
                    n.Remove(GetInputInt());
                }
                if (input == 3)
                {
                    Console.WriteLine("Datenpaket versenden...");

                    Console.Write("Datenwert: ");
                    var data = GetInputString();

                    Console.Write("Adresse des Senders: ");
                    var sender = GetInputInt();

                    Console.Write("Adresse der Empfaengers: ");
                    var receiver = GetInputInt();

                    new Simulator(n, new Network.Token(data, sender, receiver, n));
                }
                if (input == 4) break;
            }
        }
        public static int GetInputInt()
        {
            var input = Console.ReadLine();
            return Convert.ToInt32(input);
        }
        public static string GetInputString()
        {
            var input = Console.ReadLine();
            return input.ToString();
        }
    }
}
