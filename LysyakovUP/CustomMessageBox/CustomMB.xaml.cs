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
using System.Windows.Shapes;

namespace LysyakovUP.CustomMessageBox
{
    /// <summary>
    /// Логика взаимодействия для CustomMB.xaml
    /// </summary>
    public partial class CustomMB : Window
    {
        public CustomMB(string message, bool showCancelButton = false)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
            CancelButton.Visibility = showCancelButton ? Visibility.Visible : Visibility.Collapsed;
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public static bool? Show(string message, bool showCancelButton = false)
        {
            var messageBox = new CustomMB(message, showCancelButton);
            return messageBox.ShowDialog();
        }
    }
}
