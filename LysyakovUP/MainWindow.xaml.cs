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

namespace LysyakovUP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Height = 450;
            Width = 300;
            Classes.Povar.Load();
            Classes.Category.Load();
            Classes.Dish.Load();
            Classes.Order.Load();
            Classes.Customer.Load();
            Classes.OrderDetails.Load();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Classes.Povar.Save();
            Classes.Category.Save();
            Classes.Dish.Save();
            Classes.Order.Save();
            Classes.Customer.Save();
            Classes.OrderDetails.Save();
            Close();
        }

        private void btnState_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnDish_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Visible;
            Width = 1000;
            FrTable.Navigate(new Pages.DishPage());
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Visible;
            Width = 1000;
            FrTable.Navigate(new Pages.OrderPage());
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Visible;
            Width = 1000;
            FrTable.Navigate(new Pages.CustomerPage());
        }

        private void btnPovar_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Visible;
            Width = 1000;
            FrTable.Navigate(new Pages.PovarPage());
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Visible;
            Width = 1000;
            FrTable.Navigate(new Pages.CategoryPage());
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Hidden;
            Width = 300;
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Visible;
            Width = 1000;
            FrTable.Navigate(new Pages.ReportPage());
        }
    }
}
