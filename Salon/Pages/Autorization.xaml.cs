using Salon.Database;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Salon.Pages
{

    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }


        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DbConnect.modelOdb.Users.FirstOrDefault(x =>
                x.Login == LoginTextBox.Text && x.Password == PasswordBox.Password);
                if (user == null)
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
                else
                {
                    switch (user.RoleID)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, " + user.Username);
                            AdminFrame.MainFrame.Navigate(new AdminPage());
                            break;

                        case 2:
                            MessageBox.Show("Здравствуйте " + user.Username);
                            AdminFrame.MainFrame.Navigate(new AdminPage());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка приложения");
            }
        }
    }
}
