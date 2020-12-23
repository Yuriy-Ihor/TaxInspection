
namespace TaxInspection.Database_elements
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public abstract class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
