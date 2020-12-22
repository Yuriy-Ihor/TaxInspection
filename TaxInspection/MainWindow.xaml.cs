
namespace TaxInspection
{
    using System.Windows;
    using TaxInspection.Windows;
    using Extensions;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Logger.Log.Info("Window_Loaded event execution started");
            SQLDataLoader dataLoader = new SQLDataLoader();
            dataLoader.LoadSQLData();
            InitializeComponent();
        }

        private void createTables()
        {
            string commandText1 = "CREATE TABLE NaturalPersons (Id integer primary key, Name varchar(100), Surname varchar(100), IdentificationCode BIGINT, PassportCode integer);";
            string commandText2 = "CREATE TABLE JuridicalPersons (Id integer primary key, Name varchar(100), RegistrationDate DATE, RegistrationCode integer);";
            string commandText3 = "CREATE TABLE Taxes (Id integer primary key, TaxName varchar(100), DocumentName varchar(100), IsValid BIT);";
            string commandText4 = "CREATE TABLE TaxesPayedByJurPersons (Id integer primary key, TaxId integer, PayerId integer, TaxName varchar(100), PayerName varchar(100), OnPayedDate DATE, Amount integer);";
            string commandText5 = "CREATE TABLE TaxesPayedByNatPersons (Id integer primary key, TaxId integer, PayerId integer, TaxName varchar(100), PayerName varchar(100), PayerSurname varchar(100), OnPayedDate DATE, Amount integer);";
      
            Tools.ExecuteQuery(commandText1);
            Tools.ExecuteQuery(commandText2);
            Tools.ExecuteQuery(commandText3);
            Tools.ExecuteQuery(commandText4);
            Tools.ExecuteQuery(commandText5);
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
