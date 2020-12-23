
namespace TaxInspection.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using TaxInspection.Database_elements;

    public partial class CreateNewTaxByJurPerson : Window
    {
        public CreateNewTaxByJurPerson()
        {
            this.InitializeComponent();

            for (int i = 0; i < ((App)Application.Current).Taxes.Count; i++)
            {
                this.TaxesNames.Add(((App)Application.Current).Taxes[i].TaxName);
            }

            for (int i = 0; i < ((App)Application.Current).JuridicalPersons.Count; i++)
            {
                this.PayersNames.Add(((App)Application.Current).JuridicalPersons[i].Name);
            }

            this.TaxNamesBox.AutoSuggestionList = this.TaxesNames;
            this.PayersNamesBox.AutoSuggestionList = this.PayersNames;
        }

        public List<string> TaxesNames { get; set; } = new List<string>();
        public List<string> PayersNames { get; set; } = new List<string>();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Tax tax = null;
            foreach (var item in ((App)Application.Current).Taxes)
            {
                if (item.TaxName == TaxNamesBox.autoTextBox.Text)
                {
                    tax = item;
                }
            }

            if (!this.checkIfTaxIsValid(tax))
            {
                return;
            }

            JuridicalPerson jurPerson = null;
            foreach (var item in ((App)Application.Current).JuridicalPersons)
            {
                if (item.Name == PayersNamesBox.autoTextBox.Text)
                {
                    jurPerson = item;
                }
            }

            if (jurPerson == null)
            {
                MessageBox.Show("Юридичної особи з такою назвою не існує!");
                return;
            }

            TaxPayedByJuridicalPerson newTax = new TaxPayedByJuridicalPerson(TaxPayedByJuridicalPerson.MaxId++, tax.TaxId, jurPerson.Id, tax.TaxName, jurPerson.Name, PayDate.SelectedDate.Value, int.Parse(Amount.Text));

            string date = Extensions.Tools.ConvertDayTimeToSqlDate(PayDate.SelectedDate.Value); 
            string query = "INSERT INTO TaxesPayedByJurPersons (Id, TaxId, PayerId, TaxName, PayerName, OnPayedDate, Amount) VALUES (" + newTax.Id + ", " + newTax.TaxId + ", " + newTax.PayerId + ", '" + newTax.TaxName + "', '" + newTax.PayerName + "', '" + date + "', " + newTax.Amount + ");";

            Extensions.Tools.ExecuteQuery(query);

            ((App)Application.Current).TaxesPayedByJurPersons.Add(newTax);
        }

        private bool checkIfTaxIsValid(Tax tax)
        {
            if (PayDate.SelectedDate == null || PayDate.SelectedDate.Value > DateTime.Today)
            {
                MessageBox.Show("Помилка! Неприпустима дата!");
                return false;
            }

            if (string.IsNullOrEmpty(Amount.Text) || int.Parse(Amount.Text) <= 0)
            {
                MessageBox.Show("Неприпустимий розмір оплати податку!");
                return false;
            }

            if (tax == null)
            {
                MessageBox.Show("Податку з такою назвою не існує!");
                return false;
            }

            if (!tax.IsValid)
            {
                MessageBox.Show("Цей податок вже не є чинним!");
                return false;
            }

            return true;
        }

        public void CheckAmountInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Extensions.Tools.TextContainsOnlyNumbers(e.Text);
        }
    }
}
