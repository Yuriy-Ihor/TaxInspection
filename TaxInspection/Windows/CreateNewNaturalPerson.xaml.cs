
using System.Windows;
using TaxInspection.Database_elements;
using Finisar.SQLite;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for CreateNewNaturalPerson.xaml
    /// </summary>
    public partial class CreateNewNaturalPerson : Window
    {
        public CreateNewNaturalPerson()
        {
            InitializeComponent();
        }

        private void CreateNewPerson(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection(App.DatabaseConnection);

            SQLiteCommand sqlite_cmd;
            sqlite_conn.Open();

            NaturalPerson newPerson = new NaturalPerson(NaturalPerson.MaxId++, Name.Text, Surname.Text, int.Parse(IdentificationCode.Text), int.Parse(PassportCode.Text));
            
            string query = "INSERT INTO NaturalPersons (Id, Name, Surname, IdentificationCode, PassportCode) VALUES (" + newPerson.Id + ", '" + newPerson.Name + "', '" + newPerson.Surname + "', " + newPerson.IdentificationCode + ", '" + newPerson.PassportCode + "');";

            sqlite_cmd = new SQLiteCommand(query, sqlite_conn);
            sqlite_cmd.ExecuteNonQuery();

            ((App)Application.Current).NaturalPersons.Add(newPerson);
            sqlite_conn.Close();
        }
    }
}
