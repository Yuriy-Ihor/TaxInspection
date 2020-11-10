using System;
using System.Windows;
using TaxInspection.Database_elements;
using Finisar.SQLite;
using System.Text.RegularExpressions;

namespace TaxInspection.Windows
{
    public partial class CreateNewJuridicalPerson : Window
    {
        public CreateNewJuridicalPerson()
        {
            InitializeComponent();
        }

        private void AddNewPerson(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Неприпустиме значення імені!");
                return;
            }

            int code = 0;

            if(Date.SelectedDate == null || Date.SelectedDate.Value > DateTime.Today)
            {
                MessageBox.Show("Помилка! Неприпустима дата!");
                return;
            }

            if(!int.TryParse(Code.Text, out code))
            {
                MessageBox.Show("Помилка! Код ЄДРПОУ недопустимого значення!");
                return;
            }

            if (code > 99999999)
            {
                MessageBox.Show("Помилка! Код ЄДРПОУ недопустимого значення!");
                return;
            }

            SQLiteConnection sqlite_conn = new SQLiteConnection(App.DatabaseConnection);

            SQLiteCommand sqlite_cmd;
            sqlite_conn.Open();

            JuridicalPerson newPerson = new JuridicalPerson(JuridicalPerson.MaxId++, Name.Text, Date.SelectedDate.Value, code);
           
            string date = Extensions.Tools.ConvertDayTimeToSqlDate(Date.SelectedDate.Value);

            string query = "INSERT INTO JuridicalPersons (Id, Name, RegistrationDate, RegistrationCode) VALUES (" + newPerson.Id + ", '" + newPerson.Name + "', '" + date + "', " + newPerson.RegistrationCode + ");";
            
            sqlite_cmd = new SQLiteCommand(query, sqlite_conn); 
            sqlite_cmd.ExecuteNonQuery();

            ((App)Application.Current).JuridicalPersons.Add(newPerson);
            sqlite_conn.Close();
        }

        private readonly Regex _registrationCodeRegex = new Regex("[^0-9]+");
        private bool isTextAllowed(string text)
        {
            return !_registrationCodeRegex.IsMatch(text);
        }

        public void CheckCodeInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !isTextAllowed(e.Text);
        }
    }
}
