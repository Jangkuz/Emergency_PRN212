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

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void btnManageCustomer_Click(object sender, RoutedEventArgs e)
        {
            AdminManageCustomer win = new();
            win.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }

        private void btnManageRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
