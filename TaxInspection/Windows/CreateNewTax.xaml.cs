
namespace TaxInspection.Windows
{
    using System.Windows;
    using TaxInspection.Database_elements;

    public partial class CreateNewTax : Window
    {
        public CreateNewTax()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Tax newTax = new Tax(Tax.MaxId++, NameBox.Text, DocumentBox.Text);

            string query = "INSERT INTO Taxes (Id, TaxName, DocumentName, IsValid) VALUES (" + newTax.TaxId + ", '" + newTax.TaxName + "', '" + newTax.DocumentName + "', '" + 1 + "');";

            Extensions.Tools.ExecuteQuery(query);

            ((App)Application.Current).Taxes.Add(newTax);
        }
    }
}
