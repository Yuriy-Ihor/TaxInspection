
namespace TaxInspection.Database_elements
{
    public partial class NaturalPerson
    {
        public static int MaxId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdentificationCode { get; set; }
        public int PassportCode { get; set; }

        public NaturalPerson() { }

        public NaturalPerson(int id, string name, string surname, int identCode, int passportCode)
        {
            Id = id;
            Name = name;
            Surname = surname;
            IdentificationCode = identCode;
            PassportCode = passportCode;
        }

    }
}
