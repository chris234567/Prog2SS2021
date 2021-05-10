namespace Uebung07
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
        public override string ToString()
        {
            return $"Item {ID} (CD): \n Price = {Price}\n Musician = {Musician}\n Album = {Album}\n Songs = {Songs}";
        }
    }
}
