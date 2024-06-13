using Repositories.Entities;
using Services;
using System.Windows;
using System.Windows.Controls;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminManageRoom.xaml
    /// </summary>
    public partial class AdminManageRoom : Window
    {
        private RoomInformationServices _roomService = new RoomInformationServices();
        private RoomInformation? _selected = null;
        public AdminManageRoom()
        {
            InitializeComponent();
        }

        private void FillDataGridRoom()
        {
            dtgShowRoom.ItemsSource = null;
            dtgShowRoom.ItemsSource = _roomService.GetAllRoomInformationToUI();
        }


        private void btnBackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            this.Close();
        }

        private void dtgShowRoom_Loaded(object sender, RoutedEventArgs e)
        {
            dtgShowRoom.ItemsSource = null;
            dtgShowRoom.ItemsSource = _roomService.GetAllRoomInformationToUI();
        }

        private void dtgShowRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgShowRoom.SelectedItems.Count > 0)
            {
                _selected = (RoomInformation)dtgShowRoom.SelectedItem;
            }
            else
            {
                _selected = null;
            }
        }



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //to delete => to select
            if (_selected == null)
            {
                System.Windows.MessageBox.Show("Please select one room to delete!", "Select one room", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;

            }

            MessageBoxResult answer = System.Windows.MessageBox.Show($"Are you sure that you want to delete room {_selected.RoomId}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
            {
                return;
            }

            //TODO: make a private pop up helper function
            string message = _roomService.SetRoomStatusAsDeleteFromUI(_selected);
            System.Windows.MessageBox.Show(message, "Result", MessageBoxButton.OK, MessageBoxImage.Question);
            FillDataGridRoom();

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            AdminManageRoomDetail w = new();
            w.ShowDialog();

            FillDataGridRoom();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_selected != null)
            {
                AdminManageRoomDetail w = new();
                w.SelectedRoom = _selected;

                w.ShowDialog();
                FillDataGridRoom();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a certain room to edit!", "Select on room", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }
    }
}
