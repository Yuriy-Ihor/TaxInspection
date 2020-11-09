using System.Collections.ObjectModel;
using System.Windows;
using TaxInspection.Database_elements;

namespace TaxInspection
{
    public partial class App : Application
    {
        public static string DatabaseConnection = @"Data Source=database.db;Version=3;Compress=True;";

        public ObservableCollection<Tax> Taxes { get; set; } = new ObservableCollection<Tax>();
        public ObservableCollection<NaturalPerson> NaturalPersons { get; set; } = new ObservableCollection<NaturalPerson>();
        public ObservableCollection<JuridicalPerson> JuridicalPersons { get; set; } = new ObservableCollection<JuridicalPerson>();
        public ObservableCollection<TaxPayedByNaturalPerson> TaxesPayedByNatPersons { get; set; } = new ObservableCollection<TaxPayedByNaturalPerson>();
        public ObservableCollection<TaxPayedByJuridicalPerson> TaxesPayedByJurPersons { get; set; } = new ObservableCollection<TaxPayedByJuridicalPerson>();

        private void AppStartup(object sender, StartupEventArgs args) { }

    }
}
