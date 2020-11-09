using System;

namespace TaxInspection.Database_elements
{
    public partial class TaxPayedByJuridicalPerson
    {
        public static int MaxId = 0;
        public int Id { get; set; }
        public int TaxId { get; set; } = 0;
        public int PayerId { get; set; } = 0;
        public string TaxName { get; set; }
        public string PayerName { get; set; }
        public DateTime OnPayedDate { get; set; }  = DateTime.Now;
        public int Amount { get; set; }

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

        public override string ToString()
        {
            return Id + " " + TaxId + " " + PayerId + " " + TaxName + " " + PayerName;
        }

    }
}
