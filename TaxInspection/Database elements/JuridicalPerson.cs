namespace TaxInspection.Database_elements
{
    using System;

    public partial class JuridicalPerson
    {
        public static int MaxId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationCode { get; set; }

        public JuridicalPerson() { }
        public JuridicalPerson(int id, string name, DateTime regDate, int code)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = regDate;
            this.RegistrationCode = code;
        }
    }
}
