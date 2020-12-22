
namespace TaxInspection.Windows
{
    using System;
    using System.Windows;
    using TaxInspection.Database_elements;
    using Extensions;

    public partial class CreateNewJuridicalPerson : Window
    {
        public CreateNewJuridicalPerson()
        {
            InitializeComponent();
        }

        public void AddNewPerson(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Неприпустиме значення імені!");
                return;
            }

            if(Date.SelectedDate == null || Date.SelectedDate.Value > DateTime.Today)
            {
                MessageBox.Show("Помилка! Неприпустима дата!");
                return;
            }

            int code = int.Parse(Code.Text);

            if (checkIfCodeIsUsed(code))
            {
                MessageBox.Show("Помилка! У базі вже існує особа з таким Кодом ЄДРПОУ!");
                return;
            }

            JuridicalPerson newPerson = new JuridicalPerson(JuridicalPerson.MaxId++, Name.Text, Date.SelectedDate.Value, code);
           
            string date = Tools.ConvertDayTimeToSqlDate(Date.SelectedDate.Value);
            string query = "INSERT INTO JuridicalPersons (Id, Name, RegistrationDate, RegistrationCode) VALUES (" + newPerson.Id + ", '" + newPerson.Name + "', '" + date + "', " + newPerson.RegistrationCode + ");";
            
            Tools.ExecuteQuery(query);

            ((App)Application.Current).JuridicalPersons.Add(newPerson);
        }

        private bool checkIfCodeIsUsed(int code)
        {
            for (int i = 0; i < ((App)Application.Current).JuridicalPersons.Count; i++)
            {
                var item = ((App)Application.Current).JuridicalPersons[i];

                if (item.RegistrationCode == code)
                    return true;
            }

            return false;
        }

        public void CheckCodeInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Tools.TextContainsOnlyNumbers(e.Text);
        }
    }
}
