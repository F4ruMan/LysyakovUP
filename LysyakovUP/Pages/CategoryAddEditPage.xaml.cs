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
    /// Логика взаимодействия для CategoryAddEditPage.xaml
    /// </summary>
    public partial class CategoryAddEditPage : Page
    {


        public CategoryAddEditPage()
        {
            InitializeComponent();
            currentCategory = new Category("");
            DataContext = this;
        }
        public CategoryAddEditPage(Category category)
        {
            InitializeComponent();
            currentCategory = category;
            categoryBackup = new Category(category.Name);
            DataContext = this;
            isEdit = true;
        }
        public Category currentCategory { set; get; }
        private Category categoryBackup;
        private bool isEdit = false;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentCategory.Name.Length > 0 & currentCategory.Name.Length <= 50)
            {
                if (!isEdit)
                {
                    if (App.categories.Count == 0)
                        currentCategory.Id = 1;
                    else
                        currentCategory.Id = App.categories.OrderByDescending(c => c.Id).First().Id + 1;
                    App.categories.Add(currentCategory);
                }
                NavigationService.Navigate(new CategoryPage());
            }
            else if (currentCategory.Name.Length <= 50)
                CustomMessageBox.CustomMB.Show("Длина названия не должна привышать 50 символов");
            else
                CustomMessageBox.CustomMB.Show("Категория должна иметь нозвание");
            
        }
        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                currentCategory.Name = categoryBackup.Name;
            }
            NavigationService.Navigate(new CategoryPage());
        }
    }
}
