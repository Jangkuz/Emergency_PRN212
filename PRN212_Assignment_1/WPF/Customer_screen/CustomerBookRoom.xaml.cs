using AnhdlSE181818WPF.Resources;
using Repositories.Entities;
using Services;
using Services.HelperClass;
using System.Windows;
using System.Windows.Controls;

namespace AnhdlSE181818WPF.Customer_screen
{
    /// <summary>
    /// Interaction logic for CustomerBookRoom.xaml
    /// </summary>
    public partial class CustomerBookRoom : Window
    {
        private RoomInformationServices _roomServices = new();
        private BookingServices _bookingServices = new();
        private List<RoomInformation>? _selectRooms;
        public Customer? CurUser { get; set; }
        public CustomerBookRoom()
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

        private void dtgShowRoom_Loaded(object sender, RoutedEventArgs e)
        {
            //for developing pupose
            dtgShowRoom.ItemsSource = _roomServices.GetAllRoomInformationToUI();
            //for developing pupose
        }

        private void dtgShowRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgShowRoom.SelectedItems.Count > 0)
            {
                _selectRooms = new();
                foreach (var selectedItem in dtgShowRoom.SelectedItems)
                {
                    if (selectedItem is RoomInformation room)
                    {
                        _selectRooms.Add(room);
                    }
                }
            }
            else
            {
                _selectRooms = null;
            }
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            if (CurUser != null && _selectRooms != null)
            {

                if (dtpReserationStartDate.SelectedDate != null && dtpReserationEndDate.SelectedDate != null)
                {
                    DateTime startDate = (DateTime)dtpReserationStartDate.SelectedDate;
                    DateTime endDate = (DateTime)dtpReserationEndDate.SelectedDate;
                    result = _bookingServices.BookRoomFromUI(CurUser, _selectRooms, DateOnly.FromDateTime(startDate), DateOnly.FromDateTime(endDate));
                }//end date is valid
                else
                {
                    result += "Empty date error";
                }
            }//end user, _selected room is valid
            else
            {
                result += "Null object reference";
            }
            MessageBox.Show(result, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
