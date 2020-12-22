
namespace TaxInspection.Database_elements
{
    using System;

    public partial class TaxPayedByJuridicalPerson : PayedTax
    {
        public TaxPayedByJuridicalPerson(int id, int tax, int payer, string taxName, string payerName, DateTime payedDate, int amount)
        {
            Id = id;
            TaxId = tax;
            PayerId = payer;
            TaxName = taxName;
            PayerName = payerName;
            OnPayedDate = payedDate;
            Amount = amount;
        }
    }
}
