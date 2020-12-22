namespace TaxInspection.Database_elements
{
    using System;

    public partial class JuridicalPerson : Person
    {
        public JuridicalPerson(int id, string name, DateTime regDate, int code)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = regDate;
            this.RegistrationCode = code;
        }

        public static int MaxId { get; set; } = 0;

        public DateTime RegistrationDate { get; set; }
        public int RegistrationCode { get; set; }
    }
}
