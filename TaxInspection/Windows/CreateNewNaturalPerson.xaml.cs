
using System.Linq;
using System.Windows;
using TaxInspection.Database_elements;
using Finisar.SQLite;
using System.Text.RegularExpressions;
using System;

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
            if (!checkUserInputs())
                return;

            SQLiteConnection sqlite_conn = new SQLiteConnection(SQLDataLoader.DatabaseConnection);

            SQLiteCommand sqlite_cmd;
            sqlite_conn.Open();

            NaturalPerson newPerson = new NaturalPerson(NaturalPerson.MaxId++, Name.Text, Surname.Text, long.Parse(IdentificationCode.Text), int.Parse(PassportCode.Text));
            
            string query = "INSERT INTO NaturalPersons (Id, Name, Surname, IdentificationCode, PassportCode) VALUES (" + newPerson.Id + ", '" + newPerson.Name + "', '" + newPerson.Surname + "', " + newPerson.IdentificationCode + ", '" + newPerson.PassportCode + "');";

            sqlite_cmd = new SQLiteCommand(query, sqlite_conn);
            sqlite_cmd.ExecuteNonQuery();

            ((App)Application.Current).NaturalPersons.Add(newPerson);
            sqlite_conn.Close();
        }

        private bool checkUserInputs()
        {
            if (Name.Text.Any(char.IsDigit) || string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Неприпустиме значення імені");
                return false;
            }

            if (Surname.Text.Any(char.IsDigit) || string.IsNullOrEmpty(Surname.Text))
            {
                MessageBox.Show("Неприпустиме значення прізвища!");
                return false;
            }

            if (string.IsNullOrEmpty(IdentificationCode.Text))
            {
                MessageBox.Show("Поле з ідентифікаційним кодом не може бути пустим!");
                return false;
            }

            if (checkIfIdentificationCodeIsUsed(long.Parse(IdentificationCode.Text)))
            {
                MessageBox.Show("Особа з таким ідентифікаційним вже існує!");
                return false;
            }

            if (checkIfPassportCodeIsUsed(int.Parse(PassportCode.Text)))
            {
                MessageBox.Show("Особа з таким кодом паспорту вже існує!");
                return false;
            }

            if (string.IsNullOrEmpty(PassportCode.Text))
            {
                MessageBox.Show("Поле з кодом паспорту не може бути пустим!");
                return false;
            }

            return true;
        }

        private bool checkIfPassportCodeIsUsed(int code)
        {
            for (int i = 0; i < ((App)Application.Current).NaturalPersons.Count; i++)
            {
                var item = ((App)Application.Current).NaturalPersons[i];

                if (item.PassportCode == code)
                    return true;
            }

            return false;
        }

        private bool checkIfIdentificationCodeIsUsed(long code)
        {
            for (int i = 0; i < ((App)Application.Current).NaturalPersons.Count; i++)
            {
                var item = ((App)Application.Current).NaturalPersons[i];

                if (item.IdentificationCode == code)
                    return true;
            }

            return false;
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
