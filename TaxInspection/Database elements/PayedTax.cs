
namespace TaxInspection.Database_elements
{
    using System;

    public abstract class PayedTax
    {
        public static int MaxId = 0;
        public int Id { get; set; }
        public int TaxId { get; set; } = 0;
        public int PayerId { get; set; } = 0;

        public string TaxName { get; set; }
        public string PayerName { get; set; }
        public int Amount { get; set; }

        public DateTime OnPayedDate { get; set; } = DateTime.Now;
    }
}
