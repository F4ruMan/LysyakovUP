using LysyakovUP.Classes;
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

namespace LysyakovUP.Pages
{
    /// <summary>
    /// Логика взаимодействия для CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public CustomerPage()
        {
            InitializeComponent();
            dgTable.ItemsSource = null;
            dgTable.ItemsSource = App.customers;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CustomerAddEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
                NavigationService.Navigate(new CustomerAddEditPage(dgTable.SelectedItem as Customer));
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
            {
                App.customers.Remove(dgTable.SelectedItem as Customer);
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.customers;
            }
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer.Save();
        }

        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            if (tbSerch.Text.Length > 0)
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.customers.Where(s => s.Id.ToString() == tbSerch.Text);
            }
            else
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.customers;
            }
        }
    }
}
