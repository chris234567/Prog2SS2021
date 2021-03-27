using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung02
{
    class Zeitangabe
    {
        int Tage { get; set; }
        int Stunden { get; set; }
        int Mintuten { get; set; }
        int Sekunden { get; set; }

        public static Zeitangabe operator +(Zeitangabe time1, Zeitangabe time2)
        {



            return new Zeitangabe();
        }
    }
}
