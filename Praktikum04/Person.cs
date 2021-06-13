namespace Praktikum04
{
    class Person
    {
        public string Name { get; private set; }
        public string PassID { get; private set; }
        public string Adress { get; private set; }
        public Person(string name, string passID, string adress)
        {
            Name = name;
            PassID = passID;
            Adress = adress;
        }
        public override string ToString() => $"Name: {Name}, PassID: {PassID}, Adress: {Adress}";
    }
}
