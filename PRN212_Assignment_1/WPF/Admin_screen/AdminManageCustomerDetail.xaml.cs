using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnhdlSE181818WPF.Admin_screen
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

        CustomerServices _cusServices = new();
        public Customer SelectedBook { get; set; } = null;
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
                CustomerBirthday = dtpCusBirthday.SelectedDate,
                CustomerStatus = byte.Parse(txtCusStatus.Text),
                Password = txtCusPassword.Text
            };

            if (SelectedBook != null)
            {
                //call service to update book
                customer.CustomerId = int.Parse(txtCusId.Text);
                message = _cusServices.UpdateCustomerFromUi(customer);
            }
            else
            {
                //call service to add book
                message = _cusServices.CreateCustomerFromUi(customer);
            }


            MessageBox.Show(message, "Result", MessageBoxButton.OK,MessageBoxImage.None);

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //update loading
            if (SelectedBook != null)
            {
                lblCustomerDetail.Content = updateHeader;
                btnCreateUpdate.Content = updateButton;
                txtCusId.Text = SelectedBook.CustomerId.ToString();
                txtCusId.Focusable = false;
                txtCusFullName.Text = SelectedBook.CustomerFullName;
                txtCusTelephone.Text = SelectedBook.Telephone;
                txtCusEmailAddr.Text = SelectedBook.EmailAddress;
                dtpCusBirthday.SelectedDate
                    = SelectedBook.CustomerBirthday;
                txtCusStatus.Text = SelectedBook.CustomerStatus.ToString();
                txtCusPassword.Text = SelectedBook.Password;
            }
            else
            {//create lodaing
                lblCustomerDetail.Content = createHeader;
            }
        }


    }
}
