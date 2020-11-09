using System.Windows;
using Finisar.SQLite;
using TaxInspection.Database_elements;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for TaxesPayedByNatPersons.xaml
    /// </summary>
    public partial class TaxesPayedByNatPersons : Window
    {
        public TaxesPayedByNatPersons()
        {
            InitializeComponent();

            Taxes.ItemsSource = ((App)Application.Current).TaxesPayedByNatPersons;
        }

        public void OpenAddNewNatPersonWindow(object parameter, RoutedEventArgs e)
        {
            var window = new CreateNewTaxByNatPerson();
            window.Show();
        }

        private void RemoveSelectedTax(object parameter, RoutedEventArgs e)
        {
            var item = Taxes.SelectedItem as TaxPayedByNaturalPerson;
            if (item != null)
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM TaxesPayedByNatPersons WHERE Id = " + item.Id;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();

                ((App)Application.Current).TaxesPayedByNatPersons.Remove(item);
            }
        }
    }
}
