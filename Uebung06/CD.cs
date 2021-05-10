using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung06
{
    class CD : Item
    {
        public string Musician { get; set; }
        public string Album { get; set; }
        public int Songs { get; set; }
        public CD(string musician, string album, int songs, double price) : base(price)
        {
            Musician = musician;
            Album = album;
            Songs = songs;
        }
    }
}
