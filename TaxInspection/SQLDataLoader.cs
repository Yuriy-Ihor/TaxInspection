
namespace TaxInspection
{
    using System;
    using System.Windows;
    using TaxInspection.Database_elements;
    using Finisar.SQLite;

    public class SQLDataLoader
    {
        public static readonly string DatabaseConnection = @"Data Source=database.db;Version=3;Compress=True;";
        public static bool DataLoaded = false;

        public void LoadSQLData()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DatabaseConnection);
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();
            readAllNaturalPersonsFromDatabase(sqlite_cmd, out sqlite_datareader);

            sqlite_cmd = sqlite_conn.CreateCommand();
            readAllJuridicalPersonsFromDatabase(sqlite_cmd, out sqlite_datareader);

            sqlite_cmd = sqlite_conn.CreateCommand();
            readAllTaxesFromDatabase(sqlite_cmd, out sqlite_datareader);

            sqlite_cmd = sqlite_conn.CreateCommand();
            readAllTaxesPayedByNatPersonsFromDatabase(sqlite_cmd, out sqlite_datareader);

            sqlite_cmd = sqlite_conn.CreateCommand();
            readAllTaxesPayedByJurPersonsFromDatabase(sqlite_cmd, out sqlite_datareader);

            sqlite_conn.Close();
            DataLoaded = true;
        }

        private void readAllTaxesPayedByJurPersonsFromDatabase(SQLiteCommand sqlite_cmd, out SQLiteDataReader sqlite_datareader)
        {
            sqlite_cmd.CommandText = "SELECT * FROM TaxesPayedByJurPersons";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                int id = int.Parse(sqlite_datareader["Id"].ToString());
                int taxId = int.Parse(sqlite_datareader["TaxId"].ToString());
                int payerId = int.Parse(sqlite_datareader["PayerId"].ToString());
                string taxName = sqlite_datareader["TaxName"].ToString();
                string payerName = sqlite_datareader["PayerName"].ToString();
                int amount = int.Parse(sqlite_datareader["Amount"].ToString());
                DateTime date = Extensions.Tools.GetDateTimeFromSql(sqlite_datareader["OnPayedDate"].ToString());

                TaxPayedByJuridicalPerson newTax = new TaxPayedByJuridicalPerson(id, taxId, payerId, taxName, payerName, date, amount);

                ((App)Application.Current).TaxesPayedByJurPersons.Add(newTax);
            }

            if (((App)Application.Current).TaxesPayedByJurPersons.Count > 0)
                TaxPayedByJuridicalPerson.MaxId = ((App)Application.Current).TaxesPayedByJurPersons[((App)Application.Current).TaxesPayedByJurPersons.Count - 1].Id + 1;
        }

        private void readAllTaxesPayedByNatPersonsFromDatabase(SQLiteCommand sqlite_cmd, out SQLiteDataReader sqlite_datareader)
        {
            sqlite_cmd.CommandText = "SELECT * FROM TaxesPayedByNatPersons";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                int id = int.Parse(sqlite_datareader["Id"].ToString());
                int taxId = int.Parse(sqlite_datareader["TaxId"].ToString());
                int payerId = int.Parse(sqlite_datareader["PayerId"].ToString());
                string taxName = sqlite_datareader["TaxName"].ToString();
                string payerName = sqlite_datareader["PayerName"].ToString();
                string payerSurname = sqlite_datareader["PayerSurname"].ToString();
                int amount = int.Parse(sqlite_datareader["Amount"].ToString());
                DateTime date = Extensions.Tools.GetDateTimeFromSql(sqlite_datareader["OnPayedDate"].ToString());

                TaxPayedByNaturalPerson newTax = new TaxPayedByNaturalPerson(id, taxId, payerId, taxName, payerName, payerSurname, date, amount);

                ((App)Application.Current).TaxesPayedByNatPersons.Add(newTax);
            }

            if (((App)Application.Current).TaxesPayedByNatPersons.Count > 0)
                Tax.MaxId = ((App)Application.Current).TaxesPayedByNatPersons[((App)Application.Current).TaxesPayedByNatPersons.Count - 1].TaxId + 1;
        }

        private void readAllTaxesFromDatabase(SQLiteCommand sqlite_cmd, out SQLiteDataReader sqlite_datareader)
        {
            sqlite_cmd.CommandText = "SELECT * FROM Taxes";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                int id = int.Parse(sqlite_datareader["Id"].ToString());
                string taxName = sqlite_datareader["TaxName"].ToString();
                string docName = sqlite_datareader["DocumentName"].ToString();
                string str_isValid = sqlite_datareader["IsValid"].ToString();
                int isValid = (str_isValid.ToLower() == "true" ? 1 : 0);

                Tax newTax = new Tax(id, taxName, docName, isValid);

                ((App)Application.Current).Taxes.Add(newTax);
            }

            if (((App)Application.Current).Taxes.Count > 0)
                Tax.MaxId = ((App)Application.Current).Taxes[((App)Application.Current).Taxes.Count - 1].TaxId + 1;
        }

        private void readAllNaturalPersonsFromDatabase(SQLiteCommand sqlite_cmd, out SQLiteDataReader sqlite_datareader)
        {
            sqlite_cmd.CommandText = "SELECT * FROM NaturalPersons";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                NaturalPerson newPerson = new NaturalPerson(int.Parse(sqlite_datareader["Id"].ToString()), sqlite_datareader["Name"].ToString(), sqlite_datareader["Surname"].ToString(), long.Parse(sqlite_datareader["IdentificationCode"].ToString()), int.Parse(sqlite_datareader["PassportCode"].ToString()));

                ((App)Application.Current).NaturalPersons.Add(newPerson);
            }

            if (((App)Application.Current).NaturalPersons.Count > 0)
                NaturalPerson.MaxId = ((App)Application.Current).NaturalPersons[((App)Application.Current).NaturalPersons.Count - 1].Id + 1;
        }

        private void readAllJuridicalPersonsFromDatabase(SQLiteCommand sqlite_cmd, out SQLiteDataReader sqlite_datareader)
        {
            sqlite_cmd.CommandText = "SELECT * FROM JuridicalPersons";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                DateTime dateTime = Extensions.Tools.GetDateTimeFromSql(sqlite_datareader["RegistrationDate"].ToString());

                JuridicalPerson newPerson = new JuridicalPerson(int.Parse(sqlite_datareader["Id"].ToString()), sqlite_datareader["Name"].ToString(), dateTime, int.Parse(sqlite_datareader["RegistrationCode"].ToString()));

                ((App)Application.Current).JuridicalPersons.Add(newPerson);
            }

            if (((App)Application.Current).JuridicalPersons.Count > 0)
                JuridicalPerson.MaxId = ((App)Application.Current).JuridicalPersons[((App)Application.Current).JuridicalPersons.Count - 1].Id + 1;
        }
    }
}
