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
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
            dgTable.ItemsSource = null;
            dgTable.ItemsSource = App.categories;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CategoryAddEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
                NavigationService.Navigate(new CategoryAddEditPage(dgTable.SelectedItem as Category));
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
            {
                App.categories.Remove(dgTable.SelectedItem as Category);
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.categories;
            }
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Category.Save();
        }

        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            if (tbSerch.Text.Length > 0)
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.categories.Where(s => s.Id.ToString() == tbSerch.Text);
            }
            else
            {
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.categories;
            }
        }
    }
}
