
using System.Windows;
using Finisar.SQLite;
using TaxInspection.Database_elements;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for TaxesPayedByJurPersons.xaml
    /// </summary>
    public partial class TaxesPayedByJurPersons : Window
    {
        public TaxesPayedByJurPersons()
        {
            InitializeComponent();
            Taxes.ItemsSource = ((App)Application.Current).TaxesPayedByJurPersons;
        }

        private void RemoveSelectedTax(object parameter, RoutedEventArgs e)
        {
            var item = Taxes.SelectedItem as TaxPayedByJuridicalPerson;
            if (item != null)
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM TaxesPayedByJurPersons WHERE Id = " + item.Id;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();

                try
                {
                    ((App)Application.Current).TaxesPayedByJurPersons.Remove(item);
                }
                catch
                {
                    MessageBox.Show("No item found: " + item.ToString());
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateNewTaxByJurPerson();
            window.Show();
        }
    }
}
