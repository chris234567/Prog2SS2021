namespace Uebung07
{
    class ShoppingCart
    {
        public Item[] items;
        public double GetPrice()
        {
            double price = 0;
            for (int i = 0; i < items.Length; i++)
            {
                price += items[i].Price;
            }
            return price;
        }
        public string GetAll()
        {
            string s = "";
            for (int i = 0; i < items.Length; i++)
            {
                s += items[i].ToString();
            }
            return s;
        }
    }
}
