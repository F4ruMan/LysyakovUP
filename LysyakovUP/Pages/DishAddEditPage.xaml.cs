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
    /// Логика взаимодействия для DishAddEditPage.xaml
    /// </summary>
    public partial class DishAddEditPage : Page
    {


        public DishAddEditPage()
        {
            InitializeComponent();
            currentDish = new Dish("", "", 0, 0.0, "");
            DataContext = this;
        }

        public DishAddEditPage(Dish dish)
        {
            InitializeComponent();
            currentDish = dish;
            dishBackup = new Dish(dish.Name, dish.Description, dish.CategoryID, dish.Price, dish.Ingrediense);
            DataContext = this;
            isEdit = true;
        }
        public Dish currentDish { set; get; }
        private Dish dishBackup;
        private bool isEdit = false;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool vseOK = true;
            if (currentDish.Name.Length > 50)
            {
                CustomMessageBox.CustomMB.Show("Название не может привышать ");
                vseOK = false;
            }
            if (currentDish.Name.Length == 0)
            {
                CustomMessageBox.CustomMB.Show("Название обязательно");
                vseOK = false;
            }
            if (currentDish.Description.Length > 200)
            {
                CustomMessageBox.CustomMB.Show("Описание слишком длинное");
                vseOK = false;
            }
            if (!App.categories.Select(c => c.Id).Contains(currentDish.CategoryID))
            {
                CustomMessageBox.CustomMB.Show($"Rfntujhbb c id - {currentDish.CategoryID} не существует");
                vseOK = false;
            }
            if (currentDish.Price < 0)
            {
                CustomMessageBox.CustomMB.Show("Цена не может быть отрицательной");
                vseOK = false;
            }
            if (currentDish.Ingrediense.Length > 200)
            {
                CustomMessageBox.CustomMB.Show("Состав слишком длинный");
                vseOK = false;
            }
            if (vseOK)
            {
                if (!isEdit)
                {
                    if (App.dishes.Count == 0)
                        currentDish.Id = 1;
                    else
                        currentDish.Id = App.dishes.OrderByDescending(d => d.Id).First().Id + 1;
                    App.dishes.Add(currentDish);
                }
                NavigationService.Navigate(new DishPage());
            }
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                currentDish.Name = dishBackup.Name;
                currentDish.Description = dishBackup.Description;
                currentDish.CategoryID = dishBackup.CategoryID;
                currentDish.Price = dishBackup.Price;
                currentDish.Ingrediense = dishBackup.Ingrediense;
            }
            NavigationService.Navigate(new DishPage());
        }
    }
}
