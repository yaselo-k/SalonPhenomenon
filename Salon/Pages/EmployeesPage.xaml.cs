using Salon.Database;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            MastersDataGrid.ItemsSource = SalonEntities.GetContext().Masters.ToList();
        }

        private void BackMasters_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AdminPage());
        }

        private void AddNewMaster_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddMaster());
        }

        private void DeleteMaster_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGrid
            if (MastersDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите мастера для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получаем выделенную строку
            var selectedMaster = MastersDataGrid.SelectedItem as Masters;

            if (selectedMaster == null)
            {
                MessageBox.Show("Не удалось получить данные выбранного мастера.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idMaster = selectedMaster.IDMaster;

            // Подтверждение удаления
            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить мастера с ID {idMaster}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                using (var context = SalonEntities.GetContext())
                {
                    // Находим мастера по ID
                    var masterToRemove = context.Masters.Find(idMaster);

                    if (masterToRemove == null)
                    {
                        MessageBox.Show("Мастер не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Удаляем мастера из контекста
                    context.Masters.Remove(masterToRemove);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();

                    MessageBox.Show("Мастер успешно удален.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoadMastersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при удалении мастера: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadMastersData()
        {
            try
            {
                using (var context = SalonEntities.GetContext())
                {
                    // Получаем все записи из таблицы Masters
                    var masters = context.Masters.ToList();

                    // Привязываем данные к DataGrid
                    MastersDataGrid.ItemsSource = masters;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackMasters_Click_1(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AdminPage());
        }

    }
}
