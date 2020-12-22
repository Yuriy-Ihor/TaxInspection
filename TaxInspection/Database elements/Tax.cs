﻿
namespace TaxInspection.Database_elements
{
    public partial class Tax
    {
        public static int MaxId = 0;
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public string DocumentName { get; set; }

        private bool _isValid = true;
        public bool IsValid 
        { 
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;

                if(SQLDataLoader.DataLoaded)
                {
                    Extensions.Tools.ExecuteQuery("UPDATE Taxes SET IsValid = " + (_isValid ? 1 : 0) + " WHERE Id = " + TaxId);
                }
            }
        }

        public Tax() { }

        public Tax(int id, string name, string document, int isValid = 1)
        {
            this.TaxId = id;
            this.TaxName = name;
            this.DocumentName = (document);
            this.IsValid = isValid == 1;
        }

        public override string ToString()
        {
            return this.TaxId + ". " + this.TaxName;
        }
    }
}

