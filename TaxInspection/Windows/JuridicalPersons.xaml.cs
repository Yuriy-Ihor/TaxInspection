
using System.Windows;
using TaxInspection.Database_elements;
using Finisar.SQLite;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for JuridicalPersons.xaml
    /// </summary>
    public partial class JuridicalPersons : Window
    {
        public JuridicalPersons()
        {
            InitializeComponent();
            ListOfJuridicalPersons.ItemsSource = ((App)Application.Current).JuridicalPersons;
        }

        private void AddNewPerson_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateNewJuridicalPerson();
            window.Show();
        }

        private void RemoveSelectedPerson_Click(object sender, RoutedEventArgs e)
        {
            var item = ListOfJuridicalPersons.SelectedItem as JuridicalPerson;
            if (item != null)
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                sqlite_conn = new SQLiteConnection(App.DatabaseConnection);
                sqlite_conn.Open();

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM JuridicalPersons WHERE Id = " + item.Id;
                sqlite_cmd.ExecuteNonQuery();

                sqlite_conn.Close();

                ((App)Application.Current).JuridicalPersons.Remove(item);
            }
        }

    }
}
