using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung02
{
    class Zeitangabe
    {
        private int seconds;

        int Days { get; set; }
        int Hours
        {
            get { return Hours; }
            set
            {
                Days += CorrectCalc(Hours, value);
                Hours += (Hours + value) % 60;
            }
        }
        int Minutes
        {
            get { return Minutes; }
            set
            {
                Hours += CorrectCalc(Minutes, value);
                Minutes += (Minutes + value) % 60;
            }
        }
        int Seconds 
        {
            get { return seconds; }
            set
            {
                Minutes += CorrectCalc(Seconds, value);
                Seconds += (Seconds + value) % 60;
            }
        }

        public Zeitangabe() { }
        public Zeitangabe(int days, int hours, int minutes, int seconds)
        {
            this.Days = days;
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
        public static Zeitangabe operator +(Zeitangabe time1, Zeitangabe time2)
        {
            Zeitangabe newTime = new Zeitangabe();
            int time1Seconds = time1.TimeInSeconds();
            int time2Seconds = time2.TimeInSeconds(); 

            return secondsInZeitangabe(time1Seconds + time2Seconds);
        }
        public static Zeitangabe operator -(Zeitangabe time1, Zeitangabe time2)
        {
            Zeitangabe newTime = new Zeitangabe();
            int time1Seconds = time1.TimeInSeconds();
            int time2Seconds = time2.TimeInSeconds();

            return secondsInZeitangabe(time1Seconds - time2Seconds);
        }
        public static Zeitangabe operator ++(Zeitangabe time)
        {
            int temp = time.TimeInSeconds() + 1;

            return secondsInZeitangabe(temp);
        }
        public static Zeitangabe operator --(Zeitangabe time)
        {
            int temp = time.TimeInSeconds() - 1;

            return secondsInZeitangabe(temp);
        }
        public int TimeInSeconds()
        {
            int seconds = 0;
            seconds += Days * 24 * 60 * 60;
            seconds += Hours * 60 * 60;
            seconds += Minutes * 60;
            seconds += Seconds;

            return seconds;
        }
        public static Zeitangabe secondsInZeitangabe(int seconds)
        {
            Zeitangabe newTime = new Zeitangabe();
            newTime.Days += seconds * 24 * 60 * 60;
            newTime.Hours += seconds * 60 * 60;
            newTime.Minutes += seconds * 60;
            newTime.Seconds += seconds;

            return newTime;
        }
        public int CorrectCalc(int unit, int value)
        {
            int temp = unit + value;

            if (temp > 59)
            {
                return Minutes += temp / 60;
            }
            return 0;
        }
    }
}
