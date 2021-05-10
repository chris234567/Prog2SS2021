using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung06
{
    class Book : Item
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public Book(string author, string title, string publisher, double price) : base(price)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
        }
    }
}
