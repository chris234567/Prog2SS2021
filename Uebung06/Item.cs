using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung06
{
    class Item
    {
        public int ID { get; set; }
        public double Price { get; set; }
        private static int Count { get; set; }
        public Item(double price) 
        {
            ID = Count++;
        }
    }
}
