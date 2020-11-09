
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

        private void AddNewPerson(object sender, RoutedEventArgs e)
        {
            var window = new CreateNewJuridicalPerson();
            window.Show();
        }

        private void RemoveSelectedPerson(object sender, RoutedEventArgs e)
        {
            var item = ListOfJuridicalPersons.SelectedItem as JuridicalPerson;
            if (item != null)
            {
                if(checkIfPersonIsBusy(item))
                {
                    MessageBox.Show("Дана юридична особа вже записана в базі сплачених податків!");
                    return;
                }

                Extensions.Tools.ExecuteQuery("DELETE FROM JuridicalPersons WHERE Id = " + item.Id);

                ((App)Application.Current).JuridicalPersons.Remove(item);
            }
        }

        private bool checkIfPersonIsBusy(JuridicalPerson person)
        {
            for (int i = 0; i < ((App)Application.Current).TaxesPayedByJurPersons.Count; i++)
            {
                var item = ((App)Application.Current).TaxesPayedByJurPersons[i];

                if (item.PayerId == person.Id)
                    return true;
            }

            return false;
        }

    }
}
