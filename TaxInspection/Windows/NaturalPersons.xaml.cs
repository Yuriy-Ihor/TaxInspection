using System.Windows;
using Finisar.SQLite;
using TaxInspection.Database_elements;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for NaturalPersons.xaml
    /// </summary>
    public partial class NaturalPersons : Window
    {
        public NaturalPersons()
        {
            InitializeComponent();
            ListOfNaturalPersons.ItemsSource = ((App)Application.Current).NaturalPersons;
        }

        private void RemoveSelectedPerson(object parameter, RoutedEventArgs e)
        {
            var item = ListOfNaturalPersons.SelectedItem as NaturalPerson;
            if (item != null)
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM NaturalPersons WHERE Id = " + item.Id;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();

                ((App)Application.Current).NaturalPersons.Remove(item);
            }
        }

        private void ShowCreateNewPersonWindow(object sender, RoutedEventArgs e)
        {
            CreateNewNaturalPerson window = new CreateNewNaturalPerson();
            window.Show();
        }
    }
}
