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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            RegistrationsDataGrid.ItemsSource = SalonEntities.GetContext().Registrations.ToList();
        }

        private void BTServices_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ServicesPage());
        }

        private void BTClients_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ClientsPage());
        }

        private void BTEmployees_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new EmployeesPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
