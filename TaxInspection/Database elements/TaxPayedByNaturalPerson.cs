
namespace TaxInspection.Database_elements
{
    using System;

    public partial class TaxPayedByNaturalPerson : PayedTax
    {
        public string PayerSurname { get; set; }

        public TaxPayedByNaturalPerson(int id, int tax, int payer, string taxName, string payerName, string payerSurname, DateTime payedDate, int amount)
        {
            Id = id;
            TaxId = tax;
            PayerId = payer;
            TaxName = taxName;
            PayerName = payerName;
            PayerSurname = payerSurname;
            OnPayedDate = payedDate;
            Amount = amount;
        }

    }
}
