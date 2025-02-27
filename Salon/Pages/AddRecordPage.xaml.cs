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
    /// Логика взаимодействия для AddRecordPage.xaml
    /// </summary>
    public partial class AddRecordPage : Page
    {
        private Registrations _currentRegistration = new Registrations();
        public AddRecordPage()
        {
            InitializeComponent();
            DataContext = _currentRegistration;
            
        }

        private void SaveChangesRec_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (DtpAppointmentDate.SelectedDate == null)
            {
                errors.AppendLine("Укажите дату и время");
            }
            else
            {
                _currentRegistration.DateRegistration = (DateTime)DtpAppointmentDate.SelectedDate;
            }

            if (_currentRegistration.ClientID <= 0)
                errors.AppendLine("Введите ID клиента");

            if (_currentRegistration.ServiceID <= 0)
                errors.AppendLine("Введите ID услуги");

            if (_currentRegistration.MasterID <= 0)
                errors.AppendLine("Введите ID мастера");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentRegistration.IDRegistration == 0)
                SalonEntities.GetContext().Registrations.Add(_currentRegistration);

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

