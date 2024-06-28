using AnhdlSE181818WPF.Customer_screen;
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
        public Customer? CurUser { get; set; } = null;

        public CustomerMain()
        {
            InitializeComponent();
            //For debugging purpose
            //CustomerServices cusService = new CustomerServices();
            //CurUser = cusService.CheckLogin("ElizabethTaylor@FUMiniHotel.org", "144@");
            ////For debugging purpose
        }

        private void btnManageCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerManageProfile w = new();
            w.CurUser = CurUser;
            w.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResuableEvent.OnWindowLoaded(sender, e, CurUser);
        }

        private void btnBookARoom_Click(object sender, RoutedEventArgs e)
        {
            //TODO: refactor namespace
            CustomerBookRoom w = new();
            w.CurUser = this.CurUser;
            w.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnViewBooking_Click(object sender, RoutedEventArgs e)
        {
            CustomerViewBookingReservation w = new();
            w.CurUser = this.CurUser;
            w.ShowDialog();
        }
    }
}
