
namespace TaxInspection.Database_elements
{
    using System;

    public partial class TaxPayedByJuridicalPerson : PayedTax
    {
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
