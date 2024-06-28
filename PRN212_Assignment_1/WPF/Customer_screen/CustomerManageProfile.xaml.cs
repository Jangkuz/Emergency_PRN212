using AnhdlSE181818WPF.Resources;
using Repositories.Entities;
using Services;
using Services.HelperClass;
using System.Windows;

namespace AnhdlSE181818WPF.Customer_screen
{
    /// <summary>
    /// Interaction logic for CustomerManageProfile.xaml
    /// </summary>
    public partial class CustomerManageProfile : Window
    {
        private CustomerServices _cusServices = new();
        public Customer? CurUser { get; set; }
        public CustomerManageProfile()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CustomerMain w = new();
            w.CurUser = CurUser;
            w.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResuableEvent.OnWindowLoaded(sender, e, CurUser);

            txtCusFullName.Text = CurUser!.CustomerFullName;
            txtCusTelephone.Text = CurUser.Telephone;
            txtCusEmailAddr.Text = CurUser.EmailAddress;
            dtpCusBirthday.SelectedDate
                = CurUser.CustomerBirthday.FromDateOnlyToDateTime();
            txtCusStatus.Text = CurUser.CustomerStatus.ToString();
            txtCusPassword.Text = CurUser.Password;

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
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

            //if (CurUser != null)
            //{
            //call service to update book
            customer.CustomerId = CurUser.CustomerId;
            message = _cusServices.UpdateCustomerFromUi(customer);
            //}
            //else
            //{
            //call service to add book
            //message = _cusServices.CreateCustomerFromUi(customer);
            //}


            MessageBox.Show(message, "Result", MessageBoxButton.OK, MessageBoxImage.None);

            CustomerMain w = new();
            w.CurUser = customer;
            w.Show();
            this.Close();
        }
    }
}
