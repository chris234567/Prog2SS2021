namespace Uebung07
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
        public override string ToString()
        {
            return $"Item {ID} (Video): \n Price = {Price}\n Director = {Director}\n Title = {Title}\n DLC = {DLC}";
        }
    }
}
