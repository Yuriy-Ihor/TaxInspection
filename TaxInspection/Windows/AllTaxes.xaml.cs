using System.Windows;
using Finisar.SQLite;
using TaxInspection.Database_elements;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for AllTaxes.xaml
    /// </summary>
    public partial class AllTaxes : Window
    {
        public AllTaxes()
        {
            InitializeComponent();
            ListOfTaxes.ItemsSource = ((App)Application.Current).Taxes;
        }

        private void AddNewTax(object sender, RoutedEventArgs e)
        {
            var newTax = new CreateNewTax();
            newTax.Show();
        }

        private void RemoveSelectedTax(object parameter, RoutedEventArgs e)
        {
            var item = ListOfTaxes.SelectedItem as Tax;

            if (item != null)
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM Taxes WHERE Id = " + item.TaxId;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();

                ((App)Application.Current).Taxes.Remove(item);
            }
        }
    }

}
