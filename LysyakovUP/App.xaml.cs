using LysyakovUP.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LysyakovUP
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Povar> povars = new ObservableCollection<Povar>();
        public static ObservableCollection<Category> categories = new ObservableCollection<Category>();
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public static ObservableCollection<Order> orders = new ObservableCollection<Order>();
        public static ObservableCollection<OrderDetails> orderDetails = new ObservableCollection<OrderDetails>();
        public static ObservableCollection<Dish> dishes = new ObservableCollection<Dish>();
        /*
         btnHide.Visibility = Visibility.Visible;
            for (int i = 300; i <= 1000; i += 15)
            {
                if(i>1000)
                    i = 1000;
                else if(1000-15<i)
                    i = 1000;
                Width = i;
            }
        */
    }
}
