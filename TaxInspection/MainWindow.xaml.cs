using System;
using System.Windows;
using TaxInspection.Windows;
using TaxInspection.Database_elements;
using Finisar.SQLite;

namespace TaxInspection
{
    public partial class MainWindow : Window
    {
        public static bool DataLoaded = false;

        public MainWindow()
        {
            InitializeComponent();

            readAllNaturalPersonsFromDatabase();
            readAllJuridicalPersonsFromDatabase();
            readAllTaxesFromDatabase();
            readAllTaxesPayedByNatPersonsFromDatabase();
            readAllTaxesPayedByJurPersonsFromDatabase();

            DataLoaded = true;
        }

        private void createTables()
        {
            string commandText1 = "CREATE TABLE NaturalPersons (Id integer primary key, Name varchar(100), Surname varchar(100), IdentificationCode integer, PassportCode integer);";
            string commandText2 = "CREATE TABLE JuridicalPersons (Id integer primary key, Name varchar(100), RegistrationDate DATE, RegistrationCode integer);";
            string commandText3 = "CREATE TABLE Taxes (Id integer primary key, TaxName varchar(100), DocumentName varchar(100), IsValid BIT);";
            string commandText4 = "CREATE TABLE TaxesPayedByJurPersons (Id integer primary key, TaxId integer, PayerId integer, TaxName varchar(100), PayerName varchar(100), OnPayedDate DATE, Amount integer);";
            string commandText5 = "CREATE TABLE TaxesPayedByNatPersons (Id integer primary key, TaxId integer, PayerId integer, TaxName varchar(100), PayerName varchar(100), PayerSurname varchar(100), OnPayedDate DATE, Amount integer);";
      
            Extensions.Tools.ExecuteQuery(commandText1);
            Extensions.Tools.ExecuteQuery(commandText2);
            Extensions.Tools.ExecuteQuery(commandText3);
            Extensions.Tools.ExecuteQuery(commandText4);
            Extensions.Tools.ExecuteQuery(commandText5);
        }

        private void readAllTaxesPayedByJurPersonsFromDatabase()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

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

            sqlite_conn.Close();
        }

        private void readAllTaxesPayedByNatPersonsFromDatabase()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

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

            sqlite_conn.Close();
        }

        private void readAllTaxesFromDatabase()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "SELECT * FROM Taxes";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                int id = int.Parse(sqlite_datareader["Id"].ToString());
                string taxName = sqlite_datareader["TaxName"].ToString();
                string docName = sqlite_datareader["DocumentName"].ToString();
                string str_isValid = sqlite_datareader["IsValid"].ToString();
                int isValid = (str_isValid.ToLower() == "true" ? 1 : 0);

                Tax newTax = new Tax(id, taxName, docName, isValid );

                ((App)Application.Current).Taxes.Add(newTax);
            }

            if (((App)Application.Current).Taxes.Count > 0)
                Tax.MaxId = ((App)Application.Current).Taxes[((App)Application.Current).Taxes.Count - 1].TaxId + 1;

            sqlite_conn.Close();
        }

        private void readAllNaturalPersonsFromDatabase()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM NaturalPersons";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                NaturalPerson newPerson = new NaturalPerson(int.Parse(sqlite_datareader["Id"].ToString()), sqlite_datareader["Name"].ToString(), sqlite_datareader["Surname"].ToString(), int.Parse(sqlite_datareader["IdentificationCode"].ToString()), int.Parse(sqlite_datareader["PassportCode"].ToString()));

                ((App)Application.Current).NaturalPersons.Add(newPerson);
            }

            if (((App)Application.Current).NaturalPersons.Count > 0)
                JuridicalPerson.MaxId = ((App)Application.Current).NaturalPersons[((App)Application.Current).NaturalPersons.Count - 1].Id + 1;

            sqlite_conn.Close();
        }

        private void readAllJuridicalPersonsFromDatabase()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();
           
            sqlite_cmd.CommandText = "SELECT * FROM JuridicalPersons";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                DateTime dateTime = Extensions.Tools.GetDateTimeFromSql(sqlite_datareader["RegistrationDate"].ToString());

                JuridicalPerson newPerson = new JuridicalPerson(int.Parse(sqlite_datareader["Id"].ToString()), sqlite_datareader["Name"].ToString(), dateTime, int.Parse(sqlite_datareader["RegistrationCode"].ToString()));

                ((App)Application.Current).JuridicalPersons.Add(newPerson);
            }

            if(((App)Application.Current).JuridicalPersons.Count > 0)
                JuridicalPerson.MaxId = ((App)Application.Current).JuridicalPersons[((App)Application.Current).JuridicalPersons.Count - 1].Id + 1;

            sqlite_conn.Close();
        }

        private void ShowAllTaxes(object sender, RoutedEventArgs e)
        {
            var allTaxes = new AllTaxes();
            allTaxes.Show();
        }

        private void ShowAllNaturalPersons(object sender, RoutedEventArgs e)
        {
            var naturalPersons = new NaturalPersons();
            naturalPersons.Show();
        }

        private void ShowAllJuridicalPersons(object sender, RoutedEventArgs e)
        {
            var jurPersons = new JuridicalPersons();
            jurPersons.Show();
        }

        private void ShowAllTaxesPayedByNaturalPersons(object sender, RoutedEventArgs e)
        {
            var window = new TaxesPayedByNatPersons();
            window.Show();
        }

        private void ShowAllTaxesPayedByJuridicalPersons(object sender, RoutedEventArgs e)
        {
            var window = new TaxesPayedByJurPersons();
            window.Show();
        }
    }
}
