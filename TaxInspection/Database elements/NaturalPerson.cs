
namespace TaxInspection.Database_elements
{
    public partial class NaturalPerson
    {
        public static int MaxId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long IdentificationCode { get; set; }
        public int PassportCode { get; set; }

        public NaturalPerson() { }

        public NaturalPerson(int id, string name, string surname, long identCode, int passportCode)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.IdentificationCode = identCode;
            this.PassportCode = passportCode;
        }

    }
}
