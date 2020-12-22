
namespace TaxInspection.Database_elements
{
    public partial class Tax
    {
        public static int MaxId { get; set; } = 0;

        public Tax(int id, string name, string document, int isValid = 1)
        {
            this.TaxId = id;
            this.TaxName = name;
            this.DocumentName = document;
            this.IsValid = isValid == 1;
        }

        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public string DocumentName { get; set; }

        private bool _isValid = true;
        public bool IsValid 
        { 
            get
            {
                return this._isValid;
            }
            set
            {
                this._isValid = value;

                if(SQLDataLoader.DataLoaded)
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

