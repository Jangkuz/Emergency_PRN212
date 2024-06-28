using AnhdlSE181818WPF.Resources;
using Repositories.DTOs;
using Repositories.Entities;
using Services;
using Services.HelperClass;
using System.Windows;

namespace AnhdlSE181818WPF.Customer_screen
{
    /// <summary>
    /// Interaction logic for CustomerViewBookingReservation.xaml
    /// </summary>
    public partial class CustomerViewBookingReservation : Window
    {
        private BookingServices _bookingServices = new();
        public Customer? CurUser { get; set; }

        public CustomerViewBookingReservation()
        {
            InitializeComponent();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResuableEvent.OnWindowLoaded(sender, e, CurUser);

        }

        private void dtgShowReservation_Loaded(object sender, RoutedEventArgs e)
        {
            dtgShowReservation.ItemsSource = null;
            var tempList = _bookingServices.GetReservationBasedOnCustomer(CurUser!);
            if(tempList != null)
            {
                List<BookingReservationDTOs> resultList = new();
                tempList.ForEach(bk => resultList.Add(bk.ToBookingReservationDto()));
                dtgShowReservation.ItemsSource = resultList;
            }
        }
    }
}
