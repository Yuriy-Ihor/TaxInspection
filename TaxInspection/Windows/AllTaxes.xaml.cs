using System.Windows;
using Finisar.SQLite;
using TaxInspection.Database_elements;

namespace TaxInspection.Windows
{
    public partial class AllTaxes : Window
    {
        public AllTaxes()
        {
            InitializeComponent();
            ListOfTaxes.ItemsSource = ((App)Application.Current).Taxes;
        }

        private void AddNewTax(object sender, RoutedEventArgs e)
        {
            var newTax = new CreateNewTax();
            newTax.Show();
        }

        private void RemoveSelectedTax(object parameter, RoutedEventArgs e)
        {
            var item = ListOfTaxes.SelectedItem as Tax;

            if (item != null)
            {
                Extensions.Tools.ExecuteQuery("DELETE FROM Taxes WHERE Id = " + item.TaxId);

                ((App)Application.Current).Taxes.Remove(item);
            }
        }
    }

}
