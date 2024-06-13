using Repositories.Entities;
using Services;
using System.Windows;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminManageRoomDetail.xaml
    /// </summary>
    public partial class AdminManageRoomDetail : Window
    {
        private RoomInformationServices _services = new RoomInformationServices();
        public RoomInformation? SelectedRoom { get; set; } = null;
        public AdminManageRoomDetail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RoomTypeServices roomType = new RoomTypeServices();
            cboRoomTypeId.ItemsSource = roomType.GetRoomTypes();
            //select which attribute to display
            cboRoomTypeId.DisplayMemberPath = nameof(RoomType.RoomTypeName);
            //select which attribute to use to set value
            cboRoomTypeId.SelectedValuePath = nameof(RoomType.RoomTypeId);
            if (this.SelectedRoom != null)
            {//Update mode
                lblRoomDetail.Content = "Update room";
                btnCreateUpdate.Content = "Update";
                //txtRoomId.Text = SelectedRoom.RoomId.ToString();
                //txtRoomId.IsEnabled = false;
                txtRoomNumber.Text = SelectedRoom.RoomNumber.ToString();
                txtRoomDetailDes.Text = SelectedRoom.RoomDetailDescription;
                txtRoomMaxCapacity.Text = SelectedRoom.RoomMaxCapacity.ToString();
                cboRoomTypeId.SelectedIndex = SelectedRoom.RoomTypeId;
                txtRoomStatus.Text = SelectedRoom.RoomStatus.ToString();
                txtRoomPricePerDay.Text = SelectedRoom.RoomPricePerDay.ToString();

            }
            else
            {//Create mode
                //lblRoomDetail.Content = "Create room";
                //txtRoomId.IsEnabled = false;
            }
        }

        private void btnCreateUpdate_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            RoomInformation room = new()
            {
                RoomNumber = txtRoomNumber.Text,
                RoomDetailDescription = txtRoomDetailDes.Text,
                RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                RoomTypeId = cboRoomTypeId.SelectedIndex,
                RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text),
                RoomStatus = byte.Parse(txtRoomStatus.Text)
            };

            if (SelectedRoom != null)
            {
                room.RoomId = SelectedRoom.RoomId;
                //service update method
                message = _services.UpdateFromUI(room);
            }
            else
            {
                //service create method
                message = _services.CreateRoomFromUI(room);
            }
            MessageBox.Show(message, "Result", MessageBoxButton.OK, MessageBoxImage.None);

            this.Close();
        }

    }
}
