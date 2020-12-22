using Finisar.SQLite;
using System.Windows;
using TaxInspection.Database_elements;


namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for CreateNewTax.xaml
    /// </summary>
    public partial class CreateNewTax : Window
    {
        public CreateNewTax()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection(SQLDataLoader.DatabaseConnection);

            SQLiteCommand sqlite_cmd;
            sqlite_conn.Open();

            Tax newTax = new Tax(Tax.MaxId++, NameBox.Text, DocumentBox.Text);

            string query = "INSERT INTO Taxes (Id, TaxName, DocumentName, IsValid) VALUES (" + newTax.TaxId + ", '" + newTax.TaxName + "', '" + newTax.DocumentName + "', '" + 1 + "');";

            sqlite_cmd = new SQLiteCommand(query, sqlite_conn);
            sqlite_cmd.ExecuteNonQuery();

            ((App)Application.Current).Taxes.Add(newTax);
            sqlite_conn.Close();
        }
    }
}
