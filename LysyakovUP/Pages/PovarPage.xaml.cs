using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для PovarPage.xaml
    /// </summary>
    public partial class PovarPage : Page
    {
        public PovarPage()
        {
            InitializeComponent();
            dgTable.ItemsSource = null;
            dgTable.ItemsSource = App.povars;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dgTable.ItemsSource = null;
            NavigationService.Navigate(new PovarAddEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            if (dgTable.SelectedItem != null)
            {
                NavigationService.Navigate(new PovarAddEditPage(dgTable.SelectedItem as Classes.Povar));
                dgTable.ItemsSource = null;
            }
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку", false);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTable.SelectedItem != null)
            {
                App.povars.Remove(dgTable.SelectedItem as Classes.Povar);
                dgTable.ItemsSource = null;
                dgTable.ItemsSource = App.povars;
            }
            else
                CustomMessageBox.CustomMB.Show("Сначала выберите строку",false);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Classes.Povar.Save();
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