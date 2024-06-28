using Services;
using System.Windows;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminCreateReport.xaml
    /// </summary>
    public partial class AdminCreateReport : Window
    {
        private BookingServices _bookingServices = new();
        public AdminCreateReport()
        {
            InitializeComponent();
        }

        private void btnBackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            this.Close();
        }

        private void dtgShowReport_Loaded(object sender, RoutedEventArgs e)
        {
            dtgShowReport.ItemsSource = null;
            dtgShowReport.ItemsSource = _bookingServices.GetDailyRevenue();
        }
    }
}
