using Salon.Database;
using System.Linq;
using System.Windows.Controls;
namespace Salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            ServicesDataGrid.ItemsSource = SalonEntities.GetContext().Services.ToList();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AdminPage());
        }
    }
}
