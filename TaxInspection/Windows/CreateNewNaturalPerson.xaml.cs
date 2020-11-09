
using System.Linq;
using System.Windows;
using TaxInspection.Database_elements;
using Finisar.SQLite;
using System.Text.RegularExpressions;

namespace TaxInspection.Windows
{
    public partial class CreateNewNaturalPerson : Window
    {
        public CreateNewNaturalPerson()
        {
            InitializeComponent();
        }

        private void CreateNewPerson(object sender, RoutedEventArgs e)
        {
            if(Name.Text.Any(char.IsDigit) || string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Неприпустиме значення імені");
                return;
            }

            if(Surname.Text.Any(char.IsDigit) || string.IsNullOrEmpty(Surname.Text))
            {
                MessageBox.Show("Неприпустиме значення прізвища");
                return;
            }

            SQLiteConnection sqlite_conn = new SQLiteConnection(App.DatabaseConnection);

            SQLiteCommand sqlite_cmd;
            sqlite_conn.Open();

            NaturalPerson newPerson = new NaturalPerson(NaturalPerson.MaxId++, Name.Text, Surname.Text, long.Parse(IdentificationCode.Text), int.Parse(PassportCode.Text));
            
            string query = "INSERT INTO NaturalPersons (Id, Name, Surname, IdentificationCode, PassportCode) VALUES (" + newPerson.Id + ", '" + newPerson.Name + "', '" + newPerson.Surname + "', " + newPerson.IdentificationCode + ", '" + newPerson.PassportCode + "');";

            sqlite_cmd = new SQLiteCommand(query, sqlite_conn);
            sqlite_cmd.ExecuteNonQuery();

            ((App)Application.Current).NaturalPersons.Add(newPerson);
            sqlite_conn.Close();
        }

        private readonly Regex _onlyNumbersRegex = new Regex("[^0-9]+");
        private bool isTextAllowed(string text)
        {
            return !_onlyNumbersRegex.IsMatch(text);
        }

        public void CheckIdentificationCodeInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !isTextAllowed(e.Text);
        }

        private void CheckPassportCodeInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !isTextAllowed(e.Text);
        }
    }
}
