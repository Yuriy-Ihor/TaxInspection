using System;

namespace TaxInspection.Database_elements
{
    public partial class TaxPayedByNaturalPerson
    {
        public static int MaxId = 0;
        public int Id { get; set; }
        public int TaxId { get; set; } = 0;
        public int PayerId { get; set; } = 0;
        public string TaxName { get; set; }
        public string PayerName { get; set; }
        public string PayerSurname { get; set; }
        public DateTime OnPayedDate { get; set; } = DateTime.Now;
        public int Amount { get; set; }

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
