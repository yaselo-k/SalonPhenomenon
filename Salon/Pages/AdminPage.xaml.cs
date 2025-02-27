using Salon.Database;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddRecordPage());
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGrid
            if (RegistrationsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Получаем выделенную строку
            var selectedRow = RegistrationsDataGrid.SelectedItem as Registrations;

            if (selectedRow == null)
            {
                MessageBox.Show("Не удалось получить данные выбранной записи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idRegistration = selectedRow.IDRegistration;

            // Подтверждение удаления
            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить запись с ID {idRegistration}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                using (var context = SalonEntities.GetContext())
                {
                    // Находим запись по ID
                    var registrationToRemove = context.Registrations.Find(idRegistration);

                    if (registrationToRemove == null)
                    {
                        MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Удаляем запись из контекста
                    context.Registrations.Remove(registrationToRemove);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();

                    MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Обновляем DataGrid
                    LoadRegistrationsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении записи: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Метод для загрузки данных в DataGrid
        private void LoadRegistrationsData()
        {
            try
            {
                using (var context = SalonEntities.GetContext())
                {
                    // Получаем все записи из таблицы Registrations
                    var registrations = context.Registrations.ToList();

                    // Привязываем данные к DataGrid
                    RegistrationsDataGrid.ItemsSource = registrations;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeRecord_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выделенную строку из DataGrid
            var selectedRegistration = RegistrationsDataGrid.SelectedItem as Registrations;

            // Проверяем, выбрана ли строка
            if (selectedRegistration == null)
            {
                MessageBox.Show("Выберите запись для изменения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Передаем выбранную запись в ChangeRecordPage
            AdminFrame.MainFrame.Navigate(new ChangeRecordPage(selectedRegistration));
        }
    }
}

