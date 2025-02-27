using Salon.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeRecordPage.xaml
    /// </summary>
    public partial class ChangeRecordPage : Page
    {
        private Registrations _currentRegistrations = new Registrations();
        public ChangeRecordPage(Registrations selectedRegistrations)
        {
            InitializeComponent();
            if (selectedRegistrations != null)
                _currentRegistrations = selectedRegistrations;

            DataContext = _currentRegistrations;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentRegistrations.DateRegistration == default(DateTime))
                errors.AppendLine("Укажите дату и время");
            if (_currentRegistrations.ClientID <= 0)
                errors.AppendLine("Введите ID клиента");
            if (_currentRegistrations.ServiceID <= 0)
                errors.AppendLine("Введите ID услуги");
            if (_currentRegistrations.MasterID <= 0)
                errors.AppendLine("Введите ID мастера");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentRegistrations.IDRegistration == 0)
                SalonEntities.GetContext().Registrations.Add(_currentRegistrations);

            try
            {
                SalonEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                AdminFrame.MainFrame.Navigate(new AdminPage());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AdminPage());
        }
    }
}
