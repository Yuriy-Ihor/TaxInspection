using System;
using TaxInspection.Database_elements;
using System.Collections.Generic;
using System.Windows;
using Finisar.SQLite;

namespace TaxInspection.Windows
{
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
            Tax tax = new Tax();
            foreach (var item in ((App)Application.Current).Taxes)
            {
                if (item.TaxName == TaxNamesBox.autoTextBox.Text)
                {
                    tax = item;
                }
            }

            if (PayDate.SelectedDate.Value > DateTime.Today)
            {
                MessageBox.Show("Помилка! Неприпустима дата!");
                return;
            }

            if (!tax.IsValid)
            {
                MessageBox.Show("Цей податок вже не є чинним!");
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

            SQLiteConnection sqlite_conn = new SQLiteConnection(App.DatabaseConnection);

            SQLiteCommand sqlite_cmd;
            sqlite_conn.Open();

            TaxPayedByNaturalPerson newTax = new TaxPayedByNaturalPerson(TaxPayedByNaturalPerson.MaxId++, tax.TaxId, natPerson.Id, tax.TaxName, natPerson.Name, natPerson.Surname, PayDate.SelectedDate.Value, int.Parse(Amount.Text));

            string date = Extensions.Tools.ConvertDayTimeToSqlDate(PayDate.SelectedDate.Value);
            string query = "INSERT INTO TaxesPayedByNatPersons(Id, TaxId, PayerId, TaxName, PayerName, PayerSurname, OnPayedDate, Amount) VALUES (" + newTax.Id + ", " + newTax.TaxId + ", " + newTax.PayerId + ", '" + newTax.TaxName + "', '" + newTax.PayerName + "', '" + newTax.PayerSurname + "', '" + date + "', " + newTax.Amount + ");";
            
            ((App)Application.Current).TaxesPayedByNatPersons.Add(newTax);

            sqlite_cmd = new SQLiteCommand(query, sqlite_conn);
            sqlite_cmd.ExecuteNonQuery();

            sqlite_conn.Close();
        }
    }
}
