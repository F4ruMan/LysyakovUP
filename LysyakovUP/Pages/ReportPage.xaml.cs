using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        ObservableCollection<Report> list = new ObservableCollection<Report>();
        public ReportPage()
        {
            InitializeComponent();
            
            foreach(var ordD in App.orders)
            {
                int orederID = ordD.Id;
                string orderDate = ordD.OrderDate.ToString("d");
                var custName = App.customers.FirstOrDefault(c => c.Id == App.orderDetails.FirstOrDefault(o => o.Id == ordD.Id).Id);
                string customer = custName.FirstName+" "+ custName.LastName;
                double? orderTotalAmount = App.orderDetails.Where(o=>o.OrderID==ordD.Id).Sum(o => o.TotalAmount);
                list.Add(new Report(orederID,orderDate,customer,orderTotalAmount));
            }
            list.Add(new Report (null, null, "Итого", list.Select(l => l.OrderTotalAmount).Sum()));
            dgReport.ItemsSource = null;
            dgReport.ItemsSource = list;
            DataContext=this;
        }

        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            if (tbSerch.Text.Length > 0)
            {
                dgReport.ItemsSource = null;
                dgReport.ItemsSource = list.Where(s => s.OrederID.ToString() == tbSerch.Text);
            }
            else
            {
                dgReport.ItemsSource = null;
                dgReport.ItemsSource = list;
            }
        }
    }
    public class Report
    {
        int? orederID;
        string orderDate;
        string customer;
        double? orderTotalAmount;

        public Report(int? orederID, string orderDate, string customer, double? orderTotalAmount)
        {
            this.orederID = orederID;
            this.orderDate = orderDate;
            this.customer = customer;
            this.orderTotalAmount = orderTotalAmount;
        }

        public int? OrederID { get => orederID; set => orederID = value; }
        public string OrderDate { get => orderDate; set => orderDate = value; }
        public string Customer { get => customer; set => customer = value; }
        public double? OrderTotalAmount { get => orderTotalAmount; set => orderTotalAmount = value; }
    }
}
