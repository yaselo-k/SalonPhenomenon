﻿using Salon.Database;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
