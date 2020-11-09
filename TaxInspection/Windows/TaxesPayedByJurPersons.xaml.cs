
using System.Windows;
using Finisar.SQLite;
using TaxInspection.Database_elements;

namespace TaxInspection.Windows
{
    /// <summary>
    /// Interaction logic for TaxesPayedByJurPersons.xaml
    /// </summary>
    public partial class TaxesPayedByJurPersons : Window
    {
        public TaxesPayedByJurPersons()
        {
            InitializeComponent();
            Taxes.ItemsSource = ((App)Application.Current).TaxesPayedByJurPersons;
        }

        private void RemoveSelectedTax(object parameter, RoutedEventArgs e)
        {
            var item = Taxes.SelectedItem as TaxPayedByJuridicalPerson;
            if (item != null)
            {
                Extensions.Tools.ExecuteQuery("DELETE FROM TaxesPayedByJurPersons WHERE Id = " + item.Id);

                ((App)Application.Current).TaxesPayedByJurPersons.Remove(item);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateNewTaxByJurPerson();
            window.Show();
        }
    }
}
