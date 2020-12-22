
namespace TaxInspection.Database_elements
{
    public partial class NaturalPerson : Person
    {
        public NaturalPerson(int id, string name, string surname, long identCode, int passportCode)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.IdentificationCode = identCode;
            this.PassportCode = passportCode;
        }

        public static int MaxId { get; set; } = 0;

        public string Surname { get; set; }
        public long IdentificationCode { get; set; }
        public int PassportCode { get; set; }
    }
}
