
namespace TaxInspection.Database_elements
{
    using System;

    public partial class TaxPayedByNaturalPerson : PayedTax
    {
        public string PayerSurname { get; set; }

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
    }
}
