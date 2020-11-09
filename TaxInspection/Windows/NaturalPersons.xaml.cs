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
                Extensions.Tools.ExecuteQuery("DELETE FROM NaturalPersons WHERE Id = " + item.Id);

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
