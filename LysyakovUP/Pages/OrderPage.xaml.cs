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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            dgTable.ItemsSource = null;
            dgTable.ItemsSource = App.orders;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderAddEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
                NavigationService.Navigate(new OrderAddEditPage(dgTable.SelectedItem as Classes.Order));
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
            {
                App.orders.Remove(dgTable.SelectedItem as Classes.Order);
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.orders;
            }
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderDetailsPage());
        }

        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            if (tbSerch.Text.Length > 0)
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.orders.Where(s => s.Id.ToString() == tbSerch.Text);
            }
            else
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.orders;
            }
        }
    }
}
