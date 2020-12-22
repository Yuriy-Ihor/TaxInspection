
namespace TaxInspection.Windows
{
    using System.Windows;
    using TaxInspection.Database_elements;

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
                if(checkIfPersonIsBusy(item))
                {
                    MessageBox.Show("Ця особа вже записана в базі сплачених податків!");
                    return;
                }

                Extensions.Tools.ExecuteQuery("DELETE FROM NaturalPersons WHERE Id = " + item.Id);

                ((App)Application.Current).NaturalPersons.Remove(item);
            }
        }

        private void ShowCreateNewPersonWindow(object sender, RoutedEventArgs e)
        {
            CreateNewNaturalPerson window = new CreateNewNaturalPerson();
            window.Show();
        }

        private bool checkIfPersonIsBusy(NaturalPerson person)
        {
            for (int i = 0; i < ((App)Application.Current).TaxesPayedByNatPersons.Count; i++)
            {
                var item = ((App)Application.Current).TaxesPayedByNatPersons[i];

                if (item.PayerId == person.Id)
                    return true;
            }

            return false;
        }
    }
}
