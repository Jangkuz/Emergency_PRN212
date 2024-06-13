using Repositories.Entities;
using Services;
using Services.HelperClass;
using System.Windows;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminManageCustomerDetail.xaml
    /// </summary>
    public partial class AdminManageCustomerDetail : Window
    {
        private const string updateHeader = "Update customer";
        private const string createHeader = "Create customer";
        private const string updateButton = "Update";
        private const string createButton = "Create";

        private CustomerServices _cusServices = new();
        public Customer? SelectedCustomer { get; set; } = null;
        public AdminManageCustomerDetail()
        {
            InitializeComponent();
        }

        private void btnCreateUpdate_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            Customer customer = new()
            {
                //CustomerId = int.Parse(txtCusId.Text),
                CustomerFullName = txtCusFullName.Text,
                Telephone = txtCusTelephone.Text,
                EmailAddress = txtCusEmailAddr.Text,
                CustomerBirthday = dtpCusBirthday.SelectedDate.FromDateTimeToDateOnly(),
                CustomerStatus = byte.Parse(txtCusStatus.Text),
                Password = txtCusPassword.Text
            };

            if (SelectedCustomer != null)
            {
                //call service to update book
                customer.CustomerId = SelectedCustomer.CustomerId;
                message = _cusServices.UpdateCustomerFromUi(customer);
            }
            else
            {
                //call service to add book
                message = _cusServices.CreateCustomerFromUi(customer);
            }


            MessageBox.Show(message, "Result", MessageBoxButton.OK, MessageBoxImage.None);

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //update loading
            if (SelectedCustomer != null)
            {
                lblCustomerDetail.Content = updateHeader;
                btnCreateUpdate.Content = updateButton;
                //txtCusId.Text = SelectedCustomer.CustomerId.ToString();
                //txtCusId.IsEnabled = false;
                txtCusFullName.Text = SelectedCustomer.CustomerFullName;
                txtCusTelephone.Text = SelectedCustomer.Telephone;
                txtCusEmailAddr.Text = SelectedCustomer.EmailAddress;
                dtpCusBirthday.SelectedDate
                    = SelectedCustomer.CustomerBirthday.FromDateOnlyToDateTime();
                txtCusStatus.Text = SelectedCustomer.CustomerStatus.ToString();
                txtCusPassword.Text = SelectedCustomer.Password;
            }
            else
            {//create lodaing
                lblCustomerDetail.Content = createHeader;
                //txtCusId.Focusable = false;
            }
        }


    }
}
