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
    /// Логика взаимодействия для OrderDetailsAddEditPage.xaml
    /// </summary>
    public partial class OrderDetailsAddEditPage : Page
    {
        public OrderDetailsAddEditPage()
        {
            InitializeComponent();
            currentOrderDetail = new Classes.OrderDetails(0, 0, 0, null);
            DataContext = this;
        }
        public OrderDetailsAddEditPage(OrderDetails od)
        {
            InitializeComponent();
            currentOrderDetail = od;
            odDetailBackup = new Classes.OrderDetails(od.OrderID, od.DishID, od.Quantity, od.TotalAmount);
            DataContext = this;
            isEdit = true;
        }
        public Classes.OrderDetails currentOrderDetail { set; get; }
        Classes.OrderDetails odDetailBackup;
        bool isEdit = false;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool vseOK = true;
            if (!App.orders.Select(o=>o.Id).Contains(currentOrderDetail.OrderID))
            {
                CustomMessageBox.CustomMB.Show($"Заказа c id - {currentOrderDetail.OrderID} не существует");
                vseOK = false;
            }
            if (!App.dishes.Select(d => d.Id).Contains(currentOrderDetail.DishID))
            {
                CustomMessageBox.CustomMB.Show($"Блюда c id - {currentOrderDetail.DishID} не существует");
                vseOK = false;
            }
            if (currentOrderDetail.Quantity==0)
            {
                CustomMessageBox.CustomMB.Show($"Количество не должно быть 0");
                vseOK = false;
            }
            if (vseOK)
            {
                if (!isEdit)
                {
                    if (App.orderDetails.Count == 0)
                        currentOrderDetail.Id = 1;
                    else
                        currentOrderDetail.Id = App.orderDetails.OrderByDescending(p => p.Id).First().Id + 1;
                    currentOrderDetail.UnitPrice = App.dishes.FirstOrDefault(d => d.Id == currentOrderDetail.DishID).Price;
                    currentOrderDetail.TotalAmount = currentOrderDetail.UnitPrice * currentOrderDetail.Quantity;
                    App.orderDetails.Add(currentOrderDetail);
                }
                NavigationService.Navigate(new OrderDetailsPage());
            }
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                currentOrderDetail.OrderID = odDetailBackup.OrderID;
                currentOrderDetail.DishID = odDetailBackup.DishID;
                currentOrderDetail.Quantity = odDetailBackup.Quantity;
                currentOrderDetail.TotalAmount = odDetailBackup.TotalAmount;
                currentOrderDetail.UnitPrice = odDetailBackup.UnitPrice;
            }
            NavigationService.Navigate(new OrderDetailsPage());
        }
    }
}
