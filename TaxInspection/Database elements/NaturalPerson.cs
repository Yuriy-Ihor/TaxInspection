
namespace TaxInspection.Database_elements
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public partial class NaturalPerson : Person
    {
        public NaturalPerson() { }

        public NaturalPerson(int id, string name, string surname, long identCode, int passportCode)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.IdentificationCode = identCode;
            this.PassportCode = passportCode;
        }

        public static int MaxId { get; set; } = 0;
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public long IdentificationCode { get; set; }
        [DataMember]
        public int PassportCode { get; set; }
    }
}
