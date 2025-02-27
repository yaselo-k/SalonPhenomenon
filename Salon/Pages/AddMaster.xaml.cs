using Salon.Database;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace Salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddMaster.xaml
    /// </summary>
    public partial class AddMaster : Page
    {
        private Masters _currentMasters = new Masters();
        public AddMaster()
        {
            InitializeComponent();
            DataContext = _currentMasters;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentMasters.MasterName))
                errors.AppendLine("Введите имя мастера");
            if (string.IsNullOrWhiteSpace(_currentMasters.MasterSurname))
                errors.AppendLine("Введите фамилию мастера");
            if (string.IsNullOrWhiteSpace(_currentMasters.MasterPatronymic))
                errors.AppendLine("Введите отчество мастера");
            if (string.IsNullOrWhiteSpace(_currentMasters.MasterPhoneNumber))
                errors.AppendLine("Введите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentMasters.MasterSpecialization))
                errors.AppendLine("Введите специализацию");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = SalonEntities.GetContext())
                {
                    context.Masters.Add(_currentMasters);
                    context.SaveChanges();
                    MessageBox.Show("Мастер успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
