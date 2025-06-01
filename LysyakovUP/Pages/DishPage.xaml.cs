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
    /// Логика взаимодействия для DishPage.xaml
    /// </summary>
    public partial class DishPage : Page
    {
        public DishPage()
        {
            InitializeComponent();
            dgTable.ItemsSource = null;
            dgTable.ItemsSource = App.dishes; // Assuming App.dishes is an ObservableCollection<Dish>
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DishAddEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
                NavigationService.Navigate(new DishAddEditPage(dgTable.SelectedItem as Dish));
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
            {
                App.dishes.Remove(dgTable.SelectedItem as Dish);
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.dishes;
            }
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Dish.Save(); // Assuming Dish class has a Save method similar to Povar
        }

        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            if (tbSerch.Text.Length > 0)
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.dishes.Where(s => s.Id.ToString() == tbSerch.Text);
            }
            else
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.dishes;
            }
        }
    }
}
