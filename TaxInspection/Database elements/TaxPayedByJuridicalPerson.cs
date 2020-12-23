
namespace TaxInspection.Database_elements
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public partial class TaxPayedByJuridicalPerson : PayedTax
    {
        public TaxPayedByJuridicalPerson() { }

        public TaxPayedByJuridicalPerson(int id, int tax, int payer, string taxName, string payerName, DateTime payedDate, int amount)
        {
            this.Id = id;
            this.TaxId = tax;
            this.PayerId = payer;
            this.TaxName = taxName;
            this.PayerName = payerName;
            this.OnPayedDate = payedDate;
            this.Amount = amount;
        }
    }
}
