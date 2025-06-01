using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PovarAddEditPage.xaml
    /// </summary>
    public partial class PovarAddEditPage : Page
    {
        public PovarAddEditPage()
        {
            InitializeComponent();
            currentPovar = new Classes.Povar("","","","",null);
            DataContext = this;
            if (App.povars.Count == 0)
                currentPovar.Id = 1;
            else
                currentPovar.Id = App.povars.OrderByDescending(p => p.Id).First().Id + 1;
        }
        public Classes.Povar currentPovar { set; get; }
        Classes.Povar povarBackup;
        bool isEdit = false;
        public PovarAddEditPage(Classes.Povar povar)
        {
            InitializeComponent();
            currentPovar = povar;
            povarBackup = new Classes.Povar(povar.FirstName,povar.LastName,povar.PhoneNumber,povar.Email,povar.Salary);
            DataContext = this;
            isEdit = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool vseOK = true;
            string message1 = "";
            string message2 = "";
            if (currentPovar.FirstName.Length > 50)
                message1 += "Имя";
            if (currentPovar.LastName.Length > 50)
                if (message1.Length > 0)
                    message1 += " и фамилия";
                else
                    message1 += "фамилия";
            if (currentPovar.FirstName.Length == 0)
                message2 += "Имя";
            if (currentPovar.LastName.Length == 0)
                if (message2.Length > 0)
                    message2 += " и фамилия";
                else
                    message2 += "фамилия";
            if (message1.Length > 0)
            { 
            CustomMessageBox.CustomMB.Show(message1 + " длинна должна быть менее иди равна 50 символам");
                vseOK = false;
        }
            if (message2.Length > 0)
            {
                CustomMessageBox.CustomMB.Show(message2 + " не моджет быть пустым");
                vseOK = false;
            }
            if(currentPovar.PhoneNumber.Length==0)
            {
                CustomMessageBox.CustomMB.Show("Номер телефона должен присудствовать");
                vseOK = false;
            }
            if (currentPovar.Email.Length>50)
            {
                CustomMessageBox.CustomMB.Show("Слишком длинный адрес эл.почты");
                vseOK = false;
            }
            if (currentPovar.Email.Length==0)
            {
                CustomMessageBox.CustomMB.Show("эл.почта не должна быть пустой");
                vseOK = false;
            }
            if (currentPovar.Salary<0)
            {
                CustomMessageBox.CustomMB.Show("Зарплата не может быть меньше 0");
                vseOK = false;
            }
            if (vseOK)
            {
                if (!isEdit)
                {
                    App.povars.Add(currentPovar);
                }
                NavigationService.Navigate(new PovarPage());
            }
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                currentPovar.Salary = povarBackup.Salary;
                currentPovar.Email = povarBackup.Email;
                currentPovar.FirstName = povarBackup.FirstName;
                currentPovar.LastName = povarBackup.LastName;
                currentPovar.PhoneNumber = povarBackup.PhoneNumber;
            }
            NavigationService.Navigate(new PovarPage());
        }
    }
}
