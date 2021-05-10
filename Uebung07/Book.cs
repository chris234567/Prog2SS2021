namespace Uebung07
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
        public override string ToString()
        {
            return $"Item {ID} (Book): \n Price = {Price}\n Author = {Author}\n Title = {Title}\n Songs = {Publisher}";
        }
    }
}
