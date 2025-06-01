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
    /// Логика взаимодействия для OrderDetailsPage.xaml
    /// </summary>
    public partial class OrderDetailsPage : Page
    {
        public OrderDetailsPage()
        {
            InitializeComponent();
            dgTable.ItemsSource = null;
            dgTable.ItemsSource = App.orderDetails;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderDetailsAddEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
                NavigationService.Navigate(new OrderDetailsAddEditPage(dgTable.SelectedItem as Classes.OrderDetails));
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
            {
                App.orderDetails.Remove(dgTable.SelectedItem as Classes.OrderDetails);
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.orderDetails;
            }
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            if(tbSerch.Text.Length > 0)
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.orderDetails.Where(d => d.Id.ToString() == tbSerch.Text);
            }
            else
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.orderDetails;
            }
        }
    }
}
