﻿
namespace TaxInspection.Windows
{
    using System.Windows;
    using TaxInspection.Database_elements;

    public partial class TaxesPayedByNatPersons : Window
    {
        public TaxesPayedByNatPersons()
        {
            this.InitializeComponent();

            Taxes.ItemsSource = ((App)Application.Current).TaxesPayedByNatPersons;
        }

        public void OpenAddNewNatPersonWindow(object parameter, RoutedEventArgs e)
        {
            var window = new CreateNewTaxByNatPerson();
            window.Show();
        }

        private void RemoveSelectedTax(object parameter, RoutedEventArgs e)
        {
            var item = Taxes.SelectedItem as TaxPayedByNaturalPerson;
            if (item != null)
            {
                Extensions.Tools.ExecuteQuery("DELETE FROM TaxesPayedByNatPersons WHERE Id = " + item.Id);

                ((App)Application.Current).TaxesPayedByNatPersons.Remove(item);
            }
        }
    }
}
