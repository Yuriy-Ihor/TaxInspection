
namespace TaxInspection.Database_elements
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public partial class Tax
    {
        public Tax() { }

        public Tax(int id, string name, string document, int isValid = 1)
        {
            this.TaxId = id;
            this.TaxName = name;
            this.DocumentName = document;
            this.IsValid = isValid == 1;
        }

        [DataMember]
        public static int MaxId { get; set; } = 0;
        [DataMember]
        public int TaxId { get; set; }
        [DataMember]
        public string TaxName { get; set; }
        [DataMember]
        public string DocumentName { get; set; }
        [DataMember]

        private bool _isValid = true;
        [DataMember]
        public bool IsValid 
        { 
            get
            {
                return this._isValid;
            }
            set
            {
                this._isValid = value;

                if (SQLDataLoader.DataLoaded)
                {
                    Extensions.Tools.ExecuteQuery("UPDATE Taxes SET IsValid = " + (this._isValid ? 1 : 0) + " WHERE Id = " + this.TaxId);
                }
            }
        }

        public override string ToString()
        {
            return this.TaxId + ". " + this.TaxName;
        }
    }
}

