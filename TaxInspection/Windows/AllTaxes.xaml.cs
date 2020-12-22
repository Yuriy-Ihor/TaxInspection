
namespace TaxInspection.Windows
{
    using System.Windows;
    using System.Collections.ObjectModel;
    using TaxInspection.Database_elements;

    public partial class AllTaxes : Window
    {
        public AllTaxes()
        {
            this.InitializeComponent();
            ListOfTaxes.ItemsSource = ((App)Application.Current).Taxes;
        }

        private void addNewTax(object sender, RoutedEventArgs e)
        {
            var newTax = new CreateNewTax();
            newTax.Show();
        }

        private void removeSelectedTax(object parameter, RoutedEventArgs e)
        {
            var item = ListOfTaxes.SelectedItem as Tax;

            if (item != null)
            {
                bool taxIsUsedInNaturalPersonsTable = checkIfTaxIsUsed(item, ((App)Application.Current).TaxesPayedByNatPersons);
                bool taxIsUsedInJuridicalPersonsTable = checkIfTaxIsUsed(item, ((App)Application.Current).TaxesPayedByJurPersons);

                if (taxIsUsedInNaturalPersonsTable || taxIsUsedInJuridicalPersonsTable)
                {
                    MessageBox.Show("Податок вже існує в базі!");
                    return;
                }

                Extensions.Tools.ExecuteQuery("DELETE FROM Taxes WHERE Id = " + item.TaxId);

                ((App)Application.Current).Taxes.Remove(item);
            }
        }

        private bool checkIfTaxIsUsed<T>(Tax tax, ObservableCollection<T> payedTaxes) where T : PayedTax
        {
            for (int i = 0; i < payedTaxes.Count; i++)
            {
                var item = payedTaxes[i];

                if (item.TaxId == tax.TaxId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
