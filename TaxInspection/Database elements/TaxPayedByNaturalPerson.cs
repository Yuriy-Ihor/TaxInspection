
namespace TaxInspection.Database_elements
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public partial class TaxPayedByNaturalPerson : PayedTax
    {
        public TaxPayedByNaturalPerson() { }

        public TaxPayedByNaturalPerson(int id, int tax, int payer, string taxName, string payerName, string payerSurname, DateTime payedDate, int amount)
        {
            this.Id = id;
            this.TaxId = tax;
            this.PayerId = payer;
            this.TaxName = taxName;
            this.PayerName = payerName;
            this.PayerSurname = payerSurname;
            this.OnPayedDate = payedDate;
            this.Amount = amount;
        }

        [DataMember]
        public string PayerSurname { get; set; }
    }
}
