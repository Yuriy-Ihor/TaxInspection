
namespace TaxInspection.Windows
{
    using System;
    using Extensions;
    using System.Windows;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Finisar.SQLite;
    using TaxInspection.Database_elements;

    public partial class CreateNewTaxByNatPerson : Window
    {
        public CreateNewTaxByNatPerson()
        {
            InitializeComponent();

            for (int i = 0; i < ((App)Application.Current).Taxes.Count; i++)
                TaxesNames.Add(((App)Application.Current).Taxes[i].TaxName);

            for (int i = 0; i < ((App)Application.Current).NaturalPersons.Count; i++)
                PayersNames.Add(((App)Application.Current).NaturalPersons[i].Name + " " + ((App)Application.Current).NaturalPersons[i].Surname);

            this.TaxNamesBox.AutoSuggestionList = TaxesNames;
            this.PayersNamesBox.AutoSuggestionList = PayersNames;

        }

        public List<string> TaxesNames = new List<string>();
        public List<string> PayersNames = new List<string>();

        private void AddNewPerson(object sender, RoutedEventArgs e)
        {
            Tax tax = null;
            foreach (var item in ((App)Application.Current).Taxes)
            {
                if (item.TaxName == TaxNamesBox.autoTextBox.Text)
                {
                    tax = item;
                }
            }

            if(!checkIfTaxIsValid(tax))
            {
                return;
            }

            NaturalPerson natPerson = null;
            string[] personName = PayersNamesBox.autoTextBox.Text.Split(' ');

            foreach (var item in ((App)Application.Current).NaturalPersons)
            {
                if (item.Name == personName[0] && item.Surname == personName[1])
                {
                    natPerson = item;
                }
            }

            if(natPerson == null)
            {
                MessageBox.Show("Фізичної особи з таким іменем не існує!");
                return;
            }

            TaxPayedByNaturalPerson newTax = new TaxPayedByNaturalPerson(TaxPayedByNaturalPerson.MaxId++, tax.TaxId, natPerson.Id, tax.TaxName, natPerson.Name, natPerson.Surname, PayDate.SelectedDate.Value, int.Parse(Amount.Text));

            string date = Extensions.Tools.ConvertDayTimeToSqlDate(PayDate.SelectedDate.Value);
            string query = "INSERT INTO TaxesPayedByNatPersons(Id, TaxId, PayerId, TaxName, PayerName, PayerSurname, OnPayedDate, Amount) VALUES (" + newTax.Id + ", " + newTax.TaxId + ", " + newTax.PayerId + ", '" + newTax.TaxName + "', '" + newTax.PayerName + "', '" + newTax.PayerSurname + "', '" + date + "', " + newTax.Amount + ");";

            Tools.ExecuteQuery(query);

            ((App)Application.Current).TaxesPayedByNatPersons.Add(newTax);
        }

        private bool checkIfTaxIsValid(Tax tax)
        {
            if (tax == null)
            {
                MessageBox.Show("Помилка! Податку з такою назвою не існує!");
                return false;
            }

            if (PayDate.SelectedDate == null || PayDate.SelectedDate.Value > DateTime.Today)
            {
                MessageBox.Show("Помилка! Неприпустима дата!");
                return false;
            }

            if (int.Parse(Amount.Text) <= 0)
            {
                MessageBox.Show("Неприпустимий розмір оплати податку!");
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
            e.Handled = Tools.TextContainsOnlyNumbers(e.Text);
        }
    }
}
