using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung06
{
    class Video : Item
    {
        public string Director { get; set; }
        public string Title { get; set; }
        public bool DLC { get; set; }
        public Video(string author, string title, bool dlc, double price) : base(price)
        {
            Director = author;
            Title = title;
            DLC = dlc;
        }
    }
}
