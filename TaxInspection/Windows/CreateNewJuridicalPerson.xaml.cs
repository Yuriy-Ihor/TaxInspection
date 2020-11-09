using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaxInspection.Database_elements;
using Finisar.SQLite;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for CreateNewJuridicalPerson.xaml
    /// </summary>
    public partial class CreateNewJuridicalPerson : Window
    {
        public CreateNewJuridicalPerson()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection(App.DatabaseConnection);

            SQLiteCommand sqlite_cmd;
            sqlite_conn.Open();

            JuridicalPerson newPerson = new JuridicalPerson(JuridicalPerson.MaxId++, Name.Text, Date.SelectedDate.Value, int.Parse(Code.Text));
           
            string date = Extensions.Tools.ConvertDayTimeToSqlDate(Date.SelectedDate.Value);

            string query = "INSERT INTO JuridicalPersons (Id, Name, RegistrationDate, RegistrationCode) VALUES (" + newPerson.Id + ", '" + newPerson.Name + "', '" + date + "', " + newPerson.RegistrationCode + ");";
            
            sqlite_cmd = new SQLiteCommand(query, sqlite_conn); 
            sqlite_cmd.ExecuteNonQuery();

            ((App)Application.Current).JuridicalPersons.Add(newPerson);
            sqlite_conn.Close();
        }
    }
}
