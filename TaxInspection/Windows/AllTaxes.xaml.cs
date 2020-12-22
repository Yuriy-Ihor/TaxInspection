using System.Windows;
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
                if (checkIfTaxIsUsed(item))
                {
                    MessageBox.Show("Податок вже існує в базі!");
                    return;
                }

                Extensions.Tools.ExecuteQuery("DELETE FROM Taxes WHERE Id = " + item.TaxId);

                ((App)Application.Current).Taxes.Remove(item);
            }
        }

        private bool checkIfTaxIsUsed(Tax tax)
        {
            for(int i = 0; i < ((App)Application.Current).TaxesPayedByNatPersons.Count; i++)
            {
                var item = ((App)Application.Current).TaxesPayedByNatPersons[i];

                if (item.TaxId == tax.TaxId)
                    return true;
            }

            for (int i = 0; i < ((App)Application.Current).TaxesPayedByJurPersons.Count; i++)
            {
                var item = ((App)Application.Current).TaxesPayedByJurPersons[i];

                if (item.TaxId == tax.TaxId)
                    return true;
            }

            return false;
        }

    }

}
