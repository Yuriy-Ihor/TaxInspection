namespace TaxInspection.Database_elements
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public partial class JuridicalPerson : Person
    {
        public JuridicalPerson() { }

        public JuridicalPerson(int id, string name, DateTime regDate, int code)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = regDate;
            this.RegistrationCode = code;
        }

        public static int MaxId { get; set; } = 0;
        [DataMember]
        public DateTime RegistrationDate { get; set; }
        [DataMember]
        public int RegistrationCode { get; set; }
    }
}
