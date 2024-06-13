using AnhdlSE181818WPF.Resources;
using Repositories.Entities;
using Services;
using System.Windows;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for CustomerMain.xaml
    /// </summary>
    public partial class CustomerMain : Window
    {
        public Customer? curUser { get; set; } = null;

        public CustomerMain()
        {
            InitializeComponent();
            //For debugging purpose
            CustomerServices cusService = new CustomerServices();
            curUser = cusService.CheckLogin("ElizabethTaylor@FUMiniHotel.org", "144@");
            //For debugging purpose
        }

        private void btnManageCustomer_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResuableEvent.OnWindowLoaded(sender, e, curUser);
        }
    }
}
