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
    /// Логика взаимодействия для OrderAddEditPage.xaml
    /// </summary>
    public partial class OrderAddEditPage : Page
    {
        public OrderAddEditPage()
        {
            InitializeComponent();
            currentOrder = new Classes.Order(null, 0, DateTime.Now, null);
            DataContext = this;
            cmbPayMethod.ItemsSource = pay;
        }
        public OrderAddEditPage(Classes.Order order)
        {
            InitializeComponent();
            currentOrder = order;
            orderBackup = new Classes.Order(order.OrderNumber,order.CustomerID,order.OrderDate,order.PayMethod);
            DataContext = this;
            isEdit = true;
            cmbPayMethod.ItemsSource = pay;
        }
        public Classes.Order currentOrder { set; get; }
        Classes.Order orderBackup;
        bool isEdit = false;
        string[] pay = new string[] { "Наличными", "Картой" };
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool vseOK = true;
            if(currentOrder.CustomerID==0)
            { 
                CustomMessageBox.CustomMB.Show($"Посетителя c id - {currentOrder.CustomerID} не существует");
                vseOK = false;
            }
            if(currentOrder.OrderDate==null)
            {
                CustomMessageBox.CustomMB.Show("Выберите дату");
                vseOK = false;
            }
            if(currentOrder.PayMethod=="")
            {
                CustomMessageBox.CustomMB.Show("Выберите способ оплаты");
                vseOK = false;
            }
            if (vseOK)
            {
                if (!isEdit)
                {
                    if (App.orders.Count == 0)
                        currentOrder.Id = 1; 
                    else
                        currentOrder.Id = App.orders.OrderByDescending(p => p.Id).First().Id + 1;
                    currentOrder.OrderNumber = Order.GetNumber();
                    App.orders.Add(currentOrder);
                }
                NavigationService.Navigate(new OrderPage());
            }
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                currentOrder.PayMethod = orderBackup.PayMethod;
                currentOrder.CustomerID = orderBackup.CustomerID;
                currentOrder.OrderNumber = orderBackup.OrderNumber;
                currentOrder.OrderDate = orderBackup.OrderDate;
            }
            NavigationService.Navigate(new PovarPage());
        }
    }
}
