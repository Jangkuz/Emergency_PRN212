using AnhdlSE181818WPF.Admin_screen;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnhdlSE181818WPF
{
    /// <summary>
    /// Interaction logic for AdminManageCustomer.xaml
    /// </summary>
    public partial class AdminManageCustomer : Window
    {
        private CustomerServices _customerServices = new CustomerServices();
        private Customer? _selected = null;
        public AdminManageCustomer()
        {
            InitializeComponent();
        }

        private void FillDataGrid()
        {
            dtgShowCustomer.ItemsSource = null;
            dtgShowCustomer.ItemsSource = _customerServices.GetCustomers();
        }

        private void btnBackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();
            this.Hide();
        }

        private void dtgShowCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            //dtgShowCustomer.ItemsSource = null; //clean
            //dtgShowCustomer.ItemsSource = service.GetCustomers();
            FillDataGrid();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dtgShowCustomer.ItemsSource = null;
            dtgShowCustomer.ItemsSource = _customerServices.SearchByNameAndEmail(txtSearchName.Text, txtSearchEmail.Text);
        }

        private void dtgShowCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgShowCustomer.SelectedItems.Count > 0)
            {
                _selected = (Customer)dtgShowCustomer.SelectedItem;
            }
            else
            {
                _selected = null;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                System.Windows.MessageBox.Show("Please select one customer to delete!", "Select one customer", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MessageBoxResult answer = System.Windows.MessageBox.Show($"Are you sure that you want to delete {_selected.CustomerFullName}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(answer == MessageBoxResult.No)
            {
                return;
            }

            _customerServices.DeleteCustomerFromUI(_selected);

            FillDataGrid();

            _selected = null;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            AdminManageCustomerDetail w = new();
            w.ShowDialog();

            FillDataGrid();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(_selected != null)
            {
                AdminManageCustomerDetail w = new();
                w.SelectedBook = _selected;

                w.ShowDialog();
                FillDataGrid();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a certain customer to edit!", "Select on customer", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
