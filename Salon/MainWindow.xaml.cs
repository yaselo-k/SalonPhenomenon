using Salon.Database;
using Salon.Pages;
using System.Linq;
using System.Windows;

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DbConnect.modelOdb = new SalonEntities();
            AdminFrame.MainFrame = myFrame;
            AdminFrame.MainFrame.Navigate(new Autorization());
            
        }
    }
}
