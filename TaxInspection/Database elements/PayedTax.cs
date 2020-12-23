
namespace TaxInspection.Database_elements
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public abstract class PayedTax
    {
        [DataMember]
        public static int MaxId { get; set; } = 0;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TaxId { get; set; } = 0;
        [DataMember]
        public int PayerId { get; set; } = 0;

        [DataMember]
        public string TaxName { get; set; }
        [DataMember]
        public string PayerName { get; set; }
        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public DateTime OnPayedDate { get; set; } = DateTime.Now;
    }
}
