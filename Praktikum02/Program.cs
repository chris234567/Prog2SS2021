using System;

namespace Praktikum02
{
    class Program
    {
        static void Main(string[] args)
        {
            // (hab mal uebersetzt da schoener... ist ja nicht verboten...)
            // (PrioList, Prioritaet, Anhaengen, niedrig, hoch, top) == (List, Priority, Append, low, high, top)
            List pl = new List();
            pl.Append(" 9 Auto waschen", Priority.low);
            pl.Append(" 6 Milch kaufen");
            pl.Append(" 2 Brot nicht vergessen", Priority.high);
            pl.Append(" 3 Brief einwerfen", Priority.high);
            pl.Append(" 1 Praktikumsaufgabe hochladen", Priority.top);
            pl.Append(" 7 Praktikumsergebnisse anschauen");
            pl.Append(" 4 Muttertagsgeschenk 9.5.", Priority.high);
            pl.Append("10 Weihnachtsgeschenke überlegen", Priority.low);
            pl.Append(" 8 Listenstrukturen noch einmal durcharbeiten");
            pl.Append(" 5 Steuererklärung bis 2.8.2021", Priority.high);
            pl.Append();
        }
    }
}
