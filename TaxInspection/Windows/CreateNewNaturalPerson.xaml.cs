
namespace TaxInspection.Windows
{
    using System.Linq;
    using System.Windows;
    using TaxInspection.Database_elements;
    using Extensions;

    public partial class CreateNewNaturalPerson : Window
    {
        public CreateNewNaturalPerson()
        {
            InitializeComponent();
        }

        public void CheckIdentificationCodeInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Tools.TextContainsOnlyNumbers(e.Text);
        }

        public void CheckPassportCodeInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Tools.TextContainsOnlyNumbers(e.Text);
        }

        private void CreateNewPerson(object sender, RoutedEventArgs e)
        {
            if (!checkUserInputs())
            {
                return;
            }

            NaturalPerson newPerson = new NaturalPerson(NaturalPerson.MaxId++, Name.Text, Surname.Text, long.Parse(IdentificationCode.Text), int.Parse(PassportCode.Text));
            
            string query = "INSERT INTO NaturalPersons (Id, Name, Surname, IdentificationCode, PassportCode) VALUES (" + newPerson.Id + ", '" + newPerson.Name + "', '" + newPerson.Surname + "', " + newPerson.IdentificationCode + ", '" + newPerson.PassportCode + "');";

            Tools.ExecuteQuery(query);

            ((App)Application.Current).NaturalPersons.Add(newPerson);
        }

        private bool checkUserInputs()
        {
            if (Name.Text.Any(char.IsDigit) || string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Неприпустиме значення імені");
                return false;
            }

            if (Surname.Text.Any(char.IsDigit) || string.IsNullOrEmpty(Surname.Text))
            {
                MessageBox.Show("Неприпустиме значення прізвища!");
                return false;
            }

            if (string.IsNullOrEmpty(IdentificationCode.Text))
            {
                MessageBox.Show("Поле з ідентифікаційним кодом не може бути пустим!");
                return false;
            }

            if (checkIfIdentificationCodeIsUsed(long.Parse(IdentificationCode.Text)))
            {
                MessageBox.Show("Особа з таким ідентифікаційним вже існує!");
                return false;
            }

            if (checkIfPassportCodeIsUsed(int.Parse(PassportCode.Text)))
            {
                MessageBox.Show("Особа з таким кодом паспорту вже існує!");
                return false;
            }

            if (string.IsNullOrEmpty(PassportCode.Text))
            {
                MessageBox.Show("Поле з кодом паспорту не може бути пустим!");
                return false;
            }

            return true;
        }

        private bool checkIfPassportCodeIsUsed(int code)
        {
            for (int i = 0; i < ((App)Application.Current).NaturalPersons.Count; i++)
            {
                var item = ((App)Application.Current).NaturalPersons[i];

                if (item.PassportCode == code)
                {
                    return true;
                }
            }

            return false;
        }

        private bool checkIfIdentificationCodeIsUsed(long code)
        {
            for (int i = 0; i < ((App)Application.Current).NaturalPersons.Count; i++)
            {
                var item = ((App)Application.Current).NaturalPersons[i];

                if (item.IdentificationCode == code)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
