using System;

namespace Praktikum02
{
    class Program
    {
        static void Main(string[] args)
        {
            // (hab mal uebersetzt, da schoener... ist ja nicht verboten...)
            // (PrioList, Prioritaet, Anhaengen, niedrig, hoch, top) ^= (PrioList, Priority, Insert, low, high, top)
            PrioList pl = new PrioList();

            pl.Insert(" 9 Auto waschen", Priority.low);
            pl.Insert(" 6 Milch kaufen");
            pl.Insert(" 2 Brot nicht vergessen", Priority.high);
            pl.Insert(" 3 Brief einwerfen", Priority.high);
            pl.Insert(" 1 Praktikumsaufgabe hochladen", Priority.top);
            pl.Insert(" 7 Praktikumsergebnisse anschauen");
            pl.Insert(" 4 Muttertagsgeschenk 9.5.", Priority.high);
            pl.Insert("10 Weihnachtsgeschenke überlegen", Priority.low);
            pl.Insert(" 8 Listenstrukturen noch einmal durcharbeiten");
            pl.Insert(" 5 Steuererklärung bis 2.8.2021", Priority.high);

            // zum testen einfach auskommentieren;)
            // pl.NextTask();
            // pl.NextTask();

            pl.Print();
        }
    }
}
