namespace Praktikum04
{
    class Person
    {
        public string Name { get; private set; }
        public string PassID { get; private set; }
        public string Adress { get; private set; }
        public VaccinationQueue<Person, VacCat>.VaccAssigner Next { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
