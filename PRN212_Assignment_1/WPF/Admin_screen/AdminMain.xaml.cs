using System.Windows;

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
            AdminManageRoom win = new();
            win.ShowDialog();
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            AdminCreateReport win = new();
            win.ShowDialog();
        }
    }
}
