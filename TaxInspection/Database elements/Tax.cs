using System;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Finisar.SQLite;

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

                if(MainWindow.DataLoaded)
                {
                    SQLiteConnection sqlite_conn;
                    SQLiteCommand sqlite_cmd;

                    sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
                    sqlite_conn.Open();

                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = "UPDATE Taxes SET IsValid = " + (_isValid ? 1 : 0) + " WHERE Id = " + TaxId;
                    sqlite_cmd.ExecuteNonQuery();

                    sqlite_conn.Close();
                }
            }
        }

        public Tax() { }

        public Tax(int id, string name, string document, int isValid = 1)
        {
            TaxId = id;
            TaxName = name;
            DocumentName = (document);
            IsValid = isValid == 1;
        }

        public override string ToString()
        {
            return this.TaxId + ". " + this.TaxName;
        }
    }
}

