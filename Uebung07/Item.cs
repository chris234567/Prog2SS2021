namespace Uebung07
{
    class Item
    {
        public int ID { get; set; }
        private double price;
        public double Price {
            get { return price; }
            set { price = value; } 
        }
        private static int Count { get; set; }
        public Item(double price)
        {
            ID = Count++;
            Price = price;
        }
        public virtual string ToString()
        {
            return $"Item {ID}: \n Price = {Price}";
        }
    }
}
