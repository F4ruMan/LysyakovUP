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
    /// Логика взаимодействия для CustomerAddEditPage.xaml
    /// </summary>
    public partial class CustomerAddEditPage : Page
    {
        public Customer currentCustomer { set; get; }
        private Customer customerBackup;
        private bool isEdit = false;

        public CustomerAddEditPage()
        {
            InitializeComponent();
            currentCustomer = new Customer("", "");
            DataContext = this;
        }

        public CustomerAddEditPage(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
            customerBackup = new Customer(customer.FirstName, customer.LastName);
            DataContext = this;
            isEdit = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string message1 = "";
            string message2 = "";
            if (currentCustomer.FirstName.Length > 50)
                message1 += "Имя";
            if (currentCustomer.LastName.Length > 50)
                if (message1.Length > 0)
                    message1 += " и фамилия";
                else
                    message1 += "фамилия";
            if (currentCustomer.FirstName.Length == 0)
                message2 += "Имя";
            if (currentCustomer.LastName.Length == 0)
                if (message2.Length > 0)
                    message2 += " и фамилия";
                else
                    message2 += "фамилия";
            if (message1.Length == 0 & message2.Length == 0)
            {
                if (!isEdit)
                {
                    if (App.customers.Count == 0)
                        currentCustomer.Id = 1;
                    else
                        currentCustomer.Id = App.customers.OrderByDescending(c => c.Id).First().Id + 1;
                    App.customers.Add(currentCustomer);
                }
                NavigationService.Navigate(new CustomerPage());
            }
            else
            {
                if(message1.Length>0)
                    CustomMessageBox.CustomMB.Show(message1+" длинна должна быть менее иди равна 50 символам");
                if (message2.Length > 0)
                    CustomMessageBox.CustomMB.Show(message2+" не моджет быть пустым");
            }
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                currentCustomer.FirstName = customerBackup.FirstName;
                currentCustomer.LastName = customerBackup.LastName;
            }
            NavigationService.Navigate(new CustomerPage());
        }
    }
}
